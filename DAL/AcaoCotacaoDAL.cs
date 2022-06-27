using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class AcaoCotacaoDAL
    {
        public int Incluir(AcaoCotacao modelo)
        {
            int registro = -1;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            conn.Open();

            SqlTransaction transacao = conn.BeginTransaction("Transacao");

            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = transacao;

                    cmd.CommandText = "INSERT INTO AcaoCotacao " +
                                      "(InvestimentoID, Codigo, Nome, Ibovespa, Data, Abertura, " +
                                      " Minimo, Maximo, Medio, Ultimo, Oscilacao) " +
                                      "VALUES " +
                                      "(@InvestimentoID, @Codigo, @Nome, @Ibovespa, @Data, @Abertura, " +
                                      " @Minimo, @Maximo, @Medio, @Ultimo, @Oscilacao); " +
             
                                      "SELECT CAST(@@IDENTITY AS INT) AS NovoID;";

                    cmd.Parameters.AddWithValue("@InvestimentoID", modelo.InvestimentoID);
                    cmd.Parameters.AddWithValue("@Codigo", modelo.Codigo);
                    cmd.Parameters.AddWithValue("@Nome", modelo.Nome);
                    cmd.Parameters.AddWithValue("@Ibovespa", modelo.Ibovespa);
                    cmd.Parameters.AddWithValue("@Data", modelo.Data);
                    cmd.Parameters.AddWithValue("@Abertura", (object)modelo.Abertura ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Minimo", (object)modelo.Minimo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Maximo", (object)modelo.Maximo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Medio", (object)modelo.Medio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ultimo", (object)modelo.Ultimo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Oscilacao", (object)modelo.Oscilacao ?? DBNull.Value);

                    registro = (int)cmd.ExecuteScalar();
                    transacao.Commit();
                }
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao incluir cotação da ação " + modelo.Codigo + ".", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return registro;
        }

        public int Alterar(AcaoCotacao modelo)
        {
            int registro = -1;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            conn.Open();

            SqlTransaction transacao = conn.BeginTransaction("Transacao");

            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = transacao;

                    cmd.CommandText = "UPDATE AcaoCotacao SET " +
                                      "InvestimentoId = @InvestimentoID, " +
                                      "Codigo = @Codigo, " +
                                      "Nome = @Nome, " +
                                      "Ibovespa = @Ibovespa, " +
                                      "Data = @Data, " +
                                      "Abertura = @Abertura, " +
                                      "Minimo = @Minimo, " +
                                      "Maximo = @Maximo, " +
                                      "Medio = @Medio, " +
                                      "Ultimo = @Ultimo, " +
                                      "Oscilacao = @Oscilacao " +
                                      "WHERE AcaoCotacaoID = @AcaoCotacaoID; " +

                                      "SELECT CAST(@@ERROR AS INT) AS Erro;";

                    cmd.Parameters.AddWithValue("@InvestimentoID", modelo.InvestimentoID);
                    cmd.Parameters.AddWithValue("@Codigo", modelo.Codigo);
                    cmd.Parameters.AddWithValue("@Nome", modelo.Nome);
                    cmd.Parameters.AddWithValue("@Ibovespa", modelo.Ibovespa);
                    cmd.Parameters.AddWithValue("@Data", modelo.Data);
                    cmd.Parameters.AddWithValue("@Abertura", (object)modelo.Abertura ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Minimo", (object)modelo.Minimo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Maximo", (object)modelo.Maximo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Medio", (object)modelo.Medio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ultimo", (object)modelo.Ultimo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Oscilacao", (object)modelo.Oscilacao ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AcaoCotacaoID", modelo.AcaoCotacaoID);

                    if ((int)cmd.ExecuteScalar() == 0)
                        registro = modelo.AcaoCotacaoID;

                    transacao.Commit();

                    return registro;
                }
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao incluir cotação da ação " + modelo.Codigo + ".", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }


        public int ExisteCotacao(int investimentoID, DateTime data)
        {
            int acaoCotacaoID = 0;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("SELECT " +
                                            "COALESCE((SELECT AcaoCotacaoID " +
                                                      "FROM AcaoCotacao " +
                                                      "WHERE InvestimentoID = @InvestimentoID " +
                                                      "AND CONVERT(DATETIME, FLOOR(CONVERT(FLOAT(24), Data))) = @Data), 0) AS AcaoCotacaoID;", conn);

            cmd.Parameters.AddWithValue("@InvestimentoID", investimentoID);
            cmd.Parameters.AddWithValue("@Data", data.Date);

            conn.Open();
            try
            {
                acaoCotacaoID = (int)cmd.ExecuteScalar();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return acaoCotacaoID;
        }

        public DataTable BuscarCotacoes()
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(@"SELECT Inve.InvestimentoID, Inve.Apelido, Inve.Descricao, Inve.Consulta
                                                FROM Investimento Inve
                                                INNER JOIN TipoInvestimento Tipo ON Tipo.TipoInvestimentoID = Inve.TipoInvestimentoID
                                                WHERE Tipo.Acao = 1
                                                ORDER BY Inve.Apelido ASC;", conn);

            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

    }
}
