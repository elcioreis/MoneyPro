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
    public class GrupoContaBLL
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
        /// Lista com todos os registros da tabela de grupo de contas pertencente ao usuário
        /// Ordenado pelo campo apelido
        /// </summary>
        /// <returns>
        /// Retorna um DataTable
        /// </returns>
        public DataTable Listar(int usuarioID)
        {
            GrupoContaDAL obj = new GrupoContaDAL();
            return obj.Listar(usuarioID);
        }

        /// <summary>
        /// Lista com todos os registros da tabela de grupo de contas pertencente ao usuário
        /// Ordenado pelo campo Ordem
        /// </summary>
        /// <returns>
        /// Retorna um DataTable
        /// </returns>
        public DataTable ListarPorOrdem(int usuarioID)
        {
            GrupoContaDAL obj = new GrupoContaDAL();
            return obj.ListarPorOrdem(usuarioID);
        }


        public bool Validar(GrupoConta grupoConta)
        {
            string msg = null;

            GrupoContaDAL dal = new GrupoContaDAL();

            // Verifica se o apelido foi preenchido
            if (String.IsNullOrEmpty(grupoConta.Apelido))
            {
                msg = "O apelido deve ser preenchido.";
            }
            // Verifica se a descrição foi preenchida
            else if (String.IsNullOrEmpty(grupoConta.Descricao))
            {
                msg = "A descrição deve ser preenchida.";
            }
            // Verifica se o apelido está disponível
            else if (!dal.ApelidoDisponivel(grupoConta.UsuarioID, grupoConta.GrupoContaID, grupoConta.Apelido))
            {
                msg = String.Format("O apelido {0} já está sendo utilizado, por favor, mude o apelido.", grupoConta.Apelido);
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

        public int Gravar(GrupoConta grupoConta)
        {
            GrupoContaDAL obj = new GrupoContaDAL();

            if (grupoConta.GrupoContaID < 0)
            {
                // É uma inclusão
                return obj.Incluir(grupoConta);
            }
            else
            {
                // É uma alteração
                return obj.Alterar(grupoConta);
            }
        }

        public void Excluir(int grupoContaID)
        {
            GrupoContaDAL obj = new GrupoContaDAL();
            obj.Excluir(grupoContaID);
        }
    }
}

