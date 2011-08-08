using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soggiorni.Model
{
    class TableauReportCellComparer : IEqualityComparer<TableauPivot>
    {
        public bool Equals(TableauPivot first, TableauPivot second)
        {
            return ((first.data == second.data) &&
                first.Camera == second.Camera);
        }

        public int GetHashCode(TableauPivot tp)
        {
            return tp.data.Second + tp.Camera;
        }
    }
}
