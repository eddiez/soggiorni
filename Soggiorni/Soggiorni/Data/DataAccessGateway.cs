using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Soggiorni.Model;
using System.Data.OleDb;
using Soggiorni.SoggiorniDbDataSetTableAdapters;


namespace Soggiorni.Data
{
    class DataAccessGateway
    {
        internal List<Soggiorno> cercaSoggiorniProssimoMese()
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QuerySoggiorniByArrivoBetween";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("Oggi", OleDbType.Date).Value = DateTime.Today;
            cmd.Parameters.Add("ProssimoMese", OleDbType.Date).Value = DateTime.Today.AddMonths(1);
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            List<Soggiorno> list = new List<Soggiorno>();
            while (reader.Read())
            {
                var sog = new Soggiorno();
                sog.Id = int.Parse(reader[0].ToString());
                sog.Arrivo = DateTime.Parse(reader[1].ToString());
                sog.Partenza = DateTime.Parse(reader[2].ToString());
                sog.Confermato = bool.Parse(reader[3].ToString());
                sog.Cliente = new Cliente { Cognome = reader[4].ToString() };
                sog.Camera = new Camera { 
                    Numero = int.Parse(reader[5].ToString()),
                    Agriturismo = reader[6].ToString()
                };
                list.Add(sog);
            }
            reader.Close();
            conn.Close();
            return list;
        }

