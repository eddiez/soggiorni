using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soggiorni
{
    public class SchedinaReportItem
    {
        public string DataArrivo { get; set; }
        public string CognomeNome { get; set; }
        public string LuogoResidenza { get; set; }
        public string DataNascita { get; set; }
        public string LuogoNascita { get; set; }
        public string StatoCittadinanza { get; set; }
        public string TipoDoc { get; set; }
        public string NumDoc { get; set; }
        public string DataRilascioDoc { get; set; }
        public string LuogoRilascioDoc { get; set; }
        public int Progressivo { get; set; }
        public int Anno { get; set; }
    }
}
