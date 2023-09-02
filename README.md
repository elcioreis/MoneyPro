# MoneyPro
Sistema de gerenciamento financeiro para Windows.

Sistema desenvolvido em C# com framework Windows Form e banco de dados SQL Server.

## Branch 230831 -> Versão 1.1.0.79
	Criação de gráfico acumulado de valores em linhas para monitorar o crescimento das aplicações; Alteração nos seguintes objetos de banco de dados: dbo.stpPopulaInvestimentoEspecificoVariacao, dbo.stpDataParaPesquisa

## Branch 230809a -> Versão 1.1.0.78
	Correção no cálculo de variação de investimentos para exibir novos investimentos; alterada a procedure dbo.stpApuracaoBaseadoEmInvestimentoVariacaoPerc e criação de função dbo.fncDiaAnteriorComCotacao.

## Branch 230705a -> Versão 1.1.0.77
	Correção no cálculo de variação de investimentos; alterada a função dbo.fncCreditoOuDebitoInvestimentoLiquidoDiaExato que é chamada pela procedure dbo.stpPopulaInvestimentoEspecificoVariacao
