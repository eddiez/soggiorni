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
using System.Collections.ObjectModel;
using Soggiorni.Model;
using Soggiorni.Data;

namespace Soggiorni
{
    /// <summary>
    /// Interaction logic for AssociaSoggiornoAPagamentoWindow.xaml
    /// </summary>
    public partial class AssociaSoggiornoAPagamentoWindow : Window
    {
        public Soggiorno soggiornoSelezionato;
        private DataAccessGateway dag;
        private ObservableCollection<Soggiorno> soggiorni;

        public AssociaSoggiornoAPagamentoWindow()
        {
            InitializeComponent();
            
            dag = new DataAccessGateway();
            //di default prendo i soggiorni dell'ultima settimana
            datePickerPartenza.SelectedDate = DateTime.Today;
            datePickerArrivo.SelectedDate = datePickerPartenza.SelectedDate.Value.AddDays(-7);
        }

        private void btnCerca_Click(object sender, RoutedEventArgs e)
        {
            var list = dag.cercaSoggiorniNonCheckedOut((DateTime)datePickerArrivo.SelectedDate, (DateTime)datePickerPartenza.SelectedDate);
            soggiorni = new ObservableCollection<Soggiorno>(list);
            dataGridSoggiorni.DataContext = soggiorni;
        }

        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {
            //caso 0 risultati
            if (dataGridSoggiorni.Items.Count == 0)
            {
                MessageBox.Show("E' necessario avere almeno un risultato per selezionare un soggiorno", "Nessun risultato di ricerca", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //caso nessuna riga selezionata
            if (dataGridSoggiorni.SelectedItems.Count == 0)
            {
                MessageBox.Show("E' necessario selezionare un soggiorno dalla griglia", "Nessuna selezione", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            soggiornoSelezionato = (Soggiorno)dataGridSoggiorni.SelectedItems[0];
            this.DialogResult = true;
        }
    }
}
