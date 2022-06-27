using System;
using Modelos;
using DAL;
using System.Data;

namespace BLL
{
    public class PesquisaBLL
    {

        public DataTable ListarGruposContas(int UsuarioID, Boolean SomenteAtivos)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.ListarGruposContas(UsuarioID, SomenteAtivos);
        }

        public DataTable ListarTiposContas(int UsuarioID, Boolean SomenteAtivos, int GrupoContaID = -1)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.ListarTiposContas(UsuarioID, SomenteAtivos, GrupoContaID);
        }

        public DataTable ListarContas(int UsuarioID, Boolean SomenteAtivos, int GrupoContaID = -1, int TipoContaID = -1)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.ListarContas(UsuarioID, SomenteAtivos, GrupoContaID, TipoContaID);
        }

        public DataTable ListarParceiros(int usuarioID)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.ListarParceiros(usuarioID);
        }


        public object ListarParceirosUsadosNaConta(int contaID)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.ListarParceirosUsadosNaConta(contaID);
        }

        public DataTable ListarCategorias(int usuarioID)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.ListarCategorias(usuarioID);
        }

        public object ListarCategoriasUsadosNaConta(int contaID)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.ListarCategoriasUsadosNaConta(contaID);
        }

        public DataTable ListarGrupos(int usuarioID)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.ListarGrupos(usuarioID);
        }

        public DataTable VariacaoDiariaInvestimento(int usuarioID, DateTime dataReferencia)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.VariacaoDiariaInvestimento(usuarioID, dataReferencia);
        }

        public DataTable VariacaoMensalInvestimento(int usuarioID, DateTime dataReferencia)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.VariacaoMensalInvestimento(usuarioID, dataReferencia);
        }

        public DataTable ListarPagamentoCartaoCredito(int usuarioID, DateTime dataBase)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.ListarPagamentoCartaoCredito(usuarioID, dataBase);
        }

        public object VariacaoUltimosDiasUteisInvestimento(int usuarioID, DateTime dataReferencia)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.VariacaoUltimosDiasUteisInvestimento(usuarioID, dataReferencia);
        }

        public DataTable ListarGruposUsadosNaContas(int contaID)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.ListarGruposUsadosNaConta(contaID);
        }

        public DataTable FluxoCaixaContaEspecifica(int contaID, DateTime dataBase)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.FluxoCaixaContaEspecifica(contaID, dataBase);
        }

        public DataTable FluxoCaixa(Tipo.TipoFluxoCaixa tipo, int usuarioID, DateTime dataBase)
        {
            PesquisaDAL dal = new PesquisaDAL();

            switch (tipo)
            {
                case Tipo.TipoFluxoCaixa.Disponivel:
                    return dal.FluxoCaixaDisponivel(usuarioID, dataBase);
                case Tipo.TipoFluxoCaixa.Credito:
                    return dal.FluxoCaixaCredito(usuarioID, dataBase);
                default:
                    return new DataTable();
            }
        }

        public DataTable OrcamentoDiario(int usuarioID, DateTime dataBase, bool comparar)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.OrcamentoDiario(usuarioID, dataBase, comparar);
        }

        public DataTable OrcamentoMensal(int usuarioID, DateTime dataBase, bool comparar)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.OrcamentoMensal(usuarioID, dataBase, comparar);
        }

        public DataTable ListarMovimentos(int usuarioID, Pesquisa conteudoPesquisa)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.ListarMovimentos(usuarioID, conteudoPesquisa);
        }

        public DataTable ListarMovimentosCategoriaNoDia(int usuarioID, int categoriaID, DateTime diaSelecionado)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.ListarMovimentosCategoriaNoDia(usuarioID, categoriaID, diaSelecionado);
        }

        public DataTable ListarMovimentosCategoriaNoDia(Tipo.TipoFluxoCaixa tipo, int usuarioID, int categoriaID, DateTime diaSelecionado)
        {
            PesquisaDAL dal = new PesquisaDAL();

            switch (tipo)
            {
                case Tipo.TipoFluxoCaixa.Disponivel:
                    return dal.ListarMovimentosCategoriaNoDia_Disponivel(usuarioID, categoriaID, diaSelecionado);
                case Tipo.TipoFluxoCaixa.Credito:
                    return dal.ListarMovimentosCategoriaNoDia(usuarioID, categoriaID, diaSelecionado);
                default:
                    return new DataTable();
            }
        }

        public DataTable ListarMovimentosCategoriaNoDia(int usuarioID, int contaID, int categoriaID, DateTime diaSelecionado)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.ListarMovimentosCategoriaNoDia(usuarioID, contaID, categoriaID, diaSelecionado);
        }

        public DataTable ListarTransferenciasContaNoDia(int usuarioID, int contaID, DateTime diaSelecionado)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.ListarTransferenciasContaNoDia(usuarioID, contaID, diaSelecionado);
        }

        public DataTable ListarMovimentosCategoriaNoMes(int usuarioID, int categoriaID, DateTime mesSelecionado)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.ListarMovimentosCategoriaNoMes(usuarioID, categoriaID, mesSelecionado);
        }

        public DataTable ListarTransferenciasContaNoMes(int usuarioID, int contaID, DateTime mesSelecionado)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.ListarTransferenciasContaNoMe(usuarioID, contaID, mesSelecionado);
        }

        public DataTable ListarMovimentosCategoriaNoMes(Tipo.TipoFluxoCaixa tipo, int usuarioID, int categoriaID, DateTime mesSelecionado)
        {
            PesquisaDAL dal = new PesquisaDAL();

            switch (tipo)
            {
                case Tipo.TipoFluxoCaixa.Disponivel:
                    return dal.ListarMovimentosCategoriaNoMes_Disponivel(usuarioID, categoriaID, mesSelecionado);
                case Tipo.TipoFluxoCaixa.Credito:
                    return dal.ListarMovimentosCategoriaNoMes_Credito(usuarioID, categoriaID, mesSelecionado);
                default:
                    return new DataTable();
            }
        }

        public DataTable ListarMovimentosCategoriaNoPeriodo(int usuarioID, int categoriaID, DateTime inicio, DateTime fim)
        {
            PesquisaDAL dal = new PesquisaDAL();
            return dal.ListarMovimentosCategoriaNoPeriodo(usuarioID, categoriaID, inicio, fim);
        }
    }
}
