using Modelos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ContaDAL
    {
        public DataTable ListarContas(int UsuarioID, Boolean TodasContas)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(@"SELECT ContaID, UsuarioID, InstituicaoID, TipoContaID, MoedaID, Apelido,
                                                       Descricao, DataAbertura, SaldoInicial, Limite, Decimais, UsaHora, 
                                                       OFX, CSV, TipoArquivo, Ativo, ExibirProjecao
                                                FROM Conta
                                                WHERE UsuarioID = @UsuarioID " +

                                               (!TodasContas ? " AND Ativo = 1 " : "") +

                                               "ORDER BY Apelido ASC;", conn);

            // Atribui os parâmetros
            query.Parameters.AddWithValue("@UsuarioID", UsuarioID);
            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public DataTable RolContas(int usuarioID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(@"SELECT Ordem, Detalhe, Grupo, COALESCE(UsuarioID, @UsuarioID) AS UsuarioID, 
                                                       ContaID, Conta, GrupoContaID, MoedaID, TipoContaID, Moeda, Valor,
                                                       ValorFormatado, Banco, Poupanca, Cartao, Investimento, CDB,
                                                       ExibirResumo, Decimais, UsaHora, OFX, CSV
                                                FROM vw_ListaContas_V04
                                                WHERE COALESCE(UsuarioID, @UsuarioID) = @UsuarioID
                                                ORDER BY Ordem ASC, Detalhe ASC, Conta ASC;", conn);

            // Atribui os parâmetros
            query.Parameters.AddWithValue("@UsuarioID", usuarioID);
            // Define timeout maior
            query.CommandTimeout = 60;
            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public bool ApelidoDisponivel(int usuarioID, int contaID, string apelido)
        {
            bool disponivel = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand(@"SELECT COUNT(*) AS Existe
                                              FROM Conta
                                              WHERE Apelido = @Apelido
                                              AND UsuarioID = @UsuarioID
                                              AND ContaID <> @ContaID;", conn);

            cmd.Parameters.AddWithValue("@Apelido", apelido);
            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
            cmd.Parameters.AddWithValue("@ContaID", contaID);

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

        public int Incluir(Conta modelo)
        {
            int registro = -1;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            //  A tabela Conta possui uma trigger para inclusão
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Conta
                                              (UsuarioID, InstituicaoID, TipoContaID, MoedaID, Apelido, Descricao,
                                               DataAbertura, SaldoInicial, Limite, OFX, Ativo, Decimais, UsaHora,
                                               CSV, TipoArquivo)
                                              VALUES
                                              (@UsuarioID, @InstituicaoID, @TipoContaID, @MoedaID, @Apelido, @Descricao,
                                               @DataAbertura, @SaldoInicial, @Limite, @OFX, @Ativo, @Decimais, @UsaHora,
                                               @CSV, @TipoArquivo); " +
                                            // Retorna o ID da Conta
                                            "SELECT CAST(@@IDENTITY AS INT) AS ContaID;", conn);

            cmd.Parameters.AddWithValue("@UsuarioID", modelo.UsuarioID);
            cmd.Parameters.AddWithValue("@InstituicaoID", modelo.InstituicaoID);
            cmd.Parameters.AddWithValue("@TipoContaID", modelo.TipoContaID);
            cmd.Parameters.AddWithValue("@MoedaID", modelo.MoedaID);
            cmd.Parameters.AddWithValue("@Apelido", modelo.Apelido);
            cmd.Parameters.AddWithValue("@Descricao", modelo.Descricao);
            cmd.Parameters.AddWithValue("@DataAbertura", modelo.DataAbertura);
            cmd.Parameters.AddWithValue("@SaldoInicial", modelo.SaldoInicial);
            cmd.Parameters.AddWithValue("@Limite", modelo.Limite);
            cmd.Parameters.AddWithValue("OFX", modelo.OFX);
            cmd.Parameters.AddWithValue("@Ativo", modelo.Ativo);
            cmd.Parameters.AddWithValue("@Decimais", modelo.Decimais);
            cmd.Parameters.AddWithValue("@UsaHora", modelo.UsaHora);
            cmd.Parameters.AddWithValue("@CSV", modelo.CSV);
            cmd.Parameters.AddWithValue("@TipoArquivo", (object)modelo.TipoArquivo ?? DBNull.Value);

            conn.Open();
            try
            {
                registro = (int)cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao incluir conta.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return registro;
        }

        public int Alterar(Conta modelo)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            // A instituição não poderá ser transferida para outro 
            // usuário, por isso o campo UsuarioID nunca é atualizado

            //  A tabela Conta possui uma trigger para alteração
            SqlCommand cmd = new SqlCommand(// Atualiza a tabela Conta
                                            @"UPDATE Conta 
                                              SET InstituicaoID = @InstituicaoID,
                                                  TipoContaID = @TipoContaID,
                                                  MoedaID = @MoedaID,
                                                  Apelido = @Apelido,
                                                  Descricao = @Descricao,
                                                  DataAbertura = @DataAbertura,
                                                  SaldoInicial = @SaldoInicial,
                                                  Limite = @Limite,
                                                  OFX = @OFX,
                                                  Decimais = @Decimais,
                                                  UsaHora = @UsaHora,
                                                  Ativo = @Ativo,
                                                  ExibirProjecao = @ExibirProjecao,
                                                  CSV = @CSV,
                                                  TipoArquivo = @TipoArquivo
                                              WHERE ContaID = @ContaID;

                                              SELECT CAST(@@ERROR AS INT) AS Erro;", conn);

            cmd.Parameters.AddWithValue("@InstituicaoID", modelo.InstituicaoID);
            cmd.Parameters.AddWithValue("@TipoContaID", modelo.TipoContaID);
            cmd.Parameters.AddWithValue("@MoedaID", modelo.MoedaID);
            cmd.Parameters.AddWithValue("@Apelido", modelo.Apelido);
            cmd.Parameters.AddWithValue("@Descricao", modelo.Descricao);
            cmd.Parameters.AddWithValue("@DataAbertura", modelo.DataAbertura);
            cmd.Parameters.AddWithValue("@SaldoInicial", modelo.SaldoInicial);
            cmd.Parameters.AddWithValue("@Limite", modelo.Limite);
            cmd.Parameters.AddWithValue("OFX", modelo.OFX);
            cmd.Parameters.AddWithValue("@Decimais", modelo.Decimais);
            cmd.Parameters.AddWithValue("@UsaHora", modelo.UsaHora);
            cmd.Parameters.AddWithValue("@Ativo", modelo.Ativo);
            cmd.Parameters.AddWithValue("@ContaID", modelo.ContaID);
            cmd.Parameters.AddWithValue("@ExibirProjecao", modelo.ExibirProjecao);
            cmd.Parameters.AddWithValue("@CSV", modelo.CSV);
            cmd.Parameters.AddWithValue("@TipoArquivo", (object)modelo.TipoArquivo ?? DBNull.Value);

            try
            {
                conn.Open();

                if ((int)cmd.ExecuteScalar() == 0)
                    return modelo.ContaID;
                else
                    return -1;
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao alterar conta.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void Excluir(int contaID)
        {
            // Apaga por trasação, primeiro o movimento de abertura de conta, depois a conta.
            // Se houver outros movimentos na conta, a operação irá falhar.

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            conn.Open();

            SqlTransaction transacao = conn.BeginTransaction("Conta");

            SqlCommand cmd = conn.CreateCommand();
            cmd.Transaction = transacao;

            try
            {
                // Tenta excluir o movimento de abertura da conta (único com PilhaMovimentoContaID nulo)
                cmd.CommandText = @"DELETE FROM MovimentoConta
                                    WHERE ContaID = @ContaID
                                    AND Sistema = 1
                                    AND PilhaMovimentoContaID IS NULL;";
                cmd.Parameters.AddWithValue("@ContaID", contaID);
                cmd.ExecuteNonQuery();

                // Tenta excluir a categoria associada à conta
                cmd.Parameters.Clear();
                cmd.CommandText = @"DELETE FROM Categoria
                                    WHERE ContaID = @ContaID;";
                cmd.Parameters.AddWithValue("@ContaID", contaID);
                cmd.ExecuteNonQuery();

                // Tenta excluir a conta
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM Conta " +
                                  "WHERE ContaID = @ContaID;";
                cmd.Parameters.AddWithValue("@ContaID", contaID);
                cmd.ExecuteNonQuery();

                transacao.Commit();

            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao excluir conta.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void AlternarExibicaoResumo(int contaID, bool novoStatus)
        {
            // Apaga por trasação, primeiro o movimento de abertura de conta, depois a conta.
            // Se houver outros movimentos na conta, a operação irá falhar.

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            conn.Open();

            SqlTransaction transacao = conn.BeginTransaction("Conta");

            SqlCommand cmd = conn.CreateCommand();
            cmd.Transaction = transacao;

            try
            {
                // Muda a forma de exibição da conta (resumido ou tudo)
                // (se resumido, agrupa tudo entre a data de abertura e o último período reconciliado, desde que contínuo)
                cmd.CommandText = @"UPDATE Conta
                                    SET ExibirResumo = @NovoStatus
                                    WHERE ContaID = @ContaID;";

                cmd.Parameters.AddWithValue("@ContaID", contaID);
                cmd.Parameters.AddWithValue("@NovoStatus", novoStatus);

                cmd.ExecuteNonQuery();

                transacao.Commit();

            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao mudar formato de exibição da conta.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void AtualizaBalancoConta(int contaID)
        {
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "stpAtualizaBalancoConta";

                    cmd.Parameters.AddWithValue("@ContaID", contaID);
                    cmd.Parameters.AddWithValue("@DataInicioAtualizacao", 0);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}