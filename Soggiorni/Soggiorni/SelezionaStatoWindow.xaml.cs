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
    /// Interaction logic for SelezionaStatoWindow.xaml
    /// </summary>
    public partial class SelezionaStatoWindow : Window
    {
        public Stato statoSelezionato;
        private DataAccessGateway dag;
        private ObservableCollection<Stato> stati;

        public SelezionaStatoWindow()
        {
            InitializeComponent();
            dag = new DataAccessGateway();
            txtboxStato.Focus();
        }

        public SelezionaStatoWindow(string defaultStatoName)
            : this()
        {
            txtboxStato.Text = defaultStatoName;
            btnSearch_Click(null, null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string prefix = ((Button)sender).Content.ToString();
            //azzera risultati ricerca
            if (stati!= null)
                stati.Clear();

            var list = dag.cercaStatiByNome(prefix);
            stati = new ObservableCollection<Stato>(list);
            var view = new ListCollectionView(stati);
            view.SortDescriptions.Add(new System.ComponentModel.SortDescription("Nome", System.ComponentModel.ListSortDirection.Ascending));
            this.dataGridStati.DataContext = view;
            txtNumResults.Text = list.Count.ToString();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (stati != null)
                stati.Clear();

            txtNumResults.Text = "0";
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string prefix = txtboxStato.Text;
            //azzera risultati ricerca
            if (stati != null)
                stati.Clear();

            var list = dag.cercaStatiByNome(prefix);
            stati = new ObservableCollection<Stato>(list);
            var view = new ListCollectionView(stati);
            view.SortDescriptions.Add(new System.ComponentModel.SortDescription("Nome", System.ComponentModel.ListSortDirection.Ascending));
            this.dataGridStati.DataContext = view;
            txtNumResults.Text = list.Count.ToString();
        }

        private void btnSelectComune_Click(object sender, RoutedEventArgs e)
        {
            //caso 0 risultati
            if (dataGridStati.Items.Count == 0)
            {
                MessageBox.Show("E' necessario avere almeno un risultato per selezionare uno stato", "Nessun risultato di ricerca", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //caso nessuna riga selezionata
            if (dataGridStati.SelectedItems.Count == 0)
            {
                MessageBox.Show("E' necessario selezionare uno stato dalla griglia", "Nessuna selezione", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            statoSelezionato = (Stato)dataGridStati.SelectedItems[0];
            this.DialogResult = true;
        }

        private void txtboxStato_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSearch_Click(null, null);
            }
        }
    }
}
