using DAL;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CotacaoMoedasBLL
    {
        public void InserirCotacaoMoedas(CotacaoMoedas modelo)
        {
            CotacaoMoedasDAL dal = new CotacaoMoedasDAL();
            dal.InserirCotacaoMoeda(modelo);
        }
    }
}
