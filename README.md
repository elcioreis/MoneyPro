# MoneyPro
Sistema de gerenciamento financeiro para Windows.

Sistema desenvolvido em C# com framework Windows Form e banco de dados SQL Server.

## Versões futuras
    Implementação de cadastro de impostos/taxas por tipo de investimento
	Permite copiar o cadastro de impostos/taxas para um investimento específico

## Versão 1.3.1.85
	Com a conciliação ligada, pode usar o F4 para marcar como (C)onciliado
	No fluxo de pagamento de cartão de crédito, todos eventos que não sejam (F)uturo devem entrar, inclusive os (A)gendados
	- Alteração na procedure stpPagamentoCartoCredito

## Versão 1.3.1.84
	Download de cotação de bitcoin leva em consideração se a instituição está ativa ou inativas

## Versão 1.3.0.83
    Correção do cálculo de preço bruto e líquina na operação de ações

## Versão 1.3.0.82
    Correção do módulo de compra e venda de cotas de fundos ou de ações que não carregava dados corretamente para alteração

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
