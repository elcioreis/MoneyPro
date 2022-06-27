using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using DAL;
using System.Data;

namespace BLL
{
    public class AcaoCotacaoBLL
    {
        public DataTable BuscarCotacoes()
        {
            AcaoCotacaoDAL dal = new AcaoCotacaoDAL();
            return dal.BuscarCotacoes();
        }

        public int ExisteCotacao(int investimentoID, DateTime data)
        {
            AcaoCotacaoDAL dal = new AcaoCotacaoDAL();
            return dal.ExisteCotacao(investimentoID, data);
        }

        public int Incluir(AcaoCotacao modelo)
        {
            AcaoCotacaoDAL dal = new AcaoCotacaoDAL();
            return dal.Incluir(modelo);
        }

        public int Alterar(AcaoCotacao modelo)
        {
            AcaoCotacaoDAL dal = new AcaoCotacaoDAL();
            return dal.Alterar(modelo);
        }
    }
}
