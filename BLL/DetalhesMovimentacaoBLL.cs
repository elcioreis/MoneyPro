using DAL;
using System.Data;

namespace BLL
{
    public class DetalhesMovimentacaoBLL
    {
        public DataTable Listar(int usuarioID, int? contaID, int? lancamentoID, int? categoriaID, int? grupoCategoriaID)
        {
            DetalhesMovimentacaoDAL dal = new DetalhesMovimentacaoDAL();
            return dal.Listar(usuarioID, contaID, lancamentoID, categoriaID, grupoCategoriaID);
        }
    }
}
