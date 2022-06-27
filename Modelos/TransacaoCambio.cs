using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class TransacaoCambio
    {
        // O IdFake é um campo virtual criado por Row_Number() pra servir apenas para o combobox
        public int IdFake { get; set; }
        public int MoedaOrigemID { get; set; }
        public string SimboloOrigem { get; set; }
        public string Transacao { get; set; }
        public int MoedaDestinoID { get; set; }
        public string SimboloDestino { get; set; }
        public bool Compra { get; set; }
        public bool Venda { get; set; }
    }
}
