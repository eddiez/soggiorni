using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soggiorni.Model
{
    class AuguriClientiCsvFileGenerator
    { 
        private List<Cliente> clist;

        public AuguriClientiCsvFileGenerator(List<Cliente> cl)
        {
            //filtro quelli con dati incompleti
            this.clist = (from c
                          in cl
                          where ((c.Nome != "") &&
                                        (c.Cognome != "") &&
                                        (c.Email != "") &&
                                        (c.DataNascita != DateTime.MinValue))
                          select c).ToList<Cliente>();

        }

        private string ToTitleCase(string text)
        {
            text = text.ToLower();
            string rText = "";
            try
            {
                System.Globalization.CultureInfo cultureInfo =
    System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Globalization.TextInfo TextInfo = cultureInfo.TextInfo;
                rText = TextInfo.ToTitleCase(text);
            }
            catch
            {
                rText = text;
            }
            return rText;
        }

        public string getCsvText()
        {
            if (clist == null || clist.Count == 0)
                return "";

            StringBuilder sb = new StringBuilder(""); ;
            foreach (var cl in clist)
            {
                sb.Append(cl.Email);
                sb.Append(",");
                sb.Append(ToTitleCase(cl.Nome));
                sb.Append(",");
                sb.Append(ToTitleCase(cl.Cognome));
                sb.Append(",");
                //mettere data nel formato americano per MailChimp: escludere l'anno
                sb.Append(cl.DataNascita.ToString("MM/dd"));
                sb.Append("\r\n");
            }
            return sb.ToString();
        }
    }
}
