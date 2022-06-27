using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using DAL;
using System.Data;
using System.Windows.Forms;

namespace BLL
{
    public class InvestimentoDespesaBLL
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

        public DataTable Listar(int investimentoID)
        {
            InvestimentoDespesaDAL dal = new InvestimentoDespesaDAL();
            return dal.Listar(investimentoID);
        }

        public bool Validar(InvestimentoDespesa modelo)
        {
            string msg = null;

            InvestimentoDespesaDAL dal = new InvestimentoDespesaDAL();

            if (modelo.CategoriaID == null)
            {
                msg = "A categoria de despesa dever ser preenchida.";
            }

            if (!String.IsNullOrEmpty(msg))
            {
                // Se exibir qualquer mensagem na tela, não será considerado válido
                MessageBox.Show(msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        public int Gravar(InvestimentoDespesa modelo)
        {
            InvestimentoDespesaDAL dal = new InvestimentoDespesaDAL();

            if (modelo.InvestimentoDespesaID < 0)
            {
                // É uma inclusão
                return dal.Incluir(modelo);
            }
            else
            {
                // É uma alteração
                return dal.Alterar(modelo);
            }
        }

        public void Excluir(int investimentoDespesaID)
        {
            InvestimentoDespesaDAL dal = new InvestimentoDespesaDAL();
            dal.Excluir(investimentoDespesaID);
        }
    }
}
