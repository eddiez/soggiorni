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


namespace Soggiorni
{
    /// <summary>
    /// Interaction logic for ModificaSoggiornoWindow.xaml
    /// </summary>
    /// 
    public partial class ModificaSoggiornoWindow : Window
    {
        public Soggiorno soggiorno;

        private DataAccessGateway dag;

        private ObservableCollection<ServizioSoggiorno> servizi;

        private SelezionaUnClienteWindow sucw;
        private AddEditServizioWindow aesw;
        private CambiaPeriodoCameraWindow cpcw;
        private CheckinSoggiornoWindow ckinw;
        private CheckoutSoggiornoWindow ckoutw;

        public ModificaSoggiornoWindow(int idSoggiorno)
        {
            InitializeComponent();

            dag = new DataAccessGateway();

            soggiorno = dag.cercaSoggiornoById(idSoggiorno);

            loadDatiSoggiorno();
        }

        private void loadDatiSoggiorno()
        {
            datePickerArrivo.SelectedDate = soggiorno.Arrivo;
            datePickerPartenza.SelectedDate = soggiorno.Partenza;
            txtNumNotti.Text = soggiorno.Partenza.Subtract(soggiorno.Arrivo).Days.ToString();

            txtboxCamera.Text = soggiorno.Camera.Numero.ToString();
            txtboxNoteSoggiorno.Text = soggiorno.NoteDurata;

            var usiDict = new Dictionary<string, int>{
                {"Singola", 0},
                {"Doppia", 1},
                {"Tripla", 2},
                {"Doppia Suite", 3},
                {"Tripla Suite", 4},
                {"Quadrupla Suite", 5}
            };
            if (usiDict.ContainsKey(soggiorno.UsoCamera))
                cbxUsoCamera.SelectedIndex = usiDict[soggiorno.UsoCamera];

            txtboxNoteCamera.Text = soggiorno.NoteCamera;
            checkBoxConferma.IsChecked = soggiorno.Confermato;
            soggiorno.TotaleServizi = soggiorno.getTotaleServizi();
            //cambiando questa textbox modifico anche il totale pernotto
            txtboxPrezzoANotte.Text = soggiorno.PrezzoANotte.ToString("C");
            txtboxCliente.Text = soggiorno.Cliente.Cognome;

            txtboxCaparra.Text = soggiorno.Caparra.ToString("C");
            txtboxNoteCaparra.Text = soggiorno.NoteCaparra;
            txtboxNotePagamento.Text = soggiorno.NoteSaldoSoggiorno;

            var serviziSog = soggiorno.GetAllServizi();
            if(serviziSog==null)
                servizi = new ObservableCollection<ServizioSoggiorno>();
            else
                servizi = new ObservableCollection<ServizioSoggiorno>(serviziSog);

            dataGridServizi.DataContext = servizi;
            txtImpTotServizi.Text = soggiorno.TotaleServizi.ToString("C");
            txtImpTotSoggiorno.Text = soggiorno.TotaleSoggiorno.ToString("C");
            if(soggiorno.IsCheckedIn)
                ellipseCheckin.Fill = (Brush)Application.Current.FindResource("semaforoVerde");
            else
                ellipseCheckin.Fill = (Brush)Application.Current.FindResource("semaforoRosso");

            if (soggiorno.IsCheckedOut)
            {
                ellipseCheckout.Fill = (Brush)Application.Current.FindResource("semaforoVerde");
                //non posso più cambiare nè i prezzi nè la durata del soggiorno
                groupBoxServizi.IsEnabled = false;
                groupBoxServizi.Opacity = 0.75;
                txtboxPrezzoANotte.IsEnabled = false;
                txtboxPrezzoANotte.Opacity = 0.75;
                btnEditPeriodo.IsEnabled = false;
            }
            else
                ellipseCheckout.Fill = (Brush)Application.Current.FindResource("semaforoRosso");
            //txtImpTotDaPagare.Text = (soggiorno.TotaleSoggiorno - soggiorno.Caparra).ToString("C");
        }

