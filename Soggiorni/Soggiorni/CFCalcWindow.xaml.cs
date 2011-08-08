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
using Soggiorni.Data;
using Soggiorni.Model;
using CFcalculator;

namespace Soggiorni
{
    /// <summary>
    /// Interaction logic for CFCalcWindow.xaml
    /// </summary>
    public partial class CFCalcWindow : Window
    {
        private SelezionaComuneWindow scw;
        private SelezionaUnClienteWindow sucw;

        public string cf;
        private DataAccessGateway dag;
        public Cliente cl;
        private CFcalculator.CFcalculator cfcalc;

        public CFCalcWindow(int idcliente)
        {
            InitializeComponent();

            dag = new DataAccessGateway();
            cfcalc = new CFcalculator.CFcalculator();
            btnInserisci.IsEnabled = false;
            loadClientData(idcliente);
        }

        public CFCalcWindow()
        {
            InitializeComponent();

            dag = new DataAccessGateway();
            cfcalc = new CFcalculator.CFcalculator();
            btnInserisci.IsEnabled = false;
            cl = new Cliente();
        }

        private void loadClientData(int idcliente)
        {
            cl = dag.cercaCliente(idcliente);

            txtboxCognome.Text = cl.Cognome;
            txtboxNome.Text = cl.Nome;
            if (cl.IsFemmina)
                radioButtonF.IsChecked = true;
            else
                radioButtonM.IsChecked = true;

            if (cl.DataNascita != null && cl.DataNascita!= DateTime.MinValue)
                datePickerNascita.SelectedDate = cl.DataNascita;
            else
                datePickerNascita.SelectedDate = null;
            if (cl.ComuneNascita != null)
            {
                txtboxComuneNascita.Text = cl.ComuneNascita.Nome +" (" + cl.ComuneNascita.Provincia + ")";
            }
        }

        private void btnCalcolaCF_Click(object sender, RoutedEventArgs e)
        {
            if (txtboxCognome.Text == "" || txtboxNome.Text == "" || datePickerNascita==null || txtboxComuneNascita.Text=="")
            {
                MessageBox.Show("I campi sono tutti obbligatori", "Campo mancante", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            if(cfcalc.estraiComune(cl.ComuneNascita.Nome, cl.ComuneNascita.Provincia)==""){
                MessageBox.Show("Impossibile trovare comune corrispondente nel database dei codici fiscali\nInserire il codice fiscale manualmente", "Comune mancante", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            cfcalc.Cognome = txtboxCognome.Text;
            cfcalc.Nome = txtboxNome.Text;
            cfcalc.isMaschio = (bool)radioButtonM.IsChecked;
            DateTime date = (DateTime)datePickerNascita.SelectedDate;
            cfcalc.Anno = date.Year;
            cfcalc.Mese = date.Month;
            cfcalc.Giorno = date.Day;
            cfcalc.Comune = cl.ComuneNascita.Nome;
            cfcalc.Provincia = cl.ComuneNascita.Provincia;

            txtboxCF.Text = cfcalc.GetCodiceFiscale();
            if (txtboxCF.Text == "")
            {
                MessageBox.Show("Non è stato possibile calcolare il codice fiscale, controllare i dati", "Dati di input errati", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            btnInserisci.IsEnabled = true;
        }

        private void btnInserisci_Click(object sender, RoutedEventArgs e)
        {
            cf = txtboxCF.Text;
            cl.Cognome = txtboxCognome.Text;
            cl.Nome = txtboxNome.Text;
            this.DialogResult = true;
        }

        private void btnSelectComuneNascita_Click(object sender, RoutedEventArgs e)
        {
            scw = new SelezionaComuneWindow();
            scw.ShowDialog();
            if (scw.DialogResult.HasValue && scw.DialogResult.Value)
            {
                cl.ComuneNascita = scw.comuneSelezionato;
                txtboxComuneNascita.Text = cl.ComuneNascita.Nome + " (" + cl.ComuneNascita.Provincia + ")";
            }
        }

        private void btnArchivioClienti_Click(object sender, RoutedEventArgs e)
        {
            sucw = new SelezionaUnClienteWindow();
            sucw.ShowDialog();
            if (sucw.DialogResult.HasValue && sucw.DialogResult.Value)
            {
                cl = sucw.clienteSelezionato;
                txtboxCognome.Text = cl.Cognome;
                txtboxNome.Text = cl.Nome;

                if (cl.IsFemmina)
                    radioButtonF.IsChecked = true;
                else
                    radioButtonM.IsChecked = true;

                if (cl.DataNascita != null && cl.DataNascita != DateTime.MinValue)
                    datePickerNascita.SelectedDate = cl.DataNascita;
                else
                    datePickerNascita.SelectedDate = null;
                if (cl.ComuneNascita != null)
                {
                    txtboxComuneNascita.Text = cl.ComuneNascita.Nome + " (" + cl.ComuneNascita.Provincia + ")";
                }
            }
        }
    }
}
