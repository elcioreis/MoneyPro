using System;
using Modelos;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class MovimentoInvestimentoDAL
    {
        public int Incluir(MovimentoInvestimento modelo, MovimentoInvestimentoDespesa[] despesas)
        {
            int investimentoCotacaoID;
            int movimentoContaID;
            int movimentoInvestimentoID;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            conn.Open();

            SqlTransaction transacao = conn.BeginTransaction("Movimentacao");

            SqlCommand cmd = conn.CreateCommand();

            try
            {
                int Passo = 0;

                int LancamentosPrevios = QuantidadeLancamentosPrevios(modelo.ContaID, (DateTime)modelo.Data) + 1;

                modelo.Data = ((DateTime)modelo.Data).AddMilliseconds(LancamentosPrevios * 3);

                string lancamento = null;

                if (modelo.CrdDeb == "D")
                    lancamento = "Despesas de Aplicação";
                else
                    lancamento = "Despesas de Resgate";

                int lancamentoID = IDdoLancamento(modelo.UsuarioID, lancamento, false);

                cmd.Transaction = transacao;

                // Atualiza a cotação do investimento
                cmd.CommandText = @"DECLARE @InvestimentoCotacaoID INT;
                                    EXEC stpAtualizaCotacao @InvestimentoID, @Data, @VrCotacao, @ForcaAtualizacao; 
                                    SELECT @InvestimentoCotacaoID;";

                cmd.Parameters.AddWithValue("@InvestimentoID", modelo.InvestimentoID);
                cmd.Parameters.AddWithValue("@Data", ((DateTime)modelo.Data).Date);
                cmd.Parameters.AddWithValue("@VrCotacao", modelo.VrCotacao);
                cmd.Parameters.AddWithValue("@ForcaAtualizacao", modelo.ForcaAtualizacao ? 1 : 0);

                investimentoCotacaoID = (int)cmd.ExecuteScalar();
                cmd.Parameters.Clear();

                // Insere o movimento de conta
                cmd.CommandText = @"INSERT INTO MovimentoConta 
                                   (UsuarioID, ContaID, Data, Numero, LancamentoID, Descricao, CategoriaID, 
                                    GrupoCategoriaID, CrdDeb, Credito, Debito, Conciliacao, Sistema) 
                                   VALUES 
                                   (@UsuarioID, @ContaID, @Data, @Numero, @LancamentoID, @Descricao, @CategoriaID,
                                    @GrupoCategoriaID, @CrdDeb, @Credito, @Debito, @Conciliacao, @Sistema);
                                   SELECT CAST(@@IDENTITY AS INT) AS MovimentoContaID;";

                cmd.Parameters.AddWithValue("@UsuarioID", modelo.UsuarioID);
                cmd.Parameters.AddWithValue("@ContaID", modelo.ContaID);
                cmd.Parameters.AddWithValue("@Data", modelo.Data);
                cmd.Parameters.AddWithValue("@Numero", (object)modelo.Numero ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LancamentoID", modelo.LancamentoID);
                cmd.Parameters.AddWithValue("@Descricao", modelo.Descricao);
                cmd.Parameters.AddWithValue("@CategoriaID", modelo.CategoriaID);
                cmd.Parameters.AddWithValue("@GrupoCategoriaID", (object)modelo.GrupoCategoriaID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CrdDeb", modelo.CrdDeb);
                cmd.Parameters.AddWithValue("@Credito", (object)modelo.Credito ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Debito", (object)modelo.Debito ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Conciliacao", modelo.Conciliacao);
                cmd.Parameters.AddWithValue("@Sistema", false);

                movimentoContaID = (int)cmd.ExecuteScalar();
                cmd.Parameters.Clear();

                // Insere o movimento de investimento
                cmd.CommandText = @"INSERT INTO MovimentoInvestimento
                                   (MovimentoContaID, InvestimentoID, TransacaoID, InvestimentoCotacaoID,
                                    QtCotas, VrBruto, VrLiquido, VrDespesa)
                                   VALUES
                                   (@MovimentoContaID, @InvestimentoID, @TransacaoID, @InvestimentoCotacaoID,
                                    @QtCotas, @VrBruto, @VrLiquido, @VrDespesa);
                                   SELECT CAST(@@IDENTITY AS INT) AS MovimentoInvestimentoID;";

                // O movimento a crédito é na conta, diminuindo a quantidade de cotas.
                if (modelo.CrdDeb == "C")
                    modelo.QtCotas *= -1;

                cmd.Parameters.AddWithValue("@MovimentoContaID", movimentoContaID);
                cmd.Parameters.AddWithValue("@InvestimentoID", modelo.InvestimentoID);
                cmd.Parameters.AddWithValue("@TransacaoID", modelo.TransacaoID);
                cmd.Parameters.AddWithValue("@InvestimentoCotacaoID", investimentoCotacaoID);
                cmd.Parameters.AddWithValue("@QtCotas", modelo.QtCotas);
                cmd.Parameters.AddWithValue("@VrBruto", modelo.VrBruto);
                cmd.Parameters.AddWithValue("@VrLiquido", modelo.VrLiquido);
                cmd.Parameters.AddWithValue("@VrDespesa", modelo.VrDespesa);

                movimentoInvestimentoID = (int)cmd.ExecuteScalar();

                cmd.Parameters.Clear();
                // Insere a informação na tabela de ligações
                cmd.CommandText = @"INSERT INTO MovimentoContaLigacao
                                    (MovimentoContaID, Passo, MovimentoInvestimentoID)
                                    VALUES
                                    (@MovimentoContaID, @Passo, @MovimentoInvestimentoID);";

                cmd.Parameters.AddWithValue("@MovimentoContaID", movimentoContaID);
                cmd.Parameters.AddWithValue("@Passo", Passo);
                cmd.Parameters.AddWithValue("@MovimentoInvestimentoID", movimentoInvestimentoID);
                cmd.ExecuteNonQuery();


                // Não há passo 1 no investimento, o passo zero é o lançamento principal e as despesas são lançadas do passo 2 em diante.
                Passo += 2;

                // Insere as despesas do investimento
                foreach (MovimentoInvestimentoDespesa linha in despesas)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = @"INSERT INTO MovimentoInvestimentoDespesa
                                       (MovimentoInvestimentoID, CategoriaID, Valor, Ordem)
                                       VALUES
                                       (@MovimentoInvestimentoID, @CategoriaID, @Valor, @Ordem);";

                    cmd.Parameters.AddWithValue("@MovimentoInvestimentoID", movimentoInvestimentoID);
                    cmd.Parameters.AddWithValue("@CategoriaID", linha.CategoriaID);
                    cmd.Parameters.AddWithValue("@Valor", linha.Valor);
                    cmd.Parameters.AddWithValue("@Ordem", linha.Ordem);
                    cmd.ExecuteNonQuery();

                    if (linha.Valor != 0)
                    {
                        // Insere o movimento de despesa para aparecer no grid.

                        lancamentoID = IDdoLancamento(modelo.UsuarioID, linha.Parceiro, false);

                        cmd.Parameters.Clear();
                        cmd.CommandText = @"INSERT INTO MovimentoConta 
                                           (UsuarioID, ContaID, Data, Numero, LancamentoID, Descricao, CategoriaID,
                                            GrupoCategoriaID, CrdDeb, Credito, Debito, Conciliacao, Sistema, DoMovimentoContaID)
                                           VALUES
                                           (@UsuarioID, @ContaID, @Data, @Numero, @LancamentoID, @Descricao, @CategoriaID,
                                            @GrupoCategoriaID, @CrdDeb, @Credito, @Debito, @Conciliacao, @Sistema, @DoMovimentoContaID);

                                           SELECT CAST(@@IDENTITY AS INT) AS MovimentoContaID;";

                        cmd.Parameters.AddWithValue("@UsuarioID", modelo.UsuarioID);
                        cmd.Parameters.AddWithValue("@ContaID", modelo.ContaID);
                        cmd.Parameters.AddWithValue("@Data", modelo.Data);
                        cmd.Parameters.AddWithValue("@Numero", (object)modelo.Numero ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@LancamentoID", lancamentoID);
                        cmd.Parameters.AddWithValue("@Descricao", modelo.Descricao);
                        cmd.Parameters.AddWithValue("@CategoriaID", linha.CategoriaID);
                        cmd.Parameters.AddWithValue("@GrupoCategoriaID", (object)modelo.GrupoCategoriaID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CrdDeb", "D");
                        cmd.Parameters.AddWithValue("@Credito", DBNull.Value);
                        cmd.Parameters.AddWithValue("@Debito", linha.Valor);
                        cmd.Parameters.AddWithValue("@Conciliacao", modelo.Conciliacao);
                        cmd.Parameters.AddWithValue("@Sistema", true);
                        cmd.Parameters.AddWithValue("@DoMovimentoContaID", movimentoContaID);

                        //cmd.ExecuteNonQuery();
                        movimentoContaID = (int)cmd.ExecuteScalar();

                        // Insere a informação na tabela de ligações
                        cmd.Parameters.Clear();
                        cmd.CommandText = @"INSERT INTO MovimentoContaLigacao
                                    (MovimentoContaID, Passo, MovimentoInvestimentoID)
                                    VALUES
                                    (@MovimentoContaID, @Passo, @MovimentoInvestimentoID);";

                        cmd.Parameters.AddWithValue("@MovimentoContaID", movimentoContaID);
                        cmd.Parameters.AddWithValue("@Passo", Passo++);
                        cmd.Parameters.AddWithValue("@MovimentoInvestimentoID", movimentoInvestimentoID);
                        cmd.ExecuteNonQuery();
                    }
                }

                transacao.Commit();

                return movimentoContaID;
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao incluir o lançamento de investimento.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private int QuantidadeLancamentosPrevios(int contaID, DateTime data)
        {
            int Quantidade = 0;

            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"SELECT COUNT(MovimentoContaID) Lancamentos
                                                         FROM MovimentoConta
                                                         WHERE ContaID = @ContaID
                                                         AND CAST(Data AS DATE) = @Data;", conn))
                {
                    cmd.Parameters.AddWithValue("@ContaID", contaID);
                    cmd.Parameters.AddWithValue("@Data", data.Date);

                    Quantidade = (int)cmd.ExecuteScalar();
                }
                conn.Close();
                conn.Dispose();
            }

            return Quantidade;
        }

        public int Alterar(MovimentoInvestimento modelo, MovimentoInvestimentoDespesa[] despesas)
        {
            int investimentoCotacaoID;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            conn.Open();

            SqlTransaction transacao = conn.BeginTransaction("Movimentacao");

            SqlCommand cmd = conn.CreateCommand();

            try
            {
                string lancamento = null;

                if (modelo.CrdDeb == "D")
                    lancamento = "Despesas de Aplicação";
                else
                    lancamento = "Despesas de Resgate";

                int lancamentoID = IDdoLancamento(modelo.UsuarioID, lancamento, false);

                cmd.Transaction = transacao;

                cmd.CommandText = @"DECLARE @InvestimentoCotacaoID INT;
                                    EXEC stpAtualizaCotacao @InvestimentoID, @Data, @VrCotacao, @ForcaAtualizacao; 
                                    SELECT @InvestimentoCotacaoID;";

                cmd.Parameters.AddWithValue("@InvestimentoID", modelo.InvestimentoID);
                cmd.Parameters.AddWithValue("@Data", modelo.Data);
                cmd.Parameters.AddWithValue("@VrCotacao", modelo.VrCotacao);
                cmd.Parameters.AddWithValue("@ForcaAtualizacao", modelo.ForcaAtualizacao ? 1 : 0);

                investimentoCotacaoID = (int)cmd.ExecuteScalar();

                cmd.Parameters.Clear();
                cmd.CommandText = @"UPDATE MovimentoConta SET 
                                    ContaID = @ContaID, 
                                    Data = @Data, 
                                    Numero = @Numero, 
                                    LancamentoID = @LancamentoID, 
                                    Descricao = @Descricao, 
                                    CategoriaID = @CategoriaID, 
                                    GrupoCategoriaID = @GrupoCategoriaID,
                                    CrdDeb = @CrdDeb,
                                    Credito = @Credito,
                                    Debito = @Debito,
                                    Conciliacao = @Conciliacao,
                                    Sistema = @Sistema
                                    WHERE MovimentoContaID = @MovimentoContaID;";

                cmd.Parameters.AddWithValue("@ContaID", modelo.ContaID);
                cmd.Parameters.AddWithValue("@Data", modelo.Data);
                cmd.Parameters.AddWithValue("@Numero", (object)modelo.Numero ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LancamentoID", modelo.LancamentoID);
                cmd.Parameters.AddWithValue("@Descricao", modelo.Descricao);
                cmd.Parameters.AddWithValue("@CategoriaID", modelo.CategoriaID);
                cmd.Parameters.AddWithValue("@GrupoCategoriaID", (object)modelo.GrupoCategoriaID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CrdDeb", modelo.CrdDeb);
                cmd.Parameters.AddWithValue("@Credito", (object)modelo.Credito ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Debito", (object)modelo.Debito ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Conciliacao", modelo.Conciliacao);
                cmd.Parameters.AddWithValue("@Sistema", false);
                cmd.Parameters.AddWithValue("@MovimentoContaID", modelo.MovimentoContaID);

                cmd.ExecuteNonQuery();

                // O movimento a crédito é na conta, diminuindo a quantidade de cotas.
                if (modelo.CrdDeb == "C")
                    modelo.QtCotas *= -1;

                cmd.Parameters.Clear();
                cmd.CommandText = @"UPDATE MovimentoInvestimento SET 
                                    MovimentoContaID = @MovimentoContaID, 
                                    InvestimentoID = @InvestimentoID,
                                    TransacaoID = @TransacaoID,
                                    InvestimentoCotacaoID = @InvestimentoCotacaoID,
                                    QtCotas = @QtCotas,
                                    VrBruto = @VrBruto,
                                    VrLiquido = @VrLiquido,
                                    VrDespesa = @VrDespesa
                                    WHERE MovimentoInvestimentoID = @MovimentoInvestimentoID;";

                cmd.Parameters.AddWithValue("@MovimentoContaID", modelo.MovimentoContaID);
                cmd.Parameters.AddWithValue("@InvestimentoID", modelo.InvestimentoID);
                cmd.Parameters.AddWithValue("@TransacaoID", modelo.TransacaoID);
                cmd.Parameters.AddWithValue("@InvestimentoCotacaoID", investimentoCotacaoID);
                cmd.Parameters.AddWithValue("@QtCotas", modelo.QtCotas);
                cmd.Parameters.AddWithValue("@VrBruto", modelo.VrBruto);
                cmd.Parameters.AddWithValue("@VrLiquido", modelo.VrLiquido);
                cmd.Parameters.AddWithValue("@VrDespesa", modelo.VrDespesa);
                cmd.Parameters.AddWithValue("@MovimentoInvestimentoID", modelo.MovimentoInvestimentoID);

                cmd.ExecuteNonQuery();

                // Tenta atualizar a cotação; se ela for proveniente da CVM não atualiza.
                cmd.Parameters.Clear();
                cmd.CommandText = @"UPDATE InvestimentoCotacao
                                    SET VrCotacao = @VrCotacao
                                    WHERE InvestimentoCotacaoID = @InvestimentoCotacaoID
                                    AND   CotacaoDaCVM = 0;";

                cmd.Parameters.AddWithValue("@VrCotacao", modelo.VrCotacao);
                cmd.Parameters.AddWithValue("@InvestimentoCotacaoID", investimentoCotacaoID);

                cmd.ExecuteNonQuery();

                // Apaga os lançamentos de despesas de aplicação, abaixo serão reinseridos.
                cmd.Parameters.Clear();
                cmd.CommandText =
                    "DELETE FROM movimentoinvestimentodespesa " +
                    "WHERE MovimentoInvestimentoID = @MovimentoInvestimentoID;";
                cmd.Parameters.AddWithValue("@MovimentoInvestimentoID", modelo.MovimentoInvestimentoID);
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandText =
                    "DELETE FROM MovimentoConta " +
                    "WHERE DoMovimentoContaID = @MovimentoContaID " +
                    "AND Sistema = 1;";
                cmd.Parameters.AddWithValue("@MovimentoContaID", modelo.MovimentoContaID);
                cmd.ExecuteNonQuery();

                // Insere as despesas do investimento
                foreach (MovimentoInvestimentoDespesa linha in despesas)
                {
                    lancamentoID = IDdoLancamento(modelo.UsuarioID, linha.Parceiro, false);

                    cmd.Parameters.Clear();
                    cmd.CommandText =
                        "INSERT INTO MovimentoInvestimentoDespesa " +
                        "(MovimentoInvestimentoID, CategoriaID, Valor, Ordem) " +
                        "VALUES " +
                        "(@MovimentoInvestimentoID, @CategoriaID, @Valor, @Ordem);";

                    cmd.Parameters.AddWithValue("@MovimentoInvestimentoID", modelo.MovimentoInvestimentoID);
                    cmd.Parameters.AddWithValue("@CategoriaID", linha.CategoriaID);
                    cmd.Parameters.AddWithValue("@Valor", linha.Valor);
                    cmd.Parameters.AddWithValue("@Ordem", linha.Ordem);
                    cmd.ExecuteNonQuery();

                    if (linha.Valor != 0)
                    {
                        // Insere o movimento de despesa para aparecer no grid.
                        cmd.Parameters.Clear();
                        cmd.CommandText =
                            "INSERT INTO MovimentoConta " +
                            "(UsuarioID, ContaID, Data, Numero, LancamentoID, Descricao, CategoriaID, " +
                            " GrupoCategoriaID, CrdDeb, Credito, Debito, Conciliacao, Sistema, DoMovimentoContaID) " +
                            "VALUES " +
                            "(@UsuarioID, @ContaID, @Data, @Numero, @LancamentoID, @Descricao, @CategoriaID, " +
                            " @GrupoCategoriaID, @CrdDeb, @Credito, @Debito, @Conciliacao, @Sistema, @DoMovimentoContaID); " +

                            "SELECT CAST(@@IDENTITY AS INT) AS MovimentoContaID;";

                        cmd.Parameters.AddWithValue("@UsuarioID", modelo.UsuarioID);
                        cmd.Parameters.AddWithValue("@ContaID", modelo.ContaID);
                        cmd.Parameters.AddWithValue("@Data", modelo.Data);
                        cmd.Parameters.AddWithValue("@Numero", (object)modelo.Numero ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@LancamentoID", lancamentoID);
                        cmd.Parameters.AddWithValue("@Descricao", modelo.Descricao);
                        cmd.Parameters.AddWithValue("@CategoriaID", linha.CategoriaID);
                        cmd.Parameters.AddWithValue("@GrupoCategoriaID", (object)modelo.GrupoCategoriaID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CrdDeb", "D");
                        cmd.Parameters.AddWithValue("@Credito", DBNull.Value);
                        cmd.Parameters.AddWithValue("@Debito", linha.Valor);
                        cmd.Parameters.AddWithValue("@Conciliacao", modelo.Conciliacao);
                        cmd.Parameters.AddWithValue("@Sistema", true);
                        cmd.Parameters.AddWithValue("@DoMovimentoContaID", modelo.MovimentoContaID);

                        cmd.ExecuteNonQuery();
                    }
                }

                transacao.Commit();

                return modelo.MovimentoContaID;
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao alterar o lançamento de investimento.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private int IDdoLancamento(int usuarioID, string conteudo, bool apagaNaoUtilizados = true)
        {
            LancamentoDAL dal = new LancamentoDAL();
            return Math.Abs(dal.IDdoLancamento(usuarioID, conteudo, apagaNaoUtilizados));
        }
    }
}
