using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using DAL;
using System.Windows.Forms;

namespace BLL
{
    public class ImpostoFaixaBLL
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

        public DataTable Listar(int impostoID)
        {
            ImpostoFaixaDAL dal = new ImpostoFaixaDAL();
            return dal.Listar(impostoID);
        }

        public bool Validar(ImpostoFaixa modelo)
        {
            string msg = null;

            ImpostoFaixaDAL dal = new ImpostoFaixaDAL();

            if (modelo.Apelido == String.Empty)
            {
                msg = "O prazo da aplicação deve ser informado.";
            }
            else if (!dal.ApelidoDisponivel(modelo.ImpostoID, modelo.FaixaID, modelo.Apelido))
            {
                msg = String.Format("O prazo da aplicação {0} já está sendo utilizado, por favor, mude o prazo.", modelo.Apelido);
            }
            else if (modelo.Dias == null)
            {
                msg = "A quantidade máxima de dias na faixa deve ser informada.";
            }
            else if (modelo.Dias <= 0)
            {
                msg = "A quantidade de dias da faixa deve ser maior que zero.";
            }
            else if (!dal.DiasDisponivel(modelo.ImpostoID, modelo.FaixaID, (int)modelo.Dias))
            {
                msg = String.Format("A quantidade de dias {0} já está em uso para este imposto.", modelo.Dias);
            }
            else if (modelo.Porcentagem == null)
            {
                msg = "A alíquota da faixa deve ser informada.";
            }
            else if (modelo.Porcentagem < 0)
            {
                msg = "A alíquota da faixa deve ser maior ou igual a zero.";
            }
            else if (modelo.Porcentagem > 100)
            {
                msg = "A alíquota da faixa não pode ser maior que cem.";
            }
            else if (!dal.PorcentagemDisponivel(modelo.ImpostoID, modelo.FaixaID, (decimal)modelo.Porcentagem))
            {
                msg = String.Format("A alíquota {0} já está em uso para este imposto.", ((decimal)modelo.Porcentagem).ToString("N2"));
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

        public int Gravar(ImpostoFaixa modelo)
        {
            ImpostoFaixaDAL dal = new ImpostoFaixaDAL();

            if (modelo.FaixaID < 0)
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
    }
}
