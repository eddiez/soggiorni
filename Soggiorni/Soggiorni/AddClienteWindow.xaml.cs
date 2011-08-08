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

namespace Soggiorni
{
    /// <summary>
    /// Interaction logic for AddClienteWindow.xaml
    /// </summary>
    public partial class AddClienteWindow : Window
    {
        public Cliente nuovoCliente;
        private DataAccessGateway dag;
        private List<TipoDocumento> tipidoc;
        private int idStatoItalia;
        private string nomeStatoItalia = "ITALIA";

        private SelezionaComuneWindow scw;
        private SelezionaStatoWindow ssw;
        private SelezionaProvIstatWindow spiw;

        public AddClienteWindow()
        {
            InitializeComponent();

            nuovoCliente = new Cliente();

            dag = new DataAccessGateway();

            tipidoc = dag.getAllTipiDoc();
            cbxTipoDoc.DataContext = tipidoc;
            
            idStatoItalia = dag.getStatoByNome(nomeStatoItalia);
        }

        private void btnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        

        private void salvaDatiCliente()
        {
            //solo quelli non già salvati dalle finestre di selezione: comune, stato, provenienza
            nuovoCliente.Cognome = txtboxCognome.Text;
            nuovoCliente.Nome = txtboxNome.Text;
            nuovoCliente.Telefoni = txtboxTel.Text;
            nuovoCliente.Email = txtboxMail.Text;
            nuovoCliente.Descr = txtboxNote.Text;
            if (radioButtonM.IsChecked != null && (bool)radioButtonM.IsChecked)
                nuovoCliente.IsFemmina = false;
            else
                nuovoCliente.IsFemmina = true;
            nuovoCliente.Indirizzo = txtboxAddr.Text;
            nuovoCliente.DataNascita = datePickerNascita.SelectedDate == null ? DateTime.MinValue : (DateTime)datePickerNascita.SelectedDate;
            nuovoCliente.TipoDoc = (TipoDocumento)cbxTipoDoc.SelectedItem;
            nuovoCliente.NumDoc = txtboxNumDoc.Text;
            nuovoCliente.DataRilascioDoc = datePickerRilascioDoc.SelectedDate == null ? DateTime.MinValue : (DateTime)datePickerRilascioDoc.SelectedDate;
        }

        private void btnSelectComuneNascita_Click(object sender, RoutedEventArgs e)
        {
            scw = new SelezionaComuneWindow();
            scw.ShowDialog();

            if (scw.DialogResult.HasValue && scw.DialogResult.Value)
            {
                //modifica dati comune
                nuovoCliente.ComuneNascita = scw.comuneSelezionato;
                txtboxComuneNascita.Text = nuovoCliente.ComuneNascita.Nome +
                    " (" + nuovoCliente.ComuneNascita.Provincia + ")";

                //imposto anche lo stato su italia
                nuovoCliente.StatoNascita = new Stato { Id = idStatoItalia, Nome = nomeStatoItalia };
                txtboxStatoNascita.Text = nuovoCliente.StatoNascita.Nome;
            }
        }

        private void btnSelectStatoNascita_Click(object sender, RoutedEventArgs e)
        {
            ssw = new SelezionaStatoWindow();
            ssw.ShowDialog();

            if (ssw.DialogResult.HasValue && ssw.DialogResult.Value)
            {
                //modifica dati stato
                nuovoCliente.StatoNascita = ssw.statoSelezionato;
                txtboxStatoNascita.Text = nuovoCliente.StatoNascita.Nome;

                //resetta dati comune
                nuovoCliente.ComuneNascita = null;
                txtboxComuneNascita.Text = "";
            }
        }

        private void btnSelectCittadinanza_Click(object sender, RoutedEventArgs e)
        {
            ssw = new SelezionaStatoWindow(nomeStatoItalia);
            ssw.ShowDialog();

            if (ssw.DialogResult.HasValue && ssw.DialogResult.Value)
            {
                //modifica dati stato
                nuovoCliente.StatoCittadinanza = ssw.statoSelezionato;
                txtboxCittadinanza.Text = nuovoCliente.StatoCittadinanza.Nome;
            }
        }

