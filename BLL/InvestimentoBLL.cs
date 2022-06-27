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
    public class InvestimentoBLL
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
            InvestimentoDAL dal = new InvestimentoDAL();
            return dal.Listar(usuarioID);
        }

        public DataTable Listar(int usuarioID, bool venda, bool fundo, bool acao)
        {
            InvestimentoDAL dal = new InvestimentoDAL();
            return dal.Listar(usuarioID, venda, fundo, acao);
        }


        public bool Validar(Investimento modelo)
        {
            string msg = null;

            InvestimentoDAL dal = new InvestimentoDAL();

            // Verifica se o apelido foi preenchido
            if (String.IsNullOrEmpty(modelo.Apelido))
            {
                msg = "O apelido deve ser preenchido.";
            }
            // Verifica se o apelido está disponível
            else if (!dal.ApelidoDisponivel(modelo.UsuarioID, modelo.InvestimentoID, modelo.Apelido))
            {
                msg = String.Format("O apelido {0} já está sendo utilizado, por favor, mude o apelido.", modelo.Apelido);
            }
            // Verifica se a descrição foi preenchida
            else if (String.IsNullOrEmpty(modelo.Descricao))
            {
                msg = "A descrição deve ser preenchida.";
            }
            // Verifica se o tipo de investimento foi preenchido
            else if (modelo.TipoInvestimentoID == null)
            {
                msg = "O tipo de investimento deve ser preenchido.";
            }
            // Verifica se a instituição foi preenchida
            else if (modelo.InstituicaoID == null)
            {
                msg = "A instituição deve ser preenchida.";
            }
            // Verifica se a moeda foi informada
            else if (modelo.MoedaID == null)
            {
                msg = "A moeda deve ser preenchida.";
            }
            // Verifica se o risco foi informado
            else if (modelo.RiscoID == null)
            {
                msg = "O risco deve ser preenchido.";
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

        public int Gravar(Investimento modelo)
        {
            InvestimentoDAL dal = new InvestimentoDAL();

            if (modelo.InvestimentoID < 0)
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

        public void Excluir(int investimentoID)
        {
            InvestimentoDAL dal = new InvestimentoDAL();
            dal.Excluir(investimentoID);
        }

        public bool CotacaoDia(int investimentoID, DateTime data, ref decimal valorCotacao)
        {
            InvestimentoDAL dal = new InvestimentoDAL();
            return dal.CotacaoDia(investimentoID, data, ref valorCotacao);
        }

        public bool HaInvestimentos(int investimentoID)
        {
            InvestimentoDAL dal = new InvestimentoDAL();
            return dal.HaInvestimentos(investimentoID);
        }

    }
}
