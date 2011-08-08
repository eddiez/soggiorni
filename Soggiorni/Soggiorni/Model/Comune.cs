using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soggiorni.Model
{
    public class Comune
    {
        public int Id { get; set; }
        public string CodicePolizia { get; set; }
        public string Nome { get; set; }
        public string Provincia { get; set; }
        public DateTime DataCessazione { get; set; }
    }
}
