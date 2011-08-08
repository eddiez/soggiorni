using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soggiorni.Model
{
    public class Camera
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Nome { get; set; }
        public string Agriturismo { get; set; }
        public string FotoPath { get; set; }
        public string Tipo { get; set; }
        public string Bagno { get; set; }
    }
}
