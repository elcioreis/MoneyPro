using DAL;
using Modelos;
using System;
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

        public bool AtualizarCotacaoB3(CotacaoHistoricaB3 cotacaoB3, int InvestimentoID)
        {
            AcaoCotacaoDAL dal = new AcaoCotacaoDAL();
            return dal.AtualizarCotacao(cotacaoB3, InvestimentoID);
        }
    }
}