        private void txtboxPrezzoANotte_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var newPrice = decimal.Parse(txtboxPrezzoANotte.Text, System.Globalization.NumberStyles.Any);
                ricalcolaTotalePernotto(newPrice);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Il prezzo a notte deve essere un numero.", "Formato errato nel campo Prezzo a notte", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void txtboxCaparra_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var newPrice = decimal.Parse(txtboxCaparra.Text, System.Globalization.NumberStyles.Any);
                soggiorno.Caparra= newPrice;
                txtImpTotDaPagare.Text = (soggiorno.TotaleSoggiorno - soggiorno.Caparra).ToString("C");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("La caparra deve essere un numero.", "Formato errato nel campo Caparra", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnArchivioClienti_Click(object sender, RoutedEventArgs e)
        {
            sucw = new SelezionaUnClienteWindow();
            sucw.ShowDialog();

            if (sucw.DialogResult.HasValue && sucw.DialogResult.Value)
            {
                soggiorno.Cliente = sucw.clienteSelezionato;
                txtboxCliente.Text = soggiorno.Cliente.Cognome;
            }
        }

        private void ricalcolaTotalePernotto(decimal newPrice)
        {
            soggiorno.PrezzoANotte = newPrice;
            soggiorno.TotaleSoggiorno = soggiorno.TotaleServizi + soggiorno.TotalePernotto;
            txtImpTotPernotto.Text = soggiorno.TotalePernotto.ToString("C");
            txtImpTotSoggiorno.Text = soggiorno.TotaleSoggiorno.ToString("C");
            txtImpTotDaPagare.Text = (soggiorno.TotaleSoggiorno - soggiorno.Caparra).ToString("C");
        }

        private void ricalcolaTotaleServizi()
        {
            decimal totale = 0;
            foreach (var s in servizi)
                totale += s.Totale;
            
            soggiorno.TotaleServizi = totale;
            soggiorno.TotaleSoggiorno = soggiorno.TotalePernotto + soggiorno.TotaleServizi;
            txtImpTotServizi.Text = soggiorno.TotaleServizi.ToString("C");
            txtImpTotSoggiorno.Text = soggiorno.TotaleSoggiorno.ToString("C");
            txtImpTotDaPagare.Text = (soggiorno.TotaleSoggiorno - soggiorno.Caparra).ToString("C");
        }

        private void btnDeleteServizio_Click(object sender, RoutedEventArgs e)
        {
            //caso 0 risultati
            if (dataGridServizi.Items.Count == 0 || dataGridServizi.SelectedItems.Count == 0)
            {
                return;
            }

            servizi.Remove((ServizioSoggiorno)dataGridServizi.SelectedItems[0]);
            ricalcolaTotaleServizi();
        }

        private void btnAddServizio_Click(object sender, RoutedEventArgs e)
        {
            aesw = new AddEditServizioWindow();
            aesw.ShowDialog();
            if (aesw.DialogResult.HasValue && aesw.DialogResult.Value)
            {
                servizi.Add(aesw.servizio);
                ricalcolaTotaleServizi();
            }
        }

        private void dataGridServizi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //se ci sono risultati ed almeno uno è selezionato, mostro i dettagli del servizio
            if ((dataGridServizi.Items.Count > 0) && (dataGridServizi.SelectedItems.Count > 0))
            {
                aesw = new AddEditServizioWindow(((ServizioSoggiorno)dataGridServizi.SelectedItems[0]));
                aesw.ShowDialog();

                if (aesw.DialogResult.HasValue && aesw.DialogResult.Value)
                {
                    servizi[dataGridServizi.SelectedIndex] = aesw.servizio;
                    ricalcolaTotaleServizi();
                }
            }
        }

