using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soggiorni.Model
{
    public class CorrispettivoGiorno
    {
        public DateTime Giorno { get; set; }
        public decimal TotaleFatture { get; set; }
        public decimal TotaleRicevute { get; set; }
        public int FatturaFrom { get; set; }
        public int FatturaTo { get; set; }
        public int RicevutaFrom { get; set; }
        public int RicevutaTo { get; set; }
        public decimal Totale
        {
            get { return this.TotaleFatture + this.TotaleRicevute; }
        }
    }
}
