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
    public class TipoInvestimentoDAL
    {
        public DataTable Listar(int usuarioID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand("SELECT " +
                                              "TipoInvestimentoID, UsuarioID, Apelido, Descricao, Ativo, " +
                                              "Fundo, Acao, ComeCota " +
                                              "FROM TipoInvestimento " +
                                              "WHERE UsuarioID = @UsuarioID " +
                                              "ORDER BY Apelido ASC;", conn);

            // Atribui os parâmetros
            query.Parameters.AddWithValue("@UsuarioID", usuarioID);
            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public bool ApelidoDisponivel(int usuarioID, int tipoInvestimentoID, string apelido)
        {
            bool disponivel = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Existe " +
                                            "FROM TipoInvestimento " +
                                            "WHERE Apelido = @Apelido " +
                                            "AND UsuarioID = @UsuarioID " +
                                            "AND TipoInvestimentoID <> @TipoInvestimentoID;", conn);

            cmd.Parameters.AddWithValue("@Apelido", apelido);
            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
            cmd.Parameters.AddWithValue("@TipoInvestimentoID", tipoInvestimentoID);

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

        public int Incluir(TipoInvestimento modelo)
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

                    cmd.CommandText = "INSERT INTO TipoInvestimento " +
                                      "(UsuarioID, Apelido, Descricao, Ativo, Fundo, Acao, ComeCota) " +
                                      "VALUES " +
                                      "(@UsuarioID, @Apelido, @Descricao, @Ativo, @Fundo, @Acao, @ComeCota); " +
                                      // Retorna o ID do TipoInvestimento incluído
                                      "SELECT CAST(@@IDENTITY AS INT) AS NovoID;";

                    cmd.Parameters.AddWithValue("@UsuarioID", modelo.UsuarioID);
                    cmd.Parameters.AddWithValue("@Apelido", modelo.Apelido);
                    cmd.Parameters.AddWithValue("@Descricao", (object)modelo.Descricao ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ativo", modelo.Ativo);
                    cmd.Parameters.AddWithValue("@Fundo", modelo.Fundo);
                    cmd.Parameters.AddWithValue("@Acao", modelo.Acao);
                    cmd.Parameters.AddWithValue("@ComeCota", modelo.ComeCota);

                    registro = (int)cmd.ExecuteScalar();
                    transacao.Commit();
                }
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao incluir tipo de investimento.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return registro;
        }

        public int Alterar(TipoInvestimento modelo)
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

                    cmd.CommandText = "UPDATE TipoInvestimento SET " +
                                      "Apelido = @Apelido, " +
                                      "Descricao = @Descricao, " +
                                      "Fundo = @Fundo, " +
                                      "Acao = @Acao, " +
                                      "ComeCota = @ComeCota, " +
                                      "Ativo = @Ativo " +
                                      "WHERE TipoInvestimentoID = @TipoInvestimentoID; " +

                                      "SELECT CAST(@@ERROR AS INT) AS Erro;";

                    cmd.Parameters.AddWithValue("@Apelido", modelo.Apelido);
                    cmd.Parameters.AddWithValue("@Descricao", (object)modelo.Descricao ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ativo", modelo.Ativo);
                    cmd.Parameters.AddWithValue("@Fundo", modelo.Fundo);
                    cmd.Parameters.AddWithValue("@Acao", modelo.Acao);
                    cmd.Parameters.AddWithValue("@ComeCota", modelo.ComeCota);
                    cmd.Parameters.AddWithValue("@TipoInvestimentoID", modelo.TipoInvestimentoID);

                    if ((int)cmd.ExecuteScalar() == 0)
                        registro = modelo.TipoInvestimentoID;

                    transacao.Commit();

                    return registro;
                }
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao alterar tipo de investimento.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void Excluir(int tipoInvestimentoID)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            conn.Open();

            SqlTransaction transacao = conn.BeginTransaction("Transacao");

            //            SqlCommand cmd = conn.CreateCommand();

            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = transacao;

                    cmd.CommandText = "DELETE FROM TipoInvestimento " +
                                      "WHERE TipoInvestimentoID = @TipoInvestimentoID;";

                    cmd.Parameters.AddWithValue("@TipoInvestimentoID", tipoInvestimentoID);

                    cmd.ExecuteScalar();

                    transacao.Commit();
                }
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao excluir tipo de investimento.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
