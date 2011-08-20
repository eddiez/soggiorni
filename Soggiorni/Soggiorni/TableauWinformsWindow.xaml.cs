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
using System.Data;
using System.Windows.Forms.Integration;
using Microsoft.Reporting.WinForms;


namespace Soggiorni
{
    /// <summary>
    /// Interaction logic for TableauWinformsWindow.xaml
    /// </summary>
    public partial class TableauWinformsWindow : Window
    {
        private DataTable dt;
        private List<Soggiorno> soggiorni;
        private DataAccessGateway dag;
        private DateTime firstDay;
        private DateTime lastDay;
        private System.Windows.Forms.DataGridView dataGridTableau;
        private List<Camera> camere;
       // private System.Drawing.Color prenotataColor;    //deprecated
       // private System.Drawing.Color confermataColor;   //deprecated
        private System.Drawing.Color defaultColor;

        private int startCol;
        private int endCol;
        private int startRow;
        private int colCamera = 0;

        private AddSoggiornoWindow asw;
        private ModificaSoggiornoWindow msw;
        private TableauReportWindow trw;

        public TableauWinformsWindow()
        {
            InitializeComponent();
            dag = new DataAccessGateway();

            //periodo di default [oggi, oggi + 2 mesi]
            firstDay = DateTime.Today;
            lastDay = firstDay.AddMonths(2);
            initializeDataGrid();

            setIntervalloTableauText();
        }

        private void setIntervalloTableauText()
        {
            txtIntervallo.Text = "Tableau dal " + firstDay.ToShortDateString() + " al " + lastDay.ToShortDateString();
        }

        public TableauWinformsWindow(DateTime f, DateTime l)
        {
            InitializeComponent();
            dag = new DataAccessGateway();

            //periodo di default [oggi, oggi + 2 mesi]
            firstDay = f;
            lastDay = l;
            initializeDataGrid();

            setIntervalloTableauText();
        }

