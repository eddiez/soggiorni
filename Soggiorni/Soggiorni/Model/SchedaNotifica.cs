using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soggiorni.Model
{
    public class SchedaNotifica
    {
        public int Numero { get; set; }
        public int Anno { get; set; }
        public int SoggiornoId { get; set; }
        public Cliente Cliente { get; set; }
        public Soggiorno Soggiorno { get; set; }
    }
}
