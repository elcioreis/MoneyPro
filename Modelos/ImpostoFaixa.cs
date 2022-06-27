using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ImpostoFaixa
    {
        public int FaixaID { get; set; }
        public int ImpostoID { get; set; }
        public string Apelido { get; set; }
        public int? Dias { get; set; }
        public decimal? Porcentagem { get; set; }
    }
}
