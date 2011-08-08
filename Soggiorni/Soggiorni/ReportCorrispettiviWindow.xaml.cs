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
    /// Interaction logic for ReportCorrispettiviWindow.xaml
    /// </summary>
    public partial class ReportCorrispettiviWindow : Window
    {
        private List<CorrispettivoGiorno> corr;
        private ReportViewer rv;

        public ReportCorrispettiviWindow(List<CorrispettivoGiorno> cg)
        {
            InitializeComponent();

            corr = cg;
            rv = new ReportViewer();
            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.ReportEmbeddedResource = "Soggiorni.CorrispettiviReport.rdlc";
            rv.SetDisplayMode(DisplayMode.PrintLayout);
            windowsFormsHost.Child = rv;
        }

        private void buildReport()
        {

            var rds = new ReportDataSource("DataSetCorr", corr);
            rv.LocalReport.DataSources.Add(rds);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            buildReport();
            rv.RefreshReport();
        }
    }
}
