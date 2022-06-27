using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Transacao
    {
        public int TransacaoID { get; set; }
        public int Tipo { get; set; }
        public string Apelido { get; set; }
        public string Descricao { get; set; }
        public string CrdDeb { get; set; }
        public int? CategoriaID { get; set; }
        public bool Fundo { get; set; }
        public bool Acao { get; set; }
    
    }
}
