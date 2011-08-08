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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Soggiorni.Model;
using Soggiorni.Data;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace Soggiorni
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataAccessGateway dag;
        private ObservableCollection<Soggiorno> currentSoggiorni;
        private ObservableCollection<Soggiorno> nextMonthSoggiorni;
        private ObservableCollection<Soggiorno> todayArrivi;
        private ObservableCollection<Soggiorno> todayPartenze;

        private VerificaDisponibilitaWindow vdw;
        private CercaClienteWindow ccw;
        private AddSoggiornoWindow asw;
        private CercaSoggiornoWindow csw;
        private ModificaSoggiornoWindow msw;
        private AddClienteWindow acw;
        private SelectPeriodoSchedineWindow spsw;
        private SelectMesePresenzeWindow smpw;
        private SelectPeriodoPresenzeWindow sppw;
        private CercaPagamentoWindow cpw;
        private AddEditPagamentoWindow aepw;
        private SelezionaMeseCorrispettiviWindow smcw;
        private SettingsNotifichePremiWindow snpw;
        private SaveFileDialog savefiledlg;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            dag = new DataAccessGateway();

            reloadDataGrids();
            
        }

        private void reloadDataGrids()
        {
            loadDataGridNextMonth();
            loadDataGridCurrent();
            loadDataGridArriviOggi();
            loadDataGridPartenzeOggi();
        }

        private void loadDataGridPartenzeOggi()
        {
            List<Soggiorno> list = dag.cercaPartenzeOggi();
            todayPartenze = new ObservableCollection<Soggiorno>(list);

            var view = new ListCollectionView(todayPartenze);
            view.SortDescriptions.Add(new System.ComponentModel.SortDescription("Camera.Numero", System.ComponentModel.ListSortDirection.Ascending));
            this.dataGridPartenzeOggi.DataContext = view;
        }

        private void loadDataGridArriviOggi()
        {
            List<Soggiorno> list = dag.cercaArriviOggi();
            todayArrivi = new ObservableCollection<Soggiorno>(list);

            var view = new ListCollectionView(todayArrivi);
            view.SortDescriptions.Add(new System.ComponentModel.SortDescription("Camera.Numero", System.ComponentModel.ListSortDirection.Ascending));
            this.dataGridArriviOggi.DataContext = view;
        }

        private void loadDataGridCurrent()
        {
            List<Soggiorno> list = dag.cercaSoggiorniInCorso();
            currentSoggiorni = new ObservableCollection<Soggiorno>(list);

            var view = new ListCollectionView(currentSoggiorni);
            view.SortDescriptions.Add(new System.ComponentModel.SortDescription("Cliente.Cognome", System.ComponentModel.ListSortDirection.Ascending));
            this.dataGridCurrent.DataContext = view;
        }

        private void loadDataGridNextMonth()
        {
            List<Soggiorno> list = dag.cercaSoggiorniProssimoMese();
            nextMonthSoggiorni = new ObservableCollection<Soggiorno>(list);

            var viewNext = new ListCollectionView(nextMonthSoggiorni);
            viewNext.SortDescriptions.Add(new System.ComponentModel.SortDescription("Arrivo", System.ComponentModel.ListSortDirection.Ascending));
            this.dataGridNext.DataContext = viewNext;
        }

       

        private void btnSearchCliente_Click(object sender, RoutedEventArgs e)
        {
            ccw = new CercaClienteWindow();
            ccw.ShowDialog();

            if (ccw.isClienteModificato)
                reloadDataGrids();
        }

        private void btnAddSoggiorno_Click(object sender, RoutedEventArgs e)
        {
            asw = new AddSoggiornoWindow();
            asw.ShowDialog();

            //inserimento dati soggiorno-cliente nel db 
            if (asw.DialogResult.HasValue && asw.DialogResult.Value)
            {
                dag.inserisciSoggiorno(asw.nuovoSoggiorno, asw.isNuovoCliente);
                reloadDataGrids();
            }
        }

        private void MenuItemEsci_Click(object sender, RoutedEventArgs e)
        {
            //eventuali salvataggi impostazioni e cleanup

            Application.Current.Shutdown();
        }

        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var ab = new AboutBox();
            ab.ShowDialog();
        }

        private void btnSearchSoggiorno_Click(object sender, RoutedEventArgs e)
        {
            csw = new CercaSoggiornoWindow();
            csw.ShowDialog();
            if (csw.hasDoneModification)
                reloadDataGrids();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void dataGridCurrent_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //se ci sono risultati ed almeno uno è selezionato, mostro i dettagli del soggiorno
            if ((dataGridCurrent.Items.Count > 0) && (dataGridCurrent.SelectedItems.Count > 0))
            {
                msw = new ModificaSoggiornoWindow(((Soggiorno)dataGridCurrent.SelectedItems[0]).Id);
                msw.ShowDialog();

                if (msw.DialogResult.HasValue && msw.DialogResult.Value)
                {
                    reloadDataGrids();
                }
            }
        }

        private void dataGridNext_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //se ci sono risultati ed almeno uno è selezionato, mostro i dettagli del soggiorno
            if ((dataGridNext.Items.Count > 0) && (dataGridNext.SelectedItems.Count > 0))
            {
                msw = new ModificaSoggiornoWindow(((Soggiorno)dataGridNext.SelectedItems[0]).Id);
                msw.ShowDialog();

                if (msw.DialogResult.HasValue && msw.DialogResult.Value)
                {
                    reloadDataGrids();
                }
            }

        }

        private void dataGridArriviOggi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //se ci sono risultati ed almeno uno è selezionato, mostro i dettagli del soggiorno
            if ((dataGridArriviOggi.Items.Count > 0) && (dataGridArriviOggi.SelectedItems.Count > 0))
            {
                msw = new ModificaSoggiornoWindow(((Soggiorno)dataGridArriviOggi.SelectedItems[0]).Id);
                msw.ShowDialog();

                if (msw.DialogResult.HasValue && msw.DialogResult.Value)
                {
                    reloadDataGrids();
                }
            }

        }

        private void dataGridPartenzeOggi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //se ci sono risultati ed almeno uno è selezionato, mostro i dettagli del soggiorno
            if ((dataGridPartenzeOggi.Items.Count > 0) && (dataGridPartenzeOggi.SelectedItems.Count > 0))
            {
                msw = new ModificaSoggiornoWindow(((Soggiorno)dataGridPartenzeOggi.SelectedItems[0]).Id);
                msw.ShowDialog();

                if (msw.DialogResult.HasValue && msw.DialogResult.Value)
                {
                    reloadDataGrids();
                }
            }
        }

        private void MenuItemAddCliente_Click(object sender, RoutedEventArgs e)
        {
            acw = new AddClienteWindow();
            acw.ShowDialog();

            if (acw.DialogResult.HasValue && acw.DialogResult.Value)
            {
                //salva nuovo cliente nel db
                dag.inserisciCliente(acw.nuovoCliente);
            }
        }

        private void MenuItemPrestampato_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "prestampato schedine.pdf"))
            {
                MessageBox.Show("Impossibile trovare il file \"prestampato schedine.pdf\" nella cartella del programma.", "File non esiste", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            else Process.Start(AppDomain.CurrentDomain.BaseDirectory + "prestampato schedine.pdf");
        }

        private void MenuItemFileQuestura_Click(object sender, RoutedEventArgs e)
        {
            spsw = new SelectPeriodoSchedineWindow();
            spsw.ShowDialog();
            //in teoria dovrei controllare se sono stati modificati soggiorno o no...
            reloadDataGrids();
        }

        private void MenuItemFileIstat_Click(object sender, RoutedEventArgs e)
        {
            smpw = new SelectMesePresenzeWindow();
            smpw.ShowDialog();
            //in teoria dovrei controllare se sono stati modificati soggiorno o no...
            reloadDataGrids();
        }

        private void MenuItemFileIstatManual_Click(object sender, RoutedEventArgs e)
        {
            sppw = new SelectPeriodoPresenzeWindow();
            sppw.ShowDialog();
            //in teoria dovrei controllare se sono stati modificati soggiorno o no...
            reloadDataGrids();
        }

        private void btnNewPagamento_Click(object sender, RoutedEventArgs e)
        {
            aepw = new AddEditPagamentoWindow();
            aepw.ShowDialog();

            if (aepw.DialogResult.HasValue && aepw.DialogResult.Value)
            {
                //con questo pagamento posso aver fatto il checkout di alcuni soggiorni
                loadDataGridPartenzeOggi();
            }
        }

        private void btnSearchPagamento_Click(object sender, RoutedEventArgs e)
        {
            cpw = new CercaPagamentoWindow();
            cpw.ShowDialog();
            //se modifico un pagamento al massimo posso cambiare lo stato di checkout di una camera
            //solo nella tabella partenze mostro la colonna check-out
            loadDataGridPartenzeOggi();
        }

        private void MenuItemCorrispettivi_Click(object sender, RoutedEventArgs e)
        {
            smcw = new SelezionaMeseCorrispettiviWindow();
            smcw.ShowDialog();
            loadDataGridPartenzeOggi();
        }

        private void MenuItemDispCam_Click(object sender, RoutedEventArgs e)
        {
            vdw = new VerificaDisponibilitaWindow();
            vdw.ShowDialog();

            if (vdw.DialogResult.HasValue && vdw.DialogResult.Value)
            {
                //crea un nuovo soggiorno a partire dalla stanza e periodo selezionati
                asw = new AddSoggiornoWindow(vdw.ipotesiSelezionata);
                asw.ShowDialog();

                //inserimento dati soggiorno-cliente nel db 
                if (asw.DialogResult.HasValue && asw.DialogResult.Value)
                {
                    dag.inserisciSoggiorno(asw.nuovoSoggiorno, asw.isNuovoCliente);
                    reloadDataGrids();
                }
            }
        }

        private void btnTableau_Click(object sender, RoutedEventArgs e)
        {
            TableauWinformsWindow tw = new TableauWinformsWindow();
            tw.ShowDialog();

            reloadDataGrids();
        }

        private void MenuItemNotPremi_Click(object sender, RoutedEventArgs e)
        {
            snpw = new SettingsNotifichePremiWindow();
            snpw.ShowDialog();
        }

        private void MenuItemCsvAuguri_Click(object sender, RoutedEventArgs e)
        {
            
            savefiledlg = new SaveFileDialog();
            savefiledlg.DefaultExt = "csv";
            
            savefiledlg.FileName = "clienti_pianetti_" + DateTime.Today.ToString("dd-MM-yyyy");
            savefiledlg.Filter = "CSV (.csv)|*.csv";
            savefiledlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            Nullable<bool> dlgresult = savefiledlg.ShowDialog();
            if (dlgresult == true)
            {
                //raccolgo i dati di tutti i clienti
                var clist = dag.cercaClientiPerMailAuguri();
                var augfg = new AuguriClientiCsvFileGenerator(clist);
                //faccio i calcoli solo se spingo salva nella finestra di dialogo
                File.WriteAllText(savefiledlg.FileName,
                    augfg.getCsvText()
                );
            }
            
        }
    }
}
