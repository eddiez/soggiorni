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
    /// Interaction logic for SelezionaUnPagamentoWindow.xaml
    /// </summary>
    public partial class SelezionaUnPagamentoWindow : Window
    {
        public Pagamento pagSelezionato;
        private DataAccessGateway dag;
        private ObservableCollection<Pagamento> pagamenti;

        public SelezionaUnPagamentoWindow()
        {
            InitializeComponent();

            dag = new DataAccessGateway();

            radioButtonFatt.IsChecked = true;
            //intervallo di ricerca di default: ultima settimana
            datePickerA.SelectedDate = DateTime.Today;
            datePickerDa.SelectedDate = datePickerA.SelectedDate.Value.AddDays(-7);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (datePickerDa.SelectedDate > datePickerA.SelectedDate)
            {
                MessageBox.Show("Data di inizio periodo di ricerca deve precedere quella di fine periodo", "Errore nell'intervallo di date", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var list = dag.cercaPagamentiByData((bool)radioButtonFatt.IsChecked, (DateTime)datePickerDa.SelectedDate, (DateTime)datePickerA.SelectedDate);
            pagamenti = new ObservableCollection<Pagamento>(list);
            dataGridPagamenti.DataContext = pagamenti;
        }

        private void btnSeleziona_Click(object sender, RoutedEventArgs e)
        {
            //caso 0 risultati
            if (dataGridPagamenti.Items.Count == 0)
            {
                MessageBox.Show("E' necessario avere almeno un risultato per selezionare un pagamento", "Nessun risultato di ricerca", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //caso nessuna riga selezionata
            if (dataGridPagamenti.SelectedItems.Count == 0)
            {
                MessageBox.Show("E' necessario selezionare un pagamento dalla griglia", "Nessuna selezione", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            pagSelezionato = (Pagamento)dataGridPagamenti.SelectedItems[0];
            this.DialogResult = true;
        }
    }
}
