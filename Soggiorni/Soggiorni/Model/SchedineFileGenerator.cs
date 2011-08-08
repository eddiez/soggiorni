using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soggiorni.Model
{
    public class SchedineFileGenerator
    {
        private List<SchedaNotifica> schede;

        private const string CODICE_TIPO_ALLOGGIATO = "16"; //ospite singolo: noi registriamo solo questo tipo
        private const string NOME_ITALIA = "ITALIA";

        public SchedineFileGenerator(List<SchedaNotifica> scl)
        {
            this.schede = scl;
        }

        public string getFileText()
        {
            if (schede == null || schede.Count == 0)
                return "";
            
            StringBuilder sbtext = new StringBuilder("");

            foreach (var sn in schede)
            {
                sbtext.Append(getSchedaEnconded(sn));
                sbtext.Append("\r\n");
            }
            //elimino i caratteri fine linea dalla coda del testo
            sbtext.Remove(sbtext.Length - 2, 2);
            
            return sbtext.ToString();
        }

        private string createFixedLengthStringWithContent(string content, int len)
        {
            if (content.Length > len)
                return content.Substring(0, len);
            StringBuilder sb = new StringBuilder(content);
            int numOfSpacesToAdd = len - content.Length;
            for (int i = 0; i < numOfSpacesToAdd; i++)
                sb.Append(" ");
            return sb.ToString();
        }

        private string getSchedaEnconded(SchedaNotifica sn)
        {
            
            StringBuilder sb = new StringBuilder(CODICE_TIPO_ALLOGGIATO);
            //data arrivo
            sb.Append(sn.Soggiorno.Arrivo.ToString("dd/MM/yyyy"));
            //cognome
            sb.Append(
                createFixedLengthStringWithContent(
                    replaceSpecialCharacters(sn.Cliente.Cognome), 50));
            //nome
            sb.Append(
                createFixedLengthStringWithContent(
                    replaceSpecialCharacters(sn.Cliente.Nome), 30));
            //sesso
            if (sn.Cliente.IsFemmina) sb.Append("2");
            else sb.Append("1");
            //data nascita
            sb.Append(sn.Cliente.DataNascita.ToString("dd/MM/yyyy"));

            if(sn.Cliente.StatoNascita.Nome==NOME_ITALIA)
            {
                //comune nascita
                sb.Append(sn.Cliente.ComuneNascita.CodicePolizia.Trim());
                //provincia nascita
                sb.Append(sn.Cliente.ComuneNascita.Provincia);
            }
            else //nato all'estero
            {
                //comune nascita
                sb.Append(createFixedLengthStringWithContent("",9));
                //provincia nascita
                sb.Append("  ");
            }
            
            //stato nascita
            sb.Append(sn.Cliente.StatoNascita.CodicePolizia.Trim());
            //cittadinanza
            sb.Append(sn.Cliente.StatoCittadinanza.CodicePolizia.Trim());

            if (sn.Cliente.StatoResidenza.Nome == NOME_ITALIA)
            {
                //comune res
                sb.Append(sn.Cliente.ComuneResidenza.CodicePolizia.Trim());
                //provincia res
                sb.Append(sn.Cliente.ComuneResidenza.Provincia);
            }
            else //residente all'estero
            {
                //comune res
                sb.Append(createFixedLengthStringWithContent("", 9));
                //provincia res
                sb.Append("  ");
            }
            //stato res
            sb.Append(sn.Cliente.StatoResidenza.CodicePolizia.Trim());
            
            //indirizzo
            sb.Append(
                createFixedLengthStringWithContent(
                    replaceSpecialCharacters(sn.Cliente.Indirizzo), 50));

            //tipo doc
            sb.Append(sn.Cliente.TipoDoc.CodicePolizia.Trim());
            //num doc
            sb.Append(createFixedLengthStringWithContent(sn.Cliente.NumDoc, 20));
            //luogo rilascio doc
            if (sn.Cliente.StatoRilascioDoc.Nome == NOME_ITALIA)
                sb.Append(sn.Cliente.ComuneRilascioDoc.CodicePolizia.Trim());
            else sb.Append(sn.Cliente.StatoRilascioDoc.CodicePolizia.Trim());

            return sb.ToString();
            
        }

        private string replaceSpecialCharacters(string text){
            StringBuilder sb = new StringBuilder();
            foreach (char c in text){
                switch (c)
                {
                    case 'à': sb.Append("a'"); break;
                    case 'è': sb.Append("e'"); break;
                    case 'é': sb.Append("e'"); break;
                    case 'ù': sb.Append("u'"); break;
                    case 'ì': sb.Append("i'"); break;
                    case 'ò': sb.Append("o'"); break;
                    default: sb.Append(c); break;
                }
            }
            return sb.ToString();
        }
    }
}
