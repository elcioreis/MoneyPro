using DAL;
using Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;

namespace MoneyPro.Rotinas
{
    public class AcessoHitBTC : IDisposable
    {

        #region Disposable

        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~AcessoHitBTC()
        {
            Dispose(false);
        }

        #endregion Disposable

        readonly FmPrincipal Origem;

        internal string Servico = "HITBTC";
        internal int UsuarioID { get; set; }

        internal Chaves chaves;

        public AcessoHitBTC(FmPrincipal origem, int usuarioID)
        {
            this.UsuarioID = usuarioID;
            this.Origem = origem;
            chaves = CarregarCredenciais();
        }

        private Chaves CarregarCredenciais()
        {
            Chaves chaves = new Chaves();

            DataTable tabela = new DataTable();

            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                using (SqlCommand comando = new SqlCommand("EXEC stpAcessoWebService @UsuarioID, @Servico;", conn))
                {
                    comando.Parameters.AddWithValue("@UsuarioID", UsuarioID);
                    comando.Parameters.AddWithValue("@Servico", Servico);

                    SqlDataReader reader = comando.ExecuteReader();
                    tabela.Load(reader);
                }
            }

            if (tabela.Rows.Count == 1)
            {

                //chaves.API = "wS38Ly2LUczp-rzrF5oR7TYRPiUvKjie";
                //chaves.Segredo = "xFcz1nLQP7SS1Vg6AiX35bkKcaM-VXg0";
                chaves.API = (string)tabela.Rows[0]["API"];
                chaves.Segredo = (string)tabela.Rows[0]["Segredo"];
            }

            return chaves;
        }

