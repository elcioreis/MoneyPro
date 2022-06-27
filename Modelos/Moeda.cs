namespace Modelos
{
    public class Moeda
    {
        public int MoedaID { get; set; }
        public string Apelido { get; set; }
        public string Simbolo { get; set; }
        public bool Padrao { get; set; }
        public bool Virtual { get; set; }
        public bool PadraoVirtual { get; set; }
        public bool MercadoBitCoin { get; set; }
        public string CodigoMoedaBancoCentral { get; set; }
        public string Observacao { get; set; }
        public string Eletronica { get; set; }
    }
}
