using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Modelos;
using System.ComponentModel;

namespace DAL
{
    public class UsuarioDAL
    {
        /// <summary>
        /// Retorna uma lista contendo todos os registros da tabela Usuario
        /// </summary>
        /// <returns>
        /// Retorna DataTable
        /// </returns>
        public DataTable Listagem()
        {
            // Instancia uma tabela
            DataTable tabela = new DataTable();
            // Instacia um Data Adapter com a query abaixo, usando a conexão informada no login
            SqlDataAdapter da = new SqlDataAdapter("SELECT UsuarioId, Apelido, Nome, Senha, EMail, Ativo, Sistema " +
                                                   "FROM Usuario " +
                                                   "ORDER BY Apelido ASC;", Dados.Conexao);
            // Carrega a tabela
            da.Fill(tabela);
            // Retorna a listagem
            return tabela;
        }

        /// <summary>
        /// Inclui o registro atual no banco de dados
        /// </summary>
        /// <param name="registro">Usuário a ser incluíd</param>
        /// <returns>
        /// Retorna verdadeiro se sucesso
        /// </returns>
        public bool Incluir(Usuario registro)
        {
            bool incluido = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("INSERT INTO Usuario " +
                                            "(Apelido, Nome, Senha, EMail, Ativo, Sistema) " +
                                            "VALUES " +
                                            "(@Apelido, @Nome, @Senha, @EMail, @Ativo, @Sistema); " +

                                            "SELECT CAST(@@IDENTITY AS INT) AS UsuarioID;", conn);

            cmd.Parameters.AddWithValue("@Apelido", registro.Apelido);
            cmd.Parameters.AddWithValue("@Nome", registro.Nome);
            cmd.Parameters.AddWithValue("@Senha", registro.Senha);
            // O email pode ser nulo
            cmd.Parameters.AddWithValue("@EMail", ((object)registro.Email) ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Ativo", registro.Ativo);
            cmd.Parameters.AddWithValue("@Sistema", registro.Sistema);

            conn.Open();
            try
            {
                int numero = (int)cmd.ExecuteScalar();

                if (numero > 0)
                    incluido = true;
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao incluir usuário", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return incluido;
        }


        /// <summary>
        /// Atualiza o registro corrente
        /// </summary>
        /// <param name="registro">Usuário atual</param>
        /// <returns>
        /// Retorna verdadeiro se sucesso
        /// </returns>
        public bool Atualizar(Usuario registro)
        {
            bool atualizado = false;
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("UPDATE Usuario SET " +
                                            "Apelido = @Apelido, " +
                                            "Nome = @Nome, " +
                                            "Senha = @Senha, " +
                                            "EMail = @Email, " +
                                            "Ativo = @Ativo, " +
                                            "Sistema = @Sistema " +
                                            "WHERE UsuarioID = @UsuarioID; " +
                                            "SELECT CAST(@@ERROR AS INT);", conn);

            cmd.Parameters.AddWithValue("@UsuarioID", registro.UsuarioID);
            cmd.Parameters.AddWithValue("@Apelido", registro.Apelido);
            cmd.Parameters.AddWithValue("@Nome", registro.Nome);
            cmd.Parameters.AddWithValue("@Senha", registro.Senha);
            // O email pode ser nulo
            cmd.Parameters.AddWithValue("@EMail", ((object)registro.Email) ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Ativo", registro.Ativo);
            cmd.Parameters.AddWithValue("@Sistema", registro.Sistema);

            conn.Open();
            try
            {
                int numero = (int)cmd.ExecuteScalar();

                if (numero == 0)
                    atualizado = true;
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao atualizar usuário.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return atualizado;
        }

        public bool Excluir(int UsuarioID)
        {
            bool excluido = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("DELETE FROM Usuario "+
                                            "WHERE UsuarioID = @UsuarioID;", conn);

            cmd.Parameters.AddWithValue("@UsuarioID", UsuarioID);

            conn.Open();
            try
            {
                cmd.ExecuteScalar();
                excluido = true;
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao excluir usuário.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return excluido;
        }


        /// <summary>
        /// Verifica se o apelido do usuário está disponível 
        /// (se já existir mas for com o mesmo ID atual é porque se trata de uma atualização).
        /// </summary>
        /// <param name="UsuarioID">id do usuário atual</param>
        /// <param name="apelido">apelido do usuário atual</param>
        /// <returns>
        /// Retorna verdadeiro caso o apelido não exista ou seja do mesmo ID que foi testado.
        /// </returns>
        public bool ApelidoDisponivel(int UsuarioID, string apelido)
        {
            bool disponivel = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("SELECT COUNT(UsuarioID) AS Existe " +
                                            "FROM Usuario " +
                                            "WHERE UsuarioID <> @UsuarioID AND Apelido = @Apelido;", conn);

            cmd.Parameters.AddWithValue("@UsuarioID", UsuarioID);
            cmd.Parameters.AddWithValue("@Apelido", apelido);

            conn.Open();
            try
            {
                int numero = (int)cmd.ExecuteScalar();

                if (numero == 0)
                    disponivel = true;

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return disponivel;
        }
    }
}
