using System;

namespace Modelos
{
    public class CotacaoMoedas
    {
        private bool _carregou = false;
        public string Simbolo { get; set; }
        public bool Carregou { get { return _carregou; } set { _carregou = value; } }
        public int CotacaoMoedaID { get; set; }
        public DateTime Data { get; set; }
        public int DeMoedaId { get; set; }
        public decimal Cotacao { get; set; }
        public int ParaMoedaId { get; set; }
        public bool Negociado { get; set; }
        public decimal? Lowest { get; set; }
        public decimal? Volume { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AvgPrice { get; set; }
        public decimal? Opening { get; set; }
        public decimal? Closing { get; set; }
        public decimal? Highest { get; set; }
        public decimal? Quantity { get; set; }
        public int? MovimentoContaID { get; set; }
        public int? ContaIDTaxa { get; set; }
        public decimal? AliquotaTaxa { get; set; }
    }
}