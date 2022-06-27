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
    public class ContaBLL
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

        public DataTable ListarContas(int UsuarioID, Boolean TodasContas)
        {
            ContaDAL dal = new ContaDAL();           
            return dal.ListarContas(UsuarioID, TodasContas);
        }

        public DataTable RolContas(int usuarioID)
        {
            ContaDAL dal = new ContaDAL();
            return dal.RolContas(usuarioID);
        }

        public bool Validar(Conta modelo)
        {
            string msg = null;

            ContaDAL dal = new ContaDAL();

            // Verifica se o apelido foi preenchido
            if (String.IsNullOrEmpty(modelo.Apelido))
            {
                msg = "O número da conta deve ser preenchido.";
            }
            // Verifica se a data de abertura foi informada
            else if (modelo.DataAbertura == null)
            {
                msg = "A data de abertura deve ser informada.";
            }
            // Verifica se a instituição foi informada
            else if (modelo.InstituicaoID == null)
            {
                msg = "A instituição deve ser informada.";
            }
            // Verifica se a conta foi informada
            else if (modelo.TipoContaID == null)
            {
                msg = "O tipo de conta deve ser informado.";
            }
            // Verifica se a moeda foi informada
            else if (modelo.MoedaID == null)
            {
                msg = "A moeda deve ser informada.";
            }
            // Verifica se o saldo inicial foi informado
            else if (modelo.SaldoInicial == null)
            {
                msg = "O saldo inicial deve ser informado.";
            }
            // Verifica se o limite foi informado
            else if (modelo.Limite == null)
            {
                msg = "O limite deve ser informado.";
            }
            // Verifica se o apelido está disponível
            else if (!dal.ApelidoDisponivel(modelo.UsuarioID, modelo.ContaID, modelo.Apelido))
            {
                msg = String.Format("A conta {0} já está sendo utilizado, por favor, mude o número da conta.", modelo.Apelido);
            }
            // Verifica se a descrição foi preenchida
            else if (String.IsNullOrEmpty(modelo.Descricao))
            {
                msg = "A descrição deve ser preenchida.";
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

        public int Gravar(Conta modelo)
        {
            ContaDAL dal = new ContaDAL();

            if (modelo.ContaID < 0)
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

        public void Excluir(int contaID)
        {
            ContaDAL dal = new ContaDAL();
            dal.Excluir(contaID);
        }

        public void AlternarExibicaoResumo(int contaID, bool novoStatus)
        {
            ContaDAL dal = new ContaDAL();
            dal.AlternarExibicaoResumo(contaID, novoStatus);
        }

        public void AtualizaBalancoConta(int contaID)
        {
            ContaDAL dal = new ContaDAL();
            dal.AtualizaBalancoConta(contaID);
        }
    }
}
