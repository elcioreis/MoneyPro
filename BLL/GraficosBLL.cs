using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using static Modelos.Tipo;

namespace BLL
{
    public class GraficosBLL
    {
        public DataTable GetHistoricoCotacaoComparativo(string investimentos, DateTime limiteInferior)
        {
            try
            {
                GraficosDAL grafico = new GraficosDAL();
                return grafico.HistoricoCotacaoComparativo(investimentos, limiteInferior);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable InvestimentosLiquidosAcumulados(string investimentos, DateTime dtInicio, TipoConsultaInvestimentoVariacao tipoConsulta)
        {
            try
            {
                GraficosDAL grafico = new GraficosDAL();
                return grafico.InvestimentosLiquidosAcumulados(investimentos, dtInicio, tipoConsulta);
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public DataTable InvestimentosLiquidosPercentual(string investimentos, DateTime dtInicio, TipoConsultaInvestimentoVariacao tipoConsulta, bool ascendente)
        {
            try
            {
                GraficosDAL grafico = new GraficosDAL();
                return grafico.InvestimentosLiquidosPercentual(investimentos, dtInicio, tipoConsulta, ascendente);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ComposicaoCarteira(char periodo, string investimentos)
        {
            try
            {
                GraficosDAL grafico = new GraficosDAL();
                return grafico.ComposicaoCarteira(periodo, investimentos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool HaInvestimentosNaSelecao(char periodo, string investimentos, DateTime dtInicio)
        {
            try
            {
                GraficosDAL grafico = new GraficosDAL();
                return grafico.HaInvestimentosNaSelecao(periodo, investimentos, dtInicio);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
