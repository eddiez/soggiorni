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
    /// Interaction logic for SelectMesePresenzeWindow.xaml
    /// </summary>
    public partial class SelectMesePresenzeWindow : Window
    {
        private Dictionary<string, int> mesi;

        private ObservableCollection<Soggiorno> soggiorniNonCheckedIn;
        private DataAccessGateway dag;
        private ModificaSoggiornoWindow msw;

        private PresenzeFileGenerator pfg;

        public SelectMesePresenzeWindow()
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
            cbxMese.SelectedIndex = DateTime.Today.Month-1;

            dag = new DataAccessGateway();
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
            //controlla se ci sono soggiorni senza schedine associate nel periodo selezionato
            var slist = dag.cercaSoggiorniNonCheckedInForIstat(arrivoDa, arrivoA);
            if (slist.Count > 0)
            {
                var result = MessageBox.Show("Ci sono soggiorni senza schede di notifica nel mese selezionato." + Environment.NewLine + "Li vuoi modificare prima di generare il file?",
                    "Schede di notifica mancanti", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    soggiorniNonCheckedIn = new ObservableCollection<Soggiorno>(slist);
                    dataGridSoggiorni.DataContext = soggiorniNonCheckedIn;
                    return;
                }
            }

            //raccolgo i dati sulle provenienze dei clienti con scheda di notifica associata ad un soggiorno 
            //dentro il range selezionato 
            //(solo soggiorni con IsCheckedIn = true...non servirebbe ma per sicurezza lo faccio lo stesso)
            List<SchedaNotifica> schedeNotif = dag.cercaSchedeNotificaPerIstat(arrivoDa, arrivoA);

            if (schedeNotif.Count == 0)
            {
                MessageBox.Show("Non ci sono schede di notifica registrate nel periodo selezionato", "Nessuna scheda di notifica presente", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            //generazione file per ricestat ISTAT
            pfg = new PresenzeFileGenerator(mese, anno, schedeNotif);
            
            var savefiledlg = new SaveFileDialog();
            savefiledlg.DefaultExt = "xml";
            savefiledlg.FileName = "presenze_" + cbxMese.Text + "_" + anno.ToString();
            savefiledlg.Filter = "File XML (.xml)|*.xml";

            Nullable<bool> dlgresult = savefiledlg.ShowDialog();
            if (dlgresult == true)
            {
                //faccio i calcoli solo se spingo salva nella finestra di dialogo
                System.IO.File.WriteAllText(savefiledlg.FileName, pfg.getXmlFileText());
                this.DialogResult = true;
            }
        }

        private void dataGridSoggiorni_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //se ci sono risultati ed almeno uno è selezionato, mostro i dettagli del servizio
            if ((dataGridSoggiorni.Items.Count > 0) && (dataGridSoggiorni.SelectedItems.Count > 0))
            {
                msw = new ModificaSoggiornoWindow(((Soggiorno)dataGridSoggiorni.SelectedItems[0]).Id);
                msw.ShowDialog();

                if (msw.DialogResult.HasValue && msw.DialogResult.Value)
                {
                    soggiorniNonCheckedIn.Clear();
                }
            }
        }
    }
}