        private void btnSelectComuneResid_Click(object sender, RoutedEventArgs e)
        {
            string defaultComuneName = txtboxComuneNascita.Text == "" ? "" : nuovoCliente.ComuneNascita.Nome;
            scw = new SelezionaComuneWindow(defaultComuneName);
            scw.ShowDialog();

            if (scw.DialogResult.HasValue && scw.DialogResult.Value)
            {
                //modifica dati comune
                nuovoCliente.ComuneResidenza = scw.comuneSelezionato;
                txtboxComuneResid.Text = nuovoCliente.ComuneResidenza.Nome +
                    " (" + nuovoCliente.ComuneResidenza.Provincia + ")";

                //imposto anche lo stato su italia
                nuovoCliente.StatoResidenza = new Stato { Id = idStatoItalia, Nome = nomeStatoItalia };
                txtboxStatoResid.Text = nuovoCliente.StatoResidenza.Nome;
            }
        }

        private void btnSelectStatoResid_Click(object sender, RoutedEventArgs e)
        {
            ssw = new SelezionaStatoWindow();
            ssw.ShowDialog();

            if (ssw.DialogResult.HasValue && ssw.DialogResult.Value)
            {
                //modifica dati stato
                nuovoCliente.StatoResidenza = ssw.statoSelezionato;
                txtboxStatoResid.Text = nuovoCliente.StatoResidenza.Nome;

                //resetta dati comune
                nuovoCliente.ComuneResidenza = null;
                txtboxComuneResid.Text = "";
            }
        }

        private void btnSelectProvIstat_Click(object sender, RoutedEventArgs e)
        {
            string defaultStato = nuovoCliente.StatoResidenza != null ?
                nuovoCliente.StatoResidenza.Nome : "";
            spiw = new SelezionaProvIstatWindow(defaultStato);
            spiw.ShowDialog();

            if (spiw.DialogResult.HasValue && spiw.DialogResult.Value)
            {
                //modifica dati provenienza istat
                nuovoCliente.ProvenIstat = spiw.provSelezionata;
                txtboxProvIstat.Text = nuovoCliente.ProvenIstat.Regione == "" ?
                    nuovoCliente.ProvenIstat.Stato :
                    nuovoCliente.ProvenIstat.Regione;
            }
        }

        private void btnSelectComuneRilascioDoc_Click(object sender, RoutedEventArgs e)
        {
            string defaultComuneName = txtboxComuneResid.Text == "" ? "" : nuovoCliente.ComuneResidenza.Nome;
            scw = new SelezionaComuneWindow(defaultComuneName);
            scw.ShowDialog();

            if (scw.DialogResult.HasValue && scw.DialogResult.Value)
            {
                //modifica dati comune
                nuovoCliente.ComuneRilascioDoc = scw.comuneSelezionato;
                txtboxComuneRilascioDoc.Text = nuovoCliente.ComuneRilascioDoc.Nome +
                    " (" + nuovoCliente.ComuneRilascioDoc.Provincia + ")";

                //imposto anche lo stato su italia
                nuovoCliente.StatoRilascioDoc = new Stato { Id = idStatoItalia, Nome = nomeStatoItalia };
                txtboxStatoRilascioDoc.Text = nuovoCliente.StatoRilascioDoc.Nome;
            }
        }

        private void btnSelectStatoRilascioDoc_Click(object sender, RoutedEventArgs e)
        {
            ssw = new SelezionaStatoWindow();
            ssw.ShowDialog();

            if (ssw.DialogResult.HasValue && ssw.DialogResult.Value)
            {
                //modifica dati stato
                nuovoCliente.StatoRilascioDoc = ssw.statoSelezionato;
                txtboxStatoRilascioDoc.Text = nuovoCliente.StatoRilascioDoc.Nome;

                //resetta dati comune
                nuovoCliente.ComuneRilascioDoc = null;
                txtboxComuneRilascioDoc.Text = "";
            }
        }

        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            if (txtboxCognome.Text.Trim() == "")
            {
                MessageBox.Show("Il campo Cognome è obbligatorio", "Cognome obbligatorio", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            salvaDatiCliente();
            this.DialogResult = true;
        }
    }
}
