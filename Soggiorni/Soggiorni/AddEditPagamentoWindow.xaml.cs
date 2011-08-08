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
    /// Interaction logic for AddEditPagamentoWindow.xaml
    /// </summary>
    public partial class AddEditPagamentoWindow : Window
    {
        public Pagamento pag;
        DataAccessGateway dag;
        private ObservableCollection<Soggiorno> soggiorni;
        private ObservableCollection<AltraAttivita> attivita;
        private ListCollectionView viewSogg;
        private ListCollectionView viewAtt;

        private bool isNewPagamento;

        private AddEditAltraAttWindow aeattw;
        private AssociaSoggiornoAPagamentoWindow aspw;
        private ReportPagamentoWindow rpw;
        private CFCalcWindow cfcw;

        private int maxFattura;
        private int maxRicFiscale;

        public AddEditPagamentoWindow()
        {
            InitializeComponent();

            dag = new DataAccessGateway();
            pag = new Pagamento();

            isNewPagamento = true;

            //fare query per numero nuova fattura e ricevuta fiscale
            var today = DateTime.Today;
            maxFattura = dag.getMaxNumPagamento(true, today);
            maxRicFiscale = dag.getMaxNumPagamento(false, today);
            if (maxFattura == 0) txtLastFattura.Text = "- Non ci sono fatture nel " + today.Year;
            else txtLastFattura.Text = "- Ultima fattura " + today.Year.ToString() + " = " + maxFattura;
            if (maxRicFiscale == 0) txtLastRicFisc.Text = "- Non ci sono ricevute fiscali " + today.Year;
            else txtLastRicFisc.Text = "- Ultima ricevuta fiscale " + today.Year.ToString() + " = " + maxRicFiscale;
            txtLastFattura.FontWeight = FontWeights.Bold;

            datePickerData.SelectedDate = DateTime.Today;
            //di default è selezionata la fattura
            txtboxNum.Text = (maxFattura + 1).ToString();
            string zeroEuro = (0).ToString("C");
            txtImportoTotale.Text = zeroEuro;
            txtImpImponibile.Text = zeroEuro;
            txtImpIva.Text = zeroEuro;

            attivita = new ObservableCollection<AltraAttivita>();
            viewAtt = new ListCollectionView(attivita);
            dataGridAtt.DataContext = viewAtt;
            soggiorni = new ObservableCollection<Soggiorno>();
            viewSogg = new ListCollectionView(soggiorni);
            dataGridSoggiorni.DataContext = viewSogg;

            //se è un nuovo pagamento non ho nulla da eliminare
            btnElimina.Visibility = System.Windows.Visibility.Hidden;
        }

        public AddEditPagamentoWindow(Pagamento p) : this()
        {
            isNewPagamento = false;
            this.Title = "Modifica pagamento";
            pag = p;

            datePickerData.SelectedDate = pag.Data;
            txtboxDest.Text = pag.Destinatario;
            if (pag.IsFattura)
            {
                radioButtonFatt.IsChecked = true;
                txtLastFattura.FontWeight = FontWeights.Bold;
                txtLastRicFisc.FontWeight = FontWeights.Normal;
            }
            else
            {
                radioButtonRicFisc.IsChecked = true;
                txtLastRicFisc.FontWeight = FontWeights.Bold;
                txtLastFattura.FontWeight = FontWeights.Normal;
            }

            //impostazione del numero dopo quella del radio button
            txtboxNum.Text = pag.Numero.ToString();
            txtboxSede.Text = pag.Sede;
            txtboxPiva.Text = pag.Piva;
            txtboxCf.Text = pag.Cf;
            txtboxNote.Text = pag.ModoPagamento;
            setImportoTotaleEImponibile(pag.Totale);

            //carico le altre attività
            var alist = dag.cercaAttivitaByPagamento(pag.Id);
            attivita = new ObservableCollection<AltraAttivita>(alist);
            viewAtt = new ListCollectionView(attivita);
            dataGridAtt.DataContext = viewAtt;

            //carico i soggiorni associati
            var slist = dag.cercaSoggiorniByPagamento(pag.Id);
            soggiorni = new ObservableCollection<Soggiorno>(slist);
            viewSogg = new ListCollectionView(soggiorni);
            dataGridSoggiorni.DataContext = viewSogg;

            
            //riabilito il bottone elimina
            btnElimina.Visibility = System.Windows.Visibility.Visible;
        }

        //private void radioButtonRicFisc_Checked(object sender, RoutedEventArgs e)
        //{
        //    if(isNewPagamento)
        //        txtboxNum.Text = (maxRicFiscale + 1).ToString();
        //}

        //private void radioButtonFatt_Checked(object sender, RoutedEventArgs e)
        //{
        //    if(txtboxNum!=null && isNewPagamento)
        //        txtboxNum.Text = (maxFattura + 1).ToString();
        //}

        private void datePickerData_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //caso di caricamento iniziale della finestra
            if (e.RemovedItems.Count == 0) return;

            //se seleziono un altro anno devo ricalcolare i maxFattura e maxRicFiscale
            if (datePickerData.SelectedDate.Value.Year != ((DateTime)e.RemovedItems[0]).Year)
            {
                DateTime newdate = (DateTime)datePickerData.SelectedDate;
                maxFattura = dag.getMaxNumPagamento(true, newdate);
                maxRicFiscale = dag.getMaxNumPagamento(false, newdate);
                if (maxFattura == 0) txtLastFattura.Text = "- Non ci sono fatture nel " + newdate.Year;
                else txtLastFattura.Text = "- Ultima fattura " + newdate.Year.ToString() + " = " + maxFattura;
                if (maxRicFiscale == 0) txtLastRicFisc.Text = "- Non ci sono ricevute fiscali nel " + newdate.Year;
                else txtLastRicFisc.Text = "- Ultima ricevuta fiscale " + newdate.ToString() + " = " + maxRicFiscale;
            }
        }

        private void btnAddAtt_Click(object sender, RoutedEventArgs e)
        {
            aeattw = new AddEditAltraAttWindow();
            aeattw.ShowDialog();

            if (aeattw.DialogResult.HasValue && aeattw.DialogResult.Value)
            {
                attivita.Add(aeattw.attivita);
                ricalcolaTotalePagamento();

                btnSalva_Click(null, null);
            }
        }

        private void btnDeleteAtt_Click(object sender, RoutedEventArgs e)
        {
            //caso 0 risultati
            if (dataGridAtt.Items.Count == 0 || dataGridAtt.SelectedItems.Count == 0)
            {
                return;
            }

            attivita.Remove((AltraAttivita)dataGridAtt.SelectedItems[0]);
            ricalcolaTotalePagamento();
            btnSalva_Click(null, null);
        }

        private void setImportoTotaleEImponibile(decimal t)
        {
            txtImportoTotale.Text = t.ToString("C");
            //calcolo imponibile con 10% di iva. 
            //imp  = tot / 1.10
            //iva = tot - imp
            pag.Totale = t;
            pag.Imponibile = t/1.1m;
            txtImpImponibile.Text = pag.Imponibile.ToString("C");
            txtImpIva.Text = (pag.Totale-pag.Imponibile).ToString("C");
        }

        private void ricalcolaTotalePagamento()
        {
            decimal tot = 0;
            foreach (var s in soggiorni)
                tot+=s.TotaleSoggiorno;
            foreach (var a in attivita)
                tot += a.Totale;

            setImportoTotaleEImponibile(tot);
        }

        private void dataGridAtt_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //se ci sono risultati ed almeno uno è selezionato, mostro i dettagli dell'attivita
            if ((dataGridAtt.Items.Count > 0) && (dataGridAtt.SelectedItems.Count > 0))
            {
                aeattw = new AddEditAltraAttWindow(((AltraAttivita)dataGridAtt.SelectedItems[0]));
                aeattw.ShowDialog();

                if (aeattw.DialogResult.HasValue && aeattw.DialogResult.Value)
                {
                    attivita[dataGridAtt.SelectedIndex] = aeattw.attivita;
                    viewAtt.Refresh();
                    ricalcolaTotalePagamento();
                    btnSalva_Click(null, null);
                }
            }
        }

        private void btnDissociaSoggiorno_Click(object sender, RoutedEventArgs e)
        {
            //caso 0 risultati
            if (dataGridSoggiorni.Items.Count == 0 || dataGridSoggiorni.SelectedItems.Count == 0)
            {
                return;
            }

            soggiorni.Remove((Soggiorno)dataGridSoggiorni.SelectedItems[0]);
            ricalcolaTotalePagamento();
            btnSalva_Click(null, null);
        }

        private void btnAssociaSoggiorno_Click(object sender, RoutedEventArgs e)
        {
            aspw = new AssociaSoggiornoAPagamentoWindow();
            aspw.ShowDialog();

            if (aspw.DialogResult.HasValue && aspw.DialogResult.Value)
            {
                soggiorni.Add(aspw.soggiornoSelezionato);
                ricalcolaTotalePagamento();
                btnSalva_Click(null, null);
            }
        }

        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            //validazione dati
            int numero;
            try
            {
                numero = int.Parse(txtboxNum.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Il n° del pagamento dev'essere un numero", "Errore nel campo numero pagamento", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (txtboxPiva.Text.Length != 0 && txtboxPiva.Text.Length != 11)
            {
                MessageBox.Show("La partita IVA deve essere lunga 11 caratteri, inseriti " + txtboxPiva.Text.Length, "Errore nel campo numero pagamento", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (txtboxCf.Text.Length != 0 && txtboxCf.Text.Length > 16)
            {
                MessageBox.Show("Il codice fiscale non può superare i 16 caratteri, inseriti " + txtboxCf.Text.Length, "Errore nel campo numero pagamento", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            pag.IsFattura = (bool)radioButtonFatt.IsChecked;
            pag.Numero = numero;
            pag.Data = (DateTime)datePickerData.SelectedDate;
            pag.Destinatario = txtboxDest.Text;
            pag.Sede = txtboxSede.Text;
            pag.Piva = txtboxPiva.Text;
            pag.Cf = txtboxCf.Text;
            pag.ModoPagamento = txtboxNote.Text;

            if (isNewPagamento)
            {
                //inserisco pagamento e prendo id
                int idNuovoPag = dag.inserisciPagamento(pag);

                //aggiorno lo stato di check-out dei soggiorni associati
                if (soggiorni.Count > 0)
                {
                    dag.aggiornaStatoSoggiorniNuovoPagamento(soggiorni.ToList<Soggiorno>(), idNuovoPag);
                }
                //inserisco attività inserite
                if (attivita.Count > 0)
                {
                    dag.inserisciAttivitaPagamento(attivita.ToList<AltraAttivita>(), idNuovoPag);
                }
                pag.Id = idNuovoPag;
            }
            else
            {
                //aggiorno il pagamento esistente: id già ce l'ho
                dag.aggiornaPagamento(pag);

                //elimino tutte le attività con questo id pagamento e le reinserisco
                dag.eliminaAttivitaByPagamento(pag.Id);
                if (attivita.Count > 0)
                {
                    dag.inserisciAttivitaPagamento(attivita.ToList<AltraAttivita>(), pag.Id);
                }

                //aggiorno stato di check-out dei soggiorni con questo id pagamento: lo levo a quelli nel db e lo metto a 
                //quelli appena selezionati
                dag.aggiornaStatoSoggiorniPagamentoEsistente(soggiorni.ToList<Soggiorno>(), pag.Id);
            }

            //se il chiamante è un altro metodo allora non chiudo la finestra, ma segnalo che non è più un nuovo pagamento
            if (sender == null)
            {
                isNewPagamento = false;
                return;
            }

            this.DialogResult = true;
        }

        private void btnElimina_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Sei sicuro di voler eliminare questo pagamento?", "Conferma eliminazione", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                if (soggiorni.Count > 0)
                {
                    MessageBox.Show("Non si può eliminare un pagamento che ha soggiorni associati", "Impossibile eliminare pagamento", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (attivita.Count > 0)
                {
                    MessageBox.Show("Non si può eliminare un pagamento che ha altre attività associate", "Impossibile eliminare pagamento", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                dag.eliminaPagamento(pag.Id);
                this.DialogResult = true;
            }
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            //se ho già il report aperto non lo apro un altro
            if (rpw != null && rpw.IsVisible) return;

            //validazione
            //validazione dati
            int numero;
            try
            {
                numero = int.Parse(txtboxNum.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Il n° del pagamento dev'essere un numero", "Errore nel campo numero pagamento", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (txtboxPiva.Text.Length != 0 && txtboxPiva.Text.Length != 11)
            {
                MessageBox.Show("La partita IVA deve essere lunga 11 caratteri, inseriti " + txtboxPiva.Text.Length, "Errore nel campo numero pagamento", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (txtboxCf.Text.Length != 0 && txtboxCf.Text.Length > 16)
            {
                MessageBox.Show("Il codice fiscale non può superare i 16 caratteri, inseriti " + txtboxCf.Text.Length, "Errore nel campo numero pagamento", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //prelevo i dati dai controlli 
            pag.IsFattura = (bool)radioButtonFatt.IsChecked;
            pag.Numero = numero;
            pag.Data = (DateTime)datePickerData.SelectedDate;
            pag.Destinatario = txtboxDest.Text;
            pag.Sede = txtboxSede.Text;
            pag.Piva = txtboxPiva.Text;
            pag.Cf = txtboxCf.Text;
            pag.ModoPagamento = txtboxNote.Text;

            //creo la lista delle voci pagamento
            
            //una per ogni attività
            var vplist = new List<VocePagamento>();
            VocePagamento vp;
            if(attivita.Count >0)
                foreach (var att in attivita)
                {
                    vp = new VocePagamento{
                        Causale = att.VoceInStampata, 
                        TotaleIvato = att.Totale
                    };
                    vplist.Add(vp);
                }

            //una unica per i soggiorni
            if (soggiorni.Count > 0)
                vplist.AddRange(getVociPagamentoSoggiorni());

            //creazione report
            rpw = new ReportPagamentoWindow(pag, vplist);
            rpw.Show();
            
        }

        private List<VocePagamento> getVociPagamentoSoggiorni()
        {
            var serviziPerTipo = new Dictionary<string, decimal>(); ;
            decimal totalePernotti = 0; ;
            int numPernotti = 0;
            Soggiorno sog;
            //popolo dizionario serviziPerTipo ed i totali del soggiorno
            foreach (var s in soggiorni)
            {
                sog = dag.cercaSoggiornoById(s.Id);
                numPernotti += sog.Notti;
                totalePernotti += (sog.PrezzoANotte * sog.Notti);
                var srvlist = sog.GetAllServizi();
                if (srvlist != null)
                    foreach (var serv in srvlist)
                        if (serviziPerTipo.ContainsKey(serv.Nome))
                            serviziPerTipo[serv.Nome] += serv.Totale;
                        else
                            serviziPerTipo.Add(serv.Nome, serv.Totale);
            }

            //aggiungo alla lista delle voci pagamento
            var vslist = new List<VocePagamento>();
            vslist.Add(new VocePagamento { Causale = numPernotti + " pernottamenti", TotaleIvato = totalePernotti });
            foreach (var kv in serviziPerTipo)
                vslist.Add(new VocePagamento { Causale = kv.Key, TotaleIvato = kv.Value });

            return vslist;
        }

        private void radioButtonRicFisc_Checked(object sender, RoutedEventArgs e)
        {
            if (txtLastFattura != null && txtLastRicFisc != null)
            {
                txtLastRicFisc.FontWeight = FontWeights.Bold;
                txtLastFattura.FontWeight = FontWeights.Normal;
            }
        }

        private void radioButtonFatt_Checked(object sender, RoutedEventArgs e)
        {
            if (txtLastFattura != null && txtLastRicFisc != null)
            {
                txtLastRicFisc.FontWeight = FontWeights.Normal;
                txtLastFattura.FontWeight = FontWeights.Bold;
            }
        }

        private void btnCFCalc_Click(object sender, RoutedEventArgs e)
        {
            //se c'è un soggiorno associato al pagamento, allora prendo il cliente del primo soggiorno come default
            if (soggiorni != null && soggiorni.Count > 0 && soggiorni[0].Cliente.Id != 0)
                cfcw = new CFCalcWindow(soggiorni[0].Cliente.Id);
            else
                cfcw = new CFCalcWindow();
            
            cfcw.ShowDialog();

            if (cfcw.DialogResult.HasValue && cfcw.DialogResult.Value)
            {
                txtboxCf.Text = cfcw.cf;
                txtboxDest.Text = cfcw.cl.Cognome + " " + cfcw.cl.Nome;
            }
        }

        
    }
}
