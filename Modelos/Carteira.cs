using System;

namespace Modelos
{
    public class Carteira
    {
        public int UsuarioID { get; set; }
        public int InvestimentoID { get; set; }
        public string Apelido { get; set; }
        public string Consulta { get; set; }
        public string Conta { get; set; }
        public string Tipo { get; set; }
        public int? RiscoID { get; set; }
        public string Risco { get; set; }
        public decimal QtCotas { get; set; }
        public decimal VrCotacao { get; set; }
        public DateTime Data { get; set; }
        public string Simbolo { get; set; }
        public decimal VrAplicado { get; set; }
        public decimal PercCarteira { get; set; }
        public string QtCotasFmt { get; set; }
        public string VrCotacaoFmt { get; set; }
        public string VrAplicadoFmt { get; set; }
        public string PercFmt { get; set; }
        public int Detalhe { get; set; }
        public Boolean Fundo { get; set; }
        public Boolean Acao { get; set; }
    }
}
