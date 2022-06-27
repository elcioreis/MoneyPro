using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class TipoInvestimento
    {
        public int TipoInvestimentoID { get; set; }
        public int UsuarioID { get; set; }
        public string Apelido { get; set; }
        public string Descricao { get; set; }
        public bool? Fundo { get; set; }
        public bool? Acao { get; set; }
        public bool? ComeCota { get; set; }
        public bool Ativo { get; set; }

    }
}
