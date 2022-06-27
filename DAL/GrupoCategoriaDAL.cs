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
    public class GrupoCategoriaDAL
    {
        /// <summary>
        /// Retorna uma lista contendo todos os registros da tabela GrupoCategoria pertencente ao usuário ativo
        /// </summary>
        /// <returns>
        /// Retorna DataTable
        /// </returns>
        public DataTable Listar(int usuarioID)
        {
            // Instancia uma tabela
            DataTable tabela = new DataTable();

            SqlConnection connection = new SqlConnection(Dados.Conexao);

            // Instancia um Data Adapter com a query abaixo, usando a conexão informado no login
            SqlDataAdapter da = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("SELECT GrupoCategoriaID, UsuarioID, Apelido, Descricao, " +
                                            "Ativo, Automatico, Proporcao "+
                                            "FROM GrupoCategoria "+
                                            "WHERE UsuarioID = @UsuarioID "+
                                            "ORDER BY Apelido ASC;", connection);

            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

            da.SelectCommand = cmd;

            // Carrega a tabela
            da.Fill(tabela);
            // Retorna a listagem
            return tabela;
        }


        public bool Excluir(int GrupoCategoriaID)
        {
            bool excluido = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("DELETE FROM GrupoCategoria " +
                                            "WHERE GrupoCategoriaID = @GrupoCategoriaID;", conn);

            cmd.Parameters.AddWithValue("@GrupoCategoriaID", GrupoCategoriaID);

            conn.Open();
            try
            {
                cmd.ExecuteScalar();
                excluido = true;
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao excluir grupo de categoria.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return excluido;
        }

        /// <summary>
        /// Verifica se o apelido do grupo de categoria está disponível 
        /// (se já existir mas for com o mesmo ID atual é porque se trata de uma atualização).
        /// </summary>
        /// <param name="grupoCategoriaID">id do grupo atual</param>
        /// <param name="apelido">apelido do grupo atual</param>
        /// <returns>
        /// Retorna verdadeiro caso o apelido não exista ou seja do mesmo ID que foi testado.
        /// </returns>
        public bool ApelidoDisponivel(int grupoCategoriaID, string apelido)
        {
            bool disponivel = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("SELECT COUNT(GrupoCategoriaID) AS Existe " +
                                            "FROM GrupoCategoria " +
                                            "WHERE GrupoCategoriaID <> @GrupoCategoriaID AND Apelido = @Apelido;", conn);

            cmd.Parameters.AddWithValue("@GrupoCategoriaID", grupoCategoriaID);
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


        /// <summary>
        /// Inclui o registro atual no banco de dados
        /// </summary>
        /// <param name="registro">Usuário a ser incluíd</param>
        /// <returns>
        /// Retorna verdadeiro se sucesso
        /// </returns>
        public bool Incluir(GrupoCategoria registro)
        {
            bool incluido = false;

            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO GrupoCategoria " +
                                                      "(UsuarioID, Apelido, Descricao, Ativo, Automatico, Proporcao) " +
                                                      "VALUES " +
                                                      "(@UsuarioID, @Apelido, @Descricao, @Ativo, @Automatico, @Proporcao); " +

                                                      "SELECT CAST(@@IDENTITY AS INT) AS GrupoCategoriaID;", conn))
                {
                    cmd.Parameters.AddWithValue("@UsuarioID", registro.UsuarioID);
                    cmd.Parameters.AddWithValue("@Apelido", registro.Apelido);
                    // A descrição pode ser nula
                    cmd.Parameters.AddWithValue("@Descricao", ((object)registro.Descricao) ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ativo", registro.Ativo);
                    cmd.Parameters.AddWithValue("@Automatico", registro.Automatico);
                    cmd.Parameters.AddWithValue("@Proporcao", registro.Proporcao);

                    conn.Open();
                    try
                    {
                        int numero = (int)cmd.ExecuteScalar();

                        if (numero > 0)
                            incluido = true;
                    }
                    catch (SyntaxErrorException e)
                    {
                        throw new System.SystemException("Falha ao incluir grupo de categoria", e);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return incluido;
        }

        /// <summary>
        /// Atualiza o registro corrente
        /// </summary>
        /// <param name="registro">Grupo de categoria atual</param>
        /// <returns>
        /// Retorna verdadeiro se sucesso
        /// </returns>
        public bool Atualizar(GrupoCategoria registro)
        {
            bool atualizado = false;
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            // Uma vez cadastrado o grupo de categoria, não poderá mudar para outro usuário;
            // Por isso não há o campo UsuarioID no UPDATE

            SqlCommand cmd = new SqlCommand("UPDATE GrupoCategoria SET " +
                                            "Apelido = @Apelido, " +
                                            "Descricao = @Descricao, " +
                                            "Ativo = @Ativo, " +
                                            "Automatico = @Automatico, " +
                                            "Proporcao = @Proporcao " +
                                            "WHERE GrupoCategoriaID = @GrupoCategoriaID; " +
                                            "SELECT CAST(@@ERROR AS INT);", conn);

            cmd.Parameters.AddWithValue("@Apelido", registro.Apelido);
            // A descrição pode ser nula
            cmd.Parameters.AddWithValue("@Descricao", ((object)registro.Descricao) ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Ativo", registro.Ativo);
            cmd.Parameters.AddWithValue("@GrupoCategoriaID", registro.GrupoCategoriaID);
            cmd.Parameters.AddWithValue("@Automatico", registro.Automatico);
            cmd.Parameters.AddWithValue("@Proporcao", registro.Proporcao);

            conn.Open();
            try
            {
                int numero = (int)cmd.ExecuteScalar();

                if (numero == 0)
                    atualizado = true;
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao atualizar grupo de categoria.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return atualizado;
        }

        public int IDdoGrupoCategoria(int usuarioID, string conteudo)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand(
              "DELETE FROM GrupoCategoria "+
              "WHERE UsuarioID = @UsuarioID "+
              "  AND GrupoCategoriaID NOT IN (SELECT DISTINCT GrupoCategoriaID FROM MovimentoConta WHERE NOT GrupoCategoriaID IS NULL) "+
              "  AND GrupoCategoriaID NOT IN (SELECT DISTINCT GrupoCategoriaID FROM Categoria WHERE NOT GrupoCategoriaID IS NULL) "+
              "  AND Automatico = 1 " +
              "IF (EXISTS (SELECT 1 FROM GrupoCategoria WHERE UsuarioID = @UsuarioID AND Apelido = @Apelido)) "+
              "BEGIN "+
              "  SELECT GrupoCategoriaID FROM GrupoCategoria WHERE UsuarioID = @UsuarioID AND Apelido = @Apelido; "+
              "END "+
              "ELSE "+
              "BEGIN "+
              "  INSERT INTO GrupoCategoria "+
              "  (UsuarioID, Apelido, Descricao, Automatico, Proporcao) "+
              "  VALUES "+
              "  (@UsuarioID, @Apelido, 'Incluído através da movimentação de conta', 1, 100); "+
              "  SELECT CAST(SCOPE_IDENTITY() * -1 AS INT); " +
              "END;", conn);

            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
            cmd.Parameters.AddWithValue("@Apelido", conteudo);

            try
            {
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao incluir grupo de categoria.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
