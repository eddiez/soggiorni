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
    /// Interaction logic for CercaClienteWindow.xaml
    /// </summary>
    public partial class CercaClienteWindow : Window
    {
        private ObservableCollection<Cliente> clienti;
        private DataAccessGateway dag;

        private DettagliClienteWindow dcw;

        public bool isClienteModificato = false;

        public CercaClienteWindow()
        {
            InitializeComponent();
            dag = new DataAccessGateway();
            txtboxCognome.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(((Button)sender).Content.ToString());
            string prefix = ((Button)sender).Content.ToString();
            //azzera risultati ricerca
            if (clienti != null)
                clienti.Clear();

            List<Cliente> list = dag.cercaClientiByCognome(prefix);
            clienti = new ObservableCollection<Cliente>(list);
            var view = new ListCollectionView(clienti);
            view.SortDescriptions.Add(new System.ComponentModel.SortDescription("Cognome", System.ComponentModel.ListSortDirection.Ascending));
            this.dataGridClienti.DataContext = view;
            
            txtNumResults.Text = clienti.Count.ToString();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (clienti != null)
                clienti.Clear();

            int zero = 0;
            txtNumResults.Text = zero.ToString();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string prefix = txtboxCognome.Text;
            //azzera risultati ricerca
            if (clienti != null)
                clienti.Clear();

            List<Cliente> list = dag.cercaClientiByCognome(prefix);
            clienti = new ObservableCollection<Cliente>(list);
            var view = new ListCollectionView(clienti);
            view.SortDescriptions.Add(new System.ComponentModel.SortDescription("Cognome", System.ComponentModel.ListSortDirection.Ascending));
            this.dataGridClienti.DataContext = view;

            txtNumResults.Text = clienti.Count.ToString();
        }

        private void txtboxCognome_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void dataGridClienti_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //se ci sono risultati ed almeno uno è selezionato, mostro i dettagli del cliente
            if ((dataGridClienti.Items.Count > 0) && (dataGridClienti.SelectedItems.Count > 0))
            {
                dcw = new DettagliClienteWindow(((Cliente)dataGridClienti.SelectedItems[0]).Id);
                dcw.ShowDialog();

                if (dcw.DialogResult.HasValue && dcw.DialogResult.Value)
                {
                    clienti.Clear();
                    isClienteModificato = true;
                }
            }
        }
    }
}
