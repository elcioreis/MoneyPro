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
    public class LancamentoDAL
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
                                              "LancamentoID, UsuarioID, Apelido, Descricao, Ativo, Sistema " +
                                              "FROM Lancamento " +
                                              "WHERE UsuarioID = @UsuarioID " +
                                              "ORDER BY Apelido;", conn);
            // Atribui os parâmetros
            query.Parameters.AddWithValue("@UsuarioID", usuarioID);
            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public bool ApelidoDisponivel(int usuarioID, int lancamentoID, string apelido)
        {
            bool disponivel = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Existe " +
                                            "FROM Lancamento " +
                                            "WHERE Apelido = @Apelido " +
                                            "AND UsuarioID = @UsuarioID " +
                                            "AND LancamentoID <> @LancamentoID;", conn);

            cmd.Parameters.AddWithValue("@Apelido", apelido);
            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
            cmd.Parameters.AddWithValue("@LancamentoID", lancamentoID);

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

        public int Incluir(Lancamento modelo)
        {
            int registro = -1;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("INSERT INTO Lancamento " +
                                            "(UsuarioID, Apelido, Descricao, Ativo, Sistema) " +
                                            "VALUES " +
                                            "(@UsuarioID, @Apelido, @Descricao, @Ativo, @Sistema); " +

                                            "SELECT CAST(@@IDENTITY AS INT) AS LancamentoID;", conn);

            cmd.Parameters.AddWithValue("@UsuarioID", modelo.UsuarioID);
            cmd.Parameters.AddWithValue("@Apelido", modelo.Apelido);
            cmd.Parameters.AddWithValue("@Descricao", (object)modelo.Descricao ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Ativo", modelo.Ativo);
            cmd.Parameters.AddWithValue("@Sistema", modelo.Sistema);

            conn.Open();
            try
            {
                registro = (int)cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao incluir tipo de lançamento.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return registro;
        }

        public int IDdoLancamentoPadroCDB(int usuarioID)
        {
            int idLancamento = 0;

            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand query = new SqlCommand())
                {
                    query.Connection = conn;
                    query.CommandType = CommandType.Text;
                    query.CommandText = @"SELECT LP.LancamentoID
                                          FROM LancamentoPadraoCDB LP
                                          WHERE LP.UsuarioID = @UsuarioID;";

                    // Define os parâmetros necessários
                    query.Parameters.AddWithValue("@UsuarioID", usuarioID);

                    using (SqlDataReader dr = query.ExecuteReader())
                    {
                        // Verifica se há linhas
                        if (dr.HasRows)
                        {
                            // posiciona no primeiro registro
                            dr.Read();
                            // Somente o primeiro registro interessa
                            idLancamento = dr.GetInt32(0);
                        }
                    }
                }

                return idLancamento;
            }
        }

        public int Alterar(Lancamento modelo)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            // Um lançamento não poderá ser transferido para outro 
            // usuário, por isso o campo UsuarioID nunca é atualizado

            SqlCommand cmd = new SqlCommand("UPDATE Lancamento SET " +
                                            "Apelido = @Apelido, " +
                                            "Descricao = @Descricao, " +
                                            "Ativo = @Ativo, " +
                                            "Sistema = @Sistema " +
                                            "WHERE LancamentoID = @LancamentoID; " +

                                            "SELECT CAST(@@ERROR AS INT) AS Erro;", conn);

            cmd.Parameters.AddWithValue("@Apelido", modelo.Apelido);
            cmd.Parameters.AddWithValue("@Descricao", (object)modelo.Descricao ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Ativo", modelo.Ativo);
            cmd.Parameters.AddWithValue("@Sistema", modelo.Sistema);
            cmd.Parameters.AddWithValue("@LancamentoID", modelo.LancamentoID);

            try
            {
                conn.Open();

                if ((int)cmd.ExecuteScalar() == 0)
                    return modelo.LancamentoID;
                else
                    return -1;
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao alterar lançamento.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void Excluir(int lancamentoID)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("DELETE FROM Lancamento " +
                                            "WHERE LancamentoID = @LancamentoID;", conn);

            cmd.Parameters.AddWithValue("@LancamentoID", lancamentoID);

            try
            {
                conn.Open();
                cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao excluir lançamento.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public int IDdoLancamento(int usuarioID, string conteudo, bool apagaNaoUtilizados = true)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = conn.CreateCommand();

            StringBuilder texto = new StringBuilder("");

            if (apagaNaoUtilizados)
                texto.Append("DELETE FROM Lancamento " +
                             "WHERE Automatico = 1 " + 
                             "AND   LancamentoID NOT IN (SELECT DISTINCT LancamentoID " +
                             "                           FROM MovimentoConta WHERE NOT LancamentoID IS NULL) " +
                             "AND   LancamentoID NOT IN (SELECT DISTINCT LancamentoID " +
                             "                           FROM Planejamento WHERE NOT LancamentoID IS NULL) ");


            texto.Append(
              "IF (EXISTS (SELECT 1 FROM Lancamento WHERE UsuarioID = @UsuarioID AND Apelido = @Apelido)) " +
              "BEGIN " +
              "  SELECT LancamentoID FROM Lancamento WHERE UsuarioID = @UsuarioID AND Apelido = @Apelido; " +
              "END " +
              "ELSE " +
              "BEGIN " +
              "  INSERT INTO Lancamento " +
              "  (UsuarioID, Apelido, Descricao, Automatico) " +
              "  VALUES " +
              "  (@UsuarioID, @Apelido, 'Incluído através da movimentação de conta', 1); " +
              "  SELECT CAST(SCOPE_IDENTITY() * -1 AS INT); " +
              "END;");

            cmd.CommandText = texto.ToString();
            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
            cmd.Parameters.AddWithValue("@Apelido", conteudo);

            try
            {
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao incluir lançamento.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}