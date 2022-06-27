using System;
using Modelos;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CotacaoMoedasDAL
    {
        public void InserirCotacaoMoeda(CotacaoMoedas modelo)
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

                    cmd.Parameters.AddWithValue("Data", modelo.Data);
                    cmd.Parameters.AddWithValue("DeMoedaID", modelo.DeMoedaId);
                    cmd.Parameters.AddWithValue("Cotacao", modelo.Cotacao);
                    cmd.Parameters.AddWithValue("ParaMoedaID", modelo.ParaMoedaId);
                    cmd.Parameters.AddWithValue("Lowest", (object)modelo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("Volume", (object)modelo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("Amount", (object)modelo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("AvgPrice", (object)modelo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("Opening", (object)modelo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("Closing", (object)modelo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("Highest", (object)modelo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("Quantity", (object)modelo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("Negociado", modelo.Negociado);
                    cmd.Parameters.AddWithValue("MovimentoContaID", modelo.MovimentoContaID);
                    cmd.Parameters.AddWithValue("ContaIDTaxa", modelo.ContaIDTaxa);
                    cmd.Parameters.AddWithValue("AliquotaTaxa", modelo.AliquotaTaxa);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
