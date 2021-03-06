﻿using System;
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
    /// Interaction logic for EditSchedinaClienteWindow.xaml
    /// </summary>
    public partial class EditSchedinaClienteWindow : Window
    {
        public Cliente clienteModificato;

        private DataAccessGateway dag;
        private List<TipoDocumento> tipidoc;
        private int idStatoItalia;
        private string nomeStatoItalia = "ITALIA";

        private SelezionaComuneWindow scw;
        private SelezionaStatoWindow ssw;
        private SelezionaProvIstatWindow spiw;

        public EditSchedinaClienteWindow(int idcliente)
        {
            InitializeComponent();

            dag = new DataAccessGateway();

            tipidoc = dag.getAllTipiDoc();
            cbxTipoDoc.DataContext = tipidoc;

            loadClientData(idcliente);
            idStatoItalia = dag.getStatoByNome(nomeStatoItalia);
        }

        private void loadClientData(int id)
        {
            clienteModificato = dag.cercaCliente(id);

            txtboxCognome.Text = clienteModificato.Cognome;
            txtboxNome.Text = clienteModificato.Nome;
            if (clienteModificato.IsFemmina)
                radioButtonF.IsChecked = true;
            else
                radioButtonM.IsChecked = true;

            txtboxAddr.Text = clienteModificato.Indirizzo;
            if (clienteModificato.DataNascita != DateTime.MinValue)
                datePickerNascita.SelectedDate = clienteModificato.DataNascita;
            if (clienteModificato.ComuneNascita != null)
            {
                txtboxComuneNascita.Text = clienteModificato.ComuneNascita.Nome +
                    " (" + clienteModificato.ComuneNascita.Provincia + ")";
            }
            if (clienteModificato.StatoNascita != null)
                txtboxStatoNascita.Text = clienteModificato.StatoNascita.Nome;
            if (clienteModificato.StatoCittadinanza != null)
                txtboxCittadinanza.Text = clienteModificato.StatoCittadinanza.Nome;
            if (clienteModificato.ComuneResidenza != null)
            {
                txtboxComuneResid.Text = clienteModificato.ComuneResidenza.Nome +
                    " (" + clienteModificato.ComuneResidenza.Provincia + ")";
            }
            if (clienteModificato.StatoResidenza != null)
                txtboxStatoResid.Text = clienteModificato.StatoResidenza.Nome;
            txtboxNumDoc.Text = clienteModificato.NumDoc;
            if (clienteModificato.DataRilascioDoc != DateTime.MinValue)
                datePickerRilascioDoc.SelectedDate = clienteModificato.DataRilascioDoc;
            if (clienteModificato.ComuneRilascioDoc != null)
            {
                txtboxComuneRilascioDoc.Text = clienteModificato.ComuneRilascioDoc.Nome +
                    " (" + clienteModificato.ComuneRilascioDoc.Provincia + ")";
            }
            if (clienteModificato.StatoRilascioDoc != null)
                txtboxStatoRilascioDoc.Text = clienteModificato.StatoRilascioDoc.Nome;

            if (clienteModificato.TipoDoc != null)
            {
                var tipodocToSelect = (from t in tipidoc where t.Id == clienteModificato.TipoDoc.Id select t).FirstOrDefault();
                cbxTipoDoc.SelectedItem = tipodocToSelect;
            }
            if (clienteModificato.ProvenIstat != null)
                txtboxProvIstat.Text = clienteModificato.ProvenIstat.Regione == "" ?
                    clienteModificato.ProvenIstat.Stato :
                    clienteModificato.ProvenIstat.Regione;
        }

        private void btnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            if (txtboxCognome.Text.Trim() == "")
            {
                MessageBox.Show("Il campo Cognome è obbligatorio", "Cognome obbligatorio", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            salvaDatiCliente();
            dag.aggiornaCliente(clienteModificato);
            this.DialogResult = true;
        }

        private void salvaDatiCliente()
        {
            //solo quelli non già salvati dalle finestre di selezione: comune, stato, provenienza
            clienteModificato.Cognome = txtboxCognome.Text;
            clienteModificato.Nome = txtboxNome.Text;
            if (radioButtonM.IsChecked != null && (bool)radioButtonM.IsChecked)
                clienteModificato.IsFemmina = false;
            else
                clienteModificato.IsFemmina = true;
            clienteModificato.Indirizzo = txtboxAddr.Text;
            clienteModificato.DataNascita = datePickerNascita.SelectedDate == null ? DateTime.MinValue : (DateTime)datePickerNascita.SelectedDate;
            clienteModificato.TipoDoc = (TipoDocumento)cbxTipoDoc.SelectedItem;
            clienteModificato.NumDoc = txtboxNumDoc.Text;
            clienteModificato.DataRilascioDoc = datePickerRilascioDoc.SelectedDate == null ? DateTime.MinValue : (DateTime)datePickerRilascioDoc.SelectedDate;
        }

        private void btnSelectComuneNascita_Click(object sender, RoutedEventArgs e)
        {
            scw = new SelezionaComuneWindow();
            scw.ShowDialog();

            if (scw.DialogResult.HasValue && scw.DialogResult.Value)
            {
                //modifica dati comune
                clienteModificato.ComuneNascita = scw.comuneSelezionato;
                txtboxComuneNascita.Text = clienteModificato.ComuneNascita.Nome +
                    " (" + clienteModificato.ComuneNascita.Provincia + ")";

                //imposto anche lo stato su italia
                clienteModificato.StatoNascita = new Stato { Id = idStatoItalia, Nome = nomeStatoItalia };
                txtboxStatoNascita.Text = clienteModificato.StatoNascita.Nome;
            }
        }

        private void btnSelectStatoNascita_Click(object sender, RoutedEventArgs e)
        {
            ssw = new SelezionaStatoWindow();
            ssw.ShowDialog();

            if (ssw.DialogResult.HasValue && ssw.DialogResult.Value)
            {
                //modifica dati stato
                clienteModificato.StatoNascita = ssw.statoSelezionato;
                txtboxStatoNascita.Text = clienteModificato.StatoNascita.Nome;

                //resetta dati comune
                clienteModificato.ComuneNascita = null;
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
                clienteModificato.StatoCittadinanza = ssw.statoSelezionato;
                txtboxCittadinanza.Text = clienteModificato.StatoCittadinanza.Nome;
            }
        }

        private void btnSelectComuneResid_Click(object sender, RoutedEventArgs e)
        {
            string defaultComuneName = txtboxComuneNascita.Text == "" ? "" : clienteModificato.ComuneNascita.Nome;
            scw = new SelezionaComuneWindow(defaultComuneName);
            scw.ShowDialog();

            if (scw.DialogResult.HasValue && scw.DialogResult.Value)
            {
                //modifica dati comune
                clienteModificato.ComuneResidenza = scw.comuneSelezionato;
                txtboxComuneResid.Text = clienteModificato.ComuneResidenza.Nome +
                    " (" + clienteModificato.ComuneResidenza.Provincia + ")";

                //imposto anche lo stato su italia
                clienteModificato.StatoResidenza = new Stato { Id = idStatoItalia, Nome = nomeStatoItalia };
                txtboxStatoResid.Text = clienteModificato.StatoResidenza.Nome;
            }
        }

        private void btnSelectStatoResid_Click(object sender, RoutedEventArgs e)
        {
            ssw = new SelezionaStatoWindow();
            ssw.ShowDialog();

            if (ssw.DialogResult.HasValue && ssw.DialogResult.Value)
            {
                //modifica dati stato
                clienteModificato.StatoResidenza = ssw.statoSelezionato;
                txtboxStatoResid.Text = clienteModificato.StatoResidenza.Nome;

                //resetta dati comune
                clienteModificato.ComuneResidenza = null;
                txtboxComuneResid.Text = "";
            }
        }

        private void btnSelectProvIstat_Click(object sender, RoutedEventArgs e)
        {
            string defaultStato = clienteModificato.StatoResidenza != null ?
                clienteModificato.StatoResidenza.Nome : "";
            spiw = new SelezionaProvIstatWindow(defaultStato);
            spiw.ShowDialog();

            if (spiw.DialogResult.HasValue && spiw.DialogResult.Value)
            {
                //modifica dati provenienza istat
                clienteModificato.ProvenIstat = spiw.provSelezionata;
                txtboxProvIstat.Text = clienteModificato.ProvenIstat.Regione == "" ?
                    clienteModificato.ProvenIstat.Stato :
                    clienteModificato.ProvenIstat.Regione;
            }
        }

        private void btnSelectComuneRilascioDoc_Click(object sender, RoutedEventArgs e)
        {
            string defaultComuneName = txtboxComuneResid.Text == "" ? "" : clienteModificato.ComuneResidenza.Nome;
            scw = new SelezionaComuneWindow(defaultComuneName);
            scw.ShowDialog();

            if (scw.DialogResult.HasValue && scw.DialogResult.Value)
            {
                //modifica dati comune
                clienteModificato.ComuneRilascioDoc = scw.comuneSelezionato;
                txtboxComuneRilascioDoc.Text = clienteModificato.ComuneRilascioDoc.Nome +
                    " (" + clienteModificato.ComuneRilascioDoc.Provincia + ")";

                //imposto anche lo stato su italia
                clienteModificato.StatoRilascioDoc = new Stato { Id = idStatoItalia, Nome = nomeStatoItalia };
                txtboxStatoRilascioDoc.Text = clienteModificato.StatoRilascioDoc.Nome;
            }
        }

        private void btnSelectStatoRilascioDoc_Click(object sender, RoutedEventArgs e)
        {
            ssw = new SelezionaStatoWindow();
            ssw.ShowDialog();

            if (ssw.DialogResult.HasValue && ssw.DialogResult.Value)
            {
                //modifica dati stato
                clienteModificato.StatoRilascioDoc = ssw.statoSelezionato;
                txtboxStatoRilascioDoc.Text = clienteModificato.StatoRilascioDoc.Nome;

                //resetta dati comune
                clienteModificato.ComuneRilascioDoc = null;
                txtboxComuneRilascioDoc.Text = "";
            }
        }


    }
}
