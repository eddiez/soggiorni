using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soggiorni.Model
{
    public class Soggiorno
    {
        //anno apertura agriturismo
        private int annoApertura = 2003;
        private decimal _prezzoAnotte;
        private List<ServizioSoggiorno> _servizi;


        public int Id { get; set; }
        public DateTime Arrivo { get; set; }
        public DateTime Partenza { get; set; }
        public Cliente Cliente { get; set; }
        public Camera Camera { get; set; }
        public string UsoCamera { get; set; }
        public decimal Caparra { get; set; }
        public string NoteCaparra { get; set; }
        public string NoteCamera { get; set; }
        public string NoteDurata { get; set; }
        public string NoteSaldoSoggiorno { get; set; }
        public string Prenotante { get; set; }
        public bool Confermato { get; set; }
        public decimal TotalePernotto { get; set; }
        public decimal TotaleServizi { get; set; }
        public decimal TotaleSoggiorno { get; set; }
        public bool IsCheckedIn { get; set; }
        public bool IsCheckedOut { get; set; }
        public int IdPagamento { get; set; }
        public int ColoreGruppoArgb { get; set; }

        public decimal PrezzoANotte {
            get {
                return this._prezzoAnotte;
            }
            set
            {
                this._prezzoAnotte = value;
                TotalePernotto = _prezzoAnotte * Notti;
            }
        }

        public decimal getTotaleServizi()
        {
            if (_servizi == null || _servizi.Count == 0)
            {
                return 0;
            }
            
            decimal tot = 0;
            foreach (ServizioSoggiorno ss in _servizi)
                tot += ss.Totale;

            return tot;
        }

        public int Notti
        {
            get
            {
                if(Arrivo.Year < annoApertura)
                    return 0;
                return Partenza.Subtract(Arrivo).Days;
            }
        }

        public List<ServizioSoggiorno> GetAllServizi()
        {
            if (_servizi == null || _servizi.Count == 0)
            {
                return null;
            }
            return _servizi;
        }

        public void ClearServizi()
        {
            _servizi = null;
        }

        public void AddServizio(ServizioSoggiorno s)
        {
            if (s == null)
                return;

            if (_servizi == null)
            {
                _servizi = new List<ServizioSoggiorno>();
            }
            _servizi.Add(s);
        }

        public void EditServizioAt(int index, ServizioSoggiorno s)
        {
            if (_servizi == null)
                return; 

            if (index >= _servizi.Count || index<0)
                return;

            _servizi[index] = s;
        }

        public void RemoveServizioAt(int index)
        {
            if (_servizi == null)
                return;

            if (index >= _servizi.Count || index < 0)
                return;
            _servizi.RemoveAt(index);
        }
    }
}
