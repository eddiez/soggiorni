using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soggiorni.Model
{
    struct PresenzeKey
    {
        public readonly int giorno;
        public readonly string prov;
        public string provName { get; set; }
        public PresenzeKey(int g, string p): this()
        {
            giorno = g;
            prov = p;
        }

        public override bool Equals(object obj)
        {
            var other = (PresenzeKey)obj;
            if ((this.giorno == other.giorno) && (this.prov == other.prov))
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return giorno+prov.GetHashCode();
        }
     }

    
}
