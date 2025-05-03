using System;
using System.Data;
using System.Data.SqlClient;
using static Modelos.Tipo;

namespace DAL
{
    public class CarteiraDAL
    {
        public DataTable Listar(int usuarioID, bool apenasComSaldo)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(
                @"SELECT vwc.UsuarioID, vwc.InvestimentoID, vwc.Apelido, inv.Consulta,
                                vwc.Conta, vwc.Tipo, vwc.RiscoID, vwc.Risco, vwc.QtCotas, vwc.VrCotacao, vwc.Data, vwc.Simbolo,
                                vwc.VrAplicado, vwc.PercCarteira, vwc.QtCotasFmt, vwc.VrCotacaoFmt, vwc.VrAplicadoFmt, 
                                vwc.PercFmt, vwc.Detalhe, vwc.Fundo, vwc.Acao
                         FROM vw_CarteiraFormatada vwc
                              LEFT JOIN Investimento inv on inv.InvestimentoID = vwc.InvestimentoID
                         WHERE vwc.UsuarioID = 2 AND ((COALESCE(vwc.VrAplicado, 0) > 0) OR (@ApenasComSaldo = 0))
                         ORDER BY vwc.Detalhe DESC, vwc.Apelido ASC;", conn);
            query.Parameters.AddWithValue("@UsuarioID", usuarioID);
            query.Parameters.AddWithValue("@ApenasComSaldo", apenasComSaldo);

            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Elimina o DataAccess
            da.Dispose();
            // Retorn a tabela
            return table;
        }

        public DataTable VariacaoAcumulada(TipoConsultaInvestimentoVariacao tipoConsulta)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();

            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    // Instancia um comando
                    using (SqlCommand query = new SqlCommand())
                    {
                        query.Connection = conn;
                        query.CommandType = CommandType.StoredProcedure;
                        //query.CommandText = "stpApuracaoInvestimentosLiquidosVariacaoAcumulada";
                        query.CommandText = "stpApuracaoBaseadoEmInvestimentoVariacao";

                        // Define os parâmetros necessários
                        query.Parameters.AddWithValue("@Investimentos", DBNull.Value);   // Todos Investimentos
                        query.Parameters.AddWithValue("@DtInicio", DBNull.Value);        // Período compelto desde o início do MoneyPro
                        query.Parameters.AddWithValue("@Tipo", (Int32)tipoConsulta);     // Determinado pelo parâmetro passado
                        query.Parameters.AddWithValue("@Ascendente", 0);                 // Define que é descendente

                        // Coloca a query no adaptador
                        da.SelectCommand = query;
                        // Popula a tabela
                        da.Fill(table);
                        // Retorn a tabela
                        return table;
                    }
                }
            }
        }

        public DataTable DetalheInvestimento(int investimentoID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();

            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    // Instancia um comando
                    using (SqlCommand proc = new SqlCommand())
                    {
                        proc.Connection = conn;
                        proc.CommandType = CommandType.StoredProcedure;
                        proc.CommandText = "stpDetalhesInvestimento";

                        // Define os parâmetros necessários
                        proc.Parameters.AddWithValue("@InvestimentoID", investimentoID);

                        // Coloca a query no adaptador
                        da.SelectCommand = proc;
                        // Popula a tabela
                        da.Fill(table);
                        // Retorn a tabela
                        return table;
                    }
                }
            }
        }

        public DataTable ListarMovimentosFundo(int investimentoID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();

            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    // Instancia um comando
                    using (SqlCommand proc = new SqlCommand())
                    {
                        proc.Connection = conn;
                        proc.CommandType = CommandType.StoredProcedure;
                        proc.CommandText = "stpListarMovimentosFundo";

                        // Define os parâmetros necessários
                        proc.Parameters.AddWithValue("@InvestimentoID", investimentoID);

                        // Coloca a query no adaptador
                        da.SelectCommand = proc;
                        // Popula a tabela
                        da.Fill(table);
                        // Retorn a tabela
                        return table;
                    }
                }
            }
        }


        public object ResumoInvestimento(int investimentoID, DateTime data, int tipoInformacao)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();

            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    // Instancia um comando
                    using (SqlCommand proc = new SqlCommand())
                    {
                        proc.Connection = conn;
                        proc.CommandType = CommandType.StoredProcedure;
                        proc.CommandText = "stpResumoInvestimentoLiquido";

                        // Define os parâmetros necessários
                        proc.Parameters.AddWithValue("@InvestimentoID", investimentoID);
                        proc.Parameters.AddWithValue("@Data", data);
                        proc.Parameters.AddWithValue("@TipoInformacao", tipoInformacao);

                        // Coloca a query no adaptador
                        da.SelectCommand = proc;
                        // Popula a tabela
                        da.Fill(table);
                        // Retorn a tabela
                        return table;
                    }
                }
            }
        }
    }
}
