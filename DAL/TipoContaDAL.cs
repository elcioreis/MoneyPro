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
    public class TipoContaDAL
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
            SqlCommand query = new SqlCommand(@"SELECT
                                                TipoContaID, GrupoContaID, UsuarioID, Apelido, Descricao, Ativo,
                                                Investimento, Cartao, Banco, Poupanca, Cambio, CDB
                                                FROM TipoConta
                                                WHERE UsuarioID = @UsuarioID
                                                ORDER BY Apelido ASC", conn);
            // Atribui os parâmetros
            query.Parameters.AddWithValue("@UsuarioID", usuarioID);
            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public bool ApelidoDisponivel(int usuarioID, int tipoContaID, string apelido)
        {
            bool disponivel = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand(@"SELECT COUNT(*) AS Existe
                                              FROM TipoConta
                                              WHERE Apelido = @Apelido
                                              AND UsuarioID = @UsuarioID
                                              AND TipoContaID <> @TipoContaID;", conn);

            cmd.Parameters.AddWithValue("@Apelido", apelido);
            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
            cmd.Parameters.AddWithValue("@TipoContaID", tipoContaID);

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

        public int Incluir(TipoConta tipoConta)
        {
            int registro = -1;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand(@"INSERT INTO TipoConta
                                             (GrupoContaID, UsuarioID, Apelido, Descricao, Ativo,
                                              Investimento, Cartao, Banco, Poupanca, Cambio, CDB)
                                             VALUES
                                             (@GrupoContaID, @UsuarioID, @Apelido, @Descricao, @Ativo,
                                              @Investimento, @Cartao, @Banco, @Poupanca, @Cambio, @CDB);
                                             SELECT CAST(@@IDENTITY AS INT) AS TipoContaID", conn);

            cmd.Parameters.AddWithValue("@GrupoContaID", tipoConta.GrupoContaID);
            cmd.Parameters.AddWithValue("@UsuarioID", tipoConta.UsuarioID);
            cmd.Parameters.AddWithValue("@Apelido", tipoConta.Apelido);
            cmd.Parameters.AddWithValue("@Descricao", tipoConta.Descricao);
            cmd.Parameters.AddWithValue("@Ativo", tipoConta.Ativo);
            cmd.Parameters.AddWithValue("@Investimento", tipoConta.Investimento);
            cmd.Parameters.AddWithValue("@Cartao", tipoConta.Cartao);
            cmd.Parameters.AddWithValue("@Banco", tipoConta.Banco);
            cmd.Parameters.AddWithValue("@Poupanca", tipoConta.Poupanca);
            cmd.Parameters.AddWithValue("@Cambio", tipoConta.Cambio);
            cmd.Parameters.AddWithValue("@CDB", tipoConta.CDB);

            conn.Open();
            try
            {
                registro = (int)cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao incluir tipo de contas.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return registro;
        }

        public int Alterar(TipoConta tipoConta)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            // Um grupo de contas não poderá ser transferido para outro 
            // usuário, por isso o campo UsuarioID nunca é atualizado
            SqlCommand cmd = new SqlCommand(@"UPDATE TipoConta SET
                                              GrupoContaID = @GrupoContaID,
                                              Apelido = @Apelido,
                                              Descricao = @Descricao,
                                              Banco = @Banco,
                                              Cartao = @Cartao,
                                              Investimento = @Investimento,
                                              Poupanca = @Poupanca,
                                              Cambio = @Cambio,
                                              CDB = @CDB,
                                              Ativo = @Ativo
                                              WHERE TipoContaID = @TipoContaID;
                                              SELECT CAST(@@ERROR AS INT) AS Erro", conn);

            cmd.Parameters.AddWithValue("@GrupoContaID", tipoConta.GrupoContaID);
            cmd.Parameters.AddWithValue("@Apelido", tipoConta.Apelido);
            cmd.Parameters.AddWithValue("@Descricao", tipoConta.Descricao);
            cmd.Parameters.AddWithValue("@Ativo", tipoConta.Ativo);
            cmd.Parameters.AddWithValue("@Investimento", tipoConta.Investimento);
            cmd.Parameters.AddWithValue("@Cartao", tipoConta.Cartao);
            cmd.Parameters.AddWithValue("@Banco", tipoConta.Banco);
            cmd.Parameters.AddWithValue("@Poupanca", tipoConta.Poupanca);
            cmd.Parameters.AddWithValue("@TipoContaID", tipoConta.TipoContaID);
            cmd.Parameters.AddWithValue("@Cambio", tipoConta.Cambio);
            cmd.Parameters.AddWithValue("@CDB", tipoConta.CDB);

            try
            {
                conn.Open();

                if ((int)cmd.ExecuteScalar() == 0)
                    return tipoConta.TipoContaID;
                else
                    return -1;
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao alterar tipo de contas.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }


        public void Excluir(int tipoContaID)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand(@"DELETE FROM TipoConta
                                              WHERE TipoContaID = @TipoContaID", conn);

            cmd.Parameters.AddWithValue("@TipoContaID", tipoContaID);

            try
            {
                conn.Open();
                cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao excluir tipo de contas.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
