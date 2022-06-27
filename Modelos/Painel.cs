using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modelos
{

    public enum ePainel050
    {
        ApuracaoDivisaoInvestimentos = 1,
        ApuracaoDivisaoRisco = 2,
        ApuracaoDestinoDestinoPorCategoriaAnterior = 3,
        ApuracaoDestinoDestinoPorCategoriaAtual = 4
    }

    public enum ePainel100
    {
        VariacaoMensalGrupoContas = 1,
        VariacaoSemanalGrupoContas = 2,
        VariacaoSemanalAcumulado = 3,
        VariacaoInvestimentos = 4,
        ApuracaoComparativoPorCategoria = 5
    }


    public class Painel
    {
        public static string ToString(ePainel050 pnl)
        {
            switch (pnl)
            {
                case ePainel050.ApuracaoDivisaoInvestimentos:
                    return "Alocação dos Investimentos";
                case ePainel050.ApuracaoDivisaoRisco:
                    return "Alocação dos Investimentos Por Risco";
                case ePainel050.ApuracaoDestinoDestinoPorCategoriaAnterior:
                    return "Saídas por Categoria - Mês Anterior";
                case ePainel050.ApuracaoDestinoDestinoPorCategoriaAtual:
                    return "Saídas por Categoria - Mês Atual";
                default:
                    return "";
            }
        }

        public static string ToString(ePainel100 pnl)
        {
            switch (pnl)
            {
                case ePainel100.VariacaoMensalGrupoContas:
                    return "Variação Mensal dos Grupos de Contas";
                case ePainel100.VariacaoSemanalGrupoContas:
                    return "Variação Semanal dos Grupos de Contas";
                case ePainel100.VariacaoSemanalAcumulado:
                    return "Variação Semanal Acumulada";
                case ePainel100.VariacaoInvestimentos:
                    return "Variação de Investimentos";
                case ePainel100.ApuracaoComparativoPorCategoria:
                    return "Comparativo de Consumo por Categoria";
                default:
                    return "";
            }
        }
    }
}
