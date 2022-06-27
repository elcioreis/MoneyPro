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
    public class InstituicaoBLL
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

        public DataTable Listar(int usuarioID)
        {
            InstituicaoDAL dal = new InstituicaoDAL();
            return dal.Listar(usuarioID);
        }


        public bool Validar(Instituicao modelo)
        {
            string msg = null;

            InstituicaoDAL dal = new InstituicaoDAL();

            // Verifica se o apelido foi preenchido
            if (String.IsNullOrEmpty(modelo.Apelido))
            {
                msg = "O apelido deve ser preenchido.";
            }
            // Verifica se a descrição foi preenchida
            else if (String.IsNullOrEmpty(modelo.Descricao))
            {
                msg = "A descrição deve ser preenchida.";
            }
            // Verifica se o tipo de instituição foi preenchido
            else if ((int?)modelo.TipoInstituicaoID == null)
            {
                msg = "O tipo de instituição deve ser preenchido.";
            }            
            // Verifica se o apelido está disponível
            else if (!dal.ApelidoDisponivel(modelo.UsuarioID, modelo.InstituicaoID, modelo.Apelido))
            {
                msg = String.Format("O apelido {0} já está sendo utilizado, por favor, mude o apelido.", modelo.Apelido);
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

        public int Gravar(Instituicao modelo)
        {
            InstituicaoDAL dal = new InstituicaoDAL();

            if (modelo.InstituicaoID < 0)
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

        public void Excluir(int instituicaoID)
        {
            InstituicaoDAL dal = new InstituicaoDAL();
            dal.Excluir(instituicaoID);
        }
    }
}
