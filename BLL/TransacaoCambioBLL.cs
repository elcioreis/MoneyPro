using DAL;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TransacaoCambioBLL
    {
        public DataTable ListarTransacoes(int contaOrigemID, int contaDestinoID)
        {
            TransacaoCambioDAL dal = new TransacaoCambioDAL();
            return dal.ListarTransacoes(contaOrigemID, contaDestinoID);
        }

        public DataTable ListarContaDestino(int usuarioID, int contaAtualID)
        {
            TransacaoCambioDAL dal = new TransacaoCambioDAL();
            return dal.ListarContasDestino(usuarioID, contaAtualID);
        }

        public bool ManterTradeHitBTC(HitBTCTrade trade)
        {
            TransacaoCambioDAL dal = new TransacaoCambioDAL();
            return dal.ManterTradeHitBTC(trade);
        }

        public bool ManterTickerHitBTC(HitBTCTicker ticker)
        {
            TransacaoCambioDAL dal = new TransacaoCambioDAL();
            return dal.ManterTickerHitBTC(ticker);
        }
    }
}
