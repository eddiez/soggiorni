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

namespace Soggiorni
{
    /// <summary>
    /// Interaction logic for AddEditServizioWindow.xaml
    /// </summary>
    public partial class AddEditServizioWindow : Window
    {
        public ServizioSoggiorno servizio;
        DataAccessGateway dag;

        private List<ServizioSoggiorno> allServizi;

        public AddEditServizioWindow()
        {
            InitializeComponent();

            //carica tipo servizi da db
            dag = new DataAccessGateway();
            allServizi = dag.getAllServizi();
            
            cbxTipo.DataContext = allServizi;
            
            servizio = new ServizioSoggiorno();
        }

        public AddEditServizioWindow(ServizioSoggiorno s)
            : this()
        {
            this.Title = "Modifica Servizo del soggiorno";

            servizio = s;
            txtboxDescr.Text = servizio.Note;
            txtboxTotale.Text = servizio.Totale.ToString("C");

            var servizioToSelect = (from srv in allServizi where srv.Nome==servizio.Nome select srv).FirstOrDefault();
            cbxTipo.SelectedItem = servizioToSelect;
        }

        private void btnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            //validazione
            if (cbxTipo.SelectedItem == null)
            {
                MessageBox.Show("E' necessario specificare il tipo di servizio da aggiungere", "Tipo servizio mancante", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            try
            {
                servizio.Totale = decimal.Parse(txtboxTotale.Text, System.Globalization.NumberStyles.Any);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Il totale deve essere un numero", "Formato totale errato", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            decimal totaleServizio = servizio.Totale;
            servizio = ((ServizioSoggiorno)cbxTipo.SelectedItem);
            servizio.Totale = totaleServizio;
            servizio.Note = txtboxDescr.Text;

            this.DialogResult = true;
        }
    }
}
