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
    public class InstituicaoDAL
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
            SqlCommand query = new SqlCommand("SELECT "+
                                              "InstituicaoID, UsuarioID, TipoInstituicaoID, Apelido, Descricao, Banco, Ativo "+
                                              "FROM Instituicao "+
                                              "WHERE UsuarioID = @UsuarioID "+
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

        public bool ApelidoDisponivel(int usuarioID, int instituicaoID, string apelido)
        {
            bool disponivel = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Existe " +
                                            "FROM Instituicao " +
                                            "WHERE Apelido = @Apelido " +
                                            "AND UsuarioID = @UsuarioID " +
                                            "AND InstituicaoID <> @InstituicaoID;", conn);

            cmd.Parameters.AddWithValue("@Apelido", apelido);
            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
            cmd.Parameters.AddWithValue("@InstituicaoID", instituicaoID);

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

        public int Incluir(Instituicao modelo)
        {
            int registro = -1;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("INSERT INTO Instituicao "+
                                            "(UsuarioID, TipoInstituicaoID, Apelido, Descricao, Banco, Ativo) "+
                                            "VALUES "+
                                            "(@UsuarioID, @TipoInstituicaoID, @Apelido, @Descricao, @Banco, @Ativo); " +

                                            "SELECT CAST(@@IDENTITY AS INT) AS InstituicaoID;", conn);

            cmd.Parameters.AddWithValue("@UsuarioID", modelo.UsuarioID);
            cmd.Parameters.AddWithValue("@TipoInstituicaoID", modelo.TipoInstituicaoID);
            cmd.Parameters.AddWithValue("@Apelido", modelo.Apelido);
            cmd.Parameters.AddWithValue("@Descricao", modelo.Descricao);
            // Campo Banco pode ser nulo.
            cmd.Parameters.AddWithValue("@Banco", ((object)modelo.Banco) ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Ativo", modelo.Ativo);

            conn.Open();
            try
            {
                registro = (int)cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao incluir instituição.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return registro;
        }

        public int Alterar(Instituicao modelo)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            // A instituição não poderá ser transferida para outro 
            // usuário, por isso o campo UsuarioID nunca é atualizado
            SqlCommand cmd = new SqlCommand("UPDATE Instituicao SET " +
                                            "TipoInstituicaoID = @TipoInstituicaoID, "+
                                            "Apelido = @Apelido, " +
                                            "Descricao = @Descricao, " +
                                            "Banco = @Banco, "+
                                            "Ativo = @Ativo " +
                                            "WHERE InstituicaoID = @InstituicaoID; " +

                                            "SELECT CAST(@@ERROR AS INT) AS Erro;", conn);

            cmd.Parameters.AddWithValue("@TipoInstituicaoID", modelo.TipoInstituicaoID);
            cmd.Parameters.AddWithValue("@Apelido", modelo.Apelido);
            cmd.Parameters.AddWithValue("@Descricao", modelo.Descricao);
            cmd.Parameters.AddWithValue("@Banco", ((object)modelo.Banco) ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Ativo", modelo.Ativo);
            cmd.Parameters.AddWithValue("@InstituicaoID", modelo.InstituicaoID);

            try
            {
                conn.Open();

                if ((int)cmd.ExecuteScalar() == 0)
                    return modelo.InstituicaoID;
                else
                    return -1;
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao alterar instituição.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void Excluir(int instituicaoID)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("DELETE FROM Instituicao " +
                                            "WHERE InstituicaoID = @InstituicaoID;", conn);

            cmd.Parameters.AddWithValue("@InstituicaoID", instituicaoID);

            try
            {
                conn.Open();
                cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao excluir instituição.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
