using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OFXSharp;
using Modelos;
using DAL;
using System.Data;
using System.Windows.Forms;

namespace BLL
{
    public class MovimentoContaBLL
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
        /// Lista com todos os registros da tabela de movimento de contas.
        /// </summary>
        /// <returns>
        /// Retorna um DataTable
        /// </returns>
        public DataTable ListarMovimentosConta(int contaID, string filtro)
        {
            MovimentoContaDAL dal = new MovimentoContaDAL();
            return dal.ListarMovimentosConta(contaID, filtro);
        }

        /// <summary>
        /// Lista com resumo da tabela de movimento de contas.
        /// </summary>
        /// <returns>
        /// Retorna um DataTable
        /// </returns>        
        public DataTable ListarMovimentosContaResumo(int contaID, string filtro)
        {
            MovimentoContaDAL dal = new MovimentoContaDAL();
            return dal.ListarMovimentosContaResumo(contaID, filtro);
        }

        public DataTable ListarNaoConciliados(int contaID, DateTime dataInicial)
        {
            MovimentoContaDAL dal = new MovimentoContaDAL();
            return dal.ListarNaoConciliados(contaID, dataInicial);
        }


        public DataTable Movimento(int movimentoContaID)
        {
            MovimentoContaDAL dal = new MovimentoContaDAL();
            return dal.Movimento(movimentoContaID);
        }

        public bool Validar(MovimentoConta modelo)
        {
            string msg = null;

            LancamentoDAL dal = new LancamentoDAL();

            // Verifica se a data foi preenchida
            if (modelo.Data == null)
            {
                msg = "A data deve ser preenchida.";
            }
            // Verifica se o lançamento foi preenchido
            else if (modelo.LancamentoID == null)
            {
                msg = "O parceiro deve ser informado.";
            }
            // Verifica se a categoria foi preenchida
            else if (modelo.CategoriaID == null)
            {
                msg = "A categoria deve ser informada.";
            }
            // Verifica se há valor lançado (débito ou crédito)
            else if (modelo.Debito == null && modelo.Credito == null)
            {
                msg = "Deve haver lançamento de débito ou crédito.";
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

        public int Gravar(MovimentoConta modelo)
        {
            MovimentoContaDAL dal = new MovimentoContaDAL();

            if (modelo.MovimentoContaID < 0)
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

        public void Excluir(int movimentoContaID)
        {
            MovimentoContaDAL obj = new MovimentoContaDAL();
            obj.Excluir(movimentoContaID);
        }

        public int Conciliados(int movimentoContaID)
        {
            MovimentoContaDAL dal = new MovimentoContaDAL();
            return dal.Conciliados(movimentoContaID);
        }


        /// <summary>
        /// Pesquisa o último lançamento do parceiro pra repetir como sujestão na próxima inclusão.
        /// </summary>
        /// <param name="contaID"></param>
        /// <param name="parceiroID"></param>
        /// <param name="linha"></param>
        public void RecuperaUltimosDadosParceiro(int contaID, int parceiroID, ref DataGridViewRow linha)
        {
            MovimentoContaDAL dal = new MovimentoContaDAL();
            DataTable tabela = dal.RecuperaUltimosDadosParceiro(contaID, parceiroID);

            if (tabela.Rows.Count > 0)
            {
                linha.Cells["Descricao"].Value = (object)tabela.Rows[0].Field<string>("Descricao") ?? DBNull.Value;
                linha.Cells["Categoria"].Value = (object)tabela.Rows[0].Field<int?>("CategoriaID") ?? DBNull.Value;
                linha.Cells["GrupoCategoria"].Value = (object)tabela.Rows[0].Field<int?>("GrupoCategoriaID") ?? DBNull.Value;
                linha.Cells["CrdDeb"].Value = (object)tabela.Rows[0].Field<string>("CrdDeb") ?? DBNull.Value;
                linha.Cells["Credito"].Value = (object)tabela.Rows[0].Field<decimal?>("Credito") ?? DBNull.Value;
                linha.Cells["Debito"].Value = (object)tabela.Rows[0].Field<decimal?>("Debito") ?? DBNull.Value;
            }
        }

        public void GravarConciliacao(DataGridViewRow linha)
        {
            int movimentoContaID = (int)linha.Cells["MovimentoContaID"].Value;
            string conciliacao = (string)linha.Cells["Conciliacao"].Value;

            if (movimentoContaID > 0)
            {
                MovimentoContaDAL dal = new MovimentoContaDAL();
                dal.GravarConciliacao(movimentoContaID, conciliacao);
            }
        }

        public Boolean ConciliacaoViaOFX(int movimentoContaID, Transaction transacao, bool jaReconciliado)
        {
            MovimentoContaDAL dal = new MovimentoContaDAL();
            return dal.ConciliacaoViaOFX(movimentoContaID, transacao, jaReconciliado);
        }

        public DateTime PrimeiroDiaNaoReconciliado(int contaID)
        {
            MovimentoContaDAL dal = new MovimentoContaDAL();
            return dal.PrimeiroDiaNaoReconciliado(contaID);
        }

        public bool AtribuirNovaDataAoMovimento(int movimentoContaID, DateTime dataMovimento)
        {
            MovimentoContaDAL dal = new MovimentoContaDAL();
            return dal.AtribuirNovaDataAoMovimento(movimentoContaID, dataMovimento);
        }

        public string TipoArquivo(int contaID)
        {
            MovimentoContaDAL dal = new MovimentoContaDAL();
            return dal.TipoArquivo(contaID);
        }

        public bool UltimoDaPilhaDePlanejamento(int movimentoContaID)
        {
            MovimentoContaDAL dal = new MovimentoContaDAL();
            return dal.UltimoDaPilhaDePlanejamento(movimentoContaID);
        }

        public DataTable ListarConteudoPesquisa(int contaID, MovimentoContaPesquisa mcPesquisa)
        {
            MovimentoContaDAL dal = new MovimentoContaDAL();
            return dal.ListarConteudoPesquisa(contaID, mcPesquisa);
        }

        public decimal ConsultaSaldoCDB(int contaID, string numeroCDB)
        {
            MovimentoContaDAL dal = new MovimentoContaDAL();
            return dal.ConsultaSaldoCDB(contaID, numeroCDB);
        }

        public string ConsultaTextoCDB(int contaID, string numeroCDB)
        {
            MovimentoContaDAL dal = new MovimentoContaDAL();
            return dal.ConsultaTextoCDB(contaID, numeroCDB);
        }
    }
}