        internal List<Soggiorno> cercaSoggiorniInCorso()
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QuerySoggiorniBetweenArrivoPartenza";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("Arrivo", OleDbType.Date).Value = DateTime.Today;
            cmd.Parameters.Add("Partenza", OleDbType.Date).Value = DateTime.Today;
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            List<Soggiorno> list = new List<Soggiorno>();
            while (reader.Read())
            {
                //Soggiorno.ID, Soggiorno.Partenza, Soggiorno.TotaleSoggiorno, Cliente.Cognome, Camera.Numero, Camera.Agriturismo
                var sog = new Soggiorno();
                sog.Id = int.Parse(reader[0].ToString());
                sog.Partenza = DateTime.Parse(reader[1].ToString());
                sog.TotaleSoggiorno = reader[2].ToString()=="" ? 0 : decimal.Parse(reader[2].ToString());
                sog.Cliente = new Cliente { Cognome = reader[3].ToString() };
                sog.Camera = new Camera
                {
                    Numero = int.Parse(reader[4].ToString()),
                    Agriturismo = reader[5].ToString()
                };
                list.Add(sog);
            }
            reader.Close();
            conn.Close();
            return list;
        }

        internal List<Soggiorno> cercaArriviOggi()
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QuerySoggiorniByArrivoExact";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("Arrivo", OleDbType.Date).Value = DateTime.Today;
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            List<Soggiorno> list = new List<Soggiorno>();
            while (reader.Read())
            {
                //Soggiorno.ID, Soggiorno.IsCheckedIn, Cliente.Cognome, Camera.Numero, Camera.Agriturismo
                var sog = new Soggiorno();
                sog.Id = int.Parse(reader[0].ToString());
                sog.IsCheckedIn = bool.Parse(reader[1].ToString());
                sog.Cliente = new Cliente { Cognome = reader[2].ToString() };
                sog.Camera = new Camera
                {
                    Numero = int.Parse(reader[3].ToString()),
                    Agriturismo = reader[4].ToString()
                };
                list.Add(sog);
            }
            reader.Close();
            conn.Close();
            return list;
        }

        internal List<Soggiorno> cercaPartenzeOggi()
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QuerySoggiorniByPartenzaExact";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("Partenza", OleDbType.Date).Value = DateTime.Today;
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            List<Soggiorno> list = new List<Soggiorno>();
            while (reader.Read())
            {
                //Soggiorno.ID, Soggiorno.IsCheckedOut, Cliente.Cognome, Camera.Numero, Camera.Agriturismo
                var sog = new Soggiorno();
                sog.Id = int.Parse(reader[0].ToString());
                sog.IsCheckedOut = bool.Parse(reader[1].ToString());
                sog.Cliente = new Cliente { Cognome = reader[2].ToString() };
                sog.Camera = new Camera
                {
                    Numero = int.Parse(reader[3].ToString()),
                    Agriturismo = reader[4].ToString()
                };
                list.Add(sog);
            }
            reader.Close();
            conn.Close();
            return list;
        }

        internal List<Camera> cercaCamereLibere(DateTime arrivo, DateTime partenza)
        {
            //raccolgo tutte le camere presenti nell'agriturismo
            var cta = new CameraTableAdapter();
            var cdt = cta.GetData();
            var camereDict = new Dictionary<int, Camera>();
            foreach (SoggiorniDbDataSet.CameraRow cam in cdt.Rows)
            {
                camereDict.Add(cam.Numero, new Camera
                {
                    Numero = cam.Numero,
                    Nome = cam.Nome,
                    Agriturismo = cam.Agriturismo,
                    Tipo = cam.Tipo,
                    Bagno = cam.Bagno
                });
            }
            

            //raccolgo i numeri delle camere non disponibili nel periodo selezionato
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QueryCamereOccupateBetween";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("Arrivo", OleDbType.Date).Value = arrivo;
            cmd.Parameters.Add("Partenza", OleDbType.Date).Value = partenza;
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            int numero;
            while (reader.Read())
            {
                //Camera.Numero, Camera.Nome, Camera.Agriturismo
                numero = int.Parse(reader[0].ToString());
                if(camereDict.ContainsKey(numero))
                    camereDict.Remove(numero);
            }
            reader.Close();
            conn.Close();
            return new List<Camera>(camereDict.Values);
        }

        internal List<Cliente> cercaClientiByCognome(string prefix)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QueryClienteByCognome";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("Prefisso", OleDbType.Char, 255).Value = prefix+"%";
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            var clist = new List<Cliente>();
            while (reader.Read())
            {
                //ID, Cognome, Nome, Telefoni
                var cliente = new Cliente
                {
                    Id = int.Parse(reader[0].ToString()),
                    Cognome = reader[1].ToString(),
                    Nome = reader[2].ToString(),
                    Telefoni = reader[3].ToString(),
                };
                clist.Add(cliente);
            }
            reader.Close();
            conn.Close();
            return clist;
            
        }

        internal List<Cliente> cercaClientiPerMailAuguri()
        {
            var clta = new ClienteTableAdapter();
            List<Cliente> clist = new List<Cliente>();
            var cldt = clta.GetDataForMailAuguri();
            foreach (var cldr in cldt)
            {
                clist.Add(new Cliente
                {
                    Nome = cldr.IsNomeNull() ? "" : cldr.Nome,
                    Cognome = cldr.IsCognomeNull() ? "" : cldr.Cognome,
                    DataNascita = cldr.IsDataNascitaNull() ? DateTime.MinValue : cldr.DataNascita,
                    Email = cldr.IsEmailNull() ? "" : cldr.Email
                });
            }
            return clist;
        }

        internal List<Camera> getAllCamera()
        {
            var cta = new CameraTableAdapter();
            var cdt = cta.GetData();
            
            var cameras = new List<Camera>();
            
            foreach (SoggiorniDbDataSet.CameraRow cr in cdt.Rows)
            {
                cameras.Add(new Camera
                {
                    
                    Id = cr.ID,
                    Numero = cr.Numero,
                    Nome = cr.IsNomeNull() ? "" : cr.Nome,
                    Agriturismo = cr.IsAgriturismoNull() ? "" : cr.Agriturismo,
                    FotoPath =  cr.IsFotoNull() ? "" : cr.Foto,
                    Tipo = cr.IsTipoNull() ? "" : cr.Tipo,
                    Bagno = cr.IsBagnoNull() ? "" : cr.Bagno
                });
            }
            return cameras;
        }

        internal bool isCameraLibera(int idcam, DateTime from, DateTime to)
        {
            //QueryCameraLiberaInData
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QueryCameraLiberaInData";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("IdCamera", OleDbType.Integer).Value = idcam;
            cmd.Parameters.Add("Arrivo", OleDbType.Date).Value = from;
            cmd.Parameters.Add("Partenza", OleDbType.Date).Value = to;
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            bool cameraLibera = !reader.HasRows;
            reader.Close();
            conn.Close();
            return cameraLibera;
        }

        internal Cliente cercaCliente(int idcliente)
        {
            var cta = new ClienteTableAdapter();
            var cdt = cta.GetDataById(idcliente);
            var cl = cdt[0];

            var foundcliente = new Cliente
            {
                //ID, Nome, Cognome, IsFemmina, Indirizzo, ComuneResid, StatoResid, Telefoni, Descrizione, 
                //Email, DataNascita, ComuneNascita, StatoNascita, StatoCittadinanza, TipoDocumento, NumDocumento, 
                //DataRilascioDoc, ComuneRilascioDoc, StatoRilascioDoc, ProvenienzaIstat
                Id = cl.ID,
                Nome = cl.IsNomeNull() ? "" : cl.Nome,
                Cognome = cl.Cognome,
                IsFemmina = cl.IsFemmina,
                Indirizzo = cl.IsIndirizzoNull() ? "" : cl.Indirizzo,
                ComuneResidenza = cl.IsComuneResidNull() ? null : new Comune { Id = cl.ComuneResid },
                StatoResidenza = cl.IsStatoResidNull() ? null : new Stato { Id = cl.StatoResid },
                Telefoni = cl.IsTelefoniNull() ? "" : cl.Telefoni,
                Descr = cl.IsDescrizioneNull() ? "" : cl.Descrizione,
                Email = cl.IsEmailNull() ? "" : cl.Email,
                DataNascita = cl.IsDataNascitaNull() ? DateTime.MinValue : cl.DataNascita,
                ComuneNascita = cl.IsComuneNascitaNull() ? null : new Comune { Id = cl.ComuneNascita },
                StatoNascita = cl.IsStatoNascitaNull() ? null : new Stato { Id = cl.StatoNascita },
                StatoCittadinanza = cl.IsStatoCittadinanzaNull() ? null : new Stato { Id = cl.StatoCittadinanza },
                TipoDoc = cl.IsTipoDocumentoNull() ? null : new TipoDocumento { Id = cl.TipoDocumento },
                NumDoc = cl.IsNumDocumentoNull() ? "" : cl.NumDocumento,
                DataRilascioDoc = cl.IsDataRilascioDocNull() ? DateTime.MinValue : cl.DataRilascioDoc,
                ComuneRilascioDoc = cl.IsComuneRilascioDocNull() ? null : new Comune { Id = cl.ComuneRilascioDoc },
                StatoRilascioDoc = cl.IsStatoRilascioDocNull() ? null : new Stato { Id = cl.StatoRilascioDoc },
                ProvenIstat = cl.IsProvenienzaIstatNull() ? null : new ProvenienzaIstat { Id = cl.ProvenienzaIstat }
            };

            //raccolgo dati comuni (se presenti)
            var comta = new ComuneTableAdapter();
            SoggiorniDbDataSet.ComuneDataTable comdt;

            if (foundcliente.ComuneNascita != null)
            {
                comdt = comta.GetDataById(foundcliente.ComuneNascita.Id);
                foundcliente.ComuneNascita.Nome = comdt[0].Nome;
                foundcliente.ComuneNascita.Provincia = comdt[0].Provincia;
            }
            if (foundcliente.ComuneResidenza != null)
            {
                comdt = comta.GetDataById(foundcliente.ComuneResidenza.Id);
                foundcliente.ComuneResidenza.Nome = comdt[0].Nome;
                foundcliente.ComuneResidenza.Provincia = comdt[0].Provincia;
            }
            if (foundcliente.ComuneRilascioDoc != null)
            {
                comdt = comta.GetDataById(foundcliente.ComuneRilascioDoc.Id);
                foundcliente.ComuneRilascioDoc.Nome = comdt[0].Nome;
                foundcliente.ComuneRilascioDoc.Provincia = comdt[0].Provincia;
            }

            //raccolgo dati stati (se presenti)
            var stata = new StatoTableAdapter();
            SoggiorniDbDataSet.StatoDataTable stadt;

            if (foundcliente.StatoNascita != null)
            {
                stadt = stata.GetDataById(foundcliente.StatoNascita.Id);
                foundcliente.StatoNascita.Nome = stadt[0].Nome;
            }
            if (foundcliente.StatoResidenza != null)
            {
                stadt = stata.GetDataById(foundcliente.StatoResidenza.Id);
                foundcliente.StatoResidenza.Nome = stadt[0].Nome;
            }
            if (foundcliente.StatoRilascioDoc != null)
            {
                stadt = stata.GetDataById(foundcliente.StatoRilascioDoc.Id);
                foundcliente.StatoRilascioDoc.Nome = stadt[0].Nome;
            }
            if (foundcliente.StatoCittadinanza != null)
            {
                stadt = stata.GetDataById(foundcliente.StatoCittadinanza.Id);
                foundcliente.StatoCittadinanza.Nome = stadt[0].Nome;
            }

            //raccolgo dati provenienza istat
            if (foundcliente.ProvenIstat != null)
            {
                var prota = new ProvenienzaIstatTableAdapter();
                var prodt = prota.GetDataById(foundcliente.ProvenIstat.Id);
                foundcliente.ProvenIstat.Regione = prodt[0].Regione;
                foundcliente.ProvenIstat.Stato = prodt[0].Stato;
            }

            //raccolgo dati tipo documento
            if (foundcliente.TipoDoc != null)
            {
                var tdocta = new TipoDocumentoTableAdapter();
                var tdocdt = tdocta.GetDataById(foundcliente.TipoDoc.Id);
                foundcliente.TipoDoc.Descrizione = tdocdt[0].Descrizione;
            }


            return foundcliente;
        }

        internal void inserisciSoggiorno(Soggiorno sg, bool nuovoCliente)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            OleDbCommand cmd;
            string queryString;

            if (nuovoCliente)
            {
                conn.Open();

                queryString = "INSERT INTO Cliente (Nome, Cognome, Telefoni, Descrizione, Email) VALUES (?, ?, ?, ?, ?)";
                cmd = new OleDbCommand(queryString, conn);
                cmd.Parameters.Add("Nome", OleDbType.Char, 255).Value = sg.Cliente.Nome;
                cmd.Parameters.Add("Cognome", OleDbType.Char, 255).Value = sg.Cliente.Cognome;
                cmd.Parameters.Add("Telefoni", OleDbType.Char, 255).Value = sg.Cliente.Telefoni;
                cmd.Parameters.Add("Descrizione", OleDbType.Char, 255).Value = sg.Cliente.Descr;
                cmd.Parameters.Add("Email", OleDbType.Char, 255).Value = sg.Cliente.Email;

                cmd.ExecuteNonQuery();

                //eseguo la query per ottenere l'id appena inserito
                cmd = new OleDbCommand("SELECT @@IDENTITY", conn);
                sg.Cliente.Id = (int)cmd.ExecuteScalar();

            }
            else
            {//aggiornamento dati (essenziali) cliente esistente
                var cta = new ClienteTableAdapter();
                cta.UpdateEssentialById(sg.Cliente.Nome, sg.Cliente.Cognome, sg.Cliente.Telefoni,
                    sg.Cliente.Descr, sg.Cliente.Email, sg.Cliente.Id);
            }

            //inserimento dati soggiorno
            if(conn.State != System.Data.ConnectionState.Open)
                conn.Open();


            /* Arrivo, Partenza, Cliente.ID, Camera.ID, UsoCamera, Caparra, NoteCaparra, NoteDurataSoggiorno,
             * NomePrenotante, Confermato, NoteNumeroOspiti
             * */
            queryString = "INSERT INTO Soggiorno (Arrivo, Partenza, ClienteId, CameraId, UsoCamera, Caparra, "+
                "NoteCaparra, NoteDurataSoggiorno, NomePrenotante, Confermato, NoteNumeroOspiti) VALUES "+
                "(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("Arrivo", OleDbType.Date).Value = sg.Arrivo;
            cmd.Parameters.Add("Partenza", OleDbType.Date).Value = sg.Partenza;
            cmd.Parameters.Add("IdCliente", OleDbType.Integer).Value = sg.Cliente.Id;
            cmd.Parameters.Add("IdCamera", OleDbType.Integer).Value = sg.Camera.Id;
            cmd.Parameters.Add("UsoCamera", OleDbType.Char, 255).Value = sg.UsoCamera;
            cmd.Parameters.Add("Caparra", OleDbType.Decimal).Value = sg.Caparra;
            cmd.Parameters.Add("NoteCaparra", OleDbType.Char, 255).Value = sg.NoteCaparra;
            cmd.Parameters.Add("NoteSoggiorno", OleDbType.Char, 255).Value = sg.NoteDurata;
            cmd.Parameters.Add("Prenotante", OleDbType.Char, 255).Value = sg.Prenotante;
            cmd.Parameters.Add("Confermato", OleDbType.Boolean).Value = sg.Confermato;
            cmd.Parameters.Add("NoteCamera", OleDbType.Char, 255).Value = sg.NoteCamera;

            cmd.ExecuteNonQuery();
            
            conn.Close();
        }

        public int salvaUtente(string tipo, string CF, string piva, string nome, string sede, string descr)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "INSERT INTO Utente (Tipo, CF, PIVA, Nome, Sede, Descrizione) VALUES (?, ?, ?, ?, ?, ?)";
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("Tipo", OleDbType.Char, 255).Value = tipo;
            cmd.Parameters.Add("CF", OleDbType.Char, 255).Value = CF;
            cmd.Parameters.Add("PIVA", OleDbType.Char, 255).Value = piva;
            cmd.Parameters.Add("Nome", OleDbType.Char, 255).Value = nome;
            cmd.Parameters.Add("Sede", OleDbType.Char, 255).Value = sede;
            cmd.Parameters.Add("Descrizione", OleDbType.Char, 255).Value = descr;

            cmd.ExecuteNonQuery();

            cmd = new OleDbCommand("SELECT @@IDENTITY", conn);
            int newid = (int)cmd.ExecuteScalar();
            conn.Close();

            return newid;
        }

        internal List<Soggiorno> cercaSoggiorniCliente(int idcliente)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QuerySoggiorniByCliente";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("IdCliente", OleDbType.Integer).Value = idcliente;
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            var slist = new List<Soggiorno>();
            while (reader.Read())
            {

                //Soggiorno.ID, Soggiorno.Arrivo, Soggiorno.Partenza, Soggiorno.PrezzoANotteCamera, Camera.Numero, 
                //Soggiorno.UsoCamera, Soggiorno.TotaleSoggiorno
                slist.Add(new Soggiorno
                {
                    Id = int.Parse(reader[0].ToString()),
                    Arrivo = DateTime.Parse(reader[1].ToString()),
                    Partenza = DateTime.Parse(reader[2].ToString()),
                    PrezzoANotte = (reader[3].ToString() == "") ? 0 : decimal.Parse(reader[3].ToString()),
                    Camera = new Camera { Numero = int.Parse(reader[4].ToString()) },
                    UsoCamera = reader[5].ToString(),
                    TotaleSoggiorno = (reader[6].ToString() == "") ? 0 : decimal.Parse(reader[6].ToString())
                });
                
            }
            reader.Close();
            conn.Close();
            return slist;
        }

        internal void aggiornaCliente(Cliente cl)
        {
            var cta = new ClienteTableAdapter();
            cta.UpdateById(
                cl.Nome, cl.Cognome, cl.IsFemmina, cl.Indirizzo,
                cl.ComuneResidenza == null ? null : (int?)cl.ComuneResidenza.Id,
                cl.StatoResidenza == null ? null : (int?)cl.StatoResidenza.Id,
                cl.Telefoni, cl.Descr, cl.Email,
                cl.DataNascita == DateTime.MinValue ? null : (DateTime?)cl.DataNascita,
                cl.ComuneNascita== null ? null : (int?)cl.ComuneNascita.Id,
                cl.StatoNascita == null ? null : (int?)cl.StatoNascita.Id,
                cl.StatoCittadinanza == null ? null : (int?)cl.StatoCittadinanza.Id,
                cl.TipoDoc == null ? null : (int?)cl.TipoDoc.Id,
                cl.NumDoc, 
                cl.DataRilascioDoc == DateTime.MinValue ? null : (DateTime?)cl.DataRilascioDoc,
                cl.ComuneRilascioDoc == null ? null : (int?)cl.ComuneRilascioDoc.Id,
                cl.StatoRilascioDoc == null ? null : (int?)cl.StatoRilascioDoc.Id,
                cl.ProvenIstat == null ? null : (int?)cl.ProvenIstat.Id,
                cl.Id
            );
        }

        internal List<Soggiorno> cercaSoggiorni(DateTime arrivo, DateTime partenza, Cliente cliente)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString;
            if(cliente!=null)
                queryString = "SELECT * FROM QuerySoggiorniBetweenDataByCliente";
            else
                queryString = "SELECT * FROM QuerySoggiorniBetweenData";
            
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("Arrivo", OleDbType.Date).Value = arrivo;
            cmd.Parameters.Add("Partenza", OleDbType.Date).Value = partenza;
            if(cliente != null)
                cmd.Parameters.Add("IdCliente", OleDbType.Integer).Value = cliente.Id;
            
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            var slist = new List<Soggiorno>();
            while (reader.Read())
            {

                //Soggiorno.ID, Soggiorno.Arrivo, Soggiorno.Partenza, Soggiorno.TotaleSoggiorno, Cliente.Cognome, Camera.Numero,
                //Soggiorno.IsCheckedIn, Soggiorno.IsCheckedOut
                slist.Add(new Soggiorno
                {
                    Id = int.Parse(reader[0].ToString()),
                    Arrivo = DateTime.Parse(reader[1].ToString()),
                    Partenza = DateTime.Parse(reader[2].ToString()),
                    TotaleSoggiorno = (reader[3].ToString() == "") ? 0 : decimal.Parse(reader[3].ToString()),
                    Cliente = new Cliente{ Cognome = reader[4].ToString()},
                    Camera = new Camera { Numero = int.Parse(reader[5].ToString()) },
                    IsCheckedIn = bool.Parse(reader[6].ToString()),
                    IsCheckedOut = bool.Parse(reader[7].ToString())
                });
                

            }
            reader.Close();
            conn.Close();
            return slist;
        }

        internal Soggiorno cercaSoggiornoById(int idSoggiorno)
        {
            //query per ricezione soggiorno
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QuerySoggiornoById";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("IdSoggiorno", OleDbType.Integer).Value = idSoggiorno;
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            var sog = new Soggiorno();
            reader.Read();

            /*Campi query:
            * Soggiorno.ID, Soggiorno.Arrivo, Soggiorno.Partenza, Soggiorno.UsoCamera, Soggiorno.PrezzoANotteCamera, 
            * Soggiorno.Caparra, Soggiorno.NoteCaparra, Soggiorno.TotaleSoggiorno, Soggiorno.NoteSaldoSoggiorno, 
            * Soggiorno.NoteDurataSoggiorno, Soggiorno.TotaleCamera, Soggiorno.Confermato, Soggiorno.NoteNumeroOspiti,
            * Cliente.ID, Cliente.Cognome, Camera.ID, Camera.Numero, Soggiorno.NomePrenotante,Soggiorno.IsCheckedIn, 
            * Soggiorno.IsCheckedOut, Soggiorno.PagamentoId, Soggiorno.ColoreGruppo
            * */

            sog.Id = idSoggiorno;
            sog.Arrivo = DateTime.Parse(reader[1].ToString());
            sog.Partenza = DateTime.Parse(reader[2].ToString());
            sog.UsoCamera = reader[3].ToString();
            sog.PrezzoANotte = (reader[4].ToString() == "") ? 0 : decimal.Parse(reader[4].ToString());
            sog.Caparra = (reader[5].ToString() == "") ? 0 : decimal.Parse(reader[5].ToString());
            sog.NoteCaparra = reader[6].ToString();
            sog.TotaleSoggiorno = (reader[7].ToString() == "") ? 0 : decimal.Parse(reader[7].ToString());
            sog.NoteSaldoSoggiorno = reader[8].ToString();
            sog.NoteDurata = reader[9].ToString();
            sog.TotalePernotto = (reader[10].ToString() == "") ? 0 : decimal.Parse(reader[10].ToString());
            sog.Confermato = bool.Parse(reader[11].ToString());
            sog.NoteCamera = reader[12].ToString();
            sog.Cliente = new Cliente{ 
                Id = int.Parse(reader[13].ToString()),
                Cognome = reader[14].ToString()};
            sog.Camera = new Camera{
                Id = int.Parse(reader[15].ToString()),
                Numero = int.Parse(reader[16].ToString())};
            sog.Prenotante = reader[17].ToString();
            sog.IsCheckedIn = bool.Parse(reader[18].ToString());
            sog.IsCheckedOut = bool.Parse(reader[19].ToString());
            sog.IdPagamento = reader[20].ToString() == "" ? 0 : int.Parse(reader[20].ToString());
            sog.ColoreGruppoArgb = (reader[21].ToString() == "") ? 0 : int.Parse(reader[21].ToString()); 
        
            reader.Close();
            
            //query per ricezione di tutti i servizi associati al soggiorno
            queryString = "SELECT * FROM QueryServiziByIdSoggiorno";
            cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("IdSoggiorno", OleDbType.Integer).Value = idSoggiorno;
            
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                //Servizio.Nome, ServiziSoggiorno.NoteServizio, ServiziSoggiorno.TotaleServizio, Servizo.ID
                sog.AddServizio(new ServizioSoggiorno
                {
                    Nome = reader[0].ToString(),
                    Note = reader[1].ToString(),
                    Totale = (reader[2].ToString() == "") ? 0 : decimal.Parse(reader[2].ToString()),
                    IdServizio = int.Parse(reader[3].ToString())
                });
            }
            reader.Close();
            conn.Close();
            return sog;
        }

        internal List<ServizioSoggiorno> getAllServizi()
        {
            var sta = new ServizioTableAdapter();
            var sdt = sta.GetData();
            var slist = new List<ServizioSoggiorno>();
            foreach (SoggiorniDbDataSet.ServizioRow sdr in sdt.Rows)
            {
                slist.Add(new ServizioSoggiorno
                {
                    Nome = sdr.Nome,
                    PrezzoListino = sdr.IsPrezzoListinoNull() ? 0 : sdr.PrezzoListino,
                    IdServizio = sdr.ID
                });
            }
            return slist;
        }

        internal void eliminaSoggiorno(int idSoggiorno)
        {
            var ssta = new ServiziSoggiornoTableAdapter();
            ssta.DeleteByIdSoggiorno(idSoggiorno);

            var sta = new SoggiornoTableAdapter();
            sta.DeleteById(idSoggiorno);
        }

        internal void aggiornaSoggiorno(Soggiorno s)
        {
            //cancello tutti i servizi: tabella ServiziSoggiorno non ha una chiave quindi non posso fare una update
            //ho eliminato la chiave perchè posso avere più servizi dello stesso tipo (es. altro) associati ad un soggiorno
            var ssta = new ServiziSoggiornoTableAdapter();
            ssta.DeleteByIdSoggiorno(s.Id);
            //inserisco i nuovi servizi uno alla volta
            var srvlist = s.GetAllServizi();
            if(srvlist!=null)
                foreach (var srv in s.GetAllServizi())
                    ssta.Insert(s.Id, srv.IdServizio, srv.Totale, srv.Note);

            //update dei dati del soggiorno
            var sta = new SoggiornoTableAdapter();
            sta.UpdateById(s.Arrivo, s.Partenza, s.Cliente.Id, s.Camera.Id, s.UsoCamera, s.PrezzoANotte, s.Caparra,
                s.NoteCaparra, s.TotaleSoggiorno, s.NoteSaldoSoggiorno, s.NoteDurata, s.TotalePernotto, s.Prenotante,
                s.Confermato, s.NoteCamera, s.IsCheckedIn, s.IsCheckedOut, 
                s.IdPagamento==0 ? null : (int?)s.IdPagamento, s.ColoreGruppoArgb,
                s.Id);
        }

        internal bool canModifyPeriodoCameraSoggiorno(int idSoggiorno, int idcam, DateTime from, DateTime to)
        {
            //QueryCameraLiberaInData
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QueryCameraLiberaInData";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("IdCamera", OleDbType.Integer).Value = idcam;
            cmd.Parameters.Add("Arrivo", OleDbType.Date).Value = from;
            cmd.Parameters.Add("Partenza", OleDbType.Date).Value = to;
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();

            //se non ci sono risultati allora è libera
            if (!reader.HasRows)
                return true;

            //se c'è un soggiorno con id diverso dal soggiorno da modificare allora non posso fare la modifica
            while (reader.Read())
            {
                //Arrivo, IDsoggiorno
                if (int.Parse(reader[1].ToString()) != idSoggiorno)
                    return false;
            }
            //caso un solo risultato con id uguale a quello da modificare
            return true;
        }


        internal void eliminaCliente(int idcliente)
        {
            var cta = new ClienteTableAdapter();
            cta.DeleteById(idcliente);
        }

        internal List<TipoDocumento> getAllTipiDoc()
        {
            var tdta = new TipoDocumentoTableAdapter();
            var tddt = tdta.GetData();

            var tlist = new List<TipoDocumento>();
            foreach (SoggiorniDbDataSet.TipoDocumentoRow tdr in tddt.Rows)
            {
                tlist.Add(
                    new TipoDocumento
                    {
                        Id = tdr.ID,
                        Descrizione = tdr.Descrizione
                    });
            }

            return tlist;
        }

        internal List<Comune> cercaComuniByNome(string prefix)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QueryComuniByNome";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("Prefisso", OleDbType.Char, 255).Value = prefix + "%";
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            var clist = new List<Comune>();
            Comune comune;
            while (reader.Read())
            {
                //ID, Nome, Provincia, DataCessazione
                comune = new Comune
                {
                    Id = int.Parse(reader[0].ToString()),
                    Nome = reader[1].ToString(),
                    Provincia = reader[2].ToString(),
                    DataCessazione = reader[3].ToString()=="" ? DateTime.MinValue : DateTime.Parse(reader[3].ToString())
                };
                clist.Add(comune);
            }
            reader.Close();
            conn.Close();
            return clist;
        }

        internal int getStatoByNome(string nomeStato)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QueryStatoByExactNome";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("Nome", OleDbType.Char, 255).Value = nomeStato;
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            var clist = new List<Comune>();
            int idStato  = 0;
            
            if (reader.Read())
                idStato = int.Parse(reader[0].ToString());
            
            reader.Close();
            conn.Close();
            return idStato;
        }

        internal List<Stato> cercaStatiByNome(string prefix)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QueryStatiByNome";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("Prefisso", OleDbType.Char, 255).Value = prefix + "%";
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            var slist = new List<Stato>();
            Stato stato;
            while (reader.Read())
            {
                //ID, Nome
                stato = new Stato
                {
                    Id = int.Parse(reader[0].ToString()),
                    Nome = reader[1].ToString(),
                };
                slist.Add(stato);
            }
            reader.Close();
            conn.Close();
            return slist;
        }

        internal List<ProvenienzaIstat> cercaProvIstatByStato(string prefix)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QueryProvIstatByStato";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("Prefisso", OleDbType.Char, 255).Value = prefix + "%";
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            var plist = new List<ProvenienzaIstat>();
            ProvenienzaIstat prov;
            while (reader.Read())
            {
                //ID, Regione, Stato
                prov = new ProvenienzaIstat
                {
                    Id = int.Parse(reader[0].ToString()),
                    Regione = reader[1].ToString(),
                    Stato = reader[2].ToString()
                };
                plist.Add(prov);
            }
            reader.Close();
            conn.Close();
            return plist;
        }

        internal List<SchedaNotifica> cercaSchedeNotificaBySoggiorno(int idsoggiorno)
        {
            
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QuerySchedeBySoggiorno";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("Soggiorno", OleDbType.Char, 255).Value = idsoggiorno;
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            var sclist = new List<SchedaNotifica>();
            SchedaNotifica sc;

            var comta = new ComuneTableAdapter();
            SoggiorniDbDataSet.ComuneDataTable comdt;

            var stata = new StatoTableAdapter();
            SoggiorniDbDataSet.StatoDataTable stadt;

            var tdocta = new TipoDocumentoTableAdapter();
            SoggiorniDbDataSet.TipoDocumentoDataTable tdocdt;

            while (reader.Read())
            {
                /*
                 * SchedaNotifica.Cliente, Cliente.Nome, Cliente.Cognome, Cliente.IsFemmina, Cliente.Indirizzo, 
                 * Cliente.ComuneResid, Cliente.StatoResid, Cliente.DataNascita, Cliente.ComuneNascita, 
                 * Cliente.StatoNascita, Cliente.StatoCittadinanza, Cliente.TipoDocumento, Cliente.NumDocumento, 
                 * Cliente.DataRilascioDoc, Cliente.ComuneRilascioDoc, Cliente.StatoRilascioDoc, Cliente.ProvenienzaIstat,
                 * SchedaNotifica.Numero, SchedaNotifica.Anno
                 */
                sc = new SchedaNotifica
                {
                    SoggiornoId = idsoggiorno,
                    Cliente = new Cliente{
                        Id = int.Parse(reader[0].ToString()),
                        Nome = reader[1].ToString(),
                        Cognome = reader[2].ToString(),
                        IsFemmina = bool.Parse(reader[3].ToString()),
                        Indirizzo = reader[4].ToString(),
                        ComuneResidenza = reader[5].ToString()=="" ? null : new Comune{ Id = int.Parse(reader[5].ToString())},
                        StatoResidenza = reader[6].ToString() == "" ? null : new Stato { Id = int.Parse(reader[6].ToString()) },
                        DataNascita = reader[7].ToString()=="" ? DateTime.MinValue : DateTime.Parse(reader[7].ToString()),
                        ComuneNascita = reader[8].ToString() == "" ? null : new Comune { Id = int.Parse(reader[8].ToString()) },
                        StatoNascita = reader[9].ToString() == "" ? null : new Stato { Id = int.Parse(reader[9].ToString()) },
                        StatoCittadinanza = reader[10].ToString() == "" ? null : new Stato { Id = int.Parse(reader[10].ToString()) },
                        TipoDoc = reader[11].ToString() == "" ? null : new TipoDocumento { Id = int.Parse(reader[11].ToString()) },
                        NumDoc = reader[12].ToString(),
                        DataRilascioDoc = reader[13].ToString() == "" ? DateTime.MinValue : DateTime.Parse(reader[13].ToString()),
                        ComuneRilascioDoc = reader[14].ToString() == "" ? null : new Comune { Id = int.Parse(reader[14].ToString()) },
                        StatoRilascioDoc = reader[15].ToString() == "" ? null : new Stato { Id = int.Parse(reader[15].ToString()) },
                        ProvenIstat= reader[16].ToString() == "" ? null : new ProvenienzaIstat { Id = int.Parse(reader[16].ToString()) }
                    },
                    Numero = reader[17].ToString()=="" ? 0 : int.Parse(reader[17].ToString()),
                    Anno = reader[18].ToString()=="" ? 0 : int.Parse(reader[18].ToString())
                };

                //raccolgo dati comuni, stati e tipo doc
                if (sc.Cliente.ComuneNascita != null)
                {
                    comdt = comta.GetDataById(sc.Cliente.ComuneNascita.Id);
                    sc.Cliente.ComuneNascita.Nome = comdt[0].Nome;
                    sc.Cliente.ComuneNascita.Provincia = comdt[0].Provincia;
                }
                if (sc.Cliente.ComuneResidenza != null)
                {
                    comdt = comta.GetDataById(sc.Cliente.ComuneResidenza.Id);
                    sc.Cliente.ComuneResidenza.Nome = comdt[0].Nome;
                    sc.Cliente.ComuneResidenza.Provincia = comdt[0].Provincia;
                }
                if (sc.Cliente.ComuneRilascioDoc != null)
                {
                    comdt = comta.GetDataById(sc.Cliente.ComuneRilascioDoc.Id);
                    sc.Cliente.ComuneRilascioDoc.Nome = comdt[0].Nome;
                    sc.Cliente.ComuneRilascioDoc.Provincia = comdt[0].Provincia;
                }
                stadt = stata.GetDataById(sc.Cliente.StatoNascita.Id);
                sc.Cliente.StatoNascita.Nome = stadt[0].Nome;
                stadt = stata.GetDataById(sc.Cliente.StatoResidenza.Id);
                sc.Cliente.StatoResidenza.Nome = stadt[0].Nome;
                stadt = stata.GetDataById(sc.Cliente.StatoRilascioDoc.Id);
                sc.Cliente.StatoRilascioDoc.Nome = stadt[0].Nome;
                stadt = stata.GetDataById(sc.Cliente.StatoCittadinanza.Id);
                sc.Cliente.StatoCittadinanza.Nome = stadt[0].Nome;
                tdocdt = tdocta.GetDataById(sc.Cliente.TipoDoc.Id);
                sc.Cliente.TipoDoc.Descrizione = tdocdt[0].Descrizione;
                sclist.Add(sc);

            }
            reader.Close();
            conn.Close();
            return sclist;
        }

        internal Cliente cercaClienteNomeCognome(int idcliente)
        {
            var cta = new ClienteTableAdapter();
            var cdt = cta.GetNomeCognomeById(idcliente);
            var c = new Cliente
            {
                Id = idcliente,
                Cognome = cdt[0].Cognome,
                Nome = cdt[0].Nome
            };
            return c;
        }

        internal void inserisciSchedineSoggiorno(int idsoggiorno, List<SchedaNotifica> schedine)
        {

            var schta = new SchedaNotificaTableAdapter();
            schta.DeleteBySoggiorno(idsoggiorno);
            foreach (var sch in schedine)
                schta.Insert(sch.Numero, (short)sch.Anno, idsoggiorno, sch.Cliente.Id);
        }

        internal void eliminaSchedeBySoggiorno(int idsoggiorno)
        {
            var schta = new SchedaNotificaTableAdapter();
            schta.DeleteBySoggiorno(idsoggiorno);
        }

        internal void inserisciCliente(Cliente c)
        {
            var cta = new ClienteTableAdapter();
            cta.Insert(c.Nome, c.Cognome, c.IsFemmina, c.Indirizzo,
                c.ComuneResidenza == null ? null : (int?)c.ComuneResidenza.Id,
                c.StatoResidenza == null ? null : (int?)c.StatoResidenza.Id,
                c.Telefoni, c.Descr, c.Email, c.DataNascita == DateTime.MinValue ? null : (DateTime?)c.DataNascita,
                c.ComuneNascita == null ? null : (int?)c.ComuneNascita.Id,
                c.StatoNascita == null ? null : (int?)c.StatoNascita.Id,
                c.StatoCittadinanza == null ? null : (int?)c.StatoCittadinanza.Id,
                c.TipoDoc == null ? null : (int?)c.TipoDoc.Id,
                c.NumDoc, c.DataRilascioDoc == DateTime.MinValue ? null : (DateTime?)c.DataRilascioDoc,
                c.ComuneRilascioDoc == null ? null : (int?)c.ComuneRilascioDoc.Id,
                c.StatoRilascioDoc == null ? null : (int?)c.StatoRilascioDoc.Id,
                c.ProvenIstat == null ? null : (int?)c.ProvenIstat.Id);

        }

        internal bool hasSchedine(int idcliente)
        {
            var schta = new SchedaNotificaTableAdapter();
            var schdt = schta.GetDataByCliente(idcliente);
            return (schdt.Count > 0);
        }

        internal List<Soggiorno> cercaSoggiorniNonCheckedIn(DateTime arriviDa, DateTime arriviA)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QuerySoggiorniNotCheckedIn";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("DataDa", OleDbType.Date).Value = arriviDa;
            cmd.Parameters.Add("DataA", OleDbType.Date).Value = arriviA;
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            var slist = new List<Soggiorno>();
            Soggiorno sog;
            while (reader.Read())
            {
                //Soggiorno.ID, Soggiorno.Arrivo, Cliente.Cognome, Camera.Numero, Soggiorno.IsCheckedIn
                sog = new Soggiorno
                {
                    Id = int.Parse(reader[0].ToString()),
                    Arrivo = DateTime.Parse(reader[1].ToString()),
                    Cliente = new Cliente { Cognome = reader[2].ToString() },
                    Camera = new Camera { Numero = int.Parse(reader[3].ToString()) },
                    IsCheckedIn = false
                };
                slist.Add(sog);
            }
            reader.Close();
            conn.Close();
            return slist;
        }

        internal List<Soggiorno> cercaSoggiorniNonCheckedInForIstat(DateTime arriviDa, DateTime arriviA)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QuerySoggiorniNotCheckedInForIstat";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("DataDa", OleDbType.Date).Value = arriviDa;
            cmd.Parameters.Add("DataA", OleDbType.Date).Value = arriviA;
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            var slist = new List<Soggiorno>();
            Soggiorno sog;
            while (reader.Read())
            {
                //Soggiorno.ID, Soggiorno.Arrivo, Soggiorno.Arrivo, Cliente.Cognome, Camera.Numero, Soggiorno.IsCheckedIn
                sog = new Soggiorno
                {
                    Id = int.Parse(reader[0].ToString()),
                    Arrivo = DateTime.Parse(reader[1].ToString()),
                    Partenza = DateTime.Parse(reader[2].ToString()),
                    Cliente = new Cliente { Cognome = reader[3].ToString() },
                    Camera = new Camera { Numero = int.Parse(reader[4].ToString()) },
                    IsCheckedIn = false
                };
                slist.Add(sog);
            }
            reader.Close();
            conn.Close();
            return slist;
        }

        internal List<SchedaNotifica> cercaSchedeNotificaBetween(DateTime arrivoDa, DateTime arrivoA)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QuerySchedeByArrivo";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("ArrivoDa", OleDbType.Date).Value = arrivoDa;
            cmd.Parameters.Add("ArrivoA", OleDbType.Date).Value = arrivoA;
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            var sclist = new List<SchedaNotifica>();
            SchedaNotifica sc;

            var comta = new ComuneTableAdapter();
            SoggiorniDbDataSet.ComuneDataTable comdt;

            var stata = new StatoTableAdapter();
            SoggiorniDbDataSet.StatoDataTable stadt;

            var tdocta = new TipoDocumentoTableAdapter();
            SoggiorniDbDataSet.TipoDocumentoDataTable tdocdt;

            while (reader.Read())
            {
                /*
                 * Soggiorno.Arrivo, Cliente.Cognome, Cliente.Nome, Cliente.IsFemmina, Cliente.DataNascita, 
                 * Cliente.ComuneNascita, Cliente.StatoNascita, Cliente.StatoCittadinanza, Cliente.ComuneResid, 
                 * Cliente.StatoResid, Cliente.Indirizzo, Cliente.TipoDocumento, Cliente.NumDocumento, 
                 * Cliente.ComuneRilascioDoc, Cliente.StatoRilascioDoc, Cliente.DataRilascioDoc
                 */
                sc = new SchedaNotifica
                {
                    Soggiorno = new Soggiorno{Arrivo = DateTime.Parse(reader[0].ToString())},
                    Cliente = new Cliente
                    {
                        Cognome = reader[1].ToString(),
                        Nome = reader[2].ToString(),
                        IsFemmina = bool.Parse(reader[3].ToString()),
                        DataNascita = DateTime.Parse(reader[4].ToString()),
                        ComuneNascita = new Comune { Id = int.Parse(reader[5].ToString()) },
                        StatoNascita = new Stato { Id = int.Parse(reader[6].ToString()) },
                        StatoCittadinanza = new Stato { Id = int.Parse(reader[7].ToString()) },
                        ComuneResidenza = new Comune { Id = int.Parse(reader[8].ToString()) },
                        StatoResidenza = new Stato { Id = int.Parse(reader[9].ToString()) },
                        Indirizzo = reader[10].ToString(),
                        TipoDoc = new TipoDocumento { Id = int.Parse(reader[11].ToString()) },
                        NumDoc = reader[12].ToString(),
                        ComuneRilascioDoc = new Comune { Id = int.Parse(reader[13].ToString()) },
                        StatoRilascioDoc = new Stato { Id = int.Parse(reader[14].ToString()) },
                        DataRilascioDoc = DateTime.Parse(reader[15].ToString())
                    }
                };

                //raccolgo dati comuni, stati e tipo doc
                comdt = comta.GetDataById(sc.Cliente.ComuneNascita.Id);
                sc.Cliente.ComuneNascita.CodicePolizia = comdt[0].CodicePolizia;
                sc.Cliente.ComuneNascita.Provincia = comdt[0].Provincia;
                comdt = comta.GetDataById(sc.Cliente.ComuneResidenza.Id);
                sc.Cliente.ComuneResidenza.CodicePolizia = comdt[0].CodicePolizia;
                sc.Cliente.ComuneResidenza.Provincia = comdt[0].Provincia;
                comdt = comta.GetDataById(sc.Cliente.ComuneRilascioDoc.Id);
                sc.Cliente.ComuneRilascioDoc.CodicePolizia = comdt[0].CodicePolizia;
                stadt = stata.GetDataById(sc.Cliente.StatoNascita.Id);
                sc.Cliente.StatoNascita.CodicePolizia = stadt[0].CodicePolizia;
                sc.Cliente.StatoNascita.Nome = stadt[0].Nome;
                stadt = stata.GetDataById(sc.Cliente.StatoResidenza.Id);
                sc.Cliente.StatoResidenza.CodicePolizia = stadt[0].CodicePolizia;
                sc.Cliente.StatoResidenza.Nome = stadt[0].Nome;
                stadt = stata.GetDataById(sc.Cliente.StatoRilascioDoc.Id);
                sc.Cliente.StatoRilascioDoc.Nome = stadt[0].Nome;
                sc.Cliente.StatoRilascioDoc.CodicePolizia = stadt[0].CodicePolizia;
                stadt = stata.GetDataById(sc.Cliente.StatoCittadinanza.Id);
                sc.Cliente.StatoCittadinanza.CodicePolizia = stadt[0].CodicePolizia;
                tdocdt = tdocta.GetDataById(sc.Cliente.TipoDoc.Id);
                sc.Cliente.TipoDoc.CodicePolizia = tdocdt[0].CodicePolizia;
                sclist.Add(sc);

            }
            reader.Close();
            conn.Close();
            return sclist;
        }

        internal List<SchedaNotifica> cercaSchedeNotificaPerIstat(DateTime arrivoDa, DateTime arrivoA)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QuerySchedeByPeriodoIstat";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("DataDa", OleDbType.Date).Value = arrivoDa;
            cmd.Parameters.Add("DataA", OleDbType.Date).Value = arrivoA;
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            var sclist = new List<SchedaNotifica>();
            SchedaNotifica sc;

            var provta = new ProvenienzaIstatTableAdapter();
            SoggiorniDbDataSet.ProvenienzaIstatDataTable provdt;

            while (reader.Read())
            {
                /*
                 * Soggiorno.Arrivo, Soggiorno.Partenza, Cliente.ProvenienzaIstat
                 */
                sc = new SchedaNotifica
                {
                    Soggiorno = new Soggiorno { 
                        Arrivo = DateTime.Parse(reader[0].ToString()),
                        Partenza = DateTime.Parse(reader[1].ToString())
                    },
                    Cliente = new Cliente{ 
                        ProvenIstat = new ProvenienzaIstat{ Id = int.Parse(reader[2].ToString())}
                    }
                };

                //raccolgo dati su provenienza istat
                provdt = provta.GetDataById(sc.Cliente.ProvenIstat.Id);
                sc.Cliente.ProvenIstat.Sigla = provdt[0].SiglaTuriweb;
                sc.Cliente.ProvenIstat.Regione = provdt[0].Regione;
                sc.Cliente.ProvenIstat.Stato = provdt[0].Stato;
                sclist.Add(sc);

            }
            reader.Close();
            conn.Close();
            return sclist;
        }

        internal int getMaxNumSchedina(int anno)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QueryMaxSchedaByAnno";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("InizioAnno", OleDbType.Integer).Value = anno;
            conn.Open();
            var max = cmd.ExecuteScalar();
            conn.Close();

            if (max == DBNull.Value) return 0;
            return (int)max;
        }
        
        internal int getMaxNumPagamento(bool isFattura, DateTime datePag)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QueryMaxNumPagamentoByAnno";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("IsFattura", OleDbType.Boolean).Value = isFattura;
            cmd.Parameters.Add("InizioAnno", OleDbType.Date).Value = new DateTime(datePag.Year, 1, 1);
            cmd.Parameters.Add("FineAnno", OleDbType.Date).Value = new DateTime(datePag.Year, 12, 31);
            conn.Open();
            //cosa ritorna se non ci sono risultati
            var max = cmd.ExecuteScalar();
            conn.Close();

            if (max == DBNull.Value) return 0;
            return (int)max;
        }

        internal Pagamento cercaPagamentoById(int id)
        {
            var pagta = new PagamentoTableAdapter();
            var pagdt = pagta.GetDataById(id);
            var p = new Pagamento
            {
                Id = pagdt[0].ID,
                Data = pagdt[0].Data,
                IsFattura = pagdt[0].IsFattura,
                Numero = pagdt[0].Numero,
                Totale = pagdt[0].Totale,
                Imponibile = pagdt[0].IsImponibileNull() ? 0 : pagdt[0].Imponibile,
                ModoPagamento = pagdt[0].ModoPagamento,
                Destinatario = pagdt[0].Destinatario,
                Piva = pagdt[0].Piva,
                Cf = pagdt[0].CF,
                Sede = pagdt[0].Sede
            };
            return p;
        }

        internal int inserisciPagamento(Pagamento pag)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            OleDbCommand cmd;
            string queryString;

            conn.Open();

            queryString = "INSERT INTO Pagamento (IsFattura, Numero, Data, Totale, ModoPagamento, Destinatario, Sede, Piva, CF) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
            cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("IsFattura", OleDbType.Boolean).Value = pag.IsFattura;
            cmd.Parameters.Add("Numero", OleDbType.Integer).Value = pag.Numero;
            cmd.Parameters.Add("Data", OleDbType.Date).Value = pag.Data;
            cmd.Parameters.Add("Totale", OleDbType.Decimal).Value = pag.Totale;
            cmd.Parameters.Add("ModoPagamento", OleDbType.Char, 255).Value = pag.ModoPagamento;
            cmd.Parameters.Add("Destinatario", OleDbType.Char, 255).Value = pag.Destinatario;
            cmd.Parameters.Add("Sede", OleDbType.Char, 255).Value = pag.Sede;
            cmd.Parameters.Add("Piva", OleDbType.Char, 11).Value = pag.Piva;
            cmd.Parameters.Add("CF", OleDbType.Char, 16).Value = pag.Cf;

            cmd.ExecuteNonQuery();

            //eseguo la query per ottenere l'id appena inserito
            cmd = new OleDbCommand("SELECT @@IDENTITY", conn);
            int id = (int)cmd.ExecuteScalar();
            conn.Close();
            return id;
        }

        internal void aggiornaPagamento(Pagamento pag)
        {
            var pagta = new PagamentoTableAdapter();
            pagta.UpdateById(pag.IsFattura, pag.Numero, pag.Data, pag.Totale, pag.Imponibile, pag.ModoPagamento,
                pag.Destinatario, pag.Sede, pag.Piva, pag.Cf, pag.Id);
        }

        internal List<Pagamento> cercaPagamentiByData(bool isfattura, DateTime from, DateTime to)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QueryPagamentiByDataTipo";

            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("IsFattura", OleDbType.Boolean).Value = isfattura;
            cmd.Parameters.Add("DataDa", OleDbType.Date).Value = from;
            cmd.Parameters.Add("DataA", OleDbType.Date).Value = to;

            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            var plist = new List<Pagamento>();
            while (reader.Read())
            {

                //ID, IsFattura, Data, Numero, Destinatario, Totale, ModoPagamento, Sede, Piva, CF
                var p = new Pagamento();
                p.Id = int.Parse(reader[0].ToString());
                p.IsFattura = bool.Parse(reader[1].ToString());
                p.Data = reader[2].ToString()=="" ? DateTime.MinValue : DateTime.Parse(reader[2].ToString());
                p.Numero = int.Parse(reader[3].ToString());
                p.Destinatario = reader[4].ToString();
                p.Totale = reader[5].ToString()=="" ? 0 : decimal.Parse(reader[5].ToString());
                p.ModoPagamento= reader[6].ToString();
                p.Sede = reader[7].ToString();
                p.Piva = reader[8].ToString();
                p.Cf = reader[9].ToString();
                plist.Add(p);
            }
            reader.Close();
            conn.Close();
            return plist;
            
        }

        internal List<Pagamento> cercaPagamentiByData(DateTime from, DateTime to)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QueryPagamentiByData";

            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("DataDa", OleDbType.Date).Value = from;
            cmd.Parameters.Add("DataA", OleDbType.Date).Value = to;

            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            var plist = new List<Pagamento>();
            while (reader.Read())
            {

                //ID, IsFattura, Data, Numero, Destinatario, Totale, ModoPagamento, Sede, Piva, CF
                var p = new Pagamento();
                p.Id = int.Parse(reader[0].ToString());
                p.IsFattura = bool.Parse(reader[1].ToString());
                p.Data = reader[2].ToString() == "" ? DateTime.MinValue : DateTime.Parse(reader[2].ToString());
                p.Numero = int.Parse(reader[3].ToString());
                p.Destinatario = reader[4].ToString();
                p.Totale = reader[5].ToString() == "" ? 0 : decimal.Parse(reader[5].ToString());
                p.ModoPagamento = reader[6].ToString();
                p.Sede = reader[7].ToString();
                p.Piva = reader[8].ToString();
                p.Cf = reader[9].ToString();
                plist.Add(p);
            }
            reader.Close();
            conn.Close();
            return plist;
        }

        internal List<AltraAttivita> cercaAttivitaByPagamento(int idpag)
        {
            var atta = new AltreAttivitaTableAdapter();
            var atdt = atta.GetDataByPagamento(idpag);
            var alist = new List<AltraAttivita>();
            AltraAttivita aa;
            foreach (var att in atdt)
            {
                aa = new AltraAttivita
                {
                    Id = att.ID,
                    Data = att.Data,
                    VoceInStampata = att.NomeInFattura,
                    Descrizione = att.Descrizione,
                    Totale = att.IsTotaleIvatoNull() ? 0 : att.TotaleIvato,
                    PagamentoId = idpag
                };
                alist.Add(aa);
            }
            return alist;
        }

        internal List<Soggiorno> cercaSoggiorniByPagamento(int idpag)
        {
            var sogta = new SoggiornoTableAdapter();
            var sogdt = sogta.GetDataByPagamento(idpag);

            var clita = new ClienteTableAdapter();
            var camta = new CameraTableAdapter();
            var slist = new List<Soggiorno>();
            Soggiorno sog;
            foreach (var s in sogdt)
            {
                sog = new Soggiorno
                {
                    Id = s.ID,
                    Arrivo = s.Arrivo,
                    Partenza = s.Partenza,
                    TotaleSoggiorno = s.IsTotaleSoggiornoNull() ? 0 : s.TotaleSoggiorno,
                    TotalePernotto = s.IsTotaleCameraNull() ? 0 : s.TotaleCamera
                };
                var clidt = clita.GetDataById(s.ClienteId);
                sog.Cliente = new Cliente
                {
                    Id = clidt[0].ID,
                    Cognome = clidt[0].Cognome
                };
                var camdt = camta.GetDataById(s.CameraId);
                sog.Camera = new Camera
                {
                    Id = camdt[0].ID,
                    Numero = camdt[0].Numero
                };
                slist.Add(sog);
            }
            return slist;
        }

        internal void inserisciAttivitaPagamento(List<AltraAttivita> alist, int idpag)
        {
            var atta = new AltreAttivitaTableAdapter();

            foreach (var aa in alist)
                atta.Insert(aa.Data, aa.VoceInStampata, aa.Totale, (aa.Totale - aa.Totale / 10), aa.Descrizione, idpag);
        }

        internal void aggiornaStatoSoggiorniNuovoPagamento(List<Soggiorno> slist, int idNuovoPag)
        {
            var sogta = new SoggiornoTableAdapter();

            foreach (var s in slist)
                sogta.UpdateStatoPagamentoById(true, idNuovoPag, s.Id);
        }

        internal void eliminaAttivitaByPagamento(int idpag)
        {
            var atta = new AltreAttivitaTableAdapter();
            atta.DeleteByPagamento(idpag);
        }

        internal void aggiornaStatoSoggiorniPagamentoEsistente(List<Soggiorno> slist, int idpag)
        {
            var sogta = new SoggiornoTableAdapter();

            //cerca tutti i soggiorni con questo idpagamento e 1) leva il checkout, 2) azzera idpagamento
            var sogdt = sogta.GetDataByPagamento(idpag);
            foreach (var sogdr in sogdt)
                sogta.UpdateStatoPagamentoById(false, 0, sogdr.ID);

            //aggiorna stato di checkout dei soggiorni passati
            foreach (var s in slist)
                sogta.UpdateStatoPagamentoById(true, idpag, s.Id);
        }

        internal List<Soggiorno> cercaSoggiorniNonCheckedOut(DateTime from, DateTime to)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QuerySoggiorniNotCheckedOut";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("DataDa", OleDbType.Date).Value = from;
            cmd.Parameters.Add("DataA", OleDbType.Date).Value = to;
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            var slist = new List<Soggiorno>();
            Soggiorno sog;
            while (reader.Read())
            {
                //Soggiorno.ID, Soggiorno.Arrivo, Cliente.Cognome, Camera.Numero, Soggiorno.TotaleSoggiorno
                sog = new Soggiorno
                {
                    Id = int.Parse(reader[0].ToString()),
                    Arrivo = DateTime.Parse(reader[1].ToString()),
                    Cliente = new Cliente { Cognome = reader[2].ToString() },
                    Camera = new Camera { Numero = int.Parse(reader[3].ToString()) },
                    TotaleSoggiorno = reader[4].ToString()=="" ? 0 : decimal.Parse(reader[4].ToString())
                };
                slist.Add(sog);
            }
            reader.Close();
            conn.Close();
            return slist;
        }

        internal void eliminaPagamento(int idpag)
        {
            //cerca tutti i soggiorni con questo idpagamento e 1) leva il checkout, 2) azzera idpagamento
            var sogta = new SoggiornoTableAdapter();
            var sogdt = sogta.GetDataByPagamento(idpag);
            foreach (var sogdr in sogdt)
                sogta.UpdateStatoPagamentoById(false, 0, sogdr.ID);

            //elimino eventuali attivita correlate
            var aata = new AltreAttivitaTableAdapter();
            aata.DeleteByPagamento(idpag);

            //elimino pagamento
            var pagta = new PagamentoTableAdapter();
            pagta.DeleteById(idpag);
        }

        internal List<Soggiorno> cercaSoggiorniTableau(DateTime inizio, DateTime fine)
        {
            OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.SoggiorniDbConnectionString);
            string queryString = "SELECT * FROM QuerySoggiorniTableau";
            OleDbCommand cmd = new OleDbCommand(queryString, conn);
            cmd.Parameters.Add("Inizio", OleDbType.Date).Value = inizio;
            cmd.Parameters.Add("Fine", OleDbType.Date).Value = fine;
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            var list = new List<Soggiorno>();
            while (reader.Read())
            {
                var sog = new Soggiorno();
                sog.Id = int.Parse(reader[0].ToString());
                sog.Arrivo = DateTime.Parse(reader[1].ToString());
                sog.Partenza = DateTime.Parse(reader[2].ToString());
                sog.Confermato = bool.Parse(reader[3].ToString());
                sog.Cliente = new Cliente { Cognome = reader[4].ToString() };
                sog.Camera = new Camera
                {
                    Numero = int.Parse(reader[5].ToString()),
                    Agriturismo = reader[6].ToString()
                };
                sog.ColoreGruppoArgb = (reader[7].ToString() == "") ? 0 : int.Parse(reader[7].ToString());
                list.Add(sog);
            }
            reader.Close();
            conn.Close();
            return list;
        }

        internal int getPagamentoElements(int pagId)
        {
            var sta = new SoggiornoTableAdapter();
            int numSog = (int)sta.QueryNumSoggiorniByPagamento(pagId);
            var aata = new AltreAttivitaTableAdapter();
            int numAtt = (int)aata.QueryAttivitaByPagamento(pagId);

            return numSog + numAtt;
        }
    }
}
