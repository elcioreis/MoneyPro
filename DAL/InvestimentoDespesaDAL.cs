using Modelos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class InvestimentoDespesaDAL
    {
        public DataTable Listar(int investimentoID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(@"SELECT
                                                InvestimentoDespesaID, InvestimentoID, CategoriaID, Descricao,
                                                Entrada, Saida, Ordem, ImpostoID, IR, IOF, ComeCota
                                                FROM InvestimentoDespesa
                                                WHERE InvestimentoID = @InvestimentoID
                                                ORDER BY Ordem ASC;", conn);

            // Atribui os parâmetros
            query.Parameters.AddWithValue("@InvestimentoID", investimentoID);
            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public bool CategoriaDisponivel(int investimentoID, int investimentoDespesaID, int categoriaID)
        {
            bool disponivel = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Existe " +
                                            "FROM InvestimentoDespesa " +
                                            "WHERE InvestimentoID = @InvestimentoID " +
                                            "AND CategoriaID = @CategoriaID " +
                                            "AND InvestimentoDespesaID <> @InvestimentoDespesaID;", conn);

            cmd.Parameters.AddWithValue("@InvestimentoID", investimentoID);
            cmd.Parameters.AddWithValue("@InvestimentoDespesaID", investimentoDespesaID);
            cmd.Parameters.AddWithValue("@CategoriaID", categoriaID);

            conn.Open();
            try
            {
                if ((int)cmd.ExecuteScalar() == 0)
                    disponivel = true;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return disponivel;
        }

        public int Incluir(InvestimentoDespesa modelo)
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

                    cmd.CommandText = "INSERT INTO InvestimentoDespesa " +
                                      "(InvestimentoID, CategoriaID, Descricao, Entrada, Saida, Ordem, ImpostoID, IR, IOF, ComeCota) " +
                                      "VALUES " +
                                      "(@InvestimentoID, @CategoriaID, @Descricao, @Entrada, @Saida, @Ordem, @ImpostoID, @IR, @IOF, @ComeCota); " +
                                      // Retorna o ID do TipoInvestimento incluído
                                      "SELECT CAST(@@IDENTITY AS INT) AS NovoID;";

                    cmd.Parameters.AddWithValue("@InvestimentoID", modelo.InvestimentoID);
                    cmd.Parameters.AddWithValue("@CategoriaID", modelo.CategoriaID);
                    cmd.Parameters.AddWithValue("@Descricao", (object)modelo.Descricao ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Entrada", modelo.Entrada);
                    cmd.Parameters.AddWithValue("@Saida", modelo.Saida);
                    cmd.Parameters.AddWithValue("@Ordem", modelo.Ordem);
                    cmd.Parameters.AddWithValue("@ImpostoID", (object)modelo.ImpostoID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IR", modelo.IR);
                    cmd.Parameters.AddWithValue("@IOF", modelo.IOF);
                    cmd.Parameters.AddWithValue("@ComeCota", modelo.ComeCota);

                    registro = (int)cmd.ExecuteScalar();
                    transacao.Commit();
                }
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao incluir despesas de investimento.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return registro;
        }

        public int Alterar(InvestimentoDespesa modelo)
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

                    cmd.CommandText = "UPDATE InvestimentoDespesa SET " +
                                      "CategoriaID = @CategoriaID, " +
                                      "Descricao = @Descricao, " +
                                      "Entrada = @Entrada, " +
                                      "Saida = @Saida, " +
                                      "Ordem = @Ordem, " +
                                      "IR = @IR," +
                                      "IOF = @IOF, " +
                                      "ComeCota = @ComeCota, " +
                                      "ImpostoID = @ImpostoID " +
                                      "WHERE InvestimentoDespesaID = @InvestimentoDespesaID; " +

                                      "SELECT CAST(@@ERROR AS INT) AS Erro;";

                    cmd.Parameters.AddWithValue("@CategoriaID", modelo.CategoriaID);
                    cmd.Parameters.AddWithValue("@Descricao", (object)modelo.Descricao ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Entrada", modelo.Entrada);
                    cmd.Parameters.AddWithValue("@Saida", modelo.Saida);
                    cmd.Parameters.AddWithValue("@Ordem", modelo.Ordem);
                    cmd.Parameters.AddWithValue("@IR", modelo.IR);
                    cmd.Parameters.AddWithValue("@IOF", modelo.IOF);
                    cmd.Parameters.AddWithValue("@ComeCota", modelo.ComeCota);
                    cmd.Parameters.AddWithValue("@ImpostoID", (object)modelo.ImpostoID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InvestimentoDespesaID", modelo.InvestimentoDespesaID);

                    if ((int)cmd.ExecuteScalar() == 0)
                        registro = (int)modelo.InvestimentoDespesaID;

                    transacao.Commit();

                    return registro;
                }
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao alterar despesas de investimento.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void Excluir(int investimentoDespesaID)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            conn.Open();

            SqlTransaction transacao = conn.BeginTransaction("Transacao");

            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = transacao;

                    cmd.CommandText = "DELETE FROM InvestimentoDespesa " +
                                      "WHERE InvestimentoDespesaID = @InvestimentoDespesaID;";

                    cmd.Parameters.AddWithValue("@InvestimentoDespesaID", investimentoDespesaID);

                    cmd.ExecuteScalar();

                    transacao.Commit();
                }
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao excluir despesa de investimento.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
