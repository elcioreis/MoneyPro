using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SaldoFuturoBLL
    {
        public DataTable Listar(int usuarioID)
        {
            SaldoFuturoDLL dll = new SaldoFuturoDLL();
            return dll.Listar(usuarioID);
        }
    }
}
