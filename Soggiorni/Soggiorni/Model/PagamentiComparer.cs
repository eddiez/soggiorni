using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soggiorni.Model
{
    public class PagamentiComparer : IEqualityComparer<Pagamento>
    {
        public bool Equals(Pagamento first, Pagamento second)
        {
            return ((first.Data.Year == second.Data.Year) && (first.Numero == second.Numero) && (first.IsFattura == second.IsFattura));
        }

        public int GetHashCode(Pagamento p)
        {
            return (p.Data.Year * 100) + (p.Numero * 10) + (p.IsFattura ? 1 : 0);
        }
    }
}
