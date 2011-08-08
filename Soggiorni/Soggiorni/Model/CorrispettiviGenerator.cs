using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soggiorni.Model
{
    public class CorrispettiviGenerator
    {
        private List<Pagamento> pagamentiMese;

        public CorrispettiviGenerator(List<Pagamento> p)
        {
            this.pagamentiMese = p;
        }

        public List<CorrispettivoGiorno> getCorrispettivi()
        {
            if (pagamentiMese == null || pagamentiMese.Count == 0)
                return null;

            CorrispettivoGiorno cg;
            var cglist = new List<CorrispettivoGiorno>();

            var pagDict = new Dictionary<DateTime, CorrispettivoGiorno>();
            var gruppiPagamentiPerGiorno = from pag in pagamentiMese
                                           group pag by pag.Data into g
                                           orderby g.Key
                                           select g;
                
            //analizzo fatture per giorno
            foreach (var group in gruppiPagamentiPerGiorno)
            {
                cg = new CorrispettivoGiorno { Giorno = group.Key };
                int minFatt = int.MaxValue;
                int minRic = int.MaxValue;
                int maxFatt = -1;
                int maxRic = -1;
                
                foreach (var pag in group)
                {
                    if(pag.IsFattura){
                        cg.TotaleFatture += pag.Totale;
                        if (pag.Numero < minFatt) minFatt = pag.Numero;
                        if (pag.Numero > maxFatt) maxFatt = pag.Numero;
                    }
                    else{
                        cg.TotaleRicevute += pag.Totale;
                        if (pag.Numero < minRic) minRic = pag.Numero;
                        if (pag.Numero > maxRic) maxRic = pag.Numero;
                    }
                }
                //se ci sono fatture
                if(maxFatt!=-1){
                    cg.FatturaFrom = minFatt;
                    cg.FatturaTo = maxFatt;
                }

                //se ci sono ricevute
                if(maxRic!=-1){
                    cg.RicevutaFrom = minRic;
                    cg.RicevutaTo = maxRic;
                }
                cglist.Add(cg);
            }


            return cglist;
                
            
        }
    }
}
