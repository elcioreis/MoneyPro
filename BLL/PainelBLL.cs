using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class PainelBLL
    {
        public DataTable ApuracaoMensalPorGrupoDeContas(int periodos, bool ateHoje)
        {
            PainelDAL dal = new PainelDAL();
            return dal.ApuracaoMensalPorGrupoDeContas(periodos, ateHoje);
        }

        public DataTable ApuracaoSemanalPorGrupoDeContas(int periodos)
        {
            PainelDAL dal = new PainelDAL();
            return dal.ApuracaoSemanalPorGrupoDeContas(periodos);
        }

        public DataTable ApuracaoSemanalAcumulada(int periodos)
        {
            PainelDAL dal = new PainelDAL();
            return dal.ApuracaoSemanalAcumulada(periodos);
        }


        public DataTable ApuracaoInvestimentos(int periodos)
        {
            PainelDAL dal = new PainelDAL();
            return dal.ApuracaoInvestimentos(periodos);
        }

        public DataTable ApuracaoDivisaoInvestimento()
        {
            PainelDAL dal = new PainelDAL();
            return dal.ApuracaoDivisaoInvestimento();
        }

        public DataTable ApuracaoDivisaoRisco()
        {
            PainelDAL dal = new PainelDAL();
            return dal.ApuracaoDivisaoRisco();
        }

        public DataTable ApuracaoDestinoPorCategoria(DateTime data, double perc)
        {
            PainelDAL dal = new PainelDAL();
            return dal.ApuracaoDestinoPorCategoria(data, perc);
        }

        public DataTable ApuracaoComparativoPorCategoria(DateTime data, int periodos, double perc)
        {
            PainelDAL dal = new PainelDAL();
            return dal.ApuracaoComparativoPorCategoria(data, periodos, perc);
        }

        public DataTable ApuracaoInvestimentosAcumulados()
        {
            PainelDAL dal = new PainelDAL();
            return dal.ApuracaoInvestimentosAcumulados();
        }

        public DataTable ApuracaoInvestimentosAcumuladosMensal(int periodos)
        {
            PainelDAL dal = new PainelDAL();
            return dal.ApuracaoInvestimentosAcumuladosMensal(periodos);
        }
    }
}
