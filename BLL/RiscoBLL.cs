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
    public class RiscoBLL
    {
        public DataTable Listar()
        {
            RiscoDAL dal = new RiscoDAL();
            return dal.Listar();
        }
    }
}
