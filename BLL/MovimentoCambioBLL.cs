using DAL;
using Modelos;
using System.Data;

namespace BLL
{
    public class MovimentoCambioBLL
    {
        public bool ManterCambio(MovimentoCambio movtoCambio)
        {
            MovimentoCambioDAL dal = new MovimentoCambioDAL();
            return dal.ManterCambio(movtoCambio);
        }

        public DataTable MoedasMercadoBitCoin()
        {
            MovimentoCambioDAL dal = new MovimentoCambioDAL();
            return dal.MoedasMercadoBitCoin();
        }
    }
}
