using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class InvestimentoDespesa
    {
        public int InvestimentoDespesaID { get; set; }
        public int InvestimentoID { get; set; }
        public int? CategoriaID { get; set; }
        public string Descricao { get; set; }
        public bool Entrada { get; set; }
        public bool Saida { get; set; }
        public int? Ordem { get; set; }
        public int? ImpostoID { get; set; }
        public bool IR { get; set; }
        public bool IOF { get; set; }
        public bool ComeCota { get; set; }
    }
}
