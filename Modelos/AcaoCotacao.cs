using System;

namespace Modelos
{
    public class AcaoCotacao
    {
        public int AcaoCotacaoID { get; set; }
        public int InvestimentoID { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Ibovespa { get; set; }
        public DateTime Data { get; set; }
        public decimal? Abertura { get; set; }
        public decimal? Minimo { get; set; }
        public decimal? Maximo { get; set; }
        public decimal? Medio { get; set; }
        public decimal? Ultimo { get; set; }
        public decimal? Oscilacao { get; set; }
    }
}
