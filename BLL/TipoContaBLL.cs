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
    public class TipoContaBLL
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

        /// <summary>
        /// Lista com todos os registros da tabela de tipo de contas pertencente ao usuário
        /// </summary>
        /// <returns>
        /// Retorna um DataTable
        /// </returns>
        public DataTable Listar(int usuarioID)
        {
            TipoContaDAL obj = new TipoContaDAL();
            return obj.Listar(usuarioID);
        }

        public bool Validar(TipoConta tipoConta)
        {
            string msg = null;

            TipoContaDAL dal = new TipoContaDAL();

            // Verifica se o apelido foi preenchido
            if (String.IsNullOrEmpty(tipoConta.Apelido))
            {
                msg = "O apelido deve ser preenchido.";
            }
            // Verifica se a descrição foi preenchida
            else if (String.IsNullOrEmpty(tipoConta.Descricao))
            {
                msg = "A descrição deve ser preenchida.";
            }
            // Verifica se o grupo de conta foi preenchido
            else if ((int?)tipoConta.GrupoContaID == null)
            {
                msg = "O grupo de contas deve ser preenchido.";
            }
            // Verifica se o apelido está disponível
            else if (!dal.ApelidoDisponivel(tipoConta.UsuarioID, tipoConta.TipoContaID, tipoConta.Apelido))
            {
                msg = String.Format("O apelido {0} já está sendo utilizado, por favor, mude o apelido.", tipoConta.Apelido);
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

        public int Gravar(TipoConta tipoConta)
        {
            TipoContaDAL obj = new TipoContaDAL();

            if (tipoConta.TipoContaID < 0)
            {
                // É uma inclusão
                return obj.Incluir(tipoConta);
            }
            else
            {
                // É uma alteração
                return obj.Alterar(tipoConta);
            }
        }

        public void Excluir(int tipoContaID)
        {
            TipoContaDAL obj = new TipoContaDAL();
            obj.Excluir(tipoContaID);
        }
    }
}
