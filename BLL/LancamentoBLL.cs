using DAL;
using Modelos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BLL
{
    public class LancamentoBLL
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
            LancamentoDAL dal = new LancamentoDAL();
            return dal.Listar(usuarioID);
        }

        public bool Validar(Lancamento modelo)
        {
            string msg = null;

            LancamentoDAL dal = new LancamentoDAL();

            // Verifica se o apelido foi preenchido
            if (String.IsNullOrEmpty(modelo.Apelido))
            {
                msg = "O apelido deve ser preenchido.";
            }
            // Verifica se o apelido está disponível
            else if (!dal.ApelidoDisponivel(modelo.UsuarioID, modelo.LancamentoID, modelo.Apelido))
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

        public int Gravar(Lancamento modelo, SqlConnection conn = null)
        {
            LancamentoDAL dal = new LancamentoDAL();

            if (modelo.LancamentoID < 0)
            {
                // É uma inclusão
                return dal.Incluir(modelo, conn);
            }
            else
            {
                // É uma alteração
                return dal.Alterar(modelo, conn);
            }
        }

        public void Excluir(int lancamentoID, SqlConnection conn = null)
        {
            LancamentoDAL obj = new LancamentoDAL();
            obj.Excluir(lancamentoID, conn);
        }

        public int IDdoLancamento(int usuarioID, string conteudo, bool apagaNaoUtilizados, SqlConnection conn = null)
        {
            LancamentoDAL dal = new LancamentoDAL();
            return dal.IDdoLancamento(usuarioID, conteudo, apagaNaoUtilizados, conn);
        }

        public int IDdoLancamentoPadraoCDB(int usuarioID, SqlConnection conn = null)
        {
            LancamentoDAL dal = new LancamentoDAL();
            return dal.IDdoLancamentoPadroCDB(usuarioID, conn);
        }
    }
}
