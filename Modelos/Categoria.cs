namespace Modelos
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public int UsuarioID { get; set; }
        public string Apelido { get; set; }
        public string Descricao { get; set; }
        public int? CategoriaPaiID { get; set; }
        public int? GrupoCategoriaID { get; set; }
        public string CrdDeb { get; set; }
        public int? OrdemVisual { get; set; }
        public bool Fixo { get; set; }
        public bool Ativo { get; set; }
        public int? ContaID { get; set; }
        public bool Sistema { get; set; }
        public bool Automatico { get; set; }
        public string vFiltro { get; set; }
    }
}
