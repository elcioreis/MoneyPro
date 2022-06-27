using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Planejamento
    {
        public int PlanejamentoID { get; set; }
        public int UsuarioID { get; set; }
        public string Apelido { get; set; }
        public string Descricao { get; set; }
        public int ContaID { get; set; }
        public string Conta { get; set; }
        public int LancamentoID { get; set; }
        public string Lancamento { get; set; }
        public int CategoriaID { get; set; }
        public string Categoria { get; set; }
        public int? GrupoCategoriaID { get; set; }
        public string GrupoCategoria { get; set; }        
        public string CrdDeb { get; set; }
        public decimal? Valor { get; set; }
        public bool Total { get; set; }
        public DateTime DtInicial { get; set; }
        public int Dia { get; set; }
        public bool DiaFixo { get; set; }
        public bool ValorFixo { get; set; }
        public int AdiaSeNaoUtil { get; set; }
        // Se a diferença da divisão das parcelas vai pra primeira
        // Exemplo: se True:  100 / 3 = 33,34 + 33,33 + 33,33 OU
        //          se False: 100 / 3 = 33,33 + 33,33 + 33,34
        public bool DiferencaNaPrimeira { get; set; }
        public int Repeticoes { get; set; }
        public int Processados { get; set; }
        //// Campos textuais da view (provenientes de case..end)
        public string TipoDia { get; set; }
        public string TipoTotal { get; set; }
        public string SeNaoUtil { get; set; }
        public string SeDiferenca { get; set; }
        public Boolean Ativo { get; set; }
        public string Parcela { get; set; }
        public decimal? ValorParcela { get; set; }
        public bool UltimoDiaMes { get; set; }
        public string Observacao { get; set; }
    }
}
