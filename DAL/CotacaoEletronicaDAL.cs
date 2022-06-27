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
    public class CotacaoEletronicaDAL
    {
        public void GravarAtualizacaoM02_M03()
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
                    cmd.CommandText = "stpGravarAtualizacaoM02_M03";

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }


        public void GravarAtualizacaoM04_M11()
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
                    cmd.CommandText = "stpGravarAtualizacaoM04_M11";

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }


        public void InformaAtualizacao()
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
                    cmd.CommandText = "stpInformaAtualizacao";

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public DataTable Listar()
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand("SELECT " +
                                              "CotacaoCVMID, CNPJ, Data, VrCotacao, VrTotalCarteira, " +
                                              "VrPatrimonioLiquido, VrCaptacaoDia, VrResgateDia, NroCotistas " +
                                              "FROM CotacaoCVM;", conn);

            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public bool DataExiste(DateTime data)
        {
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {

                // Instancia um comando
                SqlCommand query = new SqlCommand("SELECT COUNT(*) FROM CotacaoCVM " +
                                                  "WHERE Data = @Data;", conn);

                query.Parameters.AddWithValue("@Data", data);

                try
                {
                    conn.Open();
                    return ((int)query.ExecuteScalar() > 0);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void IncluirCotacaoBTC(CotacaoMoedas moeda)
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
                    cmd.CommandText = "stpManterCotacaoMoeda";

                    // Campos obrigatórios
                    cmd.Parameters.AddWithValue("@Data", moeda.Data);
                    cmd.Parameters.AddWithValue("@DeMoedaID", moeda.DeMoedaId);
                    cmd.Parameters.AddWithValue("@Cotacao", moeda.Cotacao);
                    cmd.Parameters.AddWithValue("@ParaMoedaID", moeda.ParaMoedaId);
                    cmd.Parameters.AddWithValue("@Negociado", moeda.Negociado);
                    // Campos opcionais
                    cmd.Parameters.AddWithValue("@Lowest", (object)moeda.Lowest ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Volume", (object)moeda.Volume ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Amount", (object)moeda.Amount ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AvgPrice", (object)moeda.AvgPrice ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Opening", (object)moeda.Opening ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Closing", (object)moeda.Closing ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Highest", (object)moeda.Highest ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Quantity", (object)moeda.Quantity ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public DateTime UltimaCotacaoMercadoBitCoin(string moedaSimbolo)
        {
            //
            // Retorna o primeiro que o sistema deve buscar cotações de BTC
            // 

            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                SqlCommand query = new SqlCommand("SELECT dbo.fncPrimeiroDiaMoedaMercadoBitCoinNecessario(@Simbolo) AS Primeiro;", conn);
                query.Parameters.AddWithValue("@Simbolo", moedaSimbolo);

                try
                {
                    conn.Open();
                    return (DateTime)query.ExecuteScalar();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void InsereAtualizaCotacaoCVM(CotacaoCVM modelo)
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
                    cmd.CommandText = "stpInsereAtualizaCotacaoCVM";
                    cmd.Parameters.AddWithValue("@CNPJ", modelo.CNPJ);
                    cmd.Parameters.AddWithValue("@Data", modelo.Data);
                    cmd.Parameters.AddWithValue("@VrCotacao", (object)modelo.VrCotacao ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VrTotalCarteira", (object)modelo.VrTotalCarteira ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VrPatrimonioLiquido", (object)modelo.VrPatrimonioLiquido ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VrCaptacaoDia", (object)modelo.VrCaptacaoDia ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VrResgateDia", (object)modelo.VrResgateDia ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NroCotistas", (object)modelo.NroCotistas ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void ManterCotacaoMoedaBancoCentral(int moedaDe, int moedaPara, DateTime data, decimal cotacao)
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
                    cmd.CommandText = "stpManterCotacaoMoedaBancoCentral";
                    cmd.Parameters.AddWithValue("@MoedaDe", moedaDe);
                    cmd.Parameters.AddWithValue("@MoedaPara", moedaPara);
                    cmd.Parameters.AddWithValue("@Data", data);
                    cmd.Parameters.AddWithValue("@Cotacao", cotacao);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        string x = e.Message;
                    }
                }
                conn.Close();
            }
        }

        public int AtualizaFundosCVM(DateTime data)
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
                    cmd.CommandText = "stpAtualizaCarteiraFundos";

                    cmd.Parameters.AddWithValue("@Data", data);

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void AtualizaAcoesBOVESPA()
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
                    cmd.CommandText = "stpAtualizaAcoesBOVESPA";

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ListarCodigosCVMdeInteresse()
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando

            // É um select simples, apenas tirando os pontos, barras e traços
            SqlCommand query = new SqlCommand(@"SELECT REPLACE(REPLACE(REPLACE(Consulta, '.', ''),'/',''),'-','') AS CodigoCVM
                                                FROM Investimento
                                                WHERE Consulta IS NOT NULL
                                                ORDER BY CodigoCVM;", conn);

            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public DataTable ListarCNPJFundosCVM()
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando

            // É um select simples, apenas tirando os pontos, barras e traços
            SqlCommand query = new SqlCommand(@"SELECT Consulta AS CodigoCVM
                                                FROM Investimento
                                                WHERE Consulta IS NOT NULL
                                                ORDER BY CodigoCVM;", conn);

            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public bool FaltaCotacao(DateTime data)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            try
            {
                conn.Open();

                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // A query a baixo conta quantas cotações estão faltando, 
                    // portanto, se maior que zero é necesário a importação.
                    // Somente FUNDOS de investimento ATIVOS
                    cmd.CommandText = @"SELECT COALESCE((SELECT COUNT(*) Itens                    
                                                         FROM Investimento Invt                    
                                                         JOIN TipoInvestimento Tipo ON Tipo.TipoInvestimentoID = Invt.TipoInvestimentoID AND Tipo.Acao = 0 AND Tipo.Fundo = 1                    
                                                         LEFT JOIN InvestimentoCotacao Cota ON Cota.InvestimentoID = Invt.InvestimentoID AND Cota.Data = @Data                    
                                                         WHERE Invt.Ativo = 1 AND (Invt.DataInicio IS NULL OR Invt.DataInicio < @Data)                    
                                                         GROUP BY Cota.Data                    
                                                         HAVING Cota.Data IS NULL), 0) Itens;";

                    cmd.Parameters.AddWithValue("@Data", data);

                    return ((Int32)cmd.ExecuteScalar() > 0);

                }
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
