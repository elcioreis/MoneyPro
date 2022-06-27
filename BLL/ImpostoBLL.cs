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
    public class ImpostoBLL
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

        public DataTable Listar()
        {
            ImpostoDAL dal = new ImpostoDAL();
            return dal.Listar();
        }


        public bool Validar(Imposto modelo)
        {
            string msg = null;

            ImpostoDAL dal = new ImpostoDAL();

            if (modelo.Apelido == String.Empty)
            {
                msg = "O Apelido deve ser informado.";
            }
            else if (!dal.ApelidoDisponivel(modelo.ImpostoID, modelo.Apelido))
            {
                msg = String.Format("O apelido {0} já está sendo utilizado, por favor, mude o apelido.", modelo.Apelido);
            }
            else if (modelo.Descricao == String.Empty)
            {
                msg = "A Descrição deve ser informada.";
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


        public int Gravar(Imposto modelo)
        {
            ImpostoDAL dal = new ImpostoDAL();

            if (modelo.ImpostoID < 0)
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

        public void Excluir(int impostoID)
        {
            ImpostoDAL dal = new ImpostoDAL();
            dal.Excluir(impostoID);
        }
    }
}
