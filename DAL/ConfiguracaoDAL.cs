using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConfiguracaoDAL
    {
        public DataTable CarregarConfiguracoes()
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(@"SELECT MoneyProID, BaseProducao, CMV_NomeSistemaCliente, CMV_CPFResponsavelSC,
                                                       CMV_NomeResponsavelSC, CMV_IdentificacaoSC, CMV_SenhaSC, DtInicioUtilizacao,
                                                       SiteCVM, SiteCVM_Lote, AtualizarTudo, 
                                                       COALESCE(AtualizacaoM02_M03, CONVERT(DATE, '01/01/2017',  103)) AtualizacaoM02_M03,
                                                       COALESCE(AtualizacaoM04_M11, CONVERT(DATE, '01/01/2017',  103)) AtualizacaoM04_M11
                                                FROM MoneyPro
                                                WHERE MoneyProID = (SELECT MAX(MoneyProID) FROM MoneyPro);", conn);

            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public DataTable UltimasCotacoes()
        {
            DataTable tabela = new DataTable();

            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                using (SqlCommand comando = new SqlCommand("EXEC stpDataMinimaParaPegarCotacao;", conn))
                {
                    SqlDataReader reader = comando.ExecuteReader();
                    tabela.Load(reader);
                }
            }

            return tabela;
        }

        public void NovoCaminhoBackup(string caminho)
        {
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                //using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    SqlCommand cmd = new SqlCommand(@"UPDATE MoneyPro
                                                      SET CaminhoBackup = @Caminho;", conn);

                    cmd.Parameters.AddWithValue("@Caminho", caminho);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void AtualizaDataBackup()
        {
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                //using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    SqlCommand cmd = new SqlCommand(@"UPDATE MoneyPro
                                                      SET UltimoBackup = GETDATE();", conn);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public string CaminhoBackup()
        {
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    SqlCommand query = new SqlCommand(@"SELECT CaminhoBackup
                                                        FROM MoneyPro;", conn);

                    da.SelectCommand = query;

                    using (DataTable table = new DataTable())
                    {
                        da.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            // Certifica que o caminho termina em contrabarra
                            return table.Rows[0].Field<string>("CaminhoBackup").TrimEnd('\\') + "\\"; ;
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
            }
        }

        public string ExecutaBackup(string NomeBase)
        {

            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                //using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    SqlCommand cmd = new SqlCommand(@"BACKUP DATABASE [MoneyPro] TO  DISK = @DESTINO 
                                                      WITH NOFORMAT, INIT,  
                                                      NAME = N'MoneyPro-Full Database Backup', 
                                                      SKIP, NOREWIND, NOUNLOAD,  STATS = 10;", conn);

                    string destino = CaminhoBackup() + NomeBase + "_" + DateTime.Now.ToString("yyMMdd-HHmm") + ".bak";

                    cmd.Parameters.AddWithValue("@DESTINO", destino);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        return "";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
            }
        }

        public Boolean TruncarArquivoLogSQLServer()
        {
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                //using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    SqlCommand cmd = new SqlCommand(@"EXEC stpTruncarLog;", conn);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        public Boolean LimparTickers()
        {
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                //using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    SqlCommand cmd = new SqlCommand(@"EXEC stpLimparTicker;", conn);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

    }
}
