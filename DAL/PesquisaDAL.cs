using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace DAL
{
    public class PesquisaDAL
    {
        public DataTable ListarGruposContas(int usuarioID, Boolean SomenteAtivos)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    // Instancia um comando
                    SqlCommand query = new SqlCommand(@"SELECT GrupoContaID, Ordem,
                                                               Apelido + CASE WHEN Ativo = 0 THEN ' (Inativo)' ELSE '' END Apelido
                                                        FROM GrupoConta
                                                        WHERE (Ativo = 1 OR Ativo = @SomenteAtivos)
                                                        AND  UsuarioID = @UsuarioID
                                                        ORDER BY Ordem ASC;", conn);

                    // Atribui os parâmetros
                    query.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    query.Parameters.AddWithValue("@SomenteAtivos", SomenteAtivos);
                    // Coloca a query no adaptador
                    da.SelectCommand = query;
                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }

        public DataTable ListarGrupos(int usuarioID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    // Instancia um comando
                    SqlCommand query = new SqlCommand(@"SELECT GrupoCategoriaID, Apelido 
                                                        FROM GrupoCategoria
                                                        WHERE UsuarioID = @UsuarioID
                                                        ORDER BY Apelido ASC;", conn);

                    // Atribui os parâmetros
                    query.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    // Coloca a query no adaptador
                    da.SelectCommand = query;
                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }

        public DataTable ListarPagamentoCartaoCredito(int usuarioID, DateTime dataBase)
        {
            DataTable tabela = new DataTable();

            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                using (SqlCommand comando = new SqlCommand("EXEC stpPagamentoCartoCredito @UsuarioID, @DataReferencia;", conn))
                {

                    comando.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    comando.Parameters.AddWithValue("@DataReferencia", dataBase);

                    SqlDataReader reader = comando.ExecuteReader();
                    tabela.Load(reader);
                }
            }
            return tabela;
        }

        public DataTable VariacaoDiariaInvestimento(int usuarioID, DateTime dataReferencia)
        {
            DataTable tabela = new DataTable();

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand comando = new SqlCommand("EXEC stpVariacaoDiariaInvestimentos @UsuarioID, @DataReferencia;", conn);
            comando.Parameters.AddWithValue("@UsuarioID", usuarioID);
            comando.Parameters.AddWithValue("@DataReferencia", dataReferencia);
            comando.CommandTimeout = 240;

            try
            {
                SqlDataReader reader = comando.ExecuteReader();
                tabela.Load(reader);
                return tabela;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable VariacaoMensalInvestimento(int usuarioID, DateTime dataReferencia)
        {
            DataTable tabela = new DataTable();

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand comando = new SqlCommand("EXEC stpVariacaoMensalInvestimentos @UsuarioID, @DataReferencia;", conn);
            comando.Parameters.AddWithValue("@UsuarioID", usuarioID);
            comando.Parameters.AddWithValue("@DataReferencia", dataReferencia);

            try
            {
                SqlDataReader reader = comando.ExecuteReader();
                tabela.Load(reader);
                return tabela;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object VariacaoUltimosDiasUteisInvestimento(int usuarioID, DateTime dataReferencia)
        {
            DataTable tabela = new DataTable();

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand comando = new SqlCommand("EXEC stpVariacaoUltimosDiasInvestimentos @UsuarioID, @DataReferencia;", conn);
            comando.Parameters.AddWithValue("@UsuarioID", usuarioID);
            comando.Parameters.AddWithValue("@DataReferencia", dataReferencia);

            try
            {
                SqlDataReader reader = comando.ExecuteReader();
                tabela.Load(reader);
                return tabela;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ListarMovimentosCategoriaNoDia(int usuarioID, int categoriaID, DateTime diaSelecionado)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    SqlCommand query = new SqlCommand(
                        @"SELECT 1 Detalhe, Mvto.MovimentoContaID,
                                 Mvto.ContaID, Cnta.Apelido Conta,
                                 Mvto.Data, 
                                 Mvto.LancamentoID, Lcto.Apelido Lancamento,
                                 Mvto.Descricao,
                                 Mvto.CategoriaID, Ctng.vFiltro Categoria,
                                 Mvto.GrupoCategoriaID, Grpo.Apelido GrupoCategoria,
                                 Mvto.CrdDeb, Mvto.Credito, Mvto.Debito, Mvto.Conciliacao,
                                 Mvto.PlanejamentoID, Mvto.PlanejamentoRepeticao
                          FROM MovimentoConta Mvto
                               JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
                               JOIN Lancamento Lcto ON Lcto.LancamentoID = Mvto.LancamentoID
                               JOIN vw_CategoriasSelecionaveis Ctng ON Ctng.CategoriaID = Mvto.CategoriaID
                               JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
                          LEFT JOIN GrupoCategoria Grpo ON Grpo.GrupoCategoriaID = Mvto.GrupoCategoriaID
                          WHERE Mvto.UsuarioID = @UsuarioID 
                          AND   Ctng.CategoriaPaiID = @CategoriaID
                          AND   CAST(Mvto.Data AS DATE) = @DiaSelecionado
                          ORDER BY CrdDeb ASC, MovimentoContaID ASC;", conn);

                    // Atribui os parâmetros            
                    query.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    query.Parameters.AddWithValue("@CategoriaID", categoriaID);
                    query.Parameters.AddWithValue("@DiaSelecionado", diaSelecionado);

                    // Coloca a query no adaptador
                    da.SelectCommand = query;

                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }

        public DataTable ListarMovimentosCategoriaNoDia_Credito(int usuarioID, int categoriaID, DateTime diaSelecionado)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    SqlCommand query = new SqlCommand(
                        @"SELECT 1 Detalhe, Mvto.MovimentoContaID,
                                 Mvto.ContaID, Cnta.Apelido Conta,
                                 Mvto.Data, 
                                 Mvto.LancamentoID, Lcto.Apelido Lancamento,
                                 Mvto.Descricao,
                                 Mvto.CategoriaID, Ctng.vFiltro Categoria,
                                 Mvto.GrupoCategoriaID, Grpo.Apelido GrupoCategoria,
                                 Mvto.CrdDeb, Mvto.Credito, Mvto.Debito, Mvto.Conciliacao,
                                 Mvto.PlanejamentoID, Mvto.PlanejamentoRepeticao
                          FROM MovimentoConta Mvto
                               JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
                               JOIN Lancamento Lcto ON Lcto.LancamentoID = Mvto.LancamentoID
                               JOIN vw_CategoriasSelecionaveis Ctng ON Ctng.CategoriaID = Mvto.CategoriaID
                               JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
                               JOIN GrupoConta GCta ON GCta.GrupoContaID = Tipo.GrupoContaID
                                                   AND GCta.FluxoCredito = 1
                          LEFT JOIN GrupoCategoria Grpo ON Grpo.GrupoCategoriaID = Mvto.GrupoCategoriaID
                          WHERE Mvto.UsuarioID = @UsuarioID 
                          AND   Ctng.CategoriaPaiID = @CategoriaID
                          AND   CAST(Mvto.Data AS DATE) = @DiaSelecionado
                          ORDER BY CrdDeb ASC, MovimentoContaID ASC;", conn);

                    // Atribui os parâmetros            
                    query.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    query.Parameters.AddWithValue("@CategoriaID", categoriaID);
                    query.Parameters.AddWithValue("@DiaSelecionado", diaSelecionado);

                    // Coloca a query no adaptador
                    da.SelectCommand = query;

                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }

        public DataTable ListarMovimentosCategoriaNoDia_Disponivel(int usuarioID, int categoriaID, DateTime diaSelecionado)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    SqlCommand query = new SqlCommand(
                        @"SELECT 1 Detalhe, Mvto.MovimentoContaID,
                                 Mvto.ContaID, Cnta.Apelido Conta,
                                 Mvto.Data, 
                                 Mvto.LancamentoID, Lcto.Apelido Lancamento,
                                 Mvto.Descricao,
                                 Mvto.CategoriaID, Ctng.vFiltro Categoria,
                                 Mvto.GrupoCategoriaID, Grpo.Apelido GrupoCategoria,
                                 Mvto.CrdDeb, Mvto.Credito, Mvto.Debito, Mvto.Conciliacao,
                                 Mvto.PlanejamentoID, Mvto.PlanejamentoRepeticao
                          FROM MovimentoConta Mvto
                               JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
                               JOIN Lancamento Lcto ON Lcto.LancamentoID = Mvto.LancamentoID
                               JOIN vw_CategoriasSelecionaveis Ctng ON Ctng.CategoriaID = Mvto.CategoriaID
                               JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
                               JOIN GrupoConta GCta ON GCta.GrupoContaID = Tipo.GrupoContaID
                                                   AND GCta.FluxoDisponivel = 1
                          LEFT JOIN GrupoCategoria Grpo ON Grpo.GrupoCategoriaID = Mvto.GrupoCategoriaID
                          WHERE Mvto.UsuarioID = @UsuarioID 
                          AND   Ctng.CategoriaPaiID = @CategoriaID
                          AND   CAST(Mvto.Data AS DATE) = @DiaSelecionado
                          ORDER BY CrdDeb ASC, MovimentoContaID ASC;", conn);

                    // Atribui os parâmetros            
                    query.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    query.Parameters.AddWithValue("@CategoriaID", categoriaID);
                    query.Parameters.AddWithValue("@DiaSelecionado", diaSelecionado);

                    // Coloca a query no adaptador
                    da.SelectCommand = query;

                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }


        public DataTable ListarTransferenciasContaNoDia(int usuarioID, int contaID, DateTime diaSelecionado)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    SqlCommand query = new SqlCommand(
                        @"SELECT 1 Detalhe, Mvto.MovimentoContaID,
                                 Mvto.ContaID, Cnta.Apelido Conta,
                                 Mvto.Data, 
                                 Mvto.LancamentoID, Lcto.Apelido Lancamento,
                                 Mvto.Descricao,
                                 Mvto.CategoriaID, Ctng.vFiltro Categoria,
                                 Mvto.GrupoCategoriaID, Grpo.Apelido GrupoCategoria,
                                 Mvto.CrdDeb, Mvto.Credito, Mvto.Debito, Mvto.Conciliacao,
                                 Mvto.PlanejamentoID, Mvto.PlanejamentoRepeticao
                          FROM MovimentoConta Mvto
                               JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
                               JOIN Lancamento Lcto ON Lcto.LancamentoID = Mvto.LancamentoID
                               JOIN vw_CategoriasSelecionaveis Ctng ON Ctng.CategoriaID = Mvto.CategoriaID
                                                                   AND Ctng.vCrdDeb = 'T'
                               JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
                          LEFT JOIN GrupoCategoria Grpo ON Grpo.GrupoCategoriaID = Mvto.GrupoCategoriaID
                          WHERE Mvto.UsuarioID = @UsuarioID 
                          AND   Mvto.ContaID = @ContaID
                          AND   CAST(Mvto.Data AS DATE) = @DiaSelecionado
                          ORDER BY CrdDeb ASC, MovimentoContaID ASC;", conn);

                    // Atribui os parâmetros            
                    query.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    query.Parameters.AddWithValue("@ContaID", contaID);
                    query.Parameters.AddWithValue("@DiaSelecionado", diaSelecionado);

                    // Coloca a query no adaptador
                    da.SelectCommand = query;

                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }


        public DataTable ListarMovimentosCategoriaNoDia(int usuarioID, int contaID, int categoriaID, DateTime diaSelecionado)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    SqlCommand query = new SqlCommand(
                        @"SELECT 1 Detalhe, Mvto.MovimentoContaID,
                                 Mvto.ContaID, Cnta.Apelido Conta,
                                 Mvto.Data, 
                                 Mvto.LancamentoID, Lcto.Apelido Lancamento,
                                 Mvto.Descricao,
                                 Mvto.CategoriaID, Ctng.vFiltro Categoria,
                                 Mvto.GrupoCategoriaID, Grpo.Apelido GrupoCategoria,
                                 Mvto.CrdDeb, Mvto.Credito, Mvto.Debito, Mvto.Conciliacao,
                                 Mvto.PlanejamentoID, Mvto.PlanejamentoRepeticao
                          FROM MovimentoConta Mvto
                               JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
                               JOIN Lancamento Lcto ON Lcto.LancamentoID = Mvto.LancamentoID
                               JOIN vw_CategoriasSelecionaveis Ctng ON Ctng.CategoriaID = Mvto.CategoriaID
                               JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
                          LEFT JOIN GrupoCategoria Grpo ON Grpo.GrupoCategoriaID = Mvto.GrupoCategoriaID
                          WHERE Mvto.UsuarioID = @UsuarioID
                          AND   Mvto.ContaID = @ContaID
                          AND   Ctng.CategoriaPaiID = @CategoriaID
                          AND   CAST(Mvto.Data AS DATE) = @DiaSelecionado
                          ORDER BY CrdDeb ASC, MovimentoContaID ASC;", conn);

                    // Atribui os parâmetros            
                    query.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    query.Parameters.AddWithValue("@ContaID", contaID);
                    query.Parameters.AddWithValue("@CategoriaID", categoriaID);
                    query.Parameters.AddWithValue("@DiaSelecionado", diaSelecionado);

                    // Coloca a query no adaptador
                    da.SelectCommand = query;

                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }

        public DataTable ListarMovimentosCategoriaNoMes(int usuarioID, int categoriaID, DateTime mesSelecionado)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    SqlCommand query = new SqlCommand(
                        @"SELECT 1 Detalhe, Mvto.MovimentoContaID,
                                 Mvto.ContaID, Cnta.Apelido Conta,
                                 Mvto.Data, 
                                 Mvto.LancamentoID, Lcto.Apelido Lancamento,
                                 Mvto.Descricao,
                                 Mvto.CategoriaID, Ctng.vFiltro Categoria,
                                 Mvto.GrupoCategoriaID, Grpo.Apelido GrupoCategoria,
                                 Mvto.CrdDeb, Mvto.Credito, Mvto.Debito, Mvto.Conciliacao,
                                 Mvto.PlanejamentoID, Mvto.PlanejamentoRepeticao
                          FROM MovimentoConta Mvto
                               JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
                               JOIN Lancamento Lcto ON Lcto.LancamentoID = Mvto.LancamentoID
                               JOIN vw_CategoriasSelecionaveis Ctng ON Ctng.CategoriaID = Mvto.CategoriaID
                               JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
                          LEFT JOIN GrupoCategoria Grpo ON Grpo.GrupoCategoriaID = Mvto.GrupoCategoriaID
                          WHERE Mvto.UsuarioID = @UsuarioID 
                          AND   Ctng.CategoriaPaiID = @CategoriaID
                          AND   DATEPART(YEAR, Mvto.Data) = DATEPART(YEAR, @MesSelecionado)
                          AND   DATEPART(MONTH, Mvto.Data) = DATEPART(MONTH, @MesSelecionado)
                          ORDER BY Mvto.Data ASC, Mvto.CrdDeb ASC, Mvto.MovimentoContaID ASC;", conn);

                    // Atribui os parâmetros            
                    query.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    query.Parameters.AddWithValue("@CategoriaID", categoriaID);
                    query.Parameters.AddWithValue("@MesSelecionado", mesSelecionado);

                    // Coloca a query no adaptador
                    da.SelectCommand = query;

                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }

        public DataTable ListarTransferenciasContaNoMe(int usuarioID, int contaID, DateTime mesSelecionado)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    SqlCommand query = new SqlCommand(
                        @"SELECT 1 Detalhe, Mvto.MovimentoContaID,
                                 Mvto.ContaID, Cnta.Apelido Conta,
                                 Mvto.Data, 
                                 Mvto.LancamentoID, Lcto.Apelido Lancamento,
                                 Mvto.Descricao,
                                 Mvto.CategoriaID, Ctng.vFiltro Categoria,
                                 Mvto.GrupoCategoriaID, Grpo.Apelido GrupoCategoria,
                                 Mvto.CrdDeb, Mvto.Credito, Mvto.Debito, Mvto.Conciliacao,
                                 Mvto.PlanejamentoID, Mvto.PlanejamentoRepeticao
                          FROM MovimentoConta Mvto
                               JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
                               JOIN Lancamento Lcto ON Lcto.LancamentoID = Mvto.LancamentoID
                               JOIN vw_CategoriasSelecionaveis Ctng ON Ctng.CategoriaID = Mvto.CategoriaID
                                                                   AND Ctng.vCrdDeb = 'T'
                               JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
                          LEFT JOIN GrupoCategoria Grpo ON Grpo.GrupoCategoriaID = Mvto.GrupoCategoriaID
                          WHERE Mvto.UsuarioID = @UsuarioID 
                          AND   Mvto.ContaID = @ContaID
                          AND   DATEPART(YEAR, Mvto.Data) = DATEPART(YEAR, @MesSelecionado)
                          AND   DATEPART(MONTH, Mvto.Data) = DATEPART(MONTH, @MesSelecionado)
                          ORDER BY Mvto.Data ASC, Mvto.CrdDeb ASC, Mvto.MovimentoContaID ASC;", conn);

                    // Atribui os parâmetros            
                    query.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    query.Parameters.AddWithValue("@ContaID", contaID);
                    query.Parameters.AddWithValue("@MesSelecionado", mesSelecionado);

                    // Coloca a query no adaptador
                    da.SelectCommand = query;

                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }

        public DataTable ListarMovimentosCategoriaNoMes_Disponivel(int usuarioID, int categoriaID, DateTime mesSelecionado)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    SqlCommand query = new SqlCommand(
                        @"SELECT 1 Detalhe, Mvto.MovimentoContaID,
                                 Mvto.ContaID, Cnta.Apelido Conta,
                                 Mvto.Data, 
                                 Mvto.LancamentoID, Lcto.Apelido Lancamento,
                                 Mvto.Descricao,
                                 Mvto.CategoriaID, Ctng.vFiltro Categoria,
                                 Mvto.GrupoCategoriaID, Grpo.Apelido GrupoCategoria,
                                 Mvto.CrdDeb, Mvto.Credito, Mvto.Debito, Mvto.Conciliacao,
                                 Mvto.PlanejamentoID, Mvto.PlanejamentoRepeticao
                          FROM MovimentoConta Mvto
                               JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
                               JOIN Lancamento Lcto ON Lcto.LancamentoID = Mvto.LancamentoID
                               JOIN vw_CategoriasSelecionaveis Ctng ON Ctng.CategoriaID = Mvto.CategoriaID
                               JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
                               JOIN GrupoConta GCta ON GCta.GrupoContaID = Tipo.GrupoContaID
                                                   AND GCta.FluxoDisponivel = 1
                          LEFT JOIN GrupoCategoria Grpo ON Grpo.GrupoCategoriaID = Mvto.GrupoCategoriaID
                          WHERE Mvto.UsuarioID = @UsuarioID 
                          AND   Ctng.CategoriaPaiID = @CategoriaID
                          AND   DATEPART(YEAR, Mvto.Data) = DATEPART(YEAR, @MesSelecionado)
                          AND   DATEPART(MONTH, Mvto.Data) = DATEPART(MONTH, @MesSelecionado)
                          ORDER BY Mvto.Data ASC, Mvto.CrdDeb ASC, Mvto.MovimentoContaID ASC;", conn);

                    // Atribui os parâmetros            
                    query.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    query.Parameters.AddWithValue("@CategoriaID", categoriaID);
                    query.Parameters.AddWithValue("@MesSelecionado", mesSelecionado);

                    // Coloca a query no adaptador
                    da.SelectCommand = query;

                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }

        public DataTable ListarMovimentosCategoriaNoMes_Credito(int usuarioID, int categoriaID, DateTime mesSelecionado)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    SqlCommand query = new SqlCommand(
                        @"SELECT 1 Detalhe, Mvto.MovimentoContaID,
                                 Mvto.ContaID, Cnta.Apelido Conta,
                                 Mvto.Data, 
                                 Mvto.LancamentoID, Lcto.Apelido Lancamento,
                                 Mvto.Descricao,
                                 Mvto.CategoriaID, Ctng.vFiltro Categoria,
                                 Mvto.GrupoCategoriaID, Grpo.Apelido GrupoCategoria,
                                 Mvto.CrdDeb, Mvto.Credito, Mvto.Debito, Mvto.Conciliacao,
                                 Mvto.PlanejamentoID, Mvto.PlanejamentoRepeticao
                          FROM MovimentoConta Mvto
                               JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
                               JOIN Lancamento Lcto ON Lcto.LancamentoID = Mvto.LancamentoID
                               JOIN vw_CategoriasSelecionaveis Ctng ON Ctng.CategoriaID = Mvto.CategoriaID
                               JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
                               JOIN GrupoConta GCta ON GCta.GrupoContaID = Tipo.GrupoContaID
                                                   AND GCta.FluxoCredito = 1
                          LEFT JOIN GrupoCategoria Grpo ON Grpo.GrupoCategoriaID = Mvto.GrupoCategoriaID
                          WHERE Mvto.UsuarioID = @UsuarioID 
                          AND   Ctng.CategoriaPaiID = @CategoriaID
                          AND   DATEPART(YEAR, Mvto.Data) = DATEPART(YEAR, @MesSelecionado)
                          AND   DATEPART(MONTH, Mvto.Data) = DATEPART(MONTH, @MesSelecionado)
                          ORDER BY Mvto.Data ASC, Mvto.CrdDeb ASC, Mvto.MovimentoContaID ASC;", conn);

                    // Atribui os parâmetros            
                    query.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    query.Parameters.AddWithValue("@CategoriaID", categoriaID);
                    query.Parameters.AddWithValue("@MesSelecionado", mesSelecionado);

                    // Coloca a query no adaptador
                    da.SelectCommand = query;

                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }

        public DataTable ListarMovimentosCategoriaNoPeriodo(int usuarioID, int categoriaID, DateTime inicio, DateTime fim)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    SqlCommand query = new SqlCommand(
                        @"SELECT 1 Detalhe, Mvto.MovimentoContaID,
                                 Mvto.ContaID, Cnta.Apelido Conta,
                                 Mvto.Data, 
                                 Mvto.LancamentoID, Lcto.Apelido Lancamento,
                                 Mvto.Descricao,
                                 Mvto.CategoriaID, Ctng.vFiltro Categoria,
                                 Mvto.GrupoCategoriaID, Grpo.Apelido GrupoCategoria,
                                 Mvto.CrdDeb, Mvto.Credito, Mvto.Debito, Mvto.Conciliacao,
                                 Mvto.PlanejamentoID, Mvto.PlanejamentoRepeticao
                          FROM MovimentoConta Mvto
                               JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
                               JOIN Lancamento Lcto ON Lcto.LancamentoID = Mvto.LancamentoID
                               JOIN vw_CategoriasSelecionaveis Ctng ON Ctng.CategoriaID = Mvto.CategoriaID
                               JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
                          LEFT JOIN GrupoCategoria Grpo ON Grpo.GrupoCategoriaID = Mvto.GrupoCategoriaID
                          WHERE Mvto.UsuarioID = @UsuarioID 
                          AND   Ctng.CategoriaPaiID = @CategoriaID
                          AND   CAST(Mvto.Data AS DATE) BETWEEN @Inicio AND @Fim
                          ORDER BY Mvto.Data ASC, Mvto.CrdDeb ASC, Mvto.MovimentoContaID ASC;", conn);

                    // Atribui os parâmetros            
                    query.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    query.Parameters.AddWithValue("@CategoriaID", categoriaID);
                    query.Parameters.AddWithValue("@Inicio", inicio);
                    query.Parameters.AddWithValue("@Fim", fim);

                    // Coloca a query no adaptador
                    da.SelectCommand = query;

                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }

        public DataTable FluxoCaixaContaEspecifica(int contaID, DateTime dataBase)
        {
            DataTable tabela = new DataTable();

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand comando = new SqlCommand("EXEC stpFluxoCaixaContaEspecifica @ContaID, @DataReferencia;", conn);
            comando.Parameters.AddWithValue("@ContaID", contaID);
            comando.Parameters.AddWithValue("@DataReferencia", dataBase);

            try
            {
                SqlDataReader reader = comando.ExecuteReader();
                tabela.Load(reader);
                return tabela;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable FluxoCaixaDisponivel(int usuarioID, DateTime dataBase)
        {
            DataTable tabela = new DataTable();

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand comando = new SqlCommand("EXEC stpFluxoCaixaDisponivel @UsuarioID, @DataReferencia;", conn);
            comando.Parameters.AddWithValue("@UsuarioID", usuarioID);
            comando.Parameters.AddWithValue("@DataReferencia", dataBase);

            try
            {
                SqlDataReader reader = comando.ExecuteReader();
                tabela.Load(reader);
                return tabela;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable FluxoCaixaCredito(int usuarioID, DateTime dataBase)
        {
            DataTable tabela = new DataTable();

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand comando = new SqlCommand("EXEC stpFluxoCaixaCredito @UsuarioID, @DataReferencia;", conn);
            comando.Parameters.AddWithValue("@UsuarioID", usuarioID);
            comando.Parameters.AddWithValue("@DataReferencia", dataBase);

            try
            {
                SqlDataReader reader = comando.ExecuteReader();
                tabela.Load(reader);
                return tabela;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable OrcamentoDiario(int usuarioID, DateTime dataBase, bool comparar)
        {
            DataTable tabela = new DataTable();

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand comando = new SqlCommand("EXEC stpOrcamentoDiario @UsuarioID, @DataReferencia, @Comparar;", conn);
            comando.Parameters.AddWithValue("@UsuarioID", usuarioID);
            comando.Parameters.AddWithValue("@DataReferencia", dataBase);
            comando.Parameters.AddWithValue("@Comparar", comparar);

            try
            {
                SqlDataReader reader = comando.ExecuteReader();
                tabela.Load(reader);
                return tabela;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable OrcamentoMensal(int usuarioID, DateTime dataBase, bool comparar)
        {
            DataTable tabela = new DataTable();

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand comando = new SqlCommand("EXEC stpOrcamentoMensal @UsuarioID, @DataReferencia, @Comparar;", conn);
            comando.Parameters.AddWithValue("@UsuarioID", usuarioID);
            comando.Parameters.AddWithValue("@DataReferencia", dataBase);
            comando.Parameters.AddWithValue("@Comparar", comparar);

            try
            {
                SqlDataReader reader = comando.ExecuteReader();
                tabela.Load(reader);
                return tabela;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ListarGruposUsadosNaConta(int contaID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    // Instancia um comando
                    SqlCommand query = new SqlCommand(@"SELECT DISTINCT GpCt.GrupoCategoriaID, GpCt.Apelido
                                                        FROM MovimentoConta MvCt
                                                             JOIN GrupoCategoria GpCt ON GpCt.GrupoCategoriaID = MvCt.GrupoCategoriaID
                                                             JOIN Lancamento Lcto ON Lcto.LancamentoID = MvCt.LancamentoID
                                                                                 AND Lcto.Sistema = 0
                                                        WHERE MvCt.ContaID = @ContaID
                                                        ORDER BY GpCt.Apelido;", conn);

                    // Atribui os parâmetros
                    query.Parameters.AddWithValue("@ContaID", contaID);
                    // Coloca a query no adaptador
                    da.SelectCommand = query;
                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }

        public DataTable ListarMovimentos(int usuarioID, Pesquisa conteudoPesquisa)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {

                    StringBuilder clausulaWhere = new StringBuilder("");

                    if (!string.IsNullOrWhiteSpace((string)conteudoPesquisa.Descricao))
                    {
                        clausulaWhere.Append("AND UPPER(Mvto.Descricao) LIKE '%" + (string)conteudoPesquisa.Descricao.ToUpper() + "%' ");
                    }

                    if ((conteudoPesquisa.DataDe != null) && (conteudoPesquisa.DataAte != null))
                    {
                        // Início e fim de período
                        DateTime dePeriodo = (DateTime)conteudoPesquisa.DataDe;
                        DateTime atePeriodo = (DateTime)conteudoPesquisa.DataAte;
                        clausulaWhere.Append("AND CAST(Mvto.Data AS DATE) BETWEEN ");
                        clausulaWhere.Append("CONVERT(DATE, '" + dePeriodo.ToString("dd/MM/yyyy") + "', 103) AND ");
                        clausulaWhere.Append("CONVERT(DATE, '" + atePeriodo.ToString("dd/MM/yyyy") + "', 103) ");
                    }
                    else if (conteudoPesquisa.DataDe != null)
                    {
                        // Somente início de período
                        DateTime dePeriodo = (DateTime)conteudoPesquisa.DataDe;
                        clausulaWhere.Append("AND CAST(Mvto.Data AS DATE) >= CONVERT(DATE, '" + dePeriodo.ToString("dd/MM/yyyy") + "', 103) ");
                    }
                    else if (conteudoPesquisa.DataAte != null)
                    {
                        // Somente fim de período
                        DateTime atePeriodo = (DateTime)conteudoPesquisa.DataAte;
                        clausulaWhere.Append("AND CAST(Mvto.Data AS DATE) <= CONVERT(DATE, '" + atePeriodo.ToString("dd/MM/yyyy") + "', 103) ");
                    }

                    if ((conteudoPesquisa.ValorDe != null) && (conteudoPesquisa.ValorAte != null))
                    {
                        // Valor inicial e final informados
                        decimal deValor = (decimal)conteudoPesquisa.ValorDe;
                        decimal ateValor = (decimal)conteudoPesquisa.ValorAte;
                        clausulaWhere.Append("AND COALESCE(Mvto.Credito, 0.00) - COALESCE(Mvto.Debito, 0.00) BETWEEN ");
                        clausulaWhere.Append(deValor.ToString(CultureInfo.InvariantCulture) + " AND " + ateValor.ToString(CultureInfo.InvariantCulture) + " ");
                    }
                    else if (conteudoPesquisa.ValorDe != null)
                    {
                        // Somente valor inicial
                        decimal deValor = (decimal)conteudoPesquisa.ValorDe;
                        clausulaWhere.Append("AND COALESCE(Mvto.Credito, 0.00) - COALESCE(Mvto.Debito, 0.00) >= " + deValor.ToString(CultureInfo.InvariantCulture) + " ");
                    }
                    else if (conteudoPesquisa.ValorAte != null)
                    {
                        // Somente valor final
                        decimal ateValor = (decimal)conteudoPesquisa.ValorAte;
                        clausulaWhere.Append("AND COALESCE(Mvto.Credito, 0.00) - COALESCE(Mvto.Debito, 0.00) <= " + ateValor.ToString(CultureInfo.InvariantCulture) + " ");
                    }

                    Boolean filtraTransferencia = false;

                    if ((Tipo.FiltroTransferencia)conteudoPesquisa.Transferencia == Tipo.FiltroTransferencia.Origem)
                    {
                        clausulaWhere.Append("AND Dest.MovimentoContaID IS NOT NULL ");
                        clausulaWhere.Append("AND Mvto.DoMovimentoContaID IS NULL ");
                        filtraTransferencia = true;
                    }
                    else if ((Tipo.FiltroTransferencia)conteudoPesquisa.Transferencia == Tipo.FiltroTransferencia.Destino)
                    {
                        clausulaWhere.Append("AND Dest.MovimentoContaID IS NULL ");
                        clausulaWhere.Append("AND Mvto.DoMovimentoContaID IS NOT NULL ");
                        filtraTransferencia = true;
                    }
                    else if ((Tipo.FiltroTransferencia)conteudoPesquisa.Transferencia == Tipo.FiltroTransferencia.Nenhuma)
                    {
                        clausulaWhere.Append("AND Dest.MovimentoContaID IS NULL ");
                        clausulaWhere.Append("AND Mvto.DoMovimentoContaID IS NULL ");
                        filtraTransferencia = true;
                    }

                    SqlCommand query = new SqlCommand(
                        @"SELECT 1 Detalhe, Mvto.MovimentoContaID,
                                 Mvto.ContaID, Cnta.Apelido Conta,
                                 Mvto.Data, 
                                 Mvto.LancamentoID, Lcto.Apelido Lancamento,
                                 Mvto.Descricao,
                                 Mvto.CategoriaID, Ctng.vFiltro Categoria,
                                 Mvto.GrupoCategoriaID, Grpo.Apelido GrupoCategoria,
                                 Mvto.CrdDeb, Mvto.Credito, Mvto.Debito, Mvto.Conciliacao,
                                 Mvto.PlanejamentoID, Mvto.PlanejamentoRepeticao
                          FROM MovimentoConta Mvto
                               JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
                               JOIN Lancamento Lcto ON Lcto.LancamentoID = Mvto.LancamentoID
                               JOIN vw_CategoriasSelecionaveis Ctng ON Ctng.CategoriaID = Mvto.CategoriaID
                               JOIN Categoria Cate ON Cate.CategoriaID = Ctng.CategoriaPaiID
                               JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
                          LEFT JOIN GrupoCategoria Grpo ON Grpo.GrupoCategoriaID = Mvto.GrupoCategoriaID " +

                          (filtraTransferencia ? "LEFT JOIN MovimentoConta Dest ON Dest.DoMovimentoContaID = Mvto.MovimentoContaID " : "") +

                         "WHERE Mvto.UsuarioID = @UsuarioID " +

                          clausulaWhere.ToString() +

                        @"AND   Mvto.ContaID = COALESCE(@ContaID, Mvto.ContaID)
                          AND   Mvto.LancamentoID = COALESCE(@LancamentoID, Mvto.LancamentoID)
                          AND   (Mvto.CategoriaID = COALESCE(@CategoriaID, Mvto.CategoriaID) OR Cate.CategoriaID = COALESCE(@CategoriaID, Cate.CategoriaID))
                          AND   Tipo.TipoContaID = COALESCE(@TipoContaID, Tipo.TipoContaID)
                          AND   Tipo.GrupoContaID = COALESCE(@GrupoContaID, Tipo.GrupoContaID)
                          AND   COALESCE(Mvto.GrupoCategoriaID, 0) = COALESCE(@GrupoCategoriaID, Mvto.GrupoCategoriaID, 0)

                          UNION ALL

                          SELECT 0 Detalhe, NULL MovimentoContaID,
                                 NULL ContaID, NULL Conta,
                                 NULL Data, 
                                 NULL LancamentoID, NULL Lancamento,
                                 'Total Geral' Descricao,
                                 NULL CategoriaID, NULL Categoria,
                                 NULL GrupoCategoriaID, NULL GrupoCategoria,
                                 NULL CrdDeb, SUM(Mvto.Credito) Credito, SUM(Mvto.Debito) Debito, NULL Conciliacao,
                                 NULL PlanejamentoID, NULL PlanejamentoRepeticao
                          FROM MovimentoConta Mvto
                               JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
                               JOIN Lancamento Lcto ON Lcto.LancamentoID = Mvto.LancamentoID
                               JOIN vw_CategoriasSelecionaveis Ctng ON Ctng.CategoriaID = Mvto.CategoriaID
                               JOIN Categoria Cate ON Cate.CategoriaID = Ctng.CategoriaPaiID
                               JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
                          LEFT JOIN GrupoCategoria Grpo ON Grpo.GrupoCategoriaID = Mvto.GrupoCategoriaID " +

                          (filtraTransferencia ? "LEFT JOIN MovimentoConta Dest ON Dest.DoMovimentoContaID = Mvto.MovimentoContaID " : "") +

                         "WHERE Mvto.UsuarioID = @UsuarioID " +

                          clausulaWhere.ToString() +

                        @"AND   Mvto.ContaID = COALESCE(@ContaID, Mvto.ContaID)
                          AND   Mvto.LancamentoID = COALESCE(@LancamentoID, Mvto.LancamentoID)
                          AND   (Mvto.CategoriaID = COALESCE(@CategoriaID, Mvto.CategoriaID) OR Cate.CategoriaID = COALESCE(@CategoriaID, Cate.CategoriaID))
                          AND   Tipo.TipoContaID = COALESCE(@TipoContaID, Tipo.TipoContaID)
                          AND   Tipo.GrupoContaID = COALESCE(@GrupoContaID, Tipo.GrupoContaID)
                          AND   COALESCE(Mvto.GrupoCategoriaID, 0) = COALESCE(@GrupoCategoriaID, Mvto.GrupoCategoriaID, 0)

                          ORDER BY Detalhe DESC, Data ASC, CrdDeb ASC, MovimentoContaID ASC;", conn);

                    // Atribui os parâmetros            
                    query.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    query.Parameters.AddWithValue("@ContaID", (object)conteudoPesquisa.ContaID ?? DBNull.Value);
                    query.Parameters.AddWithValue("@LancamentoID", (object)conteudoPesquisa.ParceiroID ?? DBNull.Value);
                    query.Parameters.AddWithValue("@CategoriaID", (object)conteudoPesquisa.CategoriaID ?? DBNull.Value);
                    query.Parameters.AddWithValue("@TipoContaID", (object)conteudoPesquisa.TipoContaID ?? DBNull.Value);
                    query.Parameters.AddWithValue("@GrupoContaID", (object)conteudoPesquisa.GrupoContaID ?? DBNull.Value);
                    query.Parameters.AddWithValue("@GrupoCategoriaID", (object)conteudoPesquisa.GrupoID ?? DBNull.Value);

                    // Coloca a query no adaptador
                    da.SelectCommand = query;

                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }

        public DataTable ListarCategorias(int usuarioID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    // Instancia um comando
                    SqlCommand query = new SqlCommand(@"SELECT CategoriaID, vFiltro Apelido
                                                        FROM vw_CategoriasSelecionaveis
                                                        WHERE UsuarioID = @UsuarioID
                                                        AND   vNivel > 0
                                                        ORDER BY Apelido ASC;", conn);

                    // Atribui os parâmetros
                    query.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    // Coloca a query no adaptador
                    da.SelectCommand = query;
                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }

        public object ListarCategoriasUsadosNaConta(int contaID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    // Instancia um comando
                    SqlCommand query = new SqlCommand(@"SELECT DISTINCT Ctgr.CategoriaID, Ctgr.vFiltro Apelido
                                                        FROM MovimentoConta MvCt
                                                             JOIN Lancamento Lcto ON Lcto.LancamentoID = MvCt.LancamentoID
                                                                                 AND Lcto.Sistema = 0
                                                             JOIN vw_CategoriasSelecionaveis Ctgr ON Ctgr.CategoriaID = MvCt.CategoriaID
                                                        WHERE MvCt.ContaID = @ContaID

                                                        UNION

                                                        SELECT DISTINCT Pais.CategoriaID, Pais.vFiltro Apelido
                                                        FROM MovimentoConta MvCt
                                                             JOIN Lancamento Lcto ON Lcto.LancamentoID = MvCt.LancamentoID
                                                                                 AND Lcto.Sistema = 0
                                                             JOIN vw_CategoriasSelecionaveis Ctgr ON Ctgr.CategoriaID = MvCt.CategoriaID
                                                             JOIN vw_CategoriasSelecionaveis Pais ON Pais.CategoriaID = Ctgr.CategoriaPaiID
                                                                                                 AND Pais.vFiltro IS NOT NULL
                                                        WHERE MvCt.ContaID = @ContaID

                                                        ORDER BY Ctgr.vFiltro;", conn);

                    // Atribui os parâmetros
                    query.Parameters.AddWithValue("@ContaID", contaID);
                    // Coloca a query no adaptador
                    da.SelectCommand = query;
                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }

        public DataTable ListarParceiros(int usuarioID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    // Instancia um comando
                    SqlCommand query = new SqlCommand(@"SELECT LancamentoID, Apelido 
                                                        FROM Lancamento
                                                        WHERE UsuarioID = @UsuarioID
                                                        ORDER BY Apelido ASC;", conn);

                    // Atribui os parâmetros
                    query.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    // Coloca a query no adaptador
                    da.SelectCommand = query;
                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }

        public object ListarParceirosUsadosNaConta(int contaID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    // Instancia um comando
                    SqlCommand query = new SqlCommand(@"SELECT DISTINCT Lcto.LancamentoID, Lcto.Apelido
                                                        FROM MovimentoConta MvCt
                                                             JOIN Lancamento Lcto ON Lcto.LancamentoID = MvCt.LancamentoID
                                                                                 AND Lcto.Sistema = 0
                                                        WHERE MvCt.ContaID = @ContaID
                                                        ORDER BY Lcto.Apelido;", conn);

                    // Atribui os parâmetros
                    query.Parameters.AddWithValue("@ContaID", contaID);
                    // Coloca a query no adaptador
                    da.SelectCommand = query;
                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }

        public DataTable ListarTiposContas(int usuarioID, Boolean SomenteAtivos, int GrupoContaID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    // Instancia um comando
                    SqlCommand query = new SqlCommand(@"SELECT TipoContaID, 
                                                               Apelido + CASE WHEN Ativo = 0 THEN ' (Inativo)' ELSE '' END Apelido
                                                        FROM TipoConta
                                                        WHERE (Ativo = 1 OR Ativo = @SomenteAtivos)
                                                        AND   (GrupoContaID = @GrupoContaID OR @GrupoContaID = -1)
                                                        AND  UsuarioID = @UsuarioID
                                                        ORDER BY Apelido ASC;", conn);

                    // Atribui os parâmetros
                    query.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    query.Parameters.AddWithValue("@SomenteAtivos", SomenteAtivos);
                    query.Parameters.AddWithValue("@GrupoContaID", GrupoContaID);
                    // Coloca a query no adaptador
                    da.SelectCommand = query;
                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }

        public DataTable ListarContas(int usuarioID, Boolean SomenteAtivos, int GrupoContaID, int TipoContaID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    // Instancia um comando
                    SqlCommand query = new SqlCommand(@"SELECT Cta.ContaID, Cta.Apelido + CASE WHEN Cta.Ativo = 0 THEN ' (Inativa)' ELSE '' END Apelido
                                                        FROM Conta Cta
                                                             JOIN TipoConta Tip ON Tip.TipoContaID = Cta.TipoContaID
                                                                               AND Tip.UsuarioID = Cta.UsuarioID
                                                        WHERE (Cta.Ativo = 1 OR Cta.Ativo = @SomenteAtivos)
                                                        AND   (Cta.TipoContaID = @TipoContaID OR @TipoContaID = -1)
                                                        AND   (Tip.GrupoContaID = @GrupoContaID OR @GrupoContaID = -1)
                                                        AND   Cta.UsuarioID = @UsuarioID
                                                        ORDER BY Apelido ASC;", conn);

                    // Atribui os parâmetros
                    query.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    query.Parameters.AddWithValue("@SomenteAtivos", SomenteAtivos);
                    query.Parameters.AddWithValue("@TipoContaID", TipoContaID);
                    query.Parameters.AddWithValue("@GrupoContaID", GrupoContaID);
                    // Coloca a query no adaptador
                    da.SelectCommand = query;
                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }
    }
}
