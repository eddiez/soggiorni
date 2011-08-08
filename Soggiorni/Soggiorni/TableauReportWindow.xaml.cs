using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Soggiorni.Model;
using System.Windows.Forms.Integration;
using Microsoft.Reporting.WinForms;

namespace Soggiorni
{
    /// <summary>
    /// Interaction logic for TableauReportWindow.xaml
    /// </summary>
    public partial class TableauReportWindow : Window
    {
        private List<TableauPivot> celle;
        private ReportViewer rv;

        public TableauReportWindow(List<TableauPivot> tp)
        {
            InitializeComponent();

            this.celle = tp;
            rv = new ReportViewer();
            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.ReportEmbeddedResource = "Soggiorni.TableauReport.rdlc";
            rv.SetDisplayMode(DisplayMode.PrintLayout);
            windowsFormsHost.Child = rv;
        }

        private void buildReport()
        {
            ReportDataSource rds = new ReportDataSource("DataSetTableauPivot", celle);
            rv.LocalReport.DataSources.Add(rds);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            buildReport();
            rv.RefreshReport();
        }
    }
}
