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
using Soggiorni.Model;
using System.Collections.ObjectModel;
using Soggiorni.Data;

namespace Soggiorni
{
    /// <summary>
    /// Interaction logic for CercaSoggiornoWindow.xaml
    /// </summary>
    public partial class CercaSoggiornoWindow : Window
    {
        public bool hasDoneModification = false;

        private SelezionaUnClienteWindow sucw;
        private ModificaSoggiornoWindow msw;

        private Cliente cliente = null;

        private DataAccessGateway dag;

        private ObservableCollection<Soggiorno> soggiorniResult;

        public CercaSoggiornoWindow()
        {
            InitializeComponent();

            
            dag = new DataAccessGateway();

            datePickerArrivo.SelectedDate = DateTime.Today.AddMonths(-1);
            datePickerPartenza.SelectedDate = DateTime.Today;
        }

        private void btnResetCliente_Click(object sender, RoutedEventArgs e)
        {
            txtboxCliente.Text = "";
            this.cliente = null;
        }

        private void btnArchivioClienti_Click(object sender, RoutedEventArgs e)
        {
            sucw = new SelezionaUnClienteWindow();
            sucw.ShowDialog();

            if (sucw.DialogResult.HasValue && sucw.DialogResult.Value)
            {
                txtboxCliente.Text = sucw.clienteSelezionato.Cognome;
                this.cliente = sucw.clienteSelezionato;
            }
        }

        private void btnCerca_Click(object sender, RoutedEventArgs e)
        {
            
            var list = dag.cercaSoggiorni((DateTime)datePickerArrivo.SelectedDate, (DateTime)datePickerPartenza.SelectedDate, cliente);
            soggiorniResult = new ObservableCollection<Soggiorno>(list);
            dataGridSoggiorni.DataContext = soggiorniResult;
        }

        private void dataGridSoggiorni_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((dataGridSoggiorni.Items.Count > 0) && (dataGridSoggiorni.SelectedItems.Count > 0))
            {
                msw = new ModificaSoggiornoWindow(((Soggiorno)dataGridSoggiorni.SelectedItems[0]).Id);
                msw.ShowDialog();

                if (msw.DialogResult.HasValue && msw.DialogResult.Value)
                {
                    soggiorniResult.Clear();
                    //aggiornamento dati avviene dentro la finestra msw
                    hasDoneModification = true;
                }
            }
        }

        private void btnTableau_Click(object sender, RoutedEventArgs e)
        {
            if (datePickerArrivo.SelectedDate > datePickerPartenza.SelectedDate)
            {
                MessageBox.Show("La data di arrivo deve precedere quella di partenza", "Estremi del tableau errati", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            TableauWinformsWindow tw = new TableauWinformsWindow((DateTime)datePickerArrivo.SelectedDate, (DateTime)datePickerPartenza.SelectedDate);
            tw.ShowDialog();

            if(soggiorniResult!=null)
                soggiorniResult.Clear();
        }
    }
}
