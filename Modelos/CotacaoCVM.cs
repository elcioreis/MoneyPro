using System;

namespace Modelos
{
    public class CotacaoCVM
    {
        public string TipoFundo { get; set; }
        public int CotacaoCVMID { get; set; }
        public string CNPJ { get; set; }
        public DateTime Data { get; set; }
        public decimal? VrTotalCarteira { get; set; }
        public decimal VrCotacao { get; set; }
        public decimal? VrPatrimonioLiquido { get; set; }
        public decimal? VrCaptacaoDia { get; set; }
        public decimal? VrResgateDia { get; set; }
        public int? NroCotistas { get; set; }
    }
}
