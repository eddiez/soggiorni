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
using System.Collections.ObjectModel;

namespace Soggiorni
{
    /// <summary>
    /// Interaction logic for SelezionaProvIstatWindow.xaml
    /// </summary>
    public partial class SelezionaProvIstatWindow : Window
    {
        public ProvenienzaIstat provSelezionata;
        private DataAccessGateway dag;
        private ObservableCollection<ProvenienzaIstat> provenienze;

        public SelezionaProvIstatWindow()
        {
            InitializeComponent();
            dag = new DataAccessGateway();
            txtboxStato.Focus();
        }

        public SelezionaProvIstatWindow(string defaultStato) : this()
        {
            txtboxStato.Text = defaultStato;
            btnSearch_Click(null, null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string prefix = ((Button)sender).Content.ToString();
            //azzera risultati ricerca
            if (provenienze != null)
                provenienze.Clear();

            var list = dag.cercaProvIstatByStato(prefix);
            provenienze = new ObservableCollection<ProvenienzaIstat>(list);
            var view = new ListCollectionView(provenienze);
            //view.SortDescriptions.Add(new System.ComponentModel.SortDescription("Stato", System.ComponentModel.ListSortDirection.Ascending));
            this.dataGridProv.DataContext = view;
            txtNumResults.Text = list.Count.ToString();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (provenienze != null)
                provenienze.Clear();

            txtNumResults.Text = "0";
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string prefix = txtboxStato.Text;
            //azzera risultati ricerca
            if (provenienze != null)
                provenienze.Clear();

            var list = dag.cercaProvIstatByStato(prefix);
            provenienze = new ObservableCollection<ProvenienzaIstat>(list);
            var view = new ListCollectionView(provenienze);
           // view.SortDescriptions.Add(new System.ComponentModel.SortDescription("Stato", System.ComponentModel.ListSortDirection.Ascending));
            this.dataGridProv.DataContext = view;
            txtNumResults.Text = list.Count.ToString();
        }

        private void txtboxStato_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void btnSelectComune_Click(object sender, RoutedEventArgs e)
        {
            //caso 0 risultati
            if (dataGridProv.Items.Count == 0)
            {
                MessageBox.Show("E' necessario avere almeno un risultato per selezionare una provenienza", "Nessun risultato di ricerca", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //caso nessuna riga selezionata
            if (dataGridProv.SelectedItems.Count == 0)
            {
                MessageBox.Show("E' necessario selezionare una provenienza dalla griglia", "Nessuna selezione", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            provSelezionata = (ProvenienzaIstat)dataGridProv.SelectedItems[0];
            this.DialogResult = true;
        }
    }
}