        private DataTable ListarSimbolosHitBTC()
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
                    using (SqlCommand query = new SqlCommand(
                        @"SELECT Base.Simbolo, Base.SimboloWebService, 
                                 MAX(Base.UltimaTradeID) UltimaTradeID, 
                                 MAX(Base.DataAbertura) DataAbertura
                          FROM (SELECT MEle.Simbolo, MEle.SimboloWebService, 0  UltimaTradeID, Cnta.DataAbertura
                                FROM Instituicao Inst
                                     JOIN Conta Cnta ON Cnta.InstituicaoID = Inst.InstituicaoID
                                     JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID 
                                     JOIN MoedaEletronica MEle ON MEle.MoedaID = Moed.MoedaID
                                WHERE Inst.HitBTC = 1

                                UNION ALL

                                SELECT MEle.Simbolo, MEle.SimboloWebService, MAX(THit.TradeID) UltimaTradeID, Cnta.DataAbertura
                                FROM TradeHitBTC THit
                                     JOIN MoedaEletronica MEle ON MEle.Simbolo = THit.Instrument
                                     JOIN Conta Cnta ON Cnta.MoedaID = MEle.MoedaID
                                     JOIN Instituicao Inst ON Inst.InstituicaoID = Cnta.InstituicaoID
                                                          AND Inst.HitBTC = 1
                                GROUP BY MEle.Simbolo, MEle.SimboloWebService, Cnta.DataAbertura) Base
                          GROUP BY Base.Simbolo, Base.SimboloWebService
                          ORDER BY Base.Simbolo;", conn))
                    {
                        // Coloca a query no adaptador
                        da.SelectCommand = query;
                    }
                    // Popula a tabela
                    da.Fill(table);
                }
            }
            // Retorn a tabela
            return table;
        }

        public int CarregarTrades()
        {
            int QuantidadeTrades = 0;

            TransacaoCambioDAL dal = new TransacaoCambioDAL();

            DataTable listaSimbolos = ListarSimbolosHitBTC();

            foreach (DataRow linha in listaSimbolos.Rows)
            {
                string url = string.Format("https://api.hitbtc.com/api/2/history/trades?symbol={0}&sort=DESC&by=timestamp&limit=100", ((string)linha["SimboloWebService"]));
                var requisicaoWeb = WebRequest.CreateHttp(url);
                requisicaoWeb.Method = "GET";

                // Cria um cabeçalho de autenticação para o acesso à API HitBTC
                String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(chaves.API + ":" + chaves.Segredo));
                requisicaoWeb.Headers.Add("Authorization", "Basic " + encoded);

                using (var resposta = requisicaoWeb.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    using (StreamReader reader = new StreamReader(streamDados))
                    {
                        object objResponse = reader.ReadToEnd();

                        List<Trade> listaTrade = JsonConvert.DeserializeObject<List<Trade>>(objResponse.ToString());

                        foreach (Trade trade in listaTrade)
                        {
                            if (trade.timestamp.ToLocalTime() >= (DateTime)linha["DataAbertura"] && trade.id > (long)linha["UltimaTradeID"])
                            {
                                HitBTCTrade hit = new HitBTCTrade();
                                hit.TradeID = trade.id;
                                hit.Date = trade.timestamp.ToLocalTime();
                                hit.Instrument = (string)linha["Simbolo"];
                                hit.OrderID = trade.orderId;
                                hit.Side = trade.side;
                                hit.Quantity = trade.quantity;
                                hit.Price = trade.price;
                                hit.Volume = trade.quantity * trade.price;
                                hit.Fee = trade.fee;
                                hit.Rebate = 0;
                                hit.Total = (trade.side == "sell" ? 1 : -1) * trade.quantity * trade.price - trade.fee;
                                hit.Principal = ((string)linha["Simbolo"]).Split('/').First();
                                hit.Secundaria = ((string)linha["Simbolo"]).Split('/').Last();

                                dal.ManterTradeHitBTC(hit);

                                QuantidadeTrades++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    streamDados.Close();
                    resposta.Close();
                }
            }

            if (QuantidadeTrades != 0)
            {
                Geral.ExecutarMovimentosContaTradeHitBTC(UsuarioID, 0);
            }

            if (Origem.toolStripStatusLabelObservacoes.Tag == null)
            {
                Origem.toolStripStatusLabelObservacoes.Tag = QuantidadeTrades;
            }
            else
            {
                Origem.toolStripStatusLabelObservacoes.Tag = (int)Origem.toolStripStatusLabelObservacoes.Tag + QuantidadeTrades;
            }

            switch ((int)Origem.toolStripStatusLabelObservacoes.Tag)
            {
                case 0:
                    Origem.toolStripStatusLabelObservacoes.Text = "Nenhuma trade";
                    break;
                case 1:
                    Origem.toolStripStatusLabelObservacoes.Text = "Uma trade";
                    break;
                default:
                    Origem.toolStripStatusLabelObservacoes.Text = string.Format("{0} trades", (int)Origem.toolStripStatusLabelObservacoes.Tag);
                    break;
            }

            return QuantidadeTrades;
        }

        public void CarregarTicker()
        {
            TransacaoCambioDAL dal = new TransacaoCambioDAL();

            DataTable listaSimbolos = ListarSimbolosHitBTC();

            foreach (DataRow linha in listaSimbolos.Rows)
            {
                string url = string.Format("https://api.hitbtc.com/api/2/public/ticker/{0}", ((string)linha["SimboloWebService"]));

                var requisicaoWeb = WebRequest.CreateHttp(url);
                requisicaoWeb.Method = "GET";
                //requisicaoWeb.Credentials = new NetworkCredential(chaves.API, chaves.Segredo);

                using (var resposta = requisicaoWeb.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    using (StreamReader reader = new StreamReader(streamDados))
                    {
                        object objResponse = reader.ReadToEnd();

                        HitBTCTicker ticker = JsonConvert.DeserializeObject<HitBTCTicker>(objResponse.ToString());

                        dal.ManterTickerHitBTC(ticker);

                        streamDados.Close();
                        resposta.Close();
                    }
                }
            }
        }

        public void CarregarCandles(HitBTCTiposEnum.period periodo)
        {
            //TransacaoCambioDAL dal = new TransacaoCambioDAL();

            DataTable listaSimbolos = ListarSimbolosHitBTC();

            foreach (DataRow linha in listaSimbolos.Rows)
            {
                string url = $"https://api.hitbtc.com/api/2/public/candles/{((string)linha["SimboloWebService"])}?period={periodo.ToString()}&sort=DESC&limit=30";

                var requisicaoWeb = WebRequest.CreateHttp(url);
                requisicaoWeb.Method = "GET";

                using (var resposta = requisicaoWeb.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    using (StreamReader reader = new StreamReader(streamDados))
                    {
                        object objResponse = reader.ReadToEnd();

                        List<HitBTCCandles> listaCandles = JsonConvert.DeserializeObject<List<HitBTCCandles>>(objResponse.ToString());

                        //listaCandles[0].close

                        List<DifusorDeFluxo> difusor = new List<DifusorDeFluxo>(listaCandles.Count);

                        foreach (HitBTCCandles candle in listaCandles)
                        {
                            difusor.Add(new DifusorDeFluxo
                            {
                                Quando = candle.timestamp.ToLocalTime(),
                                Valor = candle.close
                            });
                        }



                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 03, 21), Valor = 55577 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 03, 22), Valor = 55243 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 03, 25), Valor = 54873 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 03, 26), Valor = 55671 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 03, 27), Valor = 56034 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 03, 28), Valor = 56352 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 01), Valor = 55902 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 02), Valor = 54889 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 03), Valor = 55563 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 04), Valor = 54648 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 05), Valor = 55011 });

                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 08), Valor = 55092 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 09), Valor = 55912 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 10), Valor = 56187 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 11), Valor = 55401 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 12), Valor = 54963 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 15), Valor = 52950 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 16), Valor = 53991 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 17), Valor = 52882 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 18), Valor = 53166 });

                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 19), Valor = 53929 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 22), Valor = 54298 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 23), Valor = 54885 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 24), Valor = 54984 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 25), Valor = 54963 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 26), Valor = 54252 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 29), Valor = 54887 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 04, 30), Valor = 55910 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 05, 02), Valor = 55322 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 05, 03), Valor = 55488 });
                        //difusor.Add(new DifusorDeFluxo { Quando = new DateTime(2013, 05, 06), Valor = 55430 });

                        CalcularDifusor(ref difusor, 21, 55, 34, 89);
                        //CalcularDifusor(ref difusor, 20, 50, 100, 200);

                        //dal.ManterTickerHitBTC(ticker);

                        streamDados.Close();
                        resposta.Close();
                    }
                }
            }
        }

        public void CarregarCandlesHorario()
        {
            // 24 horas por dia durante 15 dias.
            const int periodos = 24 * 15;

            TransacaoCambioDAL dal = new TransacaoCambioDAL();

            DataTable listaSimbolos = ListarSimbolosHitBTC();

            foreach (DataRow linha in listaSimbolos.Rows)
            {
                string url = $"https://api.hitbtc.com/api/2/public/candles/{((string)linha["SimboloWebService"])}?period={HitBTCTiposEnum.period.H1.ToString()}&sort=DESC&limit={periodos}";

                var webRequest = WebRequest.CreateHttp(url);
                webRequest.Method = "GET";

                using (var resposta = webRequest.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    using (StreamReader reader = new StreamReader(streamDados))
                    {
                        object objResponse = reader.ReadToEnd();

                        List<HitBTCCandles> listaCandles = JsonConvert.DeserializeObject<List<HitBTCCandles>>(objResponse.ToString());

                        foreach (var candle in listaCandles)
                        {
                            HitBTCTicker ticker = new HitBTCTicker(
                                (string)linha["SimboloWebService"],
                                candle.timestamp,
                                (decimal)candle.close,
                                (decimal)candle.close,
                                (decimal)candle.close,
                                (decimal)candle.open,
                                (decimal)candle.min,
                                (decimal)candle.max,
                                (decimal)candle.volume,
                                (decimal)candle.volumeQuote);

                            dal.ManterTickerHitBTC(ticker);
                        }

                        streamDados.Close();
                        resposta.Close();
                    }
                }
            }
        }

        private void CalcularDifusor(ref List<DifusorDeFluxo> difusor, int periodoA, int periodoB, int periodoC, int periodoD)
        {
            //double soma = 0;

            //foreach (DifusorDeFluxo d in difusor)
            //{
            //    soma += d.Fechamento;
            //}

            // O ponto de partida será o valor apresentado no primeiro elemento
            difusor[0].PeriodoA = difusor[0].Valor;
            difusor[0].PeriodoB = difusor[0].Valor;
            difusor[0].PeriodoC = difusor[0].Valor;
            difusor[0].PeriodoD = difusor[0].Valor;

            double kA = 2D / (periodoA + 1);
            double kB = 2D / (periodoB + 1);
            double kC = 2D / (periodoC + 1);
            double kD = 2D / (periodoD + 1);

            // O ponto ZERO é a média aritimética
            // Do um em diante é a média móvel exponencial
            for (int n = 1; n < difusor.Count; n++)
            {
                difusor[n].PeriodoA = (difusor[n].Valor - difusor[n - 1].PeriodoA) * kA + difusor[n - 1].PeriodoA;
                difusor[n].PeriodoB = (difusor[n].Valor - difusor[n - 1].PeriodoB) * kB + difusor[n - 1].PeriodoB;
                difusor[n].PeriodoC = (difusor[n].Valor - difusor[n - 1].PeriodoC) * kC + difusor[n - 1].PeriodoC;
                difusor[n].PeriodoD = (difusor[n].Valor - difusor[n - 1].PeriodoD) * kD + difusor[n - 1].PeriodoD;
            }

        }

        internal class Chaves
        {
            private string _API;
            private string _Segredo;

            public string API
            {
                get
                {
                    return Dados.CriptografaConexao(_API);
                }

                set
                {
                    _API = value;
                }

            }

            public string Segredo
            {
                get
                {
                    return Dados.CriptografaConexao(_Segredo);
                }

                set
                {
                    _Segredo = value;
                }
            }

        }

        internal class Trade
        {
            public long id { get; set; }
            public string clientOrderId { get; set; }
            public long orderId { get; set; }
            public string symbol { get; set; }
            public string side { get; set; }
            public decimal quantity { get; set; }
            public decimal price { get; set; }
            public decimal fee { get; set; }
            public DateTime timestamp { get; set; }
        }
    }
}
