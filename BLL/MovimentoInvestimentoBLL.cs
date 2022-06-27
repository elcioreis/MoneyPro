using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using DAL;
using System.Windows.Forms;

namespace BLL
{
    public class MovimentoInvestimentoBLL
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

        public bool Validar(MovimentoInvestimento modelo)
        {
            string msg = null;

            //if (modelo.MovimentoContaID == null)
            //{
            //    msg = "O movimento não foi informado.";
            //}
            //else if (modelo.UsuarioID == null)
            //{
            //    msg = "O usuário não foi informado.";
            //}
            //else if (modelo.ContaID == null)
            //{
            //    msg = "A conta não foi informada.";
            //}
            //else 

            if (modelo.TransacaoID == null)
            {
                msg = "A transação deve ser informada.";
            }
            else if (modelo.InvestimentoID == null)
            {
                msg = "O investimento deve ser informado.";
            }
            else if (modelo.Data == null)
            {
                msg = "A data deve ser informada.";
            }
            else if (modelo.QtCotas == null)
            {
                msg = "A quantidade de cotas deve ser informada.";
            }
            else if (modelo.QtCotas <= 0)
            {
                msg = "A quantidade de cotas deve ser maior que zero.";
            }
            else if (modelo.VrCotacao == null)
            {
                msg = "O valor da cota deve ser informado.";
            }
            else if (modelo.VrCotacao <= 0)
            {
                msg = "O valor da cota deve ser maior que zero.";
            }
            else if (modelo.VrBruto == null)
            {
                msg = "O valor bruto deve ser informado.";
            }
            else if (modelo.VrBruto <= 0)
            {
                msg = "O valor bruto deve ser maior que zero.";
            }
            else if (modelo.VrDespesa == null)
            {
                msg = "O valor das despesas deve ser informado.";
            }
            else if (modelo.VrDespesa < 0)
            {
                msg = "O valor das despesas deve ser maior ou igual a zero.";
            }
            else if (modelo.VrLiquido == null)
            {
                msg = "O valor líquido deve ser informado.";
            }
            else if (modelo.VrLiquido < 0)
            {
                msg = "O valor líquido deve ser maior ou igual a zero.";
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

        public int GravarMovimentoInvestimento(MovimentoInvestimento modelo, MovimentoInvestimentoDespesa[] despesas)
        {
            MovimentoInvestimentoDAL dal = new MovimentoInvestimentoDAL();
            
            if (modelo.MovimentoContaID < 0)
            {
                return dal.Incluir(modelo, despesas);
            }
            else
            {
                return dal.Alterar(modelo, despesas);
            }
        }

    }
}
