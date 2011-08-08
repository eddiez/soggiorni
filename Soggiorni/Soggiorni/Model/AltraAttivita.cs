using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soggiorni.Model
{
    public class AltraAttivita
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string VoceInStampata { get; set; }
        public decimal Totale { get; set; }
        public decimal Imponibile { get; set; }
        public string Descrizione { get; set; }
        public int PagamentoId { get; set; }
    }
}
