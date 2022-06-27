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
    public class TransacaoBLL
    {
        public DataTable Listar()
        {
            TransacaoDAL dal = new TransacaoDAL();
            return dal.Listar();
        }
    }
}
