using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class SaldoFuturo
    {
        public int Ordem { get; set; }
        public int Nivel { get; set; }
        public int? ContaID { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public decimal SaldoAtual { get; set; }
        public decimal DebitosFuturos { get; set; }
        public decimal CreditosFuturos { get; set; }
        public decimal SaldoPrevisto { get; set; }
    }
}
