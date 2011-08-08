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
    /// Interaction logic for SelezionaComuneWindow.xaml
    /// </summary>
    public partial class SelezionaComuneWindow : Window
    {

        public Comune comuneSelezionato;
        private DataAccessGateway dag;
        private ObservableCollection<Comune> comuni;

        public SelezionaComuneWindow()
        {
            InitializeComponent();
            dag = new DataAccessGateway();
            txtboxComune.Focus();
        }

        public SelezionaComuneWindow(string defaultComuneName)
            : this()
        {
            txtboxComune.Text = defaultComuneName;
            btnSearch_Click(null, null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(((Button)sender).Content.ToString());
            string prefix = ((Button)sender).Content.ToString();
            //azzera risultati ricerca
            if (comuni != null)
                comuni.Clear();

            var list = dag.cercaComuniByNome(prefix);
            comuni = new ObservableCollection<Comune>(list);
            var view = new ListCollectionView(comuni);
            view.SortDescriptions.Add(new System.ComponentModel.SortDescription("Nome", System.ComponentModel.ListSortDirection.Ascending));
            this.dataGridComuni.DataContext = view;
            txtNumResults.Text = list.Count.ToString();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if(comuni!=null)
                comuni.Clear();

            txtNumResults.Text = "0";
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string prefix = txtboxComune.Text;
            //azzera risultati ricerca
            if (comuni != null)
                comuni.Clear();

            var list = dag.cercaComuniByNome(prefix);
            comuni = new ObservableCollection<Comune>(list);
            var view = new ListCollectionView(comuni);
            view.SortDescriptions.Add(new System.ComponentModel.SortDescription("Nome", System.ComponentModel.ListSortDirection.Ascending));
            this.dataGridComuni.DataContext = view;
            txtNumResults.Text = list.Count.ToString();
        }

        private void txtboxComune_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void btnSelectComune_Click(object sender, RoutedEventArgs e)
        {
            //caso 0 risultati
            if (dataGridComuni.Items.Count == 0)
            {
                MessageBox.Show("E' necessario avere almeno un risultato per selezionare un comune", "Nessun risultato di ricerca", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //caso nessuna riga selezionata
            if (dataGridComuni.SelectedItems.Count == 0)
            {
                MessageBox.Show("E' necessario selezionare un comune dalla griglia", "Nessuna selezione", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            comuneSelezionato = (Comune)dataGridComuni.SelectedItems[0];
            this.DialogResult = true;
        }
    }
}