        private void initializeDataGrid()
        {
            dt = new DataTable();

            //aggiungo le colonne
            dt.Columns.Add("NumCamera", typeof(int));
            for (var date = firstDay; date <= lastDay; date = date.AddDays(1))
            {
                dt.Columns.Add(date.ToString("ddd d/M"), typeof(string));
            }


            camere = dag.getAllCamera();
            foreach (var cam in camere)
                dt.Rows.Add(cam.Numero);
            

            dataGridTableau = new System.Windows.Forms.DataGridView();
            dataGridTableau.DataSource = dt;
            
            windowsFormsHost.Child = dataGridTableau;

            //confermataColor = System.Drawing.Color.LawnGreen;
            //prenotataColor = System.Drawing.Color.Gold;
            defaultColor = System.Drawing.Color.LawnGreen;

            dataGridTableau.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridTableau.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridTableau.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dataGridTableau.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            dataGridTableau.AllowUserToAddRows = false;
            dataGridTableau.AllowUserToDeleteRows = false;
            dataGridTableau.AllowUserToOrderColumns = false;
            dataGridTableau.AllowUserToResizeColumns = false;
            dataGridTableau.AllowUserToResizeRows = false;
            dataGridTableau.ReadOnly = true;
            dataGridTableau.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridTableau.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridTableau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridTableau.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            dataGridTableau.RowTemplate.Height = 38;

            dataGridTableau.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTableau_CellDoubleClick);
            dataGridTableau.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewTableau_CellMouseDown);
            dataGridTableau.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewTableau_CellMouseUp);
        }

        private int dateToColumn(DateTime d)
        {
            //colonna 0 c'è il numero della camera nascosto
            if (d < firstDay) return 1;
            if (d > lastDay) return dataGridTableau.ColumnCount - 1;

            return d.Subtract(firstDay).Days+1;
        }

        private DateTime colToDate(int col)
        {
            //colonna 0 c'è il numero della camera nascosto
            return firstDay.AddDays(col-1);
        }

        private void loadSoggiorni()
        {
            
            soggiorni = dag.cercaSoggiorniTableau(firstDay, lastDay);
            foreach (var s in soggiorni)
            {
                insertSoggiornoInGrid(s);
            }
        }

        private int getRowCamera(int numCam)
        {
            for (int i = 0; i < dataGridTableau.RowCount; i++)
                if ((int)dataGridTableau[colCamera, i].Value == numCam)
                    return i;
            return 0;
        }

        private void insertSoggiornoInGrid(Soggiorno s)
        {
            int startColumn, endColumn, numCellToColor;
            string notti = s.Notti == 1 ? s.Notti + " notte" : s.Notti + " notti";
            int rowCamera = getRowCamera(s.Camera.Numero);

            //soggiorno che inizia prima di  firstDay
            if (s.Arrivo < firstDay)
            {
                if (s.Partenza == firstDay) return;

                numCellToColor = s.Partenza.Subtract(firstDay).Days;
                for (int i = 1; i <= numCellToColor; i++)
                {
                    dataGridTableau[i, rowCamera].ToolTipText = notti;
                    coloraCella(s, rowCamera, i);
                }

                dataGridTableau[1, rowCamera].Value = s.Cliente.Cognome;
                return;
            }
            //soggiorno che termina dopo lastDay
            if (s.Partenza > lastDay)
            {
                numCellToColor = lastDay.Subtract(s.Arrivo).Days;
                startColumn = dateToColumn(s.Arrivo);
                for (int i = startColumn; i <= startColumn + numCellToColor; i++)
                {
                    dataGridTableau[i, rowCamera].ToolTipText = notti;
                    coloraCella(s, rowCamera, i);
                }
                dataGridTableau[startColumn, rowCamera].Value = s.Cliente.Cognome;
                return;
            }
            //soggiorno tutto compreso nel periodo
            startColumn = dateToColumn(s.Arrivo);
            endColumn = dateToColumn(s.Partenza.AddDays(-1));
            for (int i = startColumn; i <= endColumn; i++)
            {
                dataGridTableau[i, rowCamera].ToolTipText = notti;
                coloraCella(s, rowCamera, i);
            }
            dataGridTableau[startColumn, rowCamera].Value = s.Cliente.Cognome;
        }

        private void coloraCella(Soggiorno s, int rowCamera, int col)
        {
            if (s.ColoreGruppoArgb != 0)
                dataGridTableau[col, rowCamera].Style.BackColor = System.Drawing.Color.FromArgb(s.ColoreGruppoArgb);
            else
            {
                dataGridTableau[col, rowCamera].Style.BackColor = defaultColor;
                /*if (s.Confermato)
                    dataGridTableau[col, rowCamera].Style.BackColor = confermataColor;
                else
                    dataGridTableau[col, rowCamera].Style.BackColor = prenotataColor;*/
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //nascondo la colonna col numero camera (mi serve per mandare i dati giusti alle altre window)
            dataGridTableau.Columns[0].Visible = false;

            //carico etichette righe
            int i = 0;
            foreach (var cam in camere)
            {
                dataGridTableau.Rows[i].HeaderCell.Value = cam.Numero + " "+ cam.Nome + "\n" + cam.Tipo +" ("+cam.Bagno+")";
                i++;
            }
            //impedisco ordinamento via colonna
            for (int j = 0; j < dataGridTableau.Columns.Count; j++)
            {
                dataGridTableau.Columns[j].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            }

            loadSoggiorni();
        }

        private int getCameraNumero(int rowindex)
        {
            return (int)dataGridTableau[colCamera, rowindex].Value;
        }


        private void dataGridTableau_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            int maxCol = dataGridTableau.ColumnCount;
            int maxRow = dataGridTableau.RowCount;
            //MessageBox.Show(dataGridTableau[5, 50].Value.ToString());
            if (e.RowIndex < 0 || e.ColumnIndex <= 0 || e.RowIndex >=maxRow || e.ColumnIndex >= maxCol) return;

            if (dataGridTableau[e.ColumnIndex, e.RowIndex].InheritedStyle.BackColor != System.Drawing.Color.LightGray &&
                dataGridTableau[e.ColumnIndex, e.RowIndex].InheritedStyle.BackColor != System.Drawing.Color.White)
            {//modifica soggiorno
                var date = colToDate(e.ColumnIndex);
                //seleziona soggiorno cliccato
                var sog = (from s in soggiorni
                           where (s.Camera.Numero == getCameraNumero(e.RowIndex)) &&
                           (date >= s.Arrivo && date < s.Partenza)
                           select s).First();
                
                msw = new ModificaSoggiornoWindow(sog.Id);
                msw.ShowDialog();
                if (msw.DialogResult.HasValue && msw.DialogResult.Value)
                {
                    if (msw.soggiorno == null)
                        cancellaSoggiornoFromGrid(sog);
                    else
                        modificaSoggiornoInGrid(sog, msw.soggiorno);

                    soggiorni = dag.cercaSoggiorniTableau(firstDay, lastDay);
                }
            }
            else
            {//nuovo soggiorno
                var s = new Soggiorno();
                s.Arrivo = colToDate(e.ColumnIndex);
                s.Partenza = s.Arrivo.AddDays(1);
                s.Camera = new Camera { Numero = getCameraNumero(e.RowIndex) };
                asw = new AddSoggiornoWindow(s);
                asw.ShowDialog();
                if (asw.DialogResult.HasValue && asw.DialogResult.Value)
                {
                    dag.inserisciSoggiorno(asw.nuovoSoggiorno, asw.isNuovoCliente);
                    insertSoggiornoInGrid(asw.nuovoSoggiorno);
                    soggiorni = dag.cercaSoggiorniTableau(firstDay, lastDay);
                }
            }
        }

        private void modificaSoggiornoInGrid(Soggiorno oldSog, Soggiorno newSog)
        {
            if (oldSog.Arrivo != newSog.Arrivo ||
               oldSog.Partenza != newSog.Partenza ||
               oldSog.Camera.Numero != newSog.Camera.Numero ||
               oldSog.Cliente.Cognome != newSog.Cliente.Cognome ||
               oldSog.Confermato != newSog.Confermato ||
               oldSog.ColoreGruppoArgb != newSog.ColoreGruppoArgb)
            {
                cancellaSoggiornoFromGrid(oldSog);
                insertSoggiornoInGrid(newSog);
            }
        }

        private void cancellaSoggiornoFromGrid(Soggiorno sog)
        {
            int startCol, endCol, row;
            startCol = dateToColumn(sog.Arrivo);
            endCol = dateToColumn(sog.Partenza);
            row = getRowCamera(sog.Camera.Numero);
            System.Drawing.Color cellCol = (row % 2) == 0 ? System.Drawing.Color.White : System.Drawing.Color.LightGray;
            if (sog.Arrivo < firstDay) startCol = 1;
            if (sog.Partenza > lastDay) endCol = dataGridTableau.ColumnCount - 1;

            for (int i = startCol; i <= endCol; i++)
            {
                dataGridTableau[i, row].Value = "";
                dataGridTableau[i, row].Style.BackColor = cellCol;
            }
        }

        private void dataGridViewTableau_CellMouseDown(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            startCol = e.ColumnIndex;
            startRow = e.RowIndex;
        }

        private void dataGridViewTableau_CellMouseUp(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            endCol = e.ColumnIndex;
            //validazione estremi
            if (startCol >= endCol || 
                startRow < 0 || startRow >= dataGridTableau.RowCount ||
                startCol < 0 || startCol >= dataGridTableau.ColumnCount ||
                endCol < 0 || endCol >= dataGridTableau.ColumnCount) return;

            //verifica se si sovrappone a soggiorni esistenti
            for (int i = startCol; i <= endCol; i++)
            {
                if (dataGridTableau[i, startRow].InheritedStyle.BackColor != System.Drawing.Color.LightGray &&
                    dataGridTableau[i, startRow].InheritedStyle.BackColor != System.Drawing.Color.White)
                    return;
            }

            var s = new Soggiorno();
            s.Arrivo = colToDate(startCol);
            s.Partenza = colToDate(endCol).AddDays(1);
            s.Camera = new Camera { Numero = getCameraNumero(e.RowIndex) };
            asw = new AddSoggiornoWindow(s);
            asw.ShowDialog();
            
            if (asw.DialogResult.HasValue && asw.DialogResult.Value)
            {
                dag.inserisciSoggiorno(asw.nuovoSoggiorno, asw.isNuovoCliente);
                insertSoggiornoInGrid(asw.nuovoSoggiorno);
                soggiorni = dag.cercaSoggiorniTableau(firstDay, lastDay);
            }
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            //avanzo il tableau di 2 mesi
            firstDay = lastDay.AddDays(1); ;
            lastDay = firstDay.AddMonths(2);
            reloadDataGrid();
            setIntervalloTableauText();
            loadSoggiorni();
        }

        private void reloadDataGrid()
        {
            dt = new DataTable();

            //aggiungo le colonne
            dt.Columns.Add("NumCamera", typeof(int));
            for (var date = firstDay; date <= lastDay; date = date.AddDays(1))
            {
                dt.Columns.Add(date.ToString("ddd d/M"), typeof(string));
            }
            
            foreach (var cam in camere)
                dt.Rows.Add(cam.Numero);


            dataGridTableau.DataSource = dt;

            //carico etichette righe
            int i = 0;
            foreach (var cam in camere)
            {
                dataGridTableau.Rows[i].HeaderCell.Value = cam.Numero + " " + cam.Nome + "\n" + cam.Tipo + " (" + cam.Bagno + ")";
                i++;
            }
            
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            //indietreggio il tableau di 2 mesi
            lastDay = firstDay.AddDays(-1); 
            firstDay = lastDay.AddMonths(-2);
            reloadDataGrid();
            setIntervalloTableauText();
            loadSoggiorni();
        }

        private List<TableauPivot> buildTableauPivot()
        {
            List<TableauPivot> cells = new List<TableauPivot>();
            foreach (var sog in soggiorni)
            {
                if (sog.Arrivo >= firstDay)
                {
                    if (sog.Partenza <= lastDay)
                    {
                        for (var date = sog.Arrivo; date < sog.Partenza; date = date.AddDays(1))
                        {
                            cells.Add(new TableauPivot
                            {
                                data = date,
                                Cliente = sog.Cliente.Cognome,
                                Camera = sog.Camera.Numero,
                                Confermato = sog.Confermato,
                                Arrivo = sog.Arrivo
                            });
                        }
                    }
                    else
                    {
                        for (var date = sog.Arrivo; date <= lastDay; date = date.AddDays(1))
                        {
                            cells.Add(new TableauPivot
                            {
                                data = date,
                                Cliente = sog.Cliente.Cognome,
                                Camera = sog.Camera.Numero,
                                Confermato = sog.Confermato,
                                Arrivo = sog.Arrivo
                            });
                        }
                    }

                }
                else
                {
                    if (sog.Partenza <= lastDay)
                    {
                        for (var date = firstDay; date < sog.Partenza; date = date.AddDays(1))
                        {
                            cells.Add(new TableauPivot
                            {
                                data = date,
                                Cliente = sog.Cliente.Cognome,
                                Camera = sog.Camera.Numero,
                                Confermato = sog.Confermato,
                                Arrivo = sog.Arrivo
                            });
                        }
                    }
                    else
                    {
                        for (var date = firstDay; date < lastDay; date = date.AddDays(1))
                        {
                            cells.Add(new TableauPivot
                            {
                                data = date,
                                Cliente = sog.Cliente.Cognome,
                                Camera = sog.Camera.Numero,
                                Confermato = sog.Confermato,
                                Arrivo = sog.Arrivo
                            });
                        }
                    }
                }
            }

            //aggiunta celle vuote
            TableauPivot tp;
            TableauReportCellComparer trcc = new TableauReportCellComparer();
            for (var d = firstDay; d <= lastDay; d = d.AddDays(1))
            {
                foreach (var c in camere)
                {
                    tp = new TableauPivot { Camera = c.Numero, data = d, Cliente = "" };
                    if (!cells.Contains(tp, trcc))
                        cells.Add(tp);
                }
            }

            return cells;
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            trw = new TableauReportWindow(buildTableauPivot());
            trw.ShowDialog();
        }
    }
}
