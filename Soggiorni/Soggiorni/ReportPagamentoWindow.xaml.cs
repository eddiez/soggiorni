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
    /// Interaction logic for ReportPagamentoWindow.xaml
    /// </summary>
    public partial class ReportPagamentoWindow : Window
    {
        private List<VocePagamento> voci;
        private Pagamento pag;
        private ReportViewer rv;

        public ReportPagamentoWindow(Pagamento p, List<VocePagamento> vpl)
        {
            InitializeComponent();

            rv = new ReportViewer();
            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.ReportEmbeddedResource = "Soggiorni.PagamentoReport.rdlc";
            rv.SetDisplayMode(DisplayMode.PrintLayout);
            voci = vpl;
            pag = p;
            windowsFormsHost.Child = rv;

            
        }

        private void buildReport()
        {
            var lp = new List<Pagamento>();
            lp.Add(pag);
            var rdsPag = new ReportDataSource("DataSetIntPagamento", lp);
            rv.LocalReport.DataSources.Add(rdsPag);
            var rdsVoci = new ReportDataSource("DataSetVociPagamento", voci);
            rv.LocalReport.DataSources.Add(rdsVoci);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            buildReport();
            rv.RefreshReport();
        }
    }
}
