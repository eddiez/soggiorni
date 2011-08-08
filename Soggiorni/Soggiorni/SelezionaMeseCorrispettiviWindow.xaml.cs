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
using Soggiorni.Data;
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace Soggiorni
{
    /// <summary>
    /// Interaction logic for SelezionaMeseCorrispettiviWindow.xaml
    /// </summary>
    public partial class SelezionaMeseCorrispettiviWindow : Window
    {
        private Dictionary<string, int> mesi;

        private ObservableCollection<Pagamento> pagamentiDup;
        private ObservableCollection<Pagamento> pagamentiNull;
        private List<Pagamento> allPagamenti;
        private DataAccessGateway dag;
        private AddEditPagamentoWindow aepw;
        private ReportCorrispettiviWindow rcw;


        public SelezionaMeseCorrispettiviWindow()
        {
            InitializeComponent();
            mesi = new Dictionary<string, int>{
                {"Gennaio", 1}, {"Febbraio", 2}, {"Marzo", 3},
                {"Aprile", 4}, {"Maggio", 5}, {"Giugno", 6},
                {"Luglio", 7}, {"Agosto", 8}, {"Settembre", 9},
                {"Ottobre", 10}, {"Novembre", 11}, {"Dicembre", 12}
            };
            cbxMese.DataContext = mesi;

            //selezione default è il mese corrente
            txtboxAnno.Text = DateTime.Today.Year.ToString();
            cbxMese.SelectedIndex = DateTime.Today.Month - 1;

            dag = new DataAccessGateway();
            btnPrint.IsEnabled = false;
            //li istanzio per evitare di fare i controlli isnull
            pagamentiNull = new ObservableCollection<Pagamento>();
            pagamentiDup = new ObservableCollection<Pagamento>();

            //azzero tabella progressivi mancanti
            txtFirstFatt.Text = "";
            txtFirstRic.Text = "";
            txtLastFatt.Text = "";
            txtLastRic.Text = "";
            txtFattManc.Text = "";
            txtRicManc.Text = "";
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            if (rcw != null && rcw.IsVisible) return;

            if (pagamentiDup.Count > 0)
            {
                MessageBox.Show("Impossibile stampare i corrispettivi: ci sono pagamenti con lo stesso numero progressivo",
                    "Pagamenti duplicati", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            if(pagamentiNull.Count > 0)
            {
                var result = MessageBox.Show("Ci sono pagamenti a importo 0, vuoi generare lo stesso i corrispettivi?",
                    "Pagamenti a importo nullo", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (result == MessageBoxResult.No)
                    return;
            }

            //genero corrispettivi
            var cg = new CorrispettiviGenerator(allPagamenti);
            var cglist = cg.getCorrispettivi();

            rcw = new ReportCorrispettiviWindow(cglist);
            rcw.Show();
        }

        private void btnGenera_Click(object sender, RoutedEventArgs e)
        {
            int anno = 0;
            try
            {
                anno = int.Parse(txtboxAnno.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("L'anno dev'essere un numero intero", "Formato anno errato", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int mese = mesi[cbxMese.Text];
            DateTime arrivoDa = new DateTime(anno, mese, 1);
            DateTime arrivoA = arrivoDa.AddMonths(1).AddDays(-1);

            //prendi tutti i pagamenti emessi in questo mese
            allPagamenti = dag.cercaPagamentiByData(arrivoDa, arrivoA);

            if (allPagamenti.Count == 0)
            {
                MessageBox.Show("Non ci sono pagamenti registrati nel mese selezionato", "Nessun pagamento", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            btnPrint.IsEnabled = true;


            var pageqcom = new PagamentiComparer();

            //cerca pagamenti duplicati
            var pagdups = allPagamenti.GroupBy(i => i, pageqcom)
                                      .Where(g => g.Count() > 1)
                                      .Select(g => g.Key).ToList<Pagamento>();
            if (pagdups.Count > 0)
            {
                var plist = new List<Pagamento>();
                foreach (var p in allPagamenti)
                {
                    if (pagdups.Contains(p, pageqcom))
                        plist.Add(p);
                }
                pagamentiDup = new ObservableCollection<Pagamento>(plist);
                //allPagamenti.Intersect<Pagamento>(pagdups, pageqcom).ToList<Pagamento>());
                dataGridPagamentiDup.DataContext = pagamentiDup;
            }

            //cerca pagamenti a importo nullo
            var pagnull = (from p in allPagamenti
                           where p.Totale == 0
                           select p).ToList<Pagamento>();

            if (pagnull.Count > 0)
            {
                pagamentiNull = new ObservableCollection<Pagamento>(pagnull);
                dataGridPagamentiNulli.DataContext = pagamentiNull;
            }

            //verifica progressivi mancanti
            checkProgressiviMancanti(allPagamenti);
        }

        private void checkProgressiviMancanti(List<Pagamento> allPagamenti)
        {
            var fatture = (from p in allPagamenti where p.IsFattura orderby p.Numero select p).ToList<Pagamento>();
            var ricevute = (from p in allPagamenti where !p.IsFattura orderby p.Numero select p).ToList<Pagamento>();

            if (fatture != null & fatture.Count > 0)
            {
                int prima = fatture[0].Numero;
                int ultima =  fatture[fatture.Count - 1].Numero;
                txtFirstFatt.Text = prima.ToString();
                txtLastFatt.Text = ultima.ToString();
                
                var list = new List<int>();
                for(int i = prima; i<= ultima; i++)
                    list.Add(i);

                foreach(var f in fatture){
                    list.Remove(f.Numero);
                }
                string mancFatt = "";
                foreach (int n in list)
                    mancFatt += n.ToString() + " ";
                txtFattManc.Text = mancFatt;
                
            }

            if (ricevute != null & ricevute.Count > 0)
            {
                int prima = ricevute[0].Numero;
                int ultima = ricevute[ricevute.Count - 1].Numero;
                txtFirstRic.Text = prima.ToString();
                txtLastRic.Text = ultima.ToString();
                if ((ultima - prima + 1) != ricevute.Count)
                {
                    var list = new List<int>();
                    for (int i = prima; i <= ultima; i++)
                        list.Add(i);

                    foreach (var r in ricevute)
                    {
                        list.Remove(r.Numero);
                    }
                    string mancRic = "";
                    foreach (int n in list)
                        mancRic += n.ToString() + " ";
                    txtRicManc.Text = mancRic;
                }
            }
        }

        private void dataGridPagamentiDup_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //se ci sono risultati ed almeno uno è selezionato, mostro i dettagli del pagamento
            if ((dataGridPagamentiDup.Items.Count > 0) && (dataGridPagamentiDup.SelectedItems.Count > 0))
            {
                aepw = new AddEditPagamentoWindow((Pagamento)dataGridPagamentiDup.SelectedItems[0]);
                aepw.ShowDialog();

                if (aepw.DialogResult.HasValue && aepw.DialogResult.Value)
                {
                    pagamentiDup.Clear();
                    pagamentiNull.Clear();
                    btnPrint.IsEnabled = false;
                }
            }
        }

        private void dataGridPagamentiNulli_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //se ci sono risultati ed almeno uno è selezionato, mostro i dettagli del pagamento
            if ((dataGridPagamentiNulli.Items.Count > 0) && (dataGridPagamentiNulli.SelectedItems.Count > 0))
            {
                aepw = new AddEditPagamentoWindow((Pagamento)dataGridPagamentiNulli.SelectedItems[0]);
                aepw.ShowDialog();

                if (aepw.DialogResult.HasValue && aepw.DialogResult.Value)
                {
                    pagamentiDup.Clear();
                    pagamentiNull.Clear();
                    btnPrint.IsEnabled = false;
                }
            }
        }
    }
}
