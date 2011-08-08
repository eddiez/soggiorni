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
using System.IO;
using System.Diagnostics;

namespace Soggiorni
{
    /// <summary>
    /// Interaction logic for CheckinSoggiornoWindow.xaml
    /// </summary>
    public partial class CheckinSoggiornoWindow : Window
    {
        public ObservableCollection<SchedaNotifica> schede;
        private ListCollectionView view;

        private SelezionaUnClienteWindow sucw;
        private EditSchedinaClienteWindow eschw;
        private ReportSchedinaWindow rsw;
        private AddClienteWindow acw;

        private int idSoggiorno;
        private DateTime dataArrivo;
        private DataAccessGateway dag;
        private int idStatoItalia;
        private string nomeStatoItalia = "ITALIA";
        private int maxScheda;

        public CheckinSoggiornoWindow(int idsog, int idcliente, DateTime arr)
        {
            InitializeComponent();
            idSoggiorno = idsog;
            dataArrivo = arr;
            dag = new DataAccessGateway();

            //prelevo il max numero scheda di quest'anno nel db
            int anno = DateTime.Today.Year;
            maxScheda = dag.getMaxNumSchedina(anno);

            loadSchede(idcliente);
            idStatoItalia = dag.getStatoByNome(nomeStatoItalia);
        }

        private void loadSchede(int idcliente)
        {
            var list = dag.cercaSchedeNotificaBySoggiorno(idSoggiorno);
            //se ci sono risultati carico quelli
            if (list.Count > 0)
            {
                schede = new ObservableCollection<SchedaNotifica>(list);
            }
            else
            {//creo di default la scheda per il cliente del soggiorno (dati potrebbero essere incompleti)
                schede = new ObservableCollection<SchedaNotifica>();
                var c = dag.cercaCliente(idcliente);
                var sc = new SchedaNotifica { Anno = DateTime.Today.Year, Numero = maxScheda + 1 };
                sc.Cliente = c;
                sc.SoggiornoId = idSoggiorno;
                schede.Add(sc);

                maxScheda++;
            }
            view = new ListCollectionView(schede);
            dataGridSchede.DataContext = view;
        }

        

        private void btnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnDeleteScheda_Click(object sender, RoutedEventArgs e)
        {
            //caso 0 risultati
            if (dataGridSchede.Items.Count == 0 || dataGridSchede.SelectedItems.Count == 0)
            {
                return;
            }

            schede.Remove((SchedaNotifica)dataGridSchede.SelectedItems[0]);
        }

        private void btnAddScheda_Click(object sender, RoutedEventArgs e)
        {
            sucw = new SelezionaUnClienteWindow();
            sucw.ShowDialog();

            if (sucw.DialogResult.HasValue && sucw.DialogResult.Value)
            {
                //riempi i campi con i dati del cliente
                var sc = new SchedaNotifica
                {
                    SoggiornoId = idSoggiorno,
                    Cliente = sucw.clienteSelezionato,
                    Numero = maxScheda+1,
                    Anno = DateTime.Today.Year
                };
                schede.Add(sc);

                maxScheda++;
            }
        }

        private void dataGridSchede_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //se ci sono risultati ed almeno uno è selezionato, mostro i dettagli del servizio
            if ((dataGridSchede.Items.Count > 0) && (dataGridSchede.SelectedItems.Count > 0))
            {
                eschw = new EditSchedinaClienteWindow(((SchedaNotifica)dataGridSchede.SelectedItems[0]).Cliente.Id);
                eschw.ShowDialog();

                if (eschw.DialogResult.HasValue && eschw.DialogResult.Value)
                {
                    schede[dataGridSchede.SelectedIndex].Cliente = eschw.clienteModificato;
                    view.Refresh();
                }
            }
        }

        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            //verifica completezza dati clienti per compilazione schedine
            if (!areDatiSchedeCompleti())
                return;

