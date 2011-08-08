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
    /// Interaction logic for CercaPagamentoWindow.xaml
    /// </summary>
    public partial class CercaPagamentoWindow : Window
    {
        private DataAccessGateway dag;
        private ObservableCollection<Pagamento> pagamenti;

        private AddEditPagamentoWindow aepw;

        public CercaPagamentoWindow()
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
            txtNumSearchRes.Text = pagamenti.Count.ToString();
        }

        private void dataGridPagamenti_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            //se ci sono risultati ed almeno uno è selezionato, mostro i dettagli del pagamento
            if ((dataGridPagamenti.Items.Count > 0) && (dataGridPagamenti.SelectedItems.Count > 0))
            {
                aepw = new AddEditPagamentoWindow((Pagamento)dataGridPagamenti.SelectedItems[0]);
                aepw.ShowDialog();

                if (aepw.DialogResult.HasValue && aepw.DialogResult.Value)
                {
                    pagamenti.Clear();
                }
            }
        }
    }
}
