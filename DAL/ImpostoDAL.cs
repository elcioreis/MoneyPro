using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ImpostoDAL
    {
        public DataTable Listar()
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand("SELECT ImpostoID, Apelido, Descricao, Ativo " +
                                              "FROM Imposto " +
                                              "ORDER BY Apelido ASC;", conn);

            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public bool ApelidoDisponivel(int impostoID, string apelido)
        {
            bool disponivel = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Existe " +
                                            "FROM Imposto " +
                                            "WHERE Apelido = @Apelido " +
                                            "AND ImpostoID <> @ImpostoID;", conn);

            cmd.Parameters.AddWithValue("@Apelido", apelido);
            cmd.Parameters.AddWithValue("@ImpostoID", impostoID);

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

        public int Incluir(Imposto modelo)
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

                    cmd.CommandText = "INSERT INTO Imposto " +
                                      "(Apelido, Descricao, Ativo) " +
                                      "VALUES " +
                                      "(@Apelido, @Descricao, @Ativo); " +

                                      "SELECT CAST(@@IDENTITY AS INT) AS NovoID;";

                    cmd.Parameters.AddWithValue("@Apelido", modelo.Apelido);
                    cmd.Parameters.AddWithValue("@Descricao", (object)modelo.Descricao ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ativo", modelo.Ativo);

                    registro = (int)cmd.ExecuteScalar();
                    transacao.Commit();
                }
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao incluir imposto.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return registro;
        }

        public int Alterar(Imposto modelo)
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

                    cmd.CommandText = "UPDATE Imposto SET " +
                                      "Apelido = @Apelido, " +
                                      "Descricao = @Descricao, " +
                                      "Ativo = @Ativo " +
                                      "WHERE ImpostoID = @ImpostoID; " +

                                      "SELECT CAST(@@ERROR AS INT) AS Erro;";

                    cmd.Parameters.AddWithValue("@Apelido", modelo.Apelido);
                    cmd.Parameters.AddWithValue("@Descricao", (object)modelo.Descricao ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ativo", modelo.Ativo);
                    cmd.Parameters.AddWithValue("@ImpostoID", modelo.ImpostoID);

                    if ((int)cmd.ExecuteScalar() == 0)
                        registro = (int)modelo.ImpostoID;

                    transacao.Commit();

                    return registro;
                }
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao alterar imposto.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void Excluir(int impostoID)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            conn.Open();

            SqlTransaction transacao = conn.BeginTransaction("Transacao");

            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = transacao;

                    cmd.CommandText = "DELETE FROM Imposto " +
                                      "WHERE ImpostoID = @ImpostoID;";

                    cmd.Parameters.AddWithValue("@ImpostoID", impostoID);

                    cmd.ExecuteScalar();

                    transacao.Commit();
                }
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao excluir imposto.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
