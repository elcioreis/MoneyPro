using Modelos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class AcaoCotacaoDAL
    {
        public int Incluir(AcaoCotacao modelo)
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

                    cmd.CommandText = "INSERT INTO AcaoCotacao " +
                                      "(InvestimentoID, Codigo, Nome, Ibovespa, Data, Abertura, " +
                                      " Minimo, Maximo, Medio, Ultimo, Oscilacao) " +
                                      "VALUES " +
                                      "(@InvestimentoID, @Codigo, @Nome, @Ibovespa, @Data, @Abertura, " +
                                      " @Minimo, @Maximo, @Medio, @Ultimo, @Oscilacao); " +

                                      "SELECT CAST(@@IDENTITY AS INT) AS NovoID;";

                    cmd.Parameters.AddWithValue("@InvestimentoID", modelo.InvestimentoID);
                    cmd.Parameters.AddWithValue("@Codigo", modelo.Codigo);
                    cmd.Parameters.AddWithValue("@Nome", modelo.Nome);
                    cmd.Parameters.AddWithValue("@Ibovespa", modelo.Ibovespa);
                    cmd.Parameters.AddWithValue("@Data", modelo.Data);
                    cmd.Parameters.AddWithValue("@Abertura", (object)modelo.Abertura ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Minimo", (object)modelo.Minimo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Maximo", (object)modelo.Maximo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Medio", (object)modelo.Medio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ultimo", (object)modelo.Ultimo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Oscilacao", (object)modelo.Oscilacao ?? DBNull.Value);

                    registro = (int)cmd.ExecuteScalar();
                    transacao.Commit();
                }
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao incluir cotação da ação " + modelo.Codigo + ".", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return registro;
        }

        public int Alterar(AcaoCotacao modelo)
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

                    cmd.CommandText = "UPDATE AcaoCotacao SET " +
                                      "InvestimentoId = @InvestimentoID, " +
                                      "Codigo = @Codigo, " +
                                      "Nome = @Nome, " +
                                      "Ibovespa = @Ibovespa, " +
                                      "Data = @Data, " +
                                      "Abertura = @Abertura, " +
                                      "Minimo = @Minimo, " +
                                      "Maximo = @Maximo, " +
                                      "Medio = @Medio, " +
                                      "Ultimo = @Ultimo, " +
                                      "Oscilacao = @Oscilacao " +
                                      "WHERE AcaoCotacaoID = @AcaoCotacaoID; " +

                                      "SELECT CAST(@@ERROR AS INT) AS Erro;";

                    cmd.Parameters.AddWithValue("@InvestimentoID", modelo.InvestimentoID);
                    cmd.Parameters.AddWithValue("@Codigo", modelo.Codigo);
                    cmd.Parameters.AddWithValue("@Nome", modelo.Nome);
                    cmd.Parameters.AddWithValue("@Ibovespa", modelo.Ibovespa);
                    cmd.Parameters.AddWithValue("@Data", modelo.Data);
                    cmd.Parameters.AddWithValue("@Abertura", (object)modelo.Abertura ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Minimo", (object)modelo.Minimo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Maximo", (object)modelo.Maximo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Medio", (object)modelo.Medio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ultimo", (object)modelo.Ultimo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Oscilacao", (object)modelo.Oscilacao ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AcaoCotacaoID", modelo.AcaoCotacaoID);

                    if ((int)cmd.ExecuteScalar() == 0)
                        registro = modelo.AcaoCotacaoID;

                    transacao.Commit();

                    return registro;
                }
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao incluir cotação da ação " + modelo.Codigo + ".", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }


        public int ExisteCotacao(int investimentoID, DateTime data)
        {
            int acaoCotacaoID = 0;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("SELECT " +
                                            "COALESCE((SELECT AcaoCotacaoID " +
                                                      "FROM AcaoCotacao " +
                                                      "WHERE InvestimentoID = @InvestimentoID " +
                                                      "AND CONVERT(DATETIME, FLOOR(CONVERT(FLOAT(24), Data))) = @Data), 0) AS AcaoCotacaoID;", conn);

            cmd.Parameters.AddWithValue("@InvestimentoID", investimentoID);
            cmd.Parameters.AddWithValue("@Data", data.Date);

            conn.Open();
            try
            {
                acaoCotacaoID = (int)cmd.ExecuteScalar();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return acaoCotacaoID;
        }

        public DataTable BuscarCotacoes()
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(
                @"SELECT Inve.InvestimentoID, Inve.Apelido, Inve.Descricao, Inve.Consulta
                         FROM Investimento Inve
                         INNER JOIN TipoInvestimento Tipo ON Tipo.TipoInvestimentoID = Inve.TipoInvestimentoID
                         WHERE Tipo.Acao = 1
                         ORDER BY Inve.Apelido ASC;", conn);

            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public bool AtualizarCotacao(CotacaoHistoricaB3 cotacaoB3, int InvestimentoID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Dados.Conexao))
                {
                    conn.Open();
                    // Instancia um adaptador
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        // Instancia um comando
                        using (SqlCommand proc = new SqlCommand())
                        {
                            proc.Connection = conn;
                            proc.CommandType = CommandType.StoredProcedure;
                            proc.CommandText = "stpAtualizaCotacaoHistoricaB3";

                            // Define os parâmetros necessários
                            //proc.Parameters.AddWithValue("@InvestimentoID", investimentoID);

                            proc.Parameters.AddWithValue("@TipReg", cotacaoB3.Tipreg);
                            proc.Parameters.AddWithValue("@DataPregao", cotacaoB3.DataPregao);
                            proc.Parameters.AddWithValue("@CodBDI", cotacaoB3.CodBDI);
                            proc.Parameters.AddWithValue("@CodNeg", cotacaoB3.CodNeg);
                            proc.Parameters.AddWithValue("@TpMerc", cotacaoB3.TpMerc);
                            proc.Parameters.AddWithValue("@NomRes", cotacaoB3.NomRes);
                            proc.Parameters.AddWithValue("@Especi", cotacaoB3.Especi);
                            proc.Parameters.AddWithValue("@PrazoT", cotacaoB3.PrazoT);
                            proc.Parameters.AddWithValue("@ModRef", cotacaoB3.ModRef);
                            proc.Parameters.AddWithValue("@PreAbe", cotacaoB3.PreAbe);
                            proc.Parameters.AddWithValue("@PreMax", cotacaoB3.PreMax);
                            proc.Parameters.AddWithValue("@PreMin", cotacaoB3.PreMin);
                            proc.Parameters.AddWithValue("@PreMed", cotacaoB3.PreMed);
                            proc.Parameters.AddWithValue("@PreUlt", cotacaoB3.PreUlt);
                            proc.Parameters.AddWithValue("@PreOFC", cotacaoB3.PreOFC);
                            proc.Parameters.AddWithValue("@PreOFV", cotacaoB3.PreOFV);
                            proc.Parameters.AddWithValue("@TotNeg", cotacaoB3.TotNeg);
                            proc.Parameters.AddWithValue("@QuaTot", cotacaoB3.QuaTot);
                            proc.Parameters.AddWithValue("@VolTot", cotacaoB3.VolTot);
                            proc.Parameters.AddWithValue("@PreExe", cotacaoB3.PreExe);
                            proc.Parameters.AddWithValue("@IndOPC", cotacaoB3.IndOPC);
                            proc.Parameters.AddWithValue("@DatVen", cotacaoB3.DatVen);
                            proc.Parameters.AddWithValue("@FatCot", cotacaoB3.FatCot);
                            proc.Parameters.AddWithValue("@PtoExe", cotacaoB3.PtoExe);
                            proc.Parameters.AddWithValue("@CodIsi", cotacaoB3.CodIsi);
                            proc.Parameters.AddWithValue("@DisMes", cotacaoB3.DisMes);
                            proc.Parameters.AddWithValue("@InvestimentoID", InvestimentoID);

                            proc.ExecuteNonQuery();
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
