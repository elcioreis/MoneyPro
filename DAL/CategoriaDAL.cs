using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace DAL
{
    public class CategoriaDAL
    {
        /// <summary>
        /// Retorna uma lista contendo todos os registros da tabela Categoria pertencente ao usuário ativo
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

            SqlCommand cmd = new SqlCommand(@"SELECT CategoriaID, UsuarioID, Apelido, Descricao, GrupoCategoriaID, 
                                                     GrupoCategoria, CrdDeb, OrdemVisual, Fixo, Ativo, ContaID, 
                                                     Sistema, CategoriaPaiID, CategoriaPai, Nivel 
                                              FROM vw_Categoria 
                                              WHERE UsuarioID = @UsuarioID 
                                              ORDER BY Nivel, OrdemVisual, Apelido;", connection);

            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

            da.SelectCommand = cmd;

            // Carrega a tabela
            da.Fill(tabela);
            // Retorna a listagem
            return tabela;
        }


        /// <summary>
        /// Retorna uma lista contendo todos as categorias que podem ser selecionadas como pai
        /// </summary>
        /// <returns>
        /// Retorna DataTable
        /// </returns>
        public DataTable Ancestral(int usuarioID)
        {
            // Instancia uma tabela
            DataTable tabela = new DataTable();

            SqlConnection connection = new SqlConnection(Dados.Conexao);

            // Instancia um Data Adapter com a query abaixo, usando a conexão informado no login
            SqlDataAdapter da = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand(@"SELECT CategoriaID, UsuarioID, Apelido, Descricao, Nivel, 
                                                     GrupoCategoriaID, CrdDeb, OrdemVisual, Fixo, Ativo, 
                                                     ContaID, Sistema, CategoriaPaiID 
                                              FROM vw_CategoriaHieraquia 
                                              WHERE UsuarioID = @UsuarioID AND Nivel < 2 
                                              ORDER BY Apelido ASC;", connection);

            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

            da.SelectCommand = cmd;

            // Carrega a tabela
            da.Fill(tabela);
            // Retorna a listagem
            return tabela;
        }

        public int IDdaCategoriaPadraoCDB(int idUsuario)
        {
            int idCategoria = 0;

            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand query = new SqlCommand())
                {
                    query.Connection = conn;
                    query.CommandType = CommandType.Text;
                    query.CommandText = @"SELECT LP.CategoriaID
                                          FROM LancamentoPadraoCDB LP
                                          WHERE LP.UsuarioID = @UsuarioID;";

                    // Define os parâmetros necessários
                    query.Parameters.AddWithValue("@UsuarioID", idUsuario);

                    using (SqlDataReader dr = query.ExecuteReader())
                    {
                        // Verifica se há linhas
                        if (dr.HasRows)
                        {
                            // posiciona no primeiro registro
                            dr.Read();
                            // Somente o primeiro registro interessa
                            idCategoria = dr.GetInt32(0);
                        }
                    }
                }

                return idCategoria;
            }
        }

        public int Incluir(Categoria registro)
        {
            int numero = -1;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand(@"INSERT INTO Categoria 
                                              (UsuarioID, Apelido, Descricao, CategoriaPaiID, GrupoCategoriaID, 
                                               CrdDeb, Fixo, Ativo, ContaID, Sistema, Automatico) 
                                              VALUES 
                                              (@UsuarioID, @Apelido, @Descricao, @CategoriaPaiID, @GrupoCategoriaID, 
                                               @CrdDeb, @Fixo, @Ativo, @ContaID, @Sistema, @Automatico); 
                                              
                                              SELECT CAST(@@IDENTITY AS INT) AS CategoriaID;", conn);

            cmd.Parameters.AddWithValue("@UsuarioID", registro.UsuarioID);
            cmd.Parameters.AddWithValue("@Apelido", registro.Apelido);
            // A descrição pode ser nula
            cmd.Parameters.AddWithValue("@Descricao", ((object)registro.Descricao) ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CategoriaPaiID", registro.CategoriaPaiID);
            // O grupo de categoria pode ser nulo
            cmd.Parameters.AddWithValue("@GrupoCategoriaID", ((object)registro.GrupoCategoriaID) ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CrdDeb", registro.CrdDeb);
            cmd.Parameters.AddWithValue("@Fixo", registro.Fixo);
            cmd.Parameters.AddWithValue("@Ativo", registro.Ativo);
            // A conta da categoria pode ser nula
            cmd.Parameters.AddWithValue("@ContaID", ((object)registro.ContaID) ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Sistema", registro.Sistema);
            cmd.Parameters.AddWithValue("@Automatico", false);

            conn.Open();
            try
            {
                numero = (int)cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao incluir categoria", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return numero;
        }

        /// <summary>
        /// Atualiza o registro corrente
        /// </summary>
        /// <param name="registro">Categoria atual</param>
        /// <returns>
        /// Retorna o número da Categoria alterada se sucesso ou negativo se falha
        /// </returns>
        public int Atualizar(Categoria registro)
        {
            int numero = -1;
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            // Uma vez cadastrada a categoria, não poderá mudar para outro usuário.
            // O campo OrdemVisual só existe nas categorias criadas pelo sistema e não podem ser editados.

            SqlCommand cmd = new SqlCommand(@"UPDATE Categoria SET 
                                              Apelido = @Apelido, 
                                              Descricao = @Descricao, 
                                              CategoriaPaiID = @CategoriaPaiID, 
                                              GrupoCategoriaID = @GrupoCategoriaID, 
                                              CrdDeb = @CrdDeb, 
                                              Fixo = @Fixo, 
                                              Ativo = @Ativo, 
                                              ContaID = @ContaID, 
                                              Sistema = @Sistema, 
                                              Automatico = @Automatico 
                                              WHERE CategoriaID = @CategoriaID; 
                                              IF (@@ERROR = 0) 
                                                 SELECT @CategoriaID; 
                                              ELSE 
                                                 SELECT CAST(-1 AS INT);", conn);

            cmd.Parameters.AddWithValue("@Apelido", registro.Apelido);
            // A descrição pode ser nula
            cmd.Parameters.AddWithValue("@Descricao", ((object)registro.Descricao) ?? DBNull.Value);
            // A categoria pai pode ser nula
            cmd.Parameters.AddWithValue("CategoriaPaiID", ((object)registro.CategoriaPaiID) ?? DBNull.Value);
            // O grupo pode ser nulo
            cmd.Parameters.AddWithValue("@GrupoCategoriaID", ((object)registro.GrupoCategoriaID) ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CrdDeb", registro.CrdDeb);
            cmd.Parameters.AddWithValue("@Fixo", registro.Fixo);
            cmd.Parameters.AddWithValue("@Ativo", registro.Ativo);
            // A conta vinculada pode ser nula
            cmd.Parameters.AddWithValue("@ContaID", ((object)registro.ContaID) ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Sistema", registro.Sistema);
            cmd.Parameters.AddWithValue("@Automatico", false);
            cmd.Parameters.AddWithValue("@CategoriaID", registro.CategoriaID);

            conn.Open();
            try
            {
                numero = (int)cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao atualizar categoria.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return numero;
        }


        public bool Excluir(int categoriaID)
        {
            bool excluido = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand(@"DELETE FROM Categoria 
                                              WHERE CategoriaID = @CategoriaID;", conn);

            cmd.Parameters.AddWithValue("@CategoriaID", categoriaID);

            conn.Open();
            try
            {
                cmd.ExecuteScalar();
                excluido = true;
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao excluir categoria.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return excluido;
        }

        public DataTable ListarSelecionaveis(int usuarioID, int nivel = 0)
        {
            // Instancia uma tabela
            DataTable tabela = new DataTable();

            SqlConnection connection = new SqlConnection(Dados.Conexao);

            // Instancia um Data Adapter com a query abaixo, usando a conexão informado no login
            SqlDataAdapter da = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand(@"SELECT UsuarioID, vCatMasterID, vCrdDeb, vOrdenador, vFiltro, vNivel, 
                                                     CategoriaID, Apelido, Descricao, CategoriaPaiID, GrupoCategoriaID, 
                                                     Ativo, Sistema, ContaID 
                                              FROM vw_CategoriasSelecionaveis 
                                              WHERE UsuarioID = @UsuarioID 
                                              AND vNivel >= @Nivel 
                                              AND CategoriaPaiID IS NOT NULL 
                                              ORDER BY vFiltro ASC;", connection);

            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
            cmd.Parameters.AddWithValue("@Nivel", nivel);

            da.SelectCommand = cmd;

            // Carrega a tabela
            da.Fill(tabela);
            // Retorna a listagem
            return tabela;
        }

        public int IDdaCategoria(int usuarioID, string conteudo)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand(@"DELETE FROM Categoria 
                                              WHERE UsuarioID = @UsuarioID 
                                              AND Automatico = 1 
                                              AND CategoriaID NOT IN (SELECT DISTINCT CategoriaID FROM MovimentoConta WHERE UsuarioID = @UsuarioID) 
                                              
                                              IF (EXISTS (SELECT 1 FROM Categoria WHERE UsuarioID = @UsuarioID AND Apelido = @Apelido)) 
                                              BEGIN 
                                                SELECT CategoriaID FROM Categoria WHERE UsuarioID = @UsuarioID AND Apelido = @Apelido; 
                                              END 
                                              ELSE 
                                              BEGIN 
                                                SELECT CAST(-1 AS INT) AS CateogiraID; 
                                              END;", conn);

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

        public int PesquisaCategoriaID(int usuarioID, string conteudo)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand(
                @"IF (EXISTS (SELECT 1 FROM vw_CategoriasSelecionaveis WHERE UsuarioID = @UsuarioID AND vFiltro = @Apelido)) 
                      SELECT CategoriaID FROM vw_CategoriasSelecionaveis WHERE UsuarioID = @UsuarioID AND vFiltro = @Apelido; 
                  ELSE 
                      SELECT 0;", conn);

            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
            cmd.Parameters.AddWithValue("@Apelido", conteudo);

            try
            {
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao consultar categoria.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public int AdicionaCategoriaID(int usuarioID, int idPai, string conteudo)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand(@"DELETE FROM Categoria 
                                              WHERE CategoriaID NOT IN (SELECT CategoriaID FROM MovimentoConta
                                                                        UNION
                                                                        SELECT CategoriaID FROM Planejamento)
                                              AND UsuarioID = @UsuarioID 
                                              AND Automatico = 1; 
                    
                                              DECLARE @CrdDeb CHAR(1); 
                    
                                              SELECT @CrdDeb = CrdDeb 
                                              FROM  Categoria 
                                              WHERE CategoriaID = @CategoriaPaiID; 
                    
                                              INSERT INTO Categoria 
                                              (UsuarioID, Apelido, Descricao, CategoriaPaiID, CrdDeb, Ativo, Sistema, Automatico) 
                                              VALUES 
                                              (@UsuarioID, @Apelido, @Descricao, @CategoriaPaiID, @CrdDeb, @Ativo, @Sistema, @Automatico); 
                                              SELECT CAST(SCOPE_IDENTITY() * -1 AS INT); ", conn);

            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
            cmd.Parameters.AddWithValue("@Apelido", conteudo);
            cmd.Parameters.AddWithValue("@Descricao", "Incluído através da movimentação de conta");
            cmd.Parameters.AddWithValue("@CategoriaPaiID", idPai);
            cmd.Parameters.AddWithValue("@Ativo", true);
            cmd.Parameters.AddWithValue("@Sistema", false);
            cmd.Parameters.AddWithValue("@Automatico", true);

            try
            {
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao incluir categoria.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