            this.DialogResult = true;

        }

        private bool areDatiSchedeCompleti()
        {
            //se non ci sono schede allora sono completi
            if (schede.Count == 0)
                return true;

            //verifica clienti duplicati
            var schedesenzadup = schede.Distinct<SchedaNotifica>(new SchedaNotificaComparer()).ToList<SchedaNotifica>();
            if (schede.Count != schedesenzadup.Count)
            {
                MessageBox.Show("Hai creato più di una schedina per lo stesso cliente", "Schede di notifica duplicate", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            //analisi cliente per cliente
            foreach (var sch in schede)
            {
                if (!isSchedinaClienteCompleta(sch.Cliente))
                {
                    MessageBox.Show("I dati del cliente " + sch.Cliente.Cognome + " " +  sch.Cliente.Nome + " sono incompleti." ,
                    "Schede di notifica incomplete", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }

            return true;
        }

        private bool isSchedinaClienteCompleta(Cliente cliente)
        {
            if (cliente.Nome == "") return false;
            if (cliente.Cognome == "") return false;
            if (cliente.DataNascita == DateTime.MinValue) return false;
            if (cliente.StatoNascita == null) return false;
            else
            {
                if ((cliente.StatoNascita.Id == idStatoItalia) &&
                    (cliente.ComuneNascita == null))
                    return false;
            }
            if (cliente.StatoCittadinanza == null) return false;
            if (cliente.StatoResidenza == null) return false;
            else
            {
                if ((cliente.StatoResidenza.Id == idStatoItalia) &&
                    (cliente.ComuneResidenza == null))
                    return false;
            }
            if (cliente.Indirizzo == "") return false;
            if (cliente.TipoDoc == null) return false;
            if (cliente.NumDoc == "") return false;
            if (cliente.StatoRilascioDoc == null) return false;
            else
            {
                if ((cliente.StatoRilascioDoc.Id == idStatoItalia) &&
                    (cliente.ComuneRilascioDoc == null))
                    return false;
            }
            //la provenienza non sarebbe obbligatoria ma la rendo tale per facilitare la compilazione 
            //del file presenze ISTAT
            if (cliente.ProvenIstat == null) return false;

            return true;
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            if (rsw != null && rsw.IsVisible) return;
            
            if (!areDatiSchedeCompleti())
                return;
           
            rsw = new ReportSchedinaWindow(createSchedineReportItems());
            rsw.Show();
        }

        private List<SchedinaReportItem> createSchedineReportItems()
        {
            var slist = new List<SchedinaReportItem>();
            SchedinaReportItem sri;
            foreach (SchedaNotifica sc in schede)
            {
                sri = new SchedinaReportItem
                {
                    CognomeNome = sc.Cliente.Cognome.ToUpper() + " " + sc.Cliente.Nome.ToUpper(),
                    DataArrivo = dataArrivo.ToShortDateString(),
                    DataNascita = sc.Cliente.DataNascita.ToShortDateString(),
                    DataRilascioDoc = sc.Cliente.DataRilascioDoc.ToShortDateString(),
                    LuogoNascita = sc.Cliente.StatoNascita.Nome == nomeStatoItalia ?
                        sc.Cliente.ComuneNascita.Nome + " (" + sc.Cliente.ComuneNascita.Provincia + ")" :
                        sc.Cliente.StatoNascita.Nome,
                    LuogoResidenza = sc.Cliente.StatoResidenza.Nome == nomeStatoItalia ?
                        sc.Cliente.Indirizzo.ToUpper() + ", " + sc.Cliente.ComuneResidenza.Nome + " (" + sc.Cliente.ComuneResidenza.Provincia + ")" :
                        sc.Cliente.StatoResidenza.Nome,
                    LuogoRilascioDoc = sc.Cliente.StatoRilascioDoc.Nome == nomeStatoItalia ?
                        sc.Cliente.ComuneRilascioDoc.Nome + " (" + sc.Cliente.ComuneRilascioDoc.Provincia + ")" :
                        sc.Cliente.StatoRilascioDoc.Nome,
                    NumDoc = sc.Cliente.NumDoc.ToUpper(),
                    StatoCittadinanza = sc.Cliente.StatoCittadinanza.Nome,
                    TipoDoc = sc.Cliente.TipoDoc.Descrizione,
                    Anno = sc.Anno,
                    Progressivo = sc.Numero
                };
                slist.Add(sri);
            }
            return slist;
        }

        private void btnNewCliente_Click(object sender, RoutedEventArgs e)
        {
            acw = new AddClienteWindow();
            acw.ShowDialog();

            if (acw.DialogResult.HasValue && acw.DialogResult.Value)
            {
                //salva nuovo cliente nel db
                dag.inserisciCliente(acw.nuovoCliente);
            }
        }

        private void btnPrestampato_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "prestampato schedine.pdf"))
            {
                MessageBox.Show("Impossibile trovare il file \"prestampato schedine.pdf\" nella cartella del programma.", "File non esiste", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            else Process.Start(AppDomain.CurrentDomain.BaseDirectory + "prestampato schedine.pdf");
        }
    }
}
