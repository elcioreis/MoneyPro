using Modelos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAL
{
    public class TransacaoCambioDAL
    {
        public DataTable ListarTransacoes(int contaOrigemID, int contaDestinoID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    // Instancia uma pesquisa

                    SqlCommand query = new SqlCommand(
                        @"SELECT Orig.ContaID ContaOrigemID,
                                 Orig.MoedaID MoedaOrigemID, MOri.Simbolo SimboloOrigem,
                                 'Venda de ' + MOri.Apelido + ' (' + MOri.Simbolo + ')' Transacao, 
                                 Dest.ContaID ContaDestinoID,
                                 Dest.MoedaID MoedaDestinoID, MDes.Simbolo SimboloDestino,
                                 CAST(0 AS BIT) Compra
                          FROM Conta Orig
                               JOIN Moeda MOri ON MOri.MoedaID = Orig.MoedaID
                               JOIN Conta Dest ON Dest.ContaID = @DestinoID
                               JOIN Moeda MDes ON MDes.MoedaID = Dest.MoedaID
                          WHERE Orig.ContaID = @OrigemID

                          UNION

                          SELECT Orig.ContaID ContaOrigemID,
                                 Orig.MoedaID MoedaOrigemID, MOri.Simbolo SimboloOrigem,
                                 'Compra de ' + MOri.Apelido + ' (' + MOri.Simbolo + ')' Transacao, 
                                 Dest.ContaID ContaDestinoID,
                                 Dest.MoedaID MoedaDestinoID, MDes.Simbolo SimboloDestino,
                                 CAST(1 AS BIT) Compra
                          FROM Conta Orig
                               JOIN Moeda MOri ON MOri.MoedaID = Orig.MoedaID
                               JOIN Conta Dest ON Dest.ContaID = @DestinoID
                               JOIN Moeda MDes ON MDes.MoedaID = Dest.MoedaID
                          WHERE Orig.ContaID = @OrigemID;", conn);

                    // Passa os parâmetros
                    query.Parameters.AddWithValue("@OrigemID", contaOrigemID);
                    query.Parameters.AddWithValue("@DestinoID", contaDestinoID);

                    // Coloca a pesquisa no adaptador
                    da.SelectCommand = query;
                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorna a tabela
            return table;
        }

        public DataTable ListarContasDestino(int usuarioID, int contaAtualID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia uma pesquisa

            // Lista as contas de câmbio com moeda diferente da usada pela conta atual
            SqlCommand query = new SqlCommand(
                @"SELECT Cnta.*
                  FROM Conta Cnta
                       JOIN TipoConta TpCt ON TpCt.TipoContaID = Cnta.TipoContaID
                                          AND TpCt.Cambio = 1
                  WHERE Cnta.UsuarioID = @UsuarioID
                  AND   Cnta.MoedaID != (SELECT MoedaID FROM Conta WHERE ContaID = @ContaID)
                  AND   Cnta.InstituicaoID = (SELECT InstituicaoID FROM Conta WHERE ContaID = @ContaID);", conn);

            // Passa os parâmetros
            query.Parameters.AddWithValue("@UsuarioID", usuarioID);
            query.Parameters.AddWithValue("@ContaID", contaAtualID);

            // Coloca a pesquisa no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorna a tabela
            return table;
        }

        public bool ManterTradeHitBTC(HitBTCTrade trade)
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
                        cmd.CommandText = "stpManterTradeHitBTC";

                        cmd.Parameters.AddWithValue("@TradeID", trade.TradeID);
                        cmd.Parameters.AddWithValue("@Date", trade.Date);
                        cmd.Parameters.AddWithValue("@Instrument", trade.Instrument);
                        cmd.Parameters.AddWithValue("@OrderID", trade.OrderID);
                        cmd.Parameters.AddWithValue("@Side", trade.Side);
                        cmd.Parameters.AddWithValue("@Quantity", trade.Quantity);
                        cmd.Parameters.AddWithValue("@Price", trade.Price);
                        cmd.Parameters.AddWithValue("@Volume", trade.Volume);
                        cmd.Parameters.AddWithValue("@Fee", trade.Fee);
                        cmd.Parameters.AddWithValue("@Rebate", trade.Rebate);
                        cmd.Parameters.AddWithValue("@Total", trade.Total);
                        cmd.Parameters.AddWithValue("@Principal", trade.Principal);
                        cmd.Parameters.AddWithValue("@Secundaria", trade.Secundaria);
                        cmd.Parameters.AddWithValue("@WebService", true);

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

        public bool ManterTickerHitBTC(HitBTCTicker ticker)
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
                        cmd.CommandText = "stpManterTickerHitBTC";

                        cmd.Parameters.AddWithValue("@HitSymbol", ticker.Symbol);
                        cmd.Parameters.AddWithValue("@HitTimeStamp_Local", ticker.TimeStamp.ToLocalTime());
                        cmd.Parameters.AddWithValue("@HitTimeStamp_UTC", ticker.TimeStamp);
                        cmd.Parameters.AddWithValue("@HitAsk", ticker.Ask);
                        cmd.Parameters.AddWithValue("@HitBid", ticker.Bid);
                        cmd.Parameters.AddWithValue("@HitLast", ticker.Last);
                        cmd.Parameters.AddWithValue("@HitOpen", ticker.Open);
                        cmd.Parameters.AddWithValue("@HitLow", ticker.Low);
                        cmd.Parameters.AddWithValue("@HitHigh", ticker.High);
                        cmd.Parameters.AddWithValue("@HitVolume", ticker.Volume);
                        cmd.Parameters.AddWithValue("@HitVolumeQuote", ticker.VolumeQuote);

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

    }
}
