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
    public class GrupoContaDAL
    {
        /// <summary>
        /// Retorna uma lista contendo todos os registros da tabela GrupoConta pertencente ao usuário ativo
        /// </summary>
        /// <returns>
        /// Retorna DataTable
        /// </returns>
        public DataTable Listar(int usuarioID)
        {
            // Instancia uma tabela
            DataTable tabela = new DataTable();

            // Instancia uma conexão
            SqlConnection connection = new SqlConnection(Dados.Conexao);

            // Instancia um Data Adapter com a query abaixo, usando a conexão informado no login
            SqlDataAdapter da = new SqlDataAdapter();

            // Passa a query
            SqlCommand cmd = new SqlCommand("SELECT "+
                                            "GrupoContaID, UsuarioID, Apelido, Descricao, Ordem, Ativo "+
                                            "FROM GrupoConta "+
                                            "WHERE UsuarioID = @UsuarioID "+
                                            "ORDER BY Apelido ASC;", connection);

            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

            da.SelectCommand = cmd;

            // Carrega a tabela
            da.Fill(tabela);
            // Retorna a listagem
            return tabela;
        }

        /// <summary>
        /// Retorna uma lista contendo todos os registros da tabela GrupoConta pertencente ao usuário ativo
        /// </summary>
        /// <returns>
        /// Retorna DataTable
        /// </returns>
        public DataTable ListarPorOrdem(int usuarioID)
        {
            // Instancia uma tabela
            DataTable tabela = new DataTable();

            // Instancia uma conexão
            SqlConnection connection = new SqlConnection(Dados.Conexao);

            // Instancia um Data Adapter com a query abaixo, usando a conexão informado no login
            SqlDataAdapter da = new SqlDataAdapter();

            // Passa a query
            SqlCommand cmd = new SqlCommand("SELECT " +
                                            "GrupoContaID, UsuarioID, Apelido, Descricao, Ordem, Ativo " +
                                            "FROM GrupoConta " +
                                            "WHERE UsuarioID = @UsuarioID " +
                                            "ORDER BY Ordem ASC;", connection);

            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

            da.SelectCommand = cmd;

            // Carrega a tabela
            da.Fill(tabela);
            // Retorna a listagem
            return tabela;
        }


        public bool ApelidoDisponivel(int usuarioID, int grupoContaID, string apelido)
        {
            bool disponivel = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Existe " +
                                            "FROM GrupoConta " +
                                            "WHERE Apelido = @Apelido " +
                                            "AND UsuarioID = @UsuarioID "+
                                            "AND GrupoContaID <> @GrupoContaID;", conn);

            cmd.Parameters.AddWithValue("@Apelido", apelido);
            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
            cmd.Parameters.AddWithValue("@GrupoContaID", grupoContaID);

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

        public int Incluir(GrupoConta grupoConta)
        {
            int registro = -1;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("INSERT INTO GrupoConta " +
                                            "(UsuarioID, Apelido, Descricao, Ordem, Ativo) " +
                                            "VALUES " +
                                            "(@UsuarioID, @Apelido, @Descricao, @Ordem, @Ativo); " +

                                            "SELECT CAST(@@IDENTITY AS INT) AS GrupoContaID;", conn);

            cmd.Parameters.AddWithValue("@UsuarioID", grupoConta.UsuarioID);
            cmd.Parameters.AddWithValue("@Apelido", grupoConta.Apelido);
            cmd.Parameters.AddWithValue("@Descricao", grupoConta.Descricao);
            cmd.Parameters.AddWithValue("@Ordem", grupoConta.Ordem);
            cmd.Parameters.AddWithValue("@Ativo", grupoConta.Ativo);

            conn.Open();
            try
            {
                registro = (int)cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao incluir grupo de contas.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return registro;
        }

        public int Alterar(GrupoConta grupoConta)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            // Um grupo de contas não poderá ser transferido para outro 
            // usuário, por isso o campo UsuarioID nunca é atualizado
            SqlCommand cmd = new SqlCommand("UPDATE GrupoConta SET " +
                                            "Apelido = @Apelido, "+
                                            "Descricao = @Descricao, "+
                                            "Ordem = @Ordem, "+
                                            "Ativo = @Ativo "+
                                            "WHERE GrupoContaID = @GrupoContaID; " +

                                            "SELECT CAST(@@ERROR AS INT) AS Erro;", conn);

            cmd.Parameters.AddWithValue("@Apelido", grupoConta.Apelido);
            cmd.Parameters.AddWithValue("@Descricao", grupoConta.Descricao);
            cmd.Parameters.AddWithValue("@Ordem", grupoConta.Ordem);
            cmd.Parameters.AddWithValue("@Ativo", grupoConta.Ativo);
            cmd.Parameters.AddWithValue("@GrupoContaID", grupoConta.GrupoContaID);

            try
            {
                conn.Open();

                if ((int)cmd.ExecuteScalar() == 0)
                    return grupoConta.GrupoContaID;
                else
                    return -1;
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao alterar grupo de contas.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void Excluir(int grupoContaID)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            // Um grupo de contas não poderá ser transferido para outro 
            // usuário, por isso o campo UsuarioID nunca é atualizado
            SqlCommand cmd = new SqlCommand("DELETE FROM GrupoConta " +
                                            "WHERE GrupoContaID = @GrupoContaID;", conn);

            cmd.Parameters.AddWithValue("@GrupoContaID", grupoContaID);

            try
            {
                conn.Open();
                cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao excluir grupo de contas.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
