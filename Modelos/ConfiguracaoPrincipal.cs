using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ConfiguracaoPrincipal
    {
        public short ConfiguracaoID { get; set; }
        public int PanelEsquerdoWidth { get; set; }
        public bool Contas_ExibeAtivas { get; set; }
        public bool Planejamento_ExibeAtivas { get; set; }
        public int DiasPrevisaoSaldoNegativo { get; set; }
        public bool NumeroEmContaBanco { get; set; }
    }
}
