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
    /// Interaction logic for CheckoutSoggiornoWindow.xaml
    /// </summary>
    public partial class CheckoutSoggiornoWindow : Window
    {
        private Soggiorno sog;
        private DataAccessGateway dag;

        private SelezionaUnPagamentoWindow supw;
        private CFCalcWindow cfcw;

        public bool isPagato;
        public bool newPagamento;
        public int idPagamento;
        private int maxFattura;
        private int maxRicFiscale;
        private Pagamento pag;

        public CheckoutSoggiornoWindow(Soggiorno s)
        {
            InitializeComponent();

            this.sog = s;
            dag = new DataAccessGateway();
            this.isPagato = s.IsCheckedOut;
            newPagamento = false;

            if (!isPagato)
            {
                //se non è pagato allora abilito solo i due pulsanti di scelta: nuovo pagamento e pag.esistente
                gridDatiPag.IsEnabled = false;
                gridDatiPag.Opacity = 0.50;
                btnDissocia.IsEnabled = false;
                btnSalva.IsEnabled = false;
                
            }
            else
            {
                //se è già pagato, carico i dati del rispettivo pagamento, senza permettere di crearne uno nuovo o selezionarne un altro
                btnNewPagamento.IsEnabled = false;
                btnPagamEsist.IsEnabled = false;

                //vai a pescare i dati del pagamento nel db
                pag = dag.cercaPagamentoById(sog.IdPagamento);
                if (pag.IsFattura)
                {
                    radioButtonFatt.IsChecked = true;
                    txtLastFattura.FontWeight = FontWeights.Bold;
                }
                else
                {
                    radioButtonRicFisc.IsChecked = true;
                    txtLastRicFisc.FontWeight = FontWeights.Bold;
                }

                txtboxNum.Text = pag.Numero.ToString();
                datePickerData.SelectedDate = pag.Data;
                txtboxDest.Text = pag.Destinatario;
                txtboxSede.Text = pag.Sede;
                txtboxPiva.Text = pag.Piva;
                txtboxCf.Text = pag.Cf;
                txtboxNote.Text = pag.ModoPagamento;
            }
        }

        private void btnNewPagamento_Click(object sender, RoutedEventArgs e)
        {
            newPagamento = true;
            pag = new Pagamento();
            gridDatiPag.IsEnabled = true;
            gridDatiPag.Opacity = 1;
            btnSalva.IsEnabled = true;
            datePickerData.SelectedDate = DateTime.Today;
            btnPagamEsist.IsEnabled = false;
            //non abilito il pulsante dissocia perchè se è un nuovo pagamento non c'è nulla da dissociare se non salvo

            //fare query per numero nuova fattura e ricevuta fiscale
            var today = DateTime.Today;
            maxFattura = dag.getMaxNumPagamento(true, today);
            maxRicFiscale = dag.getMaxNumPagamento(false, today);
            if (maxFattura == 0) txtLastFattura.Text = "- Non ci sono fatture nel " + today.Year;
            else txtLastFattura.Text = "- Ultima fattura " + today.Year.ToString() + " = " + maxFattura;
            if (maxRicFiscale== 0) txtLastRicFisc.Text = "- Non ci sono ricevute fiscali nel " + today.Year;
            else txtLastRicFisc.Text = "- Ultima ricevuta fiscale " + today.Year.ToString() + " = " + maxRicFiscale;

            radioButtonFatt.IsChecked = true;
            txtLastFattura.FontWeight = FontWeights.Bold;

            //modificare txtboxNum: default è fattura
            txtboxNum.Text = (maxFattura + 1).ToString();

            //carico i dati del cliente che ho a disposizione
            Cliente c = dag.cercaCliente(sog.Cliente.Id);
            string destinatario = c.Cognome;
            if (c.Nome != null) destinatario = destinatario + " " + c.Nome;
            txtboxDest.Text = destinatario;
            string indirizzo = "";
            if (c.Indirizzo != null)
            {
                indirizzo = c.Indirizzo;
                if (c.ComuneResidenza != null)
                    indirizzo += ", " + c.ComuneResidenza.Nome + "(" + c.ComuneResidenza.Provincia + ")";
            }
            txtboxSede.Text = indirizzo;
        }

        //private void radioButtonRicFisc_Checked(object sender, RoutedEventArgs e)
        //{
        //    txtboxNum.Text = (maxRicFiscale + 1).ToString();
        //}

        //private void radioButtonFatt_Checked(object sender, RoutedEventArgs e)
        //{
        //    //necessario per evitare nullpointerexception all'avvio della finestra
        //    if(txtboxNum!=null)
        //        txtboxNum.Text = (maxFattura + 1).ToString();
        //}

        private void datePickerData_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //caso di caricamento iniziale della finestra
            if (e.RemovedItems.Count == 0) return;

            //se seleziono un altro anno devo ricalcolare i maxFattura e maxRicFiscale
            if (datePickerData.SelectedDate.Value.Year != ((DateTime)e.RemovedItems[0]).Year)
            {
                DateTime newdate = (DateTime)datePickerData.SelectedDate;
                maxFattura = dag.getMaxNumPagamento(true, newdate);
                maxRicFiscale = dag.getMaxNumPagamento(false, newdate);
                if (maxFattura == 0) txtLastFattura.Text = "- Non ci sono fatture nel " + newdate.Year;
                else txtLastFattura.Text = "- Ultima fattura " + newdate.Year.ToString() + " = " + maxFattura;
                if (maxRicFiscale == 0) txtLastRicFisc.Text = "- Non ci sono ricevute fiscali nel " + newdate.Year;
                else txtLastRicFisc.Text = "- Ultimo ricevuta fiscale " + newdate.ToString() + " = " + maxRicFiscale;
            }

        }

        private void btnDissocia_Click(object sender, RoutedEventArgs e)
        {
            isPagato = false;
            //sottraggo il totale del soggiorno dalla fattura e la aggiorno
            pag.Totale -= sog.TotaleSoggiorno;
            dag.aggiornaPagamento(pag);

            //se il pagamento non ha più alcun soggiorno o altra attività associata allora lo elimino 
            //sicuramente un risultato ce l'ho perchè non ho ancora modificato il soggiorno che ho appena dissociato
            if (dag.getPagamentoElements(pag.Id) <= 1)
                dag.eliminaPagamento(pag.Id);

            this.DialogResult = true;
        }

        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            int numero;
            try
            {
                numero = int.Parse(txtboxNum.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Il numero del pagamento dev'essere un numero", "Errore nel campo numero pagamento", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (txtboxPiva.Text.Length != 0 && txtboxPiva.Text.Length != 11)
            {
                MessageBox.Show("La partita IVA deve essere lunga 11 caratteri, inseriti " + txtboxPiva.Text.Length, "Errore nel campo numero pagamento", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (txtboxCf.Text.Length != 0 && txtboxCf.Text.Length > 16)
            {
                MessageBox.Show("Il codice fiscale non può superare i 16 caratteri, inseriti " + txtboxCf.Text.Length, "Errore nel campo numero pagamento", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            pag.IsFattura = (bool)radioButtonFatt.IsChecked;
            pag.Numero = numero;
            pag.Data = (DateTime)datePickerData.SelectedDate;
            pag.Destinatario = txtboxDest.Text;
            pag.Sede = txtboxSede.Text;
            pag.Piva = txtboxPiva.Text;
            pag.Cf = txtboxCf.Text;
            pag.ModoPagamento = txtboxNote.Text;
            
            //se è un nuovo pagamento faccio inserimento, altrimenti aggiorno sommando importo (se non è già pagato)
            if (newPagamento)
            {
                pag.Totale = sog.TotaleSoggiorno;
                idPagamento = dag.inserisciPagamento(pag);
            }
            else
            {
                if (!isPagato)
                {//se non è ancora pagato allora sommo il totale del soggiorno al pagamento esistente
                    //somma totale soggiorno a pagamento 
                    pag.Totale += sog.TotaleSoggiorno;
                }

                //aggiorna dati pagamento
                dag.aggiornaPagamento(pag);
                idPagamento = pag.Id;
            }

            isPagato = true;

            this.DialogResult = true;
        }

        private void btnPagamEsist_Click(object sender, RoutedEventArgs e)
        {
            supw = new SelezionaUnPagamentoWindow();
            supw.ShowDialog();

            if (supw.DialogResult.HasValue && supw.DialogResult.Value)
            {
                //riempio i campi con i dati del pagamento
                pag = supw.pagSelezionato;

                if (pag.IsFattura) radioButtonFatt.IsChecked = true;
                else radioButtonRicFisc.IsChecked = true;
                txtboxNum.Text = pag.Numero.ToString();
                datePickerData.SelectedDate = pag.Data;
                txtboxDest.Text = pag.Destinatario;
                txtboxSede.Text = pag.Sede;
                txtboxPiva.Text = pag.Piva;
                txtboxCf.Text = pag.Cf;
                txtboxNote.Text = pag.ModoPagamento;

                //disabilito nuovo pagamento e riabilito gli altri pulsanti
                btnNewPagamento.IsEnabled = false;
                btnPagamEsist.IsEnabled = false;
                btnDissocia.IsEnabled = true;
                btnSalva.IsEnabled = true;
                gridDatiPag.IsEnabled = true;
                gridDatiPag.Opacity = 1;
            }
        }

        private void radioButtonRicFisc_Checked(object sender, RoutedEventArgs e)
        {
            if (txtLastFattura != null && txtLastRicFisc != null)
            {
                txtLastRicFisc.FontWeight = FontWeights.Bold;
                txtLastFattura.FontWeight = FontWeights.Normal;
            }
        }

        private void radioButtonFatt_Checked(object sender, RoutedEventArgs e)
        {
            if (txtLastFattura != null && txtLastRicFisc != null)
            {
                txtLastRicFisc.FontWeight = FontWeights.Normal;
                txtLastFattura.FontWeight = FontWeights.Bold;
            }
        }

        private void btnCFCalc_Click(object sender, RoutedEventArgs e)
        {
            cfcw = new CFCalcWindow(sog.Cliente.Id);
            cfcw.ShowDialog();

            if (cfcw.DialogResult.HasValue && cfcw.DialogResult.Value)
            {
                txtboxCf.Text = cfcw.cf;
                txtboxDest.Text = cfcw.cl.Cognome + " " + cfcw.cl.Nome;
            }
        }
    }
}
