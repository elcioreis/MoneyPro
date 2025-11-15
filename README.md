# MoneyPro
Sistema de gerenciamento financeiro para Windows.

Sistema desenvolvido em C# com framework Windows Form e banco de dados SQL Server.

## Versões futuras
    Implementação de cadastro de impostos/taxas por tipo de investimento
	Permite copiar o cadastro de impostos/taxas para um investimento específico
	Criar tela com saldo até o DiaCom, proventos recebidos e porcentagem para Ações e FII marcados como BuyAndHold

## Versão 1.4.3.97
    Carga do rol de contas executada de forma asincrona para melhorar a performance no lançamento de movimentos
	Descompactação de arquivos ZIP ao importar cotações da B3 e apagar o arquivo txt após a importação

## Versão 1.4.2.96
	Inclusão da quantidade de cotas na tela de variação de investimentos

## Versão 1.4.2.95
	Remoção de pacotes não utilizados do NuGet
	Correção na tela de lançamentos resumidos ao inlcuir item que faz diminuir quantidade de linhas já reconciliadas

## Versão 1.4.2.94
    Definição de timeout na string de conexão com o banco de dados (connection timeout=60)
    Definição de maior temopo de execução na pesquisa de saldo de investimentos (commandtimeout=240)
	Ajuste na tela de inclusão de lançamentos de variação de CDB
	Ajuste no campo data da tela de conciliação que trazia data e hora

## Versão 1.4.1.93
	Correção de bug na inclusão de lançamentos de investimentos após alteração do tipo dos campos CotacaoDaCVM e CotacaoDaBovespa

## Versão 1.4.1.92
	No Saldo de Investimentos, ao clicar no ano, carrega de 1º de janeiro até 31 de dezembrosss

## Versão 1.4.1.91
	Correção emergencial para tratamento de arquivo CSV da CVM, que contém NULO em campo numérico.

## Versão 1.4.1.90
	Ao exibir o mês corrente no saldo de investimentos, exibe sempre até o último dia do mês, para exibir também os proventos futuros.
	Ao lançar movimentos de débito, sempre adiciona 1 minuto para que todos os créditos sejam exibidos antes dos débitos

## Versão 1.4.0.89
	Desepesas de investimento podem ser marcadas como entrada e saída ao mesmo tempo
	Correção de bug na tela de lançamentos ao esconder itens reconciliados e reposicionar o cursor
	Inclusão de coluna BuyAndHold e DiaCom nos investimentos

## Versão 1.4.0.88
	Inclusão de código de consulta na carteira de investimentoss

## Versão 1.4.0.87
	Inclusão de código de consulta em Saldo de Investimentoss

## Versão 1.4.0.86
	Criação de tela com Saldo de Investimentos
	-- Mês atual (dia 01 até data corrente)
	-- Ano atual (dia 01/01 até data corrente)
	-- Último mês (hoje - 1 mês até data corrente)
	-- Últimos 3 meses (hoje - 3 meses até data corrente)
	-- Últimos 6 meses (hoje - 6 meses até data corrente)
	-- Últimos 12 meses (hoje - 12 meses até data corrente)
	-- Criação da procedure stpSaldoInvestimentos

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
