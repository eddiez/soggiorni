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
using System.Media;

namespace Soggiorni
{
    /// <summary>
    /// Interaction logic for AddSoggiornoWindow.xaml
    /// </summary>
    public partial class AddSoggiornoWindow : Window
    {

        private DataAccessGateway dag;
        private bool cameraDisponibileVerificata = false;
        private List<Camera> allCamera;
        private int idSelectedClient = 0;

        public bool isNuovoCliente = false;
        public Soggiorno nuovoSoggiorno;

        private Brush disabledColor = new SolidColorBrush(Colors.Silver);
        private Brush enabledColor = new SolidColorBrush(Colors.White);

        private SelezionaUnClienteWindow sucw;

        private System.Windows.Forms.NotifyIcon notifyIcon;

        public AddSoggiornoWindow()
        {
            InitializeComponent();

            dag = new DataAccessGateway();
            //Date default: Arrivo = domani, Partenza = Dopodomani
            datepickerArrivo.SelectedDate = DateTime.Today.AddDays(1);
            datepickerPartenza.SelectedDate = DateTime.Today.AddDays(2);
            
            loadCameraData();

            disableClienteTextBoxes();

            checkBoxConfermaSoggiorno.IsChecked = false;
        }

        private void loadCameraData()
        {
            allCamera = dag.getAllCamera();
            cbxNumCamera.DataContext = allCamera;
            txtTipoCamera.Text = "";
        }

        
        public AddSoggiornoWindow(Soggiorno ipotesi) :this()
        {
            //imposta date in base all'ipotesi di pernotto
            datepickerPartenza.SelectedDate = ipotesi.Partenza;
            datepickerArrivo.SelectedDate = ipotesi.Arrivo;

            //selezionare numero camera da ipotesi
            var cameraToSelect = (from c in allCamera where c.Numero==ipotesi.Camera.Numero select c).FirstOrDefault();
            cbxNumCamera.SelectedItem = cameraToSelect;
        }
        /*
        public AddSoggiornoWindow(Cliente cl)
        {
            InitializeComponent();
        }*/

        private void disableClienteTextBoxes()
        {
            
            txtboxCognome.IsReadOnly = true;
            txtboxCognome.Background = disabledColor;
            txtboxNome.IsReadOnly = true;
            txtboxNome.Background = disabledColor;
            txtboxTel.IsReadOnly = true;
            txtboxTel.Background = disabledColor;
            txtboxMail.IsReadOnly = true;
            txtboxMail.Background = disabledColor;
            txtboxNoteCliente.IsReadOnly = true;
            txtboxNoteCliente.Background = disabledColor;
        }

        private void enableClienteTextBoxes()
        {

            txtboxCognome.IsReadOnly = false;
            txtboxCognome.Background = enabledColor;
            txtboxNome.IsReadOnly = false;
            txtboxNome.Background = enabledColor;
            txtboxTel.IsReadOnly = false;
            txtboxTel.Background = enabledColor;
            txtboxMail.IsReadOnly = false;
            txtboxMail.Background = enabledColor;
            txtboxNoteCliente.IsReadOnly = false;
            txtboxNoteCliente.Background = enabledColor;
        }

