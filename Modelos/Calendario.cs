using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Calendario
    {
        public int FeriadoID { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int? Ano { get; set; }
        public bool Fixo { get; set; } 
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
    }
}
