using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Soggiorni.Model
{
    public class PresenzeFileGenerator
    {
        private List<SchedaNotifica> schede;
        private int month;
        private int year;
        private const string IDISTAT_STRUTTURA_FABBRE = "053014AAT0096";
        private Dictionary<PresenzeKey, PresenzeGiorno> presenze;
        private string nomeStatoItalia = "ITALIA";

        public PresenzeFileGenerator(int m, int y, List<SchedaNotifica> list)
        {
            this.schede = list;
            this.month = m;
            this.year = y;
        }

        public PresenzeFileGenerator(List<SchedaNotifica> list)
        {
            this.schede = list;
        }

        public string getXmlFileText()
        {
            if (schede == null || schede.Count == 0)
                return "";

            //creo elemento radice
            XNamespace rootns = "http://www.w4b.it/turiweb";
            XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
            XElement root = new XElement(rootns + "messaggio-turiweb",
                new XAttribute(XNamespace.Xmlns+"xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                new XAttribute(xsi+"schemaLocation", "http://www.w4b.it/turiweb http://www.w4b.it/turiweb/turiweb.xsd")
            );
            XElement report = new XElement(rootns+"report", new XAttribute("id-struttura", IDISTAT_STRUTTURA_FABBRE));
            root.Add(report);
            XElement riepilogomensile = new XElement(rootns+"riepilogo-mensile", 
                                            new XAttribute("anno", this.year),
                                            new XAttribute("mese", this.month));
            report.Add(riepilogomensile);
            
            XElement riga;
            //creo una riga per ogni giorno di presenze del periodo
            DateTime dataDa = new DateTime(year, month, 1);
            DateTime dataA = dataDa.AddMonths(1).AddDays(-1);
            calcolaPresenze(dataDa, dataA);
            //ordine la struttura dati presenze per giorno del mese
            foreach (var kv in presenze.OrderBy(kvp => kvp.Key.giorno))
            {
                riga = new XElement(rootns + "riga",
                    new XAttribute("provenienza", kv.Key.prov),
                    new XAttribute("giorno", kv.Key.giorno),
                    new XAttribute("arrivi", kv.Value.Arrivi),
                    new XAttribute("partenze", kv.Value.Partenze));
                riepilogomensile.Add(riga);
            }

            return root.ToString();
            
        }

        public string getTxtFileText(DateTime from, DateTime to){
            if (schede == null || schede.Count == 0)
                return "";

            calcolaPresenze(from, to);
            var sb = new StringBuilder("");
            foreach (var kv in presenze.OrderBy(kvp => kvp.Key.giorno))
            {
                sb.Append("Giorno: ");
                sb.Append(kv.Value.Giorno.ToShortDateString());
                sb.Append("\t\t");
                sb.Append("Provenienza: ");
                sb.Append(kv.Key.provName);
                sb.Append("\t\t");
                sb.Append("Arrivi = ");
                sb.Append(kv.Value.Arrivi.ToString());
                sb.Append("\t\t");
                sb.Append("Partenze = ");
                sb.Append(kv.Value.Partenze.ToString());
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        private void calcolaPresenze(DateTime dataDa, DateTime dataA)
        {
            presenze = new Dictionary<PresenzeKey,PresenzeGiorno>();

            
            PresenzeKey pkey;

            //per ogni scheda di notifica
            foreach (var sc in schede)
            {
                //inserisco record per data arrivo
                if (sc.Soggiorno.Arrivo >= dataDa && sc.Soggiorno.Arrivo <= dataA)
                {
                    pkey = new PresenzeKey(sc.Soggiorno.Arrivo.Day, sc.Cliente.ProvenIstat.Sigla);
                    pkey.provName = sc.Cliente.ProvenIstat.Stato == nomeStatoItalia ?
                        sc.Cliente.ProvenIstat.Regione :
                        sc.Cliente.ProvenIstat.Stato;
                    if (!presenze.ContainsKey(pkey))
                        presenze.Add(pkey, new PresenzeGiorno());
                    presenze[pkey].Arrivi += 1;
                    presenze[pkey].Giorno = sc.Soggiorno.Arrivo;
                }
                //inserisco record per data partenza
                if (sc.Soggiorno.Partenza >= dataDa && sc.Soggiorno.Partenza <= dataA)
                {
                    pkey = new PresenzeKey(sc.Soggiorno.Partenza.Day, sc.Cliente.ProvenIstat.Sigla);
                    pkey.provName = sc.Cliente.ProvenIstat.Stato == nomeStatoItalia ?
                        sc.Cliente.ProvenIstat.Regione :
                        sc.Cliente.ProvenIstat.Stato;
                    if (!presenze.ContainsKey(pkey))
                        presenze.Add(pkey, new PresenzeGiorno());
                    presenze[pkey].Partenze += 1;
                    presenze[pkey].Giorno = sc.Soggiorno.Partenza;
                }
            }
        }
    }
}