        private void btnVerificaDisp_Click(object sender, RoutedEventArgs e)
        {
            if (datepickerPartenza.SelectedDate <= datepickerArrivo.SelectedDate)
            {
                MessageBox.Show("La data di arrivo deve essere precedente a quella di partenza", "Errata selezione data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (cbxNumCamera.SelectedItem == null)
            {
                MessageBox.Show("Selezionare una camera prima di verificare la disponibilità", "Camera non selezionata", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //ricerca se la camera selezionata nel periodo selezionato è libera
            int idcam = ((Camera)cbxNumCamera.SelectedItem).Id;
            var from = (DateTime)datepickerArrivo.SelectedDate;
            var to = (DateTime)datepickerPartenza.SelectedDate;
            if (dag.isCameraLibera(idcam, from, to))
            {
                ellipseSemaforo.Fill = (Brush)Application.Current.FindResource("semaforoVerde");
                ellipseSemaforo.Stroke = new SolidColorBrush(Colors.Green);
                cameraDisponibileVerificata = true;
            }
            else
            {
                ellipseSemaforo.Fill = (Brush)Application.Current.FindResource("semaforoRosso");
                ellipseSemaforo.Stroke = new SolidColorBrush(Colors.DarkRed);
                cameraDisponibileVerificata = false;
            }
        }

        private void btnNewCliente_Click(object sender, RoutedEventArgs e)
        {
            enableClienteTextBoxes();
            isNuovoCliente = true;
            btnNewCliente.IsEnabled = false;
            btnSelezionaCliente.IsEnabled = false;
            btnSelezionaCliente.Foreground = new SolidColorBrush(Colors.LightGray);
            txtboxCognome.Focus();
        }

        private void btnSelezionaCliente_Click(object sender, RoutedEventArgs e)
        {
            sucw = new SelezionaUnClienteWindow();
            sucw.ShowDialog();

            if (sucw.DialogResult.HasValue && sucw.DialogResult.Value)
            {
                enableClienteTextBoxes();
                isNuovoCliente = false;
                btnNewCliente.IsEnabled = false;
                btnNewCliente.Foreground = new SolidColorBrush(Colors.LightGray);

                //riempi i campi con i dati del cliente
                var cl = sucw.clienteSelezionato;
                txtboxCognome.Text = cl.Cognome;
                txtboxNome.Text = cl.Nome;
                txtboxTel.Text = cl.Telefoni;
                txtboxMail.Text = cl.Email;
                txtboxNoteCliente.Text = cl.Descr;
                idSelectedClient = cl.Id;
                
                //verifica se ci sono notifiche da fare per questo cliente: tipo ogni X soggiorni un premio
                var sogs = dag.cercaSoggiorniCliente(idSelectedClient);
                if (sogs.Count > 0)
                {
                    int soggiorniCliente = sogs.Count + 1;
                    if (soggiorniCliente == Properties.Settings.Default.CadenzaPremioSoggiorni)
                    {
                        //suono premio soggiorno
                        /*var mp = new MediaPlayer();
                        mp.Open(new Uri("arpa.mp3", UriKind.Relative));
                        mp.Play();*/
                        var sp = new SoundPlayer("arpa.wav");
                        sp.Play();

                        loadNotifyIcon(cl.Cognome);
                        
                    }
                }
            }
        }

        private void loadNotifyIcon(string cliente)
        {
            notifyIcon = new System.Windows.Forms.NotifyIcon();

            notifyIcon.Icon = System.Drawing.Icon.FromHandle(Properties.Resources.information.GetHicon());
            notifyIcon.BalloonTipText = cliente + " ha pernottato " + Properties.Settings.Default.CadenzaPremioSoggiorni + " volte alla Fattoria Pianetti!"; // Text of BalloonTip 
            notifyIcon.Text = "Premio cliente raggiunto"; // ToolTip of NotifyIcon 
            notifyIcon.BalloonTipTitle = "Cliente ha raggiunto il premio soggiorni";
            notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            notifyIcon.Visible = true;
            notifyIcon.Text = "Premio cliente";
            notifyIcon.ShowBalloonTip(1000); // Shows BalloonTip 

            notifyIcon.Click += new System.EventHandler(NotifyIcon_Click);

        }

        private void NotifyIcon_Click(object sender, System.EventArgs e)
        {
            ((System.Windows.Forms.NotifyIcon)sender).ShowBalloonTip(1000);
        }

        private void datepickerArrivo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            if (datepickerArrivo.SelectedDate >= datepickerPartenza.SelectedDate)
            {
                MessageBox.Show("La data di arrivo deve essere precedente a quella di partenza", "Errata selezione data", MessageBoxButton.OK, MessageBoxImage.Error);
                datepickerArrivo.SelectedDate = (DateTime)e.RemovedItems[0];
                e.Handled = true;
                return;
            }*/
            
            if (datepickerArrivo.SelectedDate != null && datepickerPartenza.SelectedDate != null)
            {
                txtNumeroNotti.Text = ((DateTime)datepickerPartenza.SelectedDate).Subtract((DateTime)datepickerArrivo.SelectedDate).Days.ToString();
                resetVerificaDisponilibità();
            }
        }

        private void datepickerPartenza_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (datepickerArrivo.SelectedDate != null && datepickerPartenza.SelectedDate != null)
            {
                txtNumeroNotti.Text = ((DateTime)datepickerPartenza.SelectedDate).Subtract((DateTime)datepickerArrivo.SelectedDate).Days.ToString();
                resetVerificaDisponilibità();
            }
        }

        private void btnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            //validazione completezza dati
             if (datepickerArrivo.SelectedDate >= datepickerPartenza.SelectedDate)
            {
                MessageBox.Show("La data di arrivo deve essere precedente a quella di partenza", "Errata selezione data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (cbxNumCamera.SelectedItem == null)
            {
                MessageBox.Show("Selezionare una camera per la prenotazione", "Camera non selezionata", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (txtboxCognome.IsReadOnly)
            {
                MessageBox.Show("Selezionare un cliente per la prenotazione", "Cliente non selezionato", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (isNuovoCliente && txtboxCognome.Text.Trim() == "")
            {
                MessageBox.Show("E' necessario indicare almeno il cognome del nuovo cliente", "Dati sul cliente mancanti", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (txtboxCaparra.Text.Trim() != "")
            {
                try
                {
                    decimal.Parse(txtboxCaparra.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("La caparra deve essere solo un numero (niente simbolo € o altro)", "Formato caparra errato", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            //validazione disponibilità camera
            if (cameraDisponibileVerificata)
            {
                salvaDatiSoggiorno();
                this.DialogResult = true;
            }
            else
            {
                //ricerca se la camera selezionata nel periodo selezionato è libera
                int idcam = ((Camera)cbxNumCamera.SelectedItem).Id;
                var from = (DateTime)datepickerArrivo.SelectedDate;
                var to = (DateTime)datepickerPartenza.SelectedDate;
                if (dag.isCameraLibera(idcam, from, to))
                {
                    salvaDatiSoggiorno();
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("La camera indicata non è disponibile nel periodo scelto", "Camera occupata", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
        }

        private void salvaDatiSoggiorno()
        {
            nuovoSoggiorno = new Soggiorno
            {
                Arrivo = (DateTime)datepickerArrivo.SelectedDate,
                Partenza = (DateTime)datepickerPartenza.SelectedDate,
                Cliente = new Cliente
                {
                    Id = idSelectedClient,
                    Nome = txtboxNome.Text,
                    Cognome = txtboxCognome.Text,
                    Email = txtboxMail.Text,
                    Telefoni = txtboxTel.Text,
                    Descr = txtboxNoteCliente.Text
                }, 
                Camera = ((Camera)cbxNumCamera.SelectedItem),
                UsoCamera = cbxUsoCamera.Text,
                Caparra = txtboxCaparra.Text=="" ? 0 : decimal.Parse(txtboxCaparra.Text),
                NoteCaparra = txtboxNoteCaparra.Text,
                NoteDurata = txtboxNotePeriodo.Text,
                Prenotante = txtboxPrenotante.Text,
                Confermato = (bool)checkBoxConfermaSoggiorno.IsChecked,
                NoteCamera = txtboxNoteCamera.Text
            };
        }

        private void cbxNumCamera_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtTipoCamera.Text = ((Camera)cbxNumCamera.SelectedItem).Tipo;
            
            //azzero verifica disponibilità
            resetVerificaDisponilibità();
        }

        private void resetVerificaDisponilibità()
        {
            ellipseSemaforo.Fill = (Brush)Application.Current.FindResource("semaforoGrigio");
            ellipseSemaforo.Stroke = new SolidColorBrush(Colors.Silver);
            cameraDisponibileVerificata = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(notifyIcon!=null)
                notifyIcon.Dispose();
        }
    }
}
