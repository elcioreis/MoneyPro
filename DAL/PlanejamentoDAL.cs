using Modelos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAL
{
    public class PlanejamentoDAL
    {
        public DataTable Listar(int usuarioID, Boolean TodosPlanejamentos)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(@"SELECT PlanejamentoID, UsuarioID, Apelido, Descricao, ContaID, Conta, ValorFixo,
                                                       LancamentoID, Lancamento, CategoriaID, Categoria, GrupoCategoriaID,
                                                       GrupoCategoria, CrdDeb, Total, DtInicial, Dia, DiaFixo,
                                                       CASE WHEN CrdDeb = 'C' THEN Valor ELSE -Valor END Valor,
                                                       AdiaSeNaoUtil, DiferencaNaPrimeira, Repeticoes, Processados,
                                                       TipoDia, TipoTotal, SeNaoUtil, SeDiferenca, Ativo,
                                                       UltimoDiaMes, Observacao,
                                                       dbo.fncNumeroProximoEvento(PlanejamentoID) Parcela
                                                FROM vw_planejamento
                                                WHERE UsuarioID = @UsuarioID " +

                                                (!TodosPlanejamentos ? " AND Ativo = 1 " : "") +

                                                "ORDER BY Ativo DESC, DtInicial ASC, Descricao ASC;", conn);
            // Atribui os parâmetros
            query.Parameters.AddWithValue("@UsuarioID", usuarioID);
            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public DataTable Planejamento(int planejamentoID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(@"SELECT PlanejamentoID, UsuarioID, ContaID, LancamentoID, CategoriaID,
                                                       GrupoCategoriaID, Descricao, CrdDeb, Valor, Total, DtInicial,
                                                       Dia, DiaFixo, AdiaSeNaoUtil, DiferencaNaPrimeira, Repeticoes,
                                                       Processados, Apelido, ValorFixo, Ativo, UltimoDiaMes, Observacao,
                                                       CAST(0 AS DECIMAL(18,4)) ValorParcela   
                                                FROM Planejamento
                                                WHERE PlanejamentoID = @PlanejamentoID;", conn);

            // Atribui os parâmetros
            query.Parameters.AddWithValue("@PlanejamentoID", planejamentoID);
            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public bool IncluirPlanejamento(Planejamento modelo)
        {
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"INSERT INTO Planejamento
                                        (UsuarioID, ContaID, LancamentoID, CategoriaID, GrupoCategoriaID,
                                         Descricao, CrdDeb, Valor, Total, DtInicial, Dia, DiaFixo, AdiaSeNaoUtil,
                                         DiferencaNaPrimeira, Repeticoes, Processados, Apelido, ValorFixo,
                                         UltimoDiaMes, Observacao)
                                        VALUES
                                        (@UsuarioID, @ContaID, @LancamentoID, @CategoriaID, @GrupoCategoriaID,
                                         @Descricao, @CrdDeb, @Valor, @Total, @DtInicial, @Dia, @DiaFixo, @AdiaSeNaoUtil,
                                         @DiferencaNaPrimeira, @Repeticoes, @Processados, @Apelido, @ValorFixo,
                                         @UltimoDiaMes, @Observacao);";

                    cmd.Parameters.AddWithValue("@UsuarioID", modelo.UsuarioID);
                    cmd.Parameters.AddWithValue("@ContaID", modelo.ContaID);
                    cmd.Parameters.AddWithValue("@LancamentoID", modelo.LancamentoID);
                    cmd.Parameters.AddWithValue("@CategoriaID", modelo.CategoriaID);
                    cmd.Parameters.AddWithValue("@GrupoCategoriaID", (object)modelo.GrupoCategoriaID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Apelido", modelo.Apelido);
                    cmd.Parameters.AddWithValue("@Descricao", modelo.Descricao);
                    cmd.Parameters.AddWithValue("@CrdDeb", modelo.CrdDeb);
                    cmd.Parameters.AddWithValue("@Valor", modelo.Valor);
                    cmd.Parameters.AddWithValue("@Total", modelo.Total);
                    cmd.Parameters.AddWithValue("@DtInicial", modelo.DtInicial);
                    cmd.Parameters.AddWithValue("@Dia", modelo.Dia);
                    cmd.Parameters.AddWithValue("@DiaFixo", modelo.DiaFixo);
                    cmd.Parameters.AddWithValue("@AdiaSeNaoUtil", modelo.AdiaSeNaoUtil);
                    cmd.Parameters.AddWithValue("@DiferencaNaPrimeira", modelo.DiferencaNaPrimeira);
                    cmd.Parameters.AddWithValue("@Repeticoes", modelo.Repeticoes);
                    cmd.Parameters.AddWithValue("@Processados", modelo.Processados);
                    cmd.Parameters.AddWithValue("@ValorFixo", modelo.ValorFixo);
                    cmd.Parameters.AddWithValue("@UltimoDiaMes", (object)modelo.UltimoDiaMes ?? 0);
                    cmd.Parameters.AddWithValue("@Observacao", (object)modelo.Observacao ?? DBNull.Value);


                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        public bool AlterarPlanejamento(Planejamento modelo)
        {
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"UPDATE Planejamento 
                                        SET ContaID = @ContaID,
                                            LancamentoID = @LancamentoID,
                                            CategoriaID = @CategoriaID,
                                            GrupoCategoriaID = @GrupoCategoriaID,
                                            Descricao = @Descricao,
                                            CrdDeb = @CrdDeb,
                                            Valor = @Valor,
                                            Total = @Total,
                                            DtInicial = @DtInicial,
                                            Dia = @Dia,
                                            DiaFixo = @DiaFixo,
                                            AdiaSeNaoUtil = @AdiaSeNaoUtil,
                                            DiferencaNaPrimeira = @DiferencaNaPrimeira,
                                            Repeticoes = @Repeticoes,
                                            Processados = @Processados,
                                            Apelido = @Apelido,
                                            Ativo = @Ativo,
                                            UltimoDiaMes = @UltimoDiaMes,
                                            Observacao = @Observacao,
                                            ValorFixo = @ValorFixo
                                        WHERE PlanejamentoID = @PlanejamentoID;";

                    cmd.Parameters.AddWithValue("@UsuarioID", modelo.UsuarioID);
                    cmd.Parameters.AddWithValue("@ContaID", modelo.ContaID);
                    cmd.Parameters.AddWithValue("@LancamentoID", modelo.LancamentoID);
                    cmd.Parameters.AddWithValue("@CategoriaID", modelo.CategoriaID);
                    cmd.Parameters.AddWithValue("@GrupoCategoriaID", (object)modelo.GrupoCategoriaID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Apelido", modelo.Apelido);
                    cmd.Parameters.AddWithValue("@Descricao", modelo.Descricao);
                    cmd.Parameters.AddWithValue("@CrdDeb", modelo.CrdDeb);
                    cmd.Parameters.AddWithValue("@Valor", modelo.Valor);
                    cmd.Parameters.AddWithValue("@Total", modelo.Total);
                    cmd.Parameters.AddWithValue("@DtInicial", modelo.DtInicial);
                    cmd.Parameters.AddWithValue("@Dia", modelo.Dia);
                    cmd.Parameters.AddWithValue("@DiaFixo", modelo.DiaFixo);
                    cmd.Parameters.AddWithValue("@AdiaSeNaoUtil", modelo.AdiaSeNaoUtil);
                    cmd.Parameters.AddWithValue("@DiferencaNaPrimeira", modelo.DiferencaNaPrimeira);
                    cmd.Parameters.AddWithValue("@Repeticoes", modelo.Repeticoes);
                    cmd.Parameters.AddWithValue("@Processados", modelo.Processados);
                    cmd.Parameters.AddWithValue("@Ativo", modelo.Ativo);
                    cmd.Parameters.AddWithValue("@PlanejamentoID", modelo.PlanejamentoID);
                    cmd.Parameters.AddWithValue("@UltimoDiaMes", (object)modelo.UltimoDiaMes ?? 0);
                    cmd.Parameters.AddWithValue("@Observacao", (object)modelo.Observacao ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ValorFixo", modelo.ValorFixo);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Erro na alteração do planejamento.\n" + e.Message, "Erro",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);

                        return false;
                    }
                }
            }
        }

        public Boolean ExcluirPlanejamento(int planejamentoID)
        {
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"DELETE FROM Planejamento 
                                        WHERE PlanejamentoID = @PlanejamentoID;";

                    cmd.Parameters.AddWithValue("@PlanejamentoID", planejamentoID);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        public bool ExcluirPlanejamento(int contaID, int lancamentoID, int categoriaID)
        {
            int? planejamentoID;

            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT PlanejamentoID
                                        FROM Planejamento
                                        WHERE ContaID = @ContaID
                                        AND   LancamentoID = @LancamentoID
                                        AND   CategoriaID = @CategoriaID;";

                    cmd.Parameters.AddWithValue("@ContaID", contaID);
                    cmd.Parameters.AddWithValue("@LancamentoID", lancamentoID);
                    cmd.Parameters.AddWithValue("@CategoriaID", categoriaID);

                    try
                    {
                        planejamentoID = (int?)cmd.ExecuteScalar();
                        return (planejamentoID != null);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        public bool EfetivarPlanejamento(Planejamento modelo, out DateTime dataProximoEvento)
        {
            // Insere o planejamento na movimentação de conta e muda as 
            // informações do planejamento para o próximo período.

            int registro = -1;
            int transferenciaPara = -1;
            int categoriaPara = -1;

            string Conciliacao = " ";

            if (modelo.DtInicial > DateTime.Now)
            {
                // Se data maior que agora, marca o lançamento como futuro.
                Conciliacao = "F";
            }

            decimal? valor;

            if (!modelo.Total)
            {
                valor = modelo.Valor;
            }
            else
            {
                valor = modelo.ValorParcela;
            }

            decimal? Credito;
            decimal? Debito;

            if (modelo.CrdDeb == "C")
            {
                Credito = valor;
                Debito = null;
            }
            else
            {
                Credito = null;
                Debito = valor;
            }

            // 1 como parâmetro representa o próximo evento.
            dataProximoEvento = ProximoEventoPlanejamento(modelo.PlanejamentoID, 1);

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            conn.Open();

            SqlTransaction transacao = conn.BeginTransaction("Movimentacao");

            SqlCommand cmd = conn.CreateCommand();

            try
            {

                cmd.Transaction = transacao;

                // Verifica se o movimento usa uma categoria de transferência 
                // (se sim, retornará o número da conta, caso contrário retornará negativo)
                cmd.CommandText = "SELECT COALESCE(ContaID, -1) FROM Categoria WHERE CategoriaID = @CategoriaID";
                cmd.Parameters.AddWithValue("@CategoriaID", modelo.CategoriaID);
                transferenciaPara = (int)cmd.ExecuteScalar();
                cmd.Parameters.Clear();

                // Retornará o ID do MovimentoConta
                cmd.CommandText = @"INSERT INTO MovimentoConta
                                    (UsuarioID, ContaID, Data, Numero, LancamentoID,
                                     Descricao, CategoriaID, GrupoCategoriaID, CrdDeb, Credito, Debito,
                                     Conciliacao, PilhaMovimentoContaID, DoMovimentoContaID,
                                     PlanejamentoID, PlanejamentoRepeticao, Sistema)
                                    VALUES
                                    (@UsuarioID, @ContaID, @Data, @Numero, @LancamentoID,
                                     @Descricao, @CategoriaID, @GrupoCategoriaID, @CrdDeb, @Credito, @Debito,
                                     @Conciliacao, @PilhaMovimentoContaID, @DoMovimentoContaID,
                                     @PlanejamentoID, @PlanejamentoRepeticao, @Sistema);

                                    SELECT CAST(@@IDENTITY AS INT) AS MovimentoContaID;";

                cmd.Parameters.AddWithValue("@UsuarioID", modelo.UsuarioID);
                cmd.Parameters.AddWithValue("@ContaID", modelo.ContaID);
                cmd.Parameters.AddWithValue("@Data", modelo.DtInicial);
                cmd.Parameters.AddWithValue("@Numero", DBNull.Value);
                cmd.Parameters.AddWithValue("@LancamentoID", modelo.LancamentoID);
                cmd.Parameters.AddWithValue("@Descricao", (object)modelo.Descricao ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CategoriaID", modelo.CategoriaID);
                cmd.Parameters.AddWithValue("@GrupoCategoriaID", (object)modelo.GrupoCategoriaID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CrdDeb", (object)modelo.CrdDeb ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Credito", (object)Credito ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Debito", (object)Debito ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Conciliacao", Conciliacao);
                cmd.Parameters.AddWithValue("@PilhaMovimentoContaID", DBNull.Value);
                cmd.Parameters.AddWithValue("@DoMovimentoContaID", DBNull.Value);
                cmd.Parameters.AddWithValue("@PlanejamentoID", modelo.PlanejamentoID);
                cmd.Parameters.AddWithValue("@PlanejamentoRepeticao", modelo.Processados + 1);
                cmd.Parameters.AddWithValue("@Sistema", false);

                // Retornará o ID do MovimentoConta
                registro = (int)cmd.ExecuteScalar();

                cmd.Parameters.Clear();

                if (!string.IsNullOrWhiteSpace(modelo.Observacao))
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = @"INSERT INTO MovimentoContaObservacao
                                        (MovimentoContaID, Observacao)
                                        VALUES
                                        (@MovimentoContaID, @Observacao);";
                    cmd.Parameters.AddWithValue("@MovimentoContaID", registro);
                    cmd.Parameters.AddWithValue("@Observacao", modelo.Observacao.Trim());

                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                }

                // Se é movimento de transferência entre contas, aqui será criada a contra partida.
                if (transferenciaPara > 0)
                {
                    // Há conta de transferência, preciso da categoria de transferência
                    cmd.CommandText = "SELECT CategoriaID FROM Categoria where ContaID = @ContaID";
                    cmd.Parameters.AddWithValue("@ContaID", modelo.ContaID);
                    categoriaPara = (int)cmd.ExecuteScalar();

                    cmd.Parameters.Clear();
                    // A categoria está ligada a uma conta, logo é uma transferência.
                    cmd.CommandText = @"INSERT INTO MovimentoConta
                                        (UsuarioID, ContaID, Data, Numero, LancamentoID,
                                         Descricao, CategoriaID, GrupoCategoriaID, CrdDeb, Credito, Debito,
                                         Conciliacao, PilhaMovimentoContaID, DoMovimentoContaID, Sistema)
                                        VALUES
                                        (@UsuarioID, @ContaID, @Data, @Numero, @LancamentoID,
                                         @Descricao, @CategoriaID, @GrupoCategoriaID, @CrdDeb, @Credito, @Debito,
                                         @Conciliacao, @PilhaMovimentoContaID, @DoMovimentoContaID, @Sistema);

                                        SELECT CAST(@@IDENTITY AS INT) AS MovimentoContaID;";

                    cmd.Parameters.AddWithValue("@UsuarioID", modelo.UsuarioID);
                    // Conta ID é o número da conta ligada à categoria
                    cmd.Parameters.AddWithValue("@ContaID", transferenciaPara);
                    cmd.Parameters.AddWithValue("@Data", modelo.DtInicial);
                    cmd.Parameters.AddWithValue("@Numero", DBNull.Value);
                    cmd.Parameters.AddWithValue("@LancamentoID", modelo.LancamentoID);
                    cmd.Parameters.AddWithValue("@Descricao", (object)modelo.Descricao ?? DBNull.Value);
                    // CategoriaID é igual a categoria ligada à conta de origem.
                    cmd.Parameters.AddWithValue("@CategoriaID", categoriaPara);
                    cmd.Parameters.AddWithValue("@GrupoCategoriaID", (object)modelo.GrupoCategoriaID ?? DBNull.Value);

                    // Se a origem é um débito, o destino será um crédito e vice-versa.
                    if (modelo.CrdDeb == "D")
                        cmd.Parameters.AddWithValue("@CrdDeb", "C");
                    else
                        cmd.Parameters.AddWithValue("@CrdDeb", "D");

                    // Os campos crédito e débito têm as propriedades do modelo invertido para a contra partida
                    cmd.Parameters.AddWithValue("@Credito", (object)Debito ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Debito", (object)Credito ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Conciliacao", Conciliacao);
                    cmd.Parameters.AddWithValue("@PilhaMovimentoContaID", DBNull.Value);
                    // DoMovimentoContaID recebe o número do registro criado no primeiro insert dessa mesma rotina.
                    cmd.Parameters.AddWithValue("@DoMovimentoContaID", registro);
                    cmd.Parameters.AddWithValue("@Sistema", false);

                    registro = (int)cmd.ExecuteScalar();

                    if (!string.IsNullOrWhiteSpace(modelo.Observacao))
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = @"INSERT INTO MovimentoContaObservacao
                                            (MovimentoContaID, Observacao)
                                            VALUES
                                            (@MovimentoContaID, @Observacao);";
                        cmd.Parameters.AddWithValue("@MovimentoContaID", registro);
                        cmd.Parameters.AddWithValue("@Observacao", modelo.Observacao.Trim());

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }

                #region Atualiza Planejamento

                // É ativo se o número de processados + 1 for menor que o número de repetições 
                // ou se não há fim determinado para as repetições
                bool ativo = ((modelo.Processados + 1) < modelo.Repeticoes) || (modelo.Repeticoes == 0);

                // Atualiza o planejamento, informando aumentando a parcela e colocando a próxima data.
                cmd.CommandText = "UPDATE Planejamento SET " +
                                  "Valor = @Valor, " +
                                  // Somente se for ativo muda a data
                                  (string)((ativo) ? "DtInicial = @DtInicial, " : "") +
                                  "Processados = Processados + 1, " +
                                  "Ativo = @Ativo " +
                                  "WHERE PlanejamentoID = @PlanejamentoID;";

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@DtInicial", dataProximoEvento);
                cmd.Parameters.AddWithValue("@Valor", modelo.Valor);
                cmd.Parameters.AddWithValue("@PlanejamentoID", modelo.PlanejamentoID);
                cmd.Parameters.AddWithValue("@Ativo", ativo);

                cmd.ExecuteNonQuery();

                #endregion AtualizaPlanejamento;

                transacao.Commit();
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao incluir movimento de conta.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return (registro > 0);
        }

        public DateTime ProximoEventoPlanejamento(int planejamentoID, int parcela)
        {

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("SELECT dbo.fncProximoEventoPlanejamento(@PlanejamentoID, @Parcela) ProximoEvento;", conn);

            cmd.Parameters.AddWithValue("@PlanejamentoID", planejamentoID);
            cmd.Parameters.AddWithValue("@Parcela", parcela);

            conn.Open();
            try
            {
                return (DateTime)cmd.ExecuteScalar();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public DateTime PrimeiroDiaPlanejamento(int usuarioID)
        {

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            // Devolve a menor data encontrada ou o dia corrente se não houver conteúdo na tabela
            SqlCommand cmd = new SqlCommand(@"SELECT
                                              COALESCE(MIN(DtInicial), CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME)) DtInicial
                                              FROM vw_planejamento
                                              WHERE UsuarioID = @UsuarioID AND Ativo = 1;", conn);

            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

            conn.Open();
            try
            {
                return (DateTime)cmd.ExecuteScalar();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
