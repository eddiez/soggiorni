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
    /// Interaction logic for ReportSchedinaWindow.xaml
    /// </summary>
    public partial class ReportSchedinaWindow : Window
    {
        private List<SchedinaReportItem> schede;
        private ReportViewer rv;

        public ReportSchedinaWindow(List<SchedinaReportItem> l)
        {
            InitializeComponent();
            
            rv = new ReportViewer();
            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.ReportEmbeddedResource = "Soggiorni.SchedinaReport.rdlc";
            this.schede = l;
            rv.SetDisplayMode(DisplayMode.PrintLayout);
            windowsFormsHost.Child = rv;
            
        }

        private void buildReport()
        {
            ReportDataSource rds = new ReportDataSource("DataSetSchedine", schede);
            rv.LocalReport.DataSources.Add(rds);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            buildReport();
            rv.RefreshReport();
        }


    }
}
