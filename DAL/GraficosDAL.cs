using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using static Modelos.Tipo;

namespace DAL
{
    public class GraficosDAL
    {
        public DataTable HistoricoCotacaoComparativo(string investimentos, DateTime limiteInferior)
        {
            DataTable tabela = new DataTable();

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand comando = new SqlCommand("EXEC stpHistoricoCotacaoComparativo @Investimentos, @Tipo, @DtInicio;", conn);
            comando.Parameters.AddWithValue("@Investimentos", investimentos);
            comando.Parameters.AddWithValue("@Tipo", "D");
            comando.Parameters.AddWithValue("@DtInicio", limiteInferior);

            try
            {
                SqlDataReader reader = comando.ExecuteReader();
                tabela.Load(reader);
                return tabela;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable InvestimentosLiquidosAcumulados(string investimentos, DateTime dtInicio, TipoConsultaInvestimentoVariacao tipoConsulta)
        {
            DataTable tabela = new DataTable();

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            if (conn.State == ConnectionState.Closed)
                conn.Open();
        
            SqlCommand comando = new SqlCommand("EXEC stpApuracaoBaseadoEmInvestimentoVariacao @Investimentos, @DtInicio, @Tipo;", conn);
            comando.Parameters.AddWithValue("@Investimentos", investimentos);
            comando.Parameters.AddWithValue("@DtInicio", dtInicio);
            comando.Parameters.AddWithValue("@Tipo", tipoConsulta);

            try
            {
                SqlDataReader reader = comando.ExecuteReader();
                tabela.Load(reader);
                return tabela;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable InvestimentosLiquidosPercentual(string investimentos, DateTime dtInicio, TipoConsultaInvestimentoVariacao tipoConsulta, bool ascendente)
        {
            DataTable tabela = new DataTable();

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand comando = new SqlCommand("EXEC stpApuracaoBaseadoEmInvestimentoVariacaoPerc @Investimentos, @DtInicio, @Tipo, @Ascendente;", conn);
            comando.Parameters.AddWithValue("@Investimentos", investimentos);
            comando.Parameters.AddWithValue("@DtInicio", dtInicio);
            comando.Parameters.AddWithValue("@Tipo", tipoConsulta);
            comando.Parameters.AddWithValue("@Ascendente", ascendente ? 1 : 0);

            try
            {
                SqlDataReader reader = comando.ExecuteReader();
                tabela.Load(reader);
                return tabela;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ComposicaoCarteira(char periodo, string investimentos)
        {
            DataTable tabela = new DataTable();

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand comando = new SqlCommand("EXEC stpSelecaoInvestimentosSaldo @Periodo, @Investimentos;", conn);
            comando.Parameters.AddWithValue("@periodo", periodo);
            comando.Parameters.AddWithValue("@Investimentos", investimentos);

            try
            {
                SqlDataReader reader = comando.ExecuteReader();
                tabela.Load(reader);
                return tabela;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool HaInvestimentosNaSelecao(char periodo, string investimentos, DateTime dtInicio)
        {         
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand comando = new SqlCommand("EXEC stpHaInvestimentosNaSelecao @Periodo, @Investimentos, @DtInicio;", conn);
            comando.Parameters.AddWithValue("@periodo", periodo);
            comando.Parameters.AddWithValue("@Investimentos", investimentos);
            comando.Parameters.AddWithValue("@DtInicio", dtInicio);

            try
            {
                return (Int32)comando.ExecuteScalar() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
