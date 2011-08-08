using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soggiorni.Model
{
    public class SchedaNotificaComparer : IEqualityComparer<SchedaNotifica>
    {
        public bool Equals(SchedaNotifica first, SchedaNotifica second)
        {
            return ((first.SoggiornoId == second.SoggiornoId) && (first.Cliente.Id == second.Cliente.Id));
        }

        public int GetHashCode(SchedaNotifica sc)
        {
            return sc.SoggiornoId + sc.Cliente.Id;
        }
    }
}
