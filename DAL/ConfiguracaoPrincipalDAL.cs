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
    public class ConfiguracaoPrincipalDAL
    {
        public ConfiguracaoPrincipalDAL()
        {
            VerificaExistenciaConfiguracoes();
        }

        private void VerificaExistenciaConfiguracoes()
        {
            // Verifica se há o registro na tabela ConfiguracaoPrincipal, se não houver, criar o padrão.

            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "stpRestaurarConfiguracaoPrincipal";

                    cmd.Parameters.AddWithValue("@Reconfigurar", false);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void ArmazenarConfiguracaoPrincipal(ConfiguracaoPrincipal config)
        {
            // Armazena as configurações da tela principal

            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "stpManterConfiguracaoPrincipal";

                    cmd.Parameters.AddWithValue("@panelEsquerdoWidth", config.PanelEsquerdoWidth);
                    cmd.Parameters.AddWithValue("@Contas_ExibeAtivas", config.Contas_ExibeAtivas);
                    cmd.Parameters.AddWithValue("@Planejamento_ExibeAtivas", config.Planejamento_ExibeAtivas);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        private void Reconfigurar()
        {
            // Exclui a configuração atual e inclui a configuração padrão

            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "stpRestaurarConfiguracaoPrincipal";

                    cmd.Parameters.AddWithValue("@Reconfigurar", true);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public DataTable CarregarConfiguracaoPrincipal()
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
                    SqlCommand query = new SqlCommand(@"SELECT ConfiguracaoID, PanelEsquerdoWidth, 
                                                               Contas_ExibeAtivas, Planejamento_ExibeAtivas,
                                                               DiasPrevisaoSaldoNegativo, NumeroEmContaBanco
                                                        FROM ConfiguracaoPrincipal
                                                        WHERE ConfiguracaoID = 1;", conn);

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
