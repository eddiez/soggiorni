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
    /// Interaction logic for AddEditAltraAttWindow.xaml
    /// </summary>
    public partial class AddEditAltraAttWindow : Window
    {
        public AltraAttivita attivita;

        public AddEditAltraAttWindow()
        {
            InitializeComponent();
            attivita = new AltraAttivita();
            datePickerData.SelectedDate = DateTime.Today;
        }

        public AddEditAltraAttWindow(AltraAttivita aa)
            : this()
        {
            this.attivita = aa;
            datePickerData.SelectedDate = attivita.Data;
            txtboxVoceStampa.Text = attivita.VoceInStampata;
            txtboxDescr.Text = attivita.Descrizione;
            txtboxTotale.Text = attivita.Totale.ToString("C");
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //validazione
            if (txtboxVoceStampa.Text == "")
            {
                MessageBox.Show("Il campo Voce nella stampa non può essere vuoto.", "Campo vuoto non permesso", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(txtboxTotale.Text=="")
            {
                MessageBox.Show("Il campo Totale non può essere vuoto.", "Campo vuoto non permesso", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            decimal totale;
            try
            {
                totale = decimal.Parse(txtboxTotale.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Il campo Totale dev'essere un numero.", "Errore nel formato del campo Totale", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //prelevo i dati dai campi
            attivita.Data = (DateTime)datePickerData.SelectedDate;
            attivita.VoceInStampata = txtboxVoceStampa.Text;
            attivita.Totale = totale;
            attivita.Descrizione = txtboxDescr.Text;

            this.DialogResult = true;

        }
    }
}
