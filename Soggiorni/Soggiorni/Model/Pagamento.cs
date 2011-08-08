using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soggiorni.Model
{
    public class Pagamento
    {
        public int Id { get; set; }
        public bool IsFattura { get; set; }
        public int Numero { get; set; }
        public DateTime Data { get; set; }
        public decimal Totale { get; set; }
        public decimal Imponibile { get; set; }
        public int NumPernotti { get; set; }
        public decimal TotalePernotti { get; set; }
        public decimal TotaleServizi { get; set; }
        public string ModoPagamento { get; set; }
        public string Destinatario { get; set; }
        public string Sede { get; set; }
        public string Piva { get; set; }
        public string Cf { get; set; }

        private List<VocePagamento> _dettaglio;
        
        public void addVocePagamento(VocePagamento vp){
            if (vp == null) return;

            if (_dettaglio == null)
                _dettaglio = new List<VocePagamento>();
            _dettaglio.Add(vp);
        }

        public int NumSoggiorni {
            get
            {
                if (_soggiorni == null)
                    return 0;
                return _soggiorni.Count;
            }
        }

        private List<Soggiorno> _soggiorni;

        public void addSoggiorno(Soggiorno sg)
        {
            if (sg == null)
                return;

            if (_soggiorni == null)
                _soggiorni = new List<Soggiorno>();

            _soggiorni.Add(sg);
        }

        public void RemoveSoggiornoAt(int index)
        {
            if (_soggiorni == null)
                return;

            if (index >= _soggiorni.Count || index < 0)
                return;
            _soggiorni.RemoveAt(index);
        }

    }
}
