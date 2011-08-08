using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soggiorni.Model
{
    public class ServizioSoggiorno
    {
        public int IdServizio { get; set; }
        public string Nome { get; set; }
        public decimal Totale { get; set; }
        public string Note { get; set; }
        public decimal PrezzoListino { get; set; }
    }
}
