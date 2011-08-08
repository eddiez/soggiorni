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
    /// Interaction logic for VerificaDisponibilitaWindow.xaml
    /// </summary>
    /// 
    

    public partial class VerificaDisponibilitaWindow : Window
    {
        private ObservableCollection<Camera> camereLibere;
        private DataAccessGateway dag;
        private List<Camera> searchResults;

        public Soggiorno ipotesiSelezionata;

        public VerificaDisponibilitaWindow()
        {
            InitializeComponent();
            datepickerArrivo.SelectedDate = DateTime.Now.AddDays(1);
            datepickerPartenza.SelectedDate = DateTime.Now.AddDays(2);
            txtboxNotti.Text = ((DateTime)datepickerPartenza.SelectedDate).Subtract((DateTime)datepickerArrivo.SelectedDate).Days.ToString();

            dag = new DataAccessGateway();
        }

        private void datepickerPartenza_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datepickerPartenza.SelectedDate <= datepickerArrivo.SelectedDate)
            {
                MessageBox.Show("La data di partenza deve essere successiva a quella di arrivo", "Errata selezione data", MessageBoxButton.OK, MessageBoxImage.Error);
                datepickerPartenza.SelectedDate = (DateTime)e.RemovedItems[0];
                e.Handled = true;
                return;
            }

            if (camereLibere != null) camereLibere.Clear();

            if(datepickerArrivo.SelectedDate !=null && datepickerPartenza.SelectedDate !=null)
                txtboxNotti.Text = ((DateTime)datepickerPartenza.SelectedDate).Subtract((DateTime)datepickerArrivo.SelectedDate).Days.ToString();
        }

        private void datepickerArrivo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datepickerPartenza.SelectedDate <= datepickerArrivo.SelectedDate)
            {
                MessageBox.Show("La data di arrivo deve essere precedente a quella di partenza", "Errata selezione data", MessageBoxButton.OK, MessageBoxImage.Error);
                datepickerArrivo.SelectedDate = (DateTime)e.RemovedItems[0];
                e.Handled = true;
                return;
            }
            if (camereLibere != null) camereLibere.Clear();            

            if (datepickerArrivo.SelectedDate != null && datepickerPartenza.SelectedDate != null)
            {
                txtboxNotti.Text = ((DateTime)datepickerPartenza.SelectedDate).Subtract((DateTime)datepickerArrivo.SelectedDate).Days.ToString();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            datepickerPartenza.SelectedDate = datepickerPartenza.SelectedDate.Value.AddDays(1);
            if (camereLibere != null) camereLibere.Clear();
        }

        private void btnSub_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(txtboxNotti.Text) > 1)
            {
                datepickerPartenza.SelectedDate = datepickerPartenza.SelectedDate.Value.AddDays(-1);
                if (camereLibere != null) camereLibere.Clear();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if(camereLibere!=null) camereLibere.Clear();

            searchResults = dag.cercaCamereLibere((DateTime)datepickerArrivo.SelectedDate, (DateTime)datepickerPartenza.SelectedDate);
            camereLibere = new ObservableCollection<Camera>(searchResults);

            var view = new ListCollectionView(camereLibere);
            view.SortDescriptions.Add(
                new System.ComponentModel.SortDescription("Numero", System.ComponentModel.ListSortDirection.Ascending));
            dataGridCamere.DataContext = view;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (camereLibere != null) camereLibere.Clear();
        }

        private void btnPrenota_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridCamere.Items.Count > 0 && dataGridCamere.SelectedItems.Count > 0)
            {
                ipotesiSelezionata = new Soggiorno
                {
                    Arrivo = (DateTime)datepickerArrivo.SelectedDate,
                    Partenza = (DateTime)datepickerPartenza.SelectedDate,
                    Camera = (Camera)dataGridCamere.SelectedItems[0]
                };
                //MessageBox.Show(((Camera)dataGridCamere.SelectedItems[0]).Nome);
                this.DialogResult = true;
            }
        }
    }
}
