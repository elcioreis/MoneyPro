using Modelos;
using OFXSharp;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MovimentoContaDAL
    {
        public DataTable ListarMovimentosConta(int contaID, string filtro)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            using (SqlDataAdapter da = new SqlDataAdapter())
            {

                // A ordem da query abaixo deve ser sempre a mesma ordem da procedure que calcula o balanço da conta:
                // 1) stpAtualizaBalancoConta para todos os movimentos da conta
                // 2) stpAtualizaBalancoContaPeriodo para os movimentos da conta a partir de uma determinada data

                // Instancia um comando
                SqlCommand query = new SqlCommand(@"SELECT vmMC.MovimentoContaID, vmMC.UsuarioID, vmMC.ContaID, vmMC.Data, vmMC.Numero, 
                                                           vmMC.LancamentoID, vmMC.Descricao, vmMC.CategoriaID, vmMC.GrupoCategoriaID, 
                                                           vmMC.CrdDeb, vmMC.Credito, vmMC.Debito, vmMC.Valor, vmMC.Balanco, vmMC.Conciliacao,
                                                           vmMC.PilhaMovimentoContaID, vmMC.DoMovimentoContaID, vmMC.Sistema, 
                                                           vmMC.MovimentoInvestimentoID, vmMC.InvestimentoID, vmMC.TransacaoID, vmMC.Transacao, 
                                                           vmMC.InvestimentoCotacaoID, vmMC.QtCotas, vmMC.VrBruto, vmMC.VrLiquido, vmMC.SldCotas,
                                                           vmMC.VrCotacao, vmMC.VrDespesa, vmMC.Legenda, vmMC.IdentificacaoOFX, 
                                                           vmMC.CotacaoMoedaID, vmMC.Passo, 1 MovimentosAgrupados, 
                                                           vmMC.PlanejamentoID, MObs.Observacao
                                                    FROM vw_MovimentacaoConta vmMC
                                                    LEFT JOIN MovimentoContaObservacao MObs ON MObs.MovimentoContaID = vmMC.MovimentoContaID
                                                    WHERE ContaID = @ContaID " +
                                                    filtro + " " +
                                                   @"ORDER BY CASE WHEN Conciliacao IN ('A','F') THEN 1 ELSE 0 END ASC, 
                                                              Data ASC, MovimentoContaID;", conn);
                // Atribui os parâmetros
                query.Parameters.AddWithValue("@ContaID", contaID);
                // Coloca a query no adaptador
                da.SelectCommand = query;
                // Popula a tabela
                da.Fill(table);
            }
            // Retorn a tabela
            return table;
        }

        public DataTable ListarMovimentosContaResumo(int contaID, string filtro)
        {
            DateTime dataMinima = PrimeiroDiaNaoReconciliado(contaID);
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                // A ordem da query abaixo deve ser sempre a mesma ordem da procedure que calcula o balanço da conta:
                // 1) stpAtualizaBalancoConta para todos os movimentos da conta
                // 2) stpAtualizaBalancoContaPeriodo para os movimentos da conta a partir de uma determinada data

                // Instancia um comando
                SqlCommand query = new SqlCommand(
                    @"SELECT vmMC.MovimentoContaID, vmMC.UsuarioID, vmMC.ContaID, vmMC.Data, vmMC.Numero, vmMC.LancamentoID, vmMC.Descricao,  
                             vmMC.CategoriaID, vmMC.GrupoCategoriaID, vmMC.CrdDeb, vmMC.Credito, vmMC.Debito, vmMC.Valor, vmMC.Balanco, 
                             vmMC.Conciliacao, vmMC.PilhaMovimentoContaID, vmMC.DoMovimentoContaID, vmMC.Sistema, vmMC.MovimentoInvestimentoID, 
                             vmMC.InvestimentoID, vmMC.TransacaoID, vmMC.Transacao, vmMC.InvestimentoCotacaoID, vmMC.QtCotas, vmMC.VrBruto, 
                             vmMC.VrLiquido, vmMC.SldCotas, vmMC.VrCotacao, vmMC.VrDespesa, vmMC.Legenda, vmMC.IdentificacaoOFX, 
                             vmMC.CotacaoMoedaID, vmMC.Passo, 1 MovimentosAgrupados, vmMC.PlanejamentoID,
                             CASE WHEN vmMC.Conciliacao IN ('A','F') THEN 1 ELSE 0 END Conc,
                             MObs.Observacao
                      FROM vw_MovimentacaoConta vmMC  
                      LEFT JOIN MovimentoContaObservacao MObs ON MObs.MovimentoContaID = vmMC.MovimentoContaID
                      WHERE vmMC.ContaID = @ContaID  
                      AND   vmMC.Data >= @DataMinima " +

                    filtro + "  " +

                    @"UNION ALL  

                      SELECT -9999, vmMC.UsuarioID, vmMC.ContaID, DATEADD(Day, -1, @DataMinima) Data, NULL, NULL,  
                             'Reconciliados até ' + CONVERT(VARCHAR(10), DATEADD(Day, -1, @DataMinima), 103) Descricao,  
                             Ctgr.CategoriaID, NULL, NULL,  
                             SUM(vmMC.Credito) Credito, SUM(vmMC.Debito) Debito,  
                             NULL Valor, SUM(vmMC.Valor) Balanco, vmMC.Conciliacao,  
                             NULL, 0 DoMovimentoContaID, CAST(1 AS BIT) Sistema, NULL, NULL, NULL, NULL,  
                             NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0 Legenda, NULL, NULL, 0 Passo, 
                             COUNT(*) MovimentosAgrupados, 0 PlanejamentoID,
                             -1 Conc, NULL Observacao
                      FROM vw_MovimentacaoConta vmMC  
                           JOIN Categoria Ctgr ON Ctgr.ContaID = vmMC.ContaID  
                      WHERE vmMC.ContaID = @ContaID  
                      AND   vmMC.Data < @DataMinima " +

                    filtro + "  " +

                    @"GROUP BY vmMC.UsuarioID, vmMC.ContaID, vmMC.Conciliacao, Ctgr.CategoriaID  
                      ORDER BY CASE WHEN Conciliacao IN ('A','F') THEN 1 ELSE 0 END ASC, 
                               Data ASC, MovimentoContaID;", conn);

                // Atribui os parâmetros
                query.Parameters.AddWithValue("@ContaID", contaID);
                query.Parameters.AddWithValue("@DataMinima", dataMinima);

                // Coloca a query no adaptador
                da.SelectCommand = query;
                // Popula a tabela
                da.Fill(table);
            }
            // Retorn a tabela
            return table;
        }

        public DataTable ListarNaoConciliados(int contaID, DateTime dataMinima)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(@"SELECT vmMC.MovimentoContaID, vmMC.UsuarioID, vmMC.ContaID, vmMC.Data, vmMC.Numero, vmMC.Descricao,
                                                       vmMC.LancamentoID, Lnct.Apelido Lancamento,
                                                       vmMC.CategoriaID, Ctgr.Apelido Categoria,
                                                       vmMC.GrupoCategoriaID, Grpo.Apelido GrupoCategoria,
                                                       vmMC.CrdDeb, vmMC.Credito, vmMC.Debito, vmMC.Valor, vmMC.Balanco, vmMC.Conciliacao,
                                                       vmMC.PilhaMovimentoContaID, vmMC.DoMovimentoContaID, vmMC.Sistema, vmMC.MovimentoInvestimentoID, 
                                                       vmMC.InvestimentoID, vmMC.TransacaoID, vmMC.Transacao, vmMC.InvestimentoCotacaoID, vmMC.QtCotas, 
                                                       vmMC.VrBruto, vmMC.VrLiquido, vmMC.SldCotas, vmMC.VrCotacao, vmMC.VrDespesa, vmMC.Legenda, 
                                                       vmMC.IdentificacaoOFX
                                                FROM vw_MovimentacaoConta vmMC
                                                INNER JOIN Categoria Ctgr ON Ctgr.CategoriaID = vmMC.CategoriaID
                                                INNER JOIN Lancamento Lnct ON Lnct.LancamentoID = vmMC.LancamentoID
                                                LEFT JOIN GrupoCategoria Grpo ON Grpo.GrupoCategoriaID = vmMC.GrupoCategoriaID
                                                WHERE vmMC.ContaID = @ContaID
                                                AND vmMC.Data >= @DataMinima
                                                ORDER BY vmMC.Data ASC, CASE WHEN vmMC.Valor >= 0 THEN 1 ELSE 2 END ASC;", conn);

            // Atribui os parâmetros
            query.Parameters.AddWithValue("@ContaID", contaID);
            query.Parameters.AddWithValue("@DataMinima", dataMinima);
            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public string ConsultaTextoCDB(int contaID, string numeroCDB)
        {
            string texto = "";

            SqlConnection conn = new SqlConnection(Dados.Conexao);
            SqlCommand cmd = new SqlCommand(@"SELECT 
                                                  'Sobre' + substring(MCa.Descricao, CHARINDEX(' ', MCa.Descricao), 100) Descricao
                                              FROM MovimentoConta MCa
                                              WHERE MCa.ContaID = @ContaID
                                              AND MCa.Numero = @NumeroCDB
                                              AND MCa.Data = (SELECT MIN(Data) 
                                                              FROM MovimentoConta MCb 
                                                              WHERE MCb.ContaID = @ContaID
                                                              AND MCb.Numero = @NumeroCDB)", conn);
            cmd.Parameters.AddWithValue("@ContaID", contaID);
            cmd.Parameters.AddWithValue("@NumeroCDB", numeroCDB);

            try
            {
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    // Verifica se há linhas
                    if (dr.HasRows)
                    {
                        // posiciona no primeiro registro
                        dr.Read();
                        // Há somente um campo na query
                        texto = dr.GetString(0);
                    }
                }
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return texto;
        }

        public decimal ConsultaSaldoCDB(int contaID, string numeroCDB)
        {
            decimal saldo = 0;

            SqlConnection conn = new SqlConnection(Dados.Conexao);
            SqlCommand cmd = new SqlCommand(@"SELECT COALESCE(SUM(mc.Credito), 0) - COALESCE(SUM(mc.Debito), 0) Saldo
                                              FROM MovimentoConta mc
                                              WHERE mc.ContaID = @ContaID
                                              AND   mc.Numero = @NumeroCDB;", conn);
            cmd.Parameters.AddWithValue("@ContaID", contaID);
            cmd.Parameters.AddWithValue("@NumeroCDB", numeroCDB);

            try
            {
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    // Verifica se há linhas
                    if (dr.HasRows)
                    {
                        // posiciona no primeiro registro
                        dr.Read();
                        // Há somente um campo na query
                        saldo = dr.GetDecimal(0);
                    }
                }
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return saldo;
        }

        public DataTable ListarConteudoPesquisa(int contaID, MovimentoContaPesquisa mcPesquisa)
        {
            // Cria uma string para filtragem
            StringBuilder filtro = new StringBuilder();
            filtro.Append("WHERE vmMC.ContaID = @ContaID ");

            if (mcPesquisa.ParceiroID != null)
            {
                filtro.Append("AND vmMC.LancamentoID = " + mcPesquisa.ParceiroID + " ");
            }

            if (mcPesquisa.CategoriaID != null)
            {
                filtro.Append("AND (vmMC.CategoriaID = " + mcPesquisa.CategoriaID + " OR Pais.CategoriaPaiID = " + mcPesquisa.CategoriaID + ") ");
            }

            if (mcPesquisa.GrupoID != null)
            {
                filtro.Append("AND vmMC.GrupoCategoriaID = " + mcPesquisa.GrupoID + " ");
            }

            if (mcPesquisa.DataDe != null && mcPesquisa.DataAte != null)
            {
                string inicio = ((DateTime)mcPesquisa.DataDe).ToString("yyyy-MM-dd");
                string fim = ((DateTime)mcPesquisa.DataAte).ToString("yyyy-MM-dd");
                filtro.Append("AND CAST(vmMC.Data AS DATE) BETWEEN '" + inicio + "' AND '" + fim + "' ");
            }
            else if (mcPesquisa.DataDe != null && mcPesquisa.DataAte == null)
            {
                string inicio = ((DateTime)mcPesquisa.DataDe).ToString("yyyy-MM-dd");
                filtro.Append("AND CAST(vmMC.Data AS DATE) >= '" + inicio + "' ");
            }
            else if (mcPesquisa.DataDe == null && mcPesquisa.DataAte != null)
            {
                string fim = ((DateTime)mcPesquisa.DataAte).ToString("yyyy-MM-dd");
                filtro.Append("AND CAST(vmMC.Data AS DATE) <= '" + fim + "' ");
            }

            if (mcPesquisa.ValorDe != null && mcPesquisa.ValorAte != null)
            {
                string de = ((double)mcPesquisa.ValorDe).ToString("0.00", CultureInfo.InvariantCulture);
                string ate = ((double)mcPesquisa.ValorAte).ToString("0.00", CultureInfo.InvariantCulture);
                filtro.Append("AND vmMC.Valor BETWEEN " + de + " AND " + ate + " ");
            }
            else if (mcPesquisa.ValorDe != null && mcPesquisa.ValorAte == null)
            {
                string de = ((double)mcPesquisa.ValorDe).ToString("0.00", CultureInfo.InvariantCulture);
                filtro.Append("AND vmMC.Valor >= " + de + " ");
            }
            else if (mcPesquisa.ValorDe == null && mcPesquisa.ValorAte != null)
            {
                string ate = ((double)mcPesquisa.ValorAte).ToString("0.00", CultureInfo.InvariantCulture);
                filtro.Append("AND vmMC.Valor <= " + ate + " ");
            }

            if (mcPesquisa.Descricao != null)
            {
                string descricao = mcPesquisa.Descricao.Trim().ToUpperInvariant();
                filtro.Append("AND UPPER(vmMC.Descricao) LIKE '%" + descricao + "%' ");
            }

            StringBuilder texto = new StringBuilder(@"WITH BASE AS (SELECT vmMC.MovimentoContaID, vmMC.UsuarioID, vmMC.ContaID, vmMC.Data, 
                                                                           vmMC.Numero, vmMC.LancamentoID, vmMC.Descricao, vmMC.CategoriaID,
                                                                           vmMC.GrupoCategoriaID, vmMC.CrdDeb, vmMC.Credito, vmMC.Debito, vmMC.Valor, 
                                                                           CAST(NULL AS NUMERIC(22,10)) Balanco, vmMC.Conciliacao, vmMC.PilhaMovimentoContaID, 
                                                                           vmMC.DoMovimentoContaID, vmMC.Sistema, vmMC.MovimentoInvestimentoID, 
                                                                           vmMC.InvestimentoID, vmMC.TransacaoID, vmMC.Transacao, 
                                                                           vmMC.InvestimentoCotacaoID, vmMC.QtCotas, vmMC.VrBruto, vmMC.VrLiquido, 
                                                                           vmMC.SldCotas, vmMC.VrCotacao, vmMC.VrDespesa, vmMC.Legenda, 
                                                                           vmMC.IdentificacaoOFX, vmMC.CotacaoMoedaID, vmMC.Passo, 1 MovimentosAgrupados, 
                                                                           vmMC.PlanejamentoID, MObs.Observacao
                                                                    FROM vw_MovimentacaoConta vmMC 
                                                                         JOIN Categoria Pais ON Pais.CategoriaID = vmMC.CategoriaID 
                                                                    LEFT JOIN MovimentoContaObservacao MObs ON MObs.MovimentoContaID = vmMC.MovimentoContaID ");

            texto.Append(filtro.ToString() + "), ");

            texto.Append(@"SELECAO AS (SELECT MovimentoContaID, UsuarioID, ContaID, Data, Numero, LancamentoID, Descricao, 
                                              CategoriaID, GrupoCategoriaID, CrdDeb, Credito, Debito, Valor, Balanco,
                                              Conciliacao, PilhaMovimentoContaID, DoMovimentoContaID, Sistema,
                                              MovimentoInvestimentoID, InvestimentoID, TransacaoID, Transacao,
                                              InvestimentoCotacaoID, QtCotas, VrBruto, VrLiquido, SldCotas, VrCotacao,
                                              VrDespesa, Legenda, IdentificacaoOFX, CotacaoMoedaID, Passo, 
                                              MovimentosAgrupados, PlanejamentoID, Observacao
                                       FROM BASE ");

            if (mcPesquisa.Subjacente)
            {
                texto.Append(@"
                               UNION

                               SELECT vmMC.MovimentoContaID, vmMC.UsuarioID, vmMC.ContaID, vmMC.Data, 
                                      vmMC.Numero, vmMC.LancamentoID, vmMC.Descricao, vmMC.CategoriaID,
                                      vmMC.GrupoCategoriaID, vmMC.CrdDeb, vmMC.Credito, vmMC.Debito, vmMC.Valor,
                                      CAST(NULL AS NUMERIC(22, 10)) Balanco, vmMC.Conciliacao, vmMC.PilhaMovimentoContaID,
                                      vmMC.DoMovimentoContaID, vmMC.Sistema, vmMC.MovimentoInvestimentoID,
                                      vmMC.InvestimentoID, vmMC.TransacaoID, vmMC.Transacao,
                                      vmMC.InvestimentoCotacaoID, vmMC.QtCotas, vmMC.VrBruto, vmMC.VrLiquido,
                                      vmMC.SldCotas, vmMC.VrCotacao, vmMC.VrDespesa, vmMC.Legenda,
                                      vmMC.IdentificacaoOFX, vmMC.CotacaoMoedaID, vmMC.Passo, 1 MovimentosAgrupados,
                                      vmMC.PlanejamentoID, MObs.Observacao
                               FROM Base
                                    JOIN vw_MovimentacaoConta vmMC ON vmMC.DoMovimentoContaID = BASE.DoMovimentoContaID
                                    JOIN Categoria Pais ON Pais.CategoriaID = vmMC.CategoriaID
                               LEFT JOIN MovimentoContaObservacao MObs ON MObs.MovimentoContaID = vmMC.MovimentoContaID)");
            }
            else
            {
                texto.Append(" )");
            }

            texto.Append(@"SELECT * FROM SELECAO
                           ORDER BY CASE WHEN Conciliacao IN ('A','F') THEN 1 ELSE 0 END, 
                                 Data, 
                                 CrdDeb, 
                                 DoMovimentoContaID, 
                                 MovimentoContaID");



            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    // Instancia um comando
                    SqlCommand query = new SqlCommand(texto.ToString(), conn);

                    // Atribui os parâmetros
                    query.Parameters.AddWithValue("@ContaID", contaID);
                    // Coloca a query no adaptador
                    da.SelectCommand = query;
                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorna a tabela
            return table;
        }

        public bool UltimoDaPilhaDePlanejamento(int movimentoContaID)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            conn.Open();

            SqlCommand cmd = conn.CreateCommand();

            cmd.Connection = conn;

            try
            {
                // Verifica se o registro pai ou seu dependente estão conciliados
                // (tentativa de apagar ou alterar a partir do pai)
                cmd.CommandText = @"SELECT CAST(CASE 
                                                    WHEN BASE.PlanejamentoRepeticao = BASE.UltimoDaPilha THEN 1 
                                                    ELSE 0 
                                                END AS BIT) UltimoDaPilha
                                    FROM (SELECT MvtC.PlanejamentoID, MvtC.PlanejamentoRepeticao,
                                                 (SELECT MAX(PlanejamentoRepeticao)
                                                  FROM MovimentoConta Todos
                                                  WHERE Todos.PlanejamentoID = MvtC.PlanejamentoID) UltimoDaPilha
                                          FROM MovimentoConta MvtC
                                          WHERE MvtC.MovimentoContaID = @MovimentoContaID) BASE;";

                cmd.Parameters.AddWithValue("@MovimentoContaID", movimentoContaID);

                return (Boolean)cmd.ExecuteScalar();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public string TipoArquivo(int contaID)
        {
            // Ofx é o tipo de arquivo padrão, usado por diversas instituições
            string tipoArquivo = "OFX";

            SqlConnection conn = new SqlConnection(Dados.Conexao);
            SqlCommand cmd = new SqlCommand(@"SELECT UPPER(TipoArquivo) TipoArquivo
                                              FROM Conta
                                              WHERE ContaID = @ContaID", conn);
            cmd.Parameters.AddWithValue("@ContaID", contaID);

            try
            {
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    // Verifica se há linhas (se não há, é porque não encontrou registro com usuário e senha).
                    if (dr.HasRows)
                    {
                        // posiciona no primeiro registro
                        dr.Read();
                        // Há somente um campo na query
                        tipoArquivo = dr.GetString(0);
                    }
                }
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return tipoArquivo;
        }

        public bool AtribuirNovaDataAoMovimento(int movimentoContaID, DateTime dataMovimento)
        {
            using (SqlConnection conexao = new SqlConnection(Dados.Conexao))
            {
                conexao.Open();

                SqlCommand cmd = conexao.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE MovimentoConta
                                    SET Data = @Data
                                    WHERE MovimentoContaID = @MovimentoContaID";
                cmd.Parameters.AddWithValue("Data", dataMovimento);
                cmd.Parameters.AddWithValue("MovimentoContaID", movimentoContaID);

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

        public int Incluir(MovimentoConta modelo)
        {
            int identity = -1;

            SqlConnection conn = new SqlConnection(Dados.Conexao);
            SqlTransaction transacao = null;

            try
            {
                conn.Open();
                transacao = conn.BeginTransaction("Movimentacao");

                SqlCommand cmd = conn.CreateCommand();

                cmd.Transaction = transacao;

                // Se a categoria estiver ligada a uma conta, retorna seu ID, -1 caso contrário
                int transferenciaPara = ContaParaTransferencia(cmd, (int)modelo.CategoriaID);

                // Insere a movimentação e retorna a identidade (MovimentoConta.MovimentoContaID)
                identity = InserirMovimento(cmd, modelo);

                // Grava a observação no lançamento único ou de ida
                GravarObservacao(cmd, identity, modelo.Observacao);

                // Se é movimento de transferência entre contas, aqui será criada a contra partida.
                if (transferenciaPara > 0)
                {
                    // Há conta de transferência, preciso da categoria de transferência
                    modelo.CategoriaID = CategoriaConta(cmd, modelo.ContaID);
                    // ContaID será a conta da contra partida
                    modelo.ContaID = transferenciaPara;

                    if (string.IsNullOrEmpty(modelo.Numero) && modelo.Data != null && ContaEhCDB(cmd, transferenciaPara))
                    {
                        // Se for transferência para conta CDB cria CDB # no formato yyMMdd
                        modelo.Numero = ((DateTime)modelo.Data).ToString("yyMMdd");
                    }

                    // A categoria está ligada a uma conta, logo é uma transferência.
                    InserirContraPartida(cmd, modelo, identity);

                    // Grava a observação no lançamento de chegada
                    GravarObservacao(cmd, identity, modelo.Observacao);
                }

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

            return identity;
        }

        private void GravarObservacao(SqlCommand cmd, int identity, string observacao)
        {
            if (!string.IsNullOrEmpty(observacao))
            {
                try
                {
                    cmd.CommandText = @"INSERT INTO MovimentoContaObservacao
                                    (MovimentoContaID, Observacao)
                                    VALUES
                                    (@MovimentoContaID, @Observacao)";
                    cmd.Parameters.AddWithValue("@MovimentoContaID", identity);
                    cmd.Parameters.AddWithValue("@Observacao", observacao);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    cmd.Parameters.Clear();
                }
            }
        }

        private int InserirMovimento(SqlCommand cmd, MovimentoConta modelo)
        {
            try
            {
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
                cmd.Parameters.AddWithValue("@ContaID", modelo.ContaID);
                cmd.Parameters.AddWithValue("@Data", modelo.Data);
                cmd.Parameters.AddWithValue("@Numero", (object)modelo.Numero ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LancamentoID", modelo.LancamentoID);
                cmd.Parameters.AddWithValue("@Descricao", (object)modelo.Descricao ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CategoriaID", modelo.CategoriaID);
                cmd.Parameters.AddWithValue("@GrupoCategoriaID", (object)modelo.GrupoCategoriaID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CrdDeb", (object)modelo.CrdDeb ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Credito", (object)modelo.Credito ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Debito", (object)modelo.Debito ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Conciliacao", modelo.Conciliacao);
                cmd.Parameters.AddWithValue("@PilhaMovimentoContaID", (object)modelo.PilhaMovimentoContaID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DoMovimentoContaID", (object)modelo.DoMovimentoContaID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Sistema", modelo.Sistema);

                return (int)cmd.ExecuteScalar();
            }
            finally
            {
                cmd.Parameters.Clear();
            }
        }

        private int InserirContraPartida(SqlCommand cmd, MovimentoConta modelo, int identity)
        {
            // A contra partida é gerada sempre que há uma transferência entre contas.

            // Por exemplo, transfere 100,00 da conta correnta para a conta poupança
            // Será efetuado o lançamento a débito na conta corrente no valor de 100,00
            // E haverá o crédito na conta poupança no valor de 100,00, que é a contra partida
            try
            {
                // Insere a movimentação e retorna a identidade (MovimentoConta.MovimentoContaID)
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
                cmd.Parameters.AddWithValue("@ContaID", modelo.ContaID);
                cmd.Parameters.AddWithValue("@Data", modelo.Data);
                cmd.Parameters.AddWithValue("@Numero", (object)modelo.Numero ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LancamentoID", modelo.LancamentoID);
                cmd.Parameters.AddWithValue("@Descricao", (object)modelo.Descricao ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CategoriaID", modelo.CategoriaID);
                cmd.Parameters.AddWithValue("@GrupoCategoriaID", (object)modelo.GrupoCategoriaID ?? DBNull.Value);

                // Se a origem é um débito, o destino será um crédito e vice-versa.
                if (modelo.CrdDeb == "D")
                    cmd.Parameters.AddWithValue("@CrdDeb", "C");
                else
                    cmd.Parameters.AddWithValue("@CrdDeb", "D");

                // Os campos crédito e débito têm as propriedades do modelo invertido
                cmd.Parameters.AddWithValue("@Credito", (object)modelo.Debito ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Debito", (object)modelo.Credito ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Conciliacao", modelo.Conciliacao);
                cmd.Parameters.AddWithValue("@PilhaMovimentoContaID", (object)modelo.PilhaMovimentoContaID ?? DBNull.Value);
                // DoMovimentoContaID recebe o identity gerado na gravação de IDA nessa mesma rotina.
                cmd.Parameters.AddWithValue("@DoMovimentoContaID", identity);
                cmd.Parameters.AddWithValue("@Sistema", modelo.Sistema);

                return (int)cmd.ExecuteScalar();
            }
            finally
            {
                cmd.Parameters.Clear();
            }
        }

        private int ContaParaTransferencia(SqlCommand cmd, int categoriaID)
        {
            // Se a categoria estiver ligada a uma conta, retorna esta conta, caso contrário retorna -1
            try
            {
                cmd.CommandText = @"SELECT COALESCE(ContaID, -1) 
                                    FROM Categoria 
                                    WHERE CategoriaID = @CategoriaID";
                cmd.Parameters.AddWithValue("@CategoriaID", categoriaID);
                return (int)cmd.ExecuteScalar();
            }
            finally
            {
                cmd.Parameters.Clear();
            }
        }

        private int CategoriaConta(SqlCommand cmd, int contaID)
        {
            try
            {
                cmd.CommandText = "SELECT CategoriaID FROM Categoria where ContaID = @ContaID";
                cmd.Parameters.AddWithValue("@ContaID", contaID);
                return (int)cmd.ExecuteScalar();
            }
            finally
            {
                cmd.Parameters.Clear();
            }
        }

        private bool ContaEhCDB(SqlCommand cmd, int contaID)
        {
            try
            {
                cmd.CommandText = @"SELECT TC.CDB 
                                   FROM Conta CT
                                        JOIN TipoConta TC 
                                          ON TC.TipoContaID = CT.TipoContaID
                                   WHERE CT.ContaID = @ContaID";
                cmd.Parameters.AddWithValue("@ContaID", contaID);
                return (bool)cmd.ExecuteScalar();
            }
            finally
            {
                cmd.Parameters.Clear();
            }
        }

        public int Alterar(MovimentoConta modelo)
        {
            int registro = -1;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            conn.Open();

            SqlTransaction transacao = conn.BeginTransaction("Movimentacao");

            SqlCommand cmd = conn.CreateCommand();

            try
            {
                cmd.Transaction = transacao;

                // Verifica se há contra partida da transferência (se houver, pegará o número, caso contrario retornará -1).
                cmd.CommandText = "SELECT COALESCE((SELECT MIN(MovimentoContaID) FROM MovimentoConta WHERE DoMovimentoContaID = @MovimentoContaID), -1);";
                cmd.Parameters.AddWithValue("@MovimentoContaID", modelo.MovimentoContaID);
                int contraPartidaID = (int)cmd.ExecuteScalar();
                cmd.Parameters.Clear();

                // Verifica se o movimento usa uma categoria de transferência 
                // (se sim, retornará o número da conta, caso contrário retornará negativo)
                cmd.CommandText = "SELECT COALESCE(ContaID, -1) FROM Categoria WHERE CategoriaID = @CategoriaID";
                cmd.Parameters.AddWithValue("@CategoriaID", modelo.CategoriaID);
                int transferenciaPara = (int)cmd.ExecuteScalar();
                cmd.Parameters.Clear();

                cmd.CommandText = @"UPDATE MovimentoConta 
                                    SET ContaID = @ContaID,  
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
                                        PilhaMovimentoContaID = @PilhaMovimentoContaID,  
                                        DoMovimentoContaID = @DoMovimentoContaID,  
                                        Sistema = @Sistema  
                                    WHERE MovimentoContaID = @MovimentoContaID; 

                                    DELETE FROM MovimentoContaObservacao 
                                    WHERE MovimentoContaID = @MovimentoContaID; 

                                    SELECT CAST(@@ERROR AS INT) AS Erro;";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ContaID", modelo.ContaID);
                cmd.Parameters.AddWithValue("@Data", modelo.Data);
                cmd.Parameters.AddWithValue("@Numero", (object)modelo.Numero ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LancamentoID", modelo.LancamentoID);
                cmd.Parameters.AddWithValue("@Descricao", (object)modelo.Descricao ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CategoriaID", modelo.CategoriaID);
                cmd.Parameters.AddWithValue("@GrupoCategoriaID", (object)modelo.GrupoCategoriaID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CrdDeb", (object)modelo.CrdDeb ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Credito", (object)modelo.Credito ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Debito", (object)modelo.Debito ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Conciliacao", modelo.Conciliacao);
                cmd.Parameters.AddWithValue("@PilhaMovimentoContaID", (object)modelo.PilhaMovimentoContaID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DoMovimentoContaID", (object)modelo.DoMovimentoContaID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Sistema", modelo.Sistema);
                cmd.Parameters.AddWithValue("@MovimentoContaID", modelo.MovimentoContaID);

                if ((int)cmd.ExecuteScalar() == 0)
                {
                    registro = modelo.MovimentoContaID;
                }

                // Se houver observação a ser incluída, executa o bloco abaixo (movimento único ou de ida)
                if (!string.IsNullOrWhiteSpace(modelo.Observacao))
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = @"INSERT INTO MovimentoContaObservacao
                                        (MovimentoContaID, Observacao)
                                        VALUES
                                        (@MovimentoContaID, @Observacao);";
                    cmd.Parameters.AddWithValue("@MovimentoContaID", registro);
                    cmd.Parameters.AddWithValue("@Observacao", modelo.Observacao);
                    cmd.ExecuteScalar();
                }

                if (contraPartidaID > 0)
                {
                    // Se tem contra partida, já era uma transferência

                    if (transferenciaPara < 0)
                    {
                        // Se há contra-partida, porém o movimento não usa categoria de transferência,
                        // é pq o movimento foi alterado para não transferência
                        // Nesse caso, tem que se excluir a contra partida.
                        cmd.Parameters.Clear();
                        cmd.CommandText = "DELETE FROM MovimentoConta WHERE MovimentoContaID = @MovimentoContaID;";
                        cmd.Parameters.AddWithValue("@MovimentoContaID", contraPartidaID);
                        cmd.ExecuteScalar();
                    }
                    else
                    {
                        // Há movimento de transferência, então, será necessário alterá-lo.

                        // Preciso da categoria de transferência
                        cmd.Parameters.Clear();
                        cmd.CommandText = "SELECT CategoriaID FROM Categoria where ContaID = @ContaID";
                        cmd.Parameters.AddWithValue("@ContaID", modelo.ContaID);
                        int categoriaPara = (int)cmd.ExecuteScalar();

                        cmd.Parameters.Clear();
                        cmd.CommandText = @"UPDATE MovimentoConta
                                            SET ContaID = @ContaID,
                                                Data = @Data,
                                                Numero = @Numero,
                                                LancamentoID = @LancamentoID,
                                                CategoriaID = @CategoriaID,
                                                GrupoCategoriaID = @GrupoCategoriaID,
                                                CrdDeb = @CrdDeb,
                                                Credito = @Credito,
                                                Debito = @Debito,
                                                Conciliacao = @Conciliacao,
                                                DoMovimentoContaID = @DoMovimentoContaID,
                                                Sistema = @Sistema
                                            WHERE MovimentoContaID = @MovimentoContaID;

                                            DELETE FROM MovimentoContaObservacao 
                                            WHERE MovimentoContaID = @MovimentoContaID;";

                        // Conta ID é o número da conta ligada à categoria
                        cmd.Parameters.AddWithValue("@ContaID", transferenciaPara);
                        cmd.Parameters.AddWithValue("@Data", modelo.Data);
                        cmd.Parameters.AddWithValue("@Numero", (object)modelo.Numero ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@LancamentoID", modelo.LancamentoID);
                        // CategoriaID é igual a categoria ligada à conta de origem.
                        cmd.Parameters.AddWithValue("@CategoriaID", categoriaPara);
                        cmd.Parameters.AddWithValue("@GrupoCategoriaID", (object)modelo.GrupoCategoriaID ?? DBNull.Value);

                        // Se a origem é um débito, o destino será um crédito e vice-versa.
                        if (modelo.CrdDeb == "D")
                            cmd.Parameters.AddWithValue("@CrdDeb", "C");
                        else
                            cmd.Parameters.AddWithValue("@CrdDeb", "D");

                        // Os campos crédito e débito têm as propriedades do modelo invertido
                        cmd.Parameters.AddWithValue("@Credito", (object)modelo.Debito ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Debito", (object)modelo.Credito ?? DBNull.Value);

                        // Acompanha a conciliação da contra-partida.
                        cmd.Parameters.AddWithValue("@Conciliacao", modelo.Conciliacao);

                        cmd.Parameters.AddWithValue("@PilhaMovimentoContaID", (object)modelo.PilhaMovimentoContaID ?? DBNull.Value);
                        // DoMovimentoContaID recebe o número do registro criado no primeiro insert dessa mesma rotina.
                        cmd.Parameters.AddWithValue("@DoMovimentoContaID", registro);
                        cmd.Parameters.AddWithValue("@Sistema", modelo.Sistema);
                        cmd.Parameters.AddWithValue("@MovimentoContaID", contraPartidaID);
                        cmd.ExecuteScalar();

                        // Se houver observação a ser incluída, executa o bloco abaixo
                        if (!string.IsNullOrWhiteSpace(modelo.Observacao))
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandText = @"INSERT INTO MovimentoContaObservacao
                                                (MovimentoContaID, Observacao)
                                                VALUES
                                                (@MovimentoContaID, @Observacao);";
                            cmd.Parameters.AddWithValue("@MovimentoContaID", contraPartidaID);
                            cmd.Parameters.AddWithValue("@Observacao", modelo.Observacao);
                            cmd.ExecuteScalar();
                        }
                    }
                }
                else if (modelo.DoMovimentoContaID == null)
                {
                    // Não tinha contra partida... se existe conta de transferência, foi mudado de 
                    // lançamento normal para transferência, deverá ser incluída a contra-partida
                    // Se é movimento de transferência entre contas, aqui será criada a contra partida.

                    if (transferenciaPara > 0)
                    {
                        // Há conta de transferência, preciso da categoria de transferência
                        cmd.Parameters.Clear();
                        cmd.CommandText = "SELECT CategoriaID FROM Categoria where ContaID = @ContaID";
                        cmd.Parameters.AddWithValue("@ContaID", modelo.ContaID);
                        int categoriaPara = (int)cmd.ExecuteScalar();

                        // A categoria está ligada a uma conta, logo é uma transferência.
                        cmd.Parameters.Clear();
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
                        cmd.Parameters.AddWithValue("@Data", modelo.Data);
                        cmd.Parameters.AddWithValue("@Numero", (object)modelo.Numero ?? DBNull.Value);
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

                        // Os campos crédito e débito têm as propriedades do modelo invertido
                        cmd.Parameters.AddWithValue("@Credito", (object)modelo.Debito ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Debito", (object)modelo.Credito ?? DBNull.Value);

                        cmd.Parameters.AddWithValue("@Conciliacao", modelo.Conciliacao);
                        cmd.Parameters.AddWithValue("@PilhaMovimentoContaID", (object)modelo.PilhaMovimentoContaID ?? DBNull.Value);
                        // DoMovimentoContaID recebe o número do registro criado no primeiro insert dessa mesma rotina.
                        cmd.Parameters.AddWithValue("@DoMovimentoContaID", registro);
                        cmd.Parameters.AddWithValue("@Sistema", modelo.Sistema);

                        int chegada = (int)cmd.ExecuteScalar();

                        // Se houver observação a ser incluída, executa o bloco abaixo (movimento chegada)
                        if (!string.IsNullOrWhiteSpace(modelo.Observacao))
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandText = @"INSERT INTO MovimentoContaObservacao
                                        (MovimentoContaID, Observacao)
                                        VALUES
                                        (@MovimentoContaID, @Observacao);";
                            cmd.Parameters.AddWithValue("@MovimentoContaID", chegada);
                            cmd.Parameters.AddWithValue("@Observacao", modelo.Observacao);
                            cmd.ExecuteScalar();
                        }
                    }
                }

                transacao.Commit();

                return registro;
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao alterar movimento de conta.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void Excluir(int movimentoContaID)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand(
                @"DECLARE @ContaID INT;

                         SELECT @ContaID = ContaID    
                         FROM MovimentoConta
                         WHERE MovimentoContaID = @MovimentoContaID;

                         DELETE FROM MovimentoInvestimento
                         WHERE MovimentoContaID = @MovimentoContaID;

                         DELETE FROM MovimentoConta
                         WHERE MovimentoContaID = @MovimentoContaID
                            OR DoMovimentoContaID = @MovimentoContaID;

                         DELETE FROM Lancamento
                         WHERE Automatico = 1
                         AND UsuarioID = (SELECT UsuarioID FROM Conta WHERE ContaID = @ContaID)
                         AND LancamentoID NOT IN (SELECT DISTINCT LancamentoID FROM MovimentoConta)
                         AND LancamentoID NOT IN(SELECT DISTINCT LancamentoID FROM Planejamento); ", conn);

            cmd.Parameters.AddWithValue("@MovimentoContaID", movimentoContaID);

            try
            {
                conn.Open();
                cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao excluir lançamento.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public int Conciliados(int movimentoContaID)
        {
            int conciliados = 0;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            conn.Open();

            SqlCommand cmd = conn.CreateCommand();

            cmd.Connection = conn;

            try
            {
                // Utiliza o mesmo parâmetro para ambas as consultas
                cmd.Parameters.AddWithValue("@MovimentoContaID", movimentoContaID);

                // Verifica se o registro pai ou seu dependente estão conciliados
                // (tentativa de apagar ou alterar a partir do pai)
                cmd.CommandText = @"SELECT COUNT(Conciliacao) AS Conciliados
                                    FROM MovimentoConta
                                    WHERE Conciliacao <> ' '
                                    AND Conciliacao NOT IN ('A', 'F')
                                    AND (MovimentoContaID = @MovimentoContaID OR DoMovimentoContaID = @MovimentoContaID)";

                conciliados = (int)cmd.ExecuteScalar();

                // Não estão conciliados
                if (conciliados == 0)
                {
                    // Verifica se o registro filho e seu pai estão conciliados
                    // (tentativa de apagar ou alterar a partir do filho)
                    cmd.CommandText = @"SELECT COUNT(Conciliacao) AS Conciliados
                                        FROM MovimentoConta
                                        WHERE Conciliacao <> ' '
                                        AND Conciliacao NOT IN ('A', 'F')
                                        AND (MovimentoContaID = @MovimentoContaID
                                         OR  MovimentoContaID = (SELECT DoMovimentoContaID FROM MovimentoConta WHERE MovimentoContaID = @MovimentoContaID));";

                    conciliados = (int)cmd.ExecuteScalar();
                }
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return conciliados;
        }

        public DataTable RecuperaUltimosDadosParceiro(int contaID, int parceiroID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(@"SELECT TOP 1
                                                Descricao, CategoriaID, GrupoCategoriaID, CrdDeb, Credito, Debito
                                                FROM MovimentoConta
                                                WHERE ContaID = @ContaID
                                                AND LancamentoID = @ParceiroID
                                                ORDER BY Data DESC, MovimentoContaID DESC;", conn);
            // Atribui os parâmetros
            query.Parameters.AddWithValue("@ContaID", contaID);
            query.Parameters.AddWithValue("@ParceiroID", parceiroID);
            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public void GravarConciliacao(int movimentoContaID, string conciliacao)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            conn.Open();

            SqlTransaction transacao = conn.BeginTransaction("Movimentacao");

            SqlCommand cmd = conn.CreateCommand();

            try
            {
                cmd.Transaction = transacao;

                cmd.CommandText =
                    "UPDATE MovimentoConta " +
                    "SET Conciliacao = @Conciliacao " +
                    "WHERE MovimentoContaID = @MovimentoContaID " +
                    " OR DoMovimentoContaID = @MovimentoContaID; " +

                    "UPDATE MovimentoConta " +
                    "SET Conciliacao = @Conciliacao " +
                    "WHERE MovimentoContaID = @MovimentoContaID " +
                    " OR MovimentoContaID = (SELECT DoMovimentoContaID FROM MovimentoConta WHERE MovimentoContaID = @MovimentoContaID); ";

                cmd.Parameters.AddWithValue("@Conciliacao", conciliacao);
                cmd.Parameters.AddWithValue("@MovimentoContaID", movimentoContaID);

                cmd.ExecuteScalar();

                transacao.Commit();

            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao executar conciliação.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public DataTable Movimento(int movimentoContaID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(
                @"SELECT 
                             MovimentoContaID, UsuarioID, ContaID, Data, Numero, LancamentoID, Descricao,
                             CategoriaID, GrupoCategoriaID, CrdDeb, Credito, Debito, Valor, Balanco, Conciliacao,
                             PilhaMovimentoContaID, DoMovimentoContaID, Sistema, MovimentoInvestimentoID, InvestimentoID,
                             TransacaoID, InvestimentoCotacaoID, QtCotas, VrBruto, VrLiquido, SldCotas, VrCotacao,
                             VrDespesa, Legenda
                         FROM vw_MovimentacaoConta
                         WHERE MovimentoContaID = @MovimentoContaID
                         ORDER BY Data ASC, MovimentoContaID ASC;", conn);
            // Atribui os parâmetros
            query.Parameters.AddWithValue("@MovimentoContaID", movimentoContaID);
            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public DateTime PrimeiroDiaNaoReconciliado(int contaID)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("DECLARE @DataMinima DATE; " +
                                            // Tenta encontrar o primeiro dia com movimentos não reconciliados
                                            "SELECT @DataMinima = MIN(Data) " +
                                            "FROM MovimentoConta " +
                                            "WHERE ContaID = @ContaID " +
                                            "AND Conciliacao <> 'R'; " +
                                            // Se não encontrou, recupera o primeiro dia de movimentos (abertura) da conta
                                            "IF (@DataMinima IS NULL) " +
                                            "BEGIN " +
                                            "    SELECT @DataMinima = MAX(Data) " +
                                            "    FROM MovimentoConta " +
                                            "    WHERE ContaID = @ContaID; " +
                                            "END; " +
                                            // Retorna variável
                                            "SELECT @DataMinima;", conn);

            cmd.Parameters.AddWithValue("@ContaID", contaID);

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

        public Boolean ConciliacaoViaOFX(int movimentoContaID, Transaction transacao, bool jaReconciliado)
        {
            try
            {
                if (CriaLigacao(movimentoContaID, transacao))
                {
                    GravarConciliacao(movimentoContaID, jaReconciliado ? "R" : "C");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool CriaLigacao(int movimentoContaID, Transaction registro)
        {

            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "stpManterConciliacaoBancaria";

                    cmd.Parameters.AddWithValue("@Processo", 1);
                    cmd.Parameters.AddWithValue("@MovimentoContaID", movimentoContaID);
                    cmd.Parameters.AddWithValue("@Identificacao", registro.TransactionID.Trim());
                    cmd.Parameters.AddWithValue("@Descricao", registro.Memo.Trim());

                    cmd.ExecuteScalar();

                    return true;
                }
            }
        }

        public MovimentoTODO MovimentoTODO(int movimentoContaID)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT lct.Apelido Titulo, ");
            sql.AppendLine("       mvc.Data, ");
            sql.AppendLine("       mvc.Descricao Subtitulo, ");
            sql.AppendLine("       cta.Apelido Origem, ");
            sql.AppendLine("       mvc.CrdDeb, ");
            sql.AppendLine("       abs(mvc.Valor) valor ");
            sql.AppendLine("FROM MovimentoConta mvc ");
            sql.AppendLine("     JOIN Conta cta ON cta.ContaID = mvc.ContaID ");
            sql.AppendLine("     JOIN Lancamento lct ON lct.LancamentoID = mvc.LancamentoID ");
            sql.AppendLine("WHERE mvc.MovimentoContaID = @MovimentoContaID ");

            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    // Instancia um comando
                    SqlCommand query = new SqlCommand(sql.ToString(), conn);
                    // Atribui os parâmetros
                    query.Parameters.AddWithValue("@MovimentoContaID", movimentoContaID);
                    // Coloca a query no adaptador
                    da.SelectCommand = query;
                    // Popula a tabela
                    da.Fill(table);
                }
            }

            return table.ToList<MovimentoTODO>().FirstOrDefault();
        }
    }
}
