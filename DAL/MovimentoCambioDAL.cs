using Modelos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAL
{
    public class MovimentoCambioDAL
    {
        public bool ManterCambio(MovimentoCambio movtoCambio)
        {
            bool sucesso = false;

            try
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
                        cmd.CommandText = "stpManterCambio";
                        cmd.Parameters.AddWithValue("@MovimentoContaID", movtoCambio.MovimentoContaID);
                        cmd.Parameters.AddWithValue("@UsuarioID", movtoCambio.UsuarioID);
                        cmd.Parameters.AddWithValue("@DataHora", movtoCambio.DataHora);
                        cmd.Parameters.AddWithValue("@Lancamento", movtoCambio.Lancamento);
                        cmd.Parameters.AddWithValue("@Descricao", movtoCambio.Descricao);
                        cmd.Parameters.AddWithValue("@Compra", movtoCambio.Compra);
                        cmd.Parameters.AddWithValue("@CrdDeb", movtoCambio.Compra ? "C" : "D");
                        cmd.Parameters.AddWithValue("@ContaOrigemID", movtoCambio.ContaOrigemID);
                        cmd.Parameters.AddWithValue("@ContaDestinoID", movtoCambio.ContaDestinoID);
                        cmd.Parameters.AddWithValue("@ValorOrigem", movtoCambio.ValorOrigem);
                        cmd.Parameters.AddWithValue("@ValorDestino", movtoCambio.ValorDestino);
                        cmd.Parameters.AddWithValue("@Taxa", movtoCambio.Taxa);
                        cmd.Parameters.AddWithValue("@Cotacao", movtoCambio.Cotacao);

                        if (movtoCambio.RespTaxa == Tipo.ResponsavelTaxa.Destino)
                            cmd.Parameters.AddWithValue("@ContaTaxaID", movtoCambio.ContaDestinoID);
                        else
                            cmd.Parameters.AddWithValue("@ContaTaxaID", movtoCambio.ContaOrigemID);

                        cmd.ExecuteNonQuery();

                        sucesso = true;
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sucesso = false;
            }

            return sucesso;
        }

        public DataTable MoedasMercadoBitCoin()
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia uma pesquisa
            SqlCommand query = new SqlCommand(
                @"SELECT Apelido, Simbolo
                  FROM Moeda
                  WHERE MercadoBitCoin = 1
                  ORDER BY Apelido ASC", conn);

            // Coloca a pesquisa no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorna a tabela
            return table;
        }
    }
}
