using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class MovimentoInvestimentoDespesa
    {
        public int MovimentoInvestimentoDespesaID { get; set; }
        public int MovimentoInvestimentoID { get; set; }
        public string Parceiro { get; set; }
        public string Despesa { get; set; }
        public int CategoriaID { get; set; }
        public int Ordem { get; set; }
        public decimal Valor { get; set; }
    }
}
