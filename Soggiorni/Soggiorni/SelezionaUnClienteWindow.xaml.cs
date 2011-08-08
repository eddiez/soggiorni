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
    /// Interaction logic for SelezionaUnClienteWindow.xaml
    /// </summary>
    public partial class SelezionaUnClienteWindow : Window
    {
        public Cliente clienteSelezionato;
        private DataAccessGateway dag;

        private ObservableCollection<Cliente> clienti;

        public SelezionaUnClienteWindow()
        {
            InitializeComponent();
            dag = new DataAccessGateway();
            txtboxCognome.Focus();
        }

        private void btnSelectCliente_Click(object sender, RoutedEventArgs e)
        {
            //caso 0 risultati
            if (dataGridClienti.Items.Count == 0)
            {
                MessageBox.Show("E' necessario avere almeno un risultato per selezionare un cliente", "Nessun risultato di ricerca", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //caso nessuna riga selezionata
            if (dataGridClienti.SelectedItems.Count == 0)
            {
                MessageBox.Show("E' necessario selezionare un cliente dalla griglia", "Nessuna selezione", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //prelevo tutti i dati del cliente selezionato
            clienteSelezionato = dag.cercaCliente(((Cliente)dataGridClienti.SelectedItems[0]).Id);
            this.DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(((Button)sender).Content.ToString());
            string prefix = ((Button)sender).Content.ToString();
            //azzera risultati ricerca
            if (clienti != null)
                clienti.Clear();

            var list = dag.cercaClientiByCognome(prefix);
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

            var list = dag.cercaClientiByCognome(prefix);
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
    }
}
