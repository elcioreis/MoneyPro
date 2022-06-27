using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace DAL
{
    public class InvestimentoDAL
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
                                                  Inv.InvestimentoID, Inv.UsuarioID, Inv.Apelido, Inv.Descricao, Inv.TipoInvestimentoID,
                                                  Inv.InstituicaoID, Inv.MoedaID, Inv.RiscoID, Inv.Consulta, Inv.Ativo, Inv.DataInicio,
                                                  MAX(Cot.Data) Ultimo, Inv.Aplicacao, Inv.Resgate, Inv.Liquidacao, Inv.CodigoAnbima, 
                                                  Inv.TaxaAdministracao, Inv.TaxaPerformance, Inv.InicialMinimo, Inv.MovimentoMinimo, 
                                                  Inv.SaldoMinimo
                                                FROM Investimento Inv
                                                LEFT JOIN InvestimentoCotacao Cot on Cot.InvestimentoID = Inv.InvestimentoID
                                                WHERE UsuarioID = @UsuarioID
                                                GROUP BY
                                                  Inv.InvestimentoID, Inv.UsuarioID, Inv.Apelido, Inv.Descricao, Inv.TipoInvestimentoID,
                                                  Inv.InstituicaoID, Inv.MoedaID, Inv.RiscoID, Inv.Consulta, Inv.Ativo, Inv.DataInicio,
                                                  Inv.Aplicacao, Inv.Resgate, Inv.Liquidacao, Inv.CodigoAnbima, 
                                                  Inv.TaxaAdministracao, Inv.TaxaPerformance, Inv.InicialMinimo, Inv.MovimentoMinimo, 
                                                  Inv.SaldoMinimo
                                                ORDER BY Inv.Apelido ASC;", conn);

            // Atribui os parâmetros
            query.Parameters.AddWithValue("@UsuarioID", usuarioID);
            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public DataTable Listar(int usuarioID, bool venda, bool fundo, bool acao)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(@"SELECT Invt.InvestimentoID, Invt.UsuarioID, Invt.Apelido, Invt.Descricao,
                                                       Invt.TipoInvestimentoID, Invt.InstituicaoID, Invt.MoedaID,
                                                       Invt.RiscoID, Invt.Consulta, Invt.Ativo, Invt.DataInicio,
                                                       COALESCE(SUM(MInv.QtCotas), 0) QtCotas
                                                FROM Investimento Invt
                                                     JOIN TipoInvestimento Tipo ON Tipo.TipoInvestimentoID = Invt.TipoInvestimentoID
                                                LEFT JOIN MovimentoInvestimento MInv ON Minv.InvestimentoID = Invt.InvestimentoID
                                                WHERE Invt.UsuarioID = @UsuarioID
                                                AND   Invt.Ativo = 1
                                                AND ((Tipo.Fundo = 1 AND Tipo.Fundo = @Fundo) OR (Tipo.Acao = 1 AND Tipo.Acao = @Acao))
                                                GROUP BY Invt.InvestimentoID, Invt.UsuarioID, Invt.Apelido, Invt.Descricao,
                                                         Invt.TipoInvestimentoID, Invt.InstituicaoID, Invt.MoedaID,
                                                         Invt.RiscoID, Invt.Consulta, Invt.Ativo, Invt.DataInicio " +

                                               ( venda ? "HAVING COALESCE(SUM(MInv.QtCotas), 0) > 0 " : " ") +

                                               "ORDER BY Invt.Apelido ASC;", conn);

            // Atribui os parâmetros
            query.Parameters.AddWithValue("@UsuarioID", usuarioID);
            query.Parameters.AddWithValue("@Fundo", fundo);
            query.Parameters.AddWithValue("@Acao", acao);
            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }


        public bool ApelidoDisponivel(int usuarioID, int investimentoID, string apelido)
        {
            bool disponivel = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Existe " +
                                            "FROM Investimento " +
                                            "WHERE Apelido = @Apelido " +
                                            "AND UsuarioID = @UsuarioID " +
                                            "AND InvestimentoID <> @InvestimentoID;", conn);

            cmd.Parameters.AddWithValue("@Apelido", apelido);
            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
            cmd.Parameters.AddWithValue("@InvestimentoID", investimentoID);

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

        public int Incluir(Investimento modelo)
        {
            int registro = -1;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            conn.Open();

            SqlTransaction transacao = conn.BeginTransaction("Transacao");

            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = transacao;

                    cmd.CommandText = @"INSERT INTO Investimento
                                        (UsuarioID, Apelido, Descricao, TipoInvestimentoID,
                                         InstituicaoID, MoedaID, RiscoID, Consulta, Ativo, DataInicio,
                                         Aplicacao, Resgate, Liquidacao, CodigoAnbima, 
                                         TaxaAdministracao, TaxaPerformance,
                                         InicialMinimo, MovimentoMinimo, SaldoMinimo)
                                        VALUES
                                        (@UsuarioID, @Apelido, @Descricao, @TipoInvestimentoID,
                                         @InstituicaoID, @MoedaID, @RiscoID, @Consulta, @Ativo, @DataInicio,
                                         @Aplicacao, @Resgate, @Liquidacao, @CodigoAnbima, 
                                         @TaxaAdministracao, @TaxaPerformance,
                                         @InicialMinimo, @MovimentoMinimo, @SaldoMinimo);

                                        SELECT CAST(@@IDENTITY AS INT) AS NovoID;";

                    cmd.Parameters.AddWithValue("@UsuarioID", modelo.UsuarioID);
                    cmd.Parameters.AddWithValue("@Apelido", modelo.Apelido);
                    cmd.Parameters.AddWithValue("@Descricao", (object)modelo.Descricao ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TipoInvestimentoID", modelo.TipoInvestimentoID);
                    cmd.Parameters.AddWithValue("@InstituicaoID", modelo.InstituicaoID);
                    cmd.Parameters.AddWithValue("@MoedaID", modelo.MoedaID);
                    cmd.Parameters.AddWithValue("@RiscoID", modelo.RiscoID);
                    cmd.Parameters.AddWithValue("@Consulta", (object)modelo.Consulta ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ativo", modelo.Ativo);
                    cmd.Parameters.AddWithValue("@DataInicio", (object)modelo.DataInicio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Aplicacao", modelo.Aplicacao);
                    cmd.Parameters.AddWithValue("@Resgate", modelo.Resgate);
                    cmd.Parameters.AddWithValue("@Liquidacao", modelo.Liquidacao);
                    cmd.Parameters.AddWithValue("@CodigoAnbima", (object)modelo.CodigoAnbima ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TaxaAdministracao", modelo.TaxaAdministracao);
                    cmd.Parameters.AddWithValue("@TaxaPerformance", modelo.TaxaPerformance);
                    cmd.Parameters.AddWithValue("@InicialMinimo", modelo.InicialMinimo);
                    cmd.Parameters.AddWithValue("@MovimentoMinimo", modelo.MovimentoMinimo);
                    cmd.Parameters.AddWithValue("@SaldoMinimo", modelo.SaldoMinimo);

                    registro = (int)cmd.ExecuteScalar();
                    transacao.Commit();
                }
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao incluir investimento.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return registro;
        }

        public int Alterar(Investimento modelo)
        {
            int registro = -1;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            conn.Open();

            SqlTransaction transacao = conn.BeginTransaction("Transacao");

            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = transacao;

                    cmd.CommandText = @"UPDATE Investimento SET
                                        Apelido = @Apelido,
                                        Descricao = @Descricao,
                                        TipoInvestimentoID = @TipoInvestimentoID,
                                        InstituicaoID = @InstituicaoID,
                                        MoedaID = @MoedaID,
                                        RiscoID = @RiscoID,
                                        Consulta = @Consulta,
                                        Ativo = @Ativo,
                                        DataInicio = @DataInicio,
                                        Aplicacao = @Aplicacao,
                                        Resgate = @Resgate,
                                        Liquidacao = @Liquidacao,
                                        CodigoAnbima = @CodigoAnbima,
                                        TaxaAdministracao = @TaxaAdministracao,
                                        TaxaPerformance = @TaxaPerformance,
                                        InicialMinimo = @InicialMinimo,
                                        MovimentoMinimo = @MovimentoMinimo,
                                        SaldoMinimo = @SaldoMinimo
                                        WHERE InvestimentoID = @InvestimentoID;

                                        SELECT CAST(@@ERROR AS INT) AS Erro;";

                    cmd.Parameters.AddWithValue("@Apelido", modelo.Apelido);
                    cmd.Parameters.AddWithValue("@Descricao", (object)modelo.Descricao ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TipoInvestimentoID", modelo.TipoInvestimentoID);
                    cmd.Parameters.AddWithValue("@InstituicaoID", modelo.InstituicaoID);
                    cmd.Parameters.AddWithValue("@MoedaID", modelo.MoedaID);
                    cmd.Parameters.AddWithValue("@RiscoID", modelo.RiscoID);
                    cmd.Parameters.AddWithValue("@Consulta", (object)modelo.Consulta ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ativo", modelo.Ativo);
                    cmd.Parameters.AddWithValue("@DataInicio", (object)modelo.DataInicio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Aplicacao", modelo.Aplicacao);
                    cmd.Parameters.AddWithValue("@Resgate", modelo.Resgate);
                    cmd.Parameters.AddWithValue("@Liquidacao", modelo.Liquidacao);
                    cmd.Parameters.AddWithValue("@CodigoAnbima", (object)modelo.CodigoAnbima ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TaxaAdministracao", modelo.TaxaAdministracao);
                    cmd.Parameters.AddWithValue("@TaxaPerformance", modelo.TaxaPerformance);
                    cmd.Parameters.AddWithValue("@InicialMinimo", modelo.InicialMinimo);
                    cmd.Parameters.AddWithValue("@MovimentoMinimo", modelo.MovimentoMinimo);
                    cmd.Parameters.AddWithValue("@SaldoMinimo", modelo.SaldoMinimo);
                    cmd.Parameters.AddWithValue("@InvestimentoID", modelo.InvestimentoID);

                    if ((int)cmd.ExecuteScalar() == 0)
                        registro = (int)modelo.TipoInvestimentoID;

                    transacao.Commit();

                    return registro;
                }
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao alterar investimento.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void Excluir(int investimentoID)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            conn.Open();

            SqlTransaction transacao = conn.BeginTransaction("Transacao");

            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = transacao;


                    // Exclui as cotações (caso seja investimento da CVM)
                    cmd.CommandText = @"DELETE FROM INVESTIMENTOCOTACAO
                                        WHERE InvestimentoID = @InvestimentoID;";
                    cmd.Parameters.AddWithValue("@InvestimentoID", investimentoID);
                    cmd.ExecuteScalar();
                    cmd.Parameters.Clear();

                    // Exclui as cotações (caso seja ações da bovespa)
                    cmd.CommandText = @"DELETE FROM ACAOCOTACAO
                                        WHERE InvestimentoID = @InvestimentoID;";
                    cmd.Parameters.AddWithValue("@InvestimentoID", investimentoID);
                    cmd.ExecuteScalar();
                    cmd.Parameters.Clear();

                    // Exclui o investimento
                    cmd.CommandText = @"DELETE FROM Investimento
                                       WHERE InvestimentoID = @InvestimentoID;";
                    cmd.Parameters.AddWithValue("@InvestimentoID", investimentoID);
                    cmd.ExecuteScalar();

                    transacao.Commit();
                }
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao excluir investimento.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public bool CotacaoDia(int investimentoID, DateTime data, ref decimal valorCotacao)
        {
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand query = new SqlCommand())
                {
                    query.Connection = conn;
                    query.CommandType = CommandType.Text;
                    query.CommandText = @"SELECT VrCotacao, CotacaoDaCVM
                                          FROM InvestimentoCotacao
                                          WHERE InvestimentoID = @InvestimentoID
                                          AND Data = @Data;";

                    // Define os parâmetros necessários
                    query.Parameters.AddWithValue("@InvestimentoID", investimentoID);
                    query.Parameters.AddWithValue("@Data", data);

                    using (SqlDataReader dr = query.ExecuteReader())
                    {
                        // Verifica se há linhas
                        if (dr.HasRows)
                        {
                            // posiciona no primeiro registro
                            dr.Read();
                            // Somente o primeiro registro interessa
                            valorCotacao = dr.GetDecimal(0);
                            return dr.GetBoolean(1);
                        }
                        else
                        {
                            valorCotacao = 0;
                            return false;
                        }
                    }
                }
            }
        }

        public bool HaInvestimentos(int investimentoID)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand(@"SELECT COUNT(*) TOTAL
                                              FROM MovimentoInvestimento 
                                              WHERE InvestimentoID = @InvestimentoID;", conn);

            cmd.Parameters.AddWithValue("@InvestimentoID", investimentoID);

            conn.Open();
            try
            {
                return ((int)cmd.ExecuteScalar() != 0);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }        
    }
}
