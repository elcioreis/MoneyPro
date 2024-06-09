# MoneyPro
Sistema de gerenciamento financeiro para Windows.

Sistema desenvolvido em C# com framework Windows Form e banco de dados SQL Server.

## Versão 1.3.0.82
    Implementação de cadastro de impostos/taxas por tipo de investimento
	Permite copiar o cadastro de impostos/taxas para um investimento específico

## Versão 1.2.0.81
	Correção da cobrança de tarifas em entrada de investimentos

## Versão 1.2.0.80
	Importação de arquivo de ativos financeiros da bolsa de valores de SP (B3)
	Atualização de preços dos ativos de interesse baseados na importação da B3

## Versão 1.1.0.79
	Criação de gráfico acumulado de valores em linhas para monitorar o crescimento das aplicações; Alteração nos seguintes objetos de banco de dados: dbo.stpPopulaInvestimentoEspecificoVariacao, dbo.stpDataParaPesquisa.

## Versão 1.1.0.78
	Correção no cálculo de variação de investimentos para exibir novos investimentos; alterada a procedure dbo.stpApuracaoBaseadoEmInvestimentoVariacaoPerc e criação de função dbo.fncDiaAnteriorComCotacao.

## Versão 1.1.0.77
	Correção no cálculo de variação de investimentos; alterada a função dbo.fncCreditoOuDebitoInvestimentoLiquidoDiaExato que é chamada pela procedure dbo.stpPopulaInvestimentoEspecificoVariacao
