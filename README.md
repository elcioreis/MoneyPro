# MoneyPro
Sistema de gerenciamento financeiro para Windows.

Sistema desenvolvido em C# com framework Windows Form e banco de dados SQL Server.

## Branch 240602 -> Versão 1.2.0.81
	Correção da cobrança de tarifas em entrada de investimentos

## Branch 240519 -> Versão 1.2.0.80
	Importação de arquivo de ativos financeiros da bolsa de valores de SP (B3)
	Atualização de preços dos ativos de interesse baseados na importação da B3

## Branch 230831 -> Versão 1.1.0.79
	Criação de gráfico acumulado de valores em linhas para monitorar o crescimento das aplicações; Alteração nos seguintes objetos de banco de dados: dbo.stpPopulaInvestimentoEspecificoVariacao, dbo.stpDataParaPesquisa.

## Branch 230809a -> Versão 1.1.0.78
	Correção no cálculo de variação de investimentos para exibir novos investimentos; alterada a procedure dbo.stpApuracaoBaseadoEmInvestimentoVariacaoPerc e criação de função dbo.fncDiaAnteriorComCotacao.

## Branch 230705a -> Versão 1.1.0.77
	Correção no cálculo de variação de investimentos; alterada a função dbo.fncCreditoOuDebitoInvestimentoLiquidoDiaExato que é chamada pela procedure dbo.stpPopulaInvestimentoEspecificoVariacao
