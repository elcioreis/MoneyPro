using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using DAL;
using System.Data;

namespace BLL
{
    public class MovimentoInvestimentoDespesaBLL
    {
        static private int proximoID = 0;

        /// <summary>
        /// Retorna o próximo número ID disponível (sempre negativo)
        /// </summary>
        static public int ProximoID
        {
            get
            {
                return --proximoID;
            }
        }

        public DataTable Listar(int movimentoInvestimentoID)
        {
            MovimentoInvestimentoDespesaDAL dal = new MovimentoInvestimentoDespesaDAL();
            return dal.Listar(movimentoInvestimentoID);
        }

        public DataTable CriarListaDespesas(int investimentoID, bool saida)
        {
            MovimentoInvestimentoDespesaDAL dal = new MovimentoInvestimentoDespesaDAL();
            return dal.CriarListaDespesas(investimentoID, saida);
        }

        public object CarregarListaDespesas(int movimentoContaID)
        {
            MovimentoInvestimentoDespesaDAL dal = new MovimentoInvestimentoDespesaDAL();
            return dal.CarregarListaDespesas(movimentoContaID);
        }
    }
}
