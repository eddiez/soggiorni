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
    /// Interaction logic for SelectPeriodoSchedineWindow.xaml
    /// </summary>
    public partial class SelectPeriodoSchedineWindow : Window
    {
        private ObservableCollection<Soggiorno> soggiorniNonCheckedIn;
        private DataAccessGateway dag;
        private ModificaSoggiornoWindow msw;

        private SchedineFileGenerator sfg;
        private SaveFileDialog savefiledlg;

        public SelectPeriodoSchedineWindow()
        {
            InitializeComponent();
            datePickerArriviDa.SelectedDate = DateTime.Today.AddDays(-1);
            datePickerArriviA.SelectedDate = DateTime.Today;
            dag = new DataAccessGateway();
            reloadDataGrid();
        }

        private void reloadDataGrid()
        {
            var list = dag.cercaSoggiorniNonCheckedIn(
                (DateTime)datePickerArriviDa.SelectedDate,
                (DateTime)datePickerArriviA.SelectedDate
                );
            soggiorniNonCheckedIn = new ObservableCollection<Soggiorno>(list);
            dataGridSoggiorni.DataContext = soggiorniNonCheckedIn;
        }

        private void btnGenera_Click(object sender, RoutedEventArgs e)
        {
            //controlla se ci sono soggiorni senza schedine associate
            var slist = dag.cercaSoggiorniNonCheckedIn(
                (DateTime)datePickerArriviDa.SelectedDate,
                (DateTime)datePickerArriviA.SelectedDate
                );
            if (slist.Count > 0)
            {
                var result = MessageBox.Show("Ci sono soggiorni senza schede di notifica." + Environment.NewLine + "Li vuoi modificare prima di generare il file?",
                    "Schede di notifica mancanti", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    soggiorniNonCheckedIn = new ObservableCollection<Soggiorno>(slist);
                    dataGridSoggiorni.DataContext = soggiorniNonCheckedIn;
                    return;
                }
            }

            //raccolgo tutti i dati dei clienti con scheda di notifica associata ad un soggiorno con data di arrivo entro
            //il range selezionato (solo soggiorni con IsCheckedIn = true...non servirebbe ma per sicurezza lo faccio lo stesso)
            List<SchedaNotifica> schedeNotif = dag.cercaSchedeNotificaBetween(
                (DateTime)datePickerArriviDa.SelectedDate,
                (DateTime)datePickerArriviA.SelectedDate);

            if (schedeNotif.Count == 0)
            {
                MessageBox.Show("Non ci sono schede di notifica registrate nelle date di arrivo indicate", "Nessuna scheda di notifica presente", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            //generazione file nel formato polizia
            sfg = new SchedineFileGenerator(schedeNotif);

            savefiledlg = new SaveFileDialog();
            savefiledlg.DefaultExt = "txt";
            savefiledlg.FileName = "arrivi_" + ((DateTime)datePickerArriviDa.SelectedDate).ToString("ddMMyyyy") + "_" + ((DateTime)datePickerArriviA.SelectedDate).ToString("ddMMyyyy");
            savefiledlg.Filter = "File di testo (.txt)|*.txt";
            try
            {
                Nullable<bool> dlgresult = savefiledlg.ShowDialog();
                if (dlgresult == true)
                {
                    //faccio i calcoli solo se spingo salva nella finestra di dialogo
                    System.IO.File.WriteAllText(savefiledlg.FileName, sfg.getFileText());
                    this.DialogResult = true;
                }
            }
            catch (Exception ex)
            {
                return;
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
