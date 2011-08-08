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
    /// Interaction logic for SelectPeriodoPresenzeWindow.xaml
    /// </summary>
    public partial class SelectPeriodoPresenzeWindow : Window
    {
        private ObservableCollection<Soggiorno> soggiorniNonCheckedIn;
        private DataAccessGateway dag;
        private ModificaSoggiornoWindow msw;

        private PresenzeFileGenerator pfg;

        public SelectPeriodoPresenzeWindow()
        {
            InitializeComponent();
            //selezione di default è la settimana scorsa
            datePickerFrom.SelectedDate = DateTime.Today.AddDays(-8);
            datePickerTo.SelectedDate = datePickerFrom.SelectedDate.Value.AddDays(7);
            dag = new DataAccessGateway();
        }

        private void btnGenera_Click(object sender, RoutedEventArgs e)
        {
            
            if (datePickerFrom.SelectedDate > datePickerTo.SelectedDate)
            {
                MessageBox.Show("La data iniziale deve precedere quella finale", "Errore nella selezione del periodo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //controlla se ci sono soggiorni senza schedine associate nel periodo selezionato
            var slist = dag.cercaSoggiorniNonCheckedInForIstat((DateTime)datePickerFrom.SelectedDate, (DateTime)datePickerTo.SelectedDate);
            if (slist.Count > 0)
            {
                var result = MessageBox.Show("Ci sono soggiorni senza schede di notifica nel periodo selezionato." + Environment.NewLine + "Li vuoi modificare prima di generare il file?",
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
            List<SchedaNotifica> schedeNotif = dag.cercaSchedeNotificaPerIstat((DateTime)datePickerFrom.SelectedDate, (DateTime)datePickerTo.SelectedDate);

            if (schedeNotif.Count == 0)
            {
                MessageBox.Show("Non ci sono schede di notifica registrate nel periodo selezionato", "Nessuna scheda di notifica presente", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            //generazione file per ricestat ISTAT
            pfg = new PresenzeFileGenerator(schedeNotif);

            var savefiledlg = new SaveFileDialog();
            savefiledlg.DefaultExt = "txt";
            savefiledlg.FileName = "presenze_" +
                ((DateTime)datePickerFrom.SelectedDate).ToString("dd-MM-yyyy") + "_" +
                ((DateTime)datePickerTo.SelectedDate).ToString("dd-MM-yyyy");
            savefiledlg.Filter = "File di testo (.txt)|*.txt";

            Nullable<bool> dlgresult = savefiledlg.ShowDialog();
            if (dlgresult == true)
            {
                //faccio i calcoli solo se spingo salva nella finestra di dialogo
                System.IO.File.WriteAllText(savefiledlg.FileName, 
                    pfg.getTxtFileText((DateTime)datePickerFrom.SelectedDate,
                                        (DateTime)datePickerTo.SelectedDate)
                );
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
