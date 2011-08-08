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
using Soggiorni.Data;

namespace Soggiorni
{
    /// <summary>
    /// Interaction logic for CambiaPeriodoCameraWindow.xaml
    /// </summary>
    public partial class CambiaPeriodoCameraWindow : Window
    {
        public Soggiorno sog;

        private List<Camera> allCamera;
        private DataAccessGateway dag;
        private bool modificaVerificata = false;

        public CambiaPeriodoCameraWindow(Soggiorno s)
        {
            InitializeComponent();
            dag = new DataAccessGateway();
            sog = s;
            loadCameraDataAndSelect();
            datePickerArrivo.SelectedDate = sog.Arrivo;
            datePickerPartenza.SelectedDate = sog.Partenza;
        }

        private void loadCameraDataAndSelect()
        {
            allCamera = dag.getAllCamera();
            cbxCamere.DataContext = allCamera;

            //selezionare numero camera da ipotesi
            var cameraToSelect = (from c in allCamera where c.Numero == sog.Camera.Numero select c).FirstOrDefault();
            cbxCamere.SelectedItem = cameraToSelect;
        }

        private void btnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnVerificaDisp_Click(object sender, RoutedEventArgs e)
        {
            if (datePickerArrivo.SelectedDate >= datePickerPartenza.SelectedDate)
            {
                MessageBox.Show("La data di arrivo deve precedere quella di partenza", "Errore nella scelta delle date", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //ricerca se la camera selezionata nel periodo selezionato è libera
            int idcam = ((Camera)cbxCamere.SelectedItem).Id;
            var from = (DateTime)datePickerArrivo.SelectedDate;
            var to = (DateTime)datePickerPartenza.SelectedDate;
            if (dag.canModifyPeriodoCameraSoggiorno(sog.Id, idcam, from, to))
            {
                ellipseSemaforo.Fill = (Brush)Application.Current.FindResource("semaforoVerde");
                ellipseSemaforo.Stroke = new SolidColorBrush(Colors.Green);
                modificaVerificata = true;
            }
            else
            {
                ellipseSemaforo.Fill = (Brush)Application.Current.FindResource("semaforoRosso");
                ellipseSemaforo.Stroke = new SolidColorBrush(Colors.DarkRed);
                modificaVerificata = false;
            }
        }

        private void resetVerificaDisponilibità()
        {
            ellipseSemaforo.Fill = (Brush)Application.Current.FindResource("semaforoGrigio");
            ellipseSemaforo.Stroke = new SolidColorBrush(Colors.Silver);
            modificaVerificata = false;
        }

        private void cbxCamere_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            resetVerificaDisponilibità();
        }

        private void datePickerPartenza_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            resetVerificaDisponilibità();
        }

        private void datePickerArrivo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            resetVerificaDisponilibità();
        }

        private void btnModifica_Click(object sender, RoutedEventArgs e)
        {
            if (datePickerArrivo.SelectedDate >= datePickerPartenza.SelectedDate)
            {
                MessageBox.Show("La data di arrivo deve precedere quella di partenza", "Errore nella scelta delle date", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!modificaVerificata)
            {
                //ricerca se la camera selezionata nel periodo selezionato è libera
                int idcam = ((Camera)cbxCamere.SelectedItem).Id;
                var from = (DateTime)datePickerArrivo.SelectedDate;
                var to = (DateTime)datePickerPartenza.SelectedDate;
                if (!dag.canModifyPeriodoCameraSoggiorno(sog.Id, idcam, from, to))
                {
                    MessageBox.Show("La camera è occupata nel periodo selezionato", "Impossibile eseguire modifica", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }

            sog.Camera = ((Camera)cbxCamere.SelectedItem);
            sog.Arrivo = (DateTime)datePickerArrivo.SelectedDate;
            sog.Partenza = (DateTime)datePickerPartenza.SelectedDate;

            this.DialogResult = true;
        }
    }
}