        private void btnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnElimina_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Sei sicuro di voler elimare questo soggiorno?", "Conferma eliminazione", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                if (soggiorno.IsCheckedIn)
                {
                    MessageBox.Show("Non puoi eliminare un soggiorno che ha effettuato il check-in.", "Impossibile eliminare soggiorno", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                if (soggiorno.IsCheckedOut)
                {
                    MessageBox.Show("Non puoi eliminare un soggiorno che ha effettuato il check-out.", "Impossibile eliminare soggiorno", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }

                //elimina soggiorno e servizi soggiorno da db
                dag.eliminaSoggiorno(soggiorno.Id);
                soggiorno = null;
                this.DialogResult = true;
            }
        }

        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            soggiorno.ClearServizi();
            //ricopio i servizi aggiornati dentro il soggiorno
            foreach (var s in servizi)
                soggiorno.AddServizio(s);
            
            if(soggiorno.TotaleServizi!=soggiorno.getTotaleServizi()){
                MessageBox.Show("Impossibile salvare il soggiorno. Eliminare tutti i servizi e riprovare.", "Errore nel conteggio dei servizi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //soggiorno.TotaleSoggiorno = soggiorno.TotaleServizi + soggiorno.TotalePernotto;

            //validazione campi
            try
            {
                soggiorno.PrezzoANotte = decimal.Parse(txtboxPrezzoANotte.Text, System.Globalization.NumberStyles.Any);
                soggiorno.Caparra = decimal.Parse(txtboxCaparra.Text, System.Globalization.NumberStyles.Any);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Prezzo a notte e Caparra devono essere numeri.", "Formato errato nel campo Prezzo a notte o Caparra", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //ricopio i dati aggiornati dentro il soggiorno
            soggiorno.UsoCamera = cbxUsoCamera.Text == null ? "" : cbxUsoCamera.Text;
            soggiorno.NoteDurata = txtboxNoteSoggiorno.Text;
            soggiorno.NoteCamera = txtboxNoteCamera.Text;
            soggiorno.Confermato = (bool)checkBoxConferma.IsChecked;
            soggiorno.NoteCaparra = txtboxNoteCaparra.Text;
            soggiorno.NoteSaldoSoggiorno = txtboxNotePagamento.Text;

            //aggiorna dati soggiorno e servizi soggiorno nel db
            dag.aggiornaSoggiorno(soggiorno);

            //se il chiamante è un altro metodo allora non chiudo la finestra
            if (sender == null)
                return;
            
            this.DialogResult = true;
        }

        private void btnEditPeriodo_Click(object sender, RoutedEventArgs e)
        {
            cpcw = new CambiaPeriodoCameraWindow(soggiorno);
            cpcw.ShowDialog();

            if (cpcw.DialogResult.HasValue && cpcw.DialogResult.Value)
            {
                //modifico dati soggiorno e controlli
                datePickerArrivo.SelectedDate = soggiorno.Arrivo;
                datePickerPartenza.SelectedDate = soggiorno.Partenza;
                txtboxCamera.Text = soggiorno.Camera.Numero.ToString();
                
            }
        }

        private void btnEditCheckin_Click(object sender, RoutedEventArgs e)
        {
            ckinw = new CheckinSoggiornoWindow(soggiorno.Id, soggiorno.Cliente.Id, soggiorno.Arrivo);
            ckinw.ShowDialog();

            if (ckinw.DialogResult.HasValue && ckinw.DialogResult.Value)
            {
                if (ckinw.schede.Count == 0)
                {
                    //elimina schede di notifica esistenti
                    dag.eliminaSchedeBySoggiorno(soggiorno.Id);
                    //semaforo check-in diventa rosso
                    ellipseCheckin.Fill = (Brush)Application.Current.FindResource("semaforoRosso");
                    soggiorno.IsCheckedIn = false;
                }
                else
                {
                    //salva dati schedine nel db: i dati dei clienti sono stati già salvati, devo salvare solo le schedine
                    dag.inserisciSchedineSoggiorno(soggiorno.Id, ckinw.schede.ToList<SchedaNotifica>());

                    //aggiorna semaforo check-in (eventualmente)
                    ellipseCheckin.Fill = (Brush)Application.Current.FindResource("semaforoVerde");
                    soggiorno.IsCheckedIn = true;
                }
                //salvo i dati del soggiorno per mantenere consistenza
                btnSalva_Click(null, null);
            }

        }

        private void btnEditCheckout_Click(object sender, RoutedEventArgs e)
        {
            ckoutw = new CheckoutSoggiornoWindow(soggiorno);
            ckoutw.ShowDialog();

            if (ckoutw.DialogResult.HasValue && ckoutw.DialogResult.Value)
            {
                //eventuali inserimenti nella tabella pagamento li faccio da dentro la dialog
                if (ckoutw.isPagato)
                {
                    ellipseCheckout.Fill = (Brush)Application.Current.FindResource("semaforoVerde");
                    soggiorno.IsCheckedOut = true;
                    soggiorno.IdPagamento = ckoutw.idPagamento;
                    //non posso più cambiare nè i prezzi nè la durata del soggiorno
                    groupBoxServizi.IsEnabled = false;
                    groupBoxServizi.Opacity = 0.75;
                    txtboxPrezzoANotte.IsEnabled = false;
                    txtboxPrezzoANotte.Opacity = 0.75;
                    btnEditPeriodo.IsEnabled = false;
                    
                }
                else
                {
                    ellipseCheckout.Fill = (Brush)Application.Current.FindResource("semaforoRosso");
                    soggiorno.IsCheckedOut = false;
                    soggiorno.IdPagamento = 0; //resetto id pagamento
                    //riabilito i controlli di modifica prezzi e durata soggiorno
                    groupBoxServizi.IsEnabled = true;
                    txtboxPrezzoANotte.IsEnabled = true;
                    groupBoxServizi.Opacity = 1;
                    txtboxPrezzoANotte.Opacity = 1;
                    btnEditPeriodo.IsEnabled = true;
                }
                //salvo i dati del soggiorno per mantenere consistenza
                btnSalva_Click(null, null);
            }
        }

        
    }
}
