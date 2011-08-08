using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soggiorni.Model
{
    public class TableauPivot
    {
        public DateTime data { get; set; }
        public int Camera { get; set; }
        public string Cliente { get; set; }
        public bool Confermato { get; set; }
        public DateTime Arrivo { get; set; }
    }
}
