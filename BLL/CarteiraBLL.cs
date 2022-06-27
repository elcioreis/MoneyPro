using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using static Modelos.Tipo;

namespace BLL
{
    public class CarteiraBLL
    {
        public DataTable Listar(int usuarioID, bool apenasComSaldo)
        {
            CarteiraDAL dal = new CarteiraDAL();
            return dal.Listar(usuarioID, apenasComSaldo);
        }

        public DataTable DetalheInvestimento(int investimentoID)
        {
            CarteiraDAL dal = new CarteiraDAL();
            return dal.DetalheInvestimento(investimentoID);
        }

        public DataTable ListarMovimentosFundo(int investimentoID)
        {
            CarteiraDAL dal = new CarteiraDAL();
            return dal.ListarMovimentosFundo(investimentoID);
        }

        public DataTable VariacaoAcumulada(TipoConsultaInvestimentoVariacao tipoConsulta)
        {
            CarteiraDAL dal = new CarteiraDAL();
            return dal.VariacaoAcumulada(tipoConsulta);
        }

        public object ResumoInvestimento(int investimentoID, DateTime data, int tipoInformacao)
        {
            CarteiraDAL dal = new CarteiraDAL();
            return dal.ResumoInvestimento(investimentoID, data, tipoInformacao);
        }
    }
}
