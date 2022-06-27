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
    public class TipoInstituicaoDAL
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
                                              "TipoInstituicaoID, UsuarioID, Apelido, Descricao, Ativo "+
                                              "FROM TipoInstituicao "+
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

        public bool ApelidoDisponivel(int usuarioID, int tipoInstituicaoID, string apelido)
        {
            bool disponivel = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Existe " +
                                            "FROM TipoInstituicao " +
                                            "WHERE Apelido = @Apelido " +
                                            "AND UsuarioID = @UsuarioID " +
                                            "AND TipoInstituicaoID <> @TipoInstituicaoID;", conn);

            cmd.Parameters.AddWithValue("@Apelido", apelido);
            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
            cmd.Parameters.AddWithValue("@TipoInstituicaoID", tipoInstituicaoID);

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

        public int Incluir(TipoInstituicao modelo)
        {
            int registro = -1;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("INSERT INTO TipoInstituicao " +
                                            "(UsuarioID, Apelido, Descricao, Ativo) " +
                                            "VALUES " +
                                            "(@UsuarioID, @Apelido, @Descricao, @Ativo); " +

                                            "SELECT CAST(@@IDENTITY AS INT) AS TipoInstituicaoID;", conn);

            cmd.Parameters.AddWithValue("@UsuarioID", modelo.UsuarioID);
            cmd.Parameters.AddWithValue("@Apelido", modelo.Apelido);
            cmd.Parameters.AddWithValue("@Descricao", modelo.Descricao);
            cmd.Parameters.AddWithValue("@Ativo", modelo.Ativo);

            conn.Open();
            try
            {
                registro = (int)cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao incluir tipo de instituição.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return registro;
        }

        public int Alterar(TipoInstituicao modelo)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            // Um grupo de contas não poderá ser transferido para outro 
            // usuário, por isso o campo UsuarioID nunca é atualizado
            SqlCommand cmd = new SqlCommand("UPDATE TipoInstituicao SET " +
                                            "Apelido = @Apelido, " +
                                            "Descricao = @Descricao, " +
                                            "Ativo = @Ativo " +
                                            "WHERE TipoInstituicaoID = @TipoInstituicaoID; " +

                                            "SELECT CAST(@@ERROR AS INT) AS Erro;", conn);

            cmd.Parameters.AddWithValue("@Apelido", modelo.Apelido);
            cmd.Parameters.AddWithValue("@Descricao", modelo.Descricao);
            cmd.Parameters.AddWithValue("@Ativo", modelo.Ativo);
            cmd.Parameters.AddWithValue("@TipoInstituicaoID", modelo.TipoInstituicaoID);

            try
            {
                conn.Open();

                if ((int)cmd.ExecuteScalar() == 0)
                    return modelo.TipoInstituicaoID;
                else
                    return -1;
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao alterar tipo de instituição.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void Excluir(int tipoInstituicaoID)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("DELETE FROM TipoInstituicao " +
                                            "WHERE TipoInstituicaoID = @TipoInstituicaoID;", conn);

            cmd.Parameters.AddWithValue("@TipoInstituicaoID", tipoInstituicaoID);

            try
            {
                conn.Open();
                cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao excluir tipo de instituição.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }      
        }
    }
}
