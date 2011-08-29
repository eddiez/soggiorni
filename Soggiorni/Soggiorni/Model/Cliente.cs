using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soggiorni.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public bool IsFemmina { get; set; }
        public string Indirizzo { get; set; }
        public Comune ComuneResidenza { get; set; }
        public Stato StatoResidenza { get; set; }
        public string Telefoni { get; set; }
        public string Descr { get; set; }
        public string Email { get; set; }
        public DateTime DataNascita { get; set; }
        public Comune ComuneNascita { get; set; }
        public Stato StatoNascita { get; set; }
        public Stato StatoCittadinanza { get; set; }
        public TipoDocumento TipoDoc { get; set; }
        public string NumDoc { get; set; }
        public DateTime DataRilascioDoc { get; set; }
        public Comune ComuneRilascioDoc { get; set; }
        public Stato StatoRilascioDoc { get; set; }
        public ProvenienzaIstat ProvenIstat { get; set; }

        public override string ToString()
        {
            return Cognome + " " + Nome;
        }
    }
}
