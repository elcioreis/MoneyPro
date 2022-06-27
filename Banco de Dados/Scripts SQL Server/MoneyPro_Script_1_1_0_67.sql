USE [master]
GO
/****** Object:  Database [MoneyPro]    Script Date: 05/01/2022 12:59:40 ******/
CREATE DATABASE [MoneyPro]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MoneyPro', FILENAME = N'D:\SQLServer\MoneyPro.mdf' , SIZE = 526976KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MoneyPro_log', FILENAME = N'D:\SQLServer\MoneyPro_0.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MoneyPro] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MoneyPro].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MoneyPro] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MoneyPro] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MoneyPro] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MoneyPro] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MoneyPro] SET ARITHABORT OFF 
GO
ALTER DATABASE [MoneyPro] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MoneyPro] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MoneyPro] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MoneyPro] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MoneyPro] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MoneyPro] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MoneyPro] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MoneyPro] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MoneyPro] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MoneyPro] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MoneyPro] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MoneyPro] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MoneyPro] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MoneyPro] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MoneyPro] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MoneyPro] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MoneyPro] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MoneyPro] SET RECOVERY FULL 
GO
ALTER DATABASE [MoneyPro] SET  MULTI_USER 
GO
ALTER DATABASE [MoneyPro] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MoneyPro] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MoneyPro] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MoneyPro] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MoneyPro] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MoneyPro', N'ON'
GO
ALTER DATABASE [MoneyPro] SET QUERY_STORE = OFF
GO
USE [MoneyPro]
GO
USE [MoneyPro]
GO
/****** Object:  Sequence [dbo].[CotacaoCVM_CotacaoCVMID]    Script Date: 05/01/2022 12:59:40 ******/
CREATE SEQUENCE [dbo].[CotacaoCVM_CotacaoCVMID] 
 AS [bigint]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -9223372036854775808
 MAXVALUE 9223372036854775807
 CACHE 
GO
USE [MoneyPro]
GO
/****** Object:  Sequence [dbo].[seq_Categoria_NovoID]    Script Date: 05/01/2022 12:59:40 ******/
CREATE SEQUENCE [dbo].[seq_Categoria_NovoID] 
 AS [int]
 START WITH 287
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO
USE [MoneyPro]
GO
/****** Object:  Sequence [dbo].[seq_GrupoCategoria_NovoID]    Script Date: 05/01/2022 12:59:40 ******/
CREATE SEQUENCE [dbo].[seq_GrupoCategoria_NovoID] 
 AS [int]
 START WITH 28
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO
USE [MoneyPro]
GO
/****** Object:  Sequence [dbo].[seq_Investimento_NovoID]    Script Date: 05/01/2022 12:59:40 ******/
CREATE SEQUENCE [dbo].[seq_Investimento_NovoID] 
 AS [int]
 START WITH 24
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO
USE [MoneyPro]
GO
/****** Object:  Sequence [dbo].[seq_InvestimentoCotacao_NovoID]    Script Date: 05/01/2022 12:59:40 ******/
CREATE SEQUENCE [dbo].[seq_InvestimentoCotacao_NovoID] 
 AS [int]
 START WITH 21527
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO
USE [MoneyPro]
GO
/****** Object:  Sequence [dbo].[seq_Lancamento_NovoID]    Script Date: 05/01/2022 12:59:40 ******/
CREATE SEQUENCE [dbo].[seq_Lancamento_NovoID] 
 AS [int]
 START WITH 1128
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO
USE [MoneyPro]
GO
/****** Object:  Sequence [dbo].[seq_MovimentoConta_NovoID]    Script Date: 05/01/2022 12:59:40 ******/
CREATE SEQUENCE [dbo].[seq_MovimentoConta_NovoID] 
 AS [int]
 START WITH 11002
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO
USE [MoneyPro]
GO
/****** Object:  Sequence [dbo].[seq_Planejamento_NovoID]    Script Date: 05/01/2022 12:59:40 ******/
CREATE SEQUENCE [dbo].[seq_Planejamento_NovoID] 
 AS [int]
 START WITH 220
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO
USE [MoneyPro]
GO
/****** Object:  Sequence [dbo].[seq_TipoInvestimento_NovoID]    Script Date: 05/01/2022 12:59:40 ******/
CREATE SEQUENCE [dbo].[seq_TipoInvestimento_NovoID] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO
USE [MoneyPro]
GO
/****** Object:  Sequence [dbo].[TickerHitBTC_TickerID]    Script Date: 05/01/2022 12:59:40 ******/
CREATE SEQUENCE [dbo].[TickerHitBTC_TickerID] 
 AS [bigint]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -9223372036854775808
 MAXVALUE 9223372036854775807
 CACHE 
GO
/****** Object:  UserDefinedFunction [dbo].[fncContaInvestimentoDataImpostoPago]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fncContaInvestimentoDataImpostoPago](@ContaID INT, @Data DATE)
RETURNS NUMERIC(18,4)
AS
BEGIN

    DECLARE @Resultado NUMERIC(18,4);

	
    SELECT @Resultado = SUM(ABS(Impt.VALOR))
	FROM MovimentoConta Impt
         -- Ignora os descontos de Come Cotas, onde o valor total do resgate é igual ao valor do imposto
         --INNER JOIN MovimentoInvestimento Invt ON Invt.MovimentoContaID = Impt.DoMovimentoContaID AND Invt.VrLiquido <> 0
	WHERE Impt.ContaID = @ContaID
      AND Impt.Data <= @Data
	  AND Impt.DoMovimentoContaID IS NOT NULL
	  AND Impt.Sistema = 1

    IF (@Resultado IS NULL) 
    BEGIN
        SET @Resultado = 0;
    END;

    RETURN @Resultado;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncCotacaoComeCota]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fncCotacaoComeCota] (
    @InvestimentoID INT,
    @Data           DATE)
RETURNS NUMERIC(18,8)
AS
BEGIN

    DECLARE @VrCotacao NUMERIC(18,10),
            @DtAux     DATE;

    SET @DtAux = @Data;

    -- Fornece a cotação do dia anterior ao come cota para calcular os 15% a serem retidos, o valor não fica exato, mas é mais próximo, se retroceder mais um dia, fica abaixo do valor retido.
    SELECT @DtAux = MAX(Data) FROM InvestimentoCotacao WHERE InvestimentoID = @InvestimentoID AND Data <= @Data;

    IF (@DtAux IS NOT NULL)
       SELECT @VrCotacao = VrCotacao FROM InvestimentoCotacao WHERE InvestimentoID = @InvestimentoID AND Data = @DtAux;
    ELSE
       SELECT @VrCotacao = VrCotacao FROM InvestimentoCotacao WHERE InvestimentoID = @InvestimentoID AND Data = @Data;

    RETURN @VrCotacao;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncDiaComCotacao]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fncDiaComCotacao](@Data DATE)
RETURNS DATE
AS
BEGIN

    DECLARE @DiaComCotacao DATE;

    SELECT @DiaComCotacao = MIN(DATA) FROM InvestimentoCotacao WHERE DATA >= @Data;

    RETURN @DiaComCotacao;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncDiaUtil]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fncDiaUtil](@Data DATE)
RETURNS BIT
AS
BEGIN

    DECLARE @Resultado BIT = 1;

    IF DATEPART(DW, @Data) = 1        -- Se for domingo
        SET @Resultado = 0;
    ELSE IF DATEPART(DW, @Data) = 7   -- Se for sábado
        SET @Resultado = 0;
    ELSE  IF EXISTS(SELECT * FROM Feriado WHERE DAY(@Data) = Dia AND MONTH(@Data) = Mes AND YEAR(@Data) = COALESCE(Ano, YEAR(@Data)))  -- Se for feriado
       SET @Resultado = 0; 


    RETURN @Resultado;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncImpostoDevido]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fncImpostoDevido] (
    @InvestimentoID INT,
    @DataCompra     DATE,
    @DataVenda      DATE,
    @Compra         NUMERIC(18,8),
    @Venda          NUMERIC(18,8),
    @Tipo           SMALLINT = 0
)
RETURNS NUMERIC(18,8)
AS
BEGIN

    DECLARE @Resultado    NUMERIC(18,8) = 0;
    DECLARE @Dias         INT = DATEDIFF(DAY, @DataCompra, @DataVenda);
    DECLARE @VrIOF        NUMERIC(18,8) = 0;
    DECLARE @VrIR         NUMERIC(18,8) = 0;
    DECLARE @Porcentagem  NUMERIC(6,4);
    DECLARE @IOF          BIT;
    DECLARE @IR           BIT;

    DECLARE Despesas CURSOR
    FOR SELECT Faix.Porcentagem, Desp.IOF, Desp.IR
        FROM InvestimentoDespesa Desp
             INNER JOIN ImpostoFaixa Faix 
                ON Faix.ImpostoID = Desp.ImpostoID
               AND Faix.Dias = (SELECT MIN(Dias) FROM ImpostoFaixa WHERE ImpostoID = Desp.ImpostoID AND Dias >= @Dias)
       WHERE Desp.InvestimentoID = @InvestimentoID AND Desp.Saida = 1
       ORDER BY Desp.IOF DESC, Desp.IR DESC;

    OPEN Despesas;

    FETCH NEXT FROM Despesas
    INTO @Porcentagem, @IOF, @IR;

    WHILE (@@FETCH_STATUS = 0)
    BEGIN

        IF (@IOF = 1)
        BEGIN

            SET @VrIOF = (@Venda - @Compra) * @Porcentagem / 100;

        END
        ELSE IF (@IR = 1)
        BEGIN

            SET @VrIR = ((@Venda - @Compra) - @VrIOF) * @Porcentagem / 100;

        END;

        FETCH NEXT FROM Despesas
        INTO @Porcentagem, @IOF, @IR;
    END;

    CLOSE Despesas;
    DEALLOCATE Despesas;

    IF (@Tipo = 1)      -- Só IOF
       SET @Resultado = COALESCE(@VrIOF, 0.0);
    ELSE IF (@Tipo = 2) -- Só IR
       SET @Resultado = COALESCE(@VrIR, 0.0);
    ELSE                -- IOF + IR
       SET @Resultado = COALESCE(@VrIOF, 0.0) + COALESCE(@VrIR, 0.0);


    RETURN @Resultado;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncImpostoDevidoComeCota]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fncImpostoDevidoComeCota] (
    @InvestimentoID INT,
    @DataCompra     DATE,
    @DataVenda      DATE,
    @Compra         NUMERIC(18,8),
    @Venda          NUMERIC(18,8)
)
RETURNS NUMERIC(18,8)
AS
BEGIN
    
    DECLARE @VrIOF         NUMERIC(18,8) = 0;
    DECLARE @VrIR          NUMERIC(18,8) = 0;
    DECLARE @VrComeCota    NUMERIC(18,8) = 0;
    DECLARE @Porcentagem   NUMERIC(6,4);
    DECLARE @IOF           BIT;
    DECLARE @IR            BIT;
    DECLARE @ComeCota      BIT;

    -- Dias entre a compra e venda, para calculo do imposto IOF e IR, 
    -- ambos usam tabelas regressivas baseadas em dias aplicados.
    DECLARE @Dias          INT = DATEDIFF(DAY, @DataCompra, @DataVenda);

    -- Verifica se o investimento participa do imposto "ComeCota"
    SELECT @ComeCota = Tipo.ComeCota
    FROM Investimento Invt
         INNER JOIN TipoInvestimento Tipo
            ON Tipo.TipoInvestimentoID = Invt.TipoInvestimentoID
    WHERE Invt.InvestimentoID = @InvestimentoID;

    SELECT @ComeCota    = Tipo.ComeCota, 
           @Porcentagem = Faix.Porcentagem
    FROM Investimento Invt
         INNER JOIN TipoInvestimento Tipo
            ON Tipo.TipoInvestimentoID = Invt.TipoInvestimentoID
         INNER JOIN InvestimentoDespesa Desp
            ON Desp.InvestimentoID = Invt.InvestimentoID
           AND Desp.IR = 1
         INNER JOIN ImpostoFaixa Faix
            ON Faix.FaixaID = (SELECT TOP 1 FaixaID
                               FROM ImpostoFaixa
                               WHERE ImpostoID = Desp.ImpostoID
                               ORDER BY Porcentagem ASC)
    WHERE Invt.InvestimentoID = @InvestimentoID;


    -- Se o investimento participa do Come Cota
    IF (@ComeCota = 1)
    BEGIN
        -- O imposto é cobrado nos seguintes dias: último dia útil de maio e último dia útil de novembro.
        -- Deve-se verificar se o investimento já existia no último dia do período anterior.
        -- Deve-se calcular a variação do investimento entre a compra e o último dia do período.
        -- Deve-se pegar a faixa mais baixa do imposto e aplicar a alíquota.

        SET @VrComeCota = 0;

    END;

    -- Cursor para listar os impostos aplicados ao investimento
    DECLARE Despesas CURSOR
    FOR SELECT Faix.Porcentagem, Desp.IOF, Desp.IR
        FROM InvestimentoDespesa Desp
             INNER JOIN ImpostoFaixa Faix 
                ON Faix.ImpostoID = Desp.ImpostoID
               AND Faix.Dias = (SELECT MIN(Dias) FROM ImpostoFaixa WHERE ImpostoID = Desp.ImpostoID AND Dias >= @Dias)
       WHERE Desp.InvestimentoID = @InvestimentoID AND Desp.Saida = 1
       ORDER BY Desp.IOF DESC, Desp.IR DESC;

    OPEN Despesas;

    FETCH NEXT FROM Despesas
    INTO @Porcentagem, @IOF, @IR;

    WHILE (@@FETCH_STATUS = 0)
    BEGIN

        IF (@IOF = 1)
        BEGIN
            SET @VrIOF = (@Venda - @Compra) * @Porcentagem / 100;
        END
        ELSE IF (@IR = 1)
        BEGIN
            SET @VrIR = ((@Venda - @Compra) - @VrIOF) * @Porcentagem / 100;
        END;

        FETCH NEXT FROM Despesas
        INTO @Porcentagem, @IOF, @IR;
    END;

    CLOSE Despesas;
    DEALLOCATE Despesas;

    RETURN ISNULL(@VrIOF, 0.0) + ISNULL(@VrIR, 0.0) - ISNULL(@VrComeCota, 0.0);

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncInicioDoMes]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fncInicioDoMes](@Data DATE)
RETURNS Date
AS
BEGIN

    DECLARE @Ano       INT,
            @Mes       INT,
            @Retorno   DATE;

    SET @Ano = DATEPART(YEAR, @Data);
    SET @Mes = DATEPART(MONTH, @Data);

    SET @Retorno = DATEFROMPARTS(@Ano, @Mes, 1);

    RETURN @Retorno;    

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncInvestimentoDataImpostoPago]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fncInvestimentoDataImpostoPago](@InvestimentoID INT, @Data DATE)
RETURNS NUMERIC(18,4)
AS
BEGIN

    DECLARE @Resultado NUMERIC(18,4);

	
    SELECT @Resultado = SUM(ABS(Impt.VALOR))
	FROM MovimentoConta Impt
         -- Ignora os descontos de Come Cotas, onde o valor total do resgate é igual ao valor do imposto
         INNER JOIN MovimentoInvestimento Invt ON Invt.MovimentoContaID = Impt.DoMovimentoContaID AND Invt.VrLiquido <> 0
	WHERE Invt.InvestimentoID = @InvestimentoID
      AND Impt.Data <= @Data
	  AND Impt.DoMovimentoContaID IS NOT NULL
	  AND Impt.Sistema = 1

    IF (@Resultado IS NULL) 
    BEGIN
        SET @Resultado = 0;
    END;

    RETURN @Resultado;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncListaParaTabela]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fncListaParaTabela](@Lista VARCHAR(MAX))
RETURNS @Tabela TABLE 
(
    -- Colunas retornadas pela função
    ID INT
)
AS
BEGIN

    -- Se a relação de investimento foi passada, garante que a lista termine por ponto e vírgula
    -- Procura a data mínima igual para toda a lista de investimentos
    IF (@Lista IS NOT NULL) 
    BEGIN

        -- Garante que a lista de investimentos termina por ponto e vírgula
        IF RIGHT(@Lista,1) <> ';'
            SET @Lista = @Lista + ';';

        DECLARE @Codigos  VARCHAR(30),
                @ID       INT;

        SET @Codigos = @Lista;
                
        WHILE (@Codigos > '')
        BEGIN

            SET @ID = LEFT(@Codigos, CHARINDEX(';', @Codigos) - 1);

            INSERT INTO @Tabela
            (ID)
            VALUES
            (@ID);

            -- Descarta o primeiro código da lista.
            SET @Codigos = RIGHT(@Codigos, LEN(@Codigos) - CHARINDEX(';', @Codigos));

        END;

    END;


    RETURN;
END
GO
/****** Object:  UserDefinedFunction [dbo].[fncLucroContaInvestimentoData]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fncLucroContaInvestimentoData](@ContaID INT, @Data DATE)
RETURNS NUMERIC(18,4)
AS
BEGIN

    DECLARE @Resultado NUMERIC(18,4);

    SELECT @Resultado = COALESCE(SUM(MInv.QtCotas * Ultm.VrCotacao), 0) + COALESCE(SUM(Mvto.Valor), 0)
    FROM MovimentoConta Mvto
         INNER JOIN MovimentoInvestimento MInv 
           ON MInv.MovimentoContaID = Mvto.MovimentoContaID
         INNER JOIN InvestimentoCotacao Ultm
           ON Ultm.InvestimentoID = MInv.InvestimentoID
          AND Ultm.Data = (SELECT MAX(Cota.Data) FROM InvestimentoCotacao Cota WHERE Cota.InvestimentoID = MInv.InvestimentoID AND Cota.Data <= @Data)
    WHERE Mvto.ContaID = @ContaID
      AND Mvto.Data <= @Data;


    IF (@Resultado IS NULL) 
    BEGIN
        SET @Resultado = 0;
    END;

    RETURN @Resultado;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncLucroInvestimentoData]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fncLucroInvestimentoData](@InvestimentoID INT, @Data DATE)
RETURNS NUMERIC(18,4)
AS
BEGIN

    DECLARE @Resultado NUMERIC(18,4);

    SELECT @Resultado = COALESCE(SUM(MInv.QtCotas * Ultm.VrCotacao), 0) + COALESCE(SUM(Mvto.Valor), 0)
    FROM MovimentoConta Mvto
         INNER JOIN MovimentoInvestimento MInv 
           ON MInv.MovimentoContaID = Mvto.MovimentoContaID
         INNER JOIN InvestimentoCotacao Ultm
           ON Ultm.InvestimentoID = MInv.InvestimentoID
          AND Ultm.Data = (SELECT MAX(Cota.Data) FROM InvestimentoCotacao Cota WHERE Cota.InvestimentoID = MInv.InvestimentoID AND Cota.Data <= @Data)
    WHERE MInv.InvestimentoID = @InvestimentoID
      AND Mvto.Data <= @Data;


    IF (@Resultado IS NULL) 
    BEGIN
        SET @Resultado = 0;
    END;

    RETURN @Resultado;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncMeioDoMes]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fncMeioDoMes](@Data DATE)
RETURNS Date
AS
BEGIN

    DECLARE @Ano       INT,
            @Mes       INT,
            @Retorno   DATE;

    SET @Ano = DATEPART(YEAR, @Data);
    SET @Mes = DATEPART(MONTH, @Data);

    SET @Retorno = DATEFROMPARTS(@Ano, @Mes, 15);

    RETURN @Retorno;    

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncNumeroProximoEvento]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fncNumeroProximoEvento](@PlanejamentoID INT)
RETURNS VARCHAR(7)
AS
BEGIN

    DECLARE @Repeticoes  INT,
            @Processados INT,
            @Resposta    VARCHAR(7);

    SELECT @Repeticoes = Repeticoes,
           @Processados = Processados
    FROM Planejamento
    WHERE PlanejamentoID = @PlanejamentoID;

    IF (@Repeticoes = 0)
    BEGIN
        SET @Resposta = FORMAT(@Processados + 1, '#00');
    END
    ELSE
    BEGIN

        SET @Resposta = FORMAT(@Processados + 1, '#00') + '/' + FORMAT(@Repeticoes, '#00');

    END;

    RETURN @Resposta;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncPrevisaoSaldoNegativo]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/**************************************************
 Function fncPrevisaoSaldoNegativo
 Conta quantas contas ficarão negativas nos próximos
 30 dias.

 Elcio Reis - 07/09/2019

 Exemplo de execucao
 SELECT dbo.fncPrevisaoSaldoNegativo(2, 15);
 **************************************************/

CREATE FUNCTION [dbo].[fncPrevisaoSaldoNegativo] (@UsuarioID INT, @DiasDePrevisao INT)
RETURNS INT

BEGIN
    DECLARE @Contador INT = 0;

    DECLARE @DataReferencia DATE = CAST(GETDATE() AS DATE);

    DECLARE @Datas TABLE (Dia DATE);
    DECLARE @X SMALLINT = 0;

    WHILE (@X < @DiasDePrevisao)
    BEGIN

        INSERT INTO @Datas
        (Dia)
        SELECT DATEADD(DAY, @X, @DataReferencia);

        SET @X = @X + 1;
    END;

    WITH Fase01 AS (SELECT MvCt.ContaID, Cnta.Apelido, Dias.Dia, SUM(COALESCE(MvCt.Credito, 0) - COALESCE(MvCt.Debito, 0)) Saldo
                    FROM @Datas Dias
                         JOIN MovimentoConta MvCt ON CAST(MvCt.Data AS DATE) <= Dias.Dia
                         JOIN Conta Cnta ON Cnta.ContaID = MvCt.ContaID
                         JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
                         JOIN GrupoConta GpCt ON GpCt.GrupoContaID = Tipo.GrupoContaID
                                             AND GpCt.FluxoDisponivel = 1
                    WHERE Cnta.UsuarioID = @UsuarioID
                    GROUP BY MvCt.ContaID, Cnta.Apelido, Dias.Dia),
         Fase02 AS (SELECT F1.ContaID, F1.Apelido Conta, 
                           MIN(F1.Dia) Dia,
                           (SELECT Saldo
                            FROM Fase01 FX
                            WHERE FX.ContaID = F1.ContaID
                            AND   FX.Dia = MIN(F1.Dia)) Saldo
                    FROM Fase01 F1
                    WHERE F1.Saldo < 0
                    GROUP BY F1.ContaID, F1.Apelido)
   SELECT @Contador = COUNT(*)
   FROM Fase02;

   RETURN @Contador;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncPrimeiroDiaBitCoinNecessario]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fncPrimeiroDiaBitCoinNecessario]()
RETURNS Date
AS
BEGIN

	-- Retorna o primeiro dia de cotação faltante.
	-- A rotina em C# irá buscar todos os dias da data retornada aqui até D-1.

    DECLARE @Retorno DATE;

	SELECT @Retorno = MAX(Primeira)
	FROM (-- Recupera a data de abertura da primeira conta em BTC
	      SELECT MIN(Cta.DataAbertura) Primeira 
          FROM Conta Cta
		  JOIN Moeda Mda ON Mda.MoedaID = Cta.MoedaID
          WHERE Mda.Simbolo = 'B$'
          UNION ALL
          -- Recupera a primeira cotação necessária para completar a tabela de cotações
          SELECT DATEADD(day, 1, CAST(Data AS DATE)) 
          FROM CotacaoMoeda Ctm
          JOIN Moeda De ON De.MoedaID = Ctm.DeMoedaID AND De.Simbolo = 'B$'
          JOIN Moeda Para ON Para.MoedaID = Ctm.ParaMoedaID AND Para.Simbolo = 'R$') AS VENDA;

    RETURN @Retorno;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncPrimeiroDiaMoedaMercadoBitCoinNecessario]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fncPrimeiroDiaMoedaMercadoBitCoinNecessario](@Simbolo varchar(10))
RETURNS DATETIME
AS
BEGIN

	-- Retorna o primeiro dia de cotação faltante.
	-- A rotina em C# irá buscar todos os dias da data retornada aqui até D-1.

    DECLARE @Retorno DATETIME;

	SELECT @Retorno = MAX(Primeira)
	FROM (-- Recupera a data de abertura da primeira conta em BTC
	      SELECT CAST(MIN(Cta.DataAbertura) AS DATETIME) Primeira 
          FROM Conta Cta
		  JOIN Moeda Mda ON Mda.MoedaID = Cta.MoedaID
          WHERE Mda.Simbolo = @Simbolo

          UNION ALL

          -- Recupera a primeira cotação necessária para completar a tabela de cotações
          SELECT DATEADD(day, 1, CAST(Data AS DATETIME)) 
          FROM CotacaoMoeda Ctm
          JOIN Moeda De ON De.MoedaID = Ctm.DeMoedaID AND De.Simbolo = @Simbolo
          JOIN Moeda Para ON Para.MoedaID = Ctm.ParaMoedaID AND Para.Padrao = 1 -- Para.Simbolo = 'R$'
          -- Só interessa a data com a última cotação do dia (qualquer dia, com hora = 23:59:59.997)
          WHERE Data = CONVERT(DATETIME, CONVERT(CHAR(10), Data, 103) + ' 23:59:59.997', 103)
          
          
          UNION ALL

          SELECT CONVERT(DATETIME, CONVERT(CHAR(10), '01-01-1900', 103) + ' 23:59:59.997', 103) Primeira) AS BASE
    WHERE Primeira IS NOT NULL;
          
    RETURN @Retorno;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncProximaFaturaCartao]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fncProximaFaturaCartao](@UsuarioID INT)
RETURNS DATE
AS
BEGIN

    DECLARE @ProximaFatura DATE;

        SELECT @ProximaFatura = MIN(CAST(MvCt.Data AS DATE))
        FROM MovimentoConta MvCt
             JOIN Conta Cnta ON Cnta.ContaID = MvCt.ContaID
                            AND Cnta.UsuarioID = @UsuarioID
             JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
             JOIN GrupoConta GpCt ON GpCt.GrupoContaID = Tipo.GrupoContaID
             JOIN vw_CategoriasSelecionaveis CSel ON CSel.CategoriaID = MvCt.CategoriaID
                                                 AND CSel.vCrdDeb = 'T'
                                                 AND CSel.ContaID > 0
        WHERE GpCt.FluxoCredito = 1
        AND   MvCt.DoMovimentoContaID IS NOT NULL
        AND   MvCt.Conciliacao IN ('A', 'F');

    RETURN @ProximaFatura;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncProximoEventoPlanejamento]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fncProximoEventoPlanejamento](@PlanejamentoID INT, @Parcela INT = NULL)
RETURNS DATE
AS
BEGIN

    DECLARE @DiaInicial    DATE,
            @Ano           INT,
            @Mes           INT,
            @Dia           INT,
            @DiaFixo       BIT,
            @AdiaSeNaoUtil INT,
            @Proxima       INT,
            @Resposta      DATE,
            @Contador      INT = 0;

    SELECT
        @Ano           = YEAR(DtInicial),
        @Mes           = MONTH(DtInicial),
        @Dia           = Dia,
        @DiaFixo       = DiaFixo,
        @AdiaSeNaoUtil = AdiaSeNaoUtil,
        @Proxima       = COALESCE(@Parcela, Processados)
    FROM Planejamento
    WHERE PlanejamentoID = @PlanejamentoID;

    -- Calcula o dia da prestação atual, se ele caisse no dia fixo do mês, dia 20-09-2015, mesmo que domingo.
    SET @DiaInicial = DATEADD(year, @Ano-1900, DATEADD(month, @Mes-1, DATEADD(day, @Dia-1, 0)));


    IF (@DiaFixo = 1)
    BEGIN
        -- Dia Fixo - Exemplo: sempre no dia 20 do mês, só muda se não for dia útil.
        SET @Resposta = DATEADD(MONTH, @Proxima, @DiaInicial);

        -- Se não for dia útil vai para o dia útil anterior ou para o próximo dia útil, dependendo de @AdiaSeNaoUtil
        WHILE (@AdiaSeNaoUtil < 2) AND (dbo.fncDiaUtil(@Resposta) = 0)
        BEGIN
        
            /* 
               Valores de @AdiaSeNaoUtil
               0 - Adianta se não for dia útil
               1 - Adia se não for dia útil
               2 - Dia fixo
             */

            IF (@AdiaSeNaoUtil = 1)
                -- Adia
                SET @Resposta = DATEADD(DAY, 1, @Resposta);
            ELSE IF (@AdiaSeNaoUtil = 0)
                -- Adianta
                SET @Resposta = DATEADD(DAY, -1, @Resposta);

        END;

    END
    ELSE
    BEGIN
        -- Não é dia fixo - Exemplo: 5º dia útil do mês.

        -- Dia primeiro do mês inicial
        SET @Resposta = DATEADD(MONTH, DATEDIFF(MONTH, 0, @DiaInicial), 0);

        -- Avança N meses
        SET @Resposta = DATEADD(MONTH, @Proxima, @Resposta);

        WHILE (@Contador < @Dia)
        BEGIN

            -- Adiciona um enquanto @Resposta não for dia útil
            WHILE (dbo.fncDiaUtil(@Resposta) = 0)
                SET @Resposta = DATEADD(DAY, 1, @Resposta);

            SET @Contador = @Contador + 1;

            IF (@Contador < @Dia)
                SET @Resposta = DATEADD(DAY, 1, @Resposta);

        END;

    END;

    RETURN @Resposta;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncSaldoContaEmMoedaPadrao]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/***********************************************************
 Função fncSaldoContaEmMoedaPadrao

 Encontra o saldo da conta e converte para a moeda padrão
 na data especificada.

 Elcio Reis - 03/10/2019

 Exemplo de execução
 SELECT dbo.fncSaldoContaEmMoedaPadrao(33, '2019-10-03')
 ***********************************************************/

CREATE FUNCTION [dbo].[fncSaldoContaEmMoedaPadrao](@ContaID INT, @Data DATE)
RETURNS DECIMAL(10,2)
AS
BEGIN

    DECLARE @DataReferencia DATE = DATEADD(DAY, 1, @Data);
    DECLARE @Retorno DECIMAL(10,2);

    WITH Profundidade01 AS (SELECT MoEl.MoedaID MoedaID_01, MoEl.ParaMoedaID MoedaID_02,
                                   MoEl.SimboloWebService WebServiceSymbol_01, Para.Virtual
                            FROM MoedaEletronica MoEl
                                 JOIN Moeda Para ON Para.MoedaID = MoEl.ParaMoedaID),
         Profundidade02 AS (SELECT Pf_1.MoedaID_01, Pf_1.MoedaID_02, MoEl.ParaMoedaID MoedaID_03,
                                   Pf_1.WebServiceSymbol_01,
                                   MoEl.SimboloWebService WebServiceSymbol_02
                            FROM Profundidade01 Pf_1
                                 JOIN MoedaEletronica MoEl ON MoEl.MoedaID = Pf_1.MoedaID_02)
    SELECT @Retorno = CAST(ROUND(Base.ValorBase * Base.Cotacao, 2, 1) AS DECIMAL(10,2))
    FROM (SELECT CAST(SUM(Movt.Valor) + dbo.fncTotalContaInvestimentoLiquido(Cnta.ContaID) AS NUMERIC(18,4)) AS ValorBase,
                 1 Fator01,
                 1 Fator02,
                 1 Fator03,
                 1 Cotacao,
                 CAST(1 AS TINYINT) Origem
          FROM Conta Cnta
               JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
               JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
               JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID
                              AND Moed.Padrao = 1
               JOIN MovimentoConta Movt ON Movt.ContaID = Cnta.ContaID
          WHERE Cnta.ContaID = @ContaID
          AND   Movt.Data < @DataReferencia
          GROUP BY Cnta.ContaID

          UNION ALL

          SELECT CAST(SUM(Movt.Valor) + dbo.fncTotalContaInvestimentoLiquido(Cnta.ContaID) AS NUMERIC(18,4)) AS ValorBase,
                 1 Fator01,
                 1 Fator02,
                 COALESCE(CASE WHEN Moed.Padrao = 1 THEN 1 ELSE Cotc.Cotacao END, 0) Fator03,
                 COALESCE(CASE WHEN Moed.Padrao = 1 THEN 1 ELSE Cotc.Cotacao END, 0) Cotacao,
                 CAST(2 AS TINYINT) Origem
          FROM Conta Cnta
               JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
               JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
               JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID
                              AND Moed.Padrao = 0
                              AND Moed.Virtual = 0
               JOIN Moeda Padr ON Padr.Padrao = 1
               JOIN MovimentoConta Movt ON Movt.ContaID = Cnta.ContaID
          LEFT JOIN CotacaoMoeda Cotc ON Cotc.DeMoedaID = Moed.MoedaID
                                     AND Cotc.ParaMoedaID = Padr.MoedaID
                                     AND Cotc.Data = (SELECT MAX(Data) 
                                                      FROM CotacaoMoeda 
                                                      WHERE DeMoedaID = Moed.MoedaID
                                                      AND   ParaMoedaID = Padr.MoedaID
                                                      AND   Data < @DataReferencia)
          WHERE Cnta.ContaID = @ContaID
          AND   Movt.Data < @DataReferencia
          GROUP BY Cnta.ContaID, Moed.Padrao, Cotc.Cotacao

          UNION ALL

          SELECT CAST(SUM(Movt.Valor) + dbo.fncTotalContaInvestimentoLiquido(Cnta.ContaID) AS NUMERIC(18,4)) AS ValorBase,
                 1 Fator01,
                 THit.HitLast Fator02,
                 CotC.Cotacao Fator03,
                 THit.HitLast * CotC.Cotacao Cotacao,
                 CAST(3 AS TINYINT) Origem
          FROM Conta Cnta
               JOIN Profundidade01 Pf_1 ON Pf_1.MoedaID_01 = Cnta.MoedaID
                                       AND Pf_1.Virtual = 0
               JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
               JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
               JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID
               JOIN Moeda Padr ON Padr.Padrao = 1
               JOIN MovimentoConta Movt ON Movt.ContaID = Cnta.ContaID
          LEFT JOIN TickerHitBTC THit ON THit.HitSymbol = Pf_1.WebServiceSymbol_01
                                     AND THit.HitTimeStamp_Local = (SELECT MAX(HitTimeStamp_Local)
                                                                    FROM TickerHitBTC
                                                                    WHERE HitSymbol = Pf_1.WebServiceSymbol_01
                                                                    AND   HitTimeStamp_Local < @DataReferencia)
          LEFT JOIN CotacaoMoeda Cotc ON Cotc.DeMoedaID = Pf_1.MoedaID_02
                                     AND Cotc.ParaMoedaID = Padr.MoedaID
                                     AND Cotc.Data = (SELECT MAX(Data) 
                                                      FROM CotacaoMoeda 
                                                      WHERE DeMoedaID = Pf_1.MoedaID_02
                                                      AND   ParaMoedaID = Padr.MoedaID
                                                      AND   Data < @DataReferencia)
          WHERE Cnta.ContaID = @ContaID
          AND   Movt.Data < @DataReferencia
          GROUP BY Cnta.ContaID, THit.HitLast, Cotc.Cotacao

          UNION ALL

          SELECT CAST(SUM(Movt.Valor) + dbo.fncTotalContaInvestimentoLiquido(Cnta.ContaID) AS NUMERIC(18,4)) AS ValorBase,
                 Hit1.HitLast Fator01,
                 Hit2.HitLast Fator02,
                 CotC.Cotacao Fator03,
                 Hit1.HitLast * Hit2.HitLast * CotC.Cotacao Cotacao,
                 CAST(4 AS TINYINT) Origem
          FROM Conta Cnta
               JOIN Profundidade02 Pf_2 ON Pf_2.MoedaID_01 = Cnta.MoedaID                             
               JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
               JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
               JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID
               JOIN Moeda Padr ON Padr.Padrao = 1
               JOIN MovimentoConta Movt ON Movt.ContaID = Cnta.ContaID
          LEFT JOIN TickerHitBTC Hit1 ON Hit1.HitSymbol = Pf_2.WebServiceSymbol_01
                                     AND Hit1.HitTimeStamp_Local = (SELECT MAX(HitTimeStamp_Local)
                                                                    FROM TickerHitBTC
                                                                    WHERE HitSymbol = Pf_2.WebServiceSymbol_01
                                                                    AND   HitTimeStamp_Local < @DataReferencia)
          LEFT JOIN TickerHitBTC Hit2 ON Hit2.HitSymbol = Pf_2.WebServiceSymbol_02
                                     AND Hit2.HitTimeStamp_Local = (SELECT MAX(HitTimeStamp_Local)
                                                                    FROM TickerHitBTC
                                                                    WHERE HitSymbol = Pf_2.WebServiceSymbol_02
                                                                    AND   HitTimeStamp_Local < @DataReferencia)
          LEFT JOIN CotacaoMoeda Cotc ON Cotc.DeMoedaID = Pf_2.MoedaID_03
                                     AND Cotc.ParaMoedaID = Padr.MoedaID
                                     AND Cotc.Data = (SELECT MAX(Data) 
                                                      FROM CotacaoMoeda 
                                                      WHERE DeMoedaID = Pf_2.MoedaID_03
                                                      AND   ParaMoedaID = Padr.MoedaID
                                                      AND   Data < @DataReferencia)
          WHERE Cnta.ContaID = @ContaID
          AND   Movt.Data < @DataReferencia
          GROUP BY Cnta.ContaID, Hit1.HitLast, Hit2.HitLast, Cotc.Cotacao) Base

    RETURN @Retorno;
    
END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncSaldoContaInvestimento]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fncSaldoContaInvestimento](@ContaID INT)
RETURNS NUMERIC(18,4)
AS
BEGIN

    DECLARE @Resultado NUMERIC(18,4);

    SELECT @Resultado = COALESCE(SUM(MInv.QtCotas * Ultm.VrCotacao), 0)
    FROM MovimentoConta Mvto
         INNER JOIN MovimentoInvestimento MInv 
           ON MInv.MovimentoContaID = Mvto.MovimentoContaID
         INNER JOIN InvestimentoCotacao Ultm
           ON Ultm.InvestimentoID = MInv.InvestimentoID
          AND Ultm.Data = (SELECT MAX(Cota.Data) FROM InvestimentoCotacao Cota WHERE Cota.InvestimentoID = MInv.InvestimentoID AND Cota.Data <= GETDATE())
    WHERE Mvto.ContaID = @ContaID
      AND Mvto.Data <= GETDATE();


    IF (@Resultado IS NULL) 
    BEGIN
        SET @Resultado = 0;
    END;

    RETURN @Resultado;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncSaldoContaInvestimentoData]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fncSaldoContaInvestimentoData](@ContaID INT, @Data DATE)
RETURNS NUMERIC(18,4)
AS
BEGIN

    DECLARE @Resultado NUMERIC(18,4);

    SELECT @Resultado = COALESCE(SUM(MInv.QtCotas * Ultm.VrCotacao), 0)
    FROM MovimentoConta Mvto
         INNER JOIN MovimentoInvestimento MInv 
           ON MInv.MovimentoContaID = Mvto.MovimentoContaID
         INNER JOIN InvestimentoCotacao Ultm
           ON Ultm.InvestimentoID = MInv.InvestimentoID
          AND Ultm.Data = (SELECT MAX(Cota.Data) FROM InvestimentoCotacao Cota WHERE Cota.InvestimentoID = MInv.InvestimentoID AND Cota.Data <= @Data)
    WHERE Mvto.ContaID = @ContaID
      AND Mvto.Data <= @Data;

    IF (@Resultado IS NULL) 
    BEGIN
        SET @Resultado = 0;
    END;

    RETURN @Resultado;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncSaldoInvestimentoData]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fncSaldoInvestimentoData](@InvestimetoID INT, @Data DATE)
RETURNS NUMERIC(18,2)
AS
BEGIN

    DECLARE @Resultado NUMERIC(18,2);

    SELECT @Resultado = COALESCE(SUM(MInv.QtCotas * Ultm.VrCotacao), 0)
    FROM MovimentoConta Mvto
         INNER JOIN MovimentoInvestimento MInv 
           ON MInv.MovimentoContaID = Mvto.MovimentoContaID
         INNER JOIN InvestimentoCotacao Ultm
           ON Ultm.InvestimentoID = MInv.InvestimentoID
          AND Ultm.Data = (SELECT MAX(Cota.Data) FROM InvestimentoCotacao Cota WHERE Cota.InvestimentoID = MInv.InvestimentoID AND Cota.Data <= @Data)
    WHERE MInv.InvestimentoID = @InvestimetoID
      AND Mvto.Data <= @Data;

    IF (@Resultado IS NULL) 
    BEGIN
        SET @Resultado = 0;
    END;

    RETURN @Resultado;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncSaldoInvestimentoLiquido]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
 Fornece o saldo líquido de um investimento em uma determinada data.
 */

/************************************************************
 SELECT dbo.fncSaldoInvestimentoLiquido(1, '2016-11-14', 1);
 ************************************************************/

CREATE FUNCTION [dbo].[fncSaldoInvestimentoLiquido] (
    @InvestimentoID INT, 
    @Data DATE,
    @TipoInformacao INT)
RETURNS
    NUMERIC(18, 8)
AS
BEGIN

    DECLARE @Resposta NUMERIC(18, 8);
    
    DECLARE @Tabela TABLE (
        InvestimentoID  INT,
        Data            DATE, 
        QtCotas         NUMERIC(18, 10),
        SdCotas         NUMERIC(18, 10),
        CotacaoCompra   NUMERIC(18, 10),
        CotacaoVenda    NUMERIC(18, 10),
        ValorCusto      NUMERIC(18,  2), -- 4
        ValorBruto      NUMERIC(18,  2), -- 4
        LucroBruto      NUMERIC(18,  2), -- 4
        PercIOF         NUMERIC(18,  4),
        ValorIOF        NUMERIC(18,  2), -- 4
        PercIR          NUMERIC(18,  4),
        ValorIR         NUMERIC(18,  2), -- 4
        UltimoComeCota  DATE,
        CotacaoComeCota NUMERIC(18, 10),
        PercIOFComeCota NUMERIC(18,  4) DEFAULT 0,
        ValorComeCota   NUMERIC(18,  2), -- 4
        Dias            INT,
        ImpostoDevido   NUMERIC(18,  2)  -- 4
    );

    DECLARE @CotacaoData NUMERIC(18, 10);

    SELECT @CotacaoData = VrCotacao
    FROM InvestimentoCotacao Ultm
    WHERE Ultm.Data = (SELECT MAX(Cota.Data) FROM InvestimentoCotacao Cota WHERE Cota.InvestimentoID = @InvestimentoID AND Cota.Data <= @Data)
    AND   Ultm.InvestimentoID = @InvestimentoID;

    -- Insere todos os movimentos de compra de cotas
    INSERT INTO @Tabela
    (InvestimentoID, Data, UltimoComeCota, QtCotas, SdCotas, CotacaoVenda)
    SELECT Inve.InvestimentoID, Mvto.Data, dbo.fncUltimoComeCota(Inve.InvestimentoID, Mvto.Data, @Data) UltimoComeCota, SUM(Inve.QtCotas), SUM(Inve.QtCotas), @CotacaoData
    FROM MovimentoConta Mvto
         INNER JOIN MovimentoInvestimento Inve ON Inve.MovimentoContaID = Mvto.MovimentoContaID AND Inve.QtCotas > 0
    WHERE Inve.InvestimentoID = @InvestimentoID AND Mvto.Data <= @Data
    GROUP BY Inve.InvestimentoID, Mvto.Data
    ORDER BY Mvto.Data ASC;

    DECLARE @VendaData DATE, @VendaCotas NUMERIC(18, 10);
    DECLARE @auxData DATE, @auxSaldo NUMERIC(18, 10);

    DECLARE Venda CURSOR
    FOR SELECT Mvto.Data, SUM(ABS(Inve.QtCotas))
        FROM MovimentoConta Mvto
             INNER JOIN MovimentoInvestimento Inve ON Inve.MovimentoContaID = Mvto.MovimentoContaID AND Inve.QtCotas < 0
        WHERE Inve.InvestimentoID = @InvestimentoID AND Mvto.Data <= @Data
        GROUP BY Mvto.Data
        ORDER BY Mvto.Data ASC;

    OPEN Venda;

    FETCH NEXT FROM Venda
    INTO @VendaData, @VendaCotas;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        WHILE (@VendaCotas > 0)
        BEGIN
            -- Procura a data mais antiga para baixar a venda 
            -- (as cotas mais antigas são vendidas primeiro)
            SELECT @auxData = MIN(Data) FROM @Tabela WHERE SdCotas > 0;
            SELECT @auxSaldo = SdCotas FROM @Tabela WHERE Data = @auxData;

            IF (@auxSaldo >= @VendaCotas)
            BEGIN
                UPDATE @Tabela
                SET SdCotas = SdCotas - @VendaCotas
                WHERE Data = @auxData;

                SET @VendaCotas = 0;
            END
            ELSE
            BEGIN
                UPDATE @Tabela
                SET SdCotas = 0
                WHERE Data = @auxData;

                SET @VendaCotas = @VendaCotas - @auxSaldo;
            END;
            
            
        END;

        FETCH NEXT FROM Venda
        INTO @VendaData, @VendaCotas;

    END;

    CLOSE Venda;
    DEALLOCATE Venda;

    UPDATE @Tabela
    SET CotacaoCompra = Ultm.VrCotacao,
        ValorCusto = SdCotas * Ultm.VrCotacao,
        ValorBruto = SdCotas * CotacaoVenda,
        LucroBruto = (SdCotas * CotacaoVenda) - (SdCotas * Ultm.VrCotacao),
        Dias = DATEDIFF(DAY, Tabl.Data, @Data),
        CotacaoComeCota = DBO.fncCotacaoComeCota(Tabl.InvestimentoID, UltimoComeCota)
    FROM @Tabela Tabl
    INNER JOIN InvestimentoCotacao Ultm 
    ON  Ultm.Data = (SELECT MAX(Cota.Data) FROM InvestimentoCotacao Cota WHERE Cota.InvestimentoID = @InvestimentoID AND Cota.Data <= Tabl.Data)
    AND Ultm.InvestimentoID = @InvestimentoID
    WHERE Tabl.SdCotas > 0;

    -- Desconta o IOF
    UPDATE @Tabela
    SET PercIOF = Faix.Porcentagem,
        ValorIOF = CASE 
                       WHEN Tabl.LucroBruto > 0 THEN ROUND(Tabl.LucroBruto * Faix.Porcentagem / 100, 2, 1)
                       ELSE 0
                   END
    FROM @Tabela Tabl
    INNER JOIN InvestimentoDespesa Desp ON Desp.InvestimentoID = Tabl.InvestimentoID AND Desp.IOF = 1
    INNER JOIN Imposto Impt ON Impt.ImpostoID = Desp.ImpostoID AND Impt.Ativo = 1
    INNER JOIN ImpostoFaixa Faix ON Faix.ImpostoID = Impt.ImpostoID AND Tabl.Dias BETWEEN Faix.DiasDe AND Faix.DiasAte
    WHERE Tabl.SdCotas > 0;

    -- Desconta o IF
    UPDATE @Tabela
    SET PercIR = Faix.Porcentagem,
        ValorIR = CASE WHEN Tabl.LucroBruto > 0 THEN ROUND(((Tabl.LucroBruto - COALESCE(Tabl.ValorIOF, 0)) * Faix.Porcentagem) / 100, 2, 1)
                       ELSE 0
                  END
    FROM @Tabela Tabl
    INNER JOIN InvestimentoDespesa Desp ON Desp.InvestimentoID = Tabl.InvestimentoID AND Desp.IR = 1
    INNER JOIN Imposto Impt ON Impt.ImpostoID = Desp.ImpostoID AND Impt.Ativo = 1
    INNER JOIN ImpostoFaixa Faix ON Faix.ImpostoID = Impt.ImpostoID AND Tabl.Dias BETWEEN Faix.DiasDe AND Faix.DiasAte
    WHERE Tabl.SdCotas > 0;
    
    -- Encontra a porcentagem de IOF no dia do Come Cotas
    UPDATE @Tabela
    SET PercIOFComeCota = Faix.Porcentagem
    FROM @Tabela Tabl
    INNER JOIN InvestimentoDespesa Desp ON Desp.InvestimentoID = Tabl.InvestimentoID AND Desp.IOF = 1
    INNER JOIN Imposto Impt ON Impt.ImpostoID = Desp.ImpostoID AND Impt.Ativo = 1
    INNER JOIN ImpostoFaixa Faix ON Faix.ImpostoID = Impt.ImpostoID AND DATEDIFF(DAY, Tabl.Data, Tabl.UltimocomeCota) BETWEEN Faix.DiasDe AND Faix.DiasAte
    WHERE Tabl.SdCotas > 0
    AND   Tabl.UltimoComeCota IS NOT NULL;

    -- Calcula o Come Cota
    UPDATE @Tabela
    SET ValorComeCota = (((SdCotas * CotacaoComeCota) - (SdCotas * CotacaoCompra)) -                                        ---- LucroBruto
                         ((SdCotas * CotacaoComeCota) - (SdCotas * CotacaoCompra)) * (PercIOFComeCota / 100)) *             ---- IOFNoComeCota
                        0.15;                                                                                               ---- Alíquota fixa do Come Cotas

    UPDATE @Tabela
    SET ImpostoDevido = COALESCE(ValorIOF, 0) + COALESCE(ValorIR, 0) - COALESCE(ValorComeCota, 0);

    IF (@TipoInformacao = 0)
    BEGIN
        --
        -- Saldo bruto da aplicação
        --
        SELECT @Resposta = SUM(ValorBruto)
        FROM @Tabela;

    END
    ELSE IF (@TipoInformacao = 1)
    BEGIN
        --
        -- Saldo líquido da aplicação
        --
        SELECT @Resposta = SUM(ValorBruto) - SUM(ImpostoDevido)
        FROM @Tabela;

    END
    ELSE IF (@TipoInformacao = 2)
    BEGIN
        --
        -- Saldo imposto devido
        --
        SELECT @Resposta = SUM(ImpostoDevido)
        FROM @Tabela;

    END;

    RETURN @Resposta;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncSaldoInvestimentoLiquido_20200716]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
 Fornece o saldo líquido de um investimento em uma determinada data.
 */

/************************************************************
 SELECT dbo.fncSaldoInvestimentoLiquido(1, '2016-11-14', 1);
 ************************************************************/

CREATE FUNCTION [dbo].[fncSaldoInvestimentoLiquido_20200716] (
    @InvestimentoID INT, 
    @Data DATE,
    @TipoInformacao INT)
RETURNS
    NUMERIC(18, 8)
AS
BEGIN

    DECLARE @Resposta NUMERIC(18, 8);
    
    DECLARE @Tabela TABLE (
        InvestimentoID  INT,
        Data            DATE, 
        QtCotas         NUMERIC(18, 10),
        SdCotas         NUMERIC(18, 10),
        CotacaoCompra   NUMERIC(18, 10),
        CotacaoVenda    NUMERIC(18, 10),
        ValorCusto      NUMERIC(18,  2), -- 4
        ValorBruto      NUMERIC(18,  2), -- 4
        LucroBruto      NUMERIC(18,  2), -- 4
        PercIOF         NUMERIC(18,  4),
        ValorIOF        NUMERIC(18,  2), -- 4
        PercIR          NUMERIC(18,  4),
        ValorIR         NUMERIC(18,  2), -- 4
        UltimoComeCota  DATE,
        CotacaoComeCota NUMERIC(18, 10),
        PercIOFComeCota NUMERIC(18,  4) DEFAULT 0,
        ValorComeCota   NUMERIC(18,  2), -- 4
        Dias            INT,
        ImpostoDevido   NUMERIC(18,  2) -- 4
    );

    DECLARE @CotacaoData NUMERIC(18, 10);

    SELECT @CotacaoData = VrCotacao
    FROM InvestimentoCotacao Ultm
    WHERE Ultm.Data = (SELECT MAX(Cota.Data) FROM InvestimentoCotacao Cota WHERE Cota.InvestimentoID = @InvestimentoID AND Cota.Data <= @Data)
    AND   Ultm.InvestimentoID = @InvestimentoID;

    -- Insere todos os movimentos de compra de cotas
    INSERT INTO @Tabela
    (InvestimentoID, Data, UltimoComeCota, QtCotas, SdCotas, CotacaoVenda)
    SELECT Inve.InvestimentoID, Mvto.Data, dbo.fncUltimoComeCota(Inve.InvestimentoID, Mvto.Data, @Data) UltimoComeCota, SUM(Inve.QtCotas), SUM(Inve.QtCotas), @CotacaoData
    FROM MovimentoConta Mvto
         INNER JOIN MovimentoInvestimento Inve ON Inve.MovimentoContaID = Mvto.MovimentoContaID AND Inve.QtCotas > 0
    WHERE Inve.InvestimentoID = @InvestimentoID AND Mvto.Data <= @Data
    GROUP BY Inve.InvestimentoID, Mvto.Data
    ORDER BY Mvto.Data ASC;

    DECLARE @VendaData DATE, @VendaCotas NUMERIC(18, 10);
    DECLARE @auxData DATE, @auxSaldo NUMERIC(18, 10);

    DECLARE Venda CURSOR
    FOR SELECT Mvto.Data, SUM(ABS(Inve.QtCotas))
        FROM MovimentoConta Mvto
             INNER JOIN MovimentoInvestimento Inve ON Inve.MovimentoContaID = Mvto.MovimentoContaID AND Inve.QtCotas < 0
        WHERE Inve.InvestimentoID = @InvestimentoID AND Mvto.Data <= @Data
        GROUP BY Mvto.Data
        ORDER BY Mvto.Data ASC;

    OPEN Venda;

    FETCH NEXT FROM Venda
    INTO @VendaData, @VendaCotas;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        WHILE (@VendaCotas > 0)
        BEGIN
            -- Procura a data mais antiga para baixar a venda 
            -- (as cotas mais antigas são vendidas primeiro)
            SELECT @auxData = MIN(Data) FROM @Tabela WHERE SdCotas > 0;
            SELECT @auxSaldo = SdCotas FROM @Tabela WHERE Data = @auxData;

            IF (@auxSaldo >= @VendaCotas)
            BEGIN
                UPDATE @Tabela
                SET SdCotas = SdCotas - @VendaCotas
                WHERE Data = @auxData;

                SET @VendaCotas = 0;
            END
            ELSE
            BEGIN
                UPDATE @Tabela
                SET SdCotas = 0
                WHERE Data = @auxData;

                SET @VendaCotas = @VendaCotas - @auxSaldo;
            END;
            
            
        END;

        FETCH NEXT FROM Venda
        INTO @VendaData, @VendaCotas;

    END;

    CLOSE Venda;
    DEALLOCATE Venda;

    UPDATE @Tabela
    SET CotacaoCompra = Ultm.VrCotacao,
        ValorCusto = SdCotas * Ultm.VrCotacao,
        ValorBruto = SdCotas * CotacaoVenda,
        LucroBruto = (SdCotas * CotacaoVenda) - (SdCotas * Ultm.VrCotacao),
        Dias = DATEDIFF(DAY, Tabl.Data, @Data),
        CotacaoComeCota = DBO.fncCotacaoComeCota(Tabl.InvestimentoID, UltimoComeCota)
    FROM @Tabela Tabl
    INNER JOIN InvestimentoCotacao Ultm 
    ON  Ultm.Data = (SELECT MAX(Cota.Data) FROM InvestimentoCotacao Cota WHERE Cota.InvestimentoID = @InvestimentoID AND Cota.Data <= Tabl.Data)
    AND Ultm.InvestimentoID = @InvestimentoID
    WHERE Tabl.SdCotas > 0;

    -- Desconta o IOF
    UPDATE @Tabela
    SET PercIOF = Faix.Porcentagem,
        ValorIOF = Round(Tabl.LucroBruto * Faix.Porcentagem / 100, 2, 1)
        --ValorIOF = Tabl.LucroBruto * Faix.Porcentagem / 100
    FROM @Tabela Tabl
    INNER JOIN InvestimentoDespesa Desp ON Desp.InvestimentoID = Tabl.InvestimentoID AND Desp.IOF = 1
    INNER JOIN Imposto Impt ON Impt.ImpostoID = Desp.ImpostoID AND Impt.Ativo = 1
    INNER JOIN ImpostoFaixa Faix ON Faix.ImpostoID = Impt.ImpostoID AND Tabl.Dias BETWEEN Faix.DiasDe AND Faix.DiasAte
    WHERE Tabl.SdCotas > 0;

    -- Desconta o IF
    UPDATE @Tabela
    SET PercIR = Faix.Porcentagem,
        ValorIR = Round(((Tabl.LucroBruto - COALESCE(Tabl.ValorIOF, 0)) * Faix.Porcentagem) / 100, 2, 1)
        ----ValorIR = (Tabl.LucroBruto - COALESCE(Tabl.ValorIOF, 0)) * Faix.Porcentagem / 100  ---- Arredonda pra cima
    FROM @Tabela Tabl
    INNER JOIN InvestimentoDespesa Desp ON Desp.InvestimentoID = Tabl.InvestimentoID AND Desp.IR = 1
    INNER JOIN Imposto Impt ON Impt.ImpostoID = Desp.ImpostoID AND Impt.Ativo = 1
    INNER JOIN ImpostoFaixa Faix ON Faix.ImpostoID = Impt.ImpostoID AND Tabl.Dias BETWEEN Faix.DiasDe AND Faix.DiasAte
    WHERE Tabl.SdCotas > 0;
    
    -- Encontra a porcentagem de IOF no dia do Come Cotas
    UPDATE @Tabela
    SET PercIOFComeCota = Faix.Porcentagem
    FROM @Tabela Tabl
    INNER JOIN InvestimentoDespesa Desp ON Desp.InvestimentoID = Tabl.InvestimentoID AND Desp.IOF = 1
    INNER JOIN Imposto Impt ON Impt.ImpostoID = Desp.ImpostoID AND Impt.Ativo = 1
    INNER JOIN ImpostoFaixa Faix ON Faix.ImpostoID = Impt.ImpostoID AND DATEDIFF(DAY, Tabl.Data, Tabl.UltimocomeCota) BETWEEN Faix.DiasDe AND Faix.DiasAte
    WHERE Tabl.SdCotas > 0
    AND   Tabl.UltimoComeCota IS NOT NULL;

/*
    -- Calcula o Come Cota ----- não levava em consideração existência de IOF no dia do come cotas
    UPDATE @Tabela
    SET ValorComeCota = ((SdCotas * CotacaoComeCota) - (SdCotas * CotacaoCompra)) * 0.15;
 */

    -- Calcula o Come Cota
    UPDATE @Tabela
    SET ValorComeCota = (((SdCotas * CotacaoComeCota) - (SdCotas * CotacaoCompra)) -                                        ---- LucroBruto
                         ((SdCotas * CotacaoComeCota) - (SdCotas * CotacaoCompra)) * (PercIOFComeCota / 100)) *             ---- IOFNoComeCota
                        0.15;                                                                                               ---- Alíquota fixa do Come Cotas


    UPDATE @Tabela
    SET ImpostoDevido = COALESCE(ValorIOF, 0) + COALESCE(ValorIR, 0) - COALESCE(ValorComeCota, 0);

    IF (@TipoInformacao = 0)
    BEGIN

        SET @Resposta = 0;

    END
    ELSE IF (@TipoInformacao = 1)
    BEGIN
        --
        -- Saldo líquido da aplicação
        --
        SELECT @Resposta = SUM(ValorBruto) - SUM(ImpostoDevido)
        FROM @Tabela

    END;

    RETURN @Resposta;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncSaldoInvestimentoLiquidoDiaExato]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
 Fornece o saldo líquido de um investimento em uma determinada data.
 */

/************************************************************
 SELECT dbo.fncSaldoInvestimentoLiquidoDiaExato(1, '2016-11-14', 1);
 ************************************************************/

CREATE FUNCTION [dbo].[fncSaldoInvestimentoLiquidoDiaExato] (
    @InvestimentoID INT, 
    @Data DATE,
    @TipoInformacao INT)
RETURNS
    NUMERIC(18, 8)
AS
BEGIN

    DECLARE @Resposta NUMERIC(18, 8);
    
    DECLARE @Tabela TABLE (
        InvestimentoID  INT,
        Data            DATE, 
        UltimoComeCota  DATE,
        QtCotas         NUMERIC(18, 10),
        SdCotas         NUMERIC(18, 10),
        CotacaoCompra   NUMERIC(18, 10),
        CotacaoVenda    NUMERIC(18, 10),
        CotacaoComeCota NUMERIC(18, 10),
        ValorCusto      NUMERIC(18,  4),
        ValorBruto      NUMERIC(18,  4),
        LucroBruto      NUMERIC(18,  4),
        PercIOF         NUMERIC(18,  4),
        ValorIOF        NUMERIC(18,  4),
        PercIR          NUMERIC(18,  4),
        ValorIR         NUMERIC(18,  4),
        ValorComeCota   NUMERIC(18,  4),
        Dias            INT,
        ImpostoDevido   NUMERIC(18,  4)
    );

    DECLARE @CotacaoData NUMERIC(18, 10);

    SELECT @CotacaoData = VrCotacao
    FROM InvestimentoCotacao Ultm
    WHERE Ultm.Data = @Data
    AND   Ultm.InvestimentoID = @InvestimentoID;

    -- Insere todos os movimentos de compra de cotas
    INSERT INTO @Tabela
    (InvestimentoID, Data, UltimoComeCota, QtCotas, SdCotas, CotacaoVenda)
    SELECT Inve.InvestimentoID, Mvto.Data, dbo.fncUltimoComeCota(Inve.InvestimentoID, Mvto.Data, @Data) UltimoComeCota, SUM(Inve.QtCotas), SUM(Inve.QtCotas), @CotacaoData
    FROM MovimentoConta Mvto
         INNER JOIN MovimentoInvestimento Inve ON Inve.MovimentoContaID = Mvto.MovimentoContaID AND Inve.QtCotas > 0
    WHERE Inve.InvestimentoID = @InvestimentoID AND Mvto.Data <= @Data
    GROUP BY Inve.InvestimentoID, Mvto.Data
    ORDER BY Mvto.Data ASC;

    DECLARE @VendaData DATE, @VendaCotas NUMERIC(18, 10);
    DECLARE @auxData DATE, @auxSaldo NUMERIC(18, 10);

    DECLARE Venda CURSOR
    FOR SELECT Mvto.Data, SUM(ABS(Inve.QtCotas))
        FROM MovimentoConta Mvto
             INNER JOIN MovimentoInvestimento Inve ON Inve.MovimentoContaID = Mvto.MovimentoContaID AND Inve.QtCotas < 0
        WHERE Inve.InvestimentoID = @InvestimentoID AND Mvto.Data <= @Data
        GROUP BY Mvto.Data
        ORDER BY Mvto.Data ASC;

    OPEN Venda;

    FETCH NEXT FROM Venda
    INTO @VendaData, @VendaCotas;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        WHILE (@VendaCotas > 0)
        BEGIN
            -- Procura a data mais antiga para baixar a venda 
            -- (as cotas mais antigas são vendidas primeiro)
            SELECT @auxData = MIN(Data) FROM @Tabela WHERE SdCotas > 0;
            SELECT @auxSaldo = SdCotas FROM @Tabela WHERE Data = @auxData;

            IF (@auxSaldo >= @VendaCotas)
            BEGIN
                UPDATE @Tabela
                SET SdCotas = SdCotas - @VendaCotas
                WHERE Data = @auxData;

                SET @VendaCotas = 0;
            END
            ELSE
            BEGIN
                UPDATE @Tabela
                SET SdCotas = 0
                WHERE Data = @auxData;

                SET @VendaCotas = @VendaCotas - @auxSaldo;
            END;
            
            
        END;

        FETCH NEXT FROM Venda
        INTO @VendaData, @VendaCotas;

    END;

    CLOSE Venda;
    DEALLOCATE Venda;

    UPDATE @Tabela
    SET CotacaoCompra = Ultm.VrCotacao,
        ValorCusto = SdCotas * Ultm.VrCotacao,
        ValorBruto = SdCotas * CotacaoVenda,
        LucroBruto = (SdCotas * CotacaoVenda) - (SdCotas * Ultm.VrCotacao),
        Dias = DATEDIFF(DAY, Tabl.Data, @Data),
        CotacaoComeCota = DBO.fncCotacaoComeCota(Tabl.InvestimentoID, UltimoComeCota)
    FROM @Tabela Tabl
    INNER JOIN InvestimentoCotacao Ultm 
    ON  Ultm.Data = (SELECT MAX(Cota.Data) FROM InvestimentoCotacao Cota WHERE Cota.InvestimentoID = @InvestimentoID AND Cota.Data <= Tabl.Data)
    AND Ultm.InvestimentoID = @InvestimentoID
    WHERE Tabl.SdCotas > 0;

    -- Desconta o IOF
    UPDATE @Tabela
    SET PercIOF = Faix.Porcentagem,
        ValorIOF = Tabl.LucroBruto * Faix.Porcentagem / 100
    FROM @Tabela Tabl
    INNER JOIN InvestimentoDespesa Desp ON Desp.InvestimentoID = Tabl.InvestimentoID AND Desp.IOF = 1
    INNER JOIN Imposto Impt ON Impt.ImpostoID = Desp.ImpostoID AND Impt.Ativo = 1
    INNER JOIN ImpostoFaixa Faix ON Faix.ImpostoID = Impt.ImpostoID AND Tabl.Dias BETWEEN Faix.DiasDe AND Faix.DiasAte
    WHERE Tabl.SdCotas > 0;

    -- Desconta o IF
    UPDATE @Tabela
    SET PercIR = Faix.Porcentagem,
        ValorIR = (Tabl.LucroBruto - COALESCE(Tabl.ValorIOF, 0)) * Faix.Porcentagem / 100  ---- Arredonda pra cima
    FROM @Tabela Tabl
    INNER JOIN InvestimentoDespesa Desp ON Desp.InvestimentoID = Tabl.InvestimentoID AND Desp.IR = 1
    INNER JOIN Imposto Impt ON Impt.ImpostoID = Desp.ImpostoID AND Impt.Ativo = 1
    INNER JOIN ImpostoFaixa Faix ON Faix.ImpostoID = Impt.ImpostoID AND Tabl.Dias BETWEEN Faix.DiasDe AND Faix.DiasAte
    WHERE Tabl.SdCotas > 0;
    
    -- Calcula o Come Cota
    UPDATE @Tabela
    SET ValorComeCota = ((SdCotas * CotacaoComeCota) - (SdCotas * CotacaoCompra)) * 0.15;

    UPDATE @Tabela
    SET ImpostoDevido = COALESCE(ValorIOF, 0) + COALESCE(ValorIR, 0) - COALESCE(ValorComeCota, 0);

    IF (@TipoInformacao = 0)
    BEGIN

        SET @Resposta = 0;

    END
    ELSE IF (@TipoInformacao = 1)
    BEGIN
        --
        -- Saldo líquido da aplicação
        --
        SELECT @Resposta = SUM(ValorBruto) - SUM(ImpostoDevido)
        FROM @Tabela

    END;

    RETURN @Resposta;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncTotalContaInvestimentoLiquido]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[fncTotalContaInvestimentoLiquido] (@ContaID INT)
RETURNS NUMERIC(22,10)
AS
BEGIN

    DECLARE @Resultado NUMERIC(22,10);

    SELECT @Resultado = SUM(DBO.fncSaldoInvestimentoLiquido(Invt.InvestimentoID, Ultm.Data, 1))
    FROM Investimento Invt
    INNER JOIN InvestimentoCotacao Ultm
    ON Ultm.InvestimentoID = Invt.InvestimentoID
    AND Ultm.Data = (SELECT MAX(Cota.Data) FROM InvestimentoCotacao Cota WHERE Cota.InvestimentoID = Invt.InvestimentoID AND Cota.Data <= GETDATE())
    WHERE Invt.InvestimentoID IN (SELECT DISTINCT MInv.InvestimentoID
                                  FROM MovimentoConta Mvto
                                       INNER JOIN MovimentoInvestimento MInv 
                                       ON MInv.MovimentoContaID = Mvto.MovimentoContaID
                                  WHERE Mvto.ContaID = @ContaID
                                  AND Mvto.Data <= GETDATE());
      
    --IF (@Resultado IS NULL) SET @Resultado = 0;

    RETURN Coalesce(@Resultado, 0);

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncUltimaAtualizacaoInvestimentos]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/***********************************************************
 dbo.fncUltimaAtualizacao
 Retorna a última data de atualização de cotações da
 CVM e de poupança

 Elcio Reis em 30/08/2019

 Exemplo de execucação

 SELECT dbo.fncUltimaAtualizacaoInvestimentos() AS Ultima;
 ***********************************************************/
 
CREATE FUNCTION [dbo].[fncUltimaAtualizacaoInvestimentos]()
RETURNS DATE
BEGIN
    DECLARE @Data DATE;

    SELECT @Data = MAX(Data) FROM InvestimentoCotacao;

    --WITH Atualizacoes AS (SELECT MAX(Data) Ultima 
    --                      FROM InvestimentoCotacao

    --                      UNION

    --                      SELECT MAX(MvCt.Data) Ultima 
    --                      FROM TipoConta TCta
    --                           JOIN Conta Cnta ON Cnta.TipoContaID = TCta.TipoContaID
    --                           JOIN MovimentoConta MvCt ON MvCt.ContaID = Cnta.ContaID
    --                                                   AND MvCt.CrdDeb = 'C'
    --                                                   AND MvCt.Conciliacao NOT IN ('A', 'F')
    --                      WHERE TCta.Poupanca = 1)
    --SELECT @Data = CAST(MAX(Ultima) AS DATE) FROM Atualizacoes;

    RETURN @Data;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncUltimoComeCota]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fncUltimoComeCota] (
    @InvestimentoID INT,
    @DataCompra     DATE,
    @DataVenda      DATE)
RETURNS DATE
AS
BEGIN

    DECLARE @Data           DATE;

    -- IF (EXISTS (SELECT InvestimentoDespesaID FROM InvestimentoDespesa WHERE InvestimentoID = @InvestimentoID AND ComeCota = 1))
    SELECT @Data = MAX(MvtC.Data)
    FROM MovimentoInvestimento MvtI
    INNER JOIN MovimentoConta MvtC ON MvtC.MovimentoContaID = MvtI.MovimentoContaID
    INNER JOIN MovimentoInvestimentoDespesa Desp ON Desp.MovimentoInvestimentoID = MvtI.MovimentoInvestimentoID
    WHERE MvtI.InvestimentoID = @InvestimentoID
    AND   MvtC.Data BETWEEN @DataCompra AND @DataVenda
    AND   MvtI.VrBruto = Desp.Valor;

    RETURN @Data;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncUltimoInvestimentoFeito]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fncUltimoInvestimentoFeito](@Lista VARCHAR(MAX))
RETURNS DATE AS

BEGIN

    DECLARE @UltimoInvestimento DATE;

    SELECT @UltimoInvestimento = MAX(MCta.Data)
    FROM MovimentoInvestimento MInv
    INNER JOIN MovimentoConta MCta ON MCta.MovimentoContaID = MInv.MovimentoContaID
    WHERE MInv.InvestimentoID IN (SELECT ID FROM DBO.fncListaParaTabela(@Lista))
    AND   MInv.QtCotas > 0;

    RETURN @UltimoInvestimento;

END;
GO
/****** Object:  UserDefinedFunction [dbo].[fncValorCambioEmMoedaPadrao]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/**************************************************
 Funcion fncValorCambioEmMoedaPadrao
 Elcio Reis - 02/10/2019

 Retorna o valor da conta com todos os movimentos
 até a data especificada (até o último momento do
 dia) convertido na moeda padrão (normalmente R$)

 Utiliza a cláusula WITH para encontrar a primeira
 ou segunda profundidade da moeda.
 Por exemplo: 
 BTC converte direto para US$ que não é moeda 
 virtual, então é considerada profundidade 1.

 XRP necessita ser convertida para BTC que será
 convertida para US$, então é considerada
 profundiade 2.

 Não encontrei necessidade de maior profundidade
   
 **************************************************/

CREATE FUNCTION [dbo].[fncValorCambioEmMoedaPadrao](@ContaID INT, @Data DATE)
RETURNS DECIMAL(22,10)

AS

BEGIN

    DECLARE @Resposta DECIMAL(22, 10) = 0;

    WITH Profundidade01 AS (SELECT MoEl.MoedaID MoedaID_01, MoEl.ParaMoedaID MoedaID_02,
                               MoEl.SimboloWebService WebServiceSymbol_01, Para.Virtual
                        FROM MoedaEletronica MoEl
                             JOIN Moeda Para ON Para.MoedaID = MoEl.ParaMoedaID),
         Profundidade02 AS (SELECT Pf_1.MoedaID_01, Pf_1.MoedaID_02, MoEl.ParaMoedaID MoedaID_03,
                                   Pf_1.WebServiceSymbol_01,
                                   MoEl.SimboloWebService WebServiceSymbol_02, Para.Virtual
                            FROM Profundidade01 Pf_1
                                 JOIN MoedaEletronica MoEl ON MoEl.MoedaID = Pf_1.MoedaID_02
                                 JOIN Moeda Para ON Para.MoedaID = MoEl.ParaMoedaID)
    SELECT @Resposta = Base.Valor
    FROM (SELECT SUM(MvCt.Valor) * THit.HitLast * CotC.Cotacao Valor, Cnta.MoedaID, Padr.MoedaID MoedaPadraoID
          FROM Conta Cnta
               JOIN Profundidade01 Pf_1 ON Pf_1.MoedaID_01 = Cnta.MoedaID
                                       AND Pf_1.Virtual = 0
               JOIN MovimentoConta MvCt on MvCt.ContaID = Cnta.ContaID
               JOIN Moeda Padr ON Padr.Padrao = 1
               LEFT JOIN TickerHitBTC THit ON THit.HitSymbol = Pf_1.WebServiceSymbol_01
                                 AND THit.HitTimeStamp_Local = (SELECT MAX(HitTimeStamp_Local)
                                                                FROM TickerHitBTC
                                                                WHERE HitSymbol = Pf_1.WebServiceSymbol_01
                                                                AND   HitTimeStamp_Local < DATEADD(DAY, 1, @Data))
               LEFT JOIN CotacaoMoeda Cotc ON Cotc.DeMoedaID = Pf_1.MoedaID_02
                                          AND Cotc.ParaMoedaID = Padr.MoedaID
                                          AND Cotc.Data = (SELECT MAX(Data) 
                                                           FROM CotacaoMoeda 
                                                           WHERE DeMoedaID = Pf_1.MoedaID_02
                                                           AND   ParaMoedaID = Padr.MoedaID
                                                           AND   Data < DATEADD(DAY, 1, @Data))
          WHERE Cnta.ContaID = @ContaID
          AND   MvCt.ContaID = @ContaID
          -- MENOR que o dia seguinte informado para pegar todos os movimentos no decorrer do período, mesmo que seja 23h59m.
          AND   MvCt.Data < DATEADD(DAY, 1, @Data)
          GROUP BY Cnta.MoedaID, Padr.MoedaID, THit.HitLast, CotC.Cotacao

          UNION ALL

          SELECT SUM(MvCt.Valor) * Hit1.HitLast * Hit2.HitLast * CotC.Cotacao Valor, Cnta.MoedaID, Padr.MoedaID MoedaPadraoID
          FROM Conta Cnta
               JOIN Profundidade02 Pf_2 ON Pf_2.MoedaID_01 = Cnta.MoedaID
                                       AND Pf_2.Virtual = 0
               JOIN MovimentoConta MvCt on MvCt.ContaID = Cnta.ContaID
               JOIN Moeda Padr ON Padr.Padrao = 1
          LEFT JOIN TickerHitBTC Hit1 ON Hit1.HitSymbol = Pf_2.WebServiceSymbol_01
                                 AND Hit1.HitTimeStamp_Local = (SELECT MAX(HitTimeStamp_Local)
                                                                FROM TickerHitBTC
                                                                WHERE HitSymbol = Pf_2.WebServiceSymbol_01
                                                                AND   HitTimeStamp_Local <= GETDATE())
          LEFT JOIN TickerHitBTC Hit2 ON Hit2.HitSymbol = Pf_2.WebServiceSymbol_02
                                     AND Hit2.HitTimeStamp_Local = (SELECT MAX(HitTimeStamp_Local)
                                                                    FROM TickerHitBTC
                                                                    WHERE HitSymbol = Pf_2.WebServiceSymbol_02
                                                                    AND   HitTimeStamp_Local <= GETDATE())
          LEFT JOIN CotacaoMoeda Cotc ON Cotc.DeMoedaID = Pf_2.MoedaID_03
                                     AND Cotc.ParaMoedaID = Padr.MoedaID
                                     AND Cotc.Data = (SELECT MAX(Data) 
                                                      FROM CotacaoMoeda 
                                                      WHERE DeMoedaID = Pf_2.MoedaID_03
                                                      AND   ParaMoedaID = Padr.MoedaID
                                                      AND   Data <= GETDATE())
          WHERE Cnta.ContaID = @ContaID
          AND   MvCt.ContaID = @ContaID
          -- MENOR que o dia seguinte informado para pegar todos os movimentos no decorrer do período, mesmo que seja 23h59m.
          AND   MvCt.Data < DATEADD(DAY, 1, @Data)
          GROUP BY Cnta.MoedaID, Padr.MoedaID, Hit1.HitLast, Hit2.HitLast, CotC.Cotacao) Base;




    RETURN @Resposta;

END;
GO
/****** Object:  Table [dbo].[TipoInvestimento]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoInvestimento](
	[TipoInvestimentoID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[Apelido] [varchar](25) NOT NULL,
	[Descricao] [varchar](100) NULL,
	[Ativo] [bit] NOT NULL,
	[Fundo] [bit] NOT NULL,
	[Acao] [bit] NOT NULL,
	[ComeCota] [bit] NOT NULL,
	[NovoID] [int] NULL,
 CONSTRAINT [PK_TipoInvestimento] PRIMARY KEY CLUSTERED 
(
	[TipoInvestimentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_TipoInvestimento_TipoInvestimentoID] UNIQUE NONCLUSTERED 
(
	[TipoInvestimentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Investimento]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Investimento](
	[InvestimentoID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[Apelido] [varchar](40) NOT NULL,
	[Descricao] [varchar](100) NOT NULL,
	[TipoInvestimentoID] [int] NOT NULL,
	[InstituicaoID] [int] NOT NULL,
	[MoedaID] [int] NOT NULL,
	[RiscoID] [int] NOT NULL,
	[Consulta] [varchar](25) NULL,
	[Ativo] [bit] NOT NULL,
	[DataInicio] [date] NULL,
	[Aplicacao] [varchar](5) NOT NULL,
	[Resgate] [varchar](5) NOT NULL,
	[Liquidacao] [varchar](5) NOT NULL,
	[CodigoAnbima] [varchar](6) NULL,
	[TaxaAdministracao] [numeric](10, 3) NOT NULL,
	[TaxaPerformance] [numeric](10, 3) NOT NULL,
	[InicialMinimo] [numeric](10, 2) NOT NULL,
	[MovimentoMinimo] [numeric](10, 2) NOT NULL,
	[SaldoMinimo] [numeric](10, 2) NOT NULL,
	[NovoID] [int] NULL,
 CONSTRAINT [Pk_Investimento] PRIMARY KEY CLUSTERED 
(
	[InvestimentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_Fundos]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Fundos]

AS

SELECT Invt.*
FROM Investimento Invt
INNER JOIN TipoInvestimento Tipo
ON Tipo.TipoInvestimentoID = Invt.TipoInvestimentoID
AND Tipo.Fundo = 1
AND Tipo.Acao = 0;
GO
/****** Object:  Table [dbo].[InvestimentoCotacao]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvestimentoCotacao](
	[InvestimentoCotacaoID] [int] IDENTITY(1,1) NOT NULL,
	[InvestimentoID] [int] NOT NULL,
	[Data] [date] NOT NULL,
	[VrCotacao] [numeric](18, 10) NULL,
	[CotacaoDaCVM] [bit] NOT NULL,
	[CotacaoDaBOVESPA] [bit] NOT NULL,
	[NovoID] [int] NULL,
 CONSTRAINT [Pk_InvestimentoCotacao] PRIMARY KEY CLUSTERED 
(
	[InvestimentoCotacaoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transacao]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transacao](
	[TransacaoID] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [int] NOT NULL,
	[Apelido] [varchar](25) NOT NULL,
	[Descricao] [varchar](100) NOT NULL,
	[CrdDeb] [char](1) NULL,
	[Fundo] [bit] NOT NULL,
	[Acao] [bit] NOT NULL,
 CONSTRAINT [Pk_Transacao] PRIMARY KEY CLUSTERED 
(
	[TransacaoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovimentoInvestimento]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimentoInvestimento](
	[MovimentoInvestimentoID] [int] IDENTITY(1,1) NOT NULL,
	[MovimentoContaID] [int] NOT NULL,
	[InvestimentoID] [int] NOT NULL,
	[TransacaoID] [int] NOT NULL,
	[InvestimentoCotacaoID] [int] NOT NULL,
	[QtCotas] [numeric](18, 10) NULL,
	[VrBruto] [numeric](18, 2) NOT NULL,
	[VrLiquido] [numeric](18, 2) NOT NULL,
	[SldCotas] [numeric](18, 10) NULL,
	[VrDespesa] [numeric](18, 2) NOT NULL,
 CONSTRAINT [Pk_MovimentoInvestimento] PRIMARY KEY CLUSTERED 
(
	[MovimentoInvestimentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovimentoConta]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimentoConta](
	[MovimentoContaID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[ContaID] [int] NOT NULL,
	[Data] [datetime] NOT NULL,
	[Numero] [varchar](15) NULL,
	[LancamentoID] [int] NOT NULL,
	[Descricao] [varchar](100) NULL,
	[CategoriaID] [int] NOT NULL,
	[GrupoCategoriaID] [int] NULL,
	[CrdDeb] [char](1) NOT NULL,
	[Credito] [numeric](22, 10) NULL,
	[Debito] [numeric](22, 10) NULL,
	[Balanco] [numeric](22, 10) NULL,
	[Conciliacao] [char](1) NOT NULL,
	[PilhaMovimentoContaID] [int] NULL,
	[DoMovimentoContaID] [int] NULL,
	[Sistema] [bit] NOT NULL,
	[PlanejamentoID] [int] NULL,
	[PlanejamentoRepeticao] [int] NULL,
	[Valor]  AS (coalesce([Credito],(0))-coalesce([Debito],(0))),
	[NovoID] [int] NULL,
 CONSTRAINT [PK_MovimentoConta] PRIMARY KEY CLUSTERED 
(
	[MovimentoContaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_MovimentoConta_MovimentoContaID] UNIQUE NONCLUSTERED 
(
	[MovimentoContaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CotacaoMoeda]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CotacaoMoeda](
	[CotacaoMoedaID] [int] IDENTITY(1,1) NOT NULL,
	[Data] [datetime] NOT NULL,
	[DeMoedaID] [int] NOT NULL,
	[Cotacao] [numeric](22, 10) NOT NULL,
	[ParaMoedaID] [int] NOT NULL,
	[Lowest] [numeric](22, 10) NULL,
	[Volume] [numeric](22, 10) NULL,
	[Amount] [numeric](22, 10) NULL,
	[AvgPrice] [numeric](22, 10) NULL,
	[Opening] [numeric](22, 10) NULL,
	[Closing] [numeric](22, 10) NULL,
	[Highest] [numeric](22, 10) NULL,
	[Quantity] [numeric](22, 10) NULL,
	[Negociado] [bit] NOT NULL,
	[MovimentoContaID] [int] NULL,
	[ContaIDTaxa] [int] NULL,
	[AliquotaTaxa] [numeric](10, 6) NULL,
	[UltimaCotacao] [bit] NOT NULL,
 CONSTRAINT [PK_CotacaoMoeda] PRIMARY KEY CLUSTERED 
(
	[CotacaoMoedaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovimentoContaLigacao]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimentoContaLigacao](
	[MovimentoContaID] [int] NOT NULL,
	[Passo] [tinyint] NOT NULL,
	[TradeHitBTCID] [bigint] NULL,
	[MovimentoInvestimentoID] [int] NULL,
 CONSTRAINT [PK_MovimentoContaLigacao] PRIMARY KEY CLUSTERED 
(
	[MovimentoContaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovimentoContaConciliacaoBancaria]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimentoContaConciliacaoBancaria](
	[MovimentoContaID] [int] NOT NULL,
	[Identificacao] [varchar](40) NOT NULL,
	[DataConciliacao] [datetime] NOT NULL,
 CONSTRAINT [Pk_MovimentoContaConciliacaoBancaria] PRIMARY KEY CLUSTERED 
(
	[MovimentoContaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_MovimentacaoConta]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vw_MovimentacaoConta]

AS

SELECT Mvto.MovimentoContaID, Mvto.UsuarioID, Mvto.ContaID, Mvto.Data, Mvto.Numero, Mvto.LancamentoID,
       Mvto.Descricao, Mvto.CategoriaID, Mvto.GrupoCategoriaID, Mvto.CrdDeb, Mvto.Credito, Mvto.Debito,
       Mvto.Valor, Mvto.Balanco, Mvto.Conciliacao, Mvto.PilhaMovimentoContaID, Mvto.DoMovimentoContaID,
       Mvto.Sistema, Invt.MovimentoInvestimentoID, Invt.InvestimentoID, Invt.TransacaoID, Trns.Apelido AS Transacao,
       Invt.InvestimentoCotacaoID, CtMd.CotacaoMoedaID, ABS(Invt.QtCotas) AS QtCotas, Invt.VrBruto, Invt.VrLiquido, 
       Invt.SldCotas, Invt.VrDespesa, Cota.VrCotacao, Mvto.PlanejamentoID, Mvto.PlanejamentoRepeticao, 
       Conc.Identificacao AS IdentificacaoOFX, COALESCE(MCLg.Passo, 0) Passo,
       CASE
           -- Se existe outro movimento com esse número sendo sua origem e não é um investimento:
           -- Marca como origem de transferência
           WHEN EXISTS(SELECT MovimentoContaID FROM MovimentoConta WHERE DoMovimentoContaID = Mvto.MovimentoContaID) AND Invt.MovimentoInvestimentoID IS NULL  THEN 1 
           -- Se tem número de origem e não é sistema:
           -- Marca como destino de transferência
           WHEN Mvto.DoMovimentoContaID IS NOT NULL AND Mvto.Sistema = 0 THEN 2
           -- Se é investimento
           WHEN Invt.MovimentoInvestimentoID IS NOT NULL THEN 3
           -- Se tem número de origem e é sistema
           WHEN Mvto.DoMovimentoContaID IS NOT NULL AND Mvto.Sistema = 1 THEN 4
           ELSE 0
       END + CASE WHEN Mvto.PlanejamentoID IS NOT NULL OR Orig.PlanejamentoID IS NOT NULL THEN 10 ELSE 0 END AS Legenda
FROM MovimentoConta Mvto
LEFT JOIN MovimentoInvestimento Invt ON Invt.MovimentoContaID = Mvto.MovimentoContaID
LEFT JOIN InvestimentoCotacao Cota ON Cota.Data = Mvto.Data AND Cota.InvestimentoID = Invt.InvestimentoID
LEFT JOIN Transacao Trns ON Trns.TransacaoID = Invt.TransacaoID
LEFT JOIN MovimentoConta Orig ON Orig.MovimentoContaID = Mvto.DoMovimentoContaID
LEFT JOIN MovimentoContaConciliacaoBancaria Conc ON Conc.MovimentoContaID = Mvto.MovimentoContaID
LEFT JOIN CotacaoMoeda CtMd ON CtMd.MovimentoContaID = Mvto.MovimentoContaID
LEFT JOIN MovimentoContaLigacao MCLg ON MCLg.MovimentoContaID = Mvto.MovimentoContaID
GO
/****** Object:  Table [dbo].[TickerHitBTC]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TickerHitBTC](
	[TickerID] [int] NOT NULL,
	[HitSymbol] [varchar](20) NOT NULL,
	[HitTimeStamp_Local] [datetime] NOT NULL,
	[HitTimeStamp_UTC] [datetime] NOT NULL,
	[HitAsk] [numeric](20, 10) NOT NULL,
	[HitBid] [numeric](20, 10) NOT NULL,
	[HitLast] [numeric](20, 10) NOT NULL,
	[HitOpen] [numeric](20, 10) NOT NULL,
	[HitLow] [numeric](20, 10) NOT NULL,
	[HitHigh] [numeric](20, 10) NOT NULL,
	[HitVolume] [numeric](20, 10) NOT NULL,
	[HitVolumeQuote] [numeric](20, 10) NOT NULL,
 CONSTRAINT [PK_TickerHitBTC] PRIMARY KEY CLUSTERED 
(
	[TickerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GrupoConta]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrupoConta](
	[GrupoContaID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[Apelido] [varchar](25) NOT NULL,
	[Descricao] [varchar](100) NOT NULL,
	[Ordem] [int] NOT NULL,
	[Ativo] [bit] NOT NULL,
	[Painel] [bit] NOT NULL,
	[FluxoDisponivel] [bit] NOT NULL,
	[FluxoCredito] [bit] NOT NULL,
 CONSTRAINT [PK_GrupoConta] PRIMARY KEY CLUSTERED 
(
	[GrupoContaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_GrupoConta_GrupoContaID] UNIQUE NONCLUSTERED 
(
	[GrupoContaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Moeda]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Moeda](
	[MoedaID] [int] IDENTITY(1,1) NOT NULL,
	[Apelido] [varchar](25) NOT NULL,
	[Simbolo] [varchar](10) NOT NULL,
	[Padrao] [bit] NOT NULL,
	[MercadoBitCoin] [bit] NOT NULL,
	[Virtual] [bit] NOT NULL,
	[PadraoVirtual] [bit] NOT NULL,
	[CodigoMoedaBancoCentral] [int] NULL,
	[Observacao] [varchar](50) NULL,
	[Eletronica] [varchar](10) NULL,
 CONSTRAINT [PK_Moeda] PRIMARY KEY CLUSTERED 
(
	[MoedaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Moeda_Apelido] UNIQUE NONCLUSTERED 
(
	[Apelido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Moeda_MoedaID] UNIQUE NONCLUSTERED 
(
	[MoedaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Moeda_Simbolo] UNIQUE NONCLUSTERED 
(
	[Simbolo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoedaEletronica]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoedaEletronica](
	[MoedaEletronicaID] [int] IDENTITY(1,1) NOT NULL,
	[MoedaID] [int] NOT NULL,
	[WebServiceID] [int] NOT NULL,
	[Simbolo] [varchar](20) NOT NULL,
	[SimboloWebService] [varchar](20) NOT NULL,
	[ParaMoedaID] [int] NOT NULL,
	[Padrao] [bit] NOT NULL,
 CONSTRAINT [PK_MoedaEletronica] PRIMARY KEY CLUSTERED 
(
	[MoedaEletronicaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoConta]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoConta](
	[TipoContaID] [int] IDENTITY(1,1) NOT NULL,
	[GrupoContaID] [int] NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[Apelido] [varchar](25) NOT NULL,
	[Descricao] [varchar](100) NOT NULL,
	[Ativo] [bit] NOT NULL,
	[Investimento] [bit] NOT NULL,
	[Cartao] [bit] NOT NULL,
	[Banco] [bit] NOT NULL,
	[Poupanca] [bit] NOT NULL,
	[Cambio] [bit] NOT NULL,
 CONSTRAINT [PK_TipoConta] PRIMARY KEY CLUSTERED 
(
	[TipoContaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_TipoConta_TipoContaID] UNIQUE NONCLUSTERED 
(
	[TipoContaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Conta]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conta](
	[ContaID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[InstituicaoID] [int] NOT NULL,
	[TipoContaID] [int] NOT NULL,
	[MoedaID] [int] NOT NULL,
	[Apelido] [varchar](40) NOT NULL,
	[Descricao] [varchar](100) NOT NULL,
	[DataAbertura] [datetime] NOT NULL,
	[SaldoInicial] [numeric](22, 10) NOT NULL,
	[Limite] [numeric](22, 10) NOT NULL,
	[Ativo] [bit] NOT NULL,
	[ExibirResumo] [bit] NOT NULL,
	[OFX] [bit] NOT NULL,
	[Decimais] [int] NOT NULL,
	[UsaHora] [bit] NOT NULL,
	[TipoArquivo] [varchar](25) NULL,
	[ExibirProjecao] [bit] NOT NULL,
	[CSV] [bit] NOT NULL,
 CONSTRAINT [PK_Conta] PRIMARY KEY CLUSTERED 
(
	[ContaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Conta_ContaID] UNIQUE NONCLUSTERED 
(
	[ContaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Risco]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Risco](
	[RiscoID] [int] IDENTITY(1,1) NOT NULL,
	[Apelido] [varchar](25) NOT NULL,
 CONSTRAINT [Pk_Risco] PRIMARY KEY CLUSTERED 
(
	[RiscoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_SaldoAplicacoes]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/**************************************************************
 SELECT * FROM vw_SaldoAplicacoes
 WHERE USUARIOID = 2 AND COALESCE(VrAplicado, 0) > 0
 **************************************************************/

CREATE VIEW [dbo].[vw_SaldoAplicacoes]

AS
WITH Profundidade01 AS (SELECT MoEl.MoedaID MoedaID_01, MoEl.ParaMoedaID MoedaID_02,
                               MoEl.SimboloWebService WebServiceSymbol_01, Para.Virtual,
                               MoEl.Padrao
                        FROM MoedaEletronica MoEl
                             JOIN Moeda Para ON Para.MoedaID = MoEl.ParaMoedaID
                        ),
     Profundidade02 AS (SELECT Pf_1.MoedaID_01, Pf_1.MoedaID_02, MoEl.ParaMoedaID MoedaID_03,
                               Pf_1.WebServiceSymbol_01, Pf_1.Padrao,
                               MoEl.SimboloWebService WebServiceSymbol_02
                        FROM Profundidade01 Pf_1
                             JOIN MoedaEletronica MoEl ON MoEl.MoedaID = Pf_1.MoedaID_02)

SELECT Ivst.UsuarioID, Ivst.InvestimentoID, Cnta.ContaID, Cnta.Apelido Conta,
       Ivst.Apelido, Tipo.Apelido AS Tipo, Tipo.Fundo, Tipo.Acao, Rsco.RiscoID, Rsco.Apelido AS Risco, SUM(COALESCE(Mvto.QtCotas, 0)) AS QtCotas, 
       Cota.VrCotacao, Cota.Data, CAST(NULL AS VARCHAR(10)) Simbolo,
       dbo.fncSaldoInvestimentoLiquido(Ivst.InvestimentoID, Cota.Data, 1) AS VrAplicado,
       1 AS Origem
FROM Investimento Ivst
     JOIN TipoInvestimento Tipo ON Tipo.TipoInvestimentoID = Ivst.TipoInvestimentoID
     JOIN Risco Rsco ON Rsco.RiscoID = Ivst.RiscoID
LEFT JOIN MovimentoInvestimento Mvto ON Mvto.InvestimentoID = Ivst.InvestimentoID
LEFT JOIN MovimentoConta MCta ON MCta.MovimentoContaID = Mvto.MovimentoContaID
LEFT JOIN Conta Cnta ON Cnta.ContaID = MCta.ContaID
LEFT JOIN InvestimentoCotacao Cota ON Cota.InvestimentoID = Ivst.InvestimentoID
                                  AND Cota.Data = (SELECT MAX(Data) 
                                                   FROM InvestimentoCotacao 
                                                   WHERE InvestimentoID = Ivst.InvestimentoID 
                                                   AND   Data <= GETDATE())
GROUP BY Ivst.UsuarioID, Ivst.InvestimentoID, Cnta.ContaID, Cnta.Apelido, Ivst.Apelido, Tipo.Apelido, Tipo.Fundo, Tipo.Acao, Rsco.RiscoID, Rsco.Apelido, Cota.Data, Cota.VrCotacao

UNION ALL

SELECT Cnta.UsuarioID, 0 AS InvestimentoID, Cnta.ContaID, Cnta.Apelido Conta, 
       Cnta.Apelido, 'Poupança' AS Tipo, CAST(0 AS BIT) Fundo, CAST(0 AS BIT) Acao, Rsco.RiscoID, Rsco.Apelido AS Risco, NULL AS QtCotas, 
       NULL AS VrCotacao, CAST(GETDATE() AS DATE) AS Data, CAST(NULL AS VARCHAR(10)) Simbolo, 
       SUM(Valor) AS VrAplicado,
       2 AS Origem
FROM Conta Cnta
     INNER JOIN TipoConta TCnt ON TCnt.TipoContaID = Cnta.TipoContaID AND TCnt.Poupanca = 1
     INNER JOIN MovimentoConta Mvto ON Mvto.ContaID = Cnta.ContaID AND Mvto.Data <= GETDATE()
     INNER JOIN Risco Rsco ON Rsco.RiscoID = 1
GROUP BY Cnta.UsuarioID, Cnta.ContaID, Cnta.Apelido, Rsco.RiscoID, Rsco.Apelido

UNION ALL

/********************************************
 Passa a incluir contas de câmbio na Carteira
 ********************************************/

 /* USD que precisa ser convertido em Real */

SELECT Cnta.UsuarioID, 0 AS InvestimentoID, Cnta.ContaID, Cnta.Apelido Conta,
       Cnta.Apelido, TCnt.Apelido AS Tipo, CAST(0 AS BIT) Fundo, CAST(0 AS BIT) Acao, Rsco.RiscoID, Rsco.Apelido AS Risco, 
       SUM(Mvto.Valor) AS QtCotas, 
       CotC.Cotacao AS VrCotacao, CAST(CotC.Data AS DATE), Moed.Simbolo,
       SUM(Mvto.Valor) * CotC.Cotacao AS VrAplicado,
       3 AS Origem
FROM Conta Cnta
     JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID
                    AND Moed.Virtual = 0
                    AND Moed.Padrao = 0
     JOIN Moeda Padr ON Padr.Padrao = 1
     JOIN TipoConta TCnt ON TCnt.TipoContaID = Cnta.TipoContaID AND TCnt.Cambio = 1
     JOIN MovimentoConta Mvto ON Mvto.ContaID = Cnta.ContaID AND Mvto.Data <= GETDATE()
     JOIN Risco Rsco ON Rsco.RiscoID = 5
LEFT JOIN CotacaoMoeda Cotc ON Cotc.DeMoedaID = Moed.MoedaID
                           AND Cotc.ParaMoedaID = Padr.MoedaID
                           AND Cotc.Data = (SELECT MAX(Data) 
                                            FROM CotacaoMoeda 
                                            WHERE DeMoedaID = Moed.MoedaID
                                            AND   ParaMoedaID = Padr.MoedaID
                                            AND   Data <= GETDATE())
GROUP BY Cnta.UsuarioID, Cnta.ContaID, Cnta.Apelido, TCnt.Apelido, Rsco.RiscoID, Rsco.Apelido, CotC.Cotacao, Moed.Simbolo, CAST(CotC.Data AS DATE)


UNION ALL

 /* BTC que precisa ser convertido em Dólar para depois ser convertido em Real */
SELECT Cnta.UsuarioID,
       0 AS InvestimentoID,
       Cnta.ContaID,
       Cnta.Apelido AS Conta,
       Cnta.Apelido,
       'Câmbio' Tipo,
       0 Fundo,
       0 Acao,
       Rsco.RiscoID,
       Rsco.Apelido Risco,
       CAST(SUM(Movt.Valor) AS NUMERIC(18,4)) AS QtCotas,
       THit.HitLast * CotC.Cotacao VrCotacao,
       CAST(CotC.Data AS DATE) Data,
       Moed.Simbolo,
       SUM(Movt.Valor) * THit.HitLast * CotC.Cotacao VrAplicado,
       4 Origem
FROM Conta Cnta
     JOIN Profundidade01 Pf_1 ON Pf_1.MoedaID_01 = Cnta.MoedaID
                             AND Pf_1.Virtual = 0
                             AND Pf_1.Padrao = 1
     JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
     JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID
     JOIN Moeda Padr ON Padr.Padrao = 1
     JOIN MovimentoConta Movt ON Movt.ContaID = Cnta.ContaID
     JOIN Risco Rsco ON Rsco.RiscoID = 5
LEFT JOIN TickerHitBTC THit ON THit.HitSymbol = Pf_1.WebServiceSymbol_01
                           AND THit.HitTimeStamp_Local = (SELECT MAX(HitTimeStamp_Local)
                                                          FROM TickerHitBTC
                                                          WHERE HitSymbol = Pf_1.WebServiceSymbol_01
                                                          AND   HitTimeStamp_Local <= GETDATE())
LEFT JOIN CotacaoMoeda Cotc ON Cotc.DeMoedaID = Pf_1.MoedaID_02
                           AND Cotc.ParaMoedaID = Padr.MoedaID
                           AND Cotc.Data = (SELECT MAX(Data) 
                                            FROM CotacaoMoeda 
                                            WHERE DeMoedaID = Pf_1.MoedaID_02
                                            AND   ParaMoedaID = Padr.MoedaID
                                            AND   Data <= GETDATE())
WHERE  Movt.Data <= GETDATE()
GROUP BY Cnta.UsuarioID, Cnta.ContaID, Cnta.Apelido, Rsco.RiscoID, Rsco.Apelido, THit.HitLast, Cotc.Cotacao, Cotc.Data, Moed.Simbolo, Pf_1.Padrao

UNION ALL

/* Moedas que precisam ser convertidas em BTC para ser convertida em Dólar para depois ser convertido em Real */
SELECT Cnta.UsuarioID,
       0 AS InvestimentoID,
       Cnta.ContaID,
       Cnta.Apelido AS Conta,
       Cnta.Apelido,
       'Câmbio' Tipo,
       0 Fundo,
       0 Acao,
       Rsco.RiscoID,
       Rsco.Apelido Risco,
       CAST(SUM(Movt.Valor) AS NUMERIC(18,4)) AS QtCotas,
       COALESCE(Hit1.HitLast, 0) * COALESCE(Hit2.HitLast, 0) * COALESCE(CotC.Cotacao, 0) VrCotacao,
       CAST(CotC.Data AS DATE) Data,
       Moed.Simbolo,
       SUM(Movt.Valor) * COALESCE(Hit1.HitLast, 0) * COALESCE(Hit2.HitLast, 0) * COALESCE(CotC.Cotacao, 0) VrAplicado,
       5 Origem
FROM Conta Cnta
     JOIN Profundidade02 Pf_2 ON Pf_2.MoedaID_01 = Cnta.MoedaID                             
     JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
     JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID
     JOIN Moeda Padr ON Padr.Padrao = 1
     JOIN MovimentoConta Movt ON Movt.ContaID = Cnta.ContaID
     JOIN Risco Rsco ON Rsco.RiscoID = 5
LEFT JOIN TickerHitBTC Hit1 ON Hit1.HitSymbol = Pf_2.WebServiceSymbol_01
                           AND Hit1.HitTimeStamp_Local = (SELECT MAX(HitTimeStamp_Local)
                                                          FROM TickerHitBTC
                                                          WHERE HitSymbol = Pf_2.WebServiceSymbol_01
                                                          AND   HitTimeStamp_Local <= GETDATE())
LEFT JOIN TickerHitBTC Hit2 ON Hit2.HitSymbol = Pf_2.WebServiceSymbol_02
                           AND Hit2.HitTimeStamp_Local = (SELECT MAX(HitTimeStamp_Local)
                                                          FROM TickerHitBTC
                                                          WHERE HitSymbol = Pf_2.WebServiceSymbol_02
                                                          AND   HitTimeStamp_Local <= GETDATE())
LEFT JOIN CotacaoMoeda Cotc ON Cotc.DeMoedaID = Pf_2.MoedaID_03
                           AND Cotc.ParaMoedaID = Padr.MoedaID
                           AND Cotc.Data = (SELECT MAX(Data) 
                                            FROM CotacaoMoeda 
                                            WHERE DeMoedaID = Pf_2.MoedaID_03
                                            AND   ParaMoedaID = Padr.MoedaID
                                            AND   Data <= GETDATE())
WHERE  Movt.Data <= GETDATE()
GROUP BY Grup.Ordem, Grup.Apelido, Cnta.ContaID, Cnta.UsuarioID, Cnta.Apelido, Grup.GrupoContaID, Cnta.MoedaID, 
         Cnta.TipoContaID, Rsco.RiscoID, Rsco.Apelido, CotC.Data, Moed.Simbolo, Tipo.Banco, Tipo.Poupanca, 
         Tipo.Cartao, Tipo.Investimento, Moed.Padrao, Hit1.HitLast, Hit2.HitLast, Cotc.Cotacao, 
         Cnta.ExibirResumo, Cnta.Decimais, Cnta.UsaHora, Cnta.OFX, Cnta.CSV, Cnta.Ativo, Pf_2.Padrao;
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[CategoriaID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NULL,
	[Apelido] [varchar](42) NOT NULL,
	[Descricao] [varchar](100) NULL,
	[CategoriaPaiID] [int] NULL,
	[GrupoCategoriaID] [int] NULL,
	[CrdDeb] [char](1) NOT NULL,
	[OrdemVisual] [int] NULL,
	[Fixo] [bit] NOT NULL,
	[Ativo] [bit] NOT NULL,
	[ContaID] [int] NULL,
	[Sistema] [bit] NOT NULL,
	[Automatico] [bit] NOT NULL,
	[Outros] [bit] NOT NULL,
	[NovoID] [int] NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[CategoriaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Categoria_CategoriaID] UNIQUE NONCLUSTERED 
(
	[CategoriaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GrupoCategoria]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrupoCategoria](
	[GrupoCategoriaID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NULL,
	[Apelido] [varchar](25) NOT NULL,
	[Descricao] [varchar](100) NULL,
	[Ativo] [bit] NOT NULL,
	[Automatico] [bit] NOT NULL,
	[Proporcao] [numeric](10, 2) NOT NULL,
	[NovoID] [int] NULL,
 CONSTRAINT [PK_Grupo] PRIMARY KEY CLUSTERED 
(
	[GrupoCategoriaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Grupo_Apelido] UNIQUE NONCLUSTERED 
(
	[Apelido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_GrupoCategoria_GrupoCategoriaID] UNIQUE NONCLUSTERED 
(
	[GrupoCategoriaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_Categoria]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_Categoria]

AS

SELECT
  Cate.CategoriaID, Cate.UsuarioID, Cate.Apelido, Cate.Descricao, 
  Cate.GrupoCategoriaID, Grup.Apelido AS GrupoCategoria, 
  Cate.CrdDeb, Cate.OrdemVisual, Cate.Fixo, Cate.Ativo, Cate.ContaID, Cate.Sistema,
  Cate.CategoriaPaiID, CPai.Apelido AS CategoriaPai, CAST(0 AS int) AS Nivel
FROM Categoria Cate
     LEFT JOIN Categoria CPai 
       ON CPai.CategoriaID = Cate.CategoriaPaiID
     LEFT JOIN GrupoCategoria Grup
       ON Grup.GrupoCategoriaID = Cate.GrupoCategoriaID
WHERE Cate.CategoriaPaiID IS NULL
UNION ALL
SELECT
  Cate.CategoriaID, Cate.UsuarioID, Cate.Apelido, Cate.Descricao, 
  Cate.GrupoCategoriaID, Grup.Apelido AS GrupoCategoria, 
  Cate.CrdDeb, Cate.OrdemVisual, Cate.Fixo, Cate.Ativo, Cate.ContaID, Cate.Sistema,
  Cate.CategoriaPaiID, CPai.Apelido AS CategoriaPai, CAST(1 AS int) AS Nivel
FROM Categoria Cate
     INNER JOIN Categoria CPai 
       ON CPai.CategoriaID = Cate.CategoriaPaiID 
       AND CPai.CategoriaPaiID IS NULL
     LEFT JOIN GrupoCategoria Grup
       ON Grup.GrupoCategoriaID = Cate.GrupoCategoriaID
WHERE Cate.CategoriaPaiID IS NOT NULL
UNION ALL
SELECT
  Cate.CategoriaID, Cate.UsuarioID, Cate.Apelido, Cate.Descricao, 
  Cate.GrupoCategoriaID, Grup.Apelido AS GrupoCategoria,
  Cate.CrdDeb, Cate.OrdemVisual, Cate.Fixo, Cate.Ativo, Cate.ContaID, Cate.Sistema,
  Cate.CategoriaPaiID, CPai.Apelido AS CategoriaPai, CAST(2 AS int) AS Nivel
FROM Categoria Cate
     INNER JOIN Categoria CPai 
       ON CPai.CategoriaID = Cate.CategoriaPaiID 
       AND CPai.CategoriaPaiID IS NOT NULL
     LEFT JOIN GrupoCategoria Grup
       ON Grup.GrupoCategoriaID = Cate.GrupoCategoriaID
WHERE Cate.CategoriaPaiID IS NOT NULL
GO
/****** Object:  View [dbo].[vw_CategoriaHieraquia]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_CategoriaHieraquia]

AS

SELECT 
    Cate.CategoriaID, Cate.UsuarioID, Cate.Apelido, CAST(NULL AS varchar(100)) AS Descricao, CAST(0 AS int) AS Nivel,
    Cate.GrupoCategoriaID, Cate.CrdDeb, Cate.OrdemVisual, Cate.Fixo, Cate.Ativo, Cate.ContaID, Cate.Sistema, Cate.CategoriaPaiID
FROM Categoria Cate
WHERE Cate.CategoriaPaiID IS NULL
UNION ALL
SELECT 
    Cate.CategoriaID, Cate.UsuarioID, CPai.Apelido + ':' +Cate.Apelido, CAST(NULL AS varchar(100)) AS Descricao, CAST(1 AS int) AS Nivel,
    Cate.GrupoCategoriaID, Cate.CrdDeb, Cate.OrdemVisual, Cate.Fixo, Cate.Ativo, Cate.ContaID, Cate.Sistema, Cate.CategoriaPaiID
FROM Categoria Cate
     INNER JOIN Categoria CPai
       ON CPai.CategoriaID = Cate.CategoriaPaiID
      AND CPai.CategoriaPaiID IS NULL
WHERE Cate.CategoriaPaiID IS NOT NULL
UNION ALL
SELECT 
    Cate.CategoriaID, Cate.UsuarioID, CAvo.Apelido + ':' + CPai.Apelido + ':' + Cate.Apelido, CAST(NULL AS varchar(100)) AS Descricao, CAST(2 AS int) AS Nivel,
    Cate.GrupoCategoriaID, Cate.CrdDeb, Cate.OrdemVisual, Cate.Fixo, Cate.Ativo, Cate.ContaID, Cate.Sistema, Cate.CategoriaPaiID
FROM Categoria Cate
     INNER JOIN Categoria CPai
       ON CPai.CategoriaID = Cate.CategoriaPaiID
     INNER JOIN Categoria CAvo
       ON CAvo.CategoriaID = CPai.CategoriaPaiID
WHERE Cate.CategoriaPaiID IS NOT NULL
GO
/****** Object:  View [dbo].[vw_TotalCarteira]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_TotalCarteira]

AS

SELECT Ivst.UsuarioID, CAST(SUM(COALESCE(Mvto.QtCotas, 0) * Cota.VrCotacao) AS NUMERIC(19,2)) AS VrTotalCarteira
FROM Investimento Ivst
     LEFT JOIN MovimentoInvestimento Mvto ON Mvto.InvestimentoID = Ivst.InvestimentoID
     LEFT JOIN InvestimentoCotacao Cota ON Cota.InvestimentoID = Ivst.InvestimentoID
      AND Cota.Data = (SELECT MAX(Data) FROM InvestimentoCotacao WHERE InvestimentoID = Ivst.InvestimentoID AND Data <= GETDATE())
GROUP BY Ivst.UsuarioID;
GO
/****** Object:  View [dbo].[vw_Carteira]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_Carteira]

AS

SELECT UsuarioID, InvestimentoID, Apelido, Conta, Tipo, Fundo, Acao, RiscoID, Risco, QtCotas, VrCotacao, Data, Simbolo, VrAplicado,
       CAST(VrAplicado / (SELECT SUM(Totl.VrAplicado) FROM vw_SaldoAplicacoes Totl WHERE Totl.UsuarioID = Sldo.UsuarioID) AS NUMERIC(18, 6)) AS PercCarteira
FROM vw_SaldoAplicacoes Sldo
GO
/****** Object:  View [dbo].[vw_CarteiraFormatada]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[vw_CarteiraFormatada]

AS

SELECT UsuarioID, InvestimentoID, Apelido, Conta,
       Tipo, Fundo, Acao, RiscoID, Risco, 
       QtCotas, 
       VrCotacao, Data, 
       Simbolo, VrAplicado, PercCarteira,
       CASE WHEN Simbolo IS NOT NULL THEN SIMBOLO + ' ' ELSE '' END + FORMAT(ABS(QtCotas), 'n6', 'pt-br') AS QtCotasFmt,
       CASE WHEN VrCotacao >= 0 THEN '' ELSE '-' END + 'R$ ' + FORMAT(ABS(VrCotacao), 'n6', 'pt-br') AS VrCotacaoFmt,
       CASE WHEN VrAplicado >= 0 THEN '' ELSE '-' END + 'R$ ' + FORMAT(ABS(VrAplicado), 'n2', 'pt-br') AS VrAplicadoFmt,
       FORMAT(PercCarteira * 100, 'n2', 'pt-br') + '%' AS PercFmt, CAST(1 AS INT) AS Detalhe
FROM vw_Carteira

UNION ALL

SELECT UsuarioID, CAST(NULL AS INT) AS InvestimentoID, CAST('Total da Carteira' AS VARCHAR(25)) AS Apelido, NULL Conta,
       CAST(NULL AS VARCHAR(25)) AS Tipo, 0 Fundo, 0 Acao, CAST(NULL AS INT) AS RiscoID, CAST(NULL AS VARCHAR(25)) AS Risco, 
       CAST(NULL AS NUMERIC(19,6)) AS QtCotas, CAST(NULL AS NUMERIC(19,6)) AS VrCotacao, CAST(NULL AS DATETIME) AS Data, 
       NULL AS Simbolo, SUM(VrAplicado) AS VrAplicado, SUM(PercCarteira) AS PercCarteira, 
       NULL AS QtCotasFmt,
       NULL AS VrCotacaoFmt,
       CASE WHEN SUM(VrAplicado) >= 0 THEN '' ELSE '-' END + 'R$ ' + FORMAT(ABS(SUM(VrAplicado)), 'n2', 'pt-br') AS VrAplicadoFmt,
       --CASE WHEN SUM(VrAplicado) >= 0 THEN '' ELSE '-' END + Simbolo + ' ' + FORMAT(ABS(SUM(VrAplicado)), 'n2', 'pt-br') AS VrAplicadoFmt,
       FORMAT(SUM(PercCarteira) * 100, 'n2', 'pt-br') + '%'  AS PercFmt, CAST(0 AS INT) AS Detalhe
FROM vw_Carteira
GROUP BY UsuarioID;
GO
/****** Object:  View [dbo].[vw_SaldoConta]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vw_SaldoConta]

AS

SELECT 
    Grup.Ordem,
    CAST(1 AS BIT)  AS Detalhe,
    Grup.Apelido AS Grupo,
    Cnta.ContaID,
    Cnta.UsuarioID,
    Cnta.Apelido AS Conta,
    Grup.GrupoContaID,
    Cnta.MoedaID,
    Cnta.TipoContaID,
    Moed.Simbolo AS Moeda,
    Tipo.Banco,
    Tipo.Poupanca,
    Tipo.Cartao,
    Tipo.Investimento,
    CAST(SUM(Movt.Valor) + dbo.fncTotalContaInvestimentoLiquido(Cnta.ContaID) AS NUMERIC(18,4)) AS Valor,
    Cnta.ExibirResumo,
	Cnta.Decimais,
	Cnta.UsaHora,
    Cnta.OFX,
    Cnta.Ativo
FROM Conta Cnta
     INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
     INNER JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     INNER JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID
     INNER JOIN MovimentoConta Movt ON Movt.ContaID = Cnta.ContaID
WHERE Movt.Data <= GETDATE()
GROUP BY Grup.Ordem, Grup.Apelido, Cnta.ContaID, Cnta.UsuarioID, Cnta.Apelido, Grup.GrupoContaID, Cnta.MoedaID, 
         Cnta.TipoContaID, Moed.Simbolo, Tipo.Banco, Tipo.Poupanca, Tipo.Cartao, Tipo.Investimento, 
		 Cnta.ExibirResumo, Cnta.Decimais, Cnta.UsaHora, Cnta.OFX, Cnta.Ativo;
GO
/****** Object:  View [dbo].[vw_ListaContas_V01_OLD]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE  VIEW [dbo].[vw_ListaContas_V01_OLD]

AS

SELECT DISTINCT
    Sald.Ordem,
    CAST(0 AS BIT) AS Detalhe,
    Grupo,
    CAST(NULL AS INT) AS UsuarioID,
    0 AS ContaID,
    CAST(0 AS BIT) AS Banco,
    CAST(0 AS BIT) AS Poupanca,
    CAST(0 AS BIT) AS Cartao,
    CAST(0 AS BIT) AS Investimento,
    Grup.Apelido AS Conta,
    Tipo.GrupoContaID,
    0 AS MoedaID,
    0 AS TipoContaID,
    Padr.Simbolo AS Moeda,
    CAST(SUM(Sald.Valor * Coalesce(Ctac.Cotacao, 1))  AS MONEY) AS Valor,
    CASE WHEN SUM(Sald.Valor * Coalesce(Ctac.Cotacao, 1)) < 0 THEN '-' ELSE '' END + Padr.Simbolo+' '+FORMAT(ABS(SUM(Sald.Valor * Coalesce(Ctac.Cotacao, 1))), 'n', 'pt-br') AS ValorFormatado,
    CAST(0 AS BIT) ExibirResumo,
	CAST(0 AS Int) Decimais,
	CAST(0 AS BIT) UsaHora,
    CAST(0 AS BIT) OFX,
    1 AS Ativo
FROM vw_SaldoConta Sald
     INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Sald.TipoContaID
     INNER JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     INNER JOIN Moeda Moed ON Moed.MoedaID = Sald.MoedaID
     INNER JOIN Moeda Padr ON Padr.Padrao = 1
     LEFT JOIN CotacaoMoeda Ctac 
       On Ctac.DeMoedaID = Sald.MoedaID 
      AND Ctac.ParaMoedaID = (SELECT MoedaID FROM Moeda WHERE Padrao = 1)
      AND Moed.Padrao = 0 
      AND Ctac.Data = (SELECT MAX(Data) FROM CotacaoMoeda WHERE DeMoedaID = Ctac.DeMoedaID AND Data <= GETDATE())
GROUP BY Sald.Ordem, Sald.Grupo, Grup.Apelido, Tipo.GrupoContaID, Padr.Simbolo

UNION ALL

SELECT
    Ordem,
    Detalhe,
    Grupo,
    UsuarioID,
    ContaID,
    Banco,
    Poupanca,
    Cartao,
    Investimento,
    Conta,
    GrupoContaID,
    MoedaID,
    TipoContaID,
    Moeda,
    Valor,
    CASE WHEN Valor < 0 THEN '-' ELSE '' END + Moeda+' '+FORMAT(ABS(Valor), 'n', 'pt-br') AS ValorFormatado,
    ExibirResumo,
	Decimais,
	UsaHora,
    OFX,
    Ativo
FROM vw_SaldoConta

UNION ALL

SELECT DISTINCT
    CAST(9999 AS INT) AS Ordem,
    CAST(0 AS BIT) AS Detalhe,
    'Total Geral' AS Grupo,
    CAST(NULL AS INT) AS UsuarioID,
    0 AS ContaID,
    CAST(0 AS BIT) AS Banco,
    CAST(0 AS BIT) AS Poupanca,
    CAST(0 AS BIT) AS Cartao,
    CAST(0 AS BIT) AS Investimento,
    'Total Geral' AS Conta,
    0 AS GrupoContaID,
    -1 AS MoedaID,
    0 AS TipoContaID,
    Padr.Simbolo AS Moeda,
    CAST(SUM(Sald.Valor * Coalesce(Ctac.Cotacao, 1))  AS MONEY) AS Valor,
    CASE WHEN SUM(Sald.Valor * Coalesce(Ctac.Cotacao, 1)) < 0 THEN '-' ELSE '' END + Padr.Simbolo+' '+FORMAT(ABS(SUM(Sald.Valor * Coalesce(Ctac.Cotacao, 1))), 'n', 'pt-br') AS ValorFormatado,
    CAST(0 AS BIT) ExibirResumo,
	CAST(0 AS Int) Decimais,
	CAST(0 AS BIT) UsaHora,
    CAST(0 AS BIT) OFX,
    1 AS Ativo
FROM vw_SaldoConta Sald
     INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Sald.TipoContaID
     INNER JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     INNER JOIN Moeda Moed ON Moed.MoedaID = Sald.MoedaID
     INNER JOIN Moeda Padr ON Padr.Padrao = 1
     LEFT JOIN CotacaoMoeda Ctac 
       On Ctac.DeMoedaID = Sald.MoedaID 
      AND Ctac.ParaMoedaID = (SELECT MoedaID FROM Moeda WHERE Padrao = 1)
      AND Moed.Padrao = 0 
      AND Ctac.Data = (SELECT MAX(Data) FROM CotacaoMoeda WHERE DeMoedaID = Ctac.DeMoedaID AND Data <= GETDATE())
GROUP BY Padr.Simbolo;
GO
/****** Object:  View [dbo].[vw_SaldoConta_Default]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_SaldoConta_Default]
AS
SELECT 
    Grup.Ordem,
    CAST(1 AS BIT)  AS Detalhe,
    Grup.Apelido AS Grupo,
    Cnta.ContaID,
    Cnta.UsuarioID,
    Cnta.Apelido AS Conta,
    Grup.GrupoContaID,
    Cnta.MoedaID,
    Cnta.TipoContaID,
    Moed.Simbolo AS Moeda,
    Tipo.Banco,
    Tipo.Poupanca,
    Tipo.Cartao,
    Tipo.Investimento,
    CAST(SUM(Movt.Valor) + dbo.fncTotalContaInvestimentoLiquido(Cnta.ContaID) AS NUMERIC(18,4)) AS ValorBase,
    COALESCE(CASE WHEN Moed.Padrao = 1 THEN 1 ELSE Cotc.Cotacao END, 0) Cotacao,
    Cnta.ExibirResumo,
	Cnta.Decimais,
	Cnta.UsaHora,
    Cnta.OFX,
    Cnta.CSV,
    Cnta.Ativo
FROM Conta Cnta
     JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
     JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID
     JOIN Moeda Padr ON Padr.Padrao = 1
     JOIN MovimentoConta Movt ON Movt.ContaID = Cnta.ContaID
LEFT JOIN CotacaoMoeda Cotc ON Cotc.DeMoedaID = Moed.MoedaID
                           AND Cotc.ParaMoedaID = Padr.MoedaID
                           AND Cotc.Data = (SELECT MAX(Data) 
                                            FROM CotacaoMoeda 
                                            WHERE DeMoedaID = Moed.MoedaID
                                            AND   ParaMoedaID = Padr.MoedaID
                                            AND   Data <= GETUTCDATE())
WHERE Movt.Data <= GETDATE()
GROUP BY Grup.Ordem, Grup.Apelido, Cnta.ContaID, Cnta.UsuarioID, Cnta.Apelido, Grup.GrupoContaID, Cnta.MoedaID, 
         Cnta.TipoContaID, Moed.Simbolo, Tipo.Banco, Tipo.Poupanca, Tipo.Cartao, Tipo.Investimento, Moed.Padrao,
         Cotc.Cotacao, Cnta.ExibirResumo, Cnta.Decimais, Cnta.UsaHora, Cnta.OFX, Cnta.CSV, Cnta.Ativo;
GO
/****** Object:  View [dbo].[vw_ListaContas_V02_OLD]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_ListaContas_V02_OLD]

AS

WITH Base AS (SELECT Ordem,
                     Detalhe,
                     Grupo,
                     UsuarioID,
                     ContaID,
                     Banco,
                     Poupanca,
                     Cartao,
                     Investimento,
                     Conta,
                     GrupoContaID,
                     Padr.MoedaID,
                     TipoContaID,
                     Moeda,
                     ROUND(ValorBase * Cotacao, 2, 1) Valor,
                     CASE WHEN ROUND(ValorBase * Cotacao, 2, 1) < 0 THEN '-' ELSE '' END + Padr.Simbolo +' '+FORMAT(ABS(ROUND(ValorBase * Cotacao, 2, 1)), 'n', 'pt-br') AS ValorFormatado,
                     ExibirResumo,
	                 Decimais,
	                 UsaHora,
                     OFX,
                     CSV,
                     Ativo
              FROM vw_SaldoConta_Default
                   JOIN Moeda Padr ON Padr.Padrao = 1
              WHERE Ativo = 1)
SELECT Base.Ordem, Base.Detalhe, Base.Grupo, Base.UsuarioID, Base.ContaID, Base.Banco, Base.Poupanca, Base.Cartao, 
       Base.Investimento, Base.Conta, Base.GrupoContaID, Base.MoedaID, Base.TipoContaID, Base.Moeda, Base.Valor, 
       Base.ValorFormatado, Base.ExibirResumo, Base.Decimais, Base.UsaHora, Base.OFX, Base.CSV, Base.Ativo
FROM Base

UNION ALL

SELECT DISTINCT
    Base.Ordem,
    CAST(0 AS BIT) AS Detalhe,
    Grupo,
    CAST(NULL AS INT) AS UsuarioID,
    0 AS ContaID,
    CAST(0 AS BIT) AS Banco,
    CAST(0 AS BIT) AS Poupanca,
    CAST(0 AS BIT) AS Cartao,
    CAST(0 AS BIT) AS Investimento,
    Grup.Apelido AS Conta,
    Tipo.GrupoContaID,
    0 AS MoedaID,
    0 AS TipoContaID,
    Padr.Simbolo AS Moeda,
    SUM(Base.Valor) Valor,
    CASE WHEN SUM(Base.Valor) < 0 THEN '-' ELSE '' END + Padr.Simbolo + ' ' + FORMAT(ABS(SUM(Base.Valor)), 'n', 'pt-br') ValorFormatado,
    CAST(0 AS BIT) ExibirResumo,
	CAST(0 AS Int) Decimais,
	CAST(0 AS BIT) UsaHora,
    CAST(0 AS BIT) OFX,
    CAST(0 AS BIT) CSV,
    MAX(CAST(Base.Ativo AS SMALLINT)) Ativo
FROM Base
     INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Base.TipoContaID
     INNER JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     INNER JOIN Moeda Padr ON Padr.Padrao = 1
WHERE Base.Ativo = 1
GROUP BY Base.Ordem, Base.Grupo, Grup.Apelido, Tipo.GrupoContaID, Padr.Simbolo

UNION ALL


SELECT DISTINCT
    CAST(9999 AS INT) AS Ordem,
    CAST(0 AS BIT) AS Detalhe,
    'Total Geral' AS Grupo,
    CAST(NULL AS INT) AS UsuarioID,
    0 AS ContaID,
    CAST(0 AS BIT) AS Banco,
    CAST(0 AS BIT) AS Poupanca,
    CAST(0 AS BIT) AS Cartao,
    CAST(0 AS BIT) AS Investimento,
    'Total Geral' AS Conta,
    0 AS GrupoContaID,
    -1 AS MoedaID,
    0 AS TipoContaID,
    Padr.Simbolo AS Moeda,
    CAST(SUM(Base.Valor) AS MONEY) AS Valor,
    CASE WHEN SUM(Base.Valor) < 0 THEN '-' ELSE '' END + Padr.Simbolo+' '+FORMAT(ABS(SUM(Base.Valor)), 'n', 'pt-br') AS ValorFormatado,
    CAST(0 AS BIT) ExibirResumo,
	CAST(0 AS Int) Decimais,
	CAST(0 AS BIT) UsaHora,
    CAST(0 AS BIT) OFX,
    CAST(0 AS BIT) CSV,
    1 AS Ativo
FROM Base
     INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Base.TipoContaID
     INNER JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     INNER JOIN Moeda Moed ON Moed.MoedaID = Base.MoedaID
     INNER JOIN Moeda Padr ON Padr.Padrao = 1
WHERE Base.Ativo = 1
GROUP BY Padr.Simbolo;
GO
/****** Object:  View [dbo].[vw_SaldoConta_V03]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_SaldoConta_V03]
AS

WITH Profundidade01 AS (SELECT MoEl.MoedaID MoedaID_01, MoEl.ParaMoedaID MoedaID_02,
                               MoEl.SimboloWebService WebServiceSymbol_01, Para.Virtual
                        FROM MoedaEletronica MoEl
                             JOIN Moeda Para ON Para.MoedaID = MoEl.ParaMoedaID
                        WHERE MoEl.Padrao = 1),
     Profundidade02 AS (SELECT Pf_1.MoedaID_01, Pf_1.MoedaID_02, MoEl.ParaMoedaID MoedaID_03,
                               Pf_1.WebServiceSymbol_01,
                               MoEl.SimboloWebService WebServiceSymbol_02
                        FROM Profundidade01 Pf_1
                             JOIN MoedaEletronica MoEl ON MoEl.MoedaID = Pf_1.MoedaID_02)
SELECT Grup.Ordem,
       CAST(1 AS BIT)  AS Detalhe,
       Grup.Apelido AS Grupo,
       Cnta.ContaID,
       Cnta.UsuarioID,
       Cnta.Apelido AS Conta,
       Grup.GrupoContaID,
       Cnta.MoedaID,
       Cnta.TipoContaID,
       Moed.Simbolo AS Moeda,
       Tipo.Banco,
       Tipo.Poupanca,
       Tipo.Cartao,
       Tipo.Investimento,
       CAST(SUM(Movt.Valor) + dbo.fncTotalContaInvestimentoLiquido(Cnta.ContaID) AS NUMERIC(18,8)) AS ValorBase,
       1 Fator01,
       1 Fator02,
       1 Fator03,
       1 Cotacao,
       Cnta.ExibirResumo,
	   Cnta.Decimais,
	   Cnta.UsaHora,
       Cnta.OFX,
       Cnta.CSV,
       Cnta.Ativo,
       CAST(1 AS TINYINT) Origem
FROM Conta Cnta
     JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
     JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID
                    AND Moed.Padrao = 1
     JOIN MovimentoConta Movt WITH(INDEX(IX_MovimentoConta_ContaID_Conciliacao_Data)) 
        ON Movt.ContaID = Cnta.ContaID
       AND Movt.Conciliacao NOT IN ('A', 'F')
WHERE Cnta.Ativo = 1
GROUP BY Grup.Ordem, Grup.Apelido, Cnta.ContaID, Cnta.UsuarioID, Cnta.Apelido, Grup.GrupoContaID, Cnta.MoedaID, 
         Cnta.TipoContaID, Moed.Simbolo, Tipo.Banco, Tipo.Poupanca, Tipo.Cartao, Tipo.Investimento, Moed.Padrao,
         Cnta.ExibirResumo, Cnta.Decimais, Cnta.UsaHora, Cnta.OFX, Cnta.CSV, Cnta.Ativo

UNION ALL

SELECT Grup.Ordem,
       CAST(1 AS BIT)  AS Detalhe,
       Grup.Apelido AS Grupo,
       Cnta.ContaID,
       Cnta.UsuarioID,
       Cnta.Apelido AS Conta,
       Grup.GrupoContaID,
       Cnta.MoedaID,
       Cnta.TipoContaID,
       Moed.Simbolo AS Moeda,
       Tipo.Banco,
       Tipo.Poupanca,
       Tipo.Cartao,
       Tipo.Investimento,
       CAST(SUM(Movt.Valor) + dbo.fncTotalContaInvestimentoLiquido(Cnta.ContaID) AS NUMERIC(18,8)) AS ValorBase,
       1 Fator01,
       1 Fator02,
       COALESCE(CASE WHEN Moed.Padrao = 1 THEN 1 ELSE Cotc.Cotacao END, 0) Fator03,
       COALESCE(CASE WHEN Moed.Padrao = 1 THEN 1 ELSE Cotc.Cotacao END, 0) Cotacao,
       Cnta.ExibirResumo,
	   Cnta.Decimais,
	   Cnta.UsaHora,
       Cnta.OFX,
       Cnta.CSV,
       Cnta.Ativo,
       CAST(2 AS TINYINT) Origem
FROM Conta Cnta
     JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
     JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID
                    AND Moed.Padrao = 0
                    AND Moed.Virtual = 0
     JOIN Moeda Padr ON Padr.Padrao = 1
     JOIN MovimentoConta Movt WITH(INDEX(IX_MovimentoConta_ContaID_Conciliacao_Data)) 
        ON Movt.ContaID = Cnta.ContaID
       AND Movt.Conciliacao NOT IN ('A', 'F')
LEFT JOIN CotacaoMoeda Cotc ON Cotc.DeMoedaID = Moed.MoedaID
                           AND Cotc.ParaMoedaID = Padr.MoedaID
                           AND Cotc.Data = (SELECT MAX(Data) 
                                            FROM CotacaoMoeda 
                                            WHERE DeMoedaID = Moed.MoedaID
                                            AND   ParaMoedaID = Padr.MoedaID
                                            AND   Data <= GETDATE())
WHERE Cnta.Ativo = 1
GROUP BY Grup.Ordem, Grup.Apelido, Cnta.ContaID, Cnta.UsuarioID, Cnta.Apelido, Grup.GrupoContaID, Cnta.MoedaID, 
         Cnta.TipoContaID, Moed.Simbolo, Tipo.Banco, Tipo.Poupanca, Tipo.Cartao, Tipo.Investimento, Moed.Padrao,
         Cotc.Cotacao, Cnta.ExibirResumo, Cnta.Decimais, Cnta.UsaHora, Cnta.OFX, Cnta.CSV, Cnta.Ativo

UNION ALL

SELECT Grup.Ordem,
       CAST(1 AS BIT)  AS Detalhe,
       Grup.Apelido AS Grupo,
       Cnta.ContaID,
       Cnta.UsuarioID,
       Cnta.Apelido AS Conta,
       Grup.GrupoContaID,
       Cnta.MoedaID,
       Cnta.TipoContaID,
       Moed.Simbolo AS Moeda,
       Tipo.Banco,
       Tipo.Poupanca,
       Tipo.Cartao,
       Tipo.Investimento,
       CAST(SUM(Movt.Valor) + dbo.fncTotalContaInvestimentoLiquido(Cnta.ContaID) AS NUMERIC(18,8)) AS ValorBase,
       1 Fator01,
       THit.HitLast Fator02,
       CotC.Cotacao Fator03,
       THit.HitLast * CotC.Cotacao Cotacao,
       Cnta.ExibirResumo,
	   Cnta.Decimais,
	   Cnta.UsaHora,
       Cnta.OFX,
       Cnta.CSV,
       Cnta.Ativo,
       CAST(3 AS TINYINT) Origem
FROM Conta Cnta
     JOIN Profundidade01 Pf_1 ON Pf_1.MoedaID_01 = Cnta.MoedaID
                             AND Pf_1.Virtual = 0
     JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
     JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID
     JOIN Moeda Padr ON Padr.Padrao = 1
     JOIN MovimentoConta Movt WITH(INDEX(IX_MovimentoConta_ContaID_Conciliacao_Data)) 
        ON Movt.ContaID = Cnta.ContaID
       AND Movt.Conciliacao NOT IN ('A', 'F')
LEFT JOIN TickerHitBTC THit ON THit.HitSymbol = Pf_1.WebServiceSymbol_01
                           AND THit.HitTimeStamp_Local = (SELECT MAX(HitTimeStamp_Local)
                                                          FROM TickerHitBTC
                                                          WHERE HitSymbol = Pf_1.WebServiceSymbol_01
                                                          AND   HitTimeStamp_Local <= GETDATE())
LEFT JOIN CotacaoMoeda Cotc ON Cotc.DeMoedaID = Pf_1.MoedaID_02
                           AND Cotc.ParaMoedaID = Padr.MoedaID
                           AND Cotc.Data = (SELECT MAX(Data) 
                                            FROM CotacaoMoeda 
                                            WHERE DeMoedaID = Pf_1.MoedaID_02
                                            AND   ParaMoedaID = Padr.MoedaID
                                            AND   Data <= GETDATE())
WHERE Cnta.Ativo = 1
GROUP BY Grup.Ordem, Grup.Apelido, Cnta.ContaID, Cnta.UsuarioID, Cnta.Apelido, Grup.GrupoContaID, Cnta.MoedaID, 
         Cnta.TipoContaID, Moed.Simbolo, Tipo.Banco, Tipo.Poupanca, Tipo.Cartao, Tipo.Investimento, Moed.Padrao,
         THit.HitLast, Cotc.Cotacao, Cnta.ExibirResumo, Cnta.Decimais, Cnta.UsaHora, Cnta.OFX, Cnta.CSV, Cnta.Ativo

UNION ALL

SELECT Grup.Ordem,
       CAST(1 AS BIT)  AS Detalhe,
       Grup.Apelido AS Grupo,
       Cnta.ContaID,
       Cnta.UsuarioID,
       Cnta.Apelido AS Conta,
       Grup.GrupoContaID,
       Cnta.MoedaID,
       Cnta.TipoContaID,
       Moed.Simbolo AS Moeda,
       Tipo.Banco,
       Tipo.Poupanca,
       Tipo.Cartao,
       Tipo.Investimento,
       COALESCE(CAST(SUM(Movt.Valor) + dbo.fncTotalContaInvestimentoLiquido(Cnta.ContaID) AS NUMERIC(18,8)), 0) AS ValorBase,
       COALESCE(Hit1.HitLast, 0) Fator01,
       COALESCE(Hit2.HitLast, 0) Fator02,
       COALESCE(CotC.Cotacao, 0) Fator03,
       COALESCE(Hit1.HitLast, 0) * COALESCE(Hit2.HitLast, 0) * COALESCE(CotC.Cotacao, 0) Cotacao,
       Cnta.ExibirResumo,
	   Cnta.Decimais,
	   Cnta.UsaHora,
       Cnta.OFX,
       Cnta.CSV,
       Cnta.Ativo,
       CAST(4 AS TINYINT) Origem
FROM Conta Cnta
     JOIN Profundidade02 Pf_2 ON Pf_2.MoedaID_01 = Cnta.MoedaID                             
     JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
     JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID
     JOIN Moeda Padr ON Padr.Padrao = 1
     JOIN MovimentoConta Movt WITH(INDEX(IX_MovimentoConta_ContaID_Conciliacao_Data)) 
        ON Movt.ContaID = Cnta.ContaID
       AND Movt.Conciliacao NOT IN ('A', 'F')
LEFT JOIN TickerHitBTC Hit1 ON Hit1.HitSymbol = Pf_2.WebServiceSymbol_01
                           AND Hit1.HitTimeStamp_Local = (SELECT MAX(HitTimeStamp_Local)
                                                          FROM TickerHitBTC
                                                          WHERE HitSymbol = Pf_2.WebServiceSymbol_01
                                                          AND   HitTimeStamp_Local <= GETDATE())
LEFT JOIN TickerHitBTC Hit2 ON Hit2.HitSymbol = Pf_2.WebServiceSymbol_02
                           AND Hit2.HitTimeStamp_Local = (SELECT MAX(HitTimeStamp_Local)
                                                          FROM TickerHitBTC
                                                          WHERE HitSymbol = Pf_2.WebServiceSymbol_02
                                                          AND   HitTimeStamp_Local <= GETDATE())
LEFT JOIN CotacaoMoeda Cotc ON Cotc.DeMoedaID = Pf_2.MoedaID_03
                           AND Cotc.ParaMoedaID = Padr.MoedaID
                           AND Cotc.Data = (SELECT MAX(Data) 
                                            FROM CotacaoMoeda 
                                            WHERE DeMoedaID = Pf_2.MoedaID_03
                                            AND   ParaMoedaID = Padr.MoedaID
                                            AND   Data <= GETDATE())
GROUP BY Grup.Ordem, Grup.Apelido, Cnta.ContaID, Cnta.UsuarioID, Cnta.Apelido, Grup.GrupoContaID, Cnta.MoedaID, 
         Cnta.TipoContaID, Moed.Simbolo, Tipo.Banco, Tipo.Poupanca, Tipo.Cartao, Tipo.Investimento, Moed.Padrao,
         Hit1.HitLast, Hit2.HitLast, Cotc.Cotacao, Cnta.ExibirResumo, Cnta.Decimais, Cnta.UsaHora, Cnta.OFX, Cnta.CSV, Cnta.Ativo;
GO
/****** Object:  View [dbo].[vw_ListaContas_V04]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vw_ListaContas_V04]
AS

WITH Base AS (SELECT Ordem,
                     Detalhe,
                     Grupo,
                     UsuarioID,
                     ContaID,
                     Banco,
                     Poupanca,
                     Cartao,
                     Investimento,
                     Conta,
                     GrupoContaID,
                     Padr.MoedaID,
                     TipoContaID,
                     Moeda,
                     ROUND(ValorBase * Cotacao, 2, 1) Valor,
                     CASE WHEN ROUND(ValorBase * Cotacao, 2, 1) < 0 THEN '-' ELSE '' END + Padr.Simbolo +' '+FORMAT(ABS(ROUND(ValorBase * Cotacao, 2, 1)), 'n', 'pt-br') AS ValorFormatado,
                     ExibirResumo,
	                 Decimais,
	                 UsaHora,
                     OFX,
                     CSV,
                     Ativo
              FROM vw_SaldoConta_V03
                   JOIN Moeda Padr ON Padr.Padrao = 1
              WHERE Ativo = 1 OR ROUND(ValorBase * Cotacao, 2, 1) <> 0)

SELECT Base.Ordem, Base.Detalhe, Base.Grupo, Base.UsuarioID, Base.ContaID, Base.Banco, Base.Poupanca, Base.Cartao, 
       Base.Investimento, Base.Conta, Base.GrupoContaID, Base.MoedaID, Base.TipoContaID, Base.Moeda, Base.Valor, 
       Base.ValorFormatado, Base.ExibirResumo, Base.Decimais, Base.UsaHora, Base.OFX, Base.CSV, Base.Ativo
FROM Base

UNION ALL

SELECT DISTINCT
    Base.Ordem,
    CAST(0 AS BIT) AS Detalhe,
    Grupo,
    CAST(NULL AS INT) AS UsuarioID,
    0 AS ContaID,
    CAST(0 AS BIT) AS Banco,
    CAST(0 AS BIT) AS Poupanca,
    CAST(0 AS BIT) AS Cartao,
    CAST(0 AS BIT) AS Investimento,
    Grup.Apelido AS Conta,
    Tipo.GrupoContaID,
    0 AS MoedaID,
    0 AS TipoContaID,
    Padr.Simbolo AS Moeda,
    SUM(Base.Valor) Valor,
    CASE WHEN SUM(Base.Valor) < 0 THEN '-' ELSE '' END + Padr.Simbolo + ' ' + FORMAT(ABS(SUM(Base.Valor)), 'n', 'pt-br') ValorFormatado,
    CAST(0 AS BIT) ExibirResumo,
	CAST(0 AS Int) Decimais,
	CAST(0 AS BIT) UsaHora,
    CAST(0 AS BIT) OFX,
    CAST(0 AS BIT) CSV,
    CAST(1 AS BIT) Ativo
    --MAX(CAST(Base.Ativo AS SMALLINT)) Ativo
FROM Base
     INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Base.TipoContaID
     INNER JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     INNER JOIN Moeda Padr ON Padr.Padrao = 1
GROUP BY Base.Ordem, Base.Grupo, Grup.Apelido, Tipo.GrupoContaID, Padr.Simbolo

UNION ALL

SELECT DISTINCT
    CAST(9999 AS INT) AS Ordem,
    CAST(0 AS BIT) AS Detalhe,
    'Total Geral' AS Grupo,
    CAST(NULL AS INT) AS UsuarioID,
    0 AS ContaID,
    CAST(0 AS BIT) AS Banco,
    CAST(0 AS BIT) AS Poupanca,
    CAST(0 AS BIT) AS Cartao,
    CAST(0 AS BIT) AS Investimento,
    'Total Geral' AS Conta,
    0 AS GrupoContaID,
    -1 AS MoedaID,
    0 AS TipoContaID,
    Padr.Simbolo AS Moeda,
    CAST(SUM(Base.Valor) AS MONEY) AS Valor,
    CASE WHEN SUM(Base.Valor) < 0 THEN '-' ELSE '' END + Padr.Simbolo+' '+FORMAT(ABS(SUM(Base.Valor)), 'n', 'pt-br') AS ValorFormatado,
    CAST(0 AS BIT) ExibirResumo,
	CAST(0 AS Int) Decimais,
	CAST(0 AS BIT) UsaHora,
    CAST(0 AS BIT) OFX,
    CAST(0 AS BIT) CSV,
    CAST(1 AS BIT) Ativo
FROM Base
     INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Base.TipoContaID
     INNER JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     INNER JOIN Moeda Moed ON Moed.MoedaID = Base.MoedaID
     INNER JOIN Moeda Padr ON Padr.Padrao = 1
GROUP BY Padr.Simbolo;
GO
/****** Object:  View [dbo].[vw_SaldoConta_V02_OLD]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vw_SaldoConta_V02_OLD]
AS

WITH Profundidade01 AS (SELECT MoEl.MoedaID MoedaID_01, MoEl.ParaMoedaID MoedaID_02,
                               MoEl.SimboloWebService WebServiceSymbol_01, Para.Virtual
                        FROM MoedaEletronica MoEl
                             JOIN Moeda Para ON Para.MoedaID = MoEl.ParaMoedaID
                        WHERE MoEl.Padrao = 1),
     Profundidade02 AS (SELECT Pf_1.MoedaID_01, Pf_1.MoedaID_02, MoEl.ParaMoedaID MoedaID_03,
                               Pf_1.WebServiceSymbol_01,
                               MoEl.SimboloWebService WebServiceSymbol_02
                        FROM Profundidade01 Pf_1
                             JOIN MoedaEletronica MoEl ON MoEl.MoedaID = Pf_1.MoedaID_02)
SELECT Grup.Ordem,
       CAST(1 AS BIT)  AS Detalhe,
       Grup.Apelido AS Grupo,
       Cnta.ContaID,
       Cnta.UsuarioID,
       Cnta.Apelido AS Conta,
       Grup.GrupoContaID,
       Cnta.MoedaID,
       Cnta.TipoContaID,
       Moed.Simbolo AS Moeda,
       Tipo.Banco,
       Tipo.Poupanca,
       Tipo.Cartao,
       Tipo.Investimento,
       CAST(SUM(Movt.Valor) + dbo.fncTotalContaInvestimentoLiquido(Cnta.ContaID) AS NUMERIC(18,8)) AS ValorBase,
       1 Fator01,
       1 Fator02,
       1 Fator03,
       1 Cotacao,
       Cnta.ExibirResumo,
	   Cnta.Decimais,
	   Cnta.UsaHora,
       Cnta.OFX,
       Cnta.CSV,
       Cnta.Ativo,
       CAST(1 AS TINYINT) Origem
FROM Conta Cnta
     JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
     JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID
                    AND Moed.Padrao = 1
     JOIN MovimentoConta Movt ON Movt.ContaID = Cnta.ContaID
WHERE Movt.Data <= GETDATE()
GROUP BY Grup.Ordem, Grup.Apelido, Cnta.ContaID, Cnta.UsuarioID, Cnta.Apelido, Grup.GrupoContaID, Cnta.MoedaID, 
         Cnta.TipoContaID, Moed.Simbolo, Tipo.Banco, Tipo.Poupanca, Tipo.Cartao, Tipo.Investimento, Moed.Padrao,
         Cnta.ExibirResumo, Cnta.Decimais, Cnta.UsaHora, Cnta.OFX, Cnta.CSV, Cnta.Ativo

UNION ALL

SELECT Grup.Ordem,
       CAST(1 AS BIT)  AS Detalhe,
       Grup.Apelido AS Grupo,
       Cnta.ContaID,
       Cnta.UsuarioID,
       Cnta.Apelido AS Conta,
       Grup.GrupoContaID,
       Cnta.MoedaID,
       Cnta.TipoContaID,
       Moed.Simbolo AS Moeda,
       Tipo.Banco,
       Tipo.Poupanca,
       Tipo.Cartao,
       Tipo.Investimento,
       CAST(SUM(Movt.Valor) + dbo.fncTotalContaInvestimentoLiquido(Cnta.ContaID) AS NUMERIC(18,8)) AS ValorBase,
       1 Fator01,
       1 Fator02,
       COALESCE(CASE WHEN Moed.Padrao = 1 THEN 1 ELSE Cotc.Cotacao END, 0) Fator03,
       COALESCE(CASE WHEN Moed.Padrao = 1 THEN 1 ELSE Cotc.Cotacao END, 0) Cotacao,
       Cnta.ExibirResumo,
	   Cnta.Decimais,
	   Cnta.UsaHora,
       Cnta.OFX,
       Cnta.CSV,
       Cnta.Ativo,
       CAST(2 AS TINYINT) Origem
FROM Conta Cnta
     JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
     JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID
                    AND Moed.Padrao = 0
                    AND Moed.Virtual = 0
     JOIN Moeda Padr ON Padr.Padrao = 1
     JOIN MovimentoConta Movt ON Movt.ContaID = Cnta.ContaID
LEFT JOIN CotacaoMoeda Cotc ON Cotc.DeMoedaID = Moed.MoedaID
                           AND Cotc.ParaMoedaID = Padr.MoedaID
                           AND Cotc.Data = (SELECT MAX(Data) 
                                            FROM CotacaoMoeda 
                                            WHERE DeMoedaID = Moed.MoedaID
                                            AND   ParaMoedaID = Padr.MoedaID
                                            AND   Data <= GETDATE())
WHERE Movt.Data <= GETDATE()
GROUP BY Grup.Ordem, Grup.Apelido, Cnta.ContaID, Cnta.UsuarioID, Cnta.Apelido, Grup.GrupoContaID, Cnta.MoedaID, 
         Cnta.TipoContaID, Moed.Simbolo, Tipo.Banco, Tipo.Poupanca, Tipo.Cartao, Tipo.Investimento, Moed.Padrao,
         Cotc.Cotacao, Cnta.ExibirResumo, Cnta.Decimais, Cnta.UsaHora, Cnta.OFX, Cnta.CSV, Cnta.Ativo

UNION ALL

SELECT Grup.Ordem,
       CAST(1 AS BIT)  AS Detalhe,
       Grup.Apelido AS Grupo,
       Cnta.ContaID,
       Cnta.UsuarioID,
       Cnta.Apelido AS Conta,
       Grup.GrupoContaID,
       Cnta.MoedaID,
       Cnta.TipoContaID,
       Moed.Simbolo AS Moeda,
       Tipo.Banco,
       Tipo.Poupanca,
       Tipo.Cartao,
       Tipo.Investimento,
       CAST(SUM(Movt.Valor) + dbo.fncTotalContaInvestimentoLiquido(Cnta.ContaID) AS NUMERIC(18,8)) AS ValorBase,
       1 Fator01,
       THit.HitLast Fator02,
       CotC.Cotacao Fator03,
       THit.HitLast * CotC.Cotacao Cotacao,
       Cnta.ExibirResumo,
	   Cnta.Decimais,
	   Cnta.UsaHora,
       Cnta.OFX,
       Cnta.CSV,
       Cnta.Ativo,
       CAST(3 AS TINYINT) Origem
FROM Conta Cnta
     JOIN Profundidade01 Pf_1 ON Pf_1.MoedaID_01 = Cnta.MoedaID
                             AND Pf_1.Virtual = 0
     JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
     JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID
     JOIN Moeda Padr ON Padr.Padrao = 1
     JOIN MovimentoConta Movt ON Movt.ContaID = Cnta.ContaID
LEFT JOIN TickerHitBTC THit ON THit.HitSymbol = Pf_1.WebServiceSymbol_01
                           AND THit.HitTimeStamp_Local = (SELECT MAX(HitTimeStamp_Local)
                                                          FROM TickerHitBTC
                                                          WHERE HitSymbol = Pf_1.WebServiceSymbol_01
                                                          AND   HitTimeStamp_Local <= GETDATE())
LEFT JOIN CotacaoMoeda Cotc ON Cotc.DeMoedaID = Pf_1.MoedaID_02
                           AND Cotc.ParaMoedaID = Padr.MoedaID
                           AND Cotc.Data = (SELECT MAX(Data) 
                                            FROM CotacaoMoeda 
                                            WHERE DeMoedaID = Pf_1.MoedaID_02
                                            AND   ParaMoedaID = Padr.MoedaID
                                            AND   Data <= GETDATE())
WHERE  Movt.Data <= GETDATE()
GROUP BY Grup.Ordem, Grup.Apelido, Cnta.ContaID, Cnta.UsuarioID, Cnta.Apelido, Grup.GrupoContaID, Cnta.MoedaID, 
         Cnta.TipoContaID, Moed.Simbolo, Tipo.Banco, Tipo.Poupanca, Tipo.Cartao, Tipo.Investimento, Moed.Padrao,
         THit.HitLast, Cotc.Cotacao, Cnta.ExibirResumo, Cnta.Decimais, Cnta.UsaHora, Cnta.OFX, Cnta.CSV, Cnta.Ativo

UNION ALL

SELECT Grup.Ordem,
       CAST(1 AS BIT)  AS Detalhe,
       Grup.Apelido AS Grupo,
       Cnta.ContaID,
       Cnta.UsuarioID,
       Cnta.Apelido AS Conta,
       Grup.GrupoContaID,
       Cnta.MoedaID,
       Cnta.TipoContaID,
       Moed.Simbolo AS Moeda,
       Tipo.Banco,
       Tipo.Poupanca,
       Tipo.Cartao,
       Tipo.Investimento,
       COALESCE(CAST(SUM(Movt.Valor) + dbo.fncTotalContaInvestimentoLiquido(Cnta.ContaID) AS NUMERIC(18,8)), 0) AS ValorBase,
       COALESCE(Hit1.HitLast, 0) Fator01,
       COALESCE(Hit2.HitLast, 0) Fator02,
       COALESCE(CotC.Cotacao, 0) Fator03,
       COALESCE(Hit1.HitLast, 0) * COALESCE(Hit2.HitLast, 0) * COALESCE(CotC.Cotacao, 0) Cotacao,
       Cnta.ExibirResumo,
	   Cnta.Decimais,
	   Cnta.UsaHora,
       Cnta.OFX,
       Cnta.CSV,
       Cnta.Ativo,
       CAST(4 AS TINYINT) Origem
FROM Conta Cnta
     JOIN Profundidade02 Pf_2 ON Pf_2.MoedaID_01 = Cnta.MoedaID                             
     JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
     JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID
     JOIN Moeda Padr ON Padr.Padrao = 1
     JOIN MovimentoConta Movt ON Movt.ContaID = Cnta.ContaID
LEFT JOIN TickerHitBTC Hit1 ON Hit1.HitSymbol = Pf_2.WebServiceSymbol_01
                           AND Hit1.HitTimeStamp_Local = (SELECT MAX(HitTimeStamp_Local)
                                                          FROM TickerHitBTC
                                                          WHERE HitSymbol = Pf_2.WebServiceSymbol_01
                                                          AND   HitTimeStamp_Local <= GETDATE())
LEFT JOIN TickerHitBTC Hit2 ON Hit2.HitSymbol = Pf_2.WebServiceSymbol_02
                           AND Hit2.HitTimeStamp_Local = (SELECT MAX(HitTimeStamp_Local)
                                                          FROM TickerHitBTC
                                                          WHERE HitSymbol = Pf_2.WebServiceSymbol_02
                                                          AND   HitTimeStamp_Local <= GETDATE())
LEFT JOIN CotacaoMoeda Cotc ON Cotc.DeMoedaID = Pf_2.MoedaID_03
                           AND Cotc.ParaMoedaID = Padr.MoedaID
                           AND Cotc.Data = (SELECT MAX(Data) 
                                            FROM CotacaoMoeda 
                                            WHERE DeMoedaID = Pf_2.MoedaID_03
                                            AND   ParaMoedaID = Padr.MoedaID
                                            AND   Data <= GETDATE())
WHERE  Movt.Data <= GETDATE()
GROUP BY Grup.Ordem, Grup.Apelido, Cnta.ContaID, Cnta.UsuarioID, Cnta.Apelido, Grup.GrupoContaID, Cnta.MoedaID, 
         Cnta.TipoContaID, Moed.Simbolo, Tipo.Banco, Tipo.Poupanca, Tipo.Cartao, Tipo.Investimento, Moed.Padrao,
         Hit1.HitLast, Hit2.HitLast, Cotc.Cotacao, Cnta.ExibirResumo, Cnta.Decimais, Cnta.UsaHora, Cnta.OFX, Cnta.CSV, Cnta.Ativo;
GO
/****** Object:  View [dbo].[vw_ListaContas_V03_OLD]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE   VIEW [dbo].[vw_ListaContas_V03_OLD]

AS

WITH Base AS (SELECT Ordem,
                     Detalhe,
                     Grupo,
                     UsuarioID,
                     ContaID,
                     Banco,
                     Poupanca,
                     Cartao,
                     Investimento,
                     Conta,
                     GrupoContaID,
                     Padr.MoedaID,
                     TipoContaID,
                     Moeda,
                     ROUND(ValorBase * Cotacao, 2, 1) Valor,
                     CASE WHEN ROUND(ValorBase * Cotacao, 2, 1) < 0 THEN '-' ELSE '' END + Padr.Simbolo +' '+FORMAT(ABS(ROUND(ValorBase * Cotacao, 2, 1)), 'n', 'pt-br') AS ValorFormatado,
                     ExibirResumo,
	                 Decimais,
	                 UsaHora,
                     OFX,
                     CSV,
                     Ativo
              FROM vw_SaldoConta_V02_OLD
                   JOIN Moeda Padr ON Padr.Padrao = 1
              WHERE Ativo = 1 OR ROUND(ValorBase * Cotacao, 2, 1) <> 0)
SELECT Base.Ordem, Base.Detalhe, Base.Grupo, Base.UsuarioID, Base.ContaID, Base.Banco, Base.Poupanca, Base.Cartao, 
       Base.Investimento, Base.Conta, Base.GrupoContaID, Base.MoedaID, Base.TipoContaID, Base.Moeda, Base.Valor, 
       Base.ValorFormatado, Base.ExibirResumo, Base.Decimais, Base.UsaHora, Base.OFX, Base.CSV, Base.Ativo
FROM Base

UNION ALL

SELECT DISTINCT
    Base.Ordem,
    CAST(0 AS BIT) AS Detalhe,
    Grupo,
    CAST(NULL AS INT) AS UsuarioID,
    0 AS ContaID,
    CAST(0 AS BIT) AS Banco,
    CAST(0 AS BIT) AS Poupanca,
    CAST(0 AS BIT) AS Cartao,
    CAST(0 AS BIT) AS Investimento,
    Grup.Apelido AS Conta,
    Tipo.GrupoContaID,
    0 AS MoedaID,
    0 AS TipoContaID,
    Padr.Simbolo AS Moeda,
    SUM(Base.Valor) Valor,
    CASE WHEN SUM(Base.Valor) < 0 THEN '-' ELSE '' END + Padr.Simbolo + ' ' + FORMAT(ABS(SUM(Base.Valor)), 'n', 'pt-br') ValorFormatado,
    CAST(0 AS BIT) ExibirResumo,
	CAST(0 AS Int) Decimais,
	CAST(0 AS BIT) UsaHora,
    CAST(0 AS BIT) OFX,
    CAST(0 AS BIT) CSV,
    MAX(CAST(Base.Ativo AS SMALLINT)) Ativo
FROM Base
     INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Base.TipoContaID
     INNER JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     INNER JOIN Moeda Padr ON Padr.Padrao = 1
GROUP BY Base.Ordem, Base.Grupo, Grup.Apelido, Tipo.GrupoContaID, Padr.Simbolo

UNION ALL

SELECT DISTINCT
    CAST(9999 AS INT) AS Ordem,
    CAST(0 AS BIT) AS Detalhe,
    'Total Geral' AS Grupo,
    CAST(NULL AS INT) AS UsuarioID,
    0 AS ContaID,
    CAST(0 AS BIT) AS Banco,
    CAST(0 AS BIT) AS Poupanca,
    CAST(0 AS BIT) AS Cartao,
    CAST(0 AS BIT) AS Investimento,
    'Total Geral' AS Conta,
    0 AS GrupoContaID,
    -1 AS MoedaID,
    0 AS TipoContaID,
    Padr.Simbolo AS Moeda,
    CAST(SUM(Base.Valor) AS MONEY) AS Valor,
    CASE WHEN SUM(Base.Valor) < 0 THEN '-' ELSE '' END + Padr.Simbolo+' '+FORMAT(ABS(SUM(Base.Valor)), 'n', 'pt-br') AS ValorFormatado,
    CAST(0 AS BIT) ExibirResumo,
	CAST(0 AS Int) Decimais,
	CAST(0 AS BIT) UsaHora,
    CAST(0 AS BIT) OFX,
    CAST(0 AS BIT) CSV,
    1 AS Ativo
FROM Base
     INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Base.TipoContaID
     INNER JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     INNER JOIN Moeda Moed ON Moed.MoedaID = Base.MoedaID
     INNER JOIN Moeda Padr ON Padr.Padrao = 1
GROUP BY Padr.Simbolo;
GO
/****** Object:  View [dbo].[vw_SaldoProjetado]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  view [dbo].[vw_SaldoProjetado]

AS

SELECT Grup.Ordem, Grup.GrupoContaID, Tipo.Apelido Tipo, Grup.Apelido Grupo, MCta.ContaID, Cnta.Apelido Conta,
       SUM(CASE WHEN MCta.Conciliacao NOT IN ('A', 'F') THEN COALESCE(MCta.Credito, 0) - COALESCE(MCta.Debito, 0) ELSE 0 END) SaldoAtual,
       SUM(CASE WHEN MCta.Conciliacao IN ('A', 'F') THEN COALESCE(MCta.Debito, 0) ELSE 0 END) * -1 DebitosFuturos,
       SUM(CASE WHEN MCta.Conciliacao IN ('A', 'F') THEN COALESCE(MCta.Credito, 0) ELSE 0 END) CreditosFuturos,
       SUM(COALESCE(MCta.Credito, 0) - COALESCE(MCta.Debito, 0)) SaldoPrevisto, MCta.UsuarioID
FROM MovimentoConta MCta
     JOIN Conta Cnta ON Cnta.ContaID = MCta.ContaID
                    AND Cnta.Ativo = 1
                    AND Cnta.ExibirProjecao = 1
     JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
     JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
GROUP BY Grup.Ordem, Grup.GrupoContaID, Tipo.Apelido, Grup.Apelido, MCta.ContaID, Cnta.Apelido, MCta.UsuarioID;
GO
/****** Object:  View [dbo].[vw_CarteiraFormatada_V01_OLD]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vw_CarteiraFormatada_V01_OLD]

AS

SELECT UsuarioID, InvestimentoID, Apelido, Conta,
       Tipo, Fundo, Acao, RiscoID, Risco, 
       QtCotas, VrCotacao, Data, 
       Simbolo, VrAplicado, PercCarteira,
       CASE WHEN VrCotacao >= 0 THEN '' ELSE '-' END + Simbolo + ' ' + FORMAT(ABS(VrCotacao), 'n6', 'pt-br') AS VrCotacaoFmt,
       CASE WHEN VrAplicado >= 0 THEN '' ELSE '-' END + Simbolo + ' ' + FORMAT(ABS(VrAplicado), 'n2', 'pt-br') AS VrAplicadoFmt,
       FORMAT(PercCarteira * 100, 'n2', 'pt-br') + '%' AS PercFmt, CAST(1 AS INT) AS Detalhe
FROM vw_Carteira

UNION ALL

SELECT UsuarioID, CAST(NULL AS INT) AS InvestimentoID, CAST('Total da Carteira' AS VARCHAR(25)) AS Apelido, NULL Conta,
       CAST(NULL AS VARCHAR(25)) AS Tipo, 0 Fundo, 0 Acao, CAST(NULL AS INT) AS RiscoID, CAST(NULL AS VARCHAR(25)) AS Risco, 
       CAST(NULL AS NUMERIC(19,6)) AS QtCotas, CAST(NULL AS NUMERIC(19,6)) AS VrCotacao, CAST(NULL AS DATETIME) AS Data, 
       NULL AS Simbolo, SUM(VrAplicado) AS VrAplicado, SUM(PercCarteira) AS PercCarteira, 
       NULL AS VrCotacaoFmt,
       CASE WHEN SUM(VrAplicado) >= 0 THEN '' ELSE '-' END + Simbolo + ' ' + FORMAT(ABS(SUM(VrAplicado)), 'n2', 'pt-br') AS VrAplicadoFmt,
       FORMAT(SUM(PercCarteira) * 100, 'n2', 'pt-br') + '%'  AS PercFmt, CAST(0 AS INT) AS Detalhe
FROM vw_Carteira
GROUP BY UsuarioID, Simbolo;
GO
/****** Object:  Table [dbo].[Lancamento]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lancamento](
	[LancamentoID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[Apelido] [varchar](40) NOT NULL,
	[Descricao] [varchar](100) NULL,
	[Ativo] [bit] NOT NULL,
	[Sistema] [bit] NOT NULL,
	[Automatico] [bit] NOT NULL,
	[NovoID] [int] NULL,
 CONSTRAINT [PK_Lancamento] PRIMARY KEY CLUSTERED 
(
	[LancamentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Lancamento_LancamentoID] UNIQUE NONCLUSTERED 
(
	[LancamentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Planejamento]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planejamento](
	[PlanejamentoID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[ContaID] [int] NOT NULL,
	[LancamentoID] [int] NOT NULL,
	[CategoriaID] [int] NOT NULL,
	[GrupoCategoriaID] [int] NULL,
	[Descricao] [varchar](100) NOT NULL,
	[CrdDeb] [char](1) NOT NULL,
	[Valor] [numeric](18, 4) NOT NULL,
	[Total] [bit] NOT NULL,
	[DtInicial] [date] NOT NULL,
	[Dia] [int] NOT NULL,
	[DiaFixo] [bit] NOT NULL,
	[AdiaSeNaoUtil] [int] NOT NULL,
	[DiferencaNaPrimeira] [bit] NOT NULL,
	[Repeticoes] [int] NOT NULL,
	[Processados] [int] NOT NULL,
	[Apelido] [varchar](100) NOT NULL,
	[ValorFixo] [bit] NOT NULL,
	[Ativo] [bit] NOT NULL,
	[UltimoDiaMes] [bit] NOT NULL,
	[Observacao] [varchar](240) NULL,
	[NovoID] [int] NULL,
 CONSTRAINT [Pk_Planejamento] PRIMARY KEY CLUSTERED 
(
	[PlanejamentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_CategoriasSelecionaveis]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vw_CategoriasSelecionaveis]

AS

SELECT CAT1.UsuarioID, CAT1.CategoriaID AS vCatMasterID, CAT1.CrdDeb AS vCrdDeb, CAT1.Apelido AS vOrdenador, CAST(NULL AS VARCHAR(50)) AS vFiltro, 0 AS vNivel,
      CAT1.CategoriaID, CAT1.Apelido, CAT1.Descricao, CAT1.CategoriaPaiID, CAT1.GrupoCategoriaID, CAT1.Ativo, CAT1.Sistema, COALESCE(CAT1.ContaID, -1) AS ContaID, CAT1.Fixo
FROM Categoria CAT1
WHERE CAT1.CategoriaPaiID IS NULL

UNION

SELECT CAT1.UsuarioID, CAT1.CategoriaID AS vCatMasterID, CAT1.CrdDeb AS vCrdDeb, CAT1.Apelido + ':' + CAT2.Apelido AS vOrdenador, CAST(CAT2.Apelido AS VARCHAR(50)) AS vFiltro, 1 AS vNivel,
       CAT2.CategoriaID, CAT2.Apelido, CAT2.Descricao, CAT2.CategoriaPaiID, CAT2.GrupoCategoriaID, CAT2.Ativo, CAT2.Sistema, COALESCE(CAT2.ContaID, -1) AS ContaID, CAT1.Fixo
FROM Categoria CAT2
     JOIN Categoria CAT1 ON CAT1.CategoriaID = CAT2.CategoriaPaiID 
WHERE CAT2.CategoriaPaiID IN (SELECT CategoriaID FROM Categoria WHERE CategoriaPaiID IS NULL)

UNION

SELECT CAT1.UsuarioID, CAT1.CategoriaID AS vCatMasterID, CAT1.CrdDeb AS vCrdDeb, CAT1.Apelido + ':' + CAT2.Apelido + ':' + CAT3.Apelido AS vOrdenador, CAST(CAT2.Apelido + ':' + CAT3.Apelido AS VARCHAR(50)) AS vFiltro, 2 AS vNivel,
       CAT3.CategoriaID, REPLICATE(' ', 6) + CAT3.Apelido, CAT3.Descricao, CAT3.CategoriaPaiID, CAT3.GrupoCategoriaID, CAT3.Ativo, CAT3.Sistema, COALESCE(CAT3.ContaID, -1) AS ContaID, CAT1.Fixo
FROM Categoria CAT3
     JOIN Categoria CAT2 ON CAT2.CategoriaID = CAT3.CategoriaPaiID 
     JOIN Categoria CAT1 ON CAT1.CategoriaID = CAT2.CategoriaPaiID
WHERE CAT3.CategoriaPaiID IN (SELECT CategoriaID FROM Categoria WHERE CategoriaPaiID in (SELECT CategoriaID FROM Categoria WHERE CategoriaPaiID IS NULL));
GO
/****** Object:  View [dbo].[vw_Planejamento]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_Planejamento]
AS
SELECT 
	Plnj.PlanejamentoID, Plnj.UsuarioID,
	Plnj.Descricao,	Plnj.Apelido,
	Plnj.ContaID, Cnta.Apelido AS Conta,
	Plnj.LancamentoID, Lnto.Apelido AS Lancamento,
	Plnj.CategoriaID, Ctgr.vFiltro AS Categoria,
	Plnj.GrupoCategoriaID, Grup.Apelido AS GrupoCategoria,
	Plnj.CrdDeb, Plnj.Valor, Plnj.Total, Plnj.ValorFixo,
	Plnj.DtInicial,	Plnj.Dia, Plnj.DiaFixo, Plnj.AdiaSeNaoUtil, 
	Plnj.DiferencaNaPrimeira, Plnj.Repeticoes, Plnj.Processados, 
    Plnj.Ativo, Plnj.UltimoDiaMes, Plnj.Observacao,
    CASE Plnj.DiaFixo WHEN 0 THEN 'Dia Útil' ELSE 'Dia Fixo' END AS TipoDia,
    CASE Plnj.Total WHEN 0 THEN 'Mensalidade' ELSE 'Valor Total' END AS TipoTotal,
    CASE WHEN Plnj.DiaFixo = 0 THEN '' ELSE CASE Plnj.AdiaSeNaoUtil WHEN 0 THEN 'Adianta' WHEN 1 THEN 'Adia' ELSE 'Fixo' END END AS SeNaoUtil,
    CASE WHEN Plnj.Total = 0 THEN '' WHEN Plnj.DiferencaNaPrimeira = 1 THEN 'Primeira' ELSE 'Última' END AS SeDiferenca
FROM Planejamento Plnj
	 INNER JOIN Conta Cnta ON Cnta.ContaID = Plnj.ContaID
	 INNER JOIN Lancamento Lnto ON Lnto.LancamentoID = Plnj.LancamentoID
	 INNER JOIN vw_CategoriasSelecionaveis Ctgr ON Ctgr.CategoriaID = Plnj.CategoriaID
	 LEFT JOIN GrupoCategoria Grup ON Grup.GrupoCategoriaID = Plnj.GrupoCategoriaID;
GO
/****** Object:  View [dbo].[vw_SaldoProjetado_Total]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_SaldoProjetado_Total]

AS

SELECT Ordem, 1 Nivel, NULL ContaID, 'Sub Total' Tipo, Grupo Descricao, SUM(SaldoAtual) SaldoAtual, SUM(DebitosFuturos) DebitosFuturos, SUM(CreditosFuturos) CreditosFuturos, SUM(SaldoPrevisto) SaldoPrevisto, UsuarioID
FROM vw_SaldoProjetado
GROUP BY Ordem, Grupo, UsuarioID

UNION

SELECT Ordem, 0 Nivel, ContaID, Tipo, Conta Descricao, SaldoAtual, DebitosFuturos, CreditosFuturos, SaldoPrevisto, UsuarioID
FROM vw_SaldoProjetado

UNION

SELECT 999 Ordem, 999 Nivel, NULL ContaID, 'Total Geral' Tipo, NULL Descricao, SUM(SaldoAtual) SaldoAtual, SUM(DebitosFuturos) DebitosFuturos, SUM(CreditosFuturos) CreditosFuturos, SUM(SaldoPrevisto) SaldoPrevisto, UsuarioID
FROM vw_SaldoProjetado
GROUP BY UsuarioID

---ORDER BY Ordem, Nivel, Descricao;
GO
/****** Object:  View [dbo].[vw_ListaContas_Default]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[vw_ListaContas_Default]

AS

SELECT DISTINCT
    Sald.Ordem,
    CAST(0 AS BIT) AS Detalhe,
    Grupo,
    CAST(NULL AS INT) AS UsuarioID,
    0 AS ContaID,
    CAST(0 AS BIT) AS Banco,
    CAST(0 AS BIT) AS Poupanca,
    CAST(0 AS BIT) AS Cartao,
    CAST(0 AS BIT) AS Investimento,
    Grup.Apelido AS Conta,
    Tipo.GrupoContaID,
    0 AS MoedaID,
    0 AS TipoContaID,
    Padr.Simbolo AS Moeda,
    SUM(Sald.ValorBase * Sald.Cotacao) Valor,
    CASE WHEN SUM(Sald.ValorBase * Sald.Cotacao) < 0 THEN '-' ELSE '' END + Padr.Simbolo + ' ' + FORMAT(ABS(SUM(Sald.ValorBase * Sald.Cotacao)), 'n', 'pt-br') ValorFormatado,
    CAST(0 AS BIT) ExibirResumo,
	CAST(0 AS Int) Decimais,
	CAST(0 AS BIT) UsaHora,
    CAST(0 AS BIT) OFX,
    CAST(0 AS BIT) CSV,
    MAX(CAST(Sald.Ativo AS SMALLINT)) Ativo
FROM vw_SaldoConta_Default Sald
     INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Sald.TipoContaID
     INNER JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     INNER JOIN Moeda Padr ON Padr.Padrao = 1
GROUP BY Sald.Ordem, Sald.Grupo, Grup.Apelido, Tipo.GrupoContaID, Padr.Simbolo

UNION ALL

SELECT
    Ordem,
    Detalhe,
    Grupo,
    UsuarioID,
    ContaID,
    Banco,
    Poupanca,
    Cartao,
    Investimento,
    Conta,
    GrupoContaID,
    Padr.MoedaID,
    TipoContaID,
    Moeda,
    ValorBase * Cotacao Valor,
    CASE WHEN (ValorBase * Cotacao) < 0 THEN '-' ELSE '' END + Padr.Simbolo +' '+FORMAT(ABS(ValorBase * Cotacao), 'n', 'pt-br') AS ValorFormatado,
    ExibirResumo,
	Decimais,
	UsaHora,
    OFX,
    CSV,
    Ativo
FROM vw_SaldoConta_Default
INNER JOIN Moeda Padr ON Padr.Padrao = 1
WHERE Ativo = 1

UNION ALL

SELECT DISTINCT
    CAST(9999 AS INT) AS Ordem,
    CAST(0 AS BIT) AS Detalhe,
    'Total Geral' AS Grupo,
    CAST(NULL AS INT) AS UsuarioID,
    0 AS ContaID,
    CAST(0 AS BIT) AS Banco,
    CAST(0 AS BIT) AS Poupanca,
    CAST(0 AS BIT) AS Cartao,
    CAST(0 AS BIT) AS Investimento,
    'Total Geral' AS Conta,
    0 AS GrupoContaID,
    -1 AS MoedaID,
    0 AS TipoContaID,
    Padr.Simbolo AS Moeda,
    CAST(SUM(Sald.ValorBase * Sald.Cotacao) AS MONEY) AS Valor,
    CASE WHEN SUM(Sald.ValorBase * Sald.Cotacao) < 0 THEN '-' ELSE '' END + Padr.Simbolo+' '+FORMAT(ABS(SUM(Sald.ValorBase * Sald.Cotacao)), 'n', 'pt-br') AS ValorFormatado,
    CAST(0 AS BIT) ExibirResumo,
	CAST(0 AS Int) Decimais,
	CAST(0 AS BIT) UsaHora,
    CAST(0 AS BIT) OFX,
    CAST(0 AS BIT) CSV,
    1 AS Ativo
FROM vw_SaldoConta_Default Sald
     INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Sald.TipoContaID
     INNER JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID
     INNER JOIN Moeda Moed ON Moed.MoedaID = Sald.MoedaID
     INNER JOIN Moeda Padr ON Padr.Padrao = 1
     --LEFT JOIN CotacaoMoeda Ctac 
     --  On Ctac.DeMoedaID = Sald.MoedaID 
     -- AND Ctac.ParaMoedaID = (SELECT MoedaID FROM Moeda WHERE Padrao = 1)
     -- AND Moed.Padrao = 0 
     -- AND Ctac.Data = (SELECT MAX(Data) FROM CotacaoMoeda WHERE DeMoedaID = Ctac.DeMoedaID AND Data <= GETDATE())
GROUP BY Padr.Simbolo;
GO
/****** Object:  Table [dbo].[AcaoCotacao]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcaoCotacao](
	[AcaoCotacaoID] [int] IDENTITY(1,1) NOT NULL,
	[InvestimentoID] [int] NOT NULL,
	[Codigo] [varchar](20) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Ibovespa] [varchar](10) NULL,
	[Data] [datetime] NULL,
	[Abertura] [decimal](8, 2) NULL,
	[Minimo] [decimal](8, 2) NULL,
	[Maximo] [decimal](8, 2) NULL,
	[Medio] [decimal](8, 2) NULL,
	[Ultimo] [decimal](8, 2) NULL,
	[Oscilacao] [decimal](8, 4) NULL,
 CONSTRAINT [Pk_Acao] PRIMARY KEY CLUSTERED 
(
	[AcaoCotacaoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AcessoWebService]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcessoWebService](
	[AcessoID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[Servico] [varchar](25) NOT NULL,
	[API] [varchar](32) NOT NULL,
	[Segredo] [varchar](32) NOT NULL,
	[Acessos] [int] NOT NULL,
	[UltimoAcesso] [datetime] NULL,
 CONSTRAINT [PK_AcessoWebService] PRIMARY KEY CLUSTERED 
(
	[AcessoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConfiguracaoPrincipal]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfiguracaoPrincipal](
	[ConfiguracaoID] [smallint] NOT NULL,
	[PanelEsquerdoWidth] [int] NOT NULL,
	[Contas_ExibeAtivas] [bit] NOT NULL,
	[Planejamento_ExibeAtivas] [bit] NOT NULL,
	[DiasPrevisaoSaldoNegativo] [int] NOT NULL,
	[NumeroEmContaBanco] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CotacaoCVM]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CotacaoCVM](
	[CotacaoCVMID] [int] NOT NULL,
	[CNPJ] [varchar](18) NOT NULL,
	[Data] [date] NOT NULL,
	[VrCotacao] [numeric](25, 10) NOT NULL,
	[VrTotalCarteira] [numeric](19, 4) NULL,
	[VrPatrimonioLiquido] [numeric](19, 4) NULL,
	[VrCaptacaoDia] [numeric](19, 4) NULL,
	[VrResgateDia] [numeric](19, 4) NULL,
	[NroCotistas] [int] NULL,
	[Atualizacoes] [int] NOT NULL,
	[DataAtualizacao] [date] NOT NULL,
 CONSTRAINT [Pk_CotacaoCVM] PRIMARY KEY CLUSTERED 
(
	[CotacaoCVMID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feriado]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feriado](
	[FeriadoID] [int] IDENTITY(1,1) NOT NULL,
	[Dia] [int] NOT NULL,
	[Mes] [int] NOT NULL,
	[Ano] [int] NULL,
	[Descricao] [varchar](50) NOT NULL,
 CONSTRAINT [Pk_Feriado] PRIMARY KEY CLUSTERED 
(
	[FeriadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Imposto]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Imposto](
	[ImpostoID] [int] IDENTITY(1,1) NOT NULL,
	[Apelido] [varchar](25) NOT NULL,
	[Descricao] [varchar](100) NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [Pk_Imposto] PRIMARY KEY CLUSTERED 
(
	[ImpostoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImpostoFaixa]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImpostoFaixa](
	[FaixaID] [int] IDENTITY(1,1) NOT NULL,
	[ImpostoID] [int] NOT NULL,
	[Dias] [int] NOT NULL,
	[Porcentagem] [numeric](6, 4) NOT NULL,
	[Apelido] [varchar](25) NOT NULL,
	[DiasDe] [int] NULL,
	[DiasAte] [int] NULL,
 CONSTRAINT [Pk_ImpostoFaixa] PRIMARY KEY CLUSTERED 
(
	[FaixaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instituicao]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instituicao](
	[InstituicaoID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[TipoInstituicaoID] [int] NOT NULL,
	[Apelido] [varchar](25) NOT NULL,
	[Descricao] [varchar](100) NOT NULL,
	[Banco] [int] NULL,
	[Ativo] [bit] NOT NULL,
	[HitBTC] [bit] NULL,
 CONSTRAINT [PK_Instituicao] PRIMARY KEY CLUSTERED 
(
	[InstituicaoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Instituicao_InstituicaoID] UNIQUE NONCLUSTERED 
(
	[InstituicaoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invCotacaoCVM]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invCotacaoCVM](
	[IdCotacaoCVM] [int] NOT NULL,
	[CNPJ] [varchar](18) NOT NULL,
	[Data] [date] NOT NULL,
	[VrCotacao] [numeric](25, 10) NOT NULL,
	[VrTotalCarteira] [numeric](19, 4) NULL,
	[VrPatrimonioLiquido] [numeric](19, 4) NULL,
	[VrCaptacaoDia] [numeric](19, 4) NULL,
	[VrResgateDia] [numeric](19, 4) NULL,
	[NroCotistas] [int] NULL,
	[Atualizacoes] [int] NOT NULL,
	[DataAtualizacao] [date] NOT NULL,
 CONSTRAINT [Pk_invCotacaoCVM] PRIMARY KEY CLUSTERED 
(
	[IdCotacaoCVM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvestimentoDespesa]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvestimentoDespesa](
	[InvestimentoDespesaID] [int] IDENTITY(1,1) NOT NULL,
	[InvestimentoID] [int] NOT NULL,
	[CategoriaID] [int] NOT NULL,
	[Descricao] [varchar](100) NULL,
	[Entrada] [bit] NOT NULL,
	[Saida] [bit] NOT NULL,
	[Ordem] [int] NOT NULL,
	[ImpostoID] [int] NULL,
	[IR] [bit] NOT NULL,
	[IOF] [bit] NOT NULL,
	[ComeCota] [bit] NOT NULL,
 CONSTRAINT [Pk_InvestimentoDespesa] PRIMARY KEY CLUSTERED 
(
	[InvestimentoDespesaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvestimentoVariacao]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvestimentoVariacao](
	[InvestimentoID] [int] NOT NULL,
	[Data] [date] NOT NULL,
	[ValorLiquido] [numeric](18, 8) NULL,
	[PercInvestimento] [numeric](18, 12) NULL,
 CONSTRAINT [Pk_InvestimentoVariacao] PRIMARY KEY CLUSTERED 
(
	[InvestimentoID] ASC,
	[Data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Melhoria]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Melhoria](
	[MelhoriaID] [int] IDENTITY(1,1) NOT NULL,
	[DtInclusao] [datetime] NOT NULL,
	[NivelID] [int] NOT NULL,
	[TipoID] [int] NOT NULL,
	[ModuloID] [int] NOT NULL,
	[Descricao] [varchar](500) NOT NULL,
	[DependenciaID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MelhoriaModulo]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MelhoriaModulo](
	[ModuloID] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MelhoriaModulo] PRIMARY KEY CLUSTERED 
(
	[ModuloID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MelhoriaNivel]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MelhoriaNivel](
	[NivelID] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](20) NOT NULL,
 CONSTRAINT [PK_MelhoriaNivel] PRIMARY KEY CLUSTERED 
(
	[NivelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MelhoriaTipo]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MelhoriaTipo](
	[TipoID] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](20) NOT NULL,
 CONSTRAINT [PK_MelhoriaTipo] PRIMARY KEY CLUSTERED 
(
	[TipoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MelhoriaVersao]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MelhoriaVersao](
	[VersaoID] [int] IDENTITY(1,1) NOT NULL,
	[Versao] [varchar](25) NOT NULL,
	[DtEntrega] [datetime] NOT NULL,
 CONSTRAINT [PK_MelhoriaVersao] PRIMARY KEY CLUSTERED 
(
	[VersaoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_MelhoriaVersao_Versao] UNIQUE NONCLUSTERED 
(
	[Versao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoneyPro]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoneyPro](
	[MoneyProID] [int] IDENTITY(1,1) NOT NULL,
	[BaseProducao] [bit] NOT NULL,
	[CMV_NomeSistemaCliente] [varchar](100) NULL,
	[CMV_CPFResponsavelSC] [varchar](14) NULL,
	[CMV_NomeResponsavelSC] [varchar](100) NULL,
	[CMV_IdentificacaoSC] [int] NULL,
	[CMV_SenhaSC] [varchar](10) NULL,
	[DtInicioUtilizacao] [datetime] NULL,
	[SiteCVM] [varchar](max) NULL,
	[CaminhoBackup] [varchar](2000) NULL,
	[UltimoBackup] [datetime] NULL,
	[SiteCVM_Lote] [varchar](250) NULL,
	[AtualizarTudo] [bit] NOT NULL,
	[AtualizacaoM02_M03] [date] NULL,
	[AtualizacaoM04_M11] [date] NULL,
 CONSTRAINT [Pk_Configuracao] PRIMARY KEY CLUSTERED 
(
	[MoneyProID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovimentoContaObservacao]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimentoContaObservacao](
	[MovimentoContaID] [int] NOT NULL,
	[Observacao] [varchar](250) NOT NULL,
 CONSTRAINT [PK_MovimentoContaObservacao] PRIMARY KEY CLUSTERED 
(
	[MovimentoContaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovimentoInvestimentoDespesa]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimentoInvestimentoDespesa](
	[MovimentoInvestimentoDespesaID] [int] IDENTITY(1,1) NOT NULL,
	[MovimentoInvestimentoID] [int] NOT NULL,
	[CategoriaID] [int] NOT NULL,
	[Ordem] [int] NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
 CONSTRAINT [Pk_MovimentoInvestimentoDespesa] PRIMARY KEY CLUSTERED 
(
	[MovimentoInvestimentoDespesaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Painel]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Painel](
	[PainelID] [int] NOT NULL,
	[Largura] [decimal](9, 2) NOT NULL,
	[Painel] [int] NOT NULL,
 CONSTRAINT [pk_Painel] PRIMARY KEY CLUSTERED 
(
	[PainelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoInstituicao]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoInstituicao](
	[TipoInstituicaoID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[Apelido] [varchar](25) NOT NULL,
	[Descricao] [varchar](100) NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_TipoInstituicao] PRIMARY KEY CLUSTERED 
(
	[TipoInstituicaoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_TipoInstituicao_TipoInstituicaoID] UNIQUE NONCLUSTERED 
(
	[TipoInstituicaoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TradeHitBTC]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TradeHitBTC](
	[TradeID] [bigint] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Instrument] [varchar](20) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[Side] [varchar](10) NOT NULL,
	[Quantity] [numeric](22, 12) NOT NULL,
	[Price] [numeric](22, 12) NOT NULL,
	[Volume] [numeric](22, 12) NOT NULL,
	[Fee] [numeric](22, 12) NOT NULL,
	[Rebate] [numeric](22, 12) NOT NULL,
	[Total] [numeric](22, 12) NOT NULL,
	[Principal] [varchar](10) NOT NULL,
	[Secundaria] [varchar](10) NOT NULL,
	[Executado] [bit] NOT NULL,
	[WebService] [bit] NOT NULL,
 CONSTRAINT [Pk_TradeHitBTC] PRIMARY KEY CLUSTERED 
(
	[TradeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[Apelido] [varchar](25) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Senha] [varchar](32) NOT NULL,
	[Email] [varchar](100) NULL,
	[Ativo] [bit] NOT NULL,
	[Sistema] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Usuario_Apelido] UNIQUE NONCLUSTERED 
(
	[Apelido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Usuario_UsuarioID] UNIQUE NONCLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WebService]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebService](
	[WebServiceID] [int] IDENTITY(1,1) NOT NULL,
	[Servico] [varchar](25) NOT NULL,
 CONSTRAINT [Pk_WebService] PRIMARY KEY CLUSTERED 
(
	[WebServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Ix_AcaoCotacao_01]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [Ix_AcaoCotacao_01] ON [dbo].[AcaoCotacao]
(
	[Codigo] ASC,
	[Data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Ix_AcaoCotacao_02]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [Ix_AcaoCotacao_02] ON [dbo].[AcaoCotacao]
(
	[InvestimentoID] ASC,
	[Data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_AcessoWebService_UsuarioID_Servico]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_AcessoWebService_UsuarioID_Servico] ON [dbo].[AcessoWebService]
(
	[UsuarioID] ASC,
	[Servico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Categoria_ContaID]    Script Date: 05/01/2022 12:59:40 ******/
CREATE NONCLUSTERED INDEX [IX_Categoria_ContaID] ON [dbo].[Categoria]
(
	[ContaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Categoria_UsuarioCategoriaPaiApelido]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Categoria_UsuarioCategoriaPaiApelido] ON [dbo].[Categoria]
(
	[UsuarioID] ASC,
	[CategoriaPaiID] ASC,
	[Apelido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Conta_Usuario_Apelido]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Conta_Usuario_Apelido] ON [dbo].[Conta]
(
	[UsuarioID] ASC,
	[Apelido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CotacaoMoeda_Data_DeMoedaID_ParaMoedaID]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_CotacaoMoeda_Data_DeMoedaID_ParaMoedaID] ON [dbo].[CotacaoMoeda]
(
	[Data] ASC,
	[DeMoedaID] ASC,
	[ParaMoedaID] ASC,
	[MovimentoContaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CotacaoMoeda_UltimaCotacao_DeMoedaID_ParaMoedaID_Data]    Script Date: 05/01/2022 12:59:40 ******/
CREATE NONCLUSTERED INDEX [IX_CotacaoMoeda_UltimaCotacao_DeMoedaID_ParaMoedaID_Data] ON [dbo].[CotacaoMoeda]
(
	[UltimaCotacao] ASC,
	[DeMoedaID] ASC,
	[ParaMoedaID] ASC,
	[Data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Ix_Feriado_01]    Script Date: 05/01/2022 12:59:40 ******/
CREATE NONCLUSTERED INDEX [Ix_Feriado_01] ON [dbo].[Feriado]
(
	[Dia] ASC,
	[Mes] ASC,
	[Ano] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_GrupoCategoria_Apelido]    Script Date: 05/01/2022 12:59:40 ******/
CREATE NONCLUSTERED INDEX [IX_GrupoCategoria_Apelido] ON [dbo].[GrupoCategoria]
(
	[Apelido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_GrupoConta_Usuario_Apelido]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_GrupoConta_Usuario_Apelido] ON [dbo].[GrupoConta]
(
	[UsuarioID] ASC,
	[Apelido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GrupoConta_Usuario_Ordem]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_GrupoConta_Usuario_Ordem] ON [dbo].[GrupoConta]
(
	[UsuarioID] ASC,
	[Ordem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Ix_Imposto_01]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [Ix_Imposto_01] ON [dbo].[Imposto]
(
	[Apelido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Ix_ImpostoFaixa_01]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [Ix_ImpostoFaixa_01] ON [dbo].[ImpostoFaixa]
(
	[ImpostoID] ASC,
	[Dias] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Instituicao_Usuario_Apelido]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Instituicao_Usuario_Apelido] ON [dbo].[Instituicao]
(
	[UsuarioID] ASC,
	[Apelido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Ix_Investimento_Usuario_Apelido]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [Ix_Investimento_Usuario_Apelido] ON [dbo].[Investimento]
(
	[UsuarioID] ASC,
	[Apelido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Ix_InvestimentoCotacao_01]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [Ix_InvestimentoCotacao_01] ON [dbo].[InvestimentoCotacao]
(
	[InvestimentoID] ASC,
	[Data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Ix_InvestimentoVariacao_01]    Script Date: 05/01/2022 12:59:40 ******/
CREATE NONCLUSTERED INDEX [Ix_InvestimentoVariacao_01] ON [dbo].[InvestimentoVariacao]
(
	[InvestimentoID] ASC,
	[Data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Lancamento_Usuario_Apelido]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Lancamento_Usuario_Apelido] ON [dbo].[Lancamento]
(
	[UsuarioID] ASC,
	[Apelido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Moeda_Apelido]    Script Date: 05/01/2022 12:59:40 ******/
CREATE NONCLUSTERED INDEX [IX_Moeda_Apelido] ON [dbo].[Moeda]
(
	[Apelido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Moeda_Simbolo]    Script Date: 05/01/2022 12:59:40 ******/
CREATE NONCLUSTERED INDEX [IX_Moeda_Simbolo] ON [dbo].[Moeda]
(
	[Simbolo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MovimentoConta_ContaID_Conciliacao_Data]    Script Date: 05/01/2022 12:59:40 ******/
CREATE NONCLUSTERED INDEX [IX_MovimentoConta_ContaID_Conciliacao_Data] ON [dbo].[MovimentoConta]
(
	[ContaID] ASC,
	[Conciliacao] ASC,
	[Data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MovimentoConta_ContaID_Data]    Script Date: 05/01/2022 12:59:40 ******/
CREATE NONCLUSTERED INDEX [IX_MovimentoConta_ContaID_Data] ON [dbo].[MovimentoConta]
(
	[ContaID] ASC,
	[Data] ASC,
	[MovimentoContaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Ix_MovimentoInvestimentoDespesa_01]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [Ix_MovimentoInvestimentoDespesa_01] ON [dbo].[MovimentoInvestimentoDespesa]
(
	[MovimentoInvestimentoID] ASC,
	[Ordem] ASC,
	[CategoriaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_TickerHitBTC_HitSymbol_HitTimeStamp_Local_TickerID]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_TickerHitBTC_HitSymbol_HitTimeStamp_Local_TickerID] ON [dbo].[TickerHitBTC]
(
	[HitSymbol] ASC,
	[HitTimeStamp_Local] ASC,
	[TickerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TipoConta_Usuario_Apelido]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TipoConta_Usuario_Apelido] ON [dbo].[TipoConta]
(
	[UsuarioID] ASC,
	[Apelido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TipoInstituicao_Usuario_Apelido]    Script Date: 05/01/2022 12:59:40 ******/
CREATE NONCLUSTERED INDEX [IX_TipoInstituicao_Usuario_Apelido] ON [dbo].[TipoInstituicao]
(
	[UsuarioID] ASC,
	[Apelido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TipoInvestimento_Usuario_Apelido]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TipoInvestimento_Usuario_Apelido] ON [dbo].[TipoInvestimento]
(
	[UsuarioID] ASC,
	[Apelido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_TradeHitBTC_INSTRUMENT_TRADEID]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_TradeHitBTC_INSTRUMENT_TRADEID] ON [dbo].[TradeHitBTC]
(
	[Instrument] ASC,
	[TradeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Usuario_Apelido]    Script Date: 05/01/2022 12:59:40 ******/
CREATE NONCLUSTERED INDEX [IX_Usuario_Apelido] ON [dbo].[Usuario]
(
	[Apelido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_WebService_Servico]    Script Date: 05/01/2022 12:59:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_WebService_Servico] ON [dbo].[WebService]
(
	[Servico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AcessoWebService] ADD  CONSTRAINT [Df_AcessoWebService_Utilizacoes]  DEFAULT ((0)) FOR [Acessos]
GO
ALTER TABLE [dbo].[Categoria] ADD  DEFAULT ((0)) FOR [Fixo]
GO
ALTER TABLE [dbo].[Categoria] ADD  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Categoria] ADD  CONSTRAINT [Df_Categoria_Automatico]  DEFAULT ((0)) FOR [Automatico]
GO
ALTER TABLE [dbo].[Categoria] ADD  CONSTRAINT [Categoria_Outros_Df]  DEFAULT ((0)) FOR [Outros]
GO
ALTER TABLE [dbo].[Categoria] ADD  CONSTRAINT [Df_Categoria_NovoID]  DEFAULT (NEXT VALUE FOR [seq_Categoria_NovoID]) FOR [NovoID]
GO
ALTER TABLE [dbo].[ConfiguracaoPrincipal] ADD  CONSTRAINT [ConfiguracaoPrincipal_Contas_ExibeAtivas_DF]  DEFAULT ((0)) FOR [Contas_ExibeAtivas]
GO
ALTER TABLE [dbo].[ConfiguracaoPrincipal] ADD  CONSTRAINT [ConfiguracaoPrincipal_Contas_Planejamento_ExibeAtivas_DF]  DEFAULT ((0)) FOR [Planejamento_ExibeAtivas]
GO
ALTER TABLE [dbo].[ConfiguracaoPrincipal] ADD  CONSTRAINT [Df_ConfiguracaoPrincipal_DiasPrevisaoSaldoNegativo]  DEFAULT ((15)) FOR [DiasPrevisaoSaldoNegativo]
GO
ALTER TABLE [dbo].[ConfiguracaoPrincipal] ADD  CONSTRAINT [Df_ConfiguracaoPrincipal_NumeroEmContaBanco]  DEFAULT ((1)) FOR [NumeroEmContaBanco]
GO
ALTER TABLE [dbo].[Conta] ADD  CONSTRAINT [Df_Conta_Ativo]  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Conta] ADD  CONSTRAINT [Df_Conta_ExibirResumo]  DEFAULT ((0)) FOR [ExibirResumo]
GO
ALTER TABLE [dbo].[Conta] ADD  CONSTRAINT [Df_Conta_OFX]  DEFAULT ((0)) FOR [OFX]
GO
ALTER TABLE [dbo].[Conta] ADD  CONSTRAINT [Df_Conta_Decimais]  DEFAULT ((2)) FOR [Decimais]
GO
ALTER TABLE [dbo].[Conta] ADD  CONSTRAINT [Df_Conta_UsaHora]  DEFAULT ((0)) FOR [UsaHora]
GO
ALTER TABLE [dbo].[Conta] ADD  CONSTRAINT [Df_Conta_TipoArquivo]  DEFAULT ('OFX') FOR [TipoArquivo]
GO
ALTER TABLE [dbo].[Conta] ADD  DEFAULT ((1)) FOR [ExibirProjecao]
GO
ALTER TABLE [dbo].[Conta] ADD  CONSTRAINT [Df_Conta_CSV]  DEFAULT ((0)) FOR [CSV]
GO
ALTER TABLE [dbo].[CotacaoCVM] ADD  CONSTRAINT [Df_CotacaoCVM]  DEFAULT ((0)) FOR [Atualizacoes]
GO
ALTER TABLE [dbo].[CotacaoMoeda] ADD  CONSTRAINT [Df_CotacaoMoeda_Negociado]  DEFAULT ((0)) FOR [Negociado]
GO
ALTER TABLE [dbo].[CotacaoMoeda] ADD  CONSTRAINT [DF_CotacaoMoeda_UltimaCotacao]  DEFAULT ((0)) FOR [UltimaCotacao]
GO
ALTER TABLE [dbo].[GrupoCategoria] ADD  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[GrupoCategoria] ADD  CONSTRAINT [Df_GrupoCategoria_Automatico]  DEFAULT ((0)) FOR [Automatico]
GO
ALTER TABLE [dbo].[GrupoCategoria] ADD  CONSTRAINT [Df_GrupoCategoria_Proporcao]  DEFAULT ((100)) FOR [Proporcao]
GO
ALTER TABLE [dbo].[GrupoCategoria] ADD  CONSTRAINT [Df_GrupoCategoria_NovoID]  DEFAULT (NEXT VALUE FOR [seq_GrupoCategoria_NovoID]) FOR [NovoID]
GO
ALTER TABLE [dbo].[GrupoConta] ADD  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[GrupoConta] ADD  CONSTRAINT [Df_GrupoConta_Painel]  DEFAULT ((1)) FOR [Painel]
GO
ALTER TABLE [dbo].[GrupoConta] ADD  CONSTRAINT [Df_GrupoConta_FluxoDisponivel]  DEFAULT ((0)) FOR [FluxoDisponivel]
GO
ALTER TABLE [dbo].[GrupoConta] ADD  CONSTRAINT [Df_GrupoConta_FluxoCredito]  DEFAULT ((0)) FOR [FluxoCredito]
GO
ALTER TABLE [dbo].[Imposto] ADD  CONSTRAINT [Df_Imposto_Ativo]  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Instituicao] ADD  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Instituicao] ADD  CONSTRAINT [DF_Instituicao_HitBTC]  DEFAULT ((0)) FOR [HitBTC]
GO
ALTER TABLE [dbo].[Investimento] ADD  CONSTRAINT [Df_Investimento_Ativo]  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Investimento] ADD  CONSTRAINT [Df_Investimento_Aplicacao]  DEFAULT ('D+0') FOR [Aplicacao]
GO
ALTER TABLE [dbo].[Investimento] ADD  CONSTRAINT [Df_Investimento_Resgate]  DEFAULT ('D+0') FOR [Resgate]
GO
ALTER TABLE [dbo].[Investimento] ADD  CONSTRAINT [Df_Investimento_Liquidacao]  DEFAULT ('D+0') FOR [Liquidacao]
GO
ALTER TABLE [dbo].[Investimento] ADD  CONSTRAINT [Df_Investimento_TaxaAdministracao]  DEFAULT ((0)) FOR [TaxaAdministracao]
GO
ALTER TABLE [dbo].[Investimento] ADD  CONSTRAINT [Df_Investimento_TaxaPerformance]  DEFAULT ((0)) FOR [TaxaPerformance]
GO
ALTER TABLE [dbo].[Investimento] ADD  CONSTRAINT [Df_Investimento_InicialMinimo]  DEFAULT ((0)) FOR [InicialMinimo]
GO
ALTER TABLE [dbo].[Investimento] ADD  CONSTRAINT [Df_Investimento_MovimentoMinimo]  DEFAULT ((0)) FOR [MovimentoMinimo]
GO
ALTER TABLE [dbo].[Investimento] ADD  CONSTRAINT [Df_Investimento_SaldoMinimo]  DEFAULT ((0)) FOR [SaldoMinimo]
GO
ALTER TABLE [dbo].[Investimento] ADD  CONSTRAINT [Df_Investimento_NovoID]  DEFAULT (NEXT VALUE FOR [seq_Investimento_NovoID]) FOR [NovoID]
GO
ALTER TABLE [dbo].[InvestimentoCotacao] ADD  CONSTRAINT [Df_InvestimentoCotacao_CotacaoDaCVM]  DEFAULT ((0)) FOR [CotacaoDaCVM]
GO
ALTER TABLE [dbo].[InvestimentoCotacao] ADD  CONSTRAINT [Df_InvestimentoCotacao_CotacaoDaBOVESPA]  DEFAULT ((0)) FOR [CotacaoDaBOVESPA]
GO
ALTER TABLE [dbo].[InvestimentoCotacao] ADD  CONSTRAINT [Df_InvestimentoCotacao_NovoID]  DEFAULT (NEXT VALUE FOR [seq_InvestimentoCotacao_NovoID]) FOR [NovoID]
GO
ALTER TABLE [dbo].[InvestimentoDespesa] ADD  CONSTRAINT [Df_InvestimentoDespesa_Entrada]  DEFAULT ((0)) FOR [Entrada]
GO
ALTER TABLE [dbo].[InvestimentoDespesa] ADD  CONSTRAINT [Df_InvestimentoDespesa_Saida]  DEFAULT ((1)) FOR [Saida]
GO
ALTER TABLE [dbo].[InvestimentoDespesa] ADD  CONSTRAINT [Df_InvestimentoDespesa_IR]  DEFAULT ((0)) FOR [IR]
GO
ALTER TABLE [dbo].[InvestimentoDespesa] ADD  CONSTRAINT [Df_InvestimentoDespesa_IOF]  DEFAULT ((0)) FOR [IOF]
GO
ALTER TABLE [dbo].[InvestimentoDespesa] ADD  CONSTRAINT [DF_InvestimentoDespesa_ComeCota]  DEFAULT ((0)) FOR [ComeCota]
GO
ALTER TABLE [dbo].[Lancamento] ADD  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Lancamento] ADD  DEFAULT ((0)) FOR [Sistema]
GO
ALTER TABLE [dbo].[Lancamento] ADD  CONSTRAINT [Df_Lancamento_Automatico]  DEFAULT ((0)) FOR [Automatico]
GO
ALTER TABLE [dbo].[Lancamento] ADD  CONSTRAINT [Df_Lancamento_NovoID]  DEFAULT (NEXT VALUE FOR [seq_Lancamento_NovoID]) FOR [NovoID]
GO
ALTER TABLE [dbo].[Moeda] ADD  DEFAULT ((0)) FOR [Padrao]
GO
ALTER TABLE [dbo].[Moeda] ADD  CONSTRAINT [Df_Moeda_MercadoBitCoin]  DEFAULT ((0)) FOR [MercadoBitCoin]
GO
ALTER TABLE [dbo].[Moeda] ADD  CONSTRAINT [Df_Moeda_Virtual]  DEFAULT ((0)) FOR [Virtual]
GO
ALTER TABLE [dbo].[Moeda] ADD  CONSTRAINT [Df_Moeda_PadraoVirtual]  DEFAULT ((0)) FOR [PadraoVirtual]
GO
ALTER TABLE [dbo].[MoedaEletronica] ADD  DEFAULT ((1)) FOR [Padrao]
GO
ALTER TABLE [dbo].[MoneyPro] ADD  DEFAULT ((1)) FOR [BaseProducao]
GO
ALTER TABLE [dbo].[MoneyPro] ADD  DEFAULT ((0)) FOR [AtualizarTudo]
GO
ALTER TABLE [dbo].[MovimentoConta] ADD  CONSTRAINT [Df_Movimento_Sistema]  DEFAULT ((0)) FOR [Sistema]
GO
ALTER TABLE [dbo].[MovimentoConta] ADD  CONSTRAINT [Df_MovimentoConta_NovoID]  DEFAULT (NEXT VALUE FOR [seq_MovimentoConta_NovoID]) FOR [NovoID]
GO
ALTER TABLE [dbo].[Planejamento] ADD  CONSTRAINT [Df_Planejamento_Total]  DEFAULT ((1)) FOR [Total]
GO
ALTER TABLE [dbo].[Planejamento] ADD  CONSTRAINT [Df_Planejamento_DiaFixo]  DEFAULT ((1)) FOR [DiaFixo]
GO
ALTER TABLE [dbo].[Planejamento] ADD  CONSTRAINT [Df_Planejamento_AdiaSeNaoUtil]  DEFAULT ((1)) FOR [AdiaSeNaoUtil]
GO
ALTER TABLE [dbo].[Planejamento] ADD  CONSTRAINT [Df_Planejamento_DiferencaNaPrimeira]  DEFAULT ((1)) FOR [DiferencaNaPrimeira]
GO
ALTER TABLE [dbo].[Planejamento] ADD  CONSTRAINT [Df_Planejamento_Processados]  DEFAULT ((0)) FOR [Processados]
GO
ALTER TABLE [dbo].[Planejamento] ADD  CONSTRAINT [Df_Planejamento_ValorFixo]  DEFAULT ((1)) FOR [ValorFixo]
GO
ALTER TABLE [dbo].[Planejamento] ADD  CONSTRAINT [Df_Planejamento_Ativo]  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Planejamento] ADD  CONSTRAINT [DF_Planejamento_UltimoDiaMes]  DEFAULT ((0)) FOR [UltimoDiaMes]
GO
ALTER TABLE [dbo].[Planejamento] ADD  CONSTRAINT [Df_Planejamento_NovoID]  DEFAULT (NEXT VALUE FOR [seq_Planejamento_NovoID]) FOR [NovoID]
GO
ALTER TABLE [dbo].[TickerHitBTC] ADD  CONSTRAINT [Df_TickerHitBTC_TickerID]  DEFAULT (NEXT VALUE FOR [TickerHitBTC_TickerID]) FOR [TickerID]
GO
ALTER TABLE [dbo].[TipoConta] ADD  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[TipoConta] ADD  CONSTRAINT [Df_TipoConta_Investimento]  DEFAULT ((0)) FOR [Investimento]
GO
ALTER TABLE [dbo].[TipoConta] ADD  CONSTRAINT [Df_TipoConta_Cartao]  DEFAULT ((0)) FOR [Cartao]
GO
ALTER TABLE [dbo].[TipoConta] ADD  CONSTRAINT [Df_TipoConta_Banco]  DEFAULT ((0)) FOR [Banco]
GO
ALTER TABLE [dbo].[TipoConta] ADD  CONSTRAINT [Df_TipoConta_Poupanca]  DEFAULT ((0)) FOR [Poupanca]
GO
ALTER TABLE [dbo].[TipoConta] ADD  CONSTRAINT [Df_TipoConta_Cambio]  DEFAULT ((0)) FOR [Cambio]
GO
ALTER TABLE [dbo].[TipoInstituicao] ADD  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[TipoInvestimento] ADD  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[TipoInvestimento] ADD  CONSTRAINT [Df_TipoInvestimento_Fundo]  DEFAULT ((0)) FOR [Fundo]
GO
ALTER TABLE [dbo].[TipoInvestimento] ADD  CONSTRAINT [Df_TipoInvestimento_Acao]  DEFAULT ((0)) FOR [Acao]
GO
ALTER TABLE [dbo].[TipoInvestimento] ADD  CONSTRAINT [Df_TipoInvestimento_ComeCota]  DEFAULT ((0)) FOR [ComeCota]
GO
ALTER TABLE [dbo].[TipoInvestimento] ADD  CONSTRAINT [Df_TipoInvestimento_NovoID]  DEFAULT (NEXT VALUE FOR [seq_TipoInvestimento_NovoID]) FOR [NovoID]
GO
ALTER TABLE [dbo].[TradeHitBTC] ADD  CONSTRAINT [Df_TradeHitBTC_Executado]  DEFAULT ((0)) FOR [Executado]
GO
ALTER TABLE [dbo].[TradeHitBTC] ADD  CONSTRAINT [DF_TradeHitBTC_WebService]  DEFAULT ((0)) FOR [WebService]
GO
ALTER TABLE [dbo].[Transacao] ADD  CONSTRAINT [Df_Transacao_Fundo]  DEFAULT ((0)) FOR [Fundo]
GO
ALTER TABLE [dbo].[Transacao] ADD  CONSTRAINT [Df_Transacao_Acao]  DEFAULT ((0)) FOR [Acao]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((0)) FOR [Sistema]
GO
ALTER TABLE [dbo].[AcaoCotacao]  WITH CHECK ADD  CONSTRAINT [Fk_Acao_Investimento] FOREIGN KEY([InvestimentoID])
REFERENCES [dbo].[Investimento] ([InvestimentoID])
GO
ALTER TABLE [dbo].[AcaoCotacao] CHECK CONSTRAINT [Fk_Acao_Investimento]
GO
ALTER TABLE [dbo].[AcessoWebService]  WITH CHECK ADD  CONSTRAINT [FK_AcessoWebService_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[AcessoWebService] CHECK CONSTRAINT [FK_AcessoWebService_UsuarioID]
GO
ALTER TABLE [dbo].[Categoria]  WITH NOCHECK ADD  CONSTRAINT [FK_Categoria_Categoria] FOREIGN KEY([CategoriaPaiID])
REFERENCES [dbo].[Categoria] ([CategoriaID])
GO
ALTER TABLE [dbo].[Categoria] CHECK CONSTRAINT [FK_Categoria_Categoria]
GO
ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD  CONSTRAINT [FK_Categoria_Conta] FOREIGN KEY([ContaID])
REFERENCES [dbo].[Conta] ([ContaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Categoria] CHECK CONSTRAINT [FK_Categoria_Conta]
GO
ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD  CONSTRAINT [FK_Categoria_GrupoCategoria] FOREIGN KEY([GrupoCategoriaID])
REFERENCES [dbo].[GrupoCategoria] ([GrupoCategoriaID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Categoria] CHECK CONSTRAINT [FK_Categoria_GrupoCategoria]
GO
ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD  CONSTRAINT [FK_Categoria_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Categoria] CHECK CONSTRAINT [FK_Categoria_Usuario]
GO
ALTER TABLE [dbo].[Conta]  WITH CHECK ADD  CONSTRAINT [FK_Conta_Instituicao] FOREIGN KEY([InstituicaoID])
REFERENCES [dbo].[Instituicao] ([InstituicaoID])
GO
ALTER TABLE [dbo].[Conta] CHECK CONSTRAINT [FK_Conta_Instituicao]
GO
ALTER TABLE [dbo].[Conta]  WITH CHECK ADD  CONSTRAINT [FK_Conta_Moeda] FOREIGN KEY([MoedaID])
REFERENCES [dbo].[Moeda] ([MoedaID])
GO
ALTER TABLE [dbo].[Conta] CHECK CONSTRAINT [FK_Conta_Moeda]
GO
ALTER TABLE [dbo].[Conta]  WITH CHECK ADD  CONSTRAINT [FK_Conta_TipoConta] FOREIGN KEY([TipoContaID])
REFERENCES [dbo].[TipoConta] ([TipoContaID])
GO
ALTER TABLE [dbo].[Conta] CHECK CONSTRAINT [FK_Conta_TipoConta]
GO
ALTER TABLE [dbo].[Conta]  WITH CHECK ADD  CONSTRAINT [FK_Conta_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[Conta] CHECK CONSTRAINT [FK_Conta_Usuario]
GO
ALTER TABLE [dbo].[CotacaoMoeda]  WITH CHECK ADD  CONSTRAINT [FK_Cotacao_Moeda_01] FOREIGN KEY([DeMoedaID])
REFERENCES [dbo].[Moeda] ([MoedaID])
GO
ALTER TABLE [dbo].[CotacaoMoeda] CHECK CONSTRAINT [FK_Cotacao_Moeda_01]
GO
ALTER TABLE [dbo].[CotacaoMoeda]  WITH CHECK ADD  CONSTRAINT [FK_Cotacao_Moeda_02] FOREIGN KEY([ParaMoedaID])
REFERENCES [dbo].[Moeda] ([MoedaID])
GO
ALTER TABLE [dbo].[CotacaoMoeda] CHECK CONSTRAINT [FK_Cotacao_Moeda_02]
GO
ALTER TABLE [dbo].[CotacaoMoeda]  WITH CHECK ADD  CONSTRAINT [Fk_CotacaoMoeda_Conta] FOREIGN KEY([ContaIDTaxa])
REFERENCES [dbo].[Conta] ([ContaID])
GO
ALTER TABLE [dbo].[CotacaoMoeda] CHECK CONSTRAINT [Fk_CotacaoMoeda_Conta]
GO
ALTER TABLE [dbo].[CotacaoMoeda]  WITH CHECK ADD  CONSTRAINT [FK_CotacaoMoeda_MovimentoContaID] FOREIGN KEY([MovimentoContaID])
REFERENCES [dbo].[MovimentoConta] ([MovimentoContaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CotacaoMoeda] CHECK CONSTRAINT [FK_CotacaoMoeda_MovimentoContaID]
GO
ALTER TABLE [dbo].[GrupoCategoria]  WITH NOCHECK ADD  CONSTRAINT [FK_GrupoCategoria_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[GrupoCategoria] CHECK CONSTRAINT [FK_GrupoCategoria_Usuario]
GO
ALTER TABLE [dbo].[GrupoConta]  WITH CHECK ADD  CONSTRAINT [FK_GrupoConta_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[GrupoConta] CHECK CONSTRAINT [FK_GrupoConta_Usuario]
GO
ALTER TABLE [dbo].[ImpostoFaixa]  WITH CHECK ADD  CONSTRAINT [Fk_ImpostoFaixa_Imposto] FOREIGN KEY([ImpostoID])
REFERENCES [dbo].[Imposto] ([ImpostoID])
GO
ALTER TABLE [dbo].[ImpostoFaixa] CHECK CONSTRAINT [Fk_ImpostoFaixa_Imposto]
GO
ALTER TABLE [dbo].[Instituicao]  WITH CHECK ADD  CONSTRAINT [FK_Instituicao_TipoInstituicao] FOREIGN KEY([TipoInstituicaoID])
REFERENCES [dbo].[TipoInstituicao] ([TipoInstituicaoID])
GO
ALTER TABLE [dbo].[Instituicao] CHECK CONSTRAINT [FK_Instituicao_TipoInstituicao]
GO
ALTER TABLE [dbo].[Instituicao]  WITH CHECK ADD  CONSTRAINT [FK_Instituicao_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[Instituicao] CHECK CONSTRAINT [FK_Instituicao_Usuario]
GO
ALTER TABLE [dbo].[Investimento]  WITH CHECK ADD  CONSTRAINT [Fk_Investimento_Instituicao] FOREIGN KEY([InstituicaoID])
REFERENCES [dbo].[Instituicao] ([InstituicaoID])
GO
ALTER TABLE [dbo].[Investimento] CHECK CONSTRAINT [Fk_Investimento_Instituicao]
GO
ALTER TABLE [dbo].[Investimento]  WITH CHECK ADD  CONSTRAINT [Fk_Investimento_Moeda] FOREIGN KEY([MoedaID])
REFERENCES [dbo].[Moeda] ([MoedaID])
GO
ALTER TABLE [dbo].[Investimento] CHECK CONSTRAINT [Fk_Investimento_Moeda]
GO
ALTER TABLE [dbo].[Investimento]  WITH CHECK ADD  CONSTRAINT [Fk_Investimento_Risco] FOREIGN KEY([RiscoID])
REFERENCES [dbo].[Risco] ([RiscoID])
GO
ALTER TABLE [dbo].[Investimento] CHECK CONSTRAINT [Fk_Investimento_Risco]
GO
ALTER TABLE [dbo].[Investimento]  WITH CHECK ADD  CONSTRAINT [Fk_Investimento_TipoInvestimento] FOREIGN KEY([TipoInvestimentoID])
REFERENCES [dbo].[TipoInvestimento] ([TipoInvestimentoID])
GO
ALTER TABLE [dbo].[Investimento] CHECK CONSTRAINT [Fk_Investimento_TipoInvestimento]
GO
ALTER TABLE [dbo].[Investimento]  WITH CHECK ADD  CONSTRAINT [Fk_Investimento_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[Investimento] CHECK CONSTRAINT [Fk_Investimento_Usuario]
GO
ALTER TABLE [dbo].[InvestimentoCotacao]  WITH CHECK ADD  CONSTRAINT [Fk_InvestimentoCotacao_Investimento] FOREIGN KEY([InvestimentoID])
REFERENCES [dbo].[Investimento] ([InvestimentoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvestimentoCotacao] CHECK CONSTRAINT [Fk_InvestimentoCotacao_Investimento]
GO
ALTER TABLE [dbo].[InvestimentoDespesa]  WITH CHECK ADD  CONSTRAINT [Fk_InvestimentoDespesa_Categoria] FOREIGN KEY([CategoriaID])
REFERENCES [dbo].[Categoria] ([CategoriaID])
GO
ALTER TABLE [dbo].[InvestimentoDespesa] CHECK CONSTRAINT [Fk_InvestimentoDespesa_Categoria]
GO
ALTER TABLE [dbo].[InvestimentoDespesa]  WITH CHECK ADD  CONSTRAINT [Fk_InvestimentoDespesa_ImpostoID] FOREIGN KEY([ImpostoID])
REFERENCES [dbo].[Imposto] ([ImpostoID])
GO
ALTER TABLE [dbo].[InvestimentoDespesa] CHECK CONSTRAINT [Fk_InvestimentoDespesa_ImpostoID]
GO
ALTER TABLE [dbo].[InvestimentoDespesa]  WITH CHECK ADD  CONSTRAINT [Fk_InvestimentoDespesa_Investimento] FOREIGN KEY([InvestimentoID])
REFERENCES [dbo].[Investimento] ([InvestimentoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvestimentoDespesa] CHECK CONSTRAINT [Fk_InvestimentoDespesa_Investimento]
GO
ALTER TABLE [dbo].[InvestimentoVariacao]  WITH CHECK ADD  CONSTRAINT [Fk_InvestimentoVariacao_Investimento] FOREIGN KEY([InvestimentoID])
REFERENCES [dbo].[Investimento] ([InvestimentoID])
GO
ALTER TABLE [dbo].[InvestimentoVariacao] CHECK CONSTRAINT [Fk_InvestimentoVariacao_Investimento]
GO
ALTER TABLE [dbo].[Lancamento]  WITH CHECK ADD  CONSTRAINT [FK_Lancamento_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lancamento] CHECK CONSTRAINT [FK_Lancamento_Usuario]
GO
ALTER TABLE [dbo].[Melhoria]  WITH CHECK ADD  CONSTRAINT [FK_Melhoria_Melhoria] FOREIGN KEY([DependenciaID])
REFERENCES [dbo].[MelhoriaVersao] ([VersaoID])
GO
ALTER TABLE [dbo].[Melhoria] CHECK CONSTRAINT [FK_Melhoria_Melhoria]
GO
ALTER TABLE [dbo].[Melhoria]  WITH CHECK ADD  CONSTRAINT [Fk_Melhoria_MelhoriaModulo] FOREIGN KEY([ModuloID])
REFERENCES [dbo].[MelhoriaModulo] ([ModuloID])
GO
ALTER TABLE [dbo].[Melhoria] CHECK CONSTRAINT [Fk_Melhoria_MelhoriaModulo]
GO
ALTER TABLE [dbo].[Melhoria]  WITH CHECK ADD  CONSTRAINT [FK_Melhoria_MelhoriaNivel] FOREIGN KEY([NivelID])
REFERENCES [dbo].[MelhoriaNivel] ([NivelID])
GO
ALTER TABLE [dbo].[Melhoria] CHECK CONSTRAINT [FK_Melhoria_MelhoriaNivel]
GO
ALTER TABLE [dbo].[Melhoria]  WITH CHECK ADD  CONSTRAINT [Fk_Melhoria_MelhoriaTipo] FOREIGN KEY([TipoID])
REFERENCES [dbo].[MelhoriaTipo] ([TipoID])
GO
ALTER TABLE [dbo].[Melhoria] CHECK CONSTRAINT [Fk_Melhoria_MelhoriaTipo]
GO
ALTER TABLE [dbo].[MoedaEletronica]  WITH CHECK ADD  CONSTRAINT [FK_MoedaEletronica_MoedaID] FOREIGN KEY([MoedaID])
REFERENCES [dbo].[Moeda] ([MoedaID])
GO
ALTER TABLE [dbo].[MoedaEletronica] CHECK CONSTRAINT [FK_MoedaEletronica_MoedaID]
GO
ALTER TABLE [dbo].[MoedaEletronica]  WITH CHECK ADD  CONSTRAINT [FK_MoedaEletronica_ParaMoedaID] FOREIGN KEY([ParaMoedaID])
REFERENCES [dbo].[Moeda] ([MoedaID])
GO
ALTER TABLE [dbo].[MoedaEletronica] CHECK CONSTRAINT [FK_MoedaEletronica_ParaMoedaID]
GO
ALTER TABLE [dbo].[MoedaEletronica]  WITH CHECK ADD  CONSTRAINT [FK_MoedaEletronica_WebService] FOREIGN KEY([WebServiceID])
REFERENCES [dbo].[WebService] ([WebServiceID])
GO
ALTER TABLE [dbo].[MoedaEletronica] CHECK CONSTRAINT [FK_MoedaEletronica_WebService]
GO
ALTER TABLE [dbo].[MovimentoConta]  WITH CHECK ADD  CONSTRAINT [FK_MovimentoConta_Categoria] FOREIGN KEY([CategoriaID])
REFERENCES [dbo].[Categoria] ([CategoriaID])
GO
ALTER TABLE [dbo].[MovimentoConta] CHECK CONSTRAINT [FK_MovimentoConta_Categoria]
GO
ALTER TABLE [dbo].[MovimentoConta]  WITH CHECK ADD  CONSTRAINT [FK_MovimentoConta_Conta] FOREIGN KEY([ContaID])
REFERENCES [dbo].[Conta] ([ContaID])
GO
ALTER TABLE [dbo].[MovimentoConta] CHECK CONSTRAINT [FK_MovimentoConta_Conta]
GO
ALTER TABLE [dbo].[MovimentoConta]  WITH CHECK ADD  CONSTRAINT [FK_MovimentoConta_GrupoCategoria] FOREIGN KEY([GrupoCategoriaID])
REFERENCES [dbo].[GrupoCategoria] ([GrupoCategoriaID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[MovimentoConta] CHECK CONSTRAINT [FK_MovimentoConta_GrupoCategoria]
GO
ALTER TABLE [dbo].[MovimentoConta]  WITH CHECK ADD  CONSTRAINT [FK_MovimentoConta_Lancamento] FOREIGN KEY([LancamentoID])
REFERENCES [dbo].[Lancamento] ([LancamentoID])
GO
ALTER TABLE [dbo].[MovimentoConta] CHECK CONSTRAINT [FK_MovimentoConta_Lancamento]
GO
ALTER TABLE [dbo].[MovimentoConta]  WITH CHECK ADD  CONSTRAINT [FK_MovimentoConta_MovimentoConta] FOREIGN KEY([DoMovimentoContaID])
REFERENCES [dbo].[MovimentoConta] ([MovimentoContaID])
GO
ALTER TABLE [dbo].[MovimentoConta] CHECK CONSTRAINT [FK_MovimentoConta_MovimentoConta]
GO
ALTER TABLE [dbo].[MovimentoConta]  WITH CHECK ADD  CONSTRAINT [Fk_MovimentoConta_Planejamento] FOREIGN KEY([PlanejamentoID])
REFERENCES [dbo].[Planejamento] ([PlanejamentoID])
GO
ALTER TABLE [dbo].[MovimentoConta] CHECK CONSTRAINT [Fk_MovimentoConta_Planejamento]
GO
ALTER TABLE [dbo].[MovimentoConta]  WITH CHECK ADD  CONSTRAINT [FK_MovimentoConta_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[MovimentoConta] CHECK CONSTRAINT [FK_MovimentoConta_Usuario]
GO
ALTER TABLE [dbo].[MovimentoContaConciliacaoBancaria]  WITH CHECK ADD  CONSTRAINT [Fk_MovimentoContaConciliacaoBancaria] FOREIGN KEY([MovimentoContaID])
REFERENCES [dbo].[MovimentoConta] ([MovimentoContaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovimentoContaConciliacaoBancaria] CHECK CONSTRAINT [Fk_MovimentoContaConciliacaoBancaria]
GO
ALTER TABLE [dbo].[MovimentoContaLigacao]  WITH CHECK ADD  CONSTRAINT [Fk_MovimentoContaLigacao_MovimentoContaID] FOREIGN KEY([MovimentoContaID])
REFERENCES [dbo].[MovimentoConta] ([MovimentoContaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovimentoContaLigacao] CHECK CONSTRAINT [Fk_MovimentoContaLigacao_MovimentoContaID]
GO
ALTER TABLE [dbo].[MovimentoContaLigacao]  WITH CHECK ADD  CONSTRAINT [Fk_MovimentoContaLigacao_MovimentoInvestimentoID] FOREIGN KEY([MovimentoInvestimentoID])
REFERENCES [dbo].[MovimentoInvestimento] ([MovimentoInvestimentoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovimentoContaLigacao] CHECK CONSTRAINT [Fk_MovimentoContaLigacao_MovimentoInvestimentoID]
GO
ALTER TABLE [dbo].[MovimentoContaLigacao]  WITH CHECK ADD  CONSTRAINT [Fk_MovimentoContaLigacao_TradeHitBTCID] FOREIGN KEY([TradeHitBTCID])
REFERENCES [dbo].[TradeHitBTC] ([TradeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovimentoContaLigacao] CHECK CONSTRAINT [Fk_MovimentoContaLigacao_TradeHitBTCID]
GO
ALTER TABLE [dbo].[MovimentoContaObservacao]  WITH CHECK ADD  CONSTRAINT [FK_MovimentoContaObservacao_MovimentoContaID] FOREIGN KEY([MovimentoContaID])
REFERENCES [dbo].[MovimentoConta] ([MovimentoContaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovimentoContaObservacao] CHECK CONSTRAINT [FK_MovimentoContaObservacao_MovimentoContaID]
GO
ALTER TABLE [dbo].[MovimentoInvestimento]  WITH CHECK ADD  CONSTRAINT [Fk_MovimentoInvestimento_Investimento] FOREIGN KEY([InvestimentoID])
REFERENCES [dbo].[Investimento] ([InvestimentoID])
GO
ALTER TABLE [dbo].[MovimentoInvestimento] CHECK CONSTRAINT [Fk_MovimentoInvestimento_Investimento]
GO
ALTER TABLE [dbo].[MovimentoInvestimento]  WITH CHECK ADD  CONSTRAINT [Fk_MovimentoInvestimento_InvestimentoCotacao] FOREIGN KEY([InvestimentoCotacaoID])
REFERENCES [dbo].[InvestimentoCotacao] ([InvestimentoCotacaoID])
GO
ALTER TABLE [dbo].[MovimentoInvestimento] CHECK CONSTRAINT [Fk_MovimentoInvestimento_InvestimentoCotacao]
GO
ALTER TABLE [dbo].[MovimentoInvestimento]  WITH CHECK ADD  CONSTRAINT [Fk_MovimentoInvestimento_MovimentoConta] FOREIGN KEY([MovimentoContaID])
REFERENCES [dbo].[MovimentoConta] ([MovimentoContaID])
GO
ALTER TABLE [dbo].[MovimentoInvestimento] CHECK CONSTRAINT [Fk_MovimentoInvestimento_MovimentoConta]
GO
ALTER TABLE [dbo].[MovimentoInvestimento]  WITH CHECK ADD  CONSTRAINT [Fk_MovimentoInvestimento_Transacao] FOREIGN KEY([TransacaoID])
REFERENCES [dbo].[Transacao] ([TransacaoID])
GO
ALTER TABLE [dbo].[MovimentoInvestimento] CHECK CONSTRAINT [Fk_MovimentoInvestimento_Transacao]
GO
ALTER TABLE [dbo].[MovimentoInvestimentoDespesa]  WITH CHECK ADD  CONSTRAINT [Fk_MovimentoInvestimentoDespesa_Categoria] FOREIGN KEY([CategoriaID])
REFERENCES [dbo].[Categoria] ([CategoriaID])
GO
ALTER TABLE [dbo].[MovimentoInvestimentoDespesa] CHECK CONSTRAINT [Fk_MovimentoInvestimentoDespesa_Categoria]
GO
ALTER TABLE [dbo].[MovimentoInvestimentoDespesa]  WITH CHECK ADD  CONSTRAINT [Fk_MovimentoInvestimentoDespesa_MovimentoInvestimento] FOREIGN KEY([MovimentoInvestimentoID])
REFERENCES [dbo].[MovimentoInvestimento] ([MovimentoInvestimentoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovimentoInvestimentoDespesa] CHECK CONSTRAINT [Fk_MovimentoInvestimentoDespesa_MovimentoInvestimento]
GO
ALTER TABLE [dbo].[Planejamento]  WITH CHECK ADD  CONSTRAINT [Fk_Planejamento_Categoria] FOREIGN KEY([CategoriaID])
REFERENCES [dbo].[Categoria] ([CategoriaID])
GO
ALTER TABLE [dbo].[Planejamento] CHECK CONSTRAINT [Fk_Planejamento_Categoria]
GO
ALTER TABLE [dbo].[Planejamento]  WITH CHECK ADD  CONSTRAINT [Fk_Planejamento_Conta] FOREIGN KEY([ContaID])
REFERENCES [dbo].[Conta] ([ContaID])
GO
ALTER TABLE [dbo].[Planejamento] CHECK CONSTRAINT [Fk_Planejamento_Conta]
GO
ALTER TABLE [dbo].[Planejamento]  WITH CHECK ADD  CONSTRAINT [Fk_Planejamento_GrupoCategoria] FOREIGN KEY([GrupoCategoriaID])
REFERENCES [dbo].[GrupoCategoria] ([GrupoCategoriaID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Planejamento] CHECK CONSTRAINT [Fk_Planejamento_GrupoCategoria]
GO
ALTER TABLE [dbo].[Planejamento]  WITH CHECK ADD  CONSTRAINT [Fk_Planejamento_Lancamento] FOREIGN KEY([LancamentoID])
REFERENCES [dbo].[Lancamento] ([LancamentoID])
GO
ALTER TABLE [dbo].[Planejamento] CHECK CONSTRAINT [Fk_Planejamento_Lancamento]
GO
ALTER TABLE [dbo].[Planejamento]  WITH CHECK ADD  CONSTRAINT [Fk_Planejamento_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[Planejamento] CHECK CONSTRAINT [Fk_Planejamento_Usuario]
GO
ALTER TABLE [dbo].[TipoConta]  WITH CHECK ADD  CONSTRAINT [FK_TipoConta_GrupoConta] FOREIGN KEY([GrupoContaID])
REFERENCES [dbo].[GrupoConta] ([GrupoContaID])
GO
ALTER TABLE [dbo].[TipoConta] CHECK CONSTRAINT [FK_TipoConta_GrupoConta]
GO
ALTER TABLE [dbo].[TipoConta]  WITH CHECK ADD  CONSTRAINT [FK_TipoConta_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[TipoConta] CHECK CONSTRAINT [FK_TipoConta_Usuario]
GO
ALTER TABLE [dbo].[TipoInstituicao]  WITH CHECK ADD  CONSTRAINT [FK_TipoInstituicao_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[TipoInstituicao] CHECK CONSTRAINT [FK_TipoInstituicao_Usuario]
GO
ALTER TABLE [dbo].[TipoInvestimento]  WITH CHECK ADD  CONSTRAINT [FK_TipoInvestimento_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[TipoInvestimento] CHECK CONSTRAINT [FK_TipoInvestimento_Usuario]
GO
ALTER TABLE [dbo].[GrupoCategoria]  WITH CHECK ADD  CONSTRAINT [Ck_GrupoCategoria_Proporcao] CHECK  (([Proporcao]>=(0) AND [Proporcao]<=(100)))
GO
ALTER TABLE [dbo].[GrupoCategoria] CHECK CONSTRAINT [Ck_GrupoCategoria_Proporcao]
GO
ALTER TABLE [dbo].[ImpostoFaixa]  WITH CHECK ADD  CONSTRAINT [Ck_ImpostoFaixa_Dias] CHECK  (([Dias]>(0)))
GO
ALTER TABLE [dbo].[ImpostoFaixa] CHECK CONSTRAINT [Ck_ImpostoFaixa_Dias]
GO
ALTER TABLE [dbo].[ImpostoFaixa]  WITH CHECK ADD  CONSTRAINT [Ck_ImpostoFaixa_Porcentagem] CHECK  (([Porcentagem]>=(0)))
GO
ALTER TABLE [dbo].[ImpostoFaixa] CHECK CONSTRAINT [Ck_ImpostoFaixa_Porcentagem]
GO
ALTER TABLE [dbo].[Planejamento]  WITH CHECK ADD  CONSTRAINT [Ck_Planejamento_Repeticoes] CHECK  (([Repeticoes]>=(0)))
GO
ALTER TABLE [dbo].[Planejamento] CHECK CONSTRAINT [Ck_Planejamento_Repeticoes]
GO
/****** Object:  StoredProcedure [dbo].[stpAcessoWebService]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/************************************************************
 Procedure stpAcessoWebService
 
 Elcio Reis - 27/09/2019

 Retorna o usuário e senha (ambos criptografados) da API do 
 WebService; cada execução dessa rotina contabilizará o
 acesso e registrará a hora da última consulta.

 Exemplo de execução
 EXEC stpAcessoWebService 2, 'HITBTC';

 ************************************************************/
CREATE PROCEDURE [dbo].[stpAcessoWebService](@UsuarioID INT, @Servico VARCHAR(25))
AS
    DECLARE @AcessoID INT;
BEGIN

    SELECT @AcessoID = AcessoID
    FROM AcessoWebService
    WHERE UsuarioID = @UsuarioID
    AND   Servico = UPPER(@Servico);

    IF (@AcessoID IS NOT NULL)
    BEGIN

        UPDATE AcessoWebService
        SET UltimoAcesso = GETDATE(),
            Acessos = Acessos + 1
        WHERE AcessoID = @AcessoID;

    END;

    SELECT Acessos, API, Segredo
    FROM AcessoWebService
    WHERE AcessoID = @AcessoID;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpApuracaoBaseadoEmInvestimentoVariacao]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/************************************************************************************************************************************************
 EXEC stpApuracaoBaseadoEmInvestimentoVariacao '0;1;4;1014;1019', '2015-05-01', 0;      -- dia a dia, variação em ordem crescente
 EXEC stpApuracaoBaseadoEmInvestimentoVariacao '0;1;4;1014;1019', '2015-05-01', 1;      -- dia a dia, acumulado em ordem crescente
 EXEC stpApuracaoBaseadoEmInvestimentoVariacao '0;1;4;1014;1019', '2015-05-01', 2, 0;   -- mês a mês, variação em ordem decrescente
 EXEC stpApuracaoBaseadoEmInvestimentoVariacao '0;1;4;1014;1019', '2015-05-01', 3, 1;   -- mês a mês, acumulado em ordem crescente
 EXEC stpApuracaoBaseadoEmInvestimentoVariacao '0;1;4;1014;1019', '2015-05-01', 4, 0;   -- mês a mês, variação e acumulado em ordem decrescente
 ************************************************************************************************************************************************/

CREATE PROC [dbo].[stpApuracaoBaseadoEmInvestimentoVariacao]
    @Investimentos VARCHAR(MAX),
    @DtInicio      DATE = NULL,
    @Tipo          SMALLINT = 0,   -- Definição dos tipos abaixo
    @Ascendente    BIT = 1
AS
BEGIN

    /******************************************************
        @Tipo pode ser:
        0 - dia a dia, variação
        1 - dia a dia, acumulado
        2 - mês a mês, variação
        3 - mês a mês, acumulado
        4 - mês a mês, variação e acumulado
     ******************************************************/

    SET NOCOUNT ON;

    -- Variáveis auxiliares
    DECLARE @InvestimentoID  INT,
            @ContaID         INT,
	        @Contador        INT,
			@IncluirPoupanca INT = 0,
            @Comando         NVARCHAR(MAX);


    IF (@DtInicio IS NULL)
    BEGIN
        -- Data utilizada na tabela de configuração
        SELECT @DtInicio = DtInicioUtilizacao
        FROM MoneyPro 
        WHERE MoneyProID = (SELECT MAX(MoneyProID) FROM MoneyPro);
    END;

    -- Declara uma tabela para os investimentos selecionados
	DECLARE @Selecionados TABLE (
		InvestimentoID INT
    );

    -- Se a relação de investimento foi passada, garante que a lista termine por ponto e vírgula
    -- Procura a data mínima igual para toda a lista de investimentos
    IF (@Investimentos IS NOT NULL) 
    BEGIN

        -- Garante que a lista de investimentos termina por ponto e vírgula
        IF RIGHT(@Investimentos,1) <> ';'
            SET @Investimentos = @Investimentos + ';';

        DECLARE @CodigosInv VARCHAR(30);

        SET @CodigosInv = @Investimentos;

		-- A data mínima será a maior entre a data de início da utilização e a mais nova aplicação
        
        SET @Contador = 0;
         
        WHILE (@CodigosInv > '')
        BEGIN

			SET @InvestimentoID = CAST(LEFT(@CodigosInv, CHARINDEX(';', @CodigosInv) - 1) AS INT);
			
			IF (@InvestimentoID = 0)
            BEGIN
				SET @IncluirPoupanca = 1;
            END
            ELSE
            BEGIN

			    -- Coloca o código do investimento em @Selecionados
			    INSERT INTO @Selecionados
			    (InvestimentoID)
			    VALUES
			    (@InvestimentoID);

            END;

            -- Descarta o primeiro código da lista.
            SET @CodigosInv = RIGHT(@CodigosInv, LEN(@CodigosInv) - CHARINDEX(';', @CodigosInv));

            SET @Contador = @Contador + 1;

        END;

    END
    ELSE
    BEGIN

        --
        -- Se não informar nenhum investimento, incluirá todos, até a poupanças
        --

		-- Coloca o código do investimento em @Selecionados
		INSERT INTO @Selecionados
		(InvestimentoID)
        SELECT DISTINCT InvestimentoID FROM MovimentoInvestimento ORDER BY InvestimentoID ASC;

        SET @IncluirPoupanca = 1;

    END;

    ---
    --- Carrega a variação dos investimentos a partir da tabela InvestimentoVariacao; 
    --- todas consultas utilizam a mesma tabela temporária populada no passo abaixo.
    ---

	CREATE TABLE #Tabela (
        Total           BIT DEFAULT 0,
        ContaID         INT,
        InvestimentoID  INT,
		Data            DATE,
		Valor           NUMERIC(15,4),
        TipoDado        CHAR(1) DEFAULT 'V'
	);

    INSERT INTO #Tabela
    --(Total, InvestimentoID, Data, Valor, TipoDado)
    --SELECT 0, IVar.InvestimentoID, IVar.Data, IVar.ValorLiquido, 'V'
    (InvestimentoID, Data, Valor)
    SELECT IVar.InvestimentoID, IVar.Data, IVar.ValorLiquido
    FROM @Selecionados Selc
    INNER JOIN InvestimentoVariacao IVar ON IVar.InvestimentoID = Selc.InvestimentoID
    WHERE IVar.Data >= @DtInicio
    ORDER BY IVar.InvestimentoID ASC, IVar.Data ASC;


    --
    -- Somente executa esse bloco se um dos investimentos vierem marcados como 0 (zero), que representa inclusão de conta poupança
    --
    IF (@IncluirPoupanca = 1) 
    BEGIN

        --
        -- Inclui os lucros obtidos em contas poupança
        --

        DECLARE @DtInicioMaisUM DATE = DATEADD(DAY, 1, @DtInicio);
        -- Cria tabela virtual de datas e popula dias uteis
	    DECLARE @Datas TABLE (Data DATE);
        INSERT INTO @Datas EXEC stpDataParaPesquisa 'U', @DtInicioMaisUm; 

        DECLARE @Auxiliar TABLE (
            ContaID  INT,
            Data     Date,
            Valor    NUMERIC(18,4)
        );

        INSERT INTO @Auxiliar
        (ContaID, Data, Valor)
        SELECT Mvto.ContaID AS ContaID, DBO.fncDiaComCotacao(Mvto.Data) Data, SUM(Mvto.Valor) Valor
        FROM MovimentoConta Mvto
        INNER JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
        INNER JOIN TipoConta TCta 
        ON TCta.TipoContaID = Cnta.TipoContaID AND TCta.Poupanca = 1   -- Somente poupança
        WHERE Mvto.Sistema <> 1                                        -- Não é operação do sistema (abertura de conta)
        AND   Mvto.DoMovimentoContaID IS NULL                          -- Não é fruto de transferência
        AND   Mvto.Valor > 0                                           -- Valor maior que zero
        AND   Mvto.Data >= @DtInicio                                   -- Lançamento com data igual ou maior ao início informado
        GROUP BY DBO.fncDiaComCotacao(Mvto.Data), Mvto.ContaID
        ORDER BY DBO.fncDiaComCotacao(Mvto.Data) ASC, Mvto.ContaID;

        DECLARE Contas CURSOR
        FOR SELECT DISTINCT ContaID
            FROM @Auxiliar
            ORDER BY ContaID;

        OPEN Contas;

        FETCH NEXT FROM Contas
        INTO @ContaID;

        WHILE @@FETCH_STATUS = 0
        BEGIN

            INSERT INTO #Tabela
            (ContaID, Data, Valor)
            SELECT @ContaId, Dta.Data, COALESCE(Aux.Valor, 0)
            FROM @Datas Dta
            LEFT JOIN @Auxiliar Aux ON Aux.Data = Dta.Data AND Aux.ContaID = @ContaId
            ORDER BY Dta.Data ASC;

            FETCH NEXT FROM Contas
            INTO @ContaID;

        END;

        CLOSE Contas;
        DEALLOCATE Contas;

    END;

    ----
    ---- Parte que contém as análises
    ----

    DECLARE @sldInvestimentoID INT,
            @sldContaID        INT,
            @sldData           DATE,
            @sldValor          NUMERIC(15,4);


    -- o @Tipo = 0 apresenta todos os dados, dia-a-dia, sem acumulação, portanto é somente o select principal pivotado pela data.

    IF (@Tipo = 1)
    BEGIN

        DECLARE Acumulados CURSOR
        FOR SELECT InvestimentoID, Data
            FROM #Tabela
            ORDER BY InvestimentoID ASC, Data ASC; 

        OPEN Acumulados;

        FETCH NEXT FROM Acumulados
        INTO @sldInvestimentoID, @sldData;

        WHILE @@FETCH_STATUS = 0
        BEGIN

            INSERT INTO #Tabela
            (Total, InvestimentoID, Data, Valor, TipoDado)
            SELECT 0, @sldInvestimentoID, @sldData, SUM(VALOR), 'A'
            FROM #Tabela
            WHERE InvestimentoID = @sldInvestimentoID AND Data <= @sldData AND TipoDado = 'V';


            FETCH NEXT FROM Acumulados
            INTO @sldInvestimentoID, @sldData;

        END;

        CLOSE Acumulados;
        DEALLOCATE Acumulados;

        IF (@IncluirPoupanca = 1)
        BEGIN

            DECLARE Acumulados CURSOR
            FOR SELECT ContaID, Data
                FROM #Tabela
                ORDER BY ContaID ASC, Data ASC; 

            OPEN Acumulados;

            FETCH NEXT FROM Acumulados
            INTO @sldContaID, @sldData;

            WHILE @@FETCH_STATUS = 0
            BEGIN

                INSERT INTO #Tabela
                (Total, ContaID, Data, Valor, TipoDado)
                SELECT 0, @sldContaID, @sldData, SUM(VALOR), 'A'
                FROM #Tabela
                WHERE ContaID = @sldContaID AND Data <= @sldData AND TipoDado = 'V';


                FETCH NEXT FROM Acumulados
                INTO @sldContaID, @sldData;

            END;

            CLOSE Acumulados;
            DEALLOCATE Acumulados;

        END;


        DELETE FROM #Tabela
        WHERE TipoDado = 'V';

    END;

    IF (@Tipo IN (2, 3, 4))
    BEGIN

        --
        -- Acumula a variação diária num mês, sinalizando o mês como acumulado
        --

        INSERT INTO #Tabela
        (Total, InvestimentoID, Data, Valor, TipoDado)
        SELECT 0, Tab.InvestimentoID, 
               DATEFROMPARTS(DATEPART(YEAR, Tab.Data), DATEPART(MONTH, Tab.Data), 1) Data,
               Sum(Valor) Valor, 'A'
        FROM #Tabela Tab
        WHERE Tab.InvestimentoID IS NOT NULL
        GROUP BY Tab.InvestimentoID, DATEFROMPARTS(DATEPART(YEAR, Tab.Data), DATEPART(MONTH, Tab.Data), 1)
        ORDER BY Tab.InvestimentoID, Data;

        INSERT INTO #Tabela
        (Total, ContaID, Data, Valor, TipoDado)
        SELECT 0, Tab.ContaID, 
               DATEFROMPARTS(DATEPART(YEAR, Tab.Data), DATEPART(MONTH, Tab.Data), 1) Data,
               Sum(Valor) Valor, 'A'
        FROM #Tabela Tab
        WHERE Tab.ContaID IS NOT NULL
        GROUP BY Tab.ContaID, DATEFROMPARTS(DATEPART(YEAR, Tab.Data), DATEPART(MONTH, Tab.Data), 1)
        ORDER BY Tab.ContaID, Data;

        --
        -- Remove as linhas de variação, que eram os dados diários originais
        --

        DELETE FROM #Tabela
        WHERE TipoDado = 'V';

        --
        -- Altera o tipo de dado para variação, pois é a variação acumulada do mês
        --

        UPDATE #Tabela SET TipoDado = 'V';

    END;

    IF (@Tipo IN (3, 4))
    BEGIN

        DECLARE Acumulados CURSOR
        FOR SELECT InvestimentoID, ContaID, Data
            FROM #Tabela
            ORDER BY InvestimentoID ASC, ContaID ASC, Data ASC; 

        OPEN Acumulados;

        FETCH NEXT FROM Acumulados
        INTO @sldInvestimentoID, @sldContaID, @sldData;

        WHILE @@FETCH_STATUS = 0
        BEGIN

            INSERT INTO #Tabela
            (Total, InvestimentoID, Data, Valor, TipoDado)
            SELECT 0, @sldInvestimentoID, @sldData, SUM(VALOR), 'A'
            FROM #Tabela
            WHERE InvestimentoID = @sldInvestimentoID AND ContaID IS NULL AND Data <= @sldData AND TipoDado = 'V';

            INSERT INTO #Tabela
            (Total, ContaID, Data, Valor, TipoDado)
            SELECT 0, @sldContaID, @sldData, SUM(VALOR), 'A'
            FROM #Tabela
            WHERE ContaID = @sldContaID AND InvestimentoID IS NULL AND Data <= @sldData AND TipoDado = 'V';

            FETCH NEXT FROM Acumulados
            INTO @sldInvestimentoID, @sldContaID, @sldData;

        END;

        CLOSE Acumulados;
        DEALLOCATE Acumulados;

        IF (@Tipo = 3)
        BEGIN

            DELETE FROM #Tabela
            WHERE TipoDado = 'V';

        END;

    END;

    --
    -- Insere o total diário
    --
    INSERT INTO #Tabela
	(Total, ContaID, InvestimentoID, Data, Valor, TipoDado)
    SELECT 1 AS Total, 0 AS ContaID, 0 AS InvestimentoID, Data, SUM(Valor) AS Valor, TipoDado
    FROM #Tabela
    WHERE Valor IS NOT NULL
    GROUP BY Data, TipoDado;

    --
    -- Cria os nomes das colunas de origem e destino para fazer a pivotagem
    --

    DECLARE @ColOrigem VARCHAR(MAX) = '';
    DECLARE @ColDestino VARCHAR(MAX) = '';
    DECLARE @Apelido VARCHAR(40);

    DECLARE SAIDA CURSOR
    ----FOR SELECT DISTINCT #Tabela.InvestimentoID, COALESCE(Inv.Apelido, 'Total') AS Apelido-----
    FOR SELECT DISTINCT #Tabela.InvestimentoID, #Tabela.ContaID, COALESCE(Inv.Apelido, Cta.Apelido, 'Total') AS Apelido
        FROM #Tabela
		LEFT JOIN Investimento Inv ON Inv.InvestimentoID = #Tabela.InvestimentoID
		LEFT JOIN Conta Cta ON Cta.ContaID = #Tabela.ContaID
		WHERE Valor <> 0
        ORDER BY Apelido ASC;

    OPEN SAIDA;

    FETCH NEXT FROM SAIDA 
    INTO @InvestimentoID, @ContaID, @Apelido;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        SET @ColOrigem = @ColOrigem + '[' + CAST(COALESCE(@InvestimentoID, @ContaID) AS VARCHAR(6)) + '] AS ''' + @Apelido + '''';
        SET @ColDestino = @ColDestino + '[' + CAST(COALESCE(@InvestimentoID, @ContaID) AS VARCHAR(6)) + ']';

        FETCH NEXT FROM SAIDA 
        INTO @InvestimentoID, @ContaID, @Apelido;

        IF @@FETCH_STATUS = 0
        BEGIN
            SET @ColOrigem = @ColOrigem + ', ';
            SET @ColDestino = @ColDestino + ', ';
        END;

    END;

    CLOSE SAIDA;
    DEALLOCATE SAIDA;

    --
    -- Cria uma string para fazer a pivotagem sobre a tabela temporária
    --

    DECLARE @Pivot VARCHAR(MAX);

    SET @Pivot = 'SELECT Data, CASE TipoDado WHEN ''V'' THEN ''Variação'' ELSE ''Acumulado'' END TipoDado, ' + @ColOrigem + ' ' +
                 'FROM (SELECT Data, COALESCE(InvestimentoID, ContaID) InvestimentoID, Valor, TipoDado FROM #Tabela WHERE Valor <> 0) ORIGEM '+
                 'PIVOT (SUM(Valor) FOR InvestimentoID IN (' + @ColDestino + ')) FINAL ORDER BY Data ' + CASE WHEN @Ascendente = 1 THEN 'ASC;' ELSE 'DESC;' END;

    -- 
    -- Executa a string contendo o comando de pivotagem
    -- 
    EXEC (@Pivot);


    --
    -- Apaga a tabela temporária que não será mais necessária
    --
    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpApuracaoBaseadoEmInvestimentoVariacaoPerc]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/***************************************************************************************************************************************************
 EXEC stpApuracaoBaseadoEmInvestimentoVariacaoPerc '0;1;4;1014;1019', '2015-05-01', 0;      -- dia a dia, variação em ordem crescente
 EXEC stpApuracaoBaseadoEmInvestimentoVariacaoPerc '0;1;4;1014;1019', '2015-05-01', 1;      -- dia a dia, acumulado em ordem crescente
 EXEC stpApuracaoBaseadoEmInvestimentoVariacaoPerc '0;1;4;1014;1019', '2015-05-01', 2, 0;   -- mês a mês, variação em ordem decrescente
 EXEC stpApuracaoBaseadoEmInvestimentoVariacaoPerc '0;1;4;1014;1019', '2015-05-01', 3, 1;   -- mês a mês, acumulado em ordem crescente
 EXEC stpApuracaoBaseadoEmInvestimentoVariacaoPerc '0;1;4;1014;1019', '2015-05-01', 4, 0;   -- mês a mês, variação e acumulado em ordem decrescente
 ***************************************************************************************************************************************************/

CREATE PROC [dbo].[stpApuracaoBaseadoEmInvestimentoVariacaoPerc]
    @Investimentos VARCHAR(MAX),
    @DtInicio      DATE = NULL,
    @Tipo          SMALLINT = 0,   -- Definição dos tipos abaixo
    @Ascendente    BIT = 1
AS
BEGIN

    /******************************************************
        @Tipo pode ser:
        0 - dia a dia, variação
        1 - dia a dia, acumulado
        2 - mês a mês, variação
        3 - mês a mês, acumulado
        4 - mês a mês, variação e acumulado
     ******************************************************/

    SET NOCOUNT ON;

    -- Variáveis auxiliares
    DECLARE @InvestimentoID  INT,
            @ContaID         INT,
	        @Contador        INT,
			@IncluirPoupanca INT = 0,
            @Comando         NVARCHAR(MAX);

    -- Variáveis utilizadas para cálculos acumulados
    DECLARE @sldInvestimentoID INT,
            @sldContaID        INT,
            @sldData           DATE,
            @sldPercInvest     NUMERIC(18,12),
            @sldPercAcumul     NUMERIC(18,12),
            @auxInvestimentoID INT,
            @auxContaID        INT,
            @auxData           DATE;

    IF (@DtInicio IS NULL)
    BEGIN
        -- Data utilizada na tabela de configuração
        SELECT @DtInicio = DtInicioUtilizacao
        FROM MoneyPro 
        WHERE MoneyProID = (SELECT MAX(MoneyProID) FROM MoneyPro);
    END;

    --DECLARE @DtInicioMaisUM DATE = DATEADD(DAY, 1, @DtInicio);

    -- Declara uma tabela para os investimentos selecionados
	DECLARE @Selecionados TABLE (InvestimentoID INT);

    -- Se a relação de investimento foi passada, garante que a lista termine por ponto e vírgula
    -- Procura a data mínima igual para toda a lista de investimentos
    IF (@Investimentos IS NOT NULL) 
    BEGIN

        -- Garante que a lista de investimentos termina por ponto e vírgula
        IF RIGHT(@Investimentos,1) <> ';'
            SET @Investimentos = @Investimentos + ';';

        DECLARE @CodigosInv VARCHAR(30);

        SET @CodigosInv = @Investimentos;

		-- A data mínima será a maior entre a data de início da utilização e a mais nova aplicação
        
        SET @Contador = 0;
         
        WHILE (@CodigosInv > '')
        BEGIN

			SET @InvestimentoID = CAST(LEFT(@CodigosInv, CHARINDEX(';', @CodigosInv) - 1) AS INT);
			
			IF (@InvestimentoID = 0)
            BEGIN
				SET @IncluirPoupanca = 1;
            END
            ELSE
            BEGIN

			    -- Coloca o código do investimento em @Selecionados
			    INSERT INTO @Selecionados
			    (InvestimentoID)
			    VALUES
			    (@InvestimentoID);

            END;

            -- Descarta o primeiro código da lista.
            SET @CodigosInv = RIGHT(@CodigosInv, LEN(@CodigosInv) - CHARINDEX(';', @CodigosInv));

            SET @Contador = @Contador + 1;

        END;

    END
    ELSE
    BEGIN

        --
        -- Se não informar nenhum investimento, incluirá todos, até a poupanças
        --

		-- Coloca o código do investimento em @Selecionados
		INSERT INTO @Selecionados
		(InvestimentoID)
        SELECT DISTINCT InvestimentoID FROM MovimentoInvestimento ORDER BY InvestimentoID ASC;

        SET @IncluirPoupanca = 1;

    END;

    ---
    --- Carrega a variação dos investimentos a partir da tabela InvestimentoVariacao; 
    --- todas consultas utilizam a mesma tabela temporária populada no passo abaixo.
    ---

	CREATE TABLE #Tabela (
        Total            BIT DEFAULT 0,
        ContaID          INT,
        InvestimentoID   INT,
		Data             DATE,
        PercInvestimento NUMERIC(18,12),
        TipoDado         CHAR(1) DEFAULT 'V'
	);

    INSERT INTO #Tabela
    (InvestimentoID, Data, PercInvestimento)
    SELECT IVar.InvestimentoID, IVar.Data, IVar.PercInvestimento
    FROM @Selecionados Selc
    INNER JOIN InvestimentoVariacao IVar ON IVar.InvestimentoID = Selc.InvestimentoID
    WHERE IVar.Data >= DATEADD(DAY, 1, @DtInicio)
    ORDER BY IVar.InvestimentoID ASC, IVar.Data ASC;


/****************************************************************
 ****************************************************************

    --
    -- Somente executa esse bloco se um dos investimentos vierem marcados como 0 (zero), que representa inclusão de conta poupança
    --
    IF (@IncluirPoupanca = 1) 
    BEGIN

        --
        -- Inclui os lucros obtidos em contas poupança
        --

        DECLARE @DtInicioMaisUM DATE = DATEADD(DAY, 1, @DtInicio);
        -- Cria tabela virtual de datas e popula dias uteis
	    DECLARE @Datas TABLE (Data DATE);
        INSERT INTO @Datas EXEC stpDataParaPesquisa 'U', @DtInicioMaisUm; 

        DECLARE @Auxiliar TABLE (
            ContaID  INT,
            Data     Date,
            Valor    NUMERIC(18,4)
        );

        INSERT INTO @Auxiliar
        (ContaID, Data, Valor)
        SELECT Mvto.ContaID AS ContaID, DBO.fncDiaComCotacao(Mvto.Data) Data, SUM(Mvto.Valor) Valor
        FROM MovimentoConta Mvto
        INNER JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
        INNER JOIN TipoConta TCta 
        ON TCta.TipoContaID = Cnta.TipoContaID AND TCta.Poupanca = 1   -- Somente poupança
        WHERE Mvto.Sistema <> 1                                        -- Não é operação do sistema (abertura de conta)
        AND   Mvto.DoMovimentoContaID IS NULL                          -- Não é fruto de transferência
        AND   Mvto.Valor > 0                                           -- Valor maior que zero
        AND   Mvto.Data >= @DtInicio                                   -- Lançamento com data igual ou maior ao início informado
        GROUP BY DBO.fncDiaComCotacao(Mvto.Data), Mvto.ContaID
        ORDER BY DBO.fncDiaComCotacao(Mvto.Data) ASC, Mvto.ContaID;

        DECLARE Contas CURSOR
        FOR SELECT DISTINCT ContaID
            FROM @Auxiliar
            ORDER BY ContaID;

        OPEN Contas;

        FETCH NEXT FROM Contas
        INTO @ContaID;

        WHILE @@FETCH_STATUS = 0
        BEGIN

            INSERT INTO #Tabela
            (ContaID, Data, Valor)
            SELECT @ContaId, Dta.Data, COALESCE(Aux.Valor, 0)
            FROM @Datas Dta
            LEFT JOIN @Auxiliar Aux ON Aux.Data = Dta.Data AND Aux.ContaID = @ContaId
            ORDER BY Dta.Data ASC;

            FETCH NEXT FROM Contas
            INTO @ContaID;

        END;

        CLOSE Contas;
        DEALLOCATE Contas;

    END;

 ****************************************************************
 ****************************************************************/

    ----
    ---- Parte que contém as análises
    ----

    -- o @Tipo = 0 apresenta todos os dados, dia-a-dia, sem acumulação, portanto é somente o select principal pivotado pela data.

    IF (@Tipo = 1)
    BEGIN

        DECLARE Acumulados CURSOR
        FOR SELECT InvestimentoID, Data, PercInvestimento
            FROM #Tabela
            WHERE InvestimentoID IS NOT NULL
            ORDER BY InvestimentoID ASC, Data ASC; 

        OPEN Acumulados;

        FETCH NEXT FROM Acumulados
        INTO @sldInvestimentoID, @sldData, @sldPercInvest;

        SET @auxInvestimentoID = -1;

        WHILE @@FETCH_STATUS = 0
        BEGIN

            IF (@sldInvestimentoID = @auxInvestimentoID)
            BEGIN
                SET @sldPercAcumul = (1 + @sldPercInvest) * (1 + @sldPercAcumul) - 1;            
            END
            ELSE
            BEGIN
                SET @auxInvestimentoID = @sldInvestimentoID;                
                SET @sldPercAcumul = @sldPercInvest;
            END;

            INSERT INTO #Tabela
            (Total, InvestimentoID, Data, PercInvestimento, TipoDado)
            VALUES
            (0, @sldInvestimentoID, @sldData, @sldPercAcumul, 'A')

            FETCH NEXT FROM Acumulados
            INTO @sldInvestimentoID, @sldData, @sldPercInvest;

        END;

        CLOSE Acumulados;
        DEALLOCATE Acumulados;

        --
        -- Inclui um ZERO no dia anterior ao ponto de partida para que todas as linhas do gráfico sempre comecem do mesmo ponto
        --

        DECLARE Lista CURSOR
        FOR SELECT DISTINCT InvestimentoID, DATEADD(DAY, -1, MIN(Data)) Data 
            FROM #Tabela 
            GROUP BY InvestimentoID
            ORDER BY InvestimentoID ASC;

        OPEN Lista;

        FETCH NEXT FROM Lista
        INTO @auxInvestimentoID, @auxData;

        --SET @auxData = DATEADD(DAY, -1, @DtInicio);

        WHILE @@FETCH_STATUS = 0
        BEGIN

            INSERT INTO #Tabela
            (InvestimentoID, Data, PercInvestimento, TipoDado)
            VALUES
            (@auxInvestimentoID, @auxData, 0, 'A');

            FETCH NEXT FROM Lista
            INTO @auxInvestimentoID, @auxData;
        END;

        CLOSE Lista;

        DEALLOCATE Lista;



/*********************
        IF (@IncluirPoupanca = 1)
        BEGIN

            DECLARE Acumulados CURSOR
            FOR SELECT ContaID, Data
                FROM #Tabela
                ORDER BY ContaID ASC, Data ASC; 

            OPEN Acumulados;

            FETCH NEXT FROM Acumulados
            INTO @sldContaID, @sldData;

            WHILE @@FETCH_STATUS = 0
            BEGIN

                INSERT INTO #Tabela
                (Total, ContaID, Data, Valor, TipoDado)
                SELECT 0, @sldContaID, @sldData, SUM(VALOR), 'A'
                FROM #Tabela
                WHERE ContaID = @sldContaID AND Data <= @sldData AND TipoDado = 'V';


                FETCH NEXT FROM Acumulados
                INTO @sldContaID, @sldData;

            END;

            CLOSE Acumulados;
            DEALLOCATE Acumulados;

        END;
***************/

        DELETE FROM #Tabela
        WHERE TipoDado = 'V';

    END;

/*********************************** não tem sentido este total
    --
    -- Insere o total diário
    --

    DECLARE Acumulados CURSOR
    FOR SELECT Data, PercInvestimento
        FROM #Tabela
        ORDER BY Data ASC;  

    OPEN Acumulados;

    FETCH NEXT FROM Acumulados
    INTO @sldData, @sldPercInvest;

    -- Força a data auxData ser diferente da primeira data do Cursor
    SET @auxData = DATEADD(DAY, -1, @sldData);

    WHILE @@FETCH_STATUS = 0
    BEGIN

        IF (@sldData = @auxData)
        BEGIN
            SET @sldPercAcumul = (1 + @sldPercInvest) * (1 + @sldPercAcumul) - 1;            
        END
        ELSE
        BEGIN
            SET @auxData = @sldData;                
            SET @sldPercAcumul = @sldPercInvest;
        END;

        FETCH NEXT FROM Acumulados
        INTO @sldData, @sldPercInvest;

        IF (@sldData <> @auxData) OR (@@FETCH_STATUS <> 0)
        BEGIN

            --
            -- Insere apenas um total por data
            --

            INSERT INTO #Tabela
            (Total, InvestimentoID, ContaID, Data, PercInvestimento, TipoDado)
            VALUES
            (1, 0, 0, @auxData, @sldPercAcumul, 'A')

        END;

    END;

    CLOSE Acumulados;
    DEALLOCATE Acumulados;
 *********************************** não tem sentido este total ************/


    --
    -- Cria os nomes das colunas de origem e destino para fazer a pivotagem
    --

    DECLARE @ColOrigem VARCHAR(MAX) = '';
    DECLARE @ColDestino VARCHAR(MAX) = '';
    DECLARE @Apelido VARCHAR(40);

    DECLARE SAIDA CURSOR
    FOR SELECT DISTINCT #Tabela.InvestimentoID, #Tabela.ContaID, COALESCE(Inv.Apelido, Cta.Apelido, 'Total') AS Apelido
        FROM #Tabela
		LEFT JOIN Investimento Inv ON Inv.InvestimentoID = #Tabela.InvestimentoID
		LEFT JOIN Conta Cta ON Cta.ContaID = #Tabela.ContaID
		WHERE PercInvestimento <> 0
        ORDER BY Apelido ASC;

    OPEN SAIDA;

    FETCH NEXT FROM SAIDA 
    INTO @InvestimentoID, @ContaID, @Apelido;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        SET @ColOrigem = @ColOrigem + '[' + CAST(COALESCE(@InvestimentoID, @ContaID) AS VARCHAR(6)) + '] AS ''' + @Apelido + '''';
        SET @ColDestino = @ColDestino + '[' + CAST(COALESCE(@InvestimentoID, @ContaID) AS VARCHAR(6)) + ']';

        FETCH NEXT FROM SAIDA 
        INTO @InvestimentoID, @ContaID, @Apelido;

        IF @@FETCH_STATUS = 0
        BEGIN
            SET @ColOrigem = @ColOrigem + ', ';
            SET @ColDestino = @ColDestino + ', ';
        END;

    END;

    CLOSE SAIDA;
    DEALLOCATE SAIDA;

    --
    -- Cria uma string para fazer a pivotagem sobre a tabela temporária
    --

    DECLARE @Pivot VARCHAR(MAX);

    SET @Pivot = 'SELECT Data, CASE TipoDado WHEN ''V'' THEN ''Variação'' ELSE ''Acumulado'' END TipoDado, ' + @ColOrigem + ' ' +
                 'FROM (SELECT Data, COALESCE(InvestimentoID, ContaID) InvestimentoID, PercInvestimento * 100 AS PercInvestimento, TipoDado FROM #Tabela) ORIGEM '+
                 'PIVOT (SUM(PercInvestimento) FOR InvestimentoID IN (' + @ColDestino + ')) FINAL ORDER BY Data ' + CASE WHEN @Ascendente = 1 THEN 'ASC;' ELSE 'DESC;' END;

    -- 
    -- Executa a string contendo o comando de pivotagem
    -- 
    EXEC (@Pivot);

    --
    -- Apaga a tabela temporária que não será mais necessária
    --
    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpApuracaoComparativoPorCategoria]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*********************************************************
 EXEC stpApuracaoComparativoPorCategoria '2015-06-27', 6, 0.9
 *********************************************************/

CREATE PROCEDURE [dbo].[stpApuracaoComparativoPorCategoria] 
    @UltimoMes DATE,
	@Periodos  INT,
	@Perc      DECIMAL(8,4) = 0.85,
	@Totaliza  INT = 0
AS
BEGIN
	SET NOCOUNT ON;

	-- Apaga uma possível tabela temporária abandonada
    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;

	DECLARE @Data DATE = @UltimoMes;
	DECLARE @Cont INT;

	-- Para criar o pivô dinâmico
    DECLARE @Pivot VARCHAR(MAX);
    DECLARE @ColOrigem VARCHAR(MAX) = '';
    DECLARE @ColDestino VARCHAR(MAX) = '';
    DECLARE @CategoriaID INT;
    DECLARE @Apelido VARCHAR(25);
    DECLARE @Ordem INT;


	CREATE TABLE #Tabela (
		CategoriaID   INT,
		Apelido       VARCHAR(25),
		Data          DATE,
		Total         DECIMAL(20,4)
	);


	WHILE (@Periodos > 0)
	BEGIN

		WHILE (Day(@Data) > 1)
		    SET @Data = DateAdd(Day, -1, @Data);

		INSERT INTO #Tabela
		EXEC stpApuracaoDestinoPorCategoria @Data, @Perc;

		IF (@Totaliza > 0)
		BEGIN

			SELECT @Cont = COUNT(Apelido) FROM #Tabela WHERE Data = @Data;

			IF (@Cont > 0)
			BEGIN
				INSERT INTO #Tabela
				SELECT -1, 'Total', @Data, SUM(Total) 
				FROM #Tabela WHERE Data = @Data;
			END;

		END;

        SET @Data = DateAdd(Day, -28, @Data);

		SET @Periodos = @Periodos - 1;
		
	END;

	--SELECT * 
	--FROM #Tabela
	--ORDER BY Data DESC, CASE WHEN CategoriaID > 0 THEN 1 WHEN CategoriaID = 0 THEN 2 ELSE 3 END ASC, Apelido ASC;

    DECLARE SAIDA CURSOR
    FOR SELECT DISTINCT CategoriaID, Apelido, CASE WHEN CategoriaID > 0 THEN 1 WHEN CategoriaID = 0 THEN 2 ELSE 3 END AS Ordem
        FROM #Tabela
		ORDER BY Ordem ASC, Apelido ASC;

    OPEN SAIDA;

    FETCH NEXT FROM SAIDA 
    INTO @CategoriaID, @Apelido, @Ordem;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        SET @ColOrigem = @ColOrigem + '[' + CAST(@CategoriaID AS VARCHAR(5)) + '] AS ''' + @Apelido + '''';
        SET @ColDestino = @ColDestino + '[' + CAST(@CategoriaID AS VARCHAR(5)) + ']';


        FETCH NEXT FROM SAIDA 
        INTO @CategoriaID, @Apelido, @Ordem;

        IF @@FETCH_STATUS = 0
        BEGIN
            SET @ColOrigem = @ColOrigem + ', ';
            SET @ColDestino = @ColDestino + ', ';
        END;

    END;

    CLOSE SAIDA;
    DEALLOCATE SAIDA;

    SET @Pivot = 'SELECT Data, ' + @ColOrigem + ' FROM (SELECT Data, CategoriaID, Total FROM #Tabela) ORIGEM PIVOT (' +
                 'SUM(Total) FOR CategoriaID IN (' + @ColDestino + ')) FINAL ORDER BY Data ASC;';

    EXEC (@Pivot);

    DROP TABLE #Tabela;

END;


GO
/****** Object:  StoredProcedure [dbo].[stpApuracaoDestinoPorCategoria]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/**********************************************************
 EXEC stpApuracaoDestinoPorCategoria '2015-05-31', 0.9
 **********************************************************/
CREATE PROCEDURE [dbo].[stpApuracaoDestinoPorCategoria]
    @Data DATE,
	@Perc DECIMAL(8,4) = 0.85
AS
BEGIN
	SET NOCOUNT ON;

	-- Sempre utilizará o dia 01
	WHILE (Day(@Data) > 1)
	    SET @Data = DateAdd(Day, -1, @Data);


	DECLARE @TotalGeral DECIMAL(20,4);

	DECLARE @CategoriaID  INT,
	        @Apelido      VARCHAR(25),
	        @Total        DECIMAL(20,4),
			@Acumulado    DECIMAL(20,4) = 0.0;

	DECLARE @Tabela TABLE (
	    CategoriaID  INT,
		Apelido      NVARCHAR(25),
		Data         DATE,
		Total        DECIMAL(20,4)
	);

	SELECT 
		@TotalGeral = Sum(Coalesce(MCta.Debito, 0))
	FROM MovimentoConta MCta
	     INNER JOIN Categoria Ctg1 ON Ctg1.CategoriaID = MCta.CategoriaID
		 INNER JOIN Categoria Ctg2 ON Ctg2.CategoriaID = Ctg1.CategoriaPaiID
		 INNER JOIN Categoria Ctg3 ON Ctg3.CategoriaID = Ctg2.CategoriaPaiID
	WHERE Mcta.Data <= GETDATE() 
	  AND Conciliacao <> 'F' 
	  AND YEAR(MCta.Data) = YEAR(@Data) AND MONTH(MCta.Data) = MONTH(@Data);

	DECLARE Valores CURSOR
	FOR SELECT 
    		Ctg2.CategoriaID, Ctg2.Apelido, Sum(Coalesce(MCta.Debito, 0))
        FROM MovimentoConta MCta
	         INNER JOIN Categoria Ctg1 ON Ctg1.CategoriaID = MCta.CategoriaID
             INNER JOIN Categoria Ctg2 ON Ctg2.CategoriaID = Ctg1.CategoriaPaiID
             INNER JOIN Categoria Ctg3 ON Ctg3.CategoriaID = Ctg2.CategoriaPaiID
        WHERE Mcta.Data <= GETDATE() 
		  AND Conciliacao <> 'F' 
		  AND YEAR(MCta.Data) = YEAR(@Data) AND MONTH(MCta.Data) = MONTH(@Data)
        GROUP BY Ctg2.CategoriaID, Ctg2.Apelido
        HAVING Sum(Coalesce(MCta.Debito, 0)) > 0
        ORDER BY Sum(Coalesce(MCta.Debito, 0)) DESC;

	OPEN Valores;

	FETCH NEXT FROM Valores
	INTO @CategoriaID, @Apelido, @Total;

	WHILE (@@FETCH_STATUS = 0 AND @Acumulado < @TotalGeral * @Perc)
	BEGIN
		INSERT INTO @Tabela
		(CategoriaID, Apelido, Data, Total)
		VALUES
		(@CategoriaID, @Apelido, @Data, @Total);

		SET @Acumulado = @Acumulado + @Total;

		FETCH NEXT FROM Valores
		INTO @CategoriaID, @Apelido, @Total;
	END;

	IF (@Acumulado < @TotalGeral)
	BEGIN
        DECLARE @Outros NVARCHAR(25);

		SET @Outros = 'Outros ('+NCHAR(425)+'<' + CAST(CAST(1 - @Perc AS DECIMAL(8,1)) * 100 AS VARCHAR(5))+'%)'

		INSERT INTO @Tabela
		(CategoriaID, Apelido, Data, Total)
		VALUES
		(0, @Outros, @Data, @TotalGeral - @Acumulado);
	END;

	CLOSE Valores;
	DEALLOCATE Valores;

	SELECT * FROM @Tabela;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpApuracaoDivisaoInvestimento]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpApuracaoDivisaoInvestimento]
AS
BEGIN

    SELECT 
        Apelido AS Investimento,
        VrAplicado
    FROM vw_Carteira
    WHERE VrAplicado > 0
    ORDER BY Apelido;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpApuracaoDivisaoRisco]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpApuracaoDivisaoRisco]
AS
BEGIN

    SELECT 
        Risco,
        CAST(SUM(VrAplicado) AS NUMERIC(20,4)) AS VrAplicado
    FROM vw_Carteira
    WHERE VrAplicado > 0
    GROUP BY Risco
    ORDER BY Risco;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpApuracaoInvestimentos]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpApuracaoInvestimentos](@Periodos INT = 56)
AS
BEGIN

    DECLARE @DiaUtil  BIT;
    DECLARE @Hoje     DATE = GETDATE();
    DECLARE @DtInicio DATE;

    SELECT @DtInicio = DtInicioUtilizacao
    FROM MoneyPro 
    WHERE MoneyProID = (SELECT MAX(MoneyProID) FROM MoneyPro)

    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;

    CREATE TABLE #Tabela (
        ContaID INT,
        Data    DATE,
        Valor   NUMERIC(19,2),
        Base    NUMERIC(19,2),
        Perc    NUMERIC(19,4)
    );

    DECLARE @ContaInvest TABLE (
        ContaID INT
    );

    /*
        Processa os lançamentos a crédito em contas do tipo poupança, despresando transferências, pois configuram depósito.        
    */

    INSERT INTO #Tabela
    (ContaID, Data, Valor, Base)
    SELECT Cnta.ContaID, @DtInicio, 0, 1
    FROM Conta Cnta
    INNER JOIN TipoConta TCnt ON TCnt.TipoContaID = Cnta.TipoContaID
    WHERE TCnt.Poupanca = 1;


    INSERT INTO #Tabela
    (ContaID, Data, Valor, Base)
    SELECT Mvto.ContaID, Mvto.Data, SUM(Mvto.Valor) AS Valor, 
           (SELECT SUM(Base.Valor) FROM MovimentoConta Base WHERE Base.ContaID = Mvto.ContaID AND Base.Data < Mvto.Data) AS Base
    FROM MovimentoConta Mvto
    INNER JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
    INNER JOIN TipoConta TCta ON TCta.TipoContaID = Cnta.TipoContaID
    WHERE Mvto.Sistema <> 1                      -- Não é operação do sistema (abertura de conta)
    AND Mvto.DoMovimentoContaID IS NULL          -- Não é fruto de transferência
    AND Mvto.Valor > 0                           -- Valor maior que zero
    AND TCta.Poupanca = 1                        -- Tipo de conta é poupança  
    GROUP BY Mvto.ContaID, Mvto.Data;


    /*
        Processa as valorizações das contas investimento.
     */
/***
    INSERT INTO @ContaInvest
    SELECT ContaID
    FROM Conta Cnta
    INNER JOIN TipoConta TCta ON TCta.TipoContaID = Cnta.TipoContaID
    WHERE TCta.Investimento = 1;

    WHILE @Hoje > @DtInicio
    BEGIN

        SELECT @DiaUtil = dbo.fncDiaUtil(@Hoje);

        IF (@DiaUtil = 1)
        BEGIN

            INSERT INTO #Tabela
            (ContaID, Data, Valor, Base)
            SELECT 
            ContaID, @Hoje, 
            dbo.fncSaldoContaInvestimentoData(ContaID, @Hoje) - dbo.fncSaldoContaInvestimentoData(ContaID, DATEADD(DAY, -1, @Hoje)),
            0
            FROM @ContaInvest
            WHERE ContaID <> ContaID  -- Remover até decidir como ficará o cálculo dos investimentos.


        --SELECT *
        --FROM Conta Cnta
        --INNER JOIN TipoConta TCta ON TCta.TipoContaID = Cnta.TipoContaID        
        --WHERE TCta.Investimento = 1                  -- Tipo de conta é investimento
        END;

        SET @Hoje = DATEADD(DAY, -1, @Hoje);

    END;
 ***/

    /*
        Calcula todas as porcentagens.
     */

    DELETE FROM #Tabela WHERE Base = 0;

    UPDATE #Tabela
    SET Perc = CAST(Valor / Base * 100 AS NUMERIC(19,4))


    /*
        Monta um Pivot em tempo de execução
     */

    DECLARE @ColOrigem VARCHAR(MAX) = '';
    DECLARE @ColDestino VARCHAR(MAX) = '';

    DECLARE @ContaID INT;
    DECLARE @Apelido VARCHAR(25);
    DECLARE @Ordem INT;

    DECLARE SAIDA CURSOR
    FOR SELECT DISTINCT Tbla.ContaID, Cnta.Apelido
        FROM #Tabela Tbla
        INNER JOIN Conta Cnta on Cnta.ContaID = Tbla.ContaID
        ORDER BY Cnta.Apelido ASC;

    OPEN SAIDA;

    FETCH NEXT FROM SAIDA 
    INTO @ContaID, @Apelido;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        SET @ColOrigem = @ColOrigem + '[' + CAST(@ContaID AS VARCHAR(2)) + '] AS ''' + @Apelido + '''';
        SET @ColDestino = @ColDestino + '[' + CAST(@ContaID AS VARCHAR(2)) + ']';


        FETCH NEXT FROM SAIDA 
        INTO @ContaID, @Apelido

        IF @@FETCH_STATUS = 0
        BEGIN
            SET @ColOrigem = @ColOrigem + ', ';
            SET @ColDestino = @ColDestino + ', ';
        END;

    END;


    CLOSE SAIDA;
    DEALLOCATE SAIDA;


    DECLARE @Pivot VARCHAR(MAX);
    
    SET @Pivot = 'SELECT Data, ' + @ColOrigem + ' FROM (SELECT Data, ContaID, Perc FROM #Tabela) ORIGEM PIVOT (' +
                 'AVG(Perc) FOR ContaID IN (' + @ColDestino + ')) FINAL ORDER BY Data ASC;';

    EXEC (@Pivot);


    --SELECT Data, [3] AS 'Itaú CP 0149-73828-8/500' FROM (
    --SELECT Data, ContaID, Perc
    --FROM #Tabela) ORIGEM PIVOT (Avg(Perc) FOR ContaID IN ([3])) FINAL ORDER BY Data ASC;

    --select @ColOrigem, @ColDestino;

    --SELECT ContaID, Data, Valor, Base, CAST(Valor / Base * 100 AS NUMERIC(18,4)) AS Perc
    --FROM #Tabela;

    DROP TABLE #Tabela;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpApuracaoInvestimentosAcumulados]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/**************************************************
 EXEC stpApuracaoInvestimentosAcumulados
 **************************************************/

CREATE PROCEDURE [dbo].[stpApuracaoInvestimentosAcumulados]
    @Periodo CHAR(1) = 'D'
AS
BEGIN

    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;


	CREATE TABLE #Tabela (
		Data     DATE,
		ContaID  INT,
		Valor    NUMERIC(19,2)
	);

	DECLARE @Datas TABLE (
		Data     DATE
    );

	INSERT INTO @Datas
	EXEC stpDataParaPesquisa @Periodo;

	-- Insere os movimentos de investimento.
	INSERT INTO #Tabela
	SELECT Data.Data, Cnta.ContaID, 
	       dbo.fncLucroContaInvestimentoData(Cnta.ContaID, Data.Data) - dbo.fncContaInvestimentoDataImpostoPago(Cnta.ContaID, Data.Data) AS Valor
    FROM Conta Cnta	    
         INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
		 INNER JOIN @Datas Data ON 1 = 1
		 INNER JOIN MovimentoConta MvCt ON MvCt.ContaID = Cnta.ContaID AND Mvct.Data <= Data.Data
    WHERE Tipo.Investimento = 1
	GROUP BY Data.Data, Cnta.ContaID
	ORDER BY Data.Data ASC;

	-- Insere os movimentos de poupança
	INSERT INTO #Tabela
	SELECT Data.Data, Mvto.ContaID, SUM(Mvto.Valor) AS Valor
	FROM @Datas Data
    INNER JOIN MovimentoConta Mvto ON Mvto.Data <= Data.Data
    INNER JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
    INNER JOIN TipoConta TCta ON TCta.TipoContaID = Cnta.TipoContaID
	WHERE Mvto.Sistema <> 1                      -- Não é operação do sistema (abertura de conta)
    AND Mvto.DoMovimentoContaID IS NULL          -- Não é fruto de transferência
    AND Mvto.Valor > 0                           -- Valor maior que zero
    AND TCta.Poupanca = 1                        -- Tipo de conta é poupança  
    GROUP BY Mvto.ContaID, Data.Data;


    DECLARE @ColOrigem VARCHAR(MAX) = '';
    DECLARE @ColDestino VARCHAR(MAX) = '';

    DECLARE @ContaID INT;
    DECLARE @Apelido VARCHAR(25);
    DECLARE @Ordem INT;

    DECLARE SAIDA CURSOR
    FOR SELECT DISTINCT #Tabela.ContaID, Conta.Apelido
        FROM #Tabela
		INNER JOIN Conta ON Conta.ContaID = #Tabela.ContaID
		WHERE Valor <> 0
        ORDER BY Apelido ASC;

    OPEN SAIDA;

    FETCH NEXT FROM SAIDA 
    INTO @ContaID, @Apelido;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        SET @ColOrigem = @ColOrigem + '[' + CAST(@ContaID AS VARCHAR(2)) + '] AS ''' + @Apelido + '''';
        SET @ColDestino = @ColDestino + '[' + CAST(@ContaID AS VARCHAR(2)) + ']';


        FETCH NEXT FROM SAIDA 
        INTO @ContaID, @Apelido;

        IF @@FETCH_STATUS = 0
        BEGIN
            SET @ColOrigem = @ColOrigem + ', ';
            SET @ColDestino = @ColDestino + ', ';
        END;

    END;

    CLOSE SAIDA;
    DEALLOCATE SAIDA;

    DECLARE @Pivot VARCHAR(MAX);

	SET @Pivot = 'SELECT Data, ' + @ColOrigem + ' FROM (SELECT Data, ContaID, Valor FROM #Tabela WHERE Valor <> 0) ORIGEM PIVOT (' +
                 'SUM(Valor) FOR ContaID IN (' + @ColDestino + ')) FINAL ORDER BY Data ASC;';

    EXEC (@Pivot);

    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpApuracaoInvestimentosAcumuladosMensal]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/**************************************************
 EXEC stpApuracaoInvestimentosAcumulados
 **************************************************/

CREATE PROCEDURE [dbo].[stpApuracaoInvestimentosAcumuladosMensal]
AS
BEGIN

    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;


	CREATE TABLE #Tabela (
		Data     DATE,
		ContaID  INT,
		Valor    NUMERIC(19,2)
	);

	DECLARE @Datas TABLE (
		Data     DATE
    );

	INSERT INTO @Datas
	EXEC stpDataParaPesquisa 'M';

	-- Insere os movimentos de investimento.
	INSERT INTO #Tabela
	SELECT Data.Data, Cnta.ContaID, 
	       dbo.fncLucroContaInvestimentoData(Cnta.ContaID, Data.Data) - dbo.fncContaInvestimentoDataImpostoPago(Cnta.ContaID, Data.Data) AS Valor
    FROM Conta Cnta	    
         INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
		 INNER JOIN @Datas Data ON 1 = 1
		 INNER JOIN MovimentoConta MvCt ON MvCt.ContaID = Cnta.ContaID AND Mvct.Data <= Data.Data
    WHERE Tipo.Investimento = 1
	GROUP BY Data.Data, Cnta.ContaID
	ORDER BY Data.Data ASC;

	-- Insere os movimentos de poupança
	INSERT INTO #Tabela
	SELECT Data.Data, Mvto.ContaID, SUM(Mvto.Valor) AS Valor
	FROM @Datas Data
    INNER JOIN MovimentoConta Mvto ON Mvto.Data <= Data.Data
    INNER JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
    INNER JOIN TipoConta TCta ON TCta.TipoContaID = Cnta.TipoContaID
	WHERE Mvto.Sistema <> 1                      -- Não é operação do sistema (abertura de conta)
    AND Mvto.DoMovimentoContaID IS NULL          -- Não é fruto de transferência
    AND Mvto.Valor > 0                           -- Valor maior que zero
    AND TCta.Poupanca = 1                        -- Tipo de conta é poupança  
    GROUP BY Mvto.ContaID, Data.Data;


    DECLARE @ColOrigem VARCHAR(MAX) = '';
    DECLARE @ColDestino VARCHAR(MAX) = '';

    DECLARE @ContaID INT;
    DECLARE @Apelido VARCHAR(25);
    DECLARE @Ordem INT;

    DECLARE SAIDA CURSOR
    FOR SELECT DISTINCT #Tabela.ContaID, Conta.Apelido
        FROM #Tabela
		INNER JOIN Conta ON Conta.ContaID = #Tabela.ContaID
		WHERE Valor <> 0
        ORDER BY Apelido ASC;

    OPEN SAIDA;

    FETCH NEXT FROM SAIDA 
    INTO @ContaID, @Apelido;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        SET @ColOrigem = @ColOrigem + '[' + CAST(@ContaID AS VARCHAR(2)) + '] AS ''' + @Apelido + '''';
        SET @ColDestino = @ColDestino + '[' + CAST(@ContaID AS VARCHAR(2)) + ']';


        FETCH NEXT FROM SAIDA 
        INTO @ContaID, @Apelido;

        IF @@FETCH_STATUS = 0
        BEGIN
            SET @ColOrigem = @ColOrigem + ', ';
            SET @ColDestino = @ColDestino + ', ';
        END;

    END;

    CLOSE SAIDA;
    DEALLOCATE SAIDA;

    DECLARE @Pivot VARCHAR(MAX);

	SET @Pivot = 'SELECT Data, ' + @ColOrigem + ' FROM (SELECT Data, ContaID, Valor FROM #Tabela WHERE Valor <> 0) ORIGEM PIVOT (' +
                 'SUM(Valor) FOR ContaID IN (' + @ColDestino + ')) FINAL ORDER BY Data ASC;';

    EXEC (@Pivot);

    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpApuracaoInvestimentosLiquidosAcumulados]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****************************************************
 EXEC stpApuracaoInvestimentosLiquidosAcumulados 'M'
 *****************************************************/

CREATE PROCEDURE [dbo].[stpApuracaoInvestimentosLiquidosAcumulados]
    @Periodos INT = 24,
    @Periodo CHAR(1) = 'D'
AS
BEGIN

    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;

	CREATE TABLE #Tabela (
        Registro        INT,
		Data            DATE,
		ContaID         INT,
		Valor           NUMERIC(19,2)
	);

	DECLARE @Datas TABLE (
		Data     DATE
    );

    DECLARE @InicioPeriodo DATE = DATEADD(DAY, 1, EOMONTH(GETDATE(), (@Periodos-1) * -1));

	INSERT INTO @Datas
	EXEC stpDataParaPesquisa @Periodo, @InicioPeriodo;

	-- Insere os movimentos de investimento.
	INSERT INTO #Tabela
	SELECT ROW_NUMBER() OVER(ORDER BY Data.Data ASC) AS Registro,
           Data.Data, Cnta.ContaID, 
	       dbo.fncLucroContaInvestimentoData(Cnta.ContaID, Data.Data) - dbo.fncContaInvestimentoDataImpostoPago(Cnta.ContaID, Data.Data) AS Valor
           --,MvIv.InvestimentoID AS Investimento
    FROM Conta Cnta	    
         INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
		 INNER JOIN @Datas Data ON 1 = 1
		 INNER JOIN MovimentoConta MvCt ON MvCt.ContaID = Cnta.ContaID AND Mvct.Data <= Data.Data
         --INNER JOIN MovimentoInvestimento MvIv ON MvIv.MovimentoContaID = MvCt.MovimentoContaID AND MvIv.VrLiquido <> 0
    WHERE Tipo.Investimento = 1
	GROUP BY Data.Data, Cnta.ContaID --, MvIv.InvestimentoID
	ORDER BY Data.Data ASC;

    -- Apaga investimentos que tiveram movimentação apenas antes do início do período e com zero cotas
    DELETE FROM #Tabela
    WHERE Registro IN (SELECT Temp.Registro
                       FROM #Tabela Temp
                            JOIN MovimentoConta MCta ON MCta.ContaID = Temp.ContaID
                            JOIN MovimentoInvestimento MInv ON MInv.MovimentoContaID = MCta.MovimentoContaID
                       GROUP BY Temp.Registro
                       HAVING MAX(MCta.Data) < @InicioPeriodo 
                       AND    SUM(MInv.QtCotas) = 0);

/*
    -- Atualiza os valores pelo cálculo dos investimentos descontando os impostos
    DECLARE @regMinimo INT, @regMaximo INT;
    DECLARE @InvestimentoID INT, @Data DATE, @ValorSTP NUMERIC(18,2);

    SELECT @regMinimo = MIN(Registro) FROM #Tabela;
    SELECT @regMaximo = MAX(Registro) FROM #Tabela;

    DECLARE @Valor TABLE (
        Valor    NUMERIC(18,2)
    );


    WHILE (@regMinimo <= @regMaximo)
    BEGIN

        SELECT @InvestimentoID = InvestimentoID,
               @Data = Data
        FROM #Tabela
        WHERE Registro = @regMinimo;

        INSERT INTO @Valor
        EXEC stpDetalhesInvestimento @InvestimentoID, @Data, 1, 0;

        SELECT @ValorSTP = Valor FROM @Valor;

        UPDATE #Tabela
        SET Valor = @ValorSTP
        WHERE Registro = @regMinimo;

        DELETE FROM @Valor;

        SELECT @regMinimo = @regMinimo + 1;
    END;
*/

	-- Insere os movimentos de poupança
	INSERT INTO #Tabela
	SELECT 0 AS Registro, Data.Data, Mvto.ContaID, SUM(Mvto.Valor) AS Valor
	FROM @Datas Data
    INNER JOIN MovimentoConta Mvto ON Mvto.Data <= Data.Data
    INNER JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
    INNER JOIN TipoConta TCta ON TCta.TipoContaID = Cnta.TipoContaID
	WHERE Mvto.Sistema <> 1                      -- Não é operação do sistema (abertura de conta)
    AND Mvto.DoMovimentoContaID IS NULL          -- Não é fruto de transferência
    AND Mvto.Valor > 0                           -- Valor maior que zero
    AND TCta.Poupanca = 1                        -- Tipo de conta é poupança  
    GROUP BY Mvto.ContaID, Data.Data;

    DECLARE @ColOrigem VARCHAR(MAX) = '';
    DECLARE @ColDestino VARCHAR(MAX) = '';

    DECLARE @ContaID INT;
    DECLARE @Apelido VARCHAR(25);
    DECLARE @Ordem INT;

    IF (@Periodo = 'M')
    BEGIN
        UPDATE #Tabela
        SET Data = dbo.fncMeioDoMes(Data);

        INSERT INTO #Tabela
        SELECT 0 AS Registro, Data, -1 AS ContaID, SUM(Valor) AS Valor
        FROM #Tabela
        WHERE Valor IS NOT NULL
        GROUP BY Data;

    END;

    DECLARE SAIDA CURSOR
    FOR SELECT DISTINCT #Tabela.ContaID, COALESCE(Conta.Apelido, 'Total') AS Apelido
        FROM #Tabela
		LEFT JOIN Conta ON Conta.ContaID = #Tabela.ContaID
		WHERE Valor <> 0
        ORDER BY Apelido ASC;

    OPEN SAIDA;

    FETCH NEXT FROM SAIDA 
    INTO @ContaID, @Apelido;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        SET @ColOrigem = @ColOrigem + '[' + CAST(@ContaID AS VARCHAR(2)) + '] AS ''' + @Apelido + '''';
        SET @ColDestino = @ColDestino + '[' + CAST(@ContaID AS VARCHAR(2)) + ']';

        FETCH NEXT FROM SAIDA 
        INTO @ContaID, @Apelido;

        IF @@FETCH_STATUS = 0
        BEGIN
            SET @ColOrigem = @ColOrigem + ', ';
            SET @ColDestino = @ColDestino + ', ';
        END;

    END;

    CLOSE SAIDA;
    DEALLOCATE SAIDA;

    DECLARE @Pivot VARCHAR(MAX);

	SET @Pivot = 'SELECT Data, ' + @ColOrigem + ' FROM (SELECT Data, ContaID, Valor FROM #Tabela WHERE Valor <> 0) ORIGEM PIVOT (' +
                 'SUM(Valor) FOR ContaID IN (' + @ColDestino + ')) FINAL ORDER BY Data ASC;';

    EXEC (@Pivot);

    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpApuracaoInvestimentosLiquidosVariacaoAcumulada]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*********************************************************************
 EXEC stpApuracaoInvestimentosLiquidosVariacaoAcumulada 'M'
 *********************************************************************/
 
CREATE PROCEDURE [dbo].[stpApuracaoInvestimentosLiquidosVariacaoAcumulada]
    @Periodo CHAR(1) = 'M',
	@Tipo CHAR(1) = 'T'  --- Tudo
AS
BEGIN

	SET NOCOUNT ON;

	-- A - Somente acumulados
	-- V - Somente variações
	-- T - Tudo

	SET @Tipo = UPPER(@Tipo);

	IF (NOT @Tipo IN ('A', 'V', 'T')) 
	   SET @Tipo = 'T';


    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;

	CREATE TABLE #Tabela (
        Registro        INT,
		Data            DATE,
        Tipo            CHAR(1),
		ContaID         INT,
		Valor           NUMERIC(19,2),
        InvestimentoID  INT
	);

	DECLARE @Datas TABLE (
		Data     DATE
    );

	INSERT INTO @Datas
	EXEC stpDataParaPesquisa @Periodo;

	-- Insere os movimentos de investimento.
	INSERT INTO #Tabela
	SELECT ROW_NUMBER() OVER(ORDER BY Data.Data ASC) AS Registro,
           Data.Data, 'A', Cnta.ContaID, 
	       dbo.fncLucroContaInvestimentoData(Cnta.ContaID, Data.Data) - dbo.fncContaInvestimentoDataImpostoPago(Cnta.ContaID, Data.Data) AS Valor,
           MvIv.InvestimentoID AS Investimento
    FROM Conta Cnta	    
         INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
		 INNER JOIN @Datas Data ON 1 = 1
		 INNER JOIN MovimentoConta MvCt ON MvCt.ContaID = Cnta.ContaID AND Mvct.Data <= Data.Data
         INNER JOIN MovimentoInvestimento MvIv ON MvIv.MovimentoContaID = MvCt.MovimentoContaID AND MvIv.VrLiquido <> 0
    WHERE Tipo.Investimento = 1
	GROUP BY Data.Data, Cnta.ContaID, MvIv.InvestimentoID
	ORDER BY Data.Data ASC;

    -- Atualiza os valores pelo cálculo dos investimentos descontando os impostos
    DECLARE @regMinimo INT, @regMaximo INT;
    DECLARE @InvestimentoID INT, @Data DATE, @ValorSTP NUMERIC(18,2);

    SELECT @regMinimo = MIN(Registro) FROM #Tabela;
    SELECT @regMaximo = MAX(Registro) FROM #Tabela;

    DECLARE @Valor TABLE (
        Valor    NUMERIC(18,2)
    );


    WHILE (@regMinimo <= @regMaximo)
    BEGIN

        SELECT @InvestimentoID = InvestimentoID,
               @Data = Data
        FROM #Tabela
        WHERE Registro = @regMinimo;

        INSERT INTO @Valor
        EXEC stpDetalhesInvestimento @InvestimentoID, @Data, 1, 0;

        SELECT @ValorSTP = Valor FROM @Valor;

        UPDATE #Tabela
        SET Valor = @ValorSTP
        WHERE Registro = @regMinimo;

        DELETE FROM @Valor;

        SELECT @regMinimo = @regMinimo + 1;
    END;

	-- Insere os movimentos de poupança
	INSERT INTO #Tabela
	SELECT 0 AS Registro, Data.Data, 'A', Mvto.ContaID, SUM(Mvto.Valor) AS Valor, 0 AS Investimento
	FROM @Datas Data
    INNER JOIN MovimentoConta Mvto ON Mvto.Data <= Data.Data
    INNER JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
    INNER JOIN TipoConta TCta ON TCta.TipoContaID = Cnta.TipoContaID
	WHERE Mvto.Sistema <> 1                      -- Não é operação do sistema (abertura de conta)
    AND Mvto.DoMovimentoContaID IS NULL          -- Não é fruto de transferência
    AND Mvto.Valor > 0                           -- Valor maior que zero
    AND TCta.Poupanca = 1                        -- Tipo de conta é poupança  
    GROUP BY Mvto.ContaID, Data.Data;

    DECLARE @ColOrigem VARCHAR(MAX) = '';
    DECLARE @ColDestino VARCHAR(MAX) = '';

    DECLARE @ContaID INT;
    DECLARE @Apelido VARCHAR(25);
    DECLARE @Ordem INT;

    IF (@Periodo = 'M')
    BEGIN

        UPDATE #Tabela
        SET Data = dbo.fncMeioDoMes(Data);

        INSERT INTO #Tabela
        SELECT 0 AS Registro, Data, 'A', -1 AS ContaID, SUM(Valor) AS Valor, -1 AS InvestimentoID
        FROM #Tabela
        WHERE Valor IS NOT NULL
        GROUP BY Data;

    END;

    -- Variáveis para o cursor Total
    DECLARE @totRegistro       INT, 
            @totData           DATE, 
            @totContaID        INT, 
            @totValor          NUMERIC(19,2), 
            @totInvestimentoID INT;

    DECLARE @auxInvestimentoID INT,
            @auxValor   NUMERIC(19,2);

    DECLARE TOTAL CURSOR
    FOR SELECT #Tabela.Registro, #Tabela.Data, #Tabela.ContaID, #Tabela.Valor, #Tabela.InvestimentoID
        FROM #Tabela
        ORDER BY #Tabela.InvestimentoID ASC, #Tabela.Data ASC;

    OPEN TOTAL;

    FETCH NEXT FROM TOTAL
    INTO @totRegistro, @totData, @totContaID, @totValor, @totInvestimentoID;

    SET @auxInvestimentoID = -999;
    SET @auxValor   = 0;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        IF (@auxInvestimentoID = @totInvestimentoID)
        BEGIN

            INSERT INTO #Tabela
            SELECT -1, @totData, 'V', @totContaID, @totValor - @auxValor, @totInvestimentoID;

            SET @auxValor = @totValor;

        END
        ELSE ---IF (@auxContaID <> @totContaID)
        BEGIN

            SET @auxInvestimentoID = @totInvestimentoID;
            SET @auxValor = @totValor;

            INSERT INTO #Tabela
            SELECT -1, @totData, 'V', @totContaID, @totValor, @totInvestimentoID;

        END;


        FETCH NEXT FROM TOTAL
        INTO @totRegistro, @totData, @totContaID, @totValor, @totInvestimentoID;

    END;

    CLOSE TOTAL;
    DEALLOCATE TOTAL;

    DECLARE SAIDA CURSOR
    FOR SELECT DISTINCT #Tabela.InvestimentoID ContaID, COALESCE(Inv.Apelido, Cta.Apelido, 'Total') AS Apelido
        FROM #Tabela
	    LEFT JOIN Investimento Inv ON Inv.InvestimentoID = #Tabela.InvestimentoID
		LEFT JOIN Conta Cta ON Cta.ContaID = #Tabela.ContaID
		WHERE Valor <> 0
        ORDER BY Apelido ASC;

    OPEN SAIDA;

    FETCH NEXT FROM SAIDA 
    INTO @ContaID, @Apelido;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        SET @ColOrigem = @ColOrigem + '[' + CAST(@ContaID AS VARCHAR(6)) + '] AS ''' + @Apelido + '''';
        SET @ColDestino = @ColDestino + '[' + CAST(@ContaID AS VARCHAR(6)) + ']';

        FETCH NEXT FROM SAIDA 
        INTO @ContaID, @Apelido;

        IF @@FETCH_STATUS = 0
        BEGIN
            SET @ColOrigem = @ColOrigem + ', ';
            SET @ColDestino = @ColDestino + ', ';
        END;

    END;

    CLOSE SAIDA;
    DEALLOCATE SAIDA;

    DECLARE @Pivot VARCHAR(MAX);

	SET @Pivot = 'SELECT Data, ' +
                 'Tipo, ' + 
                 'CASE Tipo WHEN ''V'' THEN ''Variação'' ELSE ''Acumulado'' END Descricao, '+
                 @ColOrigem + ' FROM (SELECT Data, Tipo, InvestimentoID, Valor FROM #Tabela WHERE Valor <> 0) ORIGEM PIVOT (' +
                 'SUM(Valor) FOR InvestimentoID IN (' + @ColDestino + ')) FINAL '+
				 'WHERE Tipo = ''' + @Tipo + ''' OR ''' + @Tipo + ''' = ''T'' '+
				 'ORDER BY Data DESC, Tipo ASC;';

    EXEC (@Pivot);

    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpApuracaoMensalPorGrupoDeContas]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpApuracaoMensalPorGrupoDeContas](@Periodos INT = 24, @AteHoje BIT = 0)
AS
BEGIN

    DECLARE @Processados INT = 0;
    DECLARE @Hoje   DATE;
    DECLARE @Minimo DATE;

    DECLARE @Movimento TABLE (
        Data     DATE,
        ContaID  INT,
        Saldo    NUMERIC(19,2)
    );

    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;

    CREATE TABLE #Tabela (
        Data          DATE,
        GrupoContaID  INT,
        Apelido       VARCHAR(25),
        Saldo         NUMERIC(19,2),
        Ordem         INT
    );

    SELECT @Minimo = DtInicioUtilizacao, @Hoje = GETDATE()
    FROM MoneyPro WHERE MoneyProID = (SELECT MAX(MoneyProID) FROM MoneyPro);

    WHILE @Hoje >= @Minimo AND @Periodos > 0
    BEGIN
        
        IF (@Processados = 0 AND @AteHoje = 1)
        BEGIN

            -- Para saber o saldo do mês anterior (que é o saldo de abertura do mês atual)
            INSERT INTO @Movimento
            SELECT @Hoje, ContaID, SUM(Valor) + dbo.fncSaldoContaInvestimentoData(ContaID, @Hoje)  Saldo
            FROM MovimentoConta
            WHERE Data <= @Hoje
            GROUP BY ContaID;

            INSERT INTO #Tabela
            SELECT @Hoje, Grup.GrupoContaID, Grup.Apelido, SUM(Movt.Saldo) Saldo, Grup.Ordem
            FROM @Movimento Movt
                 INNER JOIN Conta Cnta ON Cnta.ContaID = Movt.ContaID
                 INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
                 INNER JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID AND Grup.Painel = 1
            GROUP BY Grup.GrupoContaID, Grup.Apelido, Grup.Ordem;

            -- Limpa tabela @Movimento
            DELETE FROM @Movimento;

            -- Um processado a mais
            SET @Processados = @Processados + 1;

        END
        ELSE IF (DAY(@Hoje) = 1)
        BEGIN

            -- Para saber o saldo do mês anterior (que é o saldo de abertura do mês atual)
            INSERT INTO @Movimento
            SELECT @Hoje, ContaID, SUM(Valor) + dbo.fncSaldoContaInvestimentoData(ContaID, DATEADD(DAY, -1, @Hoje))  Saldo
            FROM MovimentoConta
            WHERE Data <= DATEADD(DAY, -1, @Hoje)
            GROUP BY ContaID;

            INSERT INTO #Tabela
            SELECT @Hoje, Grup.GrupoContaID, Grup.Apelido, SUM(Movt.Saldo) Saldo, Grup.Ordem
            FROM @Movimento Movt
                 INNER JOIN Conta Cnta ON Cnta.ContaID = Movt.ContaID
                 INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
                 INNER JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID AND Grup.Painel = 1
            GROUP BY Grup.GrupoContaID, Grup.Apelido, Grup.Ordem;

            -- Limpa tabela @Movimento
            DELETE FROM @Movimento;

            -- Um processado a mais
            SET @Processados = @Processados + 1;


        END;

        SET @Hoje = DATEADD(DAY, -1, @Hoje);

    END;

----    SELECT * FROM #Tabela ORDER BY Apelido ASC, Data ASC;

    DECLARE @ColOrigem VARCHAR(MAX) = '';
    DECLARE @ColDestino VARCHAR(MAX) = '';

    DECLARE @GrupoContaID INT;
    DECLARE @Apelido VARCHAR(25);
    DECLARE @Ordem INT;

    DECLARE SAIDA CURSOR
    FOR SELECT DISTINCT GrupoContaID, Apelido, Ordem
        FROM #Tabela
        ORDER BY Ordem ASC;

    OPEN SAIDA;

    FETCH NEXT FROM SAIDA 
    INTO @GrupoContaID, @Apelido, @Ordem;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        SET @ColOrigem = @ColOrigem + '[' + CAST(@GrupoContaID AS VARCHAR(2)) + '] AS ''' + @Apelido + '''';
        SET @ColDestino = @ColDestino + '[' + CAST(@GrupoContaID AS VARCHAR(2)) + ']';


        FETCH NEXT FROM SAIDA 
        INTO @GrupoContaID, @Apelido, @Ordem;

        IF @@FETCH_STATUS = 0
        BEGIN
            SET @ColOrigem = @ColOrigem + ', ';
            SET @ColDestino = @ColDestino + ', ';
        END;

    END;


    CLOSE SAIDA;
    DEALLOCATE SAIDA;

    DECLARE @Pivot VARCHAR(MAX);

    SET @Pivot = 'SELECT Data, ' + @ColOrigem + ' FROM (SELECT Data, GrupoContaID, Saldo FROM #Tabela) ORIGEM PIVOT (' +
                 'SUM(Saldo) FOR GrupoContaID IN (' + @ColDestino + ')) FINAL ORDER BY Data ASC;';

    EXEC (@Pivot);

    DROP TABLE #Tabela;

    --SELECT Data, 
    --       [1] AS 'Disponivel', [2] AS 'Reserva', [3] AS 'Crédito', [4] AS 'Investimentos', [5] AS 'Bens e Direitos', [6] AS 'Deveres', [7] AS 'Outros'
    --FROM
    --(
    --    SELECT Data, GrupoContaID, Saldo
    --    FROM #Tabela
    --) ORIGEM
    --PIVOT
    --(
    --    SUM(Saldo) 
    --    FOR GrupoContaID IN ([1],[2],[3],[4],[5],[6],[7])
    --) FINAL
    --ORDER BY Data ASC;


END;
GO
/****** Object:  StoredProcedure [dbo].[stpApuracaoSemanalAcumulada]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpApuracaoSemanalAcumulada](@Periodos INT = 24)
AS
BEGIN

    DECLARE @Processados INT = 1;
    DECLARE @Hoje   DATE;
    DECLARE @Minimo DATE;

    DECLARE @Movimento TABLE (
        Data     DATE,
        ContaID  INT,
        Saldo    NUMERIC(19,2)
    );

    DECLARE @Tabela TABLE (
        Data          DATE,
        Saldo         NUMERIC(19,2)
    );

    SET @Hoje = GETDATE();

    SET @Minimo = DATEADD(WEEK, (@Periodos * -1), @Hoje);

    DECLARE @MinimoEntrou BIT = 0;

    WHILE @Hoje >= @Minimo AND @Processados < @Periodos
    BEGIN
        
        IF (@Hoje = @Minimo)
            SET @MinimoEntrou = 1;

        -- Para saber o saldo do mês anterior (que é o saldo de abertura do mês atual)
        INSERT INTO @Movimento
        SELECT @Hoje, Mvto.ContaID, SUM(Mvto.Valor * Coalesce(Ctac.Cotacao, 1)) + dbo.fncSaldoContaInvestimentoData(Mvto.ContaID, @Hoje)  Saldo
        FROM MovimentoConta Mvto
             INNER JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
             INNER JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID
             INNER JOIN Moeda Padr ON Padr.Padrao = 1
             LEFT JOIN CotacaoMoeda Ctac 
             ON Ctac.DeMoedaID = Cnta.MoedaID 
             AND Ctac.ParaMoedaID = (SELECT MoedaID FROM Moeda WHERE Padrao = 1)
             AND Moed.Padrao = 0 
             AND Ctac.Data = (SELECT MAX(Data) FROM CotacaoMoeda WHERE DeMoedaID = Ctac.DeMoedaID AND Data <= @Hoje)
        WHERE Mvto.Data <= @Hoje
        GROUP BY Mvto.ContaID;

        INSERT INTO @Tabela
        SELECT @Hoje, SUM(Movt.Saldo) Saldo
        FROM @Movimento Movt

        -- Limpa tabela @Movimento
        DELETE FROM @Movimento;

        -- Um processado a mais
        SET @Processados = @Processados + 1;

        SET @Hoje = DATEADD(DAY, -7, @Hoje);

    END;

    IF (@MinimoEntrou = 0) AND ((DATEADD(DAY, 7, @Hoje) > @Minimo))
    BEGIN

        -- O A data mínima estaria no período, porém a quantidade de dias entre hoje e o mínimo não é divisível por sete.
        -- Para saber o saldo do mês anterior (que é o saldo de abertura do mês atual)
        INSERT INTO @Movimento
        SELECT @Minimo, Mvto.ContaID, SUM(Mvto.Valor * Coalesce(Ctac.Cotacao, 1)) + dbo.fncSaldoContaInvestimentoData(Mvto.ContaID, @Minimo)  Saldo
        FROM MovimentoConta Mvto
             INNER JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
             INNER JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID
             INNER JOIN Moeda Padr ON Padr.Padrao = 1
             LEFT JOIN CotacaoMoeda Ctac 
             ON Ctac.DeMoedaID = Cnta.MoedaID 
             AND Ctac.ParaMoedaID = (SELECT MoedaID FROM Moeda WHERE Padrao = 1)
             AND Moed.Padrao = 0 
             AND Ctac.Data = (SELECT MAX(Data) FROM CotacaoMoeda WHERE DeMoedaID = Ctac.DeMoedaID AND Data <= @Minimo)
        WHERE Mvto.Data <= @Minimo
        GROUP BY Mvto.ContaID;

        INSERT INTO @Tabela
        SELECT @Minimo, SUM(Movt.Saldo) Saldo
        FROM @Movimento Movt

        -- Limpa tabela @Movimento
        DELETE FROM @Movimento;

    END;

    SELECT *
    FROM @Tabela
    ORDER BY Data ASC;


END;
GO
/****** Object:  StoredProcedure [dbo].[stpApuracaoSemanalPorGrupoDeContas]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpApuracaoSemanalPorGrupoDeContas](@Periodos INT = 24)
AS
BEGIN

    DECLARE @Processados INT = 1;
    DECLARE @Hoje   DATE;
    DECLARE @Minimo DATE;

    DECLARE @Movimento TABLE (
        Data     DATE,
        ContaID  INT,
        Saldo    NUMERIC(19,2)
    );

    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;


    CREATE TABLE #Tabela (
        Data          DATE,
        GrupoContaID  INT,
        Apelido       VARCHAR(25),
        Saldo         NUMERIC(19,2),
        Ordem         INT
    );

    SET @Hoje = GETDATE();

    SET @Minimo = DATEADD(WEEK, (@Periodos * -1), @Hoje);

    DECLARE @MinimoEntrou BIT = 0;

    WHILE @Hoje >= @Minimo AND @Processados < @Periodos
    BEGIN
        
        IF (@Hoje = @Minimo)
            SET @MinimoEntrou = 1;

        -- Para saber o saldo do mês anterior (que é o saldo de abertura do mês atual)
        INSERT INTO @Movimento
        SELECT @Hoje, ContaID, SUM(Valor) + dbo.fncSaldoContaInvestimentoData(ContaID, @Hoje)  Saldo
        FROM MovimentoConta
        WHERE Data <= @Hoje
        GROUP BY ContaID;

        INSERT INTO #Tabela
        SELECT @Hoje, Grup.GrupoContaID, Grup.Apelido, SUM(Movt.Saldo) Saldo, Grup.Ordem
        FROM @Movimento Movt
                INNER JOIN Conta Cnta ON Cnta.ContaID = Movt.ContaID
                INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
                INNER JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID AND Grup.Painel = 1
        GROUP BY Grup.GrupoContaID, Grup.Apelido, Grup.Ordem;

        -- Limpa tabela @Movimento
        DELETE FROM @Movimento;

        -- Um processado a mais
        SET @Processados = @Processados + 1;

        SET @Hoje = DATEADD(DAY, -7, @Hoje);

    END;

    IF (@MinimoEntrou = 0) AND ((DATEADD(DAY, 7, @Hoje) > @Minimo))
    BEGIN

        -- O A data mínima estaria no período, porém a quantidade de dias entre hoje e o mínimo não é divisível por sete.
        -- Para saber o saldo do mês anterior (que é o saldo de abertura do mês atual)
        INSERT INTO @Movimento
        SELECT @Minimo, ContaID, SUM(Valor) + dbo.fncSaldoContaInvestimentoData(ContaID, @Minimo)  Saldo
        FROM MovimentoConta
        WHERE Data <= @Minimo
        GROUP BY ContaID;

        INSERT INTO #Tabela
        SELECT @Minimo, Grup.GrupoContaID, Grup.Apelido, SUM(Movt.Saldo) Saldo, Grup.Ordem
        FROM @Movimento Movt
                INNER JOIN Conta Cnta ON Cnta.ContaID = Movt.ContaID
                INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
                INNER JOIN GrupoConta Grup ON Grup.GrupoContaID = Tipo.GrupoContaID AND Grup.Painel = 1
        GROUP BY Grup.GrupoContaID, Grup.Apelido, Grup.Ordem;

        -- Limpa tabela @Movimento
        DELETE FROM @Movimento;

    END;


    DECLARE @ColOrigem VARCHAR(MAX) = '';
    DECLARE @ColDestino VARCHAR(MAX) = '';

    DECLARE @GrupoContaID INT;
    DECLARE @Apelido VARCHAR(25);
    DECLARE @Ordem INT;

    DECLARE SAIDA CURSOR
    FOR SELECT DISTINCT GrupoContaID, Apelido, Ordem
        FROM #Tabela
        ORDER BY Ordem ASC;

    OPEN SAIDA;

    FETCH NEXT FROM SAIDA 
    INTO @GrupoContaID, @Apelido, @Ordem;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        SET @ColOrigem = @ColOrigem + '[' + CAST(@GrupoContaID AS VARCHAR(2)) + '] AS ''' + @Apelido + '''';
        SET @ColDestino = @ColDestino + '[' + CAST(@GrupoContaID AS VARCHAR(2)) + ']';


        FETCH NEXT FROM SAIDA 
        INTO @GrupoContaID, @Apelido, @Ordem;

        IF @@FETCH_STATUS = 0
        BEGIN
            SET @ColOrigem = @ColOrigem + ', ';
            SET @ColDestino = @ColDestino + ', ';
        END;

    END;


    CLOSE SAIDA;
    DEALLOCATE SAIDA;

    DECLARE @Pivot VARCHAR(MAX);

    SET @Pivot = 'SELECT Data, ' + @ColOrigem + ' FROM (SELECT Data, GrupoContaID, Saldo FROM #Tabela) ORIGEM PIVOT (' +
                 'SUM(Saldo) FOR GrupoContaID IN (' + @ColDestino + ')) FINAL ORDER BY Data ASC;';

    EXEC (@Pivot);

    DROP TABLE #Tabela;

    --SELECT Data, 
    --       [1] AS 'Disponivel', [2] AS 'Reserva', [3] AS 'Crédito', [4] AS 'Investimentos', [5] AS 'Bens e Direitos', [6] AS 'Deveres', [7] AS 'Outros'
    --FROM
    --(
    --    SELECT Data, GrupoContaID, Saldo
    --    FROM #Tabela
    --) ORIGEM
    --PIVOT
    --(
    --    SUM(Saldo) 
    --    FOR GrupoContaID IN ([1],[2],[3],[4],[5],[6],[7])
    --) FINAL
    --ORDER BY Data ASC;


END;
GO
/****** Object:  StoredProcedure [dbo].[stpAtualizaAcoesBOVESPA]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpAtualizaAcoesBOVESPA]
AS
BEGIN

    INSERT INTO InvestimentoCotacao
    (Investimentoid, Data, VrCotacao, CotacaoDaBOVESPA)
    SELECT Cota.InvestimentoID, Cota.Data, Cota.Ultimo, 1
    FROM AcaoCotacao Cota
    WHERE FORMAT(Cota.InvestimentoID, '0000') + FORMAT(Cota.Data, 'yyyyMMdd') NOT IN (SELECT FORMAT(Invt.InvestimentoID, '0000') + FORMAT(Invt.Data, 'yyyyMMdd')
                                                                                      FROM InvestimentoCotacao Invt
                                                                                      WHERE Invt.CotacaoDaBOVESPA = 1);

END;
GO
/****** Object:  StoredProcedure [dbo].[stpAtualizaBalancoConta]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[stpAtualizaBalancoConta]
    @ContaID INT,
    @DataInicioAtualizacao DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    -- Desabilita a trigger para evitar chamada recursiva
    ALTER TABLE MovimentoConta DISABLE TRIGGER tgrMovimentoConta_ALL;

    -- Variáveis auxiliares
    DECLARE @Balanco           NUMERIC(22,10),
            @PilhaMovimentoID  INT;

    -- Variáveis utilizadas no cursor
    DECLARE @MovimentoContaID  INT,
            @Valor             NUMERIC(22,10);

    SET @Balanco = 0;
    
    DECLARE Movtos CURSOR
    FOR SELECT 
           Mvto.MovimentoContaID, 
           Mvto.Valor
        FROM MovimentoConta Mvto
        WHERE Mvto.ContaID = @ContaID
        ORDER BY CASE WHEN Conciliacao IN ('A','F') THEN 1 ELSE 0 END ASC, 
                 Data ASC, MovimentoContaID;

    OPEN Movtos;

    FETCH NEXT FROM Movtos 
    INTO @MovimentoContaID, @Valor;

    WHILE (@@FETCH_STATUS = 0)
    BEGIN

        SET @Balanco = @Balanco + @Valor;

        UPDATE MovimentoConta
        SET Balanco = @Balanco,
            PilhaMovimentoContaID = @PilhaMovimentoID
        WHERE MovimentoContaID = @MovimentoContaID;

        -- Retem o número do movimento atual para informá-lo no próximo movimento
        SET @PilhaMovimentoID = @MovimentoContaID;

        FETCH NEXT FROM Movtos 
        INTO @MovimentoContaID, @Valor;
    END;

    CLOSE Movtos;
    DEALLOCATE Movtos;

    -- Reabilita a trigger após montagem do balanço e pilha de lançamentos
    ALTER TABLE MovimentoConta ENABLE TRIGGER tgrMovimentoConta_ALL;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpAtualizaBalancoContaPeriodo]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[stpAtualizaBalancoContaPeriodo]
    @ContaID INT,
    @DataInicioAtualizacao DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    -- Desabilita a trigger para evitar chamada recursiva
    ALTER TABLE MovimentoConta DISABLE TRIGGER tgrMovimentoConta_ALL;

    -- Variáveis auxiliares
    DECLARE @Balanco           NUMERIC(22,10),
            @PilhaMovimentoID  INT;
             
    -- Variáveis utilizadas no cursor
    DECLARE @MovimentoContaID  INT,
            @Valor             NUMERIC(22,10);

    SELECT @Balanco = SUM(COALESCE(MCta.Credito, 0.0)) - SUM(COALESCE(MCta.Debito, 0.0)) 
    FROM MovimentoConta MCta 
    WHERE MCta.ContaID = @ContaID
    AND   MCta.Data < @DataInicioAtualizacao;

    SELECT TOP 1 
           @PilhaMovimentoID = Mvto.PilhaMovimentoContaID
    FROM MovimentoConta Mvto
    WHERE Mvto.ContaID = @ContaID
    AND   Mvto.Data < @DataInicioAtualizacao
    ORDER BY CASE WHEN Conciliacao IN ('A','F') THEN 1 ELSE 0 END ASC, 
             Data ASC, MovimentoContaID;

    DECLARE cMovimentos CURSOR LOCAL
    FOR SELECT 
            Mvto.MovimentoContaID, 
            Mvto.Valor
        FROM MovimentoConta Mvto
        WHERE Mvto.ContaID = @ContaID
        AND   Mvto.Data >= @DataInicioAtualizacao
        ORDER BY CASE WHEN Conciliacao IN ('A','F') THEN 1 ELSE 0 END ASC, 
                Data ASC, MovimentoContaID;

    OPEN cMovimentos;

    FETCH NEXT FROM cMovimentos 
    INTO @MovimentoContaID, @Valor;

    WHILE (@@FETCH_STATUS = 0)
    BEGIN

        SET @Balanco = COALESCE(@Balanco, 0) + @Valor;

        UPDATE MovimentoConta
        SET Balanco = @Balanco,
            PilhaMovimentoContaID = @PilhaMovimentoID
        WHERE MovimentoContaID = @MovimentoContaID;

        -- Retem o número do movimento atual para informá-lo no próximo movimento
        SET @PilhaMovimentoID = @MovimentoContaID;

        FETCH NEXT FROM cMovimentos 
        INTO @MovimentoContaID, @Valor;
    END;

    CLOSE cMovimentos;
    DEALLOCATE cMovimentos;

    -- Reabilita a trigger após montagem do balanço e pilha de lançamentos
    ALTER TABLE MovimentoConta ENABLE TRIGGER tgrMovimentoConta_ALL;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpAtualizaBalancoInvestimento]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[stpAtualizaBalancoInvestimento]
    @InvestimentoID INT,
    @DataInicioAtualizacao DATETIME
AS
BEGIN

   -- Variáveis auxiliares
   DECLARE @SaldoCotas NUMERIC(18,6);

   -- Pega a data e hora inicial para contar o tempo.
--   SET @Inicio = GETDATE();

   -- Variáveis utilizadas no cursor
   DECLARE @MovimentoInvestimentoID  INT,
           @QtCotas                  NUMERIC(18,6);

   DECLARE Movtos CURSOR
   FOR SELECT 
          Mvto.MovimentoInvestimentoID, 
          Mvto.QtCotas
       FROM MovimentoInvestimento Mvto
            INNER JOIN MovimentoConta Cnta ON Cnta.MovimentoContaID = Mvto.MovimentoContaID
       WHERE Mvto.InvestimentoID = @InvestimentoID
       ORDER BY Cnta.Data, CASE WHEN Cnta.Valor >= 0 THEN 1 ELSE 2 END, Mvto.MovimentoInvestimentoID;

    OPEN Movtos;

    SET @SaldoCotas = 0;

    FETCH NEXT FROM Movtos 
    INTO @MovimentoInvestimentoID, @QtCotas;

    WHILE (@@FETCH_STATUS = 0)
    BEGIN

--    select @MovimentoContaID as Movimento

        SET @SaldoCotas = @SaldoCotas + @QtCotas;

        UPDATE MovimentoInvestimento
        SET SldCotas = @SaldoCotas
        WHERE MovimentoInvestimentoID = @MovimentoInvestimentoID;

        FETCH NEXT FROM Movtos 
        INTO @MovimentoInvestimentoID, @QtCotas;
    END;

    CLOSE Movtos;
    DEALLOCATE Movtos;

----    SELECT CAST(GETDATE() - @Inicio AS FLOAT) AS TempoGasto;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpAtualizaCarteiraFundos]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpAtualizaCarteiraFundos](@Data DATE)
AS
BEGIN

    SET NOCOUNT OFF;

    DECLARE @Afetadas INT = 0;

    DECLARE @InvestimentoCotacaoID INT;    
    DECLARE @CVMInvestimentoID INT;
    DECLARE @CVMCotacao NUMERIC(18,6);

    DECLARE cotacoes CURSOR
    FOR SELECT Invt.InvestimentoID, CVM.VrCotacao
        FROM CotacaoCVM CVM
        INNER JOIN Investimento Invt
        ON RIGHT('00'+CAST(CVM.CNPJ AS VARCHAR(15)),14) = RIGHT(CAST(REPLACE(REPLACE(REPLACE(Invt.Consulta, '.', ''), '/', ''), '-', '') AS VARCHAR(15)),14)
		AND CVM.Data = @Data;

    OPEN Cotacoes;

    FETCH NEXT FROM cotacoes 
    INTO @CVMInvestimentoID, @CVMCotacao;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        IF (EXISTS(SELECT *
                   FROM InvestimentoCotacao
                   WHERE InvestimentoID = @CVMInvestimentoID 
                   AND Data = @Data)) 
        BEGIN
            SELECT @InvestimentoCotacaoID = InvestimentoCotacaoID 
            FROM InvestimentoCotacao
            WHERE InvestimentoID = @CVMInvestimentoID 
            AND Data = @Data
        END
        ELSE
        BEGIN
            SET @InvestimentoCotacaoID = NULL;
        END;

        IF (@InvestimentoCotacaoID IS NULL)
        BEGIN        
            INSERT InvestimentoCotacao
            (InvestimentoID, Data, VrCotacao, CotacaoDaCVM)
            VALUES
            (@CVMInvestimentoID, @Data, @CVMCotacao, 1);

            SET @Afetadas = @Afetadas + @@ROWCOUNT;
        END
        ELSE
        BEGIN

            -- Somente atualiza cotações provenientes da própria CVM,
            -- cotações digitadas podem ter maior precisão, pois são 
            -- provenientes da informação do banco ou financeira
            UPDATE InvestimentoCotacao SET
            VrCotacao = @CVMCotacao
            WHERE InvestimentoCotacaoID = @InvestimentoCotacaoID
            AND   CotacaoDaCVM = 1;

            SET @Afetadas = @Afetadas + @@ROWCOUNT;
        END;

        FETCH NEXT FROM cotacoes 
        INTO @CVMInvestimentoID, @CVMCotacao;
    END;
    
    CLOSE Cotacoes;
    DEALLOCATE cotacoes;

    SELECT @Afetadas AS Afetadas;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpAtualizaCotacao]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpAtualizaCotacao]
    @InvestimentoID INT,
    @Data DATETIME,
    @VrCotacao NUMERIC(19,10),
    @ForcaAtualizacao BIT = 0
AS
BEGIN

    SET NOCOUNT ON;

    DECLARE @InvestimentoCotacaoID INT;


    -- Tenta recuperar a ID da cotação
    SELECT @InvestimentoCotacaoID = InvestimentoCotacaoID
    FROM InvestimentoCotacao
    WHERE InvestimentoID = @InvestimentoID
      AND Data = @Data;

    IF (@InvestimentoCotacaoID IS NULL)
    BEGIN
        -- Se não encontrou, inclui a nova cotação
        INSERT INTO InvestimentoCotacao
        (InvestimentoID, Data, VrCotacao, CotacaoDaCVM)
        VALUES
        (@InvestimentoID, @Data, @VrCotacao, 0);

        SELECT @InvestimentoCotacaoID = CAST(@@IDENTITY AS INT);
    END
    ELSE
    BEGIN

        IF (@ForcaAtualizacao = 0) 
        BEGIN
            -- Somente atualiza se a cotação não foi pega na CVM
            UPDATE InvestimentoCotacao
            SET VrCotacao = @VrCotacao
            WHERE InvestimentoCotacaoID = @InvestimentoCotacaoID 
            AND   CotacaoDaCVM = 0;
        END
        ELSE
        BEGIN
            -- Atualiza mesmo que a cotação foi pega na CVM            
            UPDATE InvestimentoCotacao
            SET VrCotacao = @VrCotacao,
                CotacaoDaCVM = 0  -- Marca que a cotação não é proveniente da CVM
            WHERE InvestimentoCotacaoID = @InvestimentoCotacaoID;
        END;
          
    END;

    SELECT @InvestimentoCotacaoID;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpAtualizaCotacaoEspecificaCVM]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[stpAtualizaCotacaoEspecificaCVM] (@InvestimentoID INT)
AS
BEGIN

    SET NOCOUNT ON;

	-- Atualiza tabela com as cotações da CVM
	MERGE INVESTIMENTOCOTACAO AS DESTINO
	USING (SELECT INVE.InvestimentoID, CCVM.Data, CCVM.VrCotacao, 1 CotacaoDaCVM, 0 CotacaoDaBovespa
		   FROM INVESTIMENTO INVE
				 JOIN COTACAOCVM CCVM ON CCVM.CNPJ = INVE.Consulta) AS ORIGEM
	ON (DESTINO.InvestimentoID = ORIGEM.InvestimentoID AND DESTINO.Data = ORIGEM.Data)
	WHEN MATCHED THEN
	   UPDATE 
		  SET DESTINO.VrCotacao = CASE WHEN DESTINO.CotacaoDaCVM = 0 THEN ORIGEM.VrCotacao ELSE DESTINO.VrCotacao END
	WHEN NOT MATCHED THEN
	   INSERT
	   (InvestimentoID, Data, VrCotacao, CotacaoDaCVM, CotacaoDaBovespa)
	   VALUES
	   (ORIGEM.InvestimentoID, Origem.Data, Origem.VrCotacao, Origem.CotacaoDaCVM, Origem.CotacaoDaBovespa);

END;
GO
/****** Object:  StoredProcedure [dbo].[stpAtualizaCotacoesCVM]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[stpAtualizaCotacoesCVM]
AS
BEGIN

    SET NOCOUNT ON;

	-- Atualiza tabela com as cotações da CVM
	MERGE INVESTIMENTOCOTACAO AS DESTINO
	USING (SELECT INVE.InvestimentoID, CCVM.Data, CCVM.VrCotacao, 1 CotacaoDaCVM, 0 CotacaoDaBovespa
		   FROM INVESTIMENTO INVE
				 JOIN COTACAOCVM CCVM ON CCVM.CNPJ = INVE.Consulta) AS ORIGEM
	ON (DESTINO.InvestimentoID = ORIGEM.InvestimentoID AND DESTINO.Data = ORIGEM.Data)
	WHEN MATCHED THEN
	   UPDATE 
		  SET DESTINO.VrCotacao = CASE WHEN DESTINO.CotacaoDaCVM = 0 THEN ORIGEM.VrCotacao ELSE DESTINO.VrCotacao END
	WHEN NOT MATCHED THEN
	   INSERT
	   (InvestimentoID, Data, VrCotacao, CotacaoDaCVM, CotacaoDaBovespa)
	   VALUES
	   (ORIGEM.InvestimentoID, Origem.Data, Origem.VrCotacao, Origem.CotacaoDaCVM, Origem.CotacaoDaBovespa);

END;
GO
/****** Object:  StoredProcedure [dbo].[stpDataMinimaParaPegarCotacao]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/**************************************************
 Lista moedas para baixar cotação do Banco Central

 Elcio Reis - 12/09/2019

 Exemplo de Execução:
 EXEC stpDataMinimaParaPegarCotacao;
 **************************************************/

CREATE PROCEDURE [dbo].[stpDataMinimaParaPegarCotacao]

AS

BEGIN

    -- Seleciona a maior data da tabela de cotações e a menor data de abertura da tabela de contas.
    -- Retorna a maior dentre as duas para dar o início à carga das cotações a partir de WebService do Banco Central.

    WITH Fase01 AS (SELECT Mda.MoedaID DeMoedaID, Pda.MoedaID ParaMoedaID, MAX(CtM.Data) Data, Mda.CodigoMoedaBancoCentral
                    FROM Conta Cta
                         JOIN Moeda Pda ON Pda.Padrao = 1
                         JOIN Moeda Mda ON Mda.MoedaID = Cta.MoedaID
                                       AND Mda.CodigoMoedaBancoCentral IS NOT NULL
                         JOIN CotacaoMoeda CtM ON CtM.DeMoedaID = Mda.MoedaID
                                              AND CtM.ParaMoedaID = Pda.MoedaID
                    WHERE Cta.MoedaID <> Pda.MoedaID
                    GROUP BY Mda.MoedaID, Pda.MoedaID, Mda.CodigoMoedaBancoCentral

                    UNION ALL

                    SELECT Mda.MoedaID DeMoedaID, Pda.MoedaID ParaMoedaID, MIN(Cta.DataAbertura) Data, Mda.CodigoMoedaBancoCentral
                    FROM Conta Cta
                         JOIN Moeda Pda ON Pda.Padrao = 1
                         JOIN Moeda Mda ON Mda.MoedaID = Cta.MoedaID
                                       AND Mda.CodigoMoedaBancoCentral IS NOT NULL
                    WHERE Cta.MoedaID <> Pda.MoedaID
                    GROUP BY Mda.MoedaID, Pda.MoedaID, Mda.CodigoMoedaBancoCentral)
    SELECT Fs01.DeMoedaID, De.Simbolo DeMoeda, Fs01.ParaMoedaID, Para.Simbolo ParaMoeda, Fs01.CodigoMoedaBancoCentral, CAST(MAX(Fs01.Data) AS DATE) Data
    FROM Fase01 Fs01
         JOIN Moeda De ON De.MoedaID = Fs01.DeMoedaID
         JOIN Moeda Para ON Para.MoedaID = Fs01.ParaMoedaID
    GROUP BY Fs01.DeMoedaID, De.Simbolo, Fs01.ParaMoedaID, Para.Simbolo, Fs01.CodigoMoedaBancoCentral
    ORDER BY DeMoedaID, ParaMoedaID;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpDataParaPesquisa]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************
 EXEC stpDataParaPesquisa 'M'
 ********************************************************************************/

CREATE PROCEDURE [dbo].[stpDataParaPesquisa]
    @Tipo CHAR(1) = 'M',
    @DtInicio DATETIME = NULL
AS
BEGIN

    SET NOCOUNT ON

    DECLARE @DtAtual       DATETIME,
            @DtUltima      DATETIME,
            @Mes           INT;


    DECLARE @tblData TABLE (
        Data   DATETIME
    );
    
    -- Pega a última data de arquivos da CVM
    SELECT @DtUltima = MAX(Data) FROM InvestimentoCotacao;

    -- Se a data inicial for nula, busca a data inicial na tabela de parâmetros
    IF @DtInicio IS NULL
    BEGIN

        SELECT 
            @DtInicio = DtInicioUtilizacao
        FROM MoneyPro 
        WHERE MoneyProID = (SELECT MAX(MoneyProID) FROM MoneyPro);

    END;

    -- Pega a última data de atualização antes do início do periodo
    SELECT @DtAtual = MAX(Data)
    FROM InvestimentoCotacao
    WHERE Data < @DtInicio

    -- Insere a última data antes do período
    INSERT INTO @tblData
    (Data)
    VALUES
    (@DtAtual);

    -- Coloca a data atual igual ao início do período
    SET @DtAtual = @DtInicio;

    IF (@Tipo = 'M') -- Mensal
    BEGIN

        WHILE (@DtAtual <= GETDATE())
        BEGIN
            
            SET @Mes = MONTH(@DtAtual);

            -- Avança até o primeiro dia do mês seguinte
            WHILE (@Mes = MONTH(@DtAtual))
            BEGIN
               SET @DtAtual = @DtAtual + 1;                
            END;

            IF (@DtAtual <= GETDATE())
            BEGIN
                INSERT INTO @tblData
                (Data)
                VALUES
                (@DtAtual - 1);
            END;

        END;

        IF (NOT EXISTS (SELECT * FROM @tblData WHERE YEAR(Data) = YEAR(@DtUltima) AND   MONTH(Data) = MONTH(@DtUltima)))
        BEGIN
            -- Inclui a última data de cotação da CVM
            INSERT INTO @tblData
            (Data)
            VALUES
            (@DtUltima);
        END;

    END
    ELSE IF @Tipo = 'D'
    BEGIN

        WHILE (@DtAtual <= @DtUltima)
        BEGIN

            IF NOT (DATEPART(WEEKDAY, @DtAtual) = 1 OR DATEPART(WEEKDAY, @DtAtual) = 7)
            BEGIN
                INSERT INTO @tblData
                (Data)
                VALUES
                (@DtAtual);
            END;

            SET @DtAtual = @DtAtual + 1;                
        END;

    END
    ELSE IF @Tipo = 'U'
    BEGIN

        WHILE (@DtAtual <= @DtUltima)
        BEGIN

            IF NOT (DATEPART(WEEKDAY, @DtAtual) = 1 OR DATEPART(WEEKDAY, @DtAtual) = 7)
            BEGIN

                --IF (EXISTS (SELECT Data FROM InvestimentoCotacao WHERE Data = @DtAtual))
                --BEGIN

                    INSERT INTO @tblData
                    (Data)
                    VALUES
                    (@DtAtual);

                --END;
            END;

            SET @DtAtual = @DtAtual + 1;                
        END;

        DELETE FROM @tblData where Data NOT IN (SELECT Data FROM InvestimentoCotacao);

    END;

    SELECT Data FROM @tblData;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpDetalhesInvestimento]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/************************************************************************************
 Empilha as compras de cotas e vai fazendo a venda 
 das cotas mais antigas para apurar lucro ou perda
 Exemplo:
 EXEC stpDetalhesInvestimento 1
 ************************************************************************************/
CREATE PROC [dbo].[stpDetalhesInvestimento] 
--create PROC [dbo].[stpDetalhesInvestimento_20161105] 
    @InvestimentoID INT,
    @Data           DATETIME = NULL,
    @Resumo         BIT = 0,
    @Tudo           BIT = 1
AS
BEGIN

    SET NOCOUNT ON;

    IF (@Data IS NULL)
        SET @Data = GETDATE();

    -- Variáveis para o cursor
    DECLARE @curLoteID        INT,
            @curData          DATETIME,
            @curQtCotas       NUMERIC(18,8),
            @curVrCotacaoDia  NUMERIC(18,8),
            @curVrCusto       NUMERIC(18,8),
			@curVrBruto       NUMERIC(18,8),
			@curVrImpostos    NUMERIC(18,8),
            @curVrLiquido     NUMERIC(18,8),
            @curSaldoCotas    NUMERIC(18,8),
            @curVrSaldoAcum   NUMERIC(18,8);
            
    -- Variáveis auxiliares
    DECLARE @DetalheID INT;
    DECLARE @AcumuladorCotas NUMERIC(18,8);

    -- Tabela base
    DECLARE @Base TABLE (
        ContaID        INT NOT NULL,
        MovimentoID    INT NOT NULL,
        LoteID         INT NOT NULL,
        DetalheID      INT NOT NULL DEFAULT 0,
        Data           DATE,
        Transacao      VARCHAR(40),
        QtCotas        NUMERIC(18,8),
        VrCotacaoDia   NUMERIC(18,8),
        VrCusto        NUMERIC(18,8),
		VrBruto        NUMERIC(18,8),
		VrImpostos     NUMERIC(18,8),
        VrLiquido      NUMERIC(18,8),
        SaldoCotas     NUMERIC(18,8),
        VrSaldoAcum    NUMERIC(18,8),
        DtVenda        DATE,
        VrPendente     NUMERIC(18,8)
    );

    -- Tabela de compras
    INSERT INTO @Base
    (ContaID, MovimentoID, LoteID, Data, Transacao, QtCotas, VrCotacaoDia, VrCusto, SaldoCotas)
    SELECT 
        Mvto.ContaID,
        Mvto.MovimentoContaID,
        ROW_NUMBER() OVER (ORDER BY Mvto.Data) AS LoteID,
        Mvto.Data,
        Trns.Apelido AS Transacao,
        MvIn.QtCotas,
        Cota.VrCotacao,
        ROUND(MvIn.QtCotas * Cota.VrCotacao, 2) AS VrCusto,
        MvIn.QtCotas
    FROM Investimento Invt
         INNER JOIN MovimentoInvestimento MvIn
           ON MvIn.InvestimentoID = Invt.InvestimentoID
         INNER JOIN Transacao Trns
           ON Trns.TransacaoID = MvIn.TransacaoID
         INNER JOIN MovimentoConta Mvto
           ON Mvto.MovimentoContaID = MvIn.MovimentoContaID
         INNER JOIN InvestimentoCotacao Cota
           ON Cota.InvestimentoID = Invt.InvestimentoID
          AND Cota.Data = Mvto.Data
    WHERE Invt.InvestimentoID = @InvestimentoID
      AND Mvto.Data <= @Data
      AND MvIn.QtCotas >= 0
    ORDER BY Mvto.Data ASC;

    -- Tabela de vendas
    DECLARE @Vendas TABLE (
        ContaID       INT NOT NULL,
        MovimentoID   INT NOT NULL,
        VendaID       INT NOT NULL IDENTITY(1,1),
        Data          DATE,
        Transacao     VARCHAR(40),
        QtCotas       NUMERIC(18,8),
        VrCotacaoDia  NUMERIC(18,8),
		VrBruto       NUMERIC(18,8),
		VrImpostos    NUMERIC(18,8),
        VrTransacao   NUMERIC(18,8),
        SaldoCotas    NUMERIC(18,8)
    );

    INSERT INTO @Vendas
    (ContaID, MovimentoID, Data, Transacao, QtCotas, VrCotacaoDia, VrBruto, VrImpostos, VrTransacao, SaldoCotas)
    SELECT
        Mvto.ContaID,
        Mvto.MovimentoContaID,
        Mvto.Data,
        Trns.Apelido As Transacao,
        ABS(MvIn.QtCotas) AS QtCotas,
        Cota.VrCotacao,
		Mvin.VrBruto,
        Mvin.VrBruto - MvIn.VrLiquido,
        MvIn.VrLiquido AS VrTransacao,
        ABS(MvIn.QtCotas) AS SaldoCotas
    FROM Investimento Invt
         INNER JOIN MovimentoInvestimento MvIn
           ON MvIn.InvestimentoID = Invt.InvestimentoID
          AND (MvIn.VrLiquido <> 0 OR @Tudo = 1)
         INNER JOIN Transacao Trns
           ON Trns.TransacaoID = MvIn.TransacaoID
         INNER JOIN MovimentoConta Mvto
           ON Mvto.MovimentoContaID = MvIn.MovimentoContaID
         INNER JOIN InvestimentoCotacao Cota
           ON Cota.InvestimentoID = Invt.InvestimentoID
          AND Cota.Data = Mvto.Data
    WHERE Invt.InvestimentoID = @InvestimentoID
      AND Mvto.Data <= @Data
      AND MvIn.QtCotas < 0
    ORDER BY Mvto.Data ASC;


    DECLARE AtualizaBase CURSOR
    FOR SELECT LoteID, Data, QtCotas, VrCotacaoDia, SaldoCotas, VrSaldoAcum
        FROM @Base
        ORDER BY LoteID ASC;

    OPEN AtualizaBase;

    FETCH NEXT FROM AtualizaBase
    INTO @curLoteID, @curData, @curQtCotas, @curVrCotacaoDia, @curSaldoCotas, @curVrSaldoAcum;

    SET @AcumuladorCotas = 0;

    SET @DetalheID = 0;

    DECLARE @VendaID INT = 0;
    DECLARE @ContaID INT;
    DECLARE @MovimentoID INT;
    DECLARE @CotasVendidas NUMERIC(18,8);
    DECLARE @CotasDescontada NUMERIC(18,8);
    DECLARE @VrCotacaoDiaVnd NUMERIC(18,8);
	DECLARE @VrBruto NUMERIC(18,8);
    DECLARE @VrTransacao NUMERIC(18,8);
    DECLARE @VrImposto NUMERIC(18,8);
	DECLARE @VrImpostoParcial NUMERIC(18,8);
    DECLARE @VrProcessado NUMERIC(18,8) = 0;
    DECLARE @UltimoSaldoCotas NUMERIC(18,8) = 0;
	DECLARE @VrImpostoPago NUMERIC(18,8) = 0;
	DECLARE @VrBrutoProce NUMERIC(18,8) = 0;

    --DECLARE @TESTE VARCHAR(20);

    WHILE (@@FETCH_STATUS = 0)
    BEGIN
       
        SET @DetalheID = 1;

        WHILE (@curSaldoCotas > 0 AND NOT @VendaID IS NULL)
        BEGIN

            -- Se a query abaixo retornar nulo, não altera o valor atual de @VendaID, por isso atribuo null antes.
            SET @VendaID = NULL;

            SELECT TOP 1
                @ContaID = Vnds.ContaID,
                @MovimentoID = Vnds.MovimentoID,
                @VendaID = Vnds.VendaID,
				@VrImposto = Vnds.VrImpostos,
                @CotasVendidas = Vnds.SaldoCotas,
                @VrCotacaoDiaVnd = Vnds.VrCotacaoDia,
				@VrBruto = Vnds.VrBruto,
                @VrTransacao = Vnds.VrTransacao - @VrProcessado
            FROM @Vendas Vnds
            WHERE Vnds.SaldoCotas > 0
            ORDER BY Vnds.VendaID ASC;

            -- Encontrei a primeira venda
            IF (NOT @VendaID IS NULL)
            BEGIN

				--
				-- Trata a necessidade de se vendar cotas compradas em períodos distintos caso a venda seja maior que o lote atual.
				--
                IF (@CotasVendidas <= @curSaldoCotas)
                BEGIN
                    -- A Quantidade vendida é menor que o saldo, portanto não haverá valor pendente.
                    SET @CotasDescontada = @CotasVendidas;
                    SET @VrProcessado = 0;
					-- Trata o valor bruto
					SET @VrBruto = @VrBruto - @VrBrutoProce;
                    --SET @VrBruto = (@CotasDescontada * @VrCotacaoDiaVnd);
					SET @VrBrutoProce = 0;
					-- Trata o imposto
					SET @VrImposto = @VrImposto - @VrImpostoPago;
					SET @VrImpostoPago = 0;

                    --SET @TESTE = 'Atendeu';

                END
                ELSE
                BEGIN
                    -- A quantidade vendida é maior que o saldo, portanto deixará valor pendente.
                    SET @CotasDescontada = @curSaldoCotas;
                    SET @VrProcessado = (@VrTransacao * (@CotasDescontada / @CotasVendidas));
					-- Trata o valor bruto
					--SET @VrBruto = (@VrBruto * (@CotasDescontada / @CotasVendidas));
                    SET @VrBruto = (@CotasDescontada * @VrCotacaoDiaVnd);
					SET @VrBrutoProce = @VrBrutoProce + @VrBruto;
					-- Trata o imposto
					SET @VrImposto = (@VrImposto * (@CotasDescontada / @CotasVendidas));
					SET @VrImpostoPago = @VrImpostoPago + @VrImposto;

                    --SET @TESTE = 'Não Atendeu';

                END;

                INSERT INTO @Base
                (ContaID, MovimentoID, LoteID, DetalheID, Data, Transacao,
                 QtCotas, VrCotacaoDia, 
                 VrCusto,
				 VrBruto,
                 VrImpostos,
                 VrLiquido, 
				 SaldoCotas, DtVenda, VrPendente)
                SELECT 
                    @ContaID, @MovimentoID, @curLoteID, @DetalheID, @curData, Transacao,
                    @CotasDescontada AS QtCotas, VrCotacaoDia, 
                    (@CotasDescontada * @curVrCotacaoDia) AS VrCusto,
					@VrBruto AS VrBruto,
					@VrImposto AS VrImposto,
                    @VrBruto - @VrImposto AS VrLiquido,
                    (@curSaldoCotas - @CotasDescontada) AS SaldoCotas, 
                    Data,
                    @VrProcessado
                FROM @Vendas
                WHERE VendaID = @VendaID;

                SET @curSaldoCotas = @curSaldoCotas - @CotasDescontada;

                UPDATE @Vendas
                SET SaldoCotas = SaldoCotas - @CotasDescontada
                WHERE VendaID = @VendaID;

                SET @DetalheID = @DetalheID + 1;

                SET @UltimoSaldoCotas = @curSaldoCotas;

                --select @MovimentoID MovimentoID, @curData curData, @TESTE Teste, @CotasDescontada CotasDescontadas, @curVrCotacaoDia curVrCotacaoDia, (@CotasDescontada * @curVrCotacaoDia) VrCusto, (@CotasDescontada * @VrCotacaoDiaVnd) VrVenda, @VrBruto VrBruto, @VrBrutoProce VrBrutoProce;

                ---select @MovimentoID MovimentoID, @curData curData, (@CotasDescontada * @curVrCotacaoDia) VrCusto, @CotasDescontada CotasDescontada, @curVrCotacaoDia curVrCotacaoDia, @VrProcessado VrProcessado, @VrBruto VrBruto, @VrBrutoProce VrBrutoProce, @VrImposto VrImposto, @VrImpostoPago VrImpostoPago, @curSaldoCotas curSaldoCotas, @Teste Situacao, @DetalheID Detalhe;


            END;

        END;

        -- Se @DetalheID = 1 é porque não passou pelo loop, logo, não se trata de uma venda.
        IF @DetalheID = 1
        BEGIN

            UPDATE @Base
            SET SaldoCotas = QtCotas + @UltimoSaldoCotas
            WHERE LoteID = @curLoteID;

            SELECT @UltimoSaldoCotas = SaldoCotas
            FROM @Base
            WHERE LoteID = @curLoteID;

        END;

        FETCH NEXT FROM AtualizaBase
        INTO @curLoteID, @curData, @curQtCotas, @curVrCotacaoDia, @curSaldoCotas, @curVrSaldoAcum;
    END;

    CLOSE AtualizaBase;
    DEALLOCATE AtualizaBase;

    DECLARE @Resposta TABLE (
        InvestimentoID    INT,
        ContaID           INT,
        MovimentoID       INT,
        LoteID            INT,
        DetalheID         INT,
        DtMovimento       DATE,
        DtLote            DATE,
        Transacao         VARCHAR(40),
        Lote              VARCHAR(20),
        QtCotas           NUMERIC(18,8),
        SaldoCotas        NUMERIC(18,8),
        VrCotacaoDia      NUMERIC(18,8),
        VrCusto           FLOAT,
		VrBruto           FLOAT,
		VrImpostos        FLOAT,
        VrLiquido         FLOAT,
        VrLucroOuPerda    FLOAT,
        PercLucroOuPerda  FLOAT,
        Indicador         VARCHAR(20),
        VrPendente        NUMERIC(18,8)
    );


    INSERT INTO @Resposta
    SELECT 
        @InvestimentoID AS InvestimentoID,
        ContaID,
        MovimentoID,
        LoteID,
        DetalheID,
        COALESCE(DtVenda, Data) AS DtMovimento,
        Data AS DtLote,
        Transacao,
        'Lote ' + CONVERT(VARCHAR(10), Data, 103) AS Lote,
        QtCotas,   
        SaldoCotas,
        VrCotacaoDia, 
        VrCusto,
		VrBruto,
		VrImpostos,
        VrLiquido,
        (VrLiquido - VrCusto) AS VrLucroOuPerda,
        CASE
            WHEN ROUND(COALESCE(VrLiquido, 0.0), 2) <> 0.0 THEN (VrLiquido - VrCusto) / ROUND(VrLiquido, 2) * 100.0
            WHEN NOT VrLiquido IS NULL THEN -100
            ELSE NULL
        END AS PercLucroOuPerda,
        CASE
            WHEN VrLiquido IS NULL THEN ''                 -- Vazio
            WHEN (VrLiquido - VrCusto) > 0 THEN '­­­­­­­­­­ñ'        -- Seta pra cima em wingding
            WHEN (VrLiquido - VrCusto) < 0 THEN '­­­­­­­­ò'        -- Seta pra baixo em wingding
            ELSE 'l'                                       -- Seta pra esquerda e direita em wingding (simboliza estabilidade)
        END AS Indicador,
        VrPendente
    FROM @Base
    ORDER BY LoteID ASC, DetalheID ASC;

	-- TODO
    -- select * from @Resposta order by LoteID, DetalheID;


    -- Faz a totalização dos valores para calcular o que há aplicado
    -- Sobre o que há aplicado, calcula o lucro/prejuizo pelo valor da cota do dia corrente - valor da cota da compra     

    DECLARE @Aplicado TABLE (
        InvestimentoID      INT,
        DataCompra          DATE,
        DataVenda           DATE,
		Dias                INT,
        LoteID              INT,
        Lote                VARCHAR(40),
        SaldoCotas          NUMERIC(18,8),
        VrCotacaoDia        NUMERIC(18,8),
        Simbolo             VARCHAR(10),
        VrCusto             NUMERIC(18,8),
		VrBruto             NUMERIC(18,8),
        VrIRRF              NUMERIC(18,8),
        VrIOF               NUMERIC(18,8),
        VrComeCotaPago      NUMERIC(18,8),
        DataUltimoComeCota  DATE,
        VrCotacaoComeCota   NUMERIC(18,8),
		VrImposto           NUMERIC(18,8),
        VrLiquido           NUMERIC(18,8),
        VrLucroOuPerda      NUMERIC(18,8),
        PercLucroOuPerda    NUMERIC(18,8)
    );

	-- TODO
	-- Aqui entra o cálculo do imposto a pagar.

    INSERT INTO @Aplicado
    (InvestimentoID, DataCompra, DataVenda, Dias, LoteID, Lote, SaldoCotas, VrCotacaoDia, Simbolo, VrCusto, VrBruto)
     SELECT
        Resp.InvestimentoID,
        Resp.DtLote,
        Vend.Data,
		DATEDIFF(day, Resp.DtLote, Vend.Data),
        Resp.LoteID,
        Resp.Lote,
        SUM(CASE WHEN Resp.DetalheID = 0 THEN Resp.QtCotas ELSE Resp.QtCotas * -1 END) AS SaldoCotas,
        Vend.VrCotacao AS VrCotacaoDia,
        Moed.Simbolo, 
        SUM(CASE WHEN Resp.DetalheID = 0 THEN Resp.QtCotas ELSE Resp.QtCotas * -1 END) * Cpra.VrCotacao AS VrCusto,
        SUM(CASE WHEN Resp.DetalheID = 0 THEN Resp.QtCotas ELSE Resp.QtCotas * -1 END) * Vend.VrCotacao AS VrBruto
    FROM @Resposta Resp
         INNER JOIN Investimento Invt 
            ON Invt.InvestimentoID = Resp.InvestimentoID
         INNER JOIN Moeda Moed
            ON Moed.MoedaID = Invt.MoedaID
         INNER JOIN InvestimentoCotacao Vend
            ON Vend.InvestimentoID = Invt.InvestimentoID
           AND Vend.Data = (SELECT MAX(DATA) FROM InvestimentoCotacao WHERE InvestimentoID = Invt.InvestimentoID AND Data <= @Data)
         INNER JOIN InvestimentoCotacao Cpra
            ON Cpra.InvestimentoID = Invt.InvestimentoID
           AND Cpra.Data = resp.DtLote
    GROUP BY Resp.InvestimentoID, Resp.DtLote, Vend.Data, Resp.LoteID, Resp.Lote, Vend.VrCotacao, Moed.Simbolo, Cpra.VrCotacao
    HAVING SUM(CASE WHEN Resp.DetalheID = 0 THEN Resp.QtCotas ELSE Resp.QtCotas * -1 END) <> 0

    UPDATE @Aplicado
    SET VrIOF  = Coalesce(DBO.fncImpostoDevido(InvestimentoID, DataCompra, DataVenda, VrCusto, VrBruto, 1), 0),
        VrIRRF = Coalesce(DBO.fncImpostoDevido(InvestimentoID, DataCompra, DataVenda, VrCusto, VrBruto, 2), 0),
        DataUltimoComeCota = DBO.fncUltimoComeCota(InvestimentoID, DataCompra, DataVenda);

    UPDATE @Aplicado
    SET VrCotacaoComeCota = DBO.fncCotacaoComeCota(InvestimentoID, DataUltimoComeCota)
    WHERE DataUltimoComeCota IS NOT NULL;
    
    UPDATE @Aplicado
    SET VrComeCotaPago = ((SaldoCotas * VrCotacaoComeCota) - VrCusto - VrIOF) * 0.15
    WHERE DataUltimoComeCota IS NOT NULL;

    UPDATE @Aplicado
    SET VrImposto = VrIOF + VrIRRF - Coalesce(VrComeCotaPago, 0);

    UPDATE @Aplicado
    SET VrLiquido = ROUND(VrBruto - VrImposto, 2),
        VrLucroOuPerda = ROUND((VrBruto - VrImposto) - VrCusto, 2),
        PercLucroOuPerda = CASE WHEN ISNULL(VrCusto, 0) <> 0 THEN ((VrBruto - VrImposto) - VrCusto) / VrCusto * 100 ELSE NULL END;

    IF (@Resumo = 0) 
    BEGIN
        -- NÃO É RESUMO

        SELECT
            Resp.ContaID,
            Resp.MovimentoID,
            CAST(0 AS tinyint) AS Totalizador,
            Resp.LoteID,
            Resp.DetalheID,
            Resp.Transacao,
            CASE WHEN Resp.DetalheID = 0 THEN Resp.Lote ELSE NULL END AS Lote,
            Resp.DtMovimento,
            Resp.QtCotas,
            CASE WHEN Resp.SaldoCotas <> 0 THEN Resp.SaldoCotas ELSE NULL END AS SaldoCotas,
            Resp.VrCotacaoDia,
            CASE WHEN Resp.VrCotacaoDia < 0 THEN '-' ELSE '' END + Moed.Simbolo+' '+FORMAT(ABS(Resp.VrCotacaoDia), 'n6', 'pt-br') AS VrCotacaoDiaFormatado,
            Resp.VrCusto,
		    Resp.VrBruto,
		    Resp.VrImpostos,
            Resp.VrLiquido,
            Resp.VrLucroOuPerda,
            CASE WHEN ROUND(Resp.VrCusto, 2) < 0 THEN '-' ELSE '' END + Moed.Simbolo+' '+FORMAT(ABS(Resp.VrCusto), 'n2', 'pt-br') AS VrCustoFormatado,
            CASE WHEN ROUND(Resp.VrBruto, 2) < 0 THEN '-' ELSE '' END + Moed.Simbolo+' '+FORMAT(ABS(Resp.VrBruto), 'n2', 'pt-br') AS VrBrutoFormatado,
            CASE WHEN ROUND(Resp.VrImpostos, 2) < 0 THEN '-' ELSE '' END + Moed.Simbolo+' '+FORMAT(ABS(Resp.VrImpostos), 'n2', 'pt-br') AS VrImpostosFormatado,
            CASE WHEN ROUND(Resp.VrLiquido, 2) < 0 THEN '-' ELSE '' END + Moed.Simbolo+' '+FORMAT(ABS(Resp.VrLiquido), 'n2', 'pt-br') AS VrLiquidoFormatado,
            CASE WHEN ROUND(Resp.VrLucroOuPerda, 2) < 0 THEN '-' ELSE '' END + Moed.Simbolo+' '+FORMAT(ABS(Resp.VrLucroOuPerda), 'n2', 'pt-br') AS VrLucroOuPerdaFormatado,
            Resp.PercLucroOuPerda,
            FORMAT(Resp.PercLucroOuPerda, 'n4', 'pt-br') + '%' AS PercLucroOuPerdaFormatado,
            RIGHT(Indicador,1) AS Indicador
        FROM @Resposta Resp
             INNER JOIN Investimento Invt 
                ON Invt.InvestimentoID = Resp.InvestimentoID
             INNER JOIN Moeda Moed
                ON Moed.MoedaID = Invt.MoedaID

        UNION ALL

        SELECT
            NULL AS ContaID,
            NULL AS MovimentoID,
            CAST(1 AS tinyint) AS Totalizador,
            NULL AS LoteID,
            NULL AS DetalheID,
            'Apurado' AS Transacao,
            NULL AS Lote,
            NULL AS DtMovimento,
            NULL AS QtCotas, -- Resp.QtCotas,
            NULL AS SaldoCotas, -- Resp.SaldoCotas,
            NULL AS VrCotacaoDia, -- Resp.VrCotacaoDia,
            NULL AS VrCotacaoDiaFormatado,
            SUM(Resp.VrCusto),
		    SUM(Resp.VrBruto),
		    SUM(Resp.VrImpostos),
            SUM(Resp.VrLiquido),
            SUM(Resp.VrLucroOuPerda),
            CASE WHEN SUM(Resp.VrCusto) < 0 THEN '-' ELSE '' END + Moed.Simbolo+' '+FORMAT(ABS(SUM(Resp.VrCusto)), 'n2', 'pt-br') AS VrCustoFormatado,
            CASE WHEN SUM(Resp.VrBruto) < 0 THEN '-' ELSE '' END + Moed.Simbolo+' '+FORMAT(ABS(SUM(Resp.VrBruto)), 'n2', 'pt-br') AS VrBrutoFormatado,
            CASE WHEN SUM(Resp.VrImpostos) < 0 THEN '-' ELSE '' END + Moed.Simbolo+' '+FORMAT(ABS(SUM(Resp.VrImpostos)), 'n2', 'pt-br') AS VrImpostosFormatado,
            CASE WHEN SUM(Resp.VrLiquido) < 0 THEN '-' ELSE '' END + Moed.Simbolo+' '+FORMAT(ABS(SUM(Resp.VrLiquido)), 'n2', 'pt-br') AS VrLiquidoFormatado,
            CASE WHEN SUM(Resp.VrLucroOuPerda) < 0 THEN '-' ELSE '' END + Moed.Simbolo+' '+FORMAT(ABS(SUM(Resp.VrLucroOuPerda)), 'n2', 'pt-br') AS VrLucroOuPerdaFormatado,
            (SUM(Resp.VrLucroOuPerda) / SUM(Resp.VrCusto) * 100) AS PercLucroOuPerda,
            FORMAT((SUM(Resp.VrLucroOuPerda) / SUM(Resp.VrCusto) * 100), 'n4', 'pt-br') + '%' AS PercLucroOuPerdaFormatado,
            RIGHT(CASE
                WHEN SUM(Resp.VrLucroOuPerda) IS NULL THEN ''     -- Vazio
                WHEN SUM(Resp.VrLucroOuPerda) > 0 THEN '­­­­­­­­­­ñ'        -- Seta pra cima em wingding
                WHEN SUM(Resp.VrLucroOuPerda) < 0 THEN '­­­­­­­­ò'        -- Seta pra baixo em wingding
                ELSE 'l'                                          -- Seta pra esquerda e direita em wingding (simboliza estabilidade)
            END, 1) AS Indicador
        FROM @Resposta Resp
             INNER JOIN Investimento Invt 
                ON Invt.InvestimentoID = Resp.InvestimentoID
             INNER JOIN Moeda Moed
                ON Moed.MoedaID = Invt.MoedaID
        WHERE NOT Resp.VrLiquido IS NULL
        GROUP BY Moed.Simbolo

        UNION ALL

        SELECT
            NULL AS ContaID,
            NULL AS MovimentoID,
            CAST(2 AS tinyint) AS Totalizador,
            LoteID, 
            NULL AS DetalheID,
            'Total do Lote' AS Transacao,
            Lote + '  (' + CASE Dias WHEN 0 THEN 'Mesmo dia' WHEN 1 THEN '01 dia' ELSE FORMAT(Dias, '#00') + ' dias' END + ')', 
            DataVenda AS DtMovimento,
            NULL AS QtCotas,
            SaldoCotas, 
            VrCotacaoDia, 
            CASE WHEN (VrCotacaoDia) < 0 THEN '-' ELSE '' END + Simbolo+' '+FORMAT(ABS(VrCotacaoDia), 'n6', 'pt-br') AS VrCotacaoDiaFormatado,
            VrCusto, 
		    VrBruto,
		    VrImposto,
            VrLiquido, 
            VrLucroOuPerda, 
            CASE WHEN (VrCusto) < 0 THEN '-' ELSE '' END + Simbolo+' '+FORMAT(ABS(VrCusto), 'n2', 'pt-br') AS VrCustoFormatado,
            CASE WHEN (VrBruto) < 0 THEN '-' ELSE '' END + Simbolo+' '+FORMAT(ABS(VrBruto), 'n2', 'pt-br') AS VrBrutoFormatado,
            CASE WHEN (VrImposto) < 0 THEN '-' ELSE '' END + Simbolo+' '+FORMAT(ABS(VrImposto), 'n2', 'pt-br') AS VrImpostosFormatado,
            CASE WHEN (VrLiquido) < 0 THEN '-' ELSE '' END + Simbolo+' '+FORMAT(ABS(VrLiquido), 'n2', 'pt-br') AS VrLiquidoFormatado,
            CASE WHEN (VrLucroOuPerda) < 0 THEN '-' ELSE '' END + Simbolo+' '+FORMAT(ABS(VrLucroOuPerda), 'n2', 'pt-br') AS VrLucroOuPerdaFormatado,
            PercLucroOuPerda,
            FORMAT(PercLucroOuPerda, 'n4', 'pt-br') + '%' AS PercLucroOuPerdaFormatado,
            RIGHT(CASE
                WHEN VrLucroOuPerda IS NULL THEN ''     -- Vazio
                WHEN VrLucroOuPerda > 0 THEN '­­­­­­­­­­ñ'        -- Seta pra cima em wingding
                WHEN VrLucroOuPerda < 0 THEN '­­­­­­­­ò'        -- Seta pra baixo em wingding
                ELSE 'l'                                     -- Seta pra esquerda e direita em wingding (simboliza estabilidade)
            END, 1) AS Indicador
        FROM @Aplicado

        UNION ALL

        SELECT
            NULL AS ContaID,
            NULL AS MovimentoID,
            CAST(3 AS tinyint) AS Totalizador,
            NULL AS LoteID, 
            NULL AS DetalheID,
            'Disponível' AS Transacao,
            NULL, 
            NULL AS DtMovimento,
            NULL AS QtCotas,
            SUM(SaldoCotas) AS SaldoCotas, 
            NULL AS VrCotacaoDia, 
            NULL AS VrCotacaoDiaFormatado, 
            SUM(VrCusto) AS VrCusto, 
		    SUM(VrBruto) AS VrBruto,
		    SUM(VrImposto) AS VrImposto,
            SUM(VrLiquido) AS VrLiquido, 
            SUM(VrLucroOuPerda) AS VrLucroOuPerda, 
            CASE WHEN (SUM(VrCusto)) < 0 THEN '-' ELSE '' END + Simbolo+' '+FORMAT(ABS(SUM(VrCusto)), 'n2', 'pt-br') AS VrCustoFormatado,
            CASE WHEN (SUM(VrBruto)) < 0 THEN '-' ELSE '' END + Simbolo+' '+FORMAT(ABS(SUM(VrBruto)), 'n2', 'pt-br') AS VrBrutoFormatado,
            CASE WHEN (SUM(VrImposto)) < 0 THEN '-' ELSE '' END + Simbolo+' '+FORMAT(ABS(SUM(VrImposto)), 'n2', 'pt-br') AS VrImpostosFormatado,
            CASE WHEN (SUM(VrLiquido)) < 0 THEN '-' ELSE '' END + Simbolo+' '+FORMAT(ABS(SUM(VrLiquido)), 'n2', 'pt-br') AS VrLiquidoFormatado,
            CASE WHEN (SUM(VrLucroOuPerda)) < 0 THEN '-' ELSE '' END + Simbolo+' '+FORMAT(ABS(SUM(VrLucroOuPerda)), 'n2', 'pt-br') AS VrLucroOuPerdaFormatado,
            CASE 
                WHEN SUM(COALESCE(VrLiquido, 0.0)) <> 0 THEN (SUM(VrLiquido) - SUM(VrCusto)) / SUM(VrCusto) * 100
                ELSE NULL
            END AS PercLucroOuPenda,
            FORMAT((SUM(VrLiquido) - SUM(VrCusto)) / SUM(VrCusto) * 100, 'n4', 'pt-br') + '%' AS PercLucroOuPerdaFormatado,
            RIGHT(CASE
                WHEN SUM(VrLucroOuPerda) IS NULL THEN ''     -- Vazio
                WHEN SUM(VrLucroOuPerda) > 0 THEN '­­­­­­­­­­ñ'        -- Seta pra cima em wingding
                WHEN SUM(VrLucroOuPerda) < 0 THEN '­­­­­­­­ò'        -- Seta pra baixo em wingding
                ELSE 'l'                                     -- Seta pra esquerda e direita em wingding (simboliza estabilidade)
            END, 1) AS Indicador
        FROM @Aplicado
        GROUP BY Simbolo
        ORDER BY Totalizador, LoteID ASC, DetalheID ASC;

    END
    ELSE
    BEGIN
        -- É RESUMO

        -- O RESULTSET É DIFERENTE

        DECLARE @SAIDA TABLE (
            VrCusto         NUMERIC(18,8),
			VrBruto         NUMERIC(18,8),
			VrImpostos      NUMERIC(18,8),
            VrLiquido       NUMERIC(18,8),
            VrLucroOuPerda  NUMERIC(18,8));

        INSERT INTO @SAIDA
        (VrCusto, VrBruto, VrImpostos, VrLiquido, VrLucroOuPerda)
        SELECT
            SUM(Resp.VrCusto),
		    SUM(Resp.VrBruto),
		    SUM(Resp.VrImpostos),
            SUM(Resp.VrLiquido),
            SUM(Resp.VrLucroOuPerda)
        FROM @Resposta Resp
             INNER JOIN Investimento Invt 
                ON Invt.InvestimentoID = Resp.InvestimentoID
             INNER JOIN Moeda Moed
                ON Moed.MoedaID = Invt.MoedaID
        WHERE NOT Resp.VrLiquido IS NULL

        UNION ALL

        SELECT
            SUM(VrCusto) AS VrCusto, 
		    SUM(VrBruto) AS VrBruto,
		    SUM(VrImposto) AS VrImposto,
            SUM(VrLiquido) AS VrLiquido, 
            SUM(VrLucroOuPerda) AS VrLucroOuPerda
        FROM @Aplicado;

        SELECT SUM(VrLucroOuPerda) AS VrLucroOuPerda
        FROM @SAIDA;

    END;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpExecutarCSVTradeHitBTC]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************
 Procedure stpExecutarCSVTradeHitBTC
 Elcio Reis - 25/09/2019

 A partir da Conta selecionada, busca a instituição e
 então todas as contas ativas naquela instituição.
 A partir daí, executa a procedure 
 stpMovimentoContaFromTradeHitBTC para cada conta

 Alteração por Elcio Reis em 02/11/2021
 As contas inativas também deverão ser acessadas.

 Exemplo de execução
 EXEC stpExecutarCSVTradeHitBTC 2, 33;
 ********************************************************/

CREATE PROCEDURE [dbo].[stpExecutarCSVTradeHitBTC] (@UsuarioID INT, @ContaID INT)
AS
    DECLARE @IDConta INT;
BEGIN

    SET NOCOUNT ON;


    IF (@ContaID != 0)
    BEGIN
        DECLARE cContas CURSOR 
        FOR SELECT Prin.ContaID
            FROM Conta Cnta
                 JOIN Instituicao Inst ON Inst.InstituicaoID = Cnta.InstituicaoID
                 JOIN Conta Prin ON Prin.InstituicaoID = Inst.InstituicaoID
                                --AND Prin.Ativo = 1 -- Tem que acessar as contas intativas também
            WHERE Cnta.UsuarioID = @UsuarioID
            AND   Cnta.ContaID = @ContaID;
    END
    ELSE
    BEGIN
        DECLARE cContas CURSOR 
        FOR SELECT Cnta.ContaID
            FROM Instituicao Inst
                 JOIN Conta Cnta ON Cnta.InstituicaoID = Inst.InstituicaoID
                                --AND Cnta.Ativo = 1  -- Tem que acessar as contas intativas também
            WHERE UPPER(INST.Apelido) = 'HITBTC';
    END;

    OPEN cContas;

    FETCH NEXT FROM cContas INTO @IDConta;

    WHILE (@@FETCH_STATUS = 0) 
    BEGIN

        EXEC stpMovimentoContaFromTradeHitBTC @UsuarioID, @IDConta; 

        FETCH NEXT FROM cContas INTO @IDConta;
    END;
    
    CLOSE cContas;
    DEALLOCATE cContas;
    
END;
GO
/****** Object:  StoredProcedure [dbo].[stpFeriadoNesteDia]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpFeriadoNesteDia](@Data DATE)

AS

BEGIN

    IF (EXISTS(SELECT Descricao FROM Feriado WHERE Dia = DAY(@Data) AND Mes = MONTH(@Data) AND (Ano = YEAR(@Data) OR Ano IS NULL)))
        SELECT CAST(1 AS BIT) AS Feriado;
    ELSE
        SELECT CAST(0 AS BIT) AS Feriado;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpFluxoCaixaContaEspecifica]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/**************************************************
 Procedure stpFluxoCaixaContaEspecifica
 Monta um pivô com o fluxo de caixa de uma conta 
 específica no mês informado
 Elcio Reis - 03/09/2019
 Exemplo de execução:
 EXEC stpFluxoCaixaContaEspecifica 2, '2019-08-03';
 **************************************************/

CREATE PROCEDURE [dbo].[stpFluxoCaixaContaEspecifica] @ContaID INT, @DataReferencia DATE
AS
BEGIN

    -- Calcula o primeiro dia do mês
    DECLARE @PrimeiroDia DATE = DATEADD(DAY, 1, EOMONTH(@DataReferencia, -1));
    -- Calcula o último dia do mês
    DECLARE @UltimoDia DATE = EOMONTH(@DataReferencia);

    -- Cria uma tabela com todos os dias do mês em referência
    DECLARE @Dias TABLE (Indice SMALLINT, Dia DATE);

    -- Acrescenta todos os dias do mês na tabela @Dias
    DECLARE @Dia DATE = @PrimeiroDia; -- DATEADD(DAY, -1, @PrimeiroDia);
    DECLARE @Indice SMALLINT = 1;

    WHILE (@Dia <= @UltimoDia)
    BEGIN
        INSERT INTO @Dias
        (Indice, Dia)
        VALUES
        (@Indice, @Dia);

        SET @Indice = @Indice + 1;
        SET @Dia = DATEADD(DAY, 1, @Dia);
    END; -- WHILE
    
    --SELECT * FROM @Dias;


    DECLARE @TabelaFinal TABLE (Tipo             CHAR(1),
                                TipoLinha        SMALLINT,
                                CategoriaID      INT,
                                ContaID          INT,
                                Categoria        VARCHAR(50),
                                Dia01            DECIMAL(12,2),
                                Dia02            DECIMAL(12,2),
                                Dia03            DECIMAL(12,2),
                                Dia04            DECIMAL(12,2),
                                Dia05            DECIMAL(12,2),
                                Dia06            DECIMAL(12,2),
                                Dia07            DECIMAL(12,2),
                                Dia08            DECIMAL(12,2),
                                Dia09            DECIMAL(12,2),
                                Dia10            DECIMAL(12,2),
                                Dia11            DECIMAL(12,2),
                                Dia12            DECIMAL(12,2),
                                Dia13            DECIMAL(12,2),
                                Dia14            DECIMAL(12,2),
                                Dia15            DECIMAL(12,2),
                                Dia16            DECIMAL(12,2),
                                Dia17            DECIMAL(12,2),
                                Dia18            DECIMAL(12,2),
                                Dia19            DECIMAL(12,2),
                                Dia20            DECIMAL(12,2),
                                Dia21            DECIMAL(12,2),
                                Dia22            DECIMAL(12,2),
                                Dia23            DECIMAL(12,2),
                                Dia24            DECIMAL(12,2),
                                Dia25            DECIMAL(12,2),
                                Dia26            DECIMAL(12,2),
                                Dia27            DECIMAL(12,2),
                                Dia28            DECIMAL(12,2),
                                Dia29            DECIMAL(12,2),
                                Dia30            DECIMAL(12,2),
                                Dia31            DECIMAL(12,2),
                                TotalCategoria   DECIMAL(12,2));

    DECLARE @EspacoSimpl VARCHAR(10) = '      ';
    DECLARE @EspacoDuplo VARCHAR(20) = @EspacoSimpl + @EspacoSimpl;
 
    WITH Fase01 AS (SELECT Dias.Indice Dia,
                           CSel.vCrdDeb Tipo,
                           CASE WHEN CSel.vCrdDeb = 'T' THEN 0
                                ELSE CSel.CategoriaPaiID
                           END CategoriaID,
                           CASE WHEN CSel.ContaID > 0 THEN CSel.ContaID ELSE 0 END ContaID,
                           @EspacoDuplo + CASE WHEN CSel.vCrdDeb = 'T' THEN SUBSTRING(CSel.vFiltro, 2, LEN(CSel.vFiltro)-2)
                                               ELSE Ctgr.Apelido
                                          END Categoria,
                           MvCt.Valor
                    FROM MovimentoConta MvCt
                         JOIN @Dias Dias ON Dias.Dia = CAST(MvCt.Data AS DATE)
                         JOIN vw_CategoriasSelecionaveis CSel ON CSel.CategoriaID = MvCt.CategoriaID
                         JOIN Categoria Ctgr ON Ctgr.CategoriaID = CSel.CategoriaPaiID
                    WHERE MvCt.ContaID = @ContaID),
         Fase02 AS (-- Detalhes
                    SELECT 2 TipoLinha, Tipo, Dia, Valor, CategoriaID, ContaID, Categoria
                    FROM Fase01

                    UNION ALL

                    -- Total por categoria
                    SELECT 1 TipoLinha, Tipo, Dia, SUM(Valor) Valor, 0 CategoriaID, 0 ContaID,
                           CASE Tipo
                                WHEN 'C' THEN @EspacoSimpl + 'Total Entradas'
                                WHEN 'D' THEN @EspacoSimpl + 'Total Saídas'
                                WHEN 'T' THEN @EspacoSimpl + 'Total Transferência'
                                ELSE NULL
                            END Categoria
                    FROM Fase01
                    GROUP BY Tipo, Dia

                    UNION ALL
                    
                    SELECT 0 TipoLinha, 'A' Tipo, 1 Dia, 
                           SUM(COALESCE(MvCt.Credito, 0) - COALESCE(MvCt.Debito, 0)) Valor,
                           0 CategoriaID, 0 ContaID, 'Saldo Inicial' Categoria
                    FROM MovimentoConta MvCt
                    WHERE MvCt.ContaID = @ContaID
                    AND   MvCt.Data < @PrimeiroDia

                    UNION ALL

                    -- Saldo Final
                    SELECT 3 TipoLinha, 'Z' Tipo, Dia, 0 Valor, 0 CategoriaID, 0 ContaID,
                           'Saldo Final a Transportar' Categoria
                    FROM Fase01
                    GROUP BY Dia)
    INSERT INTO @TabelaFinal
    (Tipo, TipoLinha, CategoriaID, ContaID, Categoria,
     Dia01, Dia02, Dia03, Dia04, Dia05, Dia06, Dia07, Dia08, Dia09, Dia10,
     Dia11, Dia12, Dia13, Dia14, Dia15, Dia16, Dia17, Dia18, Dia19, Dia20,
     Dia21, Dia22, Dia23, Dia24, Dia25, Dia26, Dia27, Dia28, Dia29, Dia30, Dia31)
    SELECT Tipo, TipoLinha, CategoriaID, ContaID, Categoria,
            [1] 'DIA01',  [2] 'DIA02',  [3] 'DIA03',  [4] 'DIA04',  [5] 'DIA05',  [6] 'DIA06',  [7] 'DIA07',  [8] 'DIA08',  [9] 'DIA09', [10] 'DIA10',
           [11] 'DIA11', [12] 'DIA12', [13] 'DIA13', [14] 'DIA14', [15] 'DIA15', [16] 'DIA16', [17] 'DIA17', [18] 'DIA18', [19] 'DIA19', [20] 'DIA20',
           [21] 'DIA21', [22] 'DIA22', [23] 'DIA23', [24] 'DIA24', [25] 'DIA25', [26] 'DIA26', [27] 'DIA27', [28] 'DIA28', [29] 'DIA29', [30] 'DIA30',
           [31] 'DIA31'
    FROM (SELECT Dia, Tipo, TipoLinha, CategoriaID, ContaID, Categoria, Valor FROM Fase02) Origem
    PIVOT (SUM(Valor) FOR Dia IN ( [1], [2], [3], [4], [5], [6], [7], [8], [9],[10],
                                  [11],[12],[13],[14],[15],[16],[17],[18],[19],[20],
                                  [21],[22],[23],[24],[25],[26],[27],[28],[29],[30],
                                  [31])) Final
    ORDER BY Tipo ASC, TipoLinha ASC, Categoria ASC;

    UPDATE @TabelaFinal
    SET Dia01 = COALESCE(Dia01, 0),
        Dia02 = COALESCE(Dia02, 0),
        Dia03 = COALESCE(Dia03, 0),
        Dia04 = COALESCE(Dia04, 0),
        Dia05 = COALESCE(Dia05, 0),
        Dia06 = COALESCE(Dia06, 0),
        Dia07 = COALESCE(Dia07, 0),
        Dia08 = COALESCE(Dia08, 0),
        Dia09 = COALESCE(Dia09, 0),
        Dia10 = COALESCE(Dia10, 0),
        Dia11 = COALESCE(Dia11, 0),
        Dia12 = COALESCE(Dia12, 0),
        Dia13 = COALESCE(Dia13, 0),
        Dia14 = COALESCE(Dia14, 0),
        Dia15 = COALESCE(Dia15, 0),
        Dia16 = COALESCE(Dia16, 0),
        Dia17 = COALESCE(Dia17, 0),
        Dia18 = COALESCE(Dia18, 0),
        Dia19 = COALESCE(Dia19, 0),
        Dia20 = COALESCE(Dia20, 0),
        Dia21 = COALESCE(Dia21, 0),
        Dia22 = COALESCE(Dia22, 0),
        Dia23 = COALESCE(Dia23, 0),
        Dia24 = COALESCE(Dia24, 0),
        Dia25 = COALESCE(Dia25, 0),
        Dia26 = COALESCE(Dia26, 0),
        Dia27 = COALESCE(Dia27, 0),
        Dia28 = COALESCE(Dia28, 0),
        Dia29 = CASE WHEN DATEADD(DAY, 29 - 1, @PrimeiroDia) <= @UltimoDia THEN COALESCE(Dia29, 0) ELSE NULL END,
        Dia30 = CASE WHEN DATEADD(DAY, 30 - 1, @PrimeiroDia) <= @UltimoDia THEN COALESCE(Dia30, 0) ELSE NULL END,
        Dia31 = CASE WHEN DATEADD(DAY, 31 - 1, @PrimeiroDia) <= @UltimoDia THEN COALESCE(Dia31, 0) ELSE NULL END
    WHERE TipoLinha = 1;

    -- Calcula os saldos iniciais e finais de todos os dias

    
    DECLARE @Anterior DECIMAL(12, 2), @Total DECIMAL(12, 2), @Movimento DECIMAL(12,2); 

    SELECT @Anterior = Dia01 FROM @TabelaFinal WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia01) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Anterior + @Movimento;
    UPDATE @TabelaFinal SET Dia01 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia02 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia02) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia02 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia03 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia03) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia03 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia04 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia04) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia04 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia05 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia05) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia05 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia06 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia06) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia06 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia07 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia07) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia07 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia08 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia08) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia08 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia09 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia09) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia09 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia10 = @Total WHERE TipoLinha = 0;
        
    SELECT @Movimento = SUM(Dia10) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia10 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia11 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia11) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia11 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia12 = @Total WHERE TipoLinha = 0;
        
    SELECT @Movimento = SUM(Dia12) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia12 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia13 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia13) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia13 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia14 = @Total WHERE TipoLinha = 0;
            
    SELECT @Movimento = SUM(Dia14) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia14 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia15 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia15) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia15 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia16 = @Total WHERE TipoLinha = 0;
                
    SELECT @Movimento = SUM(Dia16) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia16 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia17 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia17) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia17 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia18 = @Total WHERE TipoLinha = 0;
            
    SELECT @Movimento = SUM(Dia18) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia18 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia19 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia19) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia19 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia20 = @Total WHERE TipoLinha = 0;
                
    SELECT @Movimento = SUM(Dia20) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia20 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia21 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia21) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia21 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia22 = @Total WHERE TipoLinha = 0;
                    
    SELECT @Movimento = SUM(Dia22) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia22 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia23 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia23) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia23 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia24 = @Total WHERE TipoLinha = 0;
                        
    SELECT @Movimento = SUM(Dia24) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia24 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia25 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia25) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia25 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia26 = @Total WHERE TipoLinha = 0;
                            
    SELECT @Movimento = SUM(Dia26) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia26 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia27 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia27) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia27 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia28 = @Total WHERE TipoLinha = 0;
                                
    SELECT @Movimento = SUM(Dia28) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia28 = @Total WHERE TipoLinha = 3;
    
    IF (DATEADD(DAY, 29 - 1, @PrimeiroDia) <= @UltimoDia)
    BEGIN
        UPDATE @TabelaFinal SET Dia29 = @Total WHERE TipoLinha = 0;

        SELECT @Movimento = SUM(Dia29) FROM @TabelaFinal WHERE TipoLinha = 1;
        SET    @Total = @Total + @Movimento;
        UPDATE @TabelaFinal SET Dia29 = @Total WHERE TipoLinha = 3;
        UPDATE @TabelaFinal SET Dia30 = @Total WHERE TipoLinha = 0;
    END;
                                    
    IF (DATEADD(DAY, 30 - 1, @PrimeiroDia) <= @UltimoDia)
    BEGIN
        SELECT @Movimento = SUM(Dia30) FROM @TabelaFinal WHERE TipoLinha = 1;
        SET    @Total = @Total + @Movimento;
        UPDATE @TabelaFinal SET Dia30 = @Total WHERE TipoLinha = 3;
        UPDATE @TabelaFinal SET Dia31 = @Total WHERE TipoLinha = 0;
    END;
    
    IF (DATEADD(DAY, 31 - 1, @PrimeiroDia) <= @UltimoDia)
    BEGIN
        SELECT @Movimento = SUM(Dia31) FROM @TabelaFinal WHERE TipoLinha = 1;
        SET    @Total = @Total + @Movimento;
        UPDATE @TabelaFinal SET Dia31 = @Total WHERE TipoLinha = 3;
    END;

    -- Totaliza as categorias

    UPDATE @TabelaFinal
    SET TotalCategoria = @Anterior
    WHERE TipoLinha = 0;

    UPDATE @TabelaFinal
    SET TotalCategoria = COALESCE(Dia01, 0) + COALESCE(Dia02, 0) + COALESCE(Dia03, 0) + COALESCE(Dia04, 0) + COALESCE(Dia05, 0) +
                         COALESCE(Dia06, 0) + COALESCE(Dia07, 0) + COALESCE(Dia08, 0) + COALESCE(Dia09, 0) + COALESCE(Dia10, 0) +
                         COALESCE(Dia11, 0) + COALESCE(Dia12, 0) + COALESCE(Dia13, 0) + COALESCE(Dia14, 0) + COALESCE(Dia15, 0) +
                         COALESCE(Dia16, 0) + COALESCE(Dia17, 0) + COALESCE(Dia18, 0) + COALESCE(Dia19, 0) + COALESCE(Dia20, 0) +
                         COALESCE(Dia21, 0) + COALESCE(Dia22, 0) + COALESCE(Dia23, 0) + COALESCE(Dia24, 0) + COALESCE(Dia25, 0) +
                         COALESCE(Dia26, 0) + COALESCE(Dia27, 0) + COALESCE(Dia28, 0) + COALESCE(Dia29, 0) + COALESCE(Dia30, 0) +
                         COALESCE(Dia31, 0)
    WHERE TipoLinha = 2;

    UPDATE @TabelaFinal
    SET TotalCategoria = (SELECT SUM(TotalCategoria)
                          FROM @TabelaFinal
                          WHERE Tipo = 'C' AND TipoLinha = 2)
    WHERE Tipo = 'C'
    AND   TipoLinha = 1;

    UPDATE @TabelaFinal
    SET TotalCategoria = (SELECT SUM(TotalCategoria)
                          FROM @TabelaFinal
                          WHERE Tipo = 'D' AND TipoLinha = 2)
    WHERE Tipo = 'D'
    AND   TipoLinha = 1;

    UPDATE @TabelaFinal
    SET TotalCategoria = (SELECT SUM(TotalCategoria)
                          FROM @TabelaFinal
                          WHERE Tipo = 'T' AND TipoLinha = 2)
    WHERE Tipo = 'T'
    AND   TipoLinha = 1;

    UPDATE @TabelaFinal
    SET TotalCategoria = @Anterior +
                         (SELECT SUM(TotalCategoria)
                          FROM @TabelaFinal
                          WHERE TipoLinha = 2)
    WHERE TipoLinha = 3;


    SELECT Tipo, TipoLinha, CategoriaID, ContaID, Categoria,
           Dia01, Dia02, Dia03, Dia04, Dia05, Dia06, Dia07, Dia08, Dia09, Dia10,
           Dia11, Dia12, Dia13, Dia14, Dia15, Dia16, Dia17, Dia18, Dia19, Dia20,
           Dia21, Dia22, Dia23, Dia24, Dia25, Dia26, Dia27, Dia28, Dia29, Dia30, Dia31, 
           TotalCategoria,
           @PrimeiroDia PrimeiroDia, @UltimoDia UltimoDia
    FROM @TabelaFinal Final
    ORDER BY Final.Tipo ASC, Final.TipoLinha ASC, Final.Categoria ASC;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpFluxoCaixaCredito]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/************************************************
 Procedure stpFluxoCaixaCredito
 Monta um pivô com o fluxo de caixa de TODAS as 
 contas dos grupos de contas marcados como 
 FluxoCredito = 1
 Elcio Reis - 04/09/2019
 Exemplo de execução:
 EXEC stpFluxoCaixaCredito 2, '2019-09-03';
 ************************************************/

CREATE PROCEDURE [dbo].[stpFluxoCaixaCredito] @UsuarioID INT, @DataReferencia DATE
AS
BEGIN

    -- Calcula o primeiro dia do mês
    DECLARE @PrimeiroDia DATE = DATEADD(DAY, 1, EOMONTH(@DataReferencia, -1));
    -- Calcula o último dia do mês
    DECLARE @UltimoDia DATE = EOMONTH(@DataReferencia);

    -- Cria uma tabela com todos os dias do mês em referência
    DECLARE @Dias TABLE (Indice SMALLINT, Dia DATE);
    -- Cria uma tabela com todas as contas que entrarão no fluxo de caixa
    DECLARE @Contas TABLE (ContaID INT);

    -- Acrescenta todos os dias do mês na tabela @Dias
    DECLARE @Dia DATE = @PrimeiroDia;
    DECLARE @Indice SMALLINT = 1;

    WHILE (@Dia <= @UltimoDia)
    BEGIN
        INSERT INTO @Dias
        (Indice, Dia)
        VALUES
        (@Indice, @Dia);

        SET @Indice = @Indice + 1;
        SET @Dia = DATEADD(DAY, 1, @Dia);
    END; -- WHILE
    
    --SELECT * FROM @Dias;
    INSERT INTO @Contas
    (ContaID)
    SELECT ContaID
    FROM GrupoConta GpCt
         JOIN TipoConta Tipo ON Tipo.GrupoContaID = GpCt.GrupoContaID
         JOIN Conta Cnta ON Cnta.TipoContaID = Tipo.TipoContaID
    WHERE GpCt.FluxoCredito = 1
    AND   Cnta.UsuarioID = @UsuarioID;

    DECLARE @TabelaFinal TABLE (Tipo             CHAR(1),
                                TipoLinha        SMALLINT,
                                CategoriaID      INT,
                                ContaID          INT,
                                Categoria        VARCHAR(50),
                                Dia01            DECIMAL(12,2),
                                Dia02            DECIMAL(12,2),
                                Dia03            DECIMAL(12,2),
                                Dia04            DECIMAL(12,2),
                                Dia05            DECIMAL(12,2),
                                Dia06            DECIMAL(12,2),
                                Dia07            DECIMAL(12,2),
                                Dia08            DECIMAL(12,2),
                                Dia09            DECIMAL(12,2),
                                Dia10            DECIMAL(12,2),
                                Dia11            DECIMAL(12,2),
                                Dia12            DECIMAL(12,2),
                                Dia13            DECIMAL(12,2),
                                Dia14            DECIMAL(12,2),
                                Dia15            DECIMAL(12,2),
                                Dia16            DECIMAL(12,2),
                                Dia17            DECIMAL(12,2),
                                Dia18            DECIMAL(12,2),
                                Dia19            DECIMAL(12,2),
                                Dia20            DECIMAL(12,2),
                                Dia21            DECIMAL(12,2),
                                Dia22            DECIMAL(12,2),
                                Dia23            DECIMAL(12,2),
                                Dia24            DECIMAL(12,2),
                                Dia25            DECIMAL(12,2),
                                Dia26            DECIMAL(12,2),
                                Dia27            DECIMAL(12,2),
                                Dia28            DECIMAL(12,2),
                                Dia29            DECIMAL(12,2),
                                Dia30            DECIMAL(12,2),
                                Dia31            DECIMAL(12,2),
                                TotalCategoria   DECIMAL(12,2));

    DECLARE @EspacoSimpl VARCHAR(10) = '      ';
    DECLARE @EspacoDuplo VARCHAR(20) = @EspacoSimpl + @EspacoSimpl;
 
    WITH Fase01 AS (SELECT Dias.Indice Dia,
                           CSel.vCrdDeb Tipo,
                           --CSel.CategoriaPaiID CategoriaID,
                           CASE WHEN CSel.vCrdDeb = 'T' THEN 0
                                ELSE CSel.CategoriaPaiID
                           END CategoriaID,
                           CASE WHEN CSel.ContaID > 0 THEN CSel.ContaID ELSE 0 END ContaID,
                           @EspacoDuplo + CASE WHEN CSel.vCrdDeb = 'T' THEN SUBSTRING(CSel.vFiltro, 2, LEN(CSel.vFiltro)-2)
                                               ELSE Ctgr.Apelido
                                          END Categoria,
                           MvCt.Valor
                    FROM MovimentoConta MvCt
                         JOIN @Contas Cnta ON Cnta.ContaID = MvCt.ContaID
                         JOIN @Dias Dias ON Dias.Dia = CAST(MvCt.Data AS DATE)
                         JOIN vw_CategoriasSelecionaveis CSel ON CSel.CategoriaID = MvCt.CategoriaID
                                                             AND CSel.ContaID NOT IN (SELECT ContaID FROM @Contas)
                         JOIN Categoria Ctgr ON Ctgr.CategoriaID = CSel.CategoriaPaiID),
         Fase02 AS (-- Detalhes
                    SELECT 2 TipoLinha, Tipo, Dia, Valor, CategoriaID, ContaID, Categoria
                    FROM Fase01

                    UNION ALL

                    -- Total por categoria
                    SELECT 1 TipoLinha, Tipo, Dia, SUM(Valor) Valor, 0 CategoriaID, 0 ContaID,
                           CASE Tipo
                                WHEN 'C' THEN @EspacoSimpl + 'Total Entradas'
                                WHEN 'D' THEN @EspacoSimpl + 'Total Saídas'
                                WHEN 'T' THEN @EspacoSimpl + 'Total Transferência'
                                ELSE NULL
                            END Categoria
                    FROM Fase01
                    GROUP BY Tipo, Dia

                    UNION ALL
                    
                    SELECT 0 TipoLinha, 'A' Tipo, 1 Dia, 
                           SUM(COALESCE(MvCt.Credito, 0) - COALESCE(MvCt.Debito, 0)) Valor,
                           0 CategoriaID, 0 ContaID, 'Saldo Inicial' Categoria
                    FROM MovimentoConta MvCt
                         JOIN @Contas Cnta ON Cnta.ContaID = MvCt.ContaID
                    WHERE MvCt.Data < @PrimeiroDia

                    UNION ALL

                    -- Saldo Final
                    SELECT 3 TipoLinha, 'Z' Tipo, Dia, 0 Valor, 0 CategoriaID, 0 ContaID,
                           'Saldo Final a Transportar' Categoria
                    FROM Fase01
                    GROUP BY Dia)
    INSERT INTO @TabelaFinal
    (Tipo, TipoLinha, CategoriaID, ContaID, Categoria,
     Dia01, Dia02, Dia03, Dia04, Dia05, Dia06, Dia07, Dia08, Dia09, Dia10,
     Dia11, Dia12, Dia13, Dia14, Dia15, Dia16, Dia17, Dia18, Dia19, Dia20,
     Dia21, Dia22, Dia23, Dia24, Dia25, Dia26, Dia27, Dia28, Dia29, Dia30, Dia31)
    SELECT Tipo, TipoLinha, CategoriaID, ContaID, Categoria,
            [1] 'DIA01',  [2] 'DIA02',  [3] 'DIA03',  [4] 'DIA04',  [5] 'DIA05',  [6] 'DIA06',  [7] 'DIA07',  [8] 'DIA08',  [9] 'DIA09', [10] 'DIA10',
           [11] 'DIA11', [12] 'DIA12', [13] 'DIA13', [14] 'DIA14', [15] 'DIA15', [16] 'DIA16', [17] 'DIA17', [18] 'DIA18', [19] 'DIA19', [20] 'DIA20',
           [21] 'DIA21', [22] 'DIA22', [23] 'DIA23', [24] 'DIA24', [25] 'DIA25', [26] 'DIA26', [27] 'DIA27', [28] 'DIA28', [29] 'DIA29', [30] 'DIA30',
           [31] 'DIA31'
    FROM (SELECT Dia, Tipo, TipoLinha, CategoriaID, ContaID, Categoria, Valor FROM Fase02) Origem
    PIVOT (SUM(Valor) FOR Dia IN ( [1], [2], [3], [4], [5], [6], [7], [8], [9],[10],
                                  [11],[12],[13],[14],[15],[16],[17],[18],[19],[20],
                                  [21],[22],[23],[24],[25],[26],[27],[28],[29],[30],
                                  [31])) Final
    ORDER BY Tipo ASC, TipoLinha ASC, Categoria ASC;

    UPDATE @TabelaFinal
    SET Dia01 = COALESCE(Dia01, 0),
        Dia02 = COALESCE(Dia02, 0),
        Dia03 = COALESCE(Dia03, 0),
        Dia04 = COALESCE(Dia04, 0),
        Dia05 = COALESCE(Dia05, 0),
        Dia06 = COALESCE(Dia06, 0),
        Dia07 = COALESCE(Dia07, 0),
        Dia08 = COALESCE(Dia08, 0),
        Dia09 = COALESCE(Dia09, 0),
        Dia10 = COALESCE(Dia10, 0),
        Dia11 = COALESCE(Dia11, 0),
        Dia12 = COALESCE(Dia12, 0),
        Dia13 = COALESCE(Dia13, 0),
        Dia14 = COALESCE(Dia14, 0),
        Dia15 = COALESCE(Dia15, 0),
        Dia16 = COALESCE(Dia16, 0),
        Dia17 = COALESCE(Dia17, 0),
        Dia18 = COALESCE(Dia18, 0),
        Dia19 = COALESCE(Dia19, 0),
        Dia20 = COALESCE(Dia20, 0),
        Dia21 = COALESCE(Dia21, 0),
        Dia22 = COALESCE(Dia22, 0),
        Dia23 = COALESCE(Dia23, 0),
        Dia24 = COALESCE(Dia24, 0),
        Dia25 = COALESCE(Dia25, 0),
        Dia26 = COALESCE(Dia26, 0),
        Dia27 = COALESCE(Dia27, 0),
        Dia28 = COALESCE(Dia28, 0),
        Dia29 = CASE WHEN DATEADD(DAY, 29 - 1, @PrimeiroDia) <= @UltimoDia THEN COALESCE(Dia29, 0) ELSE NULL END,
        Dia30 = CASE WHEN DATEADD(DAY, 30 - 1, @PrimeiroDia) <= @UltimoDia THEN COALESCE(Dia30, 0) ELSE NULL END,
        Dia31 = CASE WHEN DATEADD(DAY, 31 - 1, @PrimeiroDia) <= @UltimoDia THEN COALESCE(Dia31, 0) ELSE NULL END
    WHERE TipoLinha = 1;

    -- Calcula os saldos iniciais e finais de todos os dias

    
    DECLARE @Anterior DECIMAL(12, 2), @Total DECIMAL(12, 2), @Movimento DECIMAL(12,2); 

    SELECT @Anterior = Dia01 FROM @TabelaFinal WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia01) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Anterior + @Movimento;
    UPDATE @TabelaFinal SET Dia01 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia02 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia02) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia02 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia03 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia03) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia03 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia04 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia04) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia04 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia05 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia05) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia05 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia06 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia06) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia06 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia07 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia07) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia07 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia08 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia08) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia08 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia09 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia09) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia09 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia10 = @Total WHERE TipoLinha = 0;
        
    SELECT @Movimento = SUM(Dia10) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia10 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia11 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia11) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia11 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia12 = @Total WHERE TipoLinha = 0;
        
    SELECT @Movimento = SUM(Dia12) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia12 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia13 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia13) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia13 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia14 = @Total WHERE TipoLinha = 0;
            
    SELECT @Movimento = SUM(Dia14) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia14 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia15 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia15) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia15 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia16 = @Total WHERE TipoLinha = 0;
                
    SELECT @Movimento = SUM(Dia16) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia16 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia17 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia17) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia17 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia18 = @Total WHERE TipoLinha = 0;
            
    SELECT @Movimento = SUM(Dia18) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia18 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia19 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia19) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia19 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia20 = @Total WHERE TipoLinha = 0;
                
    SELECT @Movimento = SUM(Dia20) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia20 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia21 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia21) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia21 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia22 = @Total WHERE TipoLinha = 0;
                    
    SELECT @Movimento = SUM(Dia22) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia22 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia23 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia23) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia23 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia24 = @Total WHERE TipoLinha = 0;
                        
    SELECT @Movimento = SUM(Dia24) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia24 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia25 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia25) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia25 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia26 = @Total WHERE TipoLinha = 0;
                            
    SELECT @Movimento = SUM(Dia26) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia26 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia27 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia27) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia27 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia28 = @Total WHERE TipoLinha = 0;
                                
    SELECT @Movimento = SUM(Dia28) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia28 = @Total WHERE TipoLinha = 3;
    
    IF (DATEADD(DAY, 29 - 1, @PrimeiroDia) <= @UltimoDia)
    BEGIN
        UPDATE @TabelaFinal SET Dia29 = @Total WHERE TipoLinha = 0;

        SELECT @Movimento = SUM(Dia29) FROM @TabelaFinal WHERE TipoLinha = 1;
        SET    @Total = @Total + @Movimento;
        UPDATE @TabelaFinal SET Dia29 = @Total WHERE TipoLinha = 3;
        UPDATE @TabelaFinal SET Dia30 = @Total WHERE TipoLinha = 0;
    END;
                                    
    IF (DATEADD(DAY, 30 - 1, @PrimeiroDia) <= @UltimoDia)
    BEGIN
        SELECT @Movimento = SUM(Dia30) FROM @TabelaFinal WHERE TipoLinha = 1;
        SET    @Total = @Total + @Movimento;
        UPDATE @TabelaFinal SET Dia30 = @Total WHERE TipoLinha = 3;
        UPDATE @TabelaFinal SET Dia31 = @Total WHERE TipoLinha = 0;
    END;
    
    IF (DATEADD(DAY, 31 - 1, @PrimeiroDia) <= @UltimoDia)
    BEGIN
        SELECT @Movimento = SUM(Dia31) FROM @TabelaFinal WHERE TipoLinha = 1;
        SET    @Total = @Total + @Movimento;
        UPDATE @TabelaFinal SET Dia31 = @Total WHERE TipoLinha = 3;
    END;

    -- Totaliza as categorias

    UPDATE @TabelaFinal
    SET TotalCategoria = @Anterior
    WHERE TipoLinha = 0;

    UPDATE @TabelaFinal
    SET TotalCategoria = COALESCE(Dia01, 0) + COALESCE(Dia02, 0) + COALESCE(Dia03, 0) + COALESCE(Dia04, 0) + COALESCE(Dia05, 0) +
                         COALESCE(Dia06, 0) + COALESCE(Dia07, 0) + COALESCE(Dia08, 0) + COALESCE(Dia09, 0) + COALESCE(Dia10, 0) +
                         COALESCE(Dia11, 0) + COALESCE(Dia12, 0) + COALESCE(Dia13, 0) + COALESCE(Dia14, 0) + COALESCE(Dia15, 0) +
                         COALESCE(Dia16, 0) + COALESCE(Dia17, 0) + COALESCE(Dia18, 0) + COALESCE(Dia19, 0) + COALESCE(Dia20, 0) +
                         COALESCE(Dia21, 0) + COALESCE(Dia22, 0) + COALESCE(Dia23, 0) + COALESCE(Dia24, 0) + COALESCE(Dia25, 0) +
                         COALESCE(Dia26, 0) + COALESCE(Dia27, 0) + COALESCE(Dia28, 0) + COALESCE(Dia29, 0) + COALESCE(Dia30, 0) +
                         COALESCE(Dia31, 0)
    WHERE TipoLinha = 2;

    UPDATE @TabelaFinal
    SET TotalCategoria = (SELECT SUM(TotalCategoria)
                          FROM @TabelaFinal
                          WHERE Tipo = 'C' AND TipoLinha = 2)
    WHERE Tipo = 'C'
    AND   TipoLinha = 1;

    UPDATE @TabelaFinal
    SET TotalCategoria = (SELECT SUM(TotalCategoria)
                          FROM @TabelaFinal
                          WHERE Tipo = 'D' AND TipoLinha = 2)
    WHERE Tipo = 'D'
    AND   TipoLinha = 1;

    UPDATE @TabelaFinal
    SET TotalCategoria = (SELECT SUM(TotalCategoria)
                          FROM @TabelaFinal
                          WHERE Tipo = 'T' AND TipoLinha = 2)
    WHERE Tipo = 'T'
    AND   TipoLinha = 1;

    UPDATE @TabelaFinal
    SET TotalCategoria = @Anterior +
                         (SELECT SUM(TotalCategoria)
                          FROM @TabelaFinal
                          WHERE TipoLinha = 2)
    WHERE TipoLinha = 3;


    SELECT Tipo, TipoLinha, CategoriaID, ContaID, Categoria,
           Dia01, Dia02, Dia03, Dia04, Dia05, Dia06, Dia07, Dia08, Dia09, Dia10,
           Dia11, Dia12, Dia13, Dia14, Dia15, Dia16, Dia17, Dia18, Dia19, Dia20,
           Dia21, Dia22, Dia23, Dia24, Dia25, Dia26, Dia27, Dia28, Dia29, Dia30, Dia31, 
           TotalCategoria,
           @PrimeiroDia PrimeiroDia, @UltimoDia UltimoDia
    FROM @TabelaFinal Final
    ORDER BY Final.Tipo ASC, Final.TipoLinha ASC, Final.Categoria ASC;


END;
GO
/****** Object:  StoredProcedure [dbo].[stpFluxoCaixaDisponivel]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/************************************************
 Procedure stpFluxoCaixaDisponivel
 Monta um pivô com o fluxo de caixa de TODAS as 
 contas dos grupos de contas marcados como 
 Fluxo de Caixa = 1
 Elcio Reis - 04/09/2019
 Exemplo de execução:
 EXEC stpFluxoCaixaDisponivel 2, '2019-09-03';
 ************************************************/

CREATE PROCEDURE [dbo].[stpFluxoCaixaDisponivel] @UsuarioID INT, @DataReferencia DATE
AS
BEGIN

    -- Calcula o primeiro dia do mês
    DECLARE @PrimeiroDia DATE = DATEADD(DAY, 1, EOMONTH(@DataReferencia, -1));
    -- Calcula o último dia do mês
    DECLARE @UltimoDia DATE = EOMONTH(@DataReferencia);

    -- Cria uma tabela com todos os dias do mês em referência
    DECLARE @Dias TABLE (Indice SMALLINT, Dia DATE);
    -- Cria uma tabela com todas as contas que entrarão no fluxo de caixa
    DECLARE @Contas TABLE (ContaID INT);

    -- Acrescenta todos os dias do mês na tabela @Dias
    DECLARE @Dia DATE = @PrimeiroDia; -- DATEADD(DAY, -1, @PrimeiroDia);
    DECLARE @Indice SMALLINT = 1;

    WHILE (@Dia <= @UltimoDia)
    BEGIN
        INSERT INTO @Dias
        (Indice, Dia)
        VALUES
        (@Indice, @Dia);

        SET @Indice = @Indice + 1;
        SET @Dia = DATEADD(DAY, 1, @Dia);
    END; -- WHILE
    
    --SELECT * FROM @Dias;
    INSERT INTO @Contas
    (ContaID)
    SELECT ContaID
    FROM GrupoConta GpCt
         JOIN TipoConta Tipo ON Tipo.GrupoContaID = GpCt.GrupoContaID
         JOIN Conta Cnta ON Cnta.TipoContaID = Tipo.TipoContaID
    WHERE GpCt.FluxoDisponivel = 1
    AND   Cnta.UsuarioID = @UsuarioID;

    DECLARE @TabelaFinal TABLE (Tipo             CHAR(1),
                                TipoLinha        SMALLINT,
                                CategoriaID      INT,
                                ContaID          INT,
                                Categoria        VARCHAR(50),
                                Dia01            DECIMAL(12,2),
                                Dia02            DECIMAL(12,2),
                                Dia03            DECIMAL(12,2),
                                Dia04            DECIMAL(12,2),
                                Dia05            DECIMAL(12,2),
                                Dia06            DECIMAL(12,2),
                                Dia07            DECIMAL(12,2),
                                Dia08            DECIMAL(12,2),
                                Dia09            DECIMAL(12,2),
                                Dia10            DECIMAL(12,2),
                                Dia11            DECIMAL(12,2),
                                Dia12            DECIMAL(12,2),
                                Dia13            DECIMAL(12,2),
                                Dia14            DECIMAL(12,2),
                                Dia15            DECIMAL(12,2),
                                Dia16            DECIMAL(12,2),
                                Dia17            DECIMAL(12,2),
                                Dia18            DECIMAL(12,2),
                                Dia19            DECIMAL(12,2),
                                Dia20            DECIMAL(12,2),
                                Dia21            DECIMAL(12,2),
                                Dia22            DECIMAL(12,2),
                                Dia23            DECIMAL(12,2),
                                Dia24            DECIMAL(12,2),
                                Dia25            DECIMAL(12,2),
                                Dia26            DECIMAL(12,2),
                                Dia27            DECIMAL(12,2),
                                Dia28            DECIMAL(12,2),
                                Dia29            DECIMAL(12,2),
                                Dia30            DECIMAL(12,2),
                                Dia31            DECIMAL(12,2),
                                TotalCategoria   DECIMAL(12,2));

    DECLARE @EspacoSimpl VARCHAR(10) = '      ';
    DECLARE @EspacoDuplo VARCHAR(20) = @EspacoSimpl + @EspacoSimpl;
 
    WITH Fase01 AS (SELECT Dias.Indice Dia,
                           CSel.vCrdDeb Tipo,
                           --CSel.CategoriaPaiID CategoriaID,
                           CASE WHEN CSel.vCrdDeb = 'T' THEN 0
                                ELSE CSel.CategoriaPaiID
                           END CategoriaID,
                           CASE WHEN CSel.ContaID > 0 THEN CSel.ContaID ELSE 0 END ContaID,
                           @EspacoDuplo + CASE WHEN CSel.vCrdDeb = 'T' THEN SUBSTRING(CSel.vFiltro, 2, LEN(CSel.vFiltro)-2)
                                               ELSE Ctgr.Apelido
                                          END Categoria,
                           MvCt.Valor
                    FROM MovimentoConta MvCt
                         JOIN @Contas Cnta ON Cnta.ContaID = MvCt.ContaID
                         JOIN @Dias Dias ON Dias.Dia = CAST(MvCt.Data AS DATE)
                         JOIN vw_CategoriasSelecionaveis CSel ON CSel.CategoriaID = MvCt.CategoriaID
                                                             AND CSel.ContaID NOT IN (SELECT ContaID FROM @Contas)
                         JOIN Categoria Ctgr ON Ctgr.CategoriaID = CSel.CategoriaPaiID),
         Fase02 AS (-- Detalhes
                    SELECT 2 TipoLinha, Tipo, Dia, Valor, CategoriaID, ContaID, Categoria
                    FROM Fase01

                    UNION ALL

                    -- Total por categoria
                    SELECT 1 TipoLinha, Tipo, Dia, SUM(Valor) Valor, 0 CategoriaID, 0 ContaID,
                           CASE Tipo
                                WHEN 'C' THEN @EspacoSimpl + 'Total Entradas'
                                WHEN 'D' THEN @EspacoSimpl + 'Total Saídas'
                                WHEN 'T' THEN @EspacoSimpl + 'Total Transferência'
                                ELSE NULL
                            END Categoria
                    FROM Fase01
                    GROUP BY Tipo, Dia

                    UNION ALL
                    
                    SELECT 0 TipoLinha, 'A' Tipo, 1 Dia, 
                           SUM(COALESCE(MvCt.Credito, 0) - COALESCE(MvCt.Debito, 0)) Valor,
                           0 CategoriaID, 0 ContaID, 'Saldo Inicial' Categoria
                    FROM MovimentoConta MvCt
                         JOIN @Contas Cnta ON Cnta.ContaID = MvCt.ContaID
                    WHERE MvCt.Data < @PrimeiroDia

                    UNION ALL

                    -- Saldo Final
                    SELECT 3 TipoLinha, 'Z' Tipo, Dia, 0 Valor, 0 CategoriaID, 0 ContaID,
                           'Saldo Final a Transportar' Categoria
                    FROM Fase01
                    GROUP BY Dia)
    INSERT INTO @TabelaFinal
    (Tipo, TipoLinha, CategoriaID, ContaID, Categoria,
     Dia01, Dia02, Dia03, Dia04, Dia05, Dia06, Dia07, Dia08, Dia09, Dia10,
     Dia11, Dia12, Dia13, Dia14, Dia15, Dia16, Dia17, Dia18, Dia19, Dia20,
     Dia21, Dia22, Dia23, Dia24, Dia25, Dia26, Dia27, Dia28, Dia29, Dia30, Dia31)
    SELECT Tipo, TipoLinha, CategoriaID, ContaID, Categoria,
            [1] 'DIA01',  [2] 'DIA02',  [3] 'DIA03',  [4] 'DIA04',  [5] 'DIA05',  [6] 'DIA06',  [7] 'DIA07',  [8] 'DIA08',  [9] 'DIA09', [10] 'DIA10',
           [11] 'DIA11', [12] 'DIA12', [13] 'DIA13', [14] 'DIA14', [15] 'DIA15', [16] 'DIA16', [17] 'DIA17', [18] 'DIA18', [19] 'DIA19', [20] 'DIA20',
           [21] 'DIA21', [22] 'DIA22', [23] 'DIA23', [24] 'DIA24', [25] 'DIA25', [26] 'DIA26', [27] 'DIA27', [28] 'DIA28', [29] 'DIA29', [30] 'DIA30',
           [31] 'DIA31'
    FROM (SELECT Dia, Tipo, TipoLinha, CategoriaID, ContaID, Categoria, Valor FROM Fase02) Origem
    PIVOT (SUM(Valor) FOR Dia IN ( [1], [2], [3], [4], [5], [6], [7], [8], [9],[10],
                                  [11],[12],[13],[14],[15],[16],[17],[18],[19],[20],
                                  [21],[22],[23],[24],[25],[26],[27],[28],[29],[30],
                                  [31])) Final
    ORDER BY Tipo ASC, TipoLinha ASC, Categoria ASC;

    UPDATE @TabelaFinal
    SET Dia01 = COALESCE(Dia01, 0),
        Dia02 = COALESCE(Dia02, 0),
        Dia03 = COALESCE(Dia03, 0),
        Dia04 = COALESCE(Dia04, 0),
        Dia05 = COALESCE(Dia05, 0),
        Dia06 = COALESCE(Dia06, 0),
        Dia07 = COALESCE(Dia07, 0),
        Dia08 = COALESCE(Dia08, 0),
        Dia09 = COALESCE(Dia09, 0),
        Dia10 = COALESCE(Dia10, 0),
        Dia11 = COALESCE(Dia11, 0),
        Dia12 = COALESCE(Dia12, 0),
        Dia13 = COALESCE(Dia13, 0),
        Dia14 = COALESCE(Dia14, 0),
        Dia15 = COALESCE(Dia15, 0),
        Dia16 = COALESCE(Dia16, 0),
        Dia17 = COALESCE(Dia17, 0),
        Dia18 = COALESCE(Dia18, 0),
        Dia19 = COALESCE(Dia19, 0),
        Dia20 = COALESCE(Dia20, 0),
        Dia21 = COALESCE(Dia21, 0),
        Dia22 = COALESCE(Dia22, 0),
        Dia23 = COALESCE(Dia23, 0),
        Dia24 = COALESCE(Dia24, 0),
        Dia25 = COALESCE(Dia25, 0),
        Dia26 = COALESCE(Dia26, 0),
        Dia27 = COALESCE(Dia27, 0),
        Dia28 = COALESCE(Dia28, 0),
        Dia29 = CASE WHEN DATEADD(DAY, 29 - 1, @PrimeiroDia) <= @UltimoDia THEN COALESCE(Dia29, 0) ELSE NULL END,
        Dia30 = CASE WHEN DATEADD(DAY, 30 - 1, @PrimeiroDia) <= @UltimoDia THEN COALESCE(Dia30, 0) ELSE NULL END,
        Dia31 = CASE WHEN DATEADD(DAY, 31 - 1, @PrimeiroDia) <= @UltimoDia THEN COALESCE(Dia31, 0) ELSE NULL END
    WHERE TipoLinha = 1;

    -- Calcula os saldos iniciais e finais de todos os dias

    
    DECLARE @Anterior DECIMAL(12, 2), @Total DECIMAL(12, 2), @Movimento DECIMAL(12,2); 

    SELECT @Anterior = Dia01 FROM @TabelaFinal WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia01) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Anterior + @Movimento;
    UPDATE @TabelaFinal SET Dia01 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia02 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia02) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia02 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia03 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia03) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia03 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia04 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia04) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia04 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia05 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia05) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia05 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia06 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia06) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia06 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia07 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia07) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia07 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia08 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia08) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia08 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia09 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia09) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia09 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia10 = @Total WHERE TipoLinha = 0;
        
    SELECT @Movimento = SUM(Dia10) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia10 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia11 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia11) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia11 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia12 = @Total WHERE TipoLinha = 0;
        
    SELECT @Movimento = SUM(Dia12) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia12 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia13 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia13) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia13 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia14 = @Total WHERE TipoLinha = 0;
            
    SELECT @Movimento = SUM(Dia14) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia14 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia15 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia15) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia15 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia16 = @Total WHERE TipoLinha = 0;
                
    SELECT @Movimento = SUM(Dia16) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia16 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia17 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia17) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia17 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia18 = @Total WHERE TipoLinha = 0;
            
    SELECT @Movimento = SUM(Dia18) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia18 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia19 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia19) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia19 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia20 = @Total WHERE TipoLinha = 0;
                
    SELECT @Movimento = SUM(Dia20) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia20 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia21 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia21) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia21 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia22 = @Total WHERE TipoLinha = 0;
                    
    SELECT @Movimento = SUM(Dia22) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia22 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia23 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia23) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia23 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia24 = @Total WHERE TipoLinha = 0;
                        
    SELECT @Movimento = SUM(Dia24) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia24 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia25 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia25) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia25 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia26 = @Total WHERE TipoLinha = 0;
                            
    SELECT @Movimento = SUM(Dia26) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia26 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia27 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia27) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia27 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Dia28 = @Total WHERE TipoLinha = 0;
                                
    SELECT @Movimento = SUM(Dia28) FROM @TabelaFinal WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Dia28 = @Total WHERE TipoLinha = 3;
    
    IF (DATEADD(DAY, 29 - 1, @PrimeiroDia) <= @UltimoDia)
    BEGIN
        UPDATE @TabelaFinal SET Dia29 = @Total WHERE TipoLinha = 0;

        SELECT @Movimento = SUM(Dia29) FROM @TabelaFinal WHERE TipoLinha = 1;
        SET    @Total = @Total + @Movimento;
        UPDATE @TabelaFinal SET Dia29 = @Total WHERE TipoLinha = 3;
        UPDATE @TabelaFinal SET Dia30 = @Total WHERE TipoLinha = 0;
    END;
                                    
    IF (DATEADD(DAY, 30 - 1, @PrimeiroDia) <= @UltimoDia)
    BEGIN
        SELECT @Movimento = SUM(Dia30) FROM @TabelaFinal WHERE TipoLinha = 1;
        SET    @Total = @Total + @Movimento;
        UPDATE @TabelaFinal SET Dia30 = @Total WHERE TipoLinha = 3;
        UPDATE @TabelaFinal SET Dia31 = @Total WHERE TipoLinha = 0;
    END;
    
    IF (DATEADD(DAY, 31 - 1, @PrimeiroDia) <= @UltimoDia)
    BEGIN
        SELECT @Movimento = SUM(Dia31) FROM @TabelaFinal WHERE TipoLinha = 1;
        SET    @Total = @Total + @Movimento;
        UPDATE @TabelaFinal SET Dia31 = @Total WHERE TipoLinha = 3;
    END;

    -- Totaliza as categorias

    UPDATE @TabelaFinal
    SET TotalCategoria = @Anterior
    WHERE TipoLinha = 0;

    UPDATE @TabelaFinal
    SET TotalCategoria = COALESCE(Dia01, 0) + COALESCE(Dia02, 0) + COALESCE(Dia03, 0) + COALESCE(Dia04, 0) + COALESCE(Dia05, 0) +
                         COALESCE(Dia06, 0) + COALESCE(Dia07, 0) + COALESCE(Dia08, 0) + COALESCE(Dia09, 0) + COALESCE(Dia10, 0) +
                         COALESCE(Dia11, 0) + COALESCE(Dia12, 0) + COALESCE(Dia13, 0) + COALESCE(Dia14, 0) + COALESCE(Dia15, 0) +
                         COALESCE(Dia16, 0) + COALESCE(Dia17, 0) + COALESCE(Dia18, 0) + COALESCE(Dia19, 0) + COALESCE(Dia20, 0) +
                         COALESCE(Dia21, 0) + COALESCE(Dia22, 0) + COALESCE(Dia23, 0) + COALESCE(Dia24, 0) + COALESCE(Dia25, 0) +
                         COALESCE(Dia26, 0) + COALESCE(Dia27, 0) + COALESCE(Dia28, 0) + COALESCE(Dia29, 0) + COALESCE(Dia30, 0) +
                         COALESCE(Dia31, 0)
    WHERE TipoLinha = 2;

    UPDATE @TabelaFinal
    SET TotalCategoria = (SELECT SUM(TotalCategoria)
                          FROM @TabelaFinal
                          WHERE Tipo = 'C' AND TipoLinha = 2)
    WHERE Tipo = 'C'
    AND   TipoLinha = 1;

    UPDATE @TabelaFinal
    SET TotalCategoria = (SELECT SUM(TotalCategoria)
                          FROM @TabelaFinal
                          WHERE Tipo = 'D' AND TipoLinha = 2)
    WHERE Tipo = 'D'
    AND   TipoLinha = 1;

    UPDATE @TabelaFinal
    SET TotalCategoria = (SELECT SUM(TotalCategoria)
                          FROM @TabelaFinal
                          WHERE Tipo = 'T' AND TipoLinha = 2)
    WHERE Tipo = 'T'
    AND   TipoLinha = 1;

    UPDATE @TabelaFinal
    SET TotalCategoria = @Anterior +
                         (SELECT SUM(TotalCategoria)
                          FROM @TabelaFinal
                          WHERE TipoLinha = 2)
    WHERE TipoLinha = 3;


    SELECT Tipo, TipoLinha, CategoriaID, ContaID, Categoria,
           Dia01, Dia02, Dia03, Dia04, Dia05, Dia06, Dia07, Dia08, Dia09, Dia10,
           Dia11, Dia12, Dia13, Dia14, Dia15, Dia16, Dia17, Dia18, Dia19, Dia20,
           Dia21, Dia22, Dia23, Dia24, Dia25, Dia26, Dia27, Dia28, Dia29, Dia30, Dia31, 
           TotalCategoria,
           @PrimeiroDia PrimeiroDia, @UltimoDia UltimoDia
    FROM @TabelaFinal Final
    ORDER BY Final.Tipo ASC, Final.TipoLinha ASC, Final.Categoria ASC;


END;
GO
/****** Object:  StoredProcedure [dbo].[stpGravarAtualizacaoM02_M03]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[stpGravarAtualizacaoM02_M03]
as
begin


	UPDATE MoneyPro
	SET AtualizacaoM02_M03 = CONVERT(DATE, GETDATE())
	WHERE MoneyProID = (SELECT MAX(MoneyProID) FROM MoneyPro);


end;
GO
/****** Object:  StoredProcedure [dbo].[stpGravarAtualizacaoM04_M11]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[stpGravarAtualizacaoM04_M11]
as
begin


	UPDATE MoneyPro
	SET AtualizacaoM04_M11 = CONVERT(DATE, GETDATE())
	WHERE MoneyProID = (SELECT MAX(MoneyProID) FROM MoneyPro);


end;
GO
/****** Object:  StoredProcedure [dbo].[stpHaInvestimentosNaSelecao]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/***********************************************************************
 EXEC stpHaInvestimentosNaSelecao 'M', '0;1;4;1014;1019';
 ***********************************************************************/

CREATE PROCEDURE [dbo].[stpHaInvestimentosNaSelecao]
    @Periodo CHAR(1) = 'D',
    @Investimentos VARCHAR(MAX) = '',
    @DtInicio DATETIME = NULL
AS
BEGIN

    SET NOCOUNT ON;

    -- Variáveis auxiliares
    DECLARE @InvestimentoID  INT,
	        @Contador        INT,
			@IncluirPoupanca INT = -1,
            @Comando         NVARCHAR(MAX);

    -- Declara uma tabela para os investimentos selecionados
	DECLARE @Selecionados TABLE (
		InvestimentoID INT
    );

    -- Se a relação de investimento foi passada, garante que a lista termine por ponto e vírgula
    -- Procura a data mínima igual para toda a lista de investimentos
    IF (@Investimentos IS NOT NULL) 
    BEGIN

        -- Garante que a lista de investimentos termina por ponto e vírgula
        IF RIGHT(@Investimentos,1) <> ';'
            SET @Investimentos = @Investimentos + ';';

        DECLARE @CodigosInv VARCHAR(30);

        SET @CodigosInv = @Investimentos;

        DECLARE @DtMinima DATE, 
                @DtAux    DATE;

        -- Data utilizada na tabela de configuração
        SELECT @DtMinima = DtInicioUtilizacao
        FROM MoneyPro 
        WHERE MoneyProID = (SELECT MAX(MoneyProID) FROM MoneyPro);

		-- A data mínima será a maior entre a data de início da utilização e a mais nova aplicação
        
        SET @Contador = 0;
         
        WHILE (@CodigosInv > '')
        BEGIN

			SET @InvestimentoID = CAST(LEFT(@CodigosInv, CHARINDEX(';', @CodigosInv) - 1) AS INT);
			
			IF (@InvestimentoID = 0)
				SET @IncluirPoupanca = 0; 

			-- Coloca o código do investimento em @Selecionados
			INSERT INTO @Selecionados
			(InvestimentoID)
			VALUES
			(@InvestimentoID);


            SELECT @DtAux = MIN(Data)
            FROM InvestimentoCotacao Invt
            WHERE Invt.InvestimentoID = @InvestimentoID

            IF (@DtAux > @DtMinima)
            BEGIN
                SET @DtMinima = @DtAux;
            END;

            -- Descarta o primeiro código da lista.
            SET @CodigosInv = RIGHT(@CodigosInv, LEN(@CodigosInv) - CHARINDEX(';', @CodigosInv));

            SET @Contador = @Contador + 1;

        END;

    END;

    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;

	CREATE TABLE #Tabela (
        Registro        INT,
		Data            DATE,
		ContaID         INT,
		Valor           NUMERIC(19,2),
        InvestimentoID  INT
	);

	DECLARE @Datas TABLE (
		Data     DATE
    );

	INSERT INTO @Datas
	EXEC stpDataParaPesquisa @Periodo, @DtInicio;

	-- Insere os movimentos de investimento.
	INSERT INTO #Tabela
	SELECT ROW_NUMBER() OVER(ORDER BY Data.Data ASC) AS Registro,
           Data.Data, Cnta.ContaID, 
	       dbo.fncLucroContaInvestimentoData(Cnta.ContaID, Data.Data) - dbo.fncContaInvestimentoDataImpostoPago(Cnta.ContaID, Data.Data) AS Valor,
           MvIv.InvestimentoID AS Investimento
    FROM Conta Cnta	    
         INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
		 INNER JOIN @Datas Data ON 1 = 1
		 INNER JOIN MovimentoConta MvCt ON MvCt.ContaID = Cnta.ContaID AND Mvct.Data <= Data.Data
         INNER JOIN MovimentoInvestimento MvIv ON MvIv.MovimentoContaID = MvCt.MovimentoContaID AND MvIv.VrLiquido <> 0
		 INNER JOIN @Selecionados Selc ON Selc.InvestimentoID = MvIv.InvestimentoID
    WHERE Tipo.Investimento = 1	
	GROUP BY Data.Data, Cnta.ContaID, MvIv.InvestimentoID
	ORDER BY Data.Data ASC;

    -- Atualiza os valores pelo cálculo dos investimentos descontando os impostos
    DECLARE @regMinimo INT, @regMaximo INT;
    DECLARE @Data DATE, @ValorSTP NUMERIC(18,2);

    SELECT @regMinimo = MIN(Registro) FROM #Tabela;
    SELECT @regMaximo = MAX(Registro) FROM #Tabela;

    DECLARE @Valor TABLE (
        Valor    NUMERIC(18,2)
    );


    WHILE (@regMinimo <= @regMaximo)
    BEGIN

        SELECT @InvestimentoID = InvestimentoID,
               @Data = Data
        FROM #Tabela
        WHERE Registro = @regMinimo;

        INSERT INTO @Valor
        EXEC stpDetalhesInvestimento @InvestimentoID, @Data, 1, 0;

        SELECT @ValorSTP = Valor FROM @Valor;

        UPDATE #Tabela
        SET Valor = @ValorSTP
        WHERE Registro = @regMinimo;

        DELETE FROM @Valor;

        SELECT @regMinimo = @regMinimo + 1;
    END;

	-- Insere os movimentos de poupança
	INSERT INTO #Tabela
	SELECT 0 AS Registro, Data.Data, Mvto.ContaID, SUM(Mvto.Valor) AS Valor, 0 AS Investimento
	FROM @Datas Data
    INNER JOIN MovimentoConta Mvto ON Mvto.Data <= Data.Data
    INNER JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
    INNER JOIN TipoConta TCta ON TCta.TipoContaID = Cnta.TipoContaID
	WHERE Mvto.Sistema <> 1                      -- Não é operação do sistema (abertura de conta)
    AND Mvto.DoMovimentoContaID IS NULL          -- Não é fruto de transferência
    AND Mvto.Valor > 0                           -- Valor maior que zero
    AND TCta.Poupanca = 1                        -- Tipo de conta é poupança  
	AND @IncluirPoupanca = 0                     -- Se houver o parâmetro ZERO na lista de investimentos inclui as cadernetas de poupança
    GROUP BY Mvto.ContaID, Data.Data;

    DECLARE @ColOrigem VARCHAR(MAX) = '';
    DECLARE @ColDestino VARCHAR(MAX) = '';

    DECLARE @ContaID INT;
    DECLARE @Apelido VARCHAR(40);
    DECLARE @Ordem INT;

    IF (@Periodo = 'M')
    BEGIN
        UPDATE #Tabela
        SET Data = dbo.fncMeioDoMes(Data);

        INSERT INTO #Tabela
        SELECT 0 AS Registro, Data, -1 AS ContaID, SUM(Valor) AS Valor, -1 AS InvestimentoID
        FROM #Tabela
        WHERE Valor IS NOT NULL
        GROUP BY Data;
    END;

    SELECT COUNT(*)
        FROM #Tabela
		LEFT JOIN Investimento Inv ON Inv.InvestimentoID = #Tabela.InvestimentoID
		LEFT JOIN Conta Cta ON Cta.ContaID = #Tabela.ContaID
		WHERE Valor <> 0;

    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpHistoricoCotacaoComparativo]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpHistoricoCotacaoComparativo]
    @Investimentos VARCHAR(MAX),
    @Tipo CHAR(1) = 'D',
    @DtInicio DATETIME = NULL
AS
BEGIN

    SET NOCOUNT ON;

    -- Variáveis auxiliares
    DECLARE @InvestimentoID INT,
            @Contador       INT,
            @Comando        NVARCHAR(MAX);

    -- Se a relação de investimento foi passada, garante que a lista termine por ponto e vírgula
    -- Procura a data mínima igual para toda a lista de investimentos
    IF (@Investimentos IS NOT NULL) 
    BEGIN

        -- Garante que a lista de investimentos termina por ponto e vírgula
        IF RIGHT(@Investimentos,1) <> ';'
            SET @Investimentos = @Investimentos + ';';

        DECLARE @CodigosInv VARCHAR(30);

        SET @CodigosInv = @Investimentos;

        DECLARE @DtMinima DATE, 
                @DtAux    DATE;
       
        IF (@DtInicio IS NULL)
        BEGIN
            -- Data utilizada na tabela de configuração
            SELECT @DtMinima = DtInicioUtilizacao
            FROM MoneyPro 
            WHERE MoneyProID = (SELECT MAX(MoneyProID) FROM MoneyPro);
        END
        ELSE
        BEGIN
            SET @DtMinima = @DtInicio;
        END;

        
        SET @Contador = 0;
         
        WHILE (@CodigosInv > '')
        BEGIN

            SELECT @DtAux = MIN(Data)
            FROM InvestimentoCotacao Invt
            WHERE Invt.InvestimentoID = CAST(LEFT(@CodigosInv, CHARINDEX(';', @CodigosInv) - 1) AS INT);

            IF (@DtAux > @DtMinima)
            BEGIN
                SET @DtMinima = @DtAux;
            END;

            -- Descarta o primeiro código da lista.
            SET @CodigosInv = RIGHT(@CodigosInv, LEN(@CodigosInv) - CHARINDEX(';', @CodigosInv));

            SET @Contador = @Contador + 1;

        END;

        SET @DtInicio = @DtMinima;

    END;

    DECLARE @tblResposta TABLE (
        Data          DATE,
        VrCotacao0    NUMERIC(18,8),
        Porcentagem0  NUMERIC(18,4),
        VrCotacao1    NUMERIC(18,8),
        Porcentagem1  NUMERIC(18,4),
        VrCotacao2    NUMERIC(18,8),
        Porcentagem2  NUMERIC(18,4),
        VrCotacao3    NUMERIC(18,8),
        Porcentagem3  NUMERIC(18,4),
        VrCotacao4    NUMERIC(18,8),
        Porcentagem4  NUMERIC(18,4),
        VrCotacao5    NUMERIC(18,8),
        Porcentagem5  NUMERIC(18,4),
        VrCotacao6    NUMERIC(18,8),
        Porcentagem6  NUMERIC(18,4),
        VrCotacao7    NUMERIC(18,8),
        Porcentagem7  NUMERIC(18,4)
    );

    IF (@Contador > 1)
    BEGIN
        -- Avança um dia para não comparar o dia inicial com nulo
        SET @DtInicio = DATEADD(DAY, 1, @DtInicio);
    END;

    INSERT INTO @tblResposta
    (Data)
    EXEC stpDataParaPesquisa @Tipo, @DtInicio;

    IF NOT @Investimentos IS NULL
    BEGIN     

        SET @Contador = 0; 
  
        -- Inserir as contas correntes informadas pelo operador
        WHILE (@Investimentos > '' AND @Contador <  8)
        BEGIN

            SET @InvestimentoID = CAST(LEFT(@Investimentos, CHARINDEX(';', @Investimentos) - 1) AS int);

            IF (@Contador = 0)
            BEGIN

                -- Preenche a primeira cotação
                UPDATE @tblResposta
                SET VrCotacao0 = Cota.VrCotacao
                FROM @tblResposta Resp
                     INNER JOIN InvestimentoCotacao Cota
                        ON Cota.Data = Resp.Data
                       AND Cota.InvestimentoID = @InvestimentoID;

            END
            ELSE IF (@Contador = 1)
            BEGIN

                -- Preenche a segunda cotação
                UPDATE @tblResposta
                SET VrCotacao1 = Cota.VrCotacao
                FROM @tblResposta Resp
                     INNER JOIN InvestimentoCotacao Cota
                        ON Cota.Data = Resp.Data
                       AND Cota.InvestimentoID = @InvestimentoID;

            END
            ELSE IF (@Contador = 2)
            BEGIN

                -- Preenche a terceira cotação
                UPDATE @tblResposta
                SET VrCotacao2 = Cota.VrCotacao
                FROM @tblResposta Resp
                     INNER JOIN InvestimentoCotacao Cota
                        ON Cota.Data = Resp.Data
                       AND Cota.InvestimentoID = @InvestimentoID;

            END
            ELSE IF (@Contador = 3)
            BEGIN

                -- Preenche a quarta cotação
                UPDATE @tblResposta
                SET VrCotacao3 = Cota.VrCotacao
                FROM @tblResposta Resp
                     INNER JOIN InvestimentoCotacao Cota
                        ON Cota.Data = Resp.Data
                       AND Cota.InvestimentoID = @InvestimentoID;

            END
            ELSE IF (@Contador = 4)
            BEGIN

                -- Preenche a quinta cotação
                UPDATE @tblResposta
                SET VrCotacao4 = Cota.VrCotacao
                FROM @tblResposta Resp
                     INNER JOIN InvestimentoCotacao Cota
                        ON Cota.Data = Resp.Data
                       AND Cota.InvestimentoID = @InvestimentoID;

            END
            ELSE IF (@Contador = 5)
            BEGIN

                -- Preenche a quinta cotação
                UPDATE @tblResposta
                SET VrCotacao5 = Cota.VrCotacao
                FROM @tblResposta Resp
                     INNER JOIN InvestimentoCotacao Cota
                        ON Cota.Data = Resp.Data
                       AND Cota.InvestimentoID = @InvestimentoID;

            END
            ELSE IF (@Contador = 6)
            BEGIN

                -- Preenche a quinta cotação
                UPDATE @tblResposta
                SET VrCotacao6 = Cota.VrCotacao
                FROM @tblResposta Resp
                     INNER JOIN InvestimentoCotacao Cota
                        ON Cota.Data = Resp.Data
                       AND Cota.InvestimentoID = @InvestimentoID;

            END
            ELSE IF (@Contador = 7)
            BEGIN

                -- Preenche a quinta cotação
                UPDATE @tblResposta
                SET VrCotacao7 = Cota.VrCotacao
                FROM @tblResposta Resp
                     INNER JOIN InvestimentoCotacao Cota
                        ON Cota.Data = Resp.Data
                       AND Cota.InvestimentoID = @InvestimentoID;

            END;

            SET @Contador = @Contador + 1;  
               
            SET @Investimentos = RIGHT(@Investimentos, LEN(@Investimentos) - CHARINDEX(';', @Investimentos));

        END;

    END;

    DECLARE @curData0      DATE,
            @curVrCotacao0 NUMERIC(18,8),
            @curData1      DATE,
            @curVrCotacao1 NUMERIC(18,8),
            @curData2      DATE,
            @curVrCotacao2 NUMERIC(18,8),
            @curData3      DATE,
            @curVrCotacao3 NUMERIC(18,8),
            @curData4      DATE,
            @curVrCotacao4 NUMERIC(18,8),
            @curData5      DATE,
            @curVrCotacao5 NUMERIC(18,8),
            @curData6      DATE,
            @curVrCotacao6 NUMERIC(18,8),
            @curData7      DATE,
            @curVrCotacao7 NUMERIC(18,8);

    SELECT TOP 1
        @curData0      = Data,
        @curVrCotacao0 = VrCotacao0
    FROM @tblResposta 
    WHERE VrCotacao0 IS NOT NULL
    ORDER BY Data ASC;

    SELECT TOP 1
        @curData1      = Data,
        @curVrCotacao1 = VrCotacao1
    FROM @tblResposta 
    WHERE VrCotacao1 IS NOT NULL
    ORDER BY Data ASC;

    SELECT TOP 1
        @curData2      = Data,
        @curVrCotacao2 = VrCotacao2
    FROM @tblResposta 
    WHERE VrCotacao2 IS NOT NULL
    ORDER BY Data ASC;

    SELECT TOP 1
        @curData3      = Data,
        @curVrCotacao3 = VrCotacao3
    FROM @tblResposta 
    WHERE VrCotacao3 IS NOT NULL
    ORDER BY Data ASC;

    SELECT TOP 1
        @curData4      = Data,
        @curVrCotacao4 = VrCotacao4
    FROM @tblResposta 
    WHERE VrCotacao4 IS NOT NULL
    ORDER BY Data ASC;

    SELECT TOP 1
        @curData5      = Data,
        @curVrCotacao5 = VrCotacao4
    FROM @tblResposta 
    WHERE VrCotacao5 IS NOT NULL
    ORDER BY Data ASC;

    SELECT TOP 1
        @curData6      = Data,
        @curVrCotacao6 = VrCotacao4
    FROM @tblResposta 
    WHERE VrCotacao6 IS NOT NULL
    ORDER BY Data ASC;

    SELECT TOP 1
        @curData7      = Data,
        @curVrCotacao7 = VrCotacao4
    FROM @tblResposta 
    WHERE VrCotacao7 IS NOT NULL
    ORDER BY Data ASC;

    UPDATE @tblResposta
    SET Porcentagem0 = CASE WHEN COALESCE(@curVrCotacao0, 0) <> 0 THEN (VrCotacao0 - @curVrCotacao0) / @curVrCotacao0 * 100 ELSE NULL END
    WHERE Data >= @curData0;

    UPDATE @tblResposta
    SET Porcentagem1 = CASE WHEN COALESCE(@curVrCotacao1, 0) <> 0 THEN (VrCotacao1 - @curVrCotacao1) / @curVrCotacao1 * 100 ELSE NULL END
    WHERE Data >= @curData1;

    UPDATE @tblResposta
    SET Porcentagem2 = CASE WHEN COALESCE(@curVrCotacao2, 0) <> 0 THEN (VrCotacao2 - @curVrCotacao2) / @curVrCotacao2 * 100 ELSE NULL END
    WHERE Data >= @curData2;

    UPDATE @tblResposta
    SET Porcentagem3 = CASE WHEN COALESCE(@curVrCotacao3, 0) <> 0 THEN (VrCotacao3 - @curVrCotacao3) / @curVrCotacao3 * 100 ELSE NULL END
    WHERE Data >= @curData3;
    
    UPDATE @tblResposta
    SET Porcentagem4 = CASE WHEN COALESCE(@curVrCotacao4, 0) <> 0 THEN (VrCotacao4 - @curVrCotacao4) / @curVrCotacao4 * 100 ELSE NULL END
    WHERE Data >= @curData4;

    UPDATE @tblResposta
    SET Porcentagem5 = CASE WHEN COALESCE(@curVrCotacao5, 0) <> 0 THEN (VrCotacao5 - @curVrCotacao5) / @curVrCotacao5 * 100 ELSE NULL END
    WHERE Data >= @curData5;
    
    UPDATE @tblResposta
    SET Porcentagem6 = CASE WHEN COALESCE(@curVrCotacao6, 0) <> 0 THEN (VrCotacao6 - @curVrCotacao6) / @curVrCotacao6 * 100 ELSE NULL END
    WHERE Data >= @curData6;
    
    UPDATE @tblResposta
    SET Porcentagem7 = CASE WHEN COALESCE(@curVrCotacao7, 0) <> 0 THEN (VrCotacao7 - @curVrCotacao7) / @curVrCotacao7 * 100 ELSE NULL END
    WHERE Data >= @curData7;

    SELECT Data, 
           Porcentagem0 Valor0, Porcentagem1 Valor1, Porcentagem2 Valor2, Porcentagem3 Valor3,
           Porcentagem4 Valor4, Porcentagem5 Valor5, Porcentagem6 Valor6, Porcentagem7 Valor7
    FROM @tblResposta
	WHERE NOT (Porcentagem0 IS NULL AND 
               Porcentagem1 IS NULL AND 
               Porcentagem2 IS NULL AND 
               Porcentagem3 IS NULL AND 
               Porcentagem4 IS NULL AND 
               Porcentagem5 IS NULL AND 
               Porcentagem6 IS NULL AND 
               Porcentagem7 IS NULL)
    ORDER BY Data;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpHistoricoCotacaoEspecifica]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/***************************************************************
 EXEC stpHistoricoCotacaoEspecifica 1014, 'D'
 ***************************************************************/

CREATE PROCEDURE [dbo].[stpHistoricoCotacaoEspecifica]
    @InvestimentoID INT,
    @Tipo CHAR(1) = 'D',
    @DtInicio DATETIME = NULL
AS
BEGIN

    SET NOCOUNT ON

    -- Declara uma tabela virtual para recever a lista de datas
    DECLARE @tblData TABLE (Data DATETIME);
    -- A tabela virtual recebe a lista de datas a partir de outra procedure
    INSERT INTO @tblData
    EXEC stpDataParaPesquisa @Tipo, @DtInicio;


    DECLARE @tblResposta TABLE (
        Data       DATE,
        VrCotacao  NUMERIC(18,8),
        VrMinimo   FLOAT,
        VrMaximo   FLOAT
    );

    INSERT INTO @tblResposta
    (Data, VrCotacao)
    SELECT tmpD.Data, Cota.VrCotacao
    FROM @tblData tmpD
         INNER JOIN InvestimentoCotacao Cota 
           ON Cota.InvestimentoID = @InvestimentoID
          AND Cota.Data = tmpD.Data


    UPDATE @tblResposta
    SET VrMinimo = (SELECT FLOOR(MIN(VrCotacao)) FROM @tblResposta),
        VrMaximo = (SELECT CEILING(MAX(VrCotacao)) FROM @tblResposta)

    SELECT
        Data,
        VrCotacao,
        VrMinimo,
        VrMaximo
    FROM @tblResposta

END;
GO
/****** Object:  StoredProcedure [dbo].[stpInformaAtualizacao]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[stpInformaAtualizacao]
as
begin


	UPDATE MoneyPro
	SET AtualizarTudo = 0
	WHERE MoneyProID = (SELECT MAX(MoneyProID) FROM MoneyPro);


end;
GO
/****** Object:  StoredProcedure [dbo].[stpInsereAtualizaCotacaoCVM]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpInsereAtualizaCotacaoCVM](
    @CNPJ VARCHAR(18),
    @Data DATE,
    @VrCotacao NUMERIC(25,10),
    @VrTotalCarteira NUMERIC(19,4),
    @VrPatrimonioLiquido NUMERIC(19,4),
    @VrCaptacaoDia NUMERIC(19,4),
    @VrResgateDia NUMERIC(19,4),
    @NroCotistas INTEGER)
AS
BEGIN

    SET NOCOUNT OFF;

    DECLARE @CotacaoCVMID INT;
	DECLARE @CotacaoAlterada INT;

    SELECT @CotacaoCVMID = CotacaoCVMID 
    FROM CotacaoCVM
    WHERE CNPJ = @CNPJ 
      AND Data = @Data;

    IF (@CotacaoCVMID IS NULL)
    BEGIN

	    SET @CotacaoCVMID = NEXT VALUE FOR CotacaoCVM_CotacaoCVMID;


        INSERT INTO CotacaoCVM
        (CotacaoCVMID, CNPJ, Data, VrCotacao, VrTotalCarteira, VrPatrimonioLiquido,
         VrCaptacaoDia, VrResgateDia, NroCotistas, Atualizacoes, DataAtualizacao)
        VALUES
        (@CotacaoCVMID, @CNPJ, @Data, @VrCotacao, @VrTotalCarteira, @VrPatrimonioLiquido, 
         @VrCaptacaoDia, @VrResgateDia, @NroCotistas, 0, GETDATE());
    END
    ELSE
    BEGIN

		SELECT @CotacaoAlterada = CotacaoCVMID
		FROM CotacaoCVM
		WHERE CNPJ = @CNPJ 
		  AND Data = @Data
		  AND VrCotacao = @VrCotacao
		  AND VrTotalCarteira = @VrTotalCarteira
		  AND VrPatrimonioLiquido = @VrPatrimonioLiquido
		  AND VrCaptacaoDia = @VrCaptacaoDia
		  AND VrResgateDia = @VrResgateDia 
		  AND NroCotistas = @NroCotistas;

		IF (@CotacaoAlterada IS NULL)
		BEGIN

			UPDATE CotacaoCVM 
			SET VrCotacao = @VrCotacao, 
                VrTotalCarteira = @VrTotalCarteira, 
                VrPatrimonioLiquido = @VrPatrimonioLiquido,
                VrCaptacaoDia = @VrCaptacaoDia, 
                VrResgateDia = @VrResgateDia, 
                NroCotistas = @NroCotistas,
                Atualizacoes = Atualizacoes + 1,
				DataAtualizacao = GETDATE()
            WHERE CotacaoCVMID = @CotacaoCVMID;

		END;

    END;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpLimparTicker]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpLimparTicker]

AS

BEGIN

    DECLARE @Hoje DATE = getdate();

    DELETE FROM TickerHitBTC 
    WHERE HitTimeStamp_UTC < DATEADD(d, -1, @Hoje) 
    AND   CONVERT(varchar(11), HitTimeStamp_UTC, 20)+'00:00:00' != CONVERT(varchar(20), HitTimeStamp_UTC, 20);

END;
GO
/****** Object:  StoredProcedure [dbo].[stpListarMovimentosFundo]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/**************************************************************************
 Lista os movimentos de compra e venda de cotas de fundos de investimentos
 Elcio Reis - 11/08/2019
 Exemplo de utilização:
 EXEC stpListarMovimentosFundo 1034;
 **************************************************************************/

CREATE PROCEDURE [dbo].[stpListarMovimentosFundo] (@InvestimentoID INT)
AS
BEGIN

    DECLARE @ProcedureName VARCHAR(255);
    SELECT @ProcedureName = OBJECT_NAME(@@PROCID);

    IF NOT EXISTS(SELECT Invt.InvestimentoID
                  FROM Investimento Invt
                       JOIN TipoInvestimento Tipo ON Tipo.TipoInvestimentoID = Invt.TipoInvestimentoID
                  WHERE Invt.InvestimentoID = @InvestimentoID
                  AND   Tipo.Fundo = 1)
    BEGIN
        RAISERROR(15600, -1, -1, @ProcedureName);  
    END;

    -- MovO - Movimento de origem
    -- MovD - Movimento de destino
    -- Base - Pesquisa dos movimentos envolvidos na origem e no destino

    WITH MovO AS (SELECT MCta.MovimentoContaID
                  FROM MovimentoConta MCta
                       JOIN MovimentoInvestimento MInv ON MInv.MovimentoContaID = MCta.MovimentoContaID
                  WHERE MInv.InvestimentoID = @InvestimentoID),
         MovD AS (SELECT MCta.MovimentoContaID
                  FROM MovimentoConta MCta
                  WHERE MCta.DoMovimentoContaID IN (SELECT MovimentoContaID FROM MovO)),
         Base AS (SELECT MCta.MovimentoContaID, Cnta.Apelido Conta, MCta.Data, Lcto.Apelido Lancamento, 
                         Trsa.Apelido Transacao, MCta.Descricao, Ctgr.Apelido Categoria,
                         MInv.QtCotas,
                         -- Os lançamentos são invertidos pois sempre são vistos a partir da conta de investimento,
                         -- ou seja, um lançamento de débito na conta de investimento significa um crédito no fundo.
                         MCta.Credito, MCta.Debito
                  FROM MovimentoConta MCta
                       JOIN Conta Cnta ON Cnta.ContaID = MCta.ContaID
                       JOIN Lancamento Lcto ON Lcto.LancamentoID = MCta.LancamentoID
                       JOIN Categoria Ctgr ON Ctgr.CategoriaID = MCta.CategoriaID
                  LEFT JOIN MovimentoInvestimento MInv ON MInv.MovimentoContaID = MCta.MovimentoContaID
                  LEFT JOIN Transacao Trsa ON Trsa.TransacaoID = MInv.TransacaoID
                  WHERE MCta.MovimentoContaID IN (SELECT MovimentoContaID FROM MovO
                                                  UNION 
                                                  SELECT MovimentoContaID FROM MovD))
    -- Inclui os detalhes (TipoLinha = 0)                                                   
    SELECT CAST(0 AS TINYINT) TipoLinha, Base.MovimentoContaID, 
           Base.Conta, Base.Data, Base.Lancamento, Base.Transacao, Base.Descricao, Base.Categoria,
           Base.QtCotas, 
           -- Cria uma coluna com o acumulado das cotas linha a linha
           SUM(Base.QtCotas) OVER (ORDER BY Base.Data, Base.MovimentoContaID) QtCotasAcumulado,
           Base.Debito, Base.Credito,
           -- Cria uma coluna com o acumulado do crédito menos o débito linha a linha
           SUM(COALESCE(Base.Credito, 0) - COALESCE(Base.Debito, 0)) OVER (ORDER BY Base.Data, Base.MovimentoContaID) TotalAplicacao
    FROM Base
    UNION
    -- Inclui o total (TipoLinha = 1)
    SELECT CAST(1 AS TINYINT) TipoLinha, NULL MovimentoContaID, 
           NULL Conta, NULL Data, NULL Lancamento, NULL Transacao, 'Total Efetuado' Descricao, NULL Categoria,
           SUM(Base.QtCotas) QtCotas,
           SUM(Base.QtCotas) QtCotasAcumulado,
           SUM(Base.Debito) Debito, SUM(Base.Credito) Credito, 
           SUM(COALESCE(Base.Credito, 0)) - SUM(COALESCE(Base.Debito, 0)) TotalAplicacao
    FROM Base
    UNION
    -- Inclui o valor ainda aplicado (TipoLinha = 2)
    SELECT CAST(2 AS TINYINT) TipoLinha, NULL MovimentoContaID,
           NULL Conta, NULL Data, NULL Lancamento, NULL Transacao, 'Valor na Aplicação' Descricao, NULL Categoria,
           SUM(Base.QtCotas) QtCotas,
           NULL QtCotasAcumulado,
           NULL Debito, NULL Credito,
           COALESCE(dbo.fncSaldoInvestimentoLiquido(@InvestimentoID, GETDATE(), 1), 0) TotalAplicacao
    FROM Base
    UNION
    -- Inclui o valor do lucro ou prejuízo (TipoLinha = 3)
    SELECT CAST(3 AS TINYINT) TipoLinha, NULL MovimentoContaID,
           NULL Conta, NULL Data, NULL Lancamento, NULL Transacao, 'Resultado' Descricao, NULL Categoria,
           NULL QtCotas,
           NULL QtCotasAcumulado,
           NULL Debito, NULL Credito,
           (SUM(COALESCE(Base.Credito, 0)) - SUM(COALESCE(Base.Debito, 0))) + COALESCE(dbo.fncSaldoInvestimentoLiquido(@InvestimentoID, GETDATE(), 1), 0)  TotalAplicacao
    FROM Base
    ORDER BY TipoLinha, Data, MovimentoContaID;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpManterCambio]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpManterCambio](
	@MovimentoContaID INT,
	@UsuarioID INT,
	@DataHora DATETIME,
	@CrdDeb VARCHAR(1),
    @Compra BIT,
	@ContaOrigemID INT,
	@ContaDestinoID INT,
    @ValorOrigem NUMERIC(22,10),
	@ValorDestino NUMERIC(22,10),
    @Taxa NUMERIC(22,10),
	@ContaTaxaID INT,
	@Cotacao NUMERIC(22,10),
	@Lancamento VARCHAR(40),
	@Descricao VARCHAR(100),
    @TradeHitBTC BIGINT = 0,
    @Conciliado CHAR(1) = ' '
)
AS
	DECLARE @LancamentoID INT;
	DECLARE @CategoriaOrigemID INT;	
    DECLARE @CategoriaDestinoID INT;
    DECLARE @CategoriaTaxaID INT = 150; -- Despesas bancárias: Taxa Cambial
	DECLARE @Credito NUMERIC(22,10);
	DECLARE @Debito NUMERIC(22,10);
	DECLARE @LancamentoTaxa VARCHAR(40) = 'Taxa de Câmbio';
BEGIN

    -- Verifica se o apelido do lançamento existe, se não existir cria.
	IF (EXISTS(SELECT * FROM Lancamento WHERE Apelido = @Lancamento))
	BEGIN
	    -- Existe, pega o ID do lançamento
		SELECT @LancamentoID = LancamentoID 
		FROM Lancamento
		WHERE Apelido = @Lancamento;
	END
	ELSE
	BEGIN
	    -- Não existe, inclui o lançamento
		INSERT INTO Lancamento
		(UsuarioID, Apelido, Descricao, Ativo, Sistema, Automatico)
		VALUES
		(@UsuarioID, @Lancamento, 'Incluído através da movimentação de câmbio', 1, 0, 1);
		-- Recupera o ID recem criado
		SET @LancamentoID = @@IDENTITY;

	END;

    -- Cruzado conta A para categoria B e conta B para categoria A
    -- As categorias utilizadas são as de transferência com o apelido da conta entre colchetes, '[Caixa]', por exemploe

	SELECT @CategoriaOrigemID = CategoriaID
	FROM Categoria
	WHERE ContaID = @ContaDestinoID;

    SELECT @CategoriaDestinoID = CategoriaID
    FROM Categoria
    WHERE ContaID = @ContaOrigemID;

	IF (@MovimentoContaID <= 0)
    BEGIN
		-- Se o MovimentoContaID é nulo representa uma inclusão de movimento

		IF (@CrdDeb = 'D')
		BEGIN
		    SET @Credito = NULL;
			SET @Debito = @ValorOrigem;
		END
		ELSE
		BEGIN
		    SET @Credito = @ValorOrigem;
			SET @Debito = NULL;
		END;

        --- Lança o movimento de origem		
        INSERT INTO MovimentoConta 
        (UsuarioID, ContaID, Data, Numero, LancamentoID, Descricao, CategoriaID, 
         GrupoCategoriaID, CrdDeb, Credito, Debito, Conciliacao, Sistema) 
        VALUES 
        (@UsuarioID, @ContaOrigemID, @DataHora, NULL, @LancamentoID, @Descricao, @CategoriaOrigemID,
         NULL, @CrdDeb, @Credito, @Debito, @Conciliado, 0);

		SET @MovimentoContaID = @@IDENTITY;

        IF (@TradeHitBTC > 0)
        BEGIN
            -- Vincula o Movimento de Conta ao Trade da HitBTC
            INSERT INTO MovimentoContaLigacao
            (MovimentoContaID, Passo, TradeHitBTCID)
            VALUES
            (@MovimentoContaID, 0, @TradeHitBTC);
        END
        ELSE
        BEGIN
            INSERT INTO MovimentoContaLigacao
            (MovimentoContaID, Passo, TradeHitBTCID)
            VALUES
            (@MovimentoContaID, 0, NULL);
        END;

		IF (@CrdDeb = 'D')
		BEGIN
		    SET @Credito = @ValorDestino;
			SET @Debito = NULL;
            SET @CrdDeb = 'C';

			-- Lança a cotação utilizada na tabela de cotações, amarrando a cotação ao movimento de conta
     		INSERT INTO CotacaoMoeda
            (Data, 
			 DeMoedaID, 
			 Cotacao, 
			 ParaMoedaID, 
			 Negociado, MovimentoContaID, ContaIDTaxa, AliquotaTaxa)
            VALUES
			(@DataHora,
             CASE 
                WHEN @Compra = 1 THEN (SELECT MoedaID FROM Conta WHERE ContaID = @ContaDestinoID)
                WHEN @Compra = 0 THEN (SELECT MoedaID FROM Conta WHERE ContaID = @ContaOrigemID)
             END,
			 @Cotacao,
			 CASE
                WHEN @Compra = 1 THEN (SELECT MoedaID FROM Conta WHERE ContaID = @ContaOrigemID)
                WHEN @Compra = 0 THEN (SELECT MoedaID FROM Conta WHERE ContaID = @ContaDestinoID)
             END,
			 1, @MovimentoContaID, @ContaTaxaID, (@Taxa * 100 / @ValorDestino));
		END
		ELSE
		BEGIN
		    SET @Credito = NULL;
			SET @Debito = @ValorDestino;
			SET @CrdDeb = 'D';
		END;

		-- Lança o movimento de destino
        INSERT INTO MovimentoConta 
        (UsuarioID, ContaID, Data, Numero, LancamentoID, Descricao, CategoriaID, 
         GrupoCategoriaID, CrdDeb, Credito, Debito, Conciliacao, Sistema, DoMovimentoContaID) 
        VALUES 
        (@UsuarioID, @ContaDestinoID, @DataHora, NULL, @LancamentoID, @Descricao, @CategoriaDestinoID,
         NULL, @CrdDeb, @Credito, @Debito, @Conciliado, 0, @MovimentoContaID);

        IF (@TradeHitBTC > 0)
        BEGIN
            -- Vincula o Movimento de Conta ao Trade da HitBTC
            INSERT INTO MovimentoContaLigacao
            (MovimentoContaID, Passo, TradeHitBTCID)
            VALUES
            (@@IDENTITY, 1, @TradeHitBTC);
        END
        ELSE
        BEGIN
            -- Vincula o Movimento de Conta ao Trade da HitBTC
            INSERT INTO MovimentoContaLigacao
            (MovimentoContaID, Passo, TradeHitBTCID)
            VALUES
            (@@IDENTITY, 1, NULL);
        END;

		-- Verifica se é necessário lançar a taxa
		IF (@Taxa > 0)
		BEGIN

			-- Verifica se o apelido do lançamento de taxa existe, se não existir cria.
			IF (EXISTS(SELECT * FROM Lancamento WHERE Apelido = @LancamentoTaxa))
			BEGIN
				-- Existe, pega o ID do lançamento
				SELECT @LancamentoID = LancamentoID 
				FROM Lancamento
				WHERE Apelido = @LancamentoTaxa;
			END
			ELSE
			BEGIN
				-- Não existe, inclui o lançamento
				INSERT INTO Lancamento
				(UsuarioID, Apelido, Descricao, Ativo, Sistema, Automatico)
				VALUES
				(@UsuarioID, @LancamentoTaxa, 'Incluído através da movimentação de câmbio', 1, 0, 1);
				-- Recupera o ID recem criado
				SET @LancamentoID = @@IDENTITY;
			END;

			-- Inclui o lançamento da taxa
			INSERT INTO MovimentoConta 
			(UsuarioID, ContaID, Data, Numero, LancamentoID, Descricao, CategoriaID, 
			 GrupoCategoriaID, CrdDeb, Credito, Debito, Conciliacao, Sistema, DoMovimentoContaID) 
			VALUES 
			(@UsuarioID, @ContaTaxaID, @DataHora, NULL, @LancamentoID, @Descricao, @CategoriaTaxaID,
			 NULL, 'D', NULL, @Taxa, @Conciliado, 0, @MovimentoContaID);

            IF (@TradeHitBTC > 0)
            BEGIN
                -- Vincula o Movimento de Conta ao Trade da HitBTC
                INSERT INTO MovimentoContaLigacao
                (MovimentoContaID, Passo, TradeHitBTCID)
                VALUES
                (@@IDENTITY, 2, @TradeHitBTC);
            END
            ELSE
            BEGIN
                INSERT INTO MovimentoContaLigacao
                (MovimentoContaID, Passo, TradeHitBTCID)
                VALUES
                (@@IDENTITY, 2, NULL);
            END;
            
		END;

	END;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpManterConciliacaoBancaria]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpManterConciliacaoBancaria]
    @Processo         INT,
    @MovimentoContaID INT,
    @Identificacao    VARCHAR(40),
    @Descricao        VARCHAR(100)
AS
BEGIN 

    DECLARE @Aux INT;

    IF (@Processo = 1) 
    BEGIN

        SELECT @Aux = COUNT(*)
        FROM MovimentoContaConciliacaoBancaria
        WHERE MovimentoContaID = @MovimentoContaID;

        IF (Coalesce(@Aux, 0) = 0) 
        BEGIN

            INSERT INTO MovimentoContaConciliacaoBancaria
            (MovimentoContaId, Identificacao, DataConciliacao)
            VALUES
            (@MovimentoContaID, @Identificacao, GETDATE());

        END
        ELSE
        BEGIN

            UPDATE MovimentoContaConciliacaoBancaria SET
            Identificacao = @Identificacao,
            DataConciliacao = GETDATE()
            WHERE MovimentoContaID = @MovimentoContaID;
        
        END;

        UPDATE MovimentoConta SET
        Descricao = Rtrim(LTrim(@Descricao))
        WHERE MovimentoContaID = @MovimentoContaID;

    END;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpManterConfiguracaoPrincipal]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[stpManterConfiguracaoPrincipal](
	@panelEsquerdoWidth INT = NULL,
    @Contas_ExibeAtivas BIT = NULL,
    @Planejamento_ExibeAtivas BIT = NULL
)
AS

BEGIN

	UPDATE ConfiguracaoPrincipal
	SET panelEsquerdoWidth = COALESCE(@panelEsquerdoWidth, panelEsquerdoWidth),
        Contas_ExibeAtivas = COALESCE(@Contas_ExibeAtivas, Contas_ExibeAtivas),
        Planejamento_ExibeAtivas = COALESCE(@Planejamento_ExibeAtivas, Planejamento_ExibeAtivas)
	WHERE ConfiguracaoID = 1;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpManterCotacaoMoeda]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[stpManterCotacaoMoeda](
	@Data DATETIME,
	@DeMoedaID INT,
	@Cotacao NUMERIC(22,10),
	@ParaMoedaID INT,
	@Negociado BIT,
	@Lowest NUMERIC(22,10), 
	@Volume NUMERIC(22,10), 
	@Amount NUMERIC(22,10), 
	@AvgPrice NUMERIC(22,10), 
	@Opening NUMERIC(22,10), 
	@Closing NUMERIC(22,10), 
	@Highest NUMERIC(22,10), 
	@Quantity NUMERIC(22,10),
	@MovimentoContaID INT = NULL,
	@ContaIDTaxa INT = NULL,
	@AliquotaTaxa NUMERIC(10,6) = NULL)   
AS
BEGIN

    SET NOCOUNT OFF;

	DECLARE @CotacaoMoedaID INT;

	IF (@Negociado = 0)
	BEGIN
	    -- Se não houve negociação então inclui a cotação baixada via internet para o último horário do dia,
		-- assim, quando houver valoração das contas, pegará a última cotação do dia e não uma intermediária.
	    SET @Data = CONVERT(DATETIME, CONVERT(CHAR(10), @Data, 103) + ' 23:59:59.997', 103);
	END;

	SELECT @CotacaoMoedaID = CotacaoMoedaID
	FROM CotacaoMoeda
	WHERE Data = @Data
	AND   DeMoedaID = @DeMoedaID
	AND   ParaMoedaID = @ParaMoedaID;

	IF (@CotacaoMoedaID IS NULL)
	BEGIN

		INSERT INTO CotacaoMoeda
        (Data, DeMoedaID, Cotacao, ParaMoedaID, Lowest, Volume, Amount, 
		 AvgPrice, Opening, Closing, Highest, Quantity, Negociado,
		 MovimentoContaID, ContaIDTaxa, AliquotaTaxa)
        VALUES
        (@Data, @DeMoedaID, @Cotacao, @ParaMoedaID, @Lowest, @Volume, @Amount, 
		 @AvgPrice, @Opening, @Closing, @Highest, @Quantity, @Negociado,
		 @MovimentoContaID, @ContaIDTaxa, @AliquotaTaxa);

	END
	ELSE
	BEGIN
		
		UPDATE CotacaoMoeda
		SET Cotacao = @Cotacao,
		    Lowest = @Lowest,
			Volume = @Volume,
			Amount = @Amount,
			AvgPrice = @AvgPrice,
			Opening = @Opening,
			Closing = @Closing,
			Highest = @Highest,
			Quantity = @Quantity,
			ContaIDTaxa = @ContaIDTaxa,
			AliquotaTaxa = @AliquotaTaxa
		WHERE CotacaoMoedaID = @CotacaoMoedaID;
	END;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpManterCotacaoMoedaBancoCentral]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpManterCotacaoMoedaBancoCentral](@MoedaDe INT, @MoedaPara INT, @Data DATETIME, @Cotacao DECIMAL(22,10))

AS

BEGIN

    -- Sempre acrecenta a hora à data para que a cotação oficial do Banco Central seja a 
    -- última do dia, para o caso de haver negociações com valores do dolar durante o dia.
    SET @Data = CONVERT(DATETIME, CONVERT(CHAR(10), @Data, 103) + ' 23:59:59.997', 103);

    -- Índice utilizado MoedaCotacao.IX_CotacaoMoeda_DeMoedaID_ParaMoedaID_Data (DeMoedaID, ParaMoedaID, Data).

    IF NOT EXISTS(SELECT CotacaoMoedaID FROM CotacaoMoeda WHERE DeMoedaID = @MoedaDe AND ParaMoedaID = @MoedaPara AND Data = @Data)
    BEGIN

        INSERT INTO CotacaoMoeda
        (DeMoedaID, ParaMoedaID, Data, Cotacao)
        VALUES
        (@MoedaDe, @MoedaPara, @Data, @Cotacao);

    END
    ELSE
    BEGIN

        UPDATE CotacaoMoeda
        SET Cotacao = @Cotacao
        WHERE DeMoedaID = @MoedaDe AND ParaMoedaID = @MoedaPara AND Data = @Data;

    END;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpManterTickerHitBTC]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****************************************************
 Procedure stpManterTickerHitBTC
 Elcio Reis - 01/10/2019

 Alteração em 03/11/2021 por Elcio Reis
 Passa a fazer merge para update/insert em TickerHitBTC

 Inclui as cotações provenientes do serviço Ticker
 do HitBTC na tablea TickerHitBTC
 ****************************************************/
CREATE PROCEDURE [dbo].[stpManterTickerHitBTC](
    @HitSymbol VARCHAR(20),
    @HitTimeStamp_Local DATETIME,
    @HitTimeStamp_UTC DATETIME,
    @HitAsk NUMERIC(20,10),
    @HitBid NUMERIC(20,10),
    @HitLast NUMERIC(20,10),
    @HitOpen NUMERIC(20,10),
    @HitLow NUMERIC(20,10),
    @HitHigh NUMERIC(20,10),
    @HitVolume NUMERIC(20,10),
    @HitVolumeQuote NUMERIC(20,10)
    )
AS
BEGIN

    DECLARE @TickerID INT;

    SELECT @TickerID = TickerID
    FROM TickerHitBTC
    WHERE HitSymbol = @HitSymbol
    AND   HitTimeStamp_UTC = @HitTimeStamp_UTC;

    IF (@TickerID IS NULL)
        INSERT INTO TickerHitBTC
        (TickerID, 
         HitSymbol, HitTimeStamp_Local, HitTimeStamp_UTC, HitAsk, HitBid, HitLast, HitOpen, HitLow, HitHigh, HitVolume, HitVolumeQuote)
        VALUES
        (NEXT VALUE FOR TickerHitBTC_TickerID,
         @HitSymbol, @HitTimeStamp_Local, @HitTimeStamp_UTC, @HitAsk, @HitBid, @HitLast, @HitOpen, @HitLow, @HitHigh, @HitVolume, @HitVolumeQuote);
    ELSE
        UPDATE TickerHitBTC
            SET HitAsk = @HitAsk, 
                HitBid = @HitBid, 
                HitLast = @HitLast, 
                HitOpen = @HitOpen, 
                HitLow = @HitLow, 
                HitHigh = @HitHigh, 
                HitVolume = @HitVolume, 
                HitVolumeQuote = @HitVolumeQuote
        WHERE TickerID = @TickerID;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpManterTradeHitBTC]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*******************************************************
 Procedure stpManterTradeHitBTC

 Elcio Reis - 24/09/2019

 Insere, caso não exista, a trade proveniente de
 arquivo texto do HitBTC (.csv) na tabela TradeHitBTC

 Após executar esta procedure, deve-se executar a
 procedure stpMovimentoContaFromTradeHitBTC para que 
 os movimentos de conta sejam lançados corretamente.
 Na stpMovimentoContaFromTradeHitBTC somente os 
 registros TradeHitBTC.Executado = 0 serão processados.
 *******************************************************/

CREATE PROCEDURE [dbo].[stpManterTradeHitBTC] (
    @TradeID bigint,
    @Date datetime,
    @Instrument varchar(20),
    @OrderID bigint,
    @Side varchar(10),
    @Quantity numeric(22,12),
    @Price numeric(22,12),
    @Volume numeric(22,12),
    @Fee numeric(22,12),
    @Rebate numeric(22,12),
    @Total numeric(22,12),
    @Principal varchar(10),
    @Secundaria varchar(10),
    @WebService bit = 0)
AS
BEGIN

    IF (NOT EXISTS(SELECT TradeID FROM TradeHitBTC WHERE TradeID = @TradeID))
    BEGIN
        -- Não encontrou o TradeID, nesse caso insere.
        INSERT INTO TradeHitBTC
        (TradeID, Date, Instrument, OrderID, Side, Quantity, Price, Volume, Fee, Rebate, Total, Principal, Secundaria, WebService)
        VALUES
        (@TradeID, @Date, @Instrument, @OrderID, @Side, @Quantity, @Price, @Volume, @Fee, @Rebate, @Total, @Principal, @Secundaria, @WebService);

    END;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpMoedaVirtualSaldoDiario]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
 Fornece o saldo ao final de cada dia do mês informado

 Exemplo execução:
 EXEC stpMoedaVirtualSaldoDiario 2, '16/02/2021', 2;
 
 */

CREATE PROCEDURE [dbo].[stpMoedaVirtualSaldoDiario] (@UsuarioID INT, @Dia DATETIME, @MoedaDestinoID INT)
AS
    DECLARE @Inicio DATETIME, @Fim DATETIME, @D DATETIME;
    DECLARE @Dias TABLE (Dia          DATETIME, 
                         ContaID      INT, 
                         Conta        VARCHAR(40),
                         DeMoedaID    INT, 
                         ParaMoedaID  INT,
                         Moeda        VARCHAR(25),
                         Simbolo      VARCHAR(10),
                         ValorMoeda   NUMERIC(23,10));
BEGIN

    -- Recebe o primeiro dia do mês escolhido
    SET @Inicio = DATEFROMPARTS(DATEPART(YEAR, @Dia), DATEPART(MONTH, @Dia), 1);
    -- Recebe o último dia do mês escolhido
    SET @Fim = EOMONTH(@Dia)

    PRINT @Inicio;
    PRINT @Fim;

    SET @D = @Inicio;

    WHILE @D <= @Fim
    BEGIN

        WITH Base AS (SELECT Cnta.ContaID, Cnta.Apelido Conta, Cnta.MoedaID DeMoedaID, COALESCE(Elet.ParaMoedaID, Cnta.MoedaID) ParaMoedaID, Moed.Apelido Moeda, Moed.Simbolo, Cnta.SaldoInicial
                      FROM TipoConta TpCt
                           JOIN Conta Cnta ON Cnta.TipoContaID = TpCt.TipoContaID
                                          AND Cnta.Ativo = 1
                                          AND Cnta.UsuarioID = 2
                           JOIN Moeda Moed ON Moed.MoedaID = Cnta.MoedaID                                      
                      LEFT JOIN MoedaEletronica Elet ON Elet.MoedaID = Moed.MoedaID
                                                    AND Elet.Padrao = 1
                      WHERE TpCt.Cambio = 1)

        INSERT INTO @Dias (Dia, ContaID, Conta, DeMoedaID, ParaMoedaID, Moeda, Simbolo, ValorMoeda)
        SELECT @D Dia,
               Base.ContaID, 
               Base.Conta, 
               Base.DeMoedaID, 
               Base.ParaMoedaID,
               Base.Moeda, 
               Base.Simbolo,
               SUM(Mvto.Valor) + Base.SaldoInicial ValorMoeda
        FROM Base
             JOIN MovimentoConta Mvto ON Mvto.ContaID = Base.ContaID
                                     AND CONVERT(DATE, Mvto.Data) <= @D
        GROUP BY Base.ContaID, Base.Conta, Base.DeMoedaID, Base.ParaMoedaID, Base.Moeda, Base.Simbolo, Base.SaldoInicial

        SET @D = @D + 1;

    END;


    SELECT Dias.Dia, Dias.ContaId, Dias.Conta, Dias.Moeda, Dias.Simbolo, Dias.DeMoedaID, Dias.ParaMoedaID, Dias.ValorMoeda
    FROM @Dias Dias        
    ---WHERE CONVERT(DATE, Dias.Dia) <= GETDATE()


    ORDER BY Dia, Conta;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpMovimentoContaFromTradeHitBTC]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/******************************************************
 Utiliza as movimentações provenientes do arquivo CSV
 previamente armazenadas em TradeHitBTC para fazer
 a movimentação de compra e venda de moedas eletrônicas
 do site da HitBTC.

 Somente processa a conta informada no parâmetro @ContaID
 Somente processa os registros com HitBTC.Executado = 0

 Elcio Reis - 24/09/2019

 Exemplo de uso:
 EXEC stpMovimentoContaFromTradeHitBTC 2, 33;
 ******************************************************/

CREATE PROCEDURE [dbo].[stpMovimentoContaFromTradeHitBTC] (@UsuarioID INT, @ContaID INT, @Testar BIT = 0)
AS
    -- Reter padrão e instituição
    DECLARE @MoedaPrincipalID INT;
    DECLARE @InstituicaoID INT;
    DECLARE @Instituicao VARCHAR(25);
    -- Padrão de decimais
    DECLARE @DecPrincipal TINYINT;
    DECLARE @DecSecundaria TINYINT;
    -- Contas
    DECLARE @ContaPrincipal INT;
    DECLARE @ContaSecundaria INT;
    DECLARE @ContaDe INT;
    DECLARE @ContaPara INT;
    DECLARE @Compra BIT;
    DECLARE @CrdDeb CHAR(1);

    DECLARE @Lancamento varchar(40);
    DECLARE @Descricao varchar(100);
    DECLARE @TabelaMensagens TABLE (ID INT IDENTITY, Descricao VARCHAR(MAX));
    -- Variáveis para o cursor cTrade
    DECLARE @TradeID bigint,
            @Date datetime,
            @Principal varchar(10),
            @Secundaria varchar(10),
            @Side varchar(10),
            @Quantity numeric(22,10),
            @Price numeric(22,10),
            @Volume numeric(22,10),
            @TotalFee numeric(22,10),
            @Total numeric(22,10);
BEGIN

    SET NOCOUNT ON;

    -- Recupera os padrões
    SELECT @MoedaPrincipalID = Cta.MoedaID, 
           @InstituicaoID = Cta.InstituicaoID, 
           @Instituicao = Itt.Apelido
    FROM Conta Cta
    JOIN Instituicao Itt ON Itt.InstituicaoID = Cta.InstituicaoID
    WHERE Cta.ContaID = @ContaID;

    DECLARE cTrade CURSOR 
    FOR SELECT Hit.TradeID, Hit.Date, Hit.Principal, Hit.Secundaria, lower(Hit.Side) Side, 
               Hit.Quantity, Hit.Price, Hit.Volume,
               CASE WHEN Hit.Rebate <> 0 THEN Hit.Rebate ELSE Hit.Fee END TotalFee, 
               Hit.Total,
               CPr.ContaID ContaPrincipal, CPr.Decimais DecPrincipal, 
               CSc.ContaID ContaSecuntaria, CSc.Decimais DecSecundaria
        FROM TradeHitBTC Hit
        LEFT JOIN Moeda MPr ON MPr.Eletronica = Hit.Principal
        LEFT JOIN Conta CPr ON CPr.InstituicaoID = @InstituicaoID AND CPr.MoedaID = MPr.MoedaID
        LEFT JOIN Moeda MSc ON MSc.Eletronica = Hit.Secundaria
        LEFT JOIN Conta CSc ON CSc.InstituicaoID = @InstituicaoID AND CSc.MoedaID = MSc.MoedaID
        WHERE CPr.ContaID = @ContaID
        AND   Hit.Executado = 0
        ORDER BY Hit.Date ASC, Hit.TradeID ASC;

    OPEN cTrade;
    FETCH NEXT FROM cTrade
    INTO @TradeID, @Date, @Principal, @Secundaria, @Side, @Quantity, @Price, @Volume, @TotalFee, @Total,
         @ContaPrincipal, @DecPrincipal, @ContaSecundaria, @DecSecundaria;

    WHILE (@@FETCH_STATUS = 0) 
    BEGIN

        IF (EXISTS(SELECT MoedaID FROM Moeda WHERE Eletronica = @Secundaria))
        BEGIN

            IF (EXISTS(SELECT Cta.ContaID
                       FROM Conta Cta
                       JOIN Moeda Mda ON Mda.MoedaID = Cta.MoedaID
                       WHERE Cta.InstituicaoID = @InstituicaoID
                       AND   Mda.Eletronica = @Secundaria))
            BEGIN

                IF (@Testar = 0)
                BEGIN
                    -- Se não é apenas teste

                    IF (@Side = 'buy')
                    BEGIN
                        
                        SET @Compra = 1;
                        SELECT @Lancamento = 'Compra de ' + Apelido + ' (' + Simbolo + ')' FROM Moeda WHERE Eletronica = @Principal;           

                    END
                    ELSE
                    BEGIN

                        SET @Compra = 0;
                        SELECT @Lancamento = 'Venda de ' + Apelido + ' (' + Simbolo + ')' FROM Moeda WHERE Eletronica = @Principal;           

                    END;
                    
                    --SET @Descricao = 
                    --    CASE @Compra WHEN 1 THEN 'Compra de ' ELSE 'Venda de ' END +
                    --    @Principal + ' ' +
                    --    FORMAT(@Quantity, '#,##0.00' + REPLICATE('#', @DecPrincipal-2)) +  ' @ ' +
                    --    @Secundaria + ' ' + 
                    --    FORMAT(@Volume, '#,##0.00' + REPLICATE('#', @DecSecundaria-2)) + 
                    --    ' (' + @Secundaria + ' '+
                    --    FORMAT(@Price, '#,##0.00' + REPLICATE('#', @DecSecundaria-2)) + ')';
                    
                    SET @Descricao = 
                        CASE @Compra WHEN 1 THEN 'Compra de ' ELSE 'Venda de ' END +
                        @Principal + ' ' +
                        FORMAT(@Quantity, '#,##0.00' + REPLICATE('#', 12)) +  ' @ ' +
                        @Secundaria + ' ' + 
                        FORMAT(@Volume, '#,##0.00' + REPLICATE('#', 12)) + 
                        ' (' + @Secundaria + ' '+
                        FORMAT(@Price, '#,##0.00' + REPLICATE('#', 12)) + ')';


                    INSERT INTO @TabelaMensagens
                    (Descricao)
                    SELECT 'Em ' + FORMAT(@Date, 'dd/MM/yyyy HH:mm:ss') + ' ' + @Descricao; 

                    SET @CrdDeb = CASE WHEN @Compra = 1 THEN 'C' ELSE 'D' END;

                    EXEC stpManterCambio 
                         -1,                    -- MovimentoContaID 
                         @UsuarioID,            -- Usuário
                         @Date,                 -- Data
                         @CrdDeb,               -- Débido/Crédito     
                         @Compra,               -- Compra/Venda
                         @ContaPrincipal,       -- ContaOrigemID
                         @ContaSecundaria,      -- ContaDestinoID
                         @Quantity,             -- ValorOrigem
                         @Volume,               -- ValorDestino
                         @TotalFee,             -- Taxa
                         @ContaSecundaria,      -- ContaTaxaID
                         @Price,                -- Cotacao
                         @Lancamento,           -- Lancamento
                         @Descricao,            -- Descricao
                         @TradeID,              -- TradeHitBTC
                         'C';                   -- Movimentos proveniente de troca de arquivo já entra na movimentação de conta como conciliado

                    UPDATE TradeHitBTC
                    SET Executado = 1
                    WHERE TradeID = @TradeID;
             
                END;

            END
            ELSE
            BEGIN

                INSERT INTO @TabelaMensagens
                (Descricao)
                VALUES
                ('Não existe conta na moeda ' + @Secundaria + ' na instituição ' + @Instituicao + '.');

            END;
        END
        ELSE
        BEGIN

            INSERT INTO @TabelaMensagens
            (Descricao)
            VALUES
            ('A moeda ' + @Secundaria + ' e uma conta nessa moeda precisam ser criadas na instituição ' + @Instituicao + '.');

        END;

        FETCH NEXT FROM cTrade
        INTO @TradeID, @Date, @Principal, @Secundaria, @Side, @Quantity, @Price, @Volume, @TotalFee, @Total,
             @ContaPrincipal, @DecPrincipal, @ContaSecundaria, @DecSecundaria;
    END;

    CLOSE cTrade;
    DEALLOCATE cTrade;
 
    SELECT ID, Descricao FROM @TabelaMensagens ORDER BY ID;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpOrcamentoDiario]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/******************************************************
 Procedure stpOrcamentoDiario
 Elcio Reis - 16/08/2019
 Cria uma "planilha" com as entradas e saídas do mês
 Exemplo de execução

 Elcio Reis - 19/09/2019
 Inclusão de contas de câmbio

 EXEC stpOrcamentoDiario 2, '2019-09-18', 0;
 ******************************************************/

CREATE PROCEDURE [dbo].[stpOrcamentoDiario] (@UsuarioID INT, @DataReferencia DATE, @Comparar BIT = 0)
AS
    -- Calcula o primeiro dia do mês
    DECLARE @PrimeiroDia DATE = DATEADD(DAY, 1, EOMONTH(@DataReferencia, -1));
    -- Calcula o último dia do mês
    DECLARE @UltimoDia DATE = EOMONTH(@DataReferencia);
BEGIN

    DECLARE @MoedaPadraoID INT;
    DECLARE @Simbolo VARCHAR(10);

    SELECT @MoedaPadraoID = MoedaID,
           @Simbolo = TRIM(Simbolo)
    FROM Moeda 
    WHERE Padrao = 1;
   
    -- Cria uma tabela com todos os dias do mês em referência
    DECLARE @Dias TABLE (Dia DATE, DiaSeguinte DATE);

    -- Acrescenta todos os dias do mês na tabela @Dias
    DECLARE @Dia DATE = @PrimeiroDia;

    WHILE (@Dia <= @UltimoDia)
    BEGIN
        INSERT INTO @Dias
        (Dia, DiaSeguinte)
        VALUES
        (@Dia, DATEADD(DAY, 1, @Dia));

        SET @Dia = DATEADD(DAY, 1, @Dia);
    END; -- WHILE

    -- Cria tabela virtual para receber o conteúdo do select principal
    DECLARE @Tempor TABLE (
        Ordem            CHAR(1),
        TipoLinha        SMALLINT,
        CategoriaID      INT,
        Categoria        VARCHAR(50),
        Dia01            DECIMAL(22,10),
        Dia02            DECIMAL(22,10),
        Dia03            DECIMAL(22,10),
        Dia04            DECIMAL(22,10),
        Dia05            DECIMAL(22,10),
        Dia06            DECIMAL(22,10),
        Dia07            DECIMAL(22,10),
        Dia08            DECIMAL(22,10),
        Dia09            DECIMAL(22,10),
        Dia10            DECIMAL(22,10),
        Dia11            DECIMAL(22,10),
        Dia12            DECIMAL(22,10),
        Dia13            DECIMAL(22,10),
        Dia14            DECIMAL(22,10),
        Dia15            DECIMAL(22,10),
        Dia16            DECIMAL(22,10),
        Dia17            DECIMAL(22,10),
        Dia18            DECIMAL(22,10),
        Dia19            DECIMAL(22,10),
        Dia20            DECIMAL(22,10),
        Dia21            DECIMAL(22,10),
        Dia22            DECIMAL(22,10),
        Dia23            DECIMAL(22,10),
        Dia24            DECIMAL(22,10),
        Dia25            DECIMAL(22,10),
        Dia26            DECIMAL(22,10),
        Dia27            DECIMAL(22,10),
        Dia28            DECIMAL(22,10),
        Dia29            DECIMAL(22,10),
        Dia30            DECIMAL(22,10),
        Dia31            DECIMAL(22,10),
        TotalCategoria   DECIMAL(22,10),
        DataReferencia   DATE,
        Outros           SMALLINT
    );

    -- O campo TipoLinha recebe o seguinte conteúdo:
    -- 0 - Linha com o saldo do dia anterior
    -- 1 - Total dos grupos entrada e saída
    -- 2 - Detalhes dos grupos entrada e saída
    -- 3 - Saldo final do dia

    DECLARE @EspacoSimpl VARCHAR(10) = '      ';
    DECLARE @EspacoDuplo VARCHAR(20) = @EspacoSimpl + @EspacoSimpl;

    --
    -- Se a comparação estiver ligada, fornece uma linha com o saldo inicial de cada dia
    --

    IF (@Comparar = 1)
    BEGIN

        WITH Fase01 AS (SELECT 'A' Ordem, -1 TipoLinha, DATEPART(DAY, Dias.Dia) Dia, 
                               GpCt.Apelido Grupo, Cnta.Apelido,
                               SUM(COALESCE(MvCt.Credito, 0) - COALESCE(MvCt.Debito, 0)) Valor,
                               0 CategoriaID, 'Comparativo Inicial' Categoria,  0 Outros
                        FROM MovimentoConta MvCt
                             JOIN @Dias Dias ON CAST(MvCt.Data AS DATE) < Dias.Dia
                             JOIN Conta Cnta ON Cnta.ContaID = MvCt.ContaID
                             JOIN TipoConta TpCt ON TpCt.TipoContaID = Cnta.TipoContaID
                             JOIN GrupoConta GpCt ON GpCt.GrupoContaID = TpCt.GrupoContaID
                        WHERE MvCt.UsuarioID = @UsuarioID
                        AND   Cnta.MoedaID = @MoedaPadraoID
                        GROUP BY DATEPART(DAY, Dias.Dia), GpCt.Ordem, GpCt.Apelido, Cnta.Apelido)
        INSERT INTO @Tempor
        SELECT Ordem, TipoLinha, CategoriaID, Categoria,
                [1] 'DIA01',  [2] 'DIA02',  [3] 'DIA03',  [4] 'DIA04',  [5] 'DIA05',  [6] 'DIA06',  [7] 'DIA07',  [8] 'DIA08',  [9] 'DIA09', [10] 'DIA10',
               [11] 'DIA11', [12] 'DIA12', [13] 'DIA13', [14] 'DIA14', [15] 'DIA15', [16] 'DIA16', [17] 'DIA17', [18] 'DIA18', [19] 'DIA19', [20] 'DIA20',
               [21] 'DIA21', [22] 'DIA22', [23] 'DIA23', [24] 'DIA24', [25] 'DIA25', [26] 'DIA26', [27] 'DIA27', [28] 'DIA28', [29] 'DIA29', [30] 'DIA30',
               [31] 'DIA31',
               NULL TotalCategoria, DataReferencia, Outros
        FROM (SELECT Dia, Ordem, TipoLinha, CategoriaID, Categoria, Outros, @PrimeiroDia DataReferencia, Valor FROM Fase01 WHERE CategoriaID IS NOT NULL AND Ordem IS NOT NULL) Origem
        PIVOT (SUM(Valor) FOR Dia IN ( [1], [2], [3], [4], [5], [6], [7], [8], [9],[10],
                                      [11],[12],[13],[14],[15],[16],[17],[18],[19],[20],
                                      [21],[22],[23],[24],[25],[26],[27],[28],[29],[30],
                                      [31])) Final;

        WITH Fase01 AS (SELECT 'L' Ordem, -1 TipoLinha, DATEPART(DAY, Dias.Dia) Dia, 
                               GpCt.Apelido Grupo, Cnta.Apelido,
                               SUM(COALESCE(MvCt.Credito, 0) - COALESCE(MvCt.Debito, 0)) Valor,
                               1 CategoriaID, 'Comparativo Final' Categoria,  0 Outros
                        FROM MovimentoConta MvCt
                             JOIN @Dias Dias ON CAST(MvCt.Data AS DATE) < Dias.DiaSeguinte
                             JOIN Conta Cnta ON Cnta.ContaID = MvCt.ContaID
                             JOIN TipoConta TpCt ON TpCt.TipoContaID = Cnta.TipoContaID
                             JOIN GrupoConta GpCt ON GpCt.GrupoContaID = TpCt.GrupoContaID
                        WHERE MvCt.UsuarioID = @UsuarioID
                        AND   Cnta.MoedaID = @MoedaPadraoID
                        GROUP BY DATEPART(DAY, Dias.Dia), GpCt.Ordem, GpCt.Apelido, Cnta.Apelido)
        INSERT INTO @Tempor
        SELECT Ordem, TipoLinha, CategoriaID, Categoria,
                [1] 'DIA01',  [2] 'DIA02',  [3] 'DIA03',  [4] 'DIA04',  [5] 'DIA05',  [6] 'DIA06',  [7] 'DIA07',  [8] 'DIA08',  [9] 'DIA09', [10] 'DIA10',
               [11] 'DIA11', [12] 'DIA12', [13] 'DIA13', [14] 'DIA14', [15] 'DIA15', [16] 'DIA16', [17] 'DIA17', [18] 'DIA18', [19] 'DIA19', [20] 'DIA20',
               [21] 'DIA21', [22] 'DIA22', [23] 'DIA23', [24] 'DIA24', [25] 'DIA25', [26] 'DIA26', [27] 'DIA27', [28] 'DIA28', [29] 'DIA29', [30] 'DIA30',
               [31] 'DIA31',
               NULL TotalCategoria, DataReferencia, Outros
        FROM (SELECT Dia, Ordem, TipoLinha, CategoriaID, Categoria, Outros, @PrimeiroDia DataReferencia, Valor FROM Fase01 WHERE CategoriaID IS NOT NULL AND Ordem IS NOT NULL) Origem
        PIVOT (SUM(Valor) FOR Dia IN ( [1], [2], [3], [4], [5], [6], [7], [8], [9],[10],
                                      [11],[12],[13],[14],[15],[16],[17],[18],[19],[20],
                                      [21],[22],[23],[24],[25],[26],[27],[28],[29],[30],
                                      [31])) Final;

    END;


    WITH Fase01 AS (SELECT DATEPART(DAY, MCta.Data) Dia, MCta.Valor, Pais.CategoriaID, 
                           @EspacoDuplo + CASE WHEN COALESCE(Avos.CrdDeb, Pais.CrdDeb) = 'I' AND Ctgr.CrdDeb = 'C' THEN 'Resgate'
                                               WHEN COALESCE(Avos.CrdDeb, Pais.CrdDeb) = 'I' AND Ctgr.CrdDeb = 'D' THEN 'Aplicação'
                                               ELSE Pais.Apelido 
                                          END Categoria, 
                           COALESCE(CASE WHEN TRIM(Avos.CrdDeb) <> '' THEN Avos.CrdDeb ELSE NULL END, 
                                    CASE WHEN TRIM(Pais.CrdDeb) <> '' THEN Pais.CrdDeb ELSE NULL END, 
                                    CASE WHEN TRIM(Ctgr.CrdDeb) <> '' THEN Ctgr.CrdDeb ELSE NULL END) Ordem,
                           @UltimoDia DataReferencia, 
                           CASE WHEN Ctgr.Outros = 1 THEN 1
                                WHEN Pais.Outros = 1 THEN 1
                                WHEN Avos.Outros = 1 THEN 1
                                ELSE 0
                           END Outros
                    FROM @Dias Dias
                         JOIN MovimentoConta MCta ON CAST(MCta.Data AS DATE) = Dias.Dia
                         JOIN Conta Cnta ON Cnta.ContaID = MCta.ContaID
                         JOIN TipoConta TpCt ON TpCt.TipoContaID = Cnta.TipoContaID
                         JOIN Categoria Ctgr ON Ctgr.CategoriaID = MCta.CategoriaID
                         JOIN Categoria Pais ON Pais.CategoriaID = Ctgr.CategoriaPaiID
                         JOIN Categoria Avos ON Avos.CategoriaID = Pais.CategoriaPaiID
                    WHERE MCta.UsuarioID = @UsuarioID
                    AND   Cnta.MoedaID = @MoedaPadraoID),
         Fase02 AS (-- Detalhes
                    SELECT Ordem, 2 TipoLinha, Dia, Valor, CategoriaID, Categoria, DataReferencia, Outros  
                    FROM Fase01
                    WHERE Ordem IN ('C', 'D', 'I')

                    UNION ALL

                    -- Total por categoria
                    SELECT Ordem, 1 TipoLinha, Dia, SUM(Valor) Valor, 0 CategoriaID, 
                           CASE Ordem
                                WHEN 'C' THEN @EspacoSimpl + 'Total Entradas'
                                WHEN 'D' THEN @EspacoSimpl + 'Total Saídas'
                                WHEN 'I' THEN @EspacoSimpl + 'Total Investimentos'
                                ELSE NULL
                            END Categoria, DataReferencia, 0 Outros
                    FROM Fase01
                    WHERE Ordem IN ('C', 'D', 'I')
                    GROUP BY Ordem, Dia, DataReferencia

                    UNION ALL
                    
                    SELECT 'A' Ordem, 0 TipoLinha, 1 Dia, 
                           SUM(COALESCE(MvCt.Credito, 0) - COALESCE(MvCt.Debito, 0)) Valor,
                           0 CategoriaID, 'Saldo Inicial' Categoria, @UltimoDia DataReferencia, 0 Outros
                    FROM MovimentoConta MvCt
                         JOIN Conta Cnta ON Cnta.ContaID = MvCt.ContaID
                         JOIN TipoConta TpCt ON TpCt.TipoContaID = Cnta.TipoContaID
                    WHERE MvCt.UsuarioID = @UsuarioID
                    AND   Cnta.MoedaID = @MoedaPadraoID
                    AND   MvCt.Data < @PrimeiroDia

                    UNION ALL

                    -- Saldo Final
                    SELECT 'M' Ordem, 3 TipoLinha, Dia, 0 Valor, 0 CategoriaID, 
                           'Saldo Final a Transportar' Categoria, DataReferencia, 0 Outros
                    FROM Fase01
                    WHERE Ordem IN ('C', 'D', 'I')
                    GROUP BY Dia, DataReferencia
                    )
    INSERT INTO @Tempor
    SELECT Ordem, TipoLinha, CategoriaID, Categoria,
            [1] 'DIA01',  [2] 'DIA02',  [3] 'DIA03',  [4] 'DIA04',  [5] 'DIA05',  [6] 'DIA06',  [7] 'DIA07',  [8] 'DIA08',  [9] 'DIA09', [10] 'DIA10',
           [11] 'DIA11', [12] 'DIA12', [13] 'DIA13', [14] 'DIA14', [15] 'DIA15', [16] 'DIA16', [17] 'DIA17', [18] 'DIA18', [19] 'DIA19', [20] 'DIA20',
           [21] 'DIA21', [22] 'DIA22', [23] 'DIA23', [24] 'DIA24', [25] 'DIA25', [26] 'DIA26', [27] 'DIA27', [28] 'DIA28', [29] 'DIA29', [30] 'DIA30',
           [31] 'DIA31',
           NULL TotalCategoria, DataReferencia, Outros
    FROM (SELECT Dia, Ordem, TipoLinha, CategoriaID, Categoria, Outros, DataReferencia, Valor FROM Fase02 WHERE CategoriaID IS NOT NULL AND Ordem IS NOT NULL) Origem
    PIVOT (SUM(Valor) FOR Dia IN ( [1], [2], [3], [4], [5], [6], [7], [8], [9],[10],
                                  [11],[12],[13],[14],[15],[16],[17],[18],[19],[20],
                                  [21],[22],[23],[24],[25],[26],[27],[28],[29],[30],
                                  [31])) Final;

    --
    -- Insere movimentos de investimentos
    --

    WITH Fase01 AS (SELECT DATEPART(DAY, MCta.Data) Dia, MCta.Valor, 0 CategoriaID, 
                           @EspacoDuplo + Invt.Apelido Categoria,
                          'I' Ordem, 0 Outros -- , MCta.MovimentoContaID, Invt.Apelido
                    FROM @Dias Dias
                         JOIN MovimentoConta MCta ON CAST(MCta.Data AS DATE) = Dias.Dia
                         JOIN MovimentoInvestimento MInv ON MInv.MovimentoContaID = MCta.MovimentoContaID
                         JOIN Investimento Invt ON Invt.InvestimentoID = MInv.InvestimentoID
                    WHERE MCta.UsuarioID = @UsuarioID),
         Fase02 AS (SELECT Dia, 2 TipoLinha,  Valor, CategoriaID, Categoria, Ordem
                    FROM Fase01

                    UNION ALL

                    SELECT Dia, 1 TipoLinha,  SUM(Valor) Valor, 0 CategoriaID, @EspacoSimpl + 'Investimentos' Categoria, Ordem
                    FROM Fase01
                    GROUP BY Dia, Ordem)
        INSERT INTO @Tempor
        SELECT Ordem, TipoLinha, CategoriaID, Categoria,
                [1] 'DIA01',  [2] 'DIA02',  [3] 'DIA03',  [4] 'DIA04',  [5] 'DIA05',  [6] 'DIA06',  [7] 'DIA07',  [8] 'DIA08',  [9] 'DIA09', [10] 'DIA10',
               [11] 'DIA11', [12] 'DIA12', [13] 'DIA13', [14] 'DIA14', [15] 'DIA15', [16] 'DIA16', [17] 'DIA17', [18] 'DIA18', [19] 'DIA19', [20] 'DIA20',
               [21] 'DIA21', [22] 'DIA22', [23] 'DIA23', [24] 'DIA24', [25] 'DIA25', [26] 'DIA26', [27] 'DIA27', [28] 'DIA28', [29] 'DIA29', [30] 'DIA30',
               [31] 'DIA31',
               NULL TotalCategoria, DataReferencia, 0 Outros
        FROM (SELECT Dia, Ordem, TipoLinha, CategoriaID, Categoria, @PrimeiroDia DataReferencia, Valor FROM Fase02 WHERE CategoriaID IS NOT NULL AND Ordem IS NOT NULL) Origem
        PIVOT (SUM(Valor) FOR Dia IN ( [1], [2], [3], [4], [5], [6], [7], [8], [9],[10],
                                      [11],[12],[13],[14],[15],[16],[17],[18],[19],[20],
                                      [21],[22],[23],[24],[25],[26],[27],[28],[29],[30],
                                      [31])) Final;

    -------------------------------------

    UPDATE @Tempor
    SET Dia01 = COALESCE(Dia01, 0),
        Dia02 = COALESCE(Dia02, 0),
        Dia03 = COALESCE(Dia03, 0),
        Dia04 = COALESCE(Dia04, 0),
        Dia05 = COALESCE(Dia05, 0),
        Dia06 = COALESCE(Dia06, 0),
        Dia07 = COALESCE(Dia07, 0),
        Dia08 = COALESCE(Dia08, 0),
        Dia09 = COALESCE(Dia09, 0),
        Dia10 = COALESCE(Dia10, 0),
        Dia11 = COALESCE(Dia11, 0),
        Dia12 = COALESCE(Dia12, 0),
        Dia13 = COALESCE(Dia13, 0),
        Dia14 = COALESCE(Dia14, 0),
        Dia15 = COALESCE(Dia15, 0),
        Dia16 = COALESCE(Dia16, 0),
        Dia17 = COALESCE(Dia17, 0),
        Dia18 = COALESCE(Dia18, 0),
        Dia19 = COALESCE(Dia19, 0),
        Dia20 = COALESCE(Dia20, 0),
        Dia21 = COALESCE(Dia21, 0),
        Dia22 = COALESCE(Dia22, 0),
        Dia23 = COALESCE(Dia23, 0),
        Dia24 = COALESCE(Dia24, 0),
        Dia25 = COALESCE(Dia25, 0),
        Dia26 = COALESCE(Dia26, 0),
        Dia27 = COALESCE(Dia27, 0),
        Dia28 = COALESCE(Dia28, 0),
        Dia29 = CASE WHEN DATEADD(DAY, 29 - 1, @PrimeiroDia) <= @UltimoDia THEN COALESCE(Dia29, 0) ELSE NULL END,
        Dia30 = CASE WHEN DATEADD(DAY, 30 - 1, @PrimeiroDia) <= @UltimoDia THEN COALESCE(Dia30, 0) ELSE NULL END,
        Dia31 = CASE WHEN DATEADD(DAY, 31 - 1, @PrimeiroDia) <= @UltimoDia THEN COALESCE(Dia31, 0) ELSE NULL END
    WHERE TipoLinha = 1;

    DECLARE @Anterior DECIMAL(22, 10), @Total DECIMAL(22,10), @Movimento DECIMAL(22,10); -- , @Final DECIMAL(22,10);

    SELECT @Anterior = Dia01 FROM @Tempor WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia01) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Anterior + @Movimento;
    UPDATE @Tempor SET Dia01 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia02 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia02) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia02 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia03 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia03) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia03 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia04 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia04) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia04 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia05 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia05) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia05 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia06 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia06) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia06 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia07 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia07) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia07 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia08 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Dia08) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia08 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia09 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia09) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia09 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia10 = @Total WHERE TipoLinha = 0;
        
    SELECT @Movimento = SUM(Dia10) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia10 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia11 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia11) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia11 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia12 = @Total WHERE TipoLinha = 0;
        
    SELECT @Movimento = SUM(Dia12) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia12 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia13 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia13) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia13 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia14 = @Total WHERE TipoLinha = 0;
            
    SELECT @Movimento = SUM(Dia14) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia14 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia15 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia15) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia15 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia16 = @Total WHERE TipoLinha = 0;
                
    SELECT @Movimento = SUM(Dia16) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia16 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia17 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia17) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia17 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia18 = @Total WHERE TipoLinha = 0;
            
    SELECT @Movimento = SUM(Dia18) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia18 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia19 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia19) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia19 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia20 = @Total WHERE TipoLinha = 0;
                
    SELECT @Movimento = SUM(Dia20) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia20 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia21 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia21) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia21 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia22 = @Total WHERE TipoLinha = 0;
                    
    SELECT @Movimento = SUM(Dia22) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia22 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia23 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia23) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia23 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia24 = @Total WHERE TipoLinha = 0;
                        
    SELECT @Movimento = SUM(Dia24) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia24 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia25 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia25) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia25 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia26 = @Total WHERE TipoLinha = 0;
                            
    SELECT @Movimento = SUM(Dia26) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia26 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia27 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Dia27) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia27 = @Total WHERE TipoLinha = 3;
    UPDATE @Tempor SET Dia28 = @Total WHERE TipoLinha = 0;
                                
    SELECT @Movimento = SUM(Dia28) FROM @Tempor WHERE TipoLinha = 1;
    SET    @Total = @Total + @Movimento;
    UPDATE @Tempor SET Dia28 = @Total WHERE TipoLinha = 3;
    
    IF (DATEADD(DAY, 29 - 1, @PrimeiroDia) <= @UltimoDia)
    BEGIN
        UPDATE @Tempor SET Dia29 = @Total WHERE TipoLinha = 0;

        SELECT @Movimento = SUM(Dia29) FROM @Tempor WHERE TipoLinha = 1;
        SET    @Total = @Total + @Movimento;
        UPDATE @Tempor SET Dia29 = @Total WHERE TipoLinha = 3;
        UPDATE @Tempor SET Dia30 = @Total WHERE TipoLinha = 0;
    END;
                                    
    IF (DATEADD(DAY, 30 - 1, @PrimeiroDia) <= @UltimoDia)
    BEGIN
        SELECT @Movimento = SUM(Dia30) FROM @Tempor WHERE TipoLinha = 1;
        SET    @Total = @Total + @Movimento;
        UPDATE @Tempor SET Dia30 = @Total WHERE TipoLinha = 3;
        UPDATE @Tempor SET Dia31 = @Total WHERE TipoLinha = 0;
    END;
    
    IF (DATEADD(DAY, 31 - 1, @PrimeiroDia) <= @UltimoDia)
    BEGIN
        SELECT @Movimento = SUM(Dia31) FROM @Tempor WHERE TipoLinha = 1;
        SET    @Total = @Total + @Movimento;
        UPDATE @Tempor SET Dia31 = @Total WHERE TipoLinha = 3;
    END;

    -- Totaliza as categorias

    UPDATE @Tempor
    SET TotalCategoria = @Anterior
    WHERE TipoLinha = 0;

    UPDATE @Tempor
    SET TotalCategoria = COALESCE(Dia01, 0) + COALESCE(Dia02, 0) + COALESCE(Dia03, 0) + COALESCE(Dia04, 0) + COALESCE(Dia05, 0) +
                         COALESCE(Dia06, 0) + COALESCE(Dia07, 0) + COALESCE(Dia08, 0) + COALESCE(Dia09, 0) + COALESCE(Dia10, 0) +
                         COALESCE(Dia11, 0) + COALESCE(Dia12, 0) + COALESCE(Dia13, 0) + COALESCE(Dia14, 0) + COALESCE(Dia15, 0) +
                         COALESCE(Dia16, 0) + COALESCE(Dia17, 0) + COALESCE(Dia18, 0) + COALESCE(Dia19, 0) + COALESCE(Dia20, 0) +
                         COALESCE(Dia21, 0) + COALESCE(Dia22, 0) + COALESCE(Dia23, 0) + COALESCE(Dia24, 0) + COALESCE(Dia25, 0) +
                         COALESCE(Dia26, 0) + COALESCE(Dia27, 0) + COALESCE(Dia28, 0) + COALESCE(Dia29, 0) + COALESCE(Dia30, 0) +
                         COALESCE(Dia31, 0)
    WHERE TipoLinha = 2;

    UPDATE @Tempor
    SET TotalCategoria = (SELECT SUM(TotalCategoria)
                          FROM @Tempor
                          WHERE Ordem = 'C' AND TipoLinha = 2)
    WHERE Ordem = 'C'
    AND   TipoLinha = 1;

    UPDATE @Tempor
    SET TotalCategoria = (SELECT SUM(TotalCategoria)
                          FROM @Tempor
                          WHERE Ordem = 'D' AND TipoLinha = 2)
    WHERE Ordem = 'D'
    AND   TipoLinha = 1;

    UPDATE @Tempor
    SET TotalCategoria = (SELECT SUM(TotalCategoria)
                          FROM @Tempor
                          WHERE Ordem = 'I' AND TipoLinha = 2)
    WHERE Ordem = 'I'
    AND   TipoLinha = 1;

    UPDATE @Tempor
    SET TotalCategoria = @Anterior +
                         (SELECT SUM(TotalCategoria)
                          FROM @Tempor
                          WHERE TipoLinha = 2)
    WHERE TipoLinha = 3;

    --
    -- Insere na tabela temporária os valores aplicados em investimentos
    --

    WITH Fase01 AS (SELECT DATEPART(DAY, Dias.Dia) Dia,
                           dbo.fncSaldoInvestimentoLiquido(Ivst.InvestimentoID, Dias.Dia, 1) AS Valor
                    FROM @Dias Dias
                         JOIN Investimento Ivst ON 1 = 1
                         JOIN MovimentoInvestimento Mvto ON Mvto.InvestimentoID = Ivst.InvestimentoID
                         JOIN MovimentoConta MCta ON MCta.MovimentoContaID = Mvto.MovimentoContaID
                                                 AND CAST(MCta.Data AS DATE) <= Dias.Dia
                    GROUP BY Dias.Dia, Ivst.InvestimentoID
                    HAVING SUM(COALESCE(Mvto.QtCotas, 0)) <> 0)
    INSERT INTO @Tempor
    (Ordem, TipoLinha, CategoriaId, Categoria, 
     Dia01, Dia02, Dia03, Dia04, Dia05, Dia06, Dia07, Dia08, Dia09, Dia10,
     Dia11, Dia12, Dia13, Dia14, Dia15, Dia16, Dia17, Dia18, Dia19, Dia20,
     Dia21, Dia22, Dia23, Dia24, Dia25, Dia26, Dia27, Dia28, Dia29, Dia30, Dia31,
     DataReferencia, Outros)
    SELECT 'N' Ordem, 2 TipoLinha, 0 CategoriaID, 'Saldo Investimentos' Categoria,
            [1] 'DIA01',  [2] 'DIA02',  [3] 'DIA03',  [4] 'DIA04',  [5] 'DIA05',  [6] 'DIA06',  [7] 'DIA07',  [8] 'DIA08',  [9] 'DIA09', [10] 'DIA10',
           [11] 'DIA11', [12] 'DIA12', [13] 'DIA13', [14] 'DIA14', [15] 'DIA15', [16] 'DIA16', [17] 'DIA17', [18] 'DIA18', [19] 'DIA19', [20] 'DIA20',
           [21] 'DIA21', [22] 'DIA22', [23] 'DIA23', [24] 'DIA24', [25] 'DIA25', [26] 'DIA26', [27] 'DIA27', [28] 'DIA28', [29] 'DIA29', [30] 'DIA30',
           [31] 'DIA31',
           @UltimoDia, 0 Outros
    FROM (SELECT Dia, Valor FROM Fase01) Origem
    PIVOT (SUM(Valor) FOR Dia IN ( [1], [2], [3], [4], [5], [6], [7], [8], [9],[10],
                                  [11],[12],[13],[14],[15],[16],[17],[18],[19],[20],
                                  [21],[22],[23],[24],[25],[26],[27],[28],[29],[30],
                                  [31])) Final;

    --
    -- Insere na tabela temporária os valores de câmbio
    --

    WITH Fase01 AS (SELECT DATEPART(DAY, Dias.Dia) Dia,
                           SUM(Mvto.Valor * CtcM.Cotacao) Valor
                    FROM @Dias Dias
                         JOIN Conta Cnta ON Cnta.UsuarioID = @UsuarioID
                         JOIN Risco Rsco ON Rsco.RiscoID = 5
                         JOIN TipoConta TCnt ON TCnt.TipoContaID = Cnta.TipoContaID 
                                            AND TCnt.Cambio = 1
                         JOIN MovimentoConta Mvto WITH (INDEX(IX_MovimentoConta_ContaID_Data))
                                                    ON Mvto.ContaID = Cnta.ContaID 
                                                   AND Mvto.Data < Dias.DiaSeguinte
                         JOIN CotacaoMoeda CtcM WITH (INDEX(IX_CotacaoMoeda_UltimaCotacao_DeMoedaID_ParaMoedaID_Data))
                                                  ON CtcM.UltimaCotacao = 1
                                                 AND CtcM.DeMoedaID = Cnta.MoedaID
                                                 AND CtcM.ParaMoedaID = @MoedaPadraoID
                                                 AND CtcM.Data = (SELECT MAX(Moeda.Data)
                                                                  FROM CotacaoMoeda Moeda WITH (INDEX(IX_CotacaoMoeda_UltimaCotacao_DeMoedaID_ParaMoedaID_Data))
                                                                  WHERE Moeda.UltimaCotacao = 1
                                                                  AND   Moeda.DeMoedaID = Cnta.MoedaID
                                                                  AND   Moeda.ParaMoedaID = @MoedaPadraoID
                                                                  AND   Moeda.Data < Dias.DiaSeguinte)
                    GROUP BY DATEPART(DAY, Dias.Dia))
    INSERT INTO @Tempor
    (Ordem, TipoLinha, CategoriaId, Categoria, 
     Dia01, Dia02, Dia03, Dia04, Dia05, Dia06, Dia07, Dia08, Dia09, Dia10,
     Dia11, Dia12, Dia13, Dia14, Dia15, Dia16, Dia17, Dia18, Dia19, Dia20,
     Dia21, Dia22, Dia23, Dia24, Dia25, Dia26, Dia27, Dia28, Dia29, Dia30, Dia31,
     DataReferencia, Outros)
    SELECT 'O' Ordem, 2 TipoLinha, 0 CategoriaID, 'Saldo Câmbio (em ' + @Simbolo + ')' Categoria,
            [1] 'DIA01',  [2] 'DIA02',  [3] 'DIA03',  [4] 'DIA04',  [5] 'DIA05',  [6] 'DIA06',  [7] 'DIA07',  [8] 'DIA08',  [9] 'DIA09', [10] 'DIA10',
           [11] 'DIA11', [12] 'DIA12', [13] 'DIA13', [14] 'DIA14', [15] 'DIA15', [16] 'DIA16', [17] 'DIA17', [18] 'DIA18', [19] 'DIA19', [20] 'DIA20',
           [21] 'DIA21', [22] 'DIA22', [23] 'DIA23', [24] 'DIA24', [25] 'DIA25', [26] 'DIA26', [27] 'DIA27', [28] 'DIA28', [29] 'DIA29', [30] 'DIA30',
           [31] 'DIA31',
           @UltimoDia, 0 Outros
    FROM (SELECT Dia, Valor FROM Fase01) Origem
    PIVOT (SUM(Valor) FOR Dia IN ( [1], [2], [3], [4], [5], [6], [7], [8], [9],[10],
                                  [11],[12],[13],[14],[15],[16],[17],[18],[19],[20],
                                  [21],[22],[23],[24],[25],[26],[27],[28],[29],[30],
                                  [31])) Final;

    --
    -- Insere na tabela temporária o total geral
    --

    INSERT INTO @Tempor
    (Ordem, TipoLinha, CategoriaId, Categoria, 
     Dia01, Dia02, Dia03, Dia04, Dia05, Dia06, Dia07, Dia08, Dia09, Dia10,
     Dia11, Dia12, Dia13, Dia14, Dia15, Dia16, Dia17, Dia18, Dia19, Dia20,
     Dia21, Dia22, Dia23, Dia24, Dia25, Dia26, Dia27, Dia28, Dia29, Dia30, Dia31,
     DataReferencia, Outros)
    SELECT 'P' Ordem, 3 TipoLinha, 0 CategoriaID, 'Total Geral' Categoria,
            SUM(DIA01) DIA01, SUM(DIA02) DIA02, SUM(DIA03) DIA03, SUM(DIA04) DIA04, SUM(DIA05) DIA05,
            SUM(DIA06) DIA06, SUM(DIA07) DIA07, SUM(DIA08) DIA08, SUM(DIA09) DIA09, SUM(DIA10) DIA10,
            SUM(DIA11) DIA11, SUM(DIA12) DIA12, SUM(DIA13) DIA13, SUM(DIA14) DIA14, SUM(DIA15) DIA15,
            SUM(DIA16) DIA16, SUM(DIA17) DIA17, SUM(DIA18) DIA18, SUM(DIA19) DIA19, SUM(DIA20) DIA20,
            SUM(DIA21) DIA21, SUM(DIA22) DIA22, SUM(DIA23) DIA23, SUM(DIA24) DIA24, SUM(DIA25) DIA25,
            SUM(DIA26) DIA26, SUM(DIA27) DIA27, SUM(DIA28) DIA28, SUM(DIA29) DIA29, SUM(DIA30) DIA30, SUM(DIA31) DIA31,
            DataReferencia, 0 Outros
    FROM @Tempor
    WHERE Ordem IN ('M', 'N', 'O')
    GROUP BY DataReferencia; 

    --
    -- Copia o valor do último dia do mês para o Total Categoria
    --
    UPDATE @Tempor
    SET TotalCategoria = COALESCE(Dia31, Dia30, Dia29, Dia28)
    WHERE Ordem IN ('M', 'N');

    SELECT Ordem, TipoLinha, CategoriaID, Categoria, 
           Dia01, Dia02, Dia03, Dia04, Dia05, Dia06, Dia07, Dia08, Dia09, Dia10, 
           Dia11, Dia12, Dia13, Dia14, Dia15, Dia16, Dia17, Dia18, Dia19, Dia20, 
           Dia21, Dia22, Dia23, Dia24, Dia25, Dia26, Dia27, Dia28, Dia29, Dia30, 
           Dia31, TotalCategoria, DataReferencia
    FROM @Tempor
    ORDER BY Ordem ASC, TipoLinha ASC, Outros ASC, Categoria ASC;
              
END;
GO
/****** Object:  StoredProcedure [dbo].[stpOrcamentoMensal]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/******************************************************
 Procedure stpOrcamentoMensal
 Elcio Reis - 16/08/2019
 Cria uma "planilha" com as entradas e saídas do mês
 solicitado e dos 12 meses anteriores
 Exemplo de execução
 EXEC stpOrcamentoMensal 2, '2019-09-18', 1;
 ******************************************************/

CREATE PROCEDURE [dbo].[stpOrcamentoMensal] (@UsuarioID INT, @DataReferencia DATE = NULL, @Comparar BIT = 0)
AS
    DECLARE @InicioMes DATE;
    DECLARE @FimMes DATE;
    DECLARE @DataAnterior DATE;
    DECLARE @EspacoSimpl VARCHAR(10) = '      ';
    DECLARE @EspacoDuplo VARCHAR(20) = @EspacoSimpl + @EspacoSimpl;
    DECLARE @Anterior DECIMAL(22, 10), @Total DECIMAL(22,10), @Movimento DECIMAL(22,10);
BEGIN

    DECLARE @MoedaPadraoID INT;
    DECLARE @Simbolo VARCHAR(10);

    SELECT @MoedaPadraoID = MoedaID,
           @Simbolo = TRIM(Simbolo)
    FROM Moeda 
    WHERE Padrao = 1;

    IF (@DataReferencia IS NULL)
    BEGIN
        SET @DataReferencia = GETDATE();
    END;

    SET @DataReferencia = EOMONTH(@DataReferencia);

    DECLARE @Meses TABLE (Indice SMALLINT, Mes SMALLINT, Inicio DATE, Fim DATE, DiaSeguinte DATE);

    DECLARE @Indice SMALLINT = 13;

    SET @FimMes = DATEADD(DAY, 1, @DataReferencia);

    WHILE (@Indice > 0)
    BEGIN

        SET @FimMes = EOMONTH(@FimMes, -1);
        SET @InicioMes = DATEADD(DAY, 1, EOMONTH(@FimMes, -1));

        INSERT INTO @Meses 
        (Indice, Mes, Inicio, Fim, DiaSeguinte)
        VALUES 
        (@Indice, @Indice, @InicioMes, @FimMes, DATEADD(DAY, 1, @FimMes));

        SET @Indice = @Indice - 1;
    END;

    -- Cria tabela virtual para receber o conteúdo do select principal
    DECLARE @TabelaFinal TABLE (
        Ordem            CHAR(1),
        TipoLinha        SMALLINT,
        CategoriaID      INT,
        Categoria        VARCHAR(50),
        Mes01            DECIMAL(22,10),
        Mes02            DECIMAL(22,10),
        Mes03            DECIMAL(22,10),
        Mes04            DECIMAL(22,10),
        Mes05            DECIMAL(22,10),
        Mes06            DECIMAL(22,10),
        Mes07            DECIMAL(22,10),
        Mes08            DECIMAL(22,10),
        Mes09            DECIMAL(22,10),
        Mes10            DECIMAL(22,10),
        Mes11            DECIMAL(22,10),
        Mes12            DECIMAL(22,10),
        Mes13            DECIMAL(22,10),
        TotalCategoria   DECIMAL(22,10),
        MediaCategoria   DECIMAL(22,10),
        VarMedia13       DECIMAL(12,4),
        DataReferencia   DATE,
        Outros           SMALLINT    -- A coluna OUTROS é utilizada apenas para fazer com que os créditos ou débitos classificados como Outros fiquem ordenados no fim das exibições
    );

    IF (@Comparar = 1)
    BEGIN

        WITH Fase01 AS (SELECT 'A' Ordem, -1 TipoLinha, Mes.Indice Mes, 
                               SUM(COALESCE(MvCt.Credito, 0) - COALESCE(MvCt.Debito, 0)) Valor,
                               0 CategoriaID, 'Comparativo Inicial' Categoria, @DataReferencia DataReferencia, 0 Outros
                        FROM MovimentoConta MvCt
                             JOIN @Meses Mes ON CAST(MvCt.Data AS DATE) < Mes.Inicio
                             JOIN Conta Cnta ON Cnta.ContaID = MvCt.ContaID
                             JOIN TipoConta TpCt ON TpCt.TipoContaID = Cnta.TipoContaID
                        WHERE MvCt.UsuarioID = @UsuarioID
                        AND   Cnta.MoedaID = @MoedaPadraoID
                        GROUP BY Mes.Indice)
        INSERT INTO @TabelaFinal
        (Ordem, TipoLinha, CategoriaId, Categoria, 
         Mes01, Mes02, Mes03, Mes04, Mes05, Mes06, Mes07, Mes08, Mes09, Mes10, Mes11, Mes12, Mes13,
         DataReferencia, Outros)
        SELECT Ordem, TipoLinha, CategoriaID, Categoria,
               [1] 'Mes01',  [2] 'Mes02',  [3] 'Mes03',  [4] 'Mes04',  [5] 'Mes05',  [6] 'Mes06',  
               [7] 'Mes07',  [8] 'Mes08',  [9] 'Mes09', [10] 'Mes10', [11] 'Mes11', [12] 'Mes12', [13] 'Mes13',
               DataReferencia, Outros
        FROM (SELECT Mes, Ordem, TipoLinha, CategoriaID, Categoria, Outros, DataReferencia, Valor FROM Fase01 WHERE CategoriaID IS NOT NULL AND Ordem IS NOT NULL) Origem
        PIVOT (SUM(Valor) FOR Mes IN ( [1], [2], [3], [4], [5], [6], [7], [8], [9],[10],[11],[12], [13])) Final
        ORDER BY Ordem ASC, TipoLinha ASC, Outros ASC, Categoria ASC;


        WITH Fase01 AS (SELECT 'K' Ordem, -1 TipoLinha, Mes.Indice Mes, 
                               SUM(COALESCE(MvCt.Credito, 0) - COALESCE(MvCt.Debito, 0)) Valor,
                               0 CategoriaID, 'Comparativo Final' Categoria, @DataReferencia DataReferencia, 0 Outros
                        FROM MovimentoConta MvCt
                             JOIN @Meses Mes ON CAST(MvCt.Data AS DATE) < Mes.DiaSeguinte
                             JOIN Conta Cnta ON Cnta.ContaID = MvCt.ContaID
                             JOIN TipoConta TpCt ON TpCt.TipoContaID = Cnta.TipoContaID
                        WHERE MvCt.UsuarioID = @UsuarioID
                        AND   Cnta.MoedaID = @MoedaPadraoID
                        GROUP BY Mes.Indice)
        INSERT INTO @TabelaFinal
        (Ordem, TipoLinha, CategoriaId, Categoria, 
         Mes01, Mes02, Mes03, Mes04, Mes05, Mes06, Mes07, Mes08, Mes09, Mes10, Mes11, Mes12, Mes13,
         DataReferencia, Outros)
        SELECT Ordem, TipoLinha, CategoriaID, Categoria,
               [1] 'Mes01',  [2] 'Mes02',  [3] 'Mes03',  [4] 'Mes04',  [5] 'Mes05',  [6] 'Mes06',  
               [7] 'Mes07',  [8] 'Mes08',  [9] 'Mes09', [10] 'Mes10', [11] 'Mes11', [12] 'Mes12', [13] 'Mes13',
               DataReferencia, Outros
        FROM (SELECT Mes, Ordem, TipoLinha, CategoriaID, Categoria, Outros, DataReferencia, Valor FROM Fase01 WHERE CategoriaID IS NOT NULL AND Ordem IS NOT NULL) Origem
        PIVOT (SUM(Valor) FOR Mes IN ( [1], [2], [3], [4], [5], [6], [7], [8], [9],[10],[11],[12], [13])) Final
        ORDER BY Ordem ASC, TipoLinha ASC, Outros ASC, Categoria ASC;


    END;

    -- Insere as movimentações de conta
    WITH Fase01 AS (SELECT NMes.Mes,
                           MCta.Valor, Pais.CategoriaID, 
                           @EspacoDuplo + CASE WHEN COALESCE(Avos.CrdDeb, Pais.CrdDeb) = 'I' AND Ctgr.CrdDeb = 'C' THEN 'Resgate'
                                               WHEN COALESCE(Avos.CrdDeb, Pais.CrdDeb) = 'I' AND Ctgr.CrdDeb = 'D' THEN 'Aplicação'
                                               ELSE Pais.Apelido 
                                          END Categoria, 
                           COALESCE(CASE WHEN TRIM(Avos.CrdDeb) <> '' THEN Avos.CrdDeb ELSE NULL END, 
                                    CASE WHEN TRIM(Pais.CrdDeb) <> '' THEN Pais.CrdDeb ELSE NULL END, 
                                    CASE WHEN TRIM(Ctgr.CrdDeb) <> '' THEN Ctgr.CrdDeb ELSE NULL END) Ordem,
                           @DataReferencia DataReferencia, 
                           CASE WHEN Ctgr.Outros = 1 THEN 1
                                WHEN Pais.Outros = 1 THEN 1
                                WHEN Avos.Outros = 1 THEN 1
                                ELSE 0
                           END Outros
                    FROM @Meses NMes
                         JOIN MovimentoConta MCta ON CAST(MCta.Data AS DATE) BETWEEN NMes.Inicio AND NMes.Fim
                         JOIN Conta Cnta ON Cnta.ContaID = MCta.ContaID
                         JOIN TipoConta TpCt ON TpCt.TipoContaID = Cnta.TipoContaID
                         JOIN Categoria Ctgr ON Ctgr.CategoriaID = MCta.CategoriaID
                         JOIN Categoria Pais ON Pais.CategoriaID = Ctgr.CategoriaPaiID
                         JOIN Categoria Avos ON Avos.CategoriaID = Pais.CategoriaPaiID
                    WHERE MCta.UsuarioID = @UsuarioID
                    AND   Cnta.MoedaID = @MoedaPadraoID),
         Fase02 AS (-- Detalhes
                    SELECT Ordem, 2 TipoLinha, Mes, Valor, CategoriaID, Categoria, DataReferencia, Outros  
                    FROM Fase01
                    WHERE Ordem IN ('C', 'D', 'I')

                    UNION ALL

                    -- Total por categoria
                    SELECT Ordem, 1 TipoLinha, Mes, SUM(Valor) Valor, 0 CategoriaID, 
                           CASE Ordem
                                WHEN 'C' THEN @EspacoSimpl + 'Total Entradas'
                                WHEN 'D' THEN @EspacoSimpl + 'Total Saídas'
                                WHEN 'I' THEN @EspacoSimpl + 'Movimento Investimentos'
                                ELSE NULL
                            END Categoria, DataReferencia, 0 Outros
                    FROM Fase01
                    WHERE Ordem IN ('C', 'D', 'I')
                    GROUP BY Ordem, Mes, DataReferencia

                    UNION ALL
                    
                    SELECT 'A' Ordem, 0 TipoLinha, 1 Mes, 
                           SUM(COALESCE(MvCt.Credito, 0) - COALESCE(MvCt.Debito, 0)) Valor,
                           0 CategoriaID, 'Saldo Inicial' Categoria, @DataReferencia DataReferencia, 0 Outros
                    FROM MovimentoConta MvCt
                         JOIN Conta Cnta ON Cnta.ContaID = MvCt.ContaID
                         JOIN TipoConta TpCt ON TpCt.TipoContaID = Cnta.TipoContaID
                    WHERE MvCt.UsuarioID = @UsuarioID
                    AND   Cnta.MoedaID = @MoedaPadraoID
                    AND   MvCt.Data < @InicioMes

                    UNION ALL

                    -- Saldo Final
                    SELECT 'M' Ordem, 3 TipoLinha, Mes, 0 Valor, 0 CategoriaID, 
                           'Saldo Final a Transportar' Categoria, DataReferencia, 0 Outros
                    FROM Fase01
                    WHERE Ordem IN ('C', 'D', 'I')
                    GROUP BY Mes, DataReferencia)
    INSERT INTO @TabelaFinal
    (Ordem, TipoLinha, CategoriaId, Categoria, 
     Mes01, Mes02, Mes03, Mes04, Mes05, Mes06, Mes07, Mes08, Mes09, Mes10, Mes11, Mes12, Mes13,
     DataReferencia, Outros)
    SELECT Ordem, TipoLinha, CategoriaID, Categoria,
           [1] 'Mes01',  [2] 'Mes02',  [3] 'Mes03',  [4] 'Mes04',  [5] 'Mes05',  [6] 'Mes06',  
           [7] 'Mes07',  [8] 'Mes08',  [9] 'Mes09', [10] 'Mes10', [11] 'Mes11', [12] 'Mes12', [13] 'Mes13',
           DataReferencia, Outros
    FROM (SELECT Mes, Ordem, TipoLinha, CategoriaID, Categoria, Outros, DataReferencia, Valor FROM Fase02 WHERE CategoriaID IS NOT NULL AND Ordem IS NOT NULL) Origem
    PIVOT (SUM(Valor) FOR Mes IN ( [1], [2], [3], [4], [5], [6], [7], [8], [9],[10],[11],[12], [13])) Final
    ORDER BY Ordem ASC, TipoLinha ASC, Outros ASC, Categoria ASC;

    --
    -- Insere movimentos de investimentos
    --

    WITH Fase01 AS (SELECT NMes.Mes, MCta.Valor, 0 CategoriaID, 
                           @EspacoDuplo + Invt.Apelido Categoria,
                          'I' Ordem, 0 Outros
                    FROM @Meses NMes
                         JOIN MovimentoConta MCta ON CAST(MCta.Data AS DATE) BETWEEN NMES.Inicio AND NMES.Fim
                         JOIN MovimentoInvestimento MInv ON MInv.MovimentoContaID = MCta.MovimentoContaID
                         JOIN Investimento Invt ON Invt.InvestimentoID = MInv.InvestimentoID
                    WHERE MCta.UsuarioID = @UsuarioID),
         Fase02 AS (SELECT Mes, 2 TipoLinha,  Valor, CategoriaID, Categoria, Ordem
                    FROM Fase01

                    UNION ALL

                    SELECT Mes, 1 TipoLinha,  SUM(Valor) Valor, 0 CategoriaID, @EspacoSimpl + 'Investimentos' Categoria, Ordem
                    FROM Fase01
                    GROUP BY Mes, Ordem)
    INSERT INTO @TabelaFinal
    (Ordem, TipoLinha, CategoriaId, Categoria, 
     Mes01, Mes02, Mes03, Mes04, Mes05, Mes06, Mes07, Mes08, Mes09, Mes10, Mes11, Mes12, Mes13,
     DataReferencia, Outros)
    SELECT Ordem, TipoLinha, CategoriaID, Categoria,
           [1] 'Mes01',  [2] 'Mes02',  [3] 'Mes03',  [4] 'Mes04',  [5] 'Mes05',  [6] 'Mes06',  
           [7] 'Mes07',  [8] 'Mes08',  [9] 'Mes09', [10] 'Mes10', [11] 'Mes11', [12] 'Mes12', [13] 'Mes13',
           @DataReferencia DataReferencia, 0 Outros
    FROM (SELECT Mes, Ordem, TipoLinha, CategoriaID, Categoria, Valor FROM Fase02 WHERE CategoriaID IS NOT NULL AND Ordem IS NOT NULL) Origem
    PIVOT (SUM(Valor) FOR Mes IN ( [1], [2], [3], [4], [5], [6], [7], [8], [9],[10],[11],[12], [13])) Final
    ORDER BY Ordem ASC, TipoLinha ASC, Outros ASC, Categoria ASC;

    -- Marca todas os campos de linhas de total com zero, caso seja nula
    UPDATE @TabelaFinal
    SET Mes01 = COALESCE(Mes01, 0),
        Mes02 = COALESCE(Mes02, 0),
        Mes03 = COALESCE(Mes03, 0),
        Mes04 = COALESCE(Mes04, 0),
        Mes05 = COALESCE(Mes05, 0),
        Mes06 = COALESCE(Mes06, 0),
        Mes07 = COALESCE(Mes07, 0),
        Mes08 = COALESCE(Mes08, 0),
        Mes09 = COALESCE(Mes09, 0),
        Mes10 = COALESCE(Mes10, 0),
        Mes11 = COALESCE(Mes11, 0),
        Mes12 = COALESCE(Mes12, 0),
        Mes13 = COALESCE(Mes13, 0)
    WHERE TipoLinha = 1;

    -- Calcula o saldo inicial e final de cada mês

    SELECT @Anterior = Mes01 FROM @TabelaFinal WHERE TipoLinha = 0 AND Ordem <> 'S';
    SELECT @Movimento = SUM(Mes01) FROM @TabelaFinal WHERE TipoLinha = 1 AND Ordem <> 'S';
    SET    @Total = @Anterior + @Movimento;
    UPDATE @TabelaFinal SET Mes01 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Mes02 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Mes02) FROM @TabelaFinal WHERE TipoLinha = 1 AND Ordem <> 'S'
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Mes02 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Mes03 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Mes03) FROM @TabelaFinal WHERE TipoLinha = 1 AND Ordem <> 'S'
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Mes03 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Mes04 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Mes04) FROM @TabelaFinal WHERE TipoLinha = 1 AND Ordem <> 'S'
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Mes04 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Mes05 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Mes05) FROM @TabelaFinal WHERE TipoLinha = 1 AND Ordem <> 'S'
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Mes05 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Mes06 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Mes06) FROM @TabelaFinal WHERE TipoLinha = 1 AND Ordem <> 'S'
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Mes06 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Mes07 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Mes07) FROM @TabelaFinal WHERE TipoLinha = 1 AND Ordem <> 'S'
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Mes07 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Mes08 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Mes08) FROM @TabelaFinal WHERE TipoLinha = 1 AND Ordem <> 'S'
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Mes08 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Mes09 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Mes09) FROM @TabelaFinal WHERE TipoLinha = 1 AND Ordem <> 'S'
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Mes09 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Mes10 = @Total WHERE TipoLinha = 0;
        
    SELECT @Movimento = SUM(Mes10) FROM @TabelaFinal WHERE TipoLinha = 1 AND Ordem <> 'S'
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Mes10 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Mes11 = @Total WHERE TipoLinha = 0;
    
    SELECT @Movimento = SUM(Mes11) FROM @TabelaFinal WHERE TipoLinha = 1 AND Ordem <> 'S'
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Mes11 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Mes12 = @Total WHERE TipoLinha = 0;
        
    SELECT @Movimento = SUM(Mes12) FROM @TabelaFinal WHERE TipoLinha = 1 AND Ordem <> 'S'
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Mes12 = @Total WHERE TipoLinha = 3;
    UPDATE @TabelaFinal SET Mes13 = @Total WHERE TipoLinha = 0;

    SELECT @Movimento = SUM(Mes13) FROM @TabelaFinal WHERE TipoLinha = 1 AND Ordem <> 'S'
    SET    @Total = @Total + @Movimento;
    UPDATE @TabelaFinal SET Mes13 = @Total WHERE TipoLinha = 3;

    -- Totaliza as categorias

    UPDATE @TabelaFinal
    SET TotalCategoria = @Anterior
    WHERE TipoLinha = 0;

    UPDATE @TabelaFinal
    SET TotalCategoria = COALESCE(Mes01, 0) + COALESCE(Mes02, 0) + COALESCE(Mes03, 0) + COALESCE(Mes04, 0) + COALESCE(Mes05, 0) + COALESCE(Mes06, 0) + 
                         COALESCE(Mes07, 0) + COALESCE(Mes08, 0) + COALESCE(Mes09, 0) + COALESCE(Mes10, 0) + COALESCE(Mes11, 0) + COALESCE(Mes12, 0)
    WHERE TipoLinha = 2;

    -- Totaliza as categorias de crédito e coloca na linha tipo 1 correspondente
    UPDATE @TabelaFinal
    SET TotalCategoria = (SELECT SUM(TotalCategoria)
                          FROM @TabelaFinal
                          WHERE Ordem = 'C' AND TipoLinha = 2)
    WHERE Ordem = 'C'
    AND   TipoLinha = 1;

    -- Totaliza as categorias de débito e coloca na linha tipo 1 correspondente
    UPDATE @TabelaFinal
    SET TotalCategoria = (SELECT SUM(TotalCategoria)
                          FROM @TabelaFinal
                          WHERE Ordem = 'D' AND TipoLinha = 2)
    WHERE Ordem = 'D'
    AND   TipoLinha = 1;

    -- Totaliza as categorias de investimento e coloca na linha tipo 1 correspondente
    UPDATE @TabelaFinal
    SET TotalCategoria = (SELECT SUM(TotalCategoria)
                          FROM @TabelaFinal
                          WHERE Ordem = 'I' AND TipoLinha = 2)
    WHERE Ordem = 'I'
    AND   TipoLinha = 1;

    -- Calcula o saldo final de cada período
    UPDATE @TabelaFinal
    SET TotalCategoria = @Anterior +
                         (SELECT SUM(TotalCategoria)
                          FROM @TabelaFinal
                          WHERE TipoLinha = 2)
    WHERE TipoLinha = 3;

    -- Calcula a média das categorias
    UPDATE @TabelaFinal
    SET MediaCategoria = TotalCategoria / 12
    WHERE TipoLinha IN (1, 2);

    -- Calcula a variação do mês corrente com relação à média
    UPDATE @TabelaFinal
    SET VarMedia13 = CASE WHEN COALESCE(MediaCategoria, 0) <> 0 AND COALESCE(Mes13, 0) <> 0 THEN Mes13 / MediaCategoria * 100 - 100
                          WHEN COALESCE(MediaCategoria, 0) <> 0 AND COALESCE(Mes13, 0) = 0 THEN -9999.9999
                          WHEN COALESCE(MediaCategoria, 0) = 0 AND COALESCE(Mes13, 0) <> 0 THEN 9999.9999
                          ELSE 0
                     END
    WHERE TipoLinha IN (1, 2);

    --
    -- Insere na tabela temporária os valores aplicados em investimentos
    --

    WITH Fase01 AS (SELECT NMes.Mes,
                           dbo.fncSaldoInvestimentoLiquido(Ivst.InvestimentoID, NMes.Fim, 1) AS Valor
                    FROM @Meses NMes
                         JOIN Investimento Ivst ON 1 = 1
                         JOIN MovimentoInvestimento Mvto ON Mvto.InvestimentoID = Ivst.InvestimentoID
                         JOIN MovimentoConta MCta ON MCta.MovimentoContaID = Mvto.MovimentoContaID
                                                 AND MCta.Data < NMes.DiaSeguinte
                    GROUP BY NMes.Mes, NMes.Fim, Ivst.InvestimentoID
                    HAVING SUM(COALESCE(Mvto.QtCotas, 0)) <> 0)
    INSERT INTO @TabelaFinal
    (Ordem, TipoLinha, CategoriaId, Categoria, 
     Mes01, Mes02, Mes03, Mes04, Mes05, Mes06, Mes07, Mes08, Mes09, Mes10, Mes11, Mes12, Mes13,
     DataReferencia, Outros)
    SELECT 'N' Ordem, 2 TipoLinha, 0 CategoriaID, 'Saldo Investimentos' Categoria,
           [1] 'Mes01',  [2] 'Mes02',  [3] 'Mes03',  [4] 'Mes04',  [5] 'Mes05',  [6] 'Mes06',  
           [7] 'Mes07',  [8] 'Mes08',  [9] 'Mes09', [10] 'Mes10', [11] 'Mes11', [12] 'Mes12', [13] 'Mes13',
           @DataReferencia, 0 Outros
    FROM (SELECT Mes, Valor FROM Fase01) Origem
    PIVOT (SUM(Valor) FOR Mes IN ([1], [2], [3], [4], [5], [6], [7], [8], [9],[10],[11],[12], [13])) Final
    ORDER BY Ordem ASC, TipoLinha ASC, Outros ASC, Categoria ASC;

--------------------------------
--------------------------------

    --
    -- Insere na tabela temporária os valores de câmbio
    --

    WITH Fase01 AS (SELECT NMes.Mes,
                           SUM(Mvto.Valor * CtcM.Cotacao) Valor
                    FROM @Meses NMes
                         JOIN Conta Cnta ON Cnta.UsuarioID = @UsuarioID
                         JOIN Risco Rsco ON Rsco.RiscoID = 5
                         JOIN TipoConta TCnt ON TCnt.TipoContaID = Cnta.TipoContaID 
                                            AND TCnt.Cambio = 1
                         JOIN MovimentoConta Mvto WITH (INDEX(IX_MovimentoConta_ContaID_Data))
                                                    ON Mvto.ContaID = Cnta.ContaID 
                                                   AND Mvto.Data < NMes.DiaSeguinte
                         JOIN CotacaoMoeda CtcM WITH (INDEX(IX_CotacaoMoeda_UltimaCotacao_DeMoedaID_ParaMoedaID_Data))
                                                  ON CtcM.UltimaCotacao = 1
                                                 AND CtcM.DeMoedaID = Cnta.MoedaID
                                                 AND CtcM.ParaMoedaID = @MoedaPadraoID
                                                 AND CtcM.Data = (SELECT MAX(Moeda.Data)
                                                                  FROM CotacaoMoeda Moeda WITH (INDEX(IX_CotacaoMoeda_UltimaCotacao_DeMoedaID_ParaMoedaID_Data))
                                                                  WHERE Moeda.UltimaCotacao = 1
                                                                  AND   Moeda.DeMoedaID = Cnta.MoedaID
                                                                  AND   Moeda.ParaMoedaID = @MoedaPadraoID
                                                                  AND   Moeda.Data < NMes.DiaSeguinte)
                    GROUP BY NMes.Mes)
    INSERT INTO @TabelaFinal
    (Ordem, TipoLinha, CategoriaId, Categoria, 
     Mes01, Mes02, Mes03, Mes04, Mes05, Mes06, Mes07, Mes08, Mes09, Mes10, Mes11, Mes12, Mes13,
     DataReferencia, Outros)
    SELECT 'O' Ordem, 2 TipoLinha, 0 CategoriaID, 'Saldo Câmbio (em ' + @Simbolo + ')' Categoria,
           [1] 'Mes01',  [2] 'Mes02',  [3] 'Mes03',  [4] 'Mes04',  [5] 'Mes05',  [6] 'Mes06',  
           [7] 'Mes07',  [8] 'Mes08',  [9] 'Mes09', [10] 'Mes10', [11] 'Mes11', [12] 'Mes12', [13] 'Mes13',
           @DataReferencia, 0 Outros
    FROM (SELECT Mes, Valor FROM Fase01) Origem
    PIVOT (SUM(Valor) FOR Mes IN ([1], [2], [3], [4], [5], [6], [7], [8], [9],[10],[11],[12], [13])) Final
    ORDER BY Ordem ASC, TipoLinha ASC, Outros ASC, Categoria ASC;
--------------------------------
--------------------------------

    --
    -- Insere na tabela temporária o total geral
    --

    INSERT INTO @TabelaFinal
    (Ordem, TipoLinha, CategoriaId, Categoria, 
     Mes01, Mes02, Mes03, Mes04, Mes05, Mes06, Mes07, Mes08, Mes09, Mes10, Mes11, Mes12, Mes13,
     DataReferencia, Outros)
    SELECT 'O' Ordem, 3 TipoLinha, 0 CategoriaID, 'Total Geral' Categoria,
            SUM(Mes01) Mes01, SUM(Mes02) Mes02, SUM(Mes03) Mes03, SUM(Mes04) Mes04, SUM(Mes05) Mes05, SUM(Mes06) Mes06, 
            SUM(Mes07) Mes07, SUM(Mes08) Mes08, SUM(Mes09) Mes09, SUM(Mes10) Mes10, SUM(Mes11) Mes11, SUM(Mes12) Mes12, SUM(Mes13) Mes13,
            DataReferencia, 0 Outros
    FROM @TabelaFinal
    WHERE Ordem IN ('M', 'N', 'O')
    GROUP BY DataReferencia;  

    SELECT Ordem, TipoLinha, CategoriaID, Categoria,
           Mes01, 
           Mes02, 
           Mes03, 
           Mes04, 
           Mes05, 
           Mes06, 
           Mes07, 
           Mes08, 
           Mes09, 
           Mes10, 
           Mes11, 
           Mes12, 
           Mes13, VarMedia13,
           TotalCategoria, MediaCategoria, DataReferencia
    FROM @TabelaFinal
    ORDER BY Ordem ASC, TipoLinha ASC, Outros ASC, Categoria ASC;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpPagamentoCartoCredito]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/********************************************************
 Procedure stpPagamentoCartoCredito
 Elcio Reis - 06/09/2019

 Cria uma "planilha" com os valor pagos a cartão de 
 crédito nos últimos 12 meses.

 Se a data de referência não for informada, utilizará a
 data corrente.

 Exemplo de execução
 EXEC stpPagamentoCartoCredito 2, '2019-08-18'
 ********************************************************/

CREATE PROCEDURE [dbo].[stpPagamentoCartoCredito] (@UsuarioID INT, @DataReferencia DATE = NULL)
AS
    DECLARE @InicioMes DATE;
    DECLARE @FimMes DATE;
BEGIN

    IF (@DataReferencia IS NULL)
    BEGIN
        SELECT @DataReferencia = MAX(CAST(MvCt.Data AS DATE))
        FROM MovimentoConta MvCt
             JOIN Conta Cnta ON Cnta.ContaID = MvCt.ContaID
                            AND Cnta.UsuarioID = @UsuarioID
             JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
             JOIN GrupoConta GpCt ON GpCt.GrupoContaID = Tipo.GrupoContaID
             JOIN vw_CategoriasSelecionaveis CSel ON CSel.CategoriaID = MvCt.CategoriaID
                                                 AND CSel.vCrdDeb = 'T'
                                                 AND CSel.ContaID > 0
        WHERE GpCt.FluxoCredito = 1
        AND   MvCt.DoMovimentoContaID IS NOT NULL
    END;

    SET @DataReferencia = EOMONTH(@DataReferencia);

    DECLARE @Meses TABLE (Indice SMALLINT, Inicio DATE, Fim DATE);
    DECLARE @Indice SMALLINT = 12;

    SET @FimMes = DATEADD(DAY, 1, @DataReferencia);

    WHILE (@Indice > 0)
    BEGIN

        SET @FimMes = EOMONTH(@FimMes, -1);
        SET @InicioMes = DATEADD(DAY, 1, EOMONTH(@FimMes, -1));

        INSERT INTO @Meses 
        (Indice, Inicio, Fim)
        VALUES 
        (@Indice, @InicioMes, @FimMes);

        SET @Indice = @Indice - 1;
    END;

    -- Cria tabela virtual para receber o conteúdo do select principal
    DECLARE @TabelaFinal TABLE (
        TipoLinha  SMALLINT,
        ContaID    INT,
        Conta      VARCHAR(50),
        Mes01      DECIMAL(10, 2),
        Mes02      DECIMAL(10, 2),
        Mes03      DECIMAL(10, 2),
        Mes04      DECIMAL(10, 2),
        Mes05      DECIMAL(10, 2),
        Mes06      DECIMAL(10, 2),
        Mes07      DECIMAL(10, 2),
        Mes08      DECIMAL(10, 2),
        Mes09      DECIMAL(10, 2),
        Mes10      DECIMAL(10, 2),
        Mes11      DECIMAL(10, 2),
        Mes12      DECIMAL(10, 2),
        Total      DECIMAL(10, 2),
        Media      DECIMAL(10, 2)
    );

    DECLARE @EspacoSimpl VARCHAR(10) = '      ';

    WITH Fase01 AS (SELECT Meses.Indice Indice,
                           Cnta.ContaID,
                           Cnta.Apelido Conta,
                           MvCt.Valor
                    FROM MovimentoConta MvCt
                         JOIN @Meses Meses ON CAST(MvCt.Data AS DATE) BETWEEN Meses.Inicio AND Meses.Fim
                         JOIN Conta Cnta ON Cnta.ContaID = MvCt.ContaID
                                        AND Cnta.UsuarioID = @UsuarioID
                         JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
                         JOIN GrupoConta GpCt ON GpCt.GrupoContaID = Tipo.GrupoContaID
                         JOIN vw_CategoriasSelecionaveis CSel ON CSel.CategoriaID = MvCt.CategoriaID
                                                             AND CSel.vCrdDeb = 'T'
                                                             AND CSel.ContaID > 0
                    WHERE GpCt.FluxoCredito = 1
                    AND   MvCt.DoMovimentoContaID IS NOT NULL),
         Fase02 AS (SELECT 0 TipoLinha, F1.Indice, F1.ContaID, F1.Conta Conta, F1.Valor
                    FROM Fase01 F1

                    UNION ALL

                    SELECT 1 TipoLinha, F1.Indice, 0 ContaID, 'Total Pagamento' Conta, SUM(F1.Valor) Valor
                    FROM Fase01 F1
                    GROUP BY F1.Indice)
    INSERT INTO @TabelaFinal
    (TipoLinha, ContaID, Conta, 
     Mes01, Mes02, Mes03, Mes04, Mes05, Mes06,
     Mes07, Mes08, Mes09, Mes10, Mes11, Mes12)
    SELECT TipoLinha, ContaID, Conta, 
           [1] 'Mes01', [2] 'Mes02', [3] 'Mes03',  [4] 'Mes04',  [5] 'Mes05',  [6] 'Mes06',
           [7] 'Mes07', [8] 'Mes08', [9] 'Mes09', [10] 'Mes10', [11] 'Mes11', [12] 'Mes12'
    FROM (SELECT Indice, TipoLinha, ContaID, Conta, Valor FROM Fase02) Origem
    PIVOT (SUM(VALOR) FOR Indice IN ( [1],  [2],  [3],  [4],  [5],  [6], 
                                      [7],  [8],  [9], [10], [11], [12])) Final
    ORDER BY TipoLinha, Conta;

    UPDATE @TabelaFinal
    SET Mes01 = COALESCE(Mes01, 0),
        Mes02 = COALESCE(Mes02, 0),
        Mes03 = COALESCE(Mes03, 0),
        Mes04 = COALESCE(Mes04, 0),
        Mes05 = COALESCE(Mes05, 0),
        Mes06 = COALESCE(Mes06, 0),
        Mes07 = COALESCE(Mes07, 0),
        Mes08 = COALESCE(Mes08, 0),
        Mes09 = COALESCE(Mes09, 0),
        Mes10 = COALESCE(Mes10, 0),
        Mes11 = COALESCE(Mes11, 0),
        Mes12 = COALESCE(Mes12, 0)
    WHERE TipoLinha = 1;

    UPDATE @TabelaFinal
    SET Total = COALESCE(Mes01, 0) + COALESCE(Mes02, 0) + COALESCE(Mes03, 0) + COALESCE(Mes04, 0) + COALESCE(Mes05, 0) + COALESCE(Mes06, 0) +
                COALESCE(Mes07, 0) + COALESCE(Mes08, 0) + COALESCE(Mes09, 0) + COALESCE(Mes10, 0) + COALESCE(Mes11, 0) + COALESCE(Mes12, 0);

    UPDATE @TabelaFinal
    SET Media = Total / 12;

    --UPDATE @TabelaFinal
    --SET Media = Total / (CASE WHEN Mes01 IS NULL THEN 0 ELSE 1 END +
    --                     CASE WHEN Mes02 IS NULL THEN 0 ELSE 1 END +
    --                     CASE WHEN Mes03 IS NULL THEN 0 ELSE 1 END +
    --                     CASE WHEN Mes04 IS NULL THEN 0 ELSE 1 END +
    --                     CASE WHEN Mes05 IS NULL THEN 0 ELSE 1 END +
    --                     CASE WHEN Mes06 IS NULL THEN 0 ELSE 1 END +
    --                     CASE WHEN Mes07 IS NULL THEN 0 ELSE 1 END +
    --                     CASE WHEN Mes08 IS NULL THEN 0 ELSE 1 END +
    --                     CASE WHEN Mes09 IS NULL THEN 0 ELSE 1 END +
    --                     CASE WHEN Mes10 IS NULL THEN 0 ELSE 1 END +
    --                     CASE WHEN Mes11 IS NULL THEN 0 ELSE 1 END +
    --                     CASE WHEN Mes12 IS NULL THEN 0 ELSE 1 END);

    SELECT TipoLinha, ContaID, Conta,
           Mes01,
           Mes02,
           Mes03,
           Mes04,
           Mes05,
           Mes06,
           Mes07,
           Mes08,
           Mes09,
           Mes10,
           Mes11,
           Mes12,
           Total, Media,
           @DataReferencia DataReferencia
    FROM @TabelaFinal
    ORDER BY TipoLinha ASC, Conta ASC;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpPopula_InvestimentoVariacao]    Script Date: 05/01/2022 12:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*******************************************************************************
 Limpa a tabela InvestimentoVariacao e recria todos os valores de investimentos,
 dia a dia, a tabela InvestimentoVariacao é a base para vários gráficos e tabelas
 demonstrativas de desempenho de fundos de investimento.

 Seu processamento é executado através do MoneyPro após a recepção das cotações
 diárias.

 ** Não há problemas em executar esta procedure mais de uma vez, pois sempre os
 ** dados da tabela InvestimentoVariacao serão recriados do início da utilização
 ** do sistema MoneyPro, data contida no campo MoneyPro.DtInicioUtilizacao.

 EXEC stpPopula_InvestimentoVariacao;
 *******************************************************************************/

CREATE PROC [dbo].[stpPopula_InvestimentoVariacao]
AS
BEGIN

    SET NOCOUNT ON;

    -- Remove todos os registros e refaz a população da tabela InvestimentoVariacao.

    DELETE FROM InvestimentoVariacao;

    DECLARE @Periodo CHAR(1) = 'U',
            @DtInicio DATE;

    -- Data utilizada na tabela de configuração
    SELECT @DtInicio = DtInicioUtilizacao
    FROM MoneyPro 
    WHERE MoneyProID = (SELECT MAX(MoneyProID) FROM MoneyPro);

    -- Cria uma tabela contendo apenas as datas necessárias
  	DECLARE @Datas TABLE (Data DATE);

    -- Popula com todas os dias úteis (sem ser sábado e domingo e que teve cotação de ao menos uma aplicação)
    INSERT INTO @Datas
	EXEC stpDataParaPesquisa @Periodo, @DtInicio;

    DECLARE VariacaoDiaria CURSOR
    FOR SELECT Sel.InvestimentoID, Dat.Data, dbo.fncSaldoInvestimentoLiquidoDiaExato(Sel.InvestimentoID, Dat.Data, 1) Valor, COALESCE(SUM(CASE WHEN MInv.QtCotas > 0 THEN 1 ELSE -1 END * MInv.VrLiquido), 0) Descontar
        FROM Investimento Sel
        INNER JOIN @Datas Dat ON 1 = 1
        LEFT JOIN MovimentoConta MCta ON MCta.Data = Dat.Data
        LEFT JOIN MovimentoInvestimento MInv ON MInv.MovimentoContaID = MCta.MovimentoContaID AND MInv.InvestimentoID = Sel.InvestimentoID
        WHERE Sel.InvestimentoID IN (SELECT DISTINCT InvestimentoID FROM MovimentoInvestimento)
        GROUP BY Sel.InvestimentoID, Dat.Data
        ORDER BY Sel.InvestimentoID ASC, Dat.Data DESC;

    DECLARE @sldInvestimentoID INT,
            @sldData           DATE,
            @sldValor          NUMERIC(15,4),
            @sldDescontar      NUMERIC(15,4);

    DECLARE @auxInvestimentoID INT = 0,
            @auxData           DATE,
            @auxValor          NUMERIC(15,4),
            @auxDescontar      NUMERIC(15,4);

    OPEN VariacaoDiaria;

    FETCH NEXT FROM VariacaoDiaria
    INTO @sldInvestimentoID, @sldData, @sldValor, @sldDescontar;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        IF (@auxInvestimentoID = @sldInvestimentoID)
        BEGIN

            INSERT INTO InvestimentoVariacao
            (InvestimentoID, Data, 
             ValorLiquido,
             PercInvestimento)
            VALUES
            (@auxInvestimentoID, @auxData, 
             @auxValor - (@sldValor + @auxDescontar),
            CASE WHEN @sldValor <> 0 THEN (@auxValor - (@sldValor + @auxDescontar)) / @sldValor ELSE 0 END);

        END
        ELSE
        BEGIN

            SET @auxInvestimentoID = @sldInvestimentoID;

        END;

        SET @auxData = @sldData;
        SET @auxValor = @sldValor;
        SET @auxDescontar = @sldDescontar;

        FETCH NEXT FROM VariacaoDiaria
        INTO @sldInvestimentoID, @sldData, @sldValor, @sldDescontar;

    END;

    CLOSE VariacaoDiaria;
    DEALLOCATE VariacaoDiaria;

    DELETE FROM InvestimentoVariacao WHERE ValorLiquido IS NULL;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpPopula_InvestimentoVariacao_V2]    Script Date: 05/01/2022 12:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*******************************************************************************
 Limpa a tabela InvestimentoVariacao e recria todos os valores de investimentos,
 dia a dia, a tabela InvestimentoVariacao é a base para vários gráficos e tabelas
 demonstrativas de desempenho de fundos de investimento.

 Seu processamento é executado através do MoneyPro após a recepção das cotações
 diárias.

 ** Não há problemas em executar esta procedure mais de uma vez, pois sempre os
 ** dados da tabela InvestimentoVariacao serão recriados do início da utilização
 ** do sistema MoneyPro, data contida no campo MoneyPro.DtInicioUtilizacao.

 EXEC stpPopula_InvestimentoVariacao_V2;   0.0001290636
 *******************************************************************************/

CREATE PROC [dbo].[stpPopula_InvestimentoVariacao_V2]
AS
BEGIN

    SET NOCOUNT ON;

    -- Remove todos os registros e refaz a população da tabela InvestimentoVariacao.

    DECLARE @Periodo CHAR(1) = 'U',
            @DtInicio DATE;

    -- Data utilizada na tabela de configuração
    SELECT @DtInicio = DtInicioUtilizacao
    FROM MoneyPro 
    WHERE MoneyProID = (SELECT MAX(MoneyProID) FROM MoneyPro);

    -- Cria uma tabela contendo apenas as datas necessárias
  	DECLARE @Datas TABLE (Data DATE);

    -- Popula com todas os dias úteis (sem ser sábado e domingo e que teve cotação de ao menos uma aplicação)
    INSERT INTO @Datas
	EXEC stpDataParaPesquisa @Periodo, @DtInicio;

    DECLARE VariacaoDiaria CURSOR
    FOR SELECT Sel.InvestimentoID, Dat.Data, dbo.fncSaldoInvestimentoLiquidoDiaExato(Sel.InvestimentoID, Dat.Data, 1) Valor, COALESCE(SUM(CASE WHEN MInv.QtCotas > 0 THEN 1 ELSE -1 END * MInv.VrLiquido), 0) Descontar
        FROM Investimento Sel
        INNER JOIN @Datas Dat ON 1 = 1
        LEFT JOIN MovimentoConta MCta ON MCta.Data = Dat.Data
        LEFT JOIN MovimentoInvestimento MInv ON MInv.MovimentoContaID = MCta.MovimentoContaID AND MInv.InvestimentoID = Sel.InvestimentoID
        WHERE Sel.InvestimentoID IN (SELECT DISTINCT InvestimentoID FROM MovimentoInvestimento)
        GROUP BY Sel.InvestimentoID, Dat.Data
        ORDER BY Sel.InvestimentoID ASC, Dat.Data DESC;

    DECLARE @sldInvestimentoID INT,
            @sldData           DATE,
            @sldValor          NUMERIC(15,4),
            @sldDescontar      NUMERIC(15,4);

    DECLARE @auxInvestimentoID INT = 0,
            @auxData           DATE,
            @auxValor          NUMERIC(15,4),
            @auxDescontar      NUMERIC(15,4);

    OPEN VariacaoDiaria;

    FETCH NEXT FROM VariacaoDiaria
    INTO @sldInvestimentoID, @sldData, @sldValor, @sldDescontar;

    declare @InvestimentoVariacao table  (InvestimentoID int, Data date, LucroLiquido numeric(18,8), Porcentagem numeric(18,12));

    WHILE @@FETCH_STATUS = 0
    BEGIN

        IF (@auxInvestimentoID = @sldInvestimentoID)
        BEGIN

            INSERT INTO @InvestimentoVariacao
            (InvestimentoID, Data, 
             LucroLiquido, 
             Porcentagem)
            VALUES
            (@auxInvestimentoID, @auxData, 
             @auxValor - (@sldValor + @auxDescontar),
             (@auxValor - (@sldValor + @auxDescontar)) / @sldValor);

        END
        ELSE
        BEGIN

            SET @auxInvestimentoID = @sldInvestimentoID;

        END;

        SET @auxData = @sldData;
        SET @auxValor = @sldValor;
        SET @auxDescontar = @sldDescontar;

        FETCH NEXT FROM VariacaoDiaria
        INTO @sldInvestimentoID, @sldData, @sldValor, @sldDescontar;

    END;

    CLOSE VariacaoDiaria;
    DEALLOCATE VariacaoDiaria;

    DELETE FROM @InvestimentoVariacao WHERE LucroLiquido IS NULL;

    select * from @InvestimentoVariacao order by investimentoID ASC, Data ASC;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpPopulaInvestimentoEspecificoVariacao]    Script Date: 05/01/2022 12:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*******************************************************************************
 Limpa a tabela InvestimentoVariacao e recria todos os valores de investimentos,
 dia a dia, a tabela InvestimentoVariacao é a base para vários gráficos e tabelas
 demonstrativas de desempenho de fundos de investimento.

 Seu processamento é executado através do MoneyPro após a recepção das cotações
 diárias.

 ** Não há problemas em executar esta procedure mais de uma vez, pois sempre os
 ** dados da tabela InvestimentoVariacao serão recriados do início da utilização
 ** do sistema MoneyPro, data contida no campo MoneyPro.DtInicioUtilizacao.

 EXEC stpPopulaInvestimentoEspecificoVariacao 1;
 *******************************************************************************/

CREATE PROC [dbo].[stpPopulaInvestimentoEspecificoVariacao]  (@InvestimentoID INT)
AS
BEGIN

    SET NOCOUNT ON;

    -- Remove todos os registros e refaz a população da tabela InvestimentoVariacao.

    DELETE FROM InvestimentoVariacao
    WHERE InvestimentoID = @InvestimentoID;

    DECLARE @Periodo CHAR(1) = 'U',
            @DtInicio DATE;

    -- Data utilizada na tabela de configuração
    --SELECT @DtInicio = DtInicioUtilizacao
    --FROM MoneyPro 
    --WHERE MoneyProID = (SELECT MAX(MoneyProID) FROM MoneyPro);

    SELECT @DtInicio = MIN(MCta.Data)
    FROM MovimentoConta MCta
    JOIN MovimentoInvestimento MInv ON MInv.MovimentoContaID = MCta.MovimentoContaID AND MInv.InvestimentoID = @InvestimentoID;

    -- Cria uma tabela contendo apenas as datas necessárias
  	DECLARE @Datas TABLE (Data DATE);

    -- Popula com todas os dias úteis (sem ser sábado e domingo e que teve cotação de ao menos uma aplicação)
    INSERT INTO @Datas
	EXEC stpDataParaPesquisa @Periodo, @DtInicio;

    DECLARE VariacaoDiaria CURSOR
    FOR SELECT Dat.Data, dbo.fncSaldoInvestimentoLiquidoDiaExato(Sel.InvestimentoID, Dat.Data, 1) Valor, COALESCE(SUM(CASE WHEN MInv.QtCotas > 0 THEN 1 ELSE -1 END * MInv.VrLiquido), 0) Descontar
        FROM Investimento Sel
        INNER JOIN @Datas Dat ON 1 = 1
        LEFT JOIN MovimentoConta MCta ON MCta.Data = Dat.Data
        LEFT JOIN MovimentoInvestimento MInv ON MInv.MovimentoContaID = MCta.MovimentoContaID AND MInv.InvestimentoID = Sel.InvestimentoID
        WHERE Sel.InvestimentoID = @InvestimentoID
        GROUP BY Sel.InvestimentoID, Dat.Data
        ORDER BY Dat.Data DESC;

    DECLARE @sldData           DATE,
            @sldValor          NUMERIC(15,4),
            @sldDescontar      NUMERIC(15,4);

    DECLARE @auxData           DATE,
            @auxValor          NUMERIC(15,4),
            @auxDescontar      NUMERIC(15,4);

    OPEN VariacaoDiaria;

    FETCH NEXT FROM VariacaoDiaria
    INTO @auxData, @auxValor, @auxDescontar;

    IF (@@FETCH_STATUS = 0)
    BEGIN

        FETCH NEXT FROM VariacaoDiaria
        INTO @sldData, @sldValor, @sldDescontar;

        WHILE @@FETCH_STATUS = 0
        BEGIN

            INSERT INTO InvestimentoVariacao
            (InvestimentoID, Data, 
             ValorLiquido,
             PercInvestimento)
            VALUES
            (@InvestimentoID, @auxData, 
             @auxValor - (@sldValor + @auxDescontar),
            CASE WHEN @sldValor <> 0 THEN (@auxValor - (@sldValor + @auxDescontar)) / @sldValor ELSE 0 END);

            SET @auxData = @sldData;
            SET @auxValor = @sldValor;
            SET @auxDescontar = @sldDescontar;

            FETCH NEXT FROM VariacaoDiaria
            INTO @sldData, @sldValor, @sldDescontar;

        END; -- WHILE @@FETCH_STATUS = 0

    END; -- IF (@@FETCH_STATUS = 0)

    CLOSE VariacaoDiaria;
    DEALLOCATE VariacaoDiaria;

    DELETE FROM InvestimentoVariacao WHERE ValorLiquido IS NULL;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpPoupancaMovimento]    Script Date: 05/01/2022 12:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpPoupancaMovimento] 
    @DtInicio DATE = NULL
AS
BEGIN

    IF (@DtInicio IS NULL)
    BEGIN
        -- Data utilizada na tabela de configuração
        SELECT @DtInicio = DtInicioUtilizacao
        FROM MoneyPro 
        WHERE MoneyProID = (SELECT MAX(MoneyProID) FROM MoneyPro);
    END
    ELSE
    BEGIN
        SET @DtInicio = DATEADD(DAY, 1, @DtInicio);
    END;

	DECLARE @Datas TABLE (Data DATE);

	INSERT INTO @Datas EXEC stpDataParaPesquisa 'U', @DtInicio;   -- dia 08-10-2016 foi domingo,

	-- Apaga possíveis tabelas auxiares abandonadas
    --IF OBJECT_ID('TempDB.dbo.#Destino') IS NOT NULL
    --    DROP TABLE #Destino;

    DECLARE @Auxiliar TABLE (
        ContaID  INT,
        Data     Date,
        Valor    NUMERIC(18,4)
    );
            
    DECLARE @Destino TABLE (
        ContaID  INT,
        Data     Date,
        Valor    NUMERIC(18,4)
    );



    INSERT INTO @Auxiliar
    (ContaID, Data, Valor)
    SELECT Mvto.ContaID, DBO.fncDiaComCotacao(Mvto.Data) Data, SUM(Mvto.Valor) Valor
    FROM MovimentoConta Mvto
    INNER JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
    INNER JOIN TipoConta TCta 
    ON TCta.TipoContaID = Cnta.TipoContaID AND TCta.Poupanca = 1   -- Somente poupança
    WHERE Mvto.Sistema <> 1                                        -- Não é operação do sistema (abertura de conta)
    AND   Mvto.DoMovimentoContaID IS NULL                          -- Não é fruto de transferência
    AND   Mvto.Valor > 0                                           -- Valor maior que zero
    AND   Mvto.Data >= @DtInicio                                   -- Lançamento com data igual ou maior ao início informado
    GROUP BY DBO.fncDiaComCotacao(Mvto.Data), Mvto.ContaID
    ORDER BY DBO.fncDiaComCotacao(Mvto.Data), Mvto.ContaID DESC;


    DECLARE @ContaID INT;

    DECLARE Contas CURSOR
    FOR SELECT DISTINCT ContaID
        FROM @Auxiliar
        ORDER BY ContaID;

    OPEN Contas;

    FETCH NEXT FROM Contas
    INTO @ContaID;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        INSERT INTO @Destino
        (ContaID, Data, Valor)
        SELECT @ContaId, Dta.Data, COALESCE(Aux.Valor, 0)
        FROM @Datas Dta
        LEFT JOIN @Auxiliar Aux ON Aux.Data = Dta.Data AND Aux.ContaID = @ContaId
        ORDER BY Dta.Data ASC;

        FETCH NEXT FROM Contas
        INTO @ContaID;

    END;

    CLOSE Contas;
    DEALLOCATE Contas;

    -- A ordem das colunas importa na execução desta procedure, pois seu resultado é captado por outra procedure
    SELECT ContaID, Data, Valor
    FROM @Destino
    ORDER BY ContaID, Data;

	-- Apaga tabelas temporárias utilizadas
    --IF OBJECT_ID('TempDB.dbo.#Destino') IS NOT NULL
    --    DROP TABLE #Destino;

END;


GO
/****** Object:  StoredProcedure [dbo].[stpPrevisaoSaldoNegativo]    Script Date: 05/01/2022 12:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/**************************************************
 Procedure stpPrevisaoSaldoNegativo
 Lista datas em que cada conta poderá
 ficar negativa nos próximo N dias

 Elcio Reis - 05/09/2019

 Exemplo de execucao
 EXEC stpPrevisaoSaldoNegativo 2, 15, '2019-09-05';
 **************************************************/

CREATE PROCEDURE [dbo].[stpPrevisaoSaldoNegativo] @UsuarioID INT, @DiasDePrevisao INT, @DataReferencia DATE = NULL
AS
BEGIN

    IF (@DataReferencia IS NULL)
    BEGIN
        SET @DataReferencia = CAST(GETDATE() AS DATE);
    END;

    DECLARE @Datas TABLE (Dia DATE);
    DECLARE @X SMALLINT = 0;

    WHILE (@X < @DiasDePrevisao)
    BEGIN

        INSERT INTO @Datas
        (Dia)
        SELECT DATEADD(DAY, @X, @DataReferencia);

        SET @X = @X + 1;
    END;

    WITH Fase01 AS (SELECT MvCt.ContaID, Cnta.Apelido, Dias.Dia, SUM(COALESCE(MvCt.Credito, 0) - COALESCE(MvCt.Debito, 0)) Saldo
                    FROM @Datas Dias
                         JOIN MovimentoConta MvCt ON CAST(MvCt.Data AS DATE) <= Dias.Dia
                         JOIN Conta Cnta ON Cnta.ContaID = MvCt.ContaID
                         JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
                         JOIN GrupoConta GpCt ON GpCt.GrupoContaID = Tipo.GrupoContaID
                                             AND GpCt.FluxoDisponivel = 1
                    WHERE Cnta.UsuarioID = @UsuarioID
                    GROUP BY MvCt.ContaID, Cnta.Apelido, Dias.Dia)
   SELECT F1.ContaID, F1.Apelido Conta, 
          MIN(F1.Dia) Dia,
          (SELECT Saldo
           FROM Fase01 FX
           WHERE FX.ContaID = F1.ContaID
           AND   FX.Dia = MIN(F1.Dia)) Saldo
   FROM Fase01 F1
   WHERE F1.Saldo < 0
   GROUP BY F1.ContaID, F1.Apelido
   ORDER BY Dia ASC;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpProximoDiaUtil]    Script Date: 05/01/2022 12:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpProximoDiaUtil](@Data DATE)
AS
BEGIN

    DECLARE @Encontrou BIT = 0;

    WHILE @Encontrou = 0
    BEGIN

       SELECT @Encontrou = dbo.fncDiaUtil(@Data);

       IF @Encontrou = 0
            SELECT @Data = DATEADD(DAY, 1, @Data);

    END;

    SELECT @Data AS DiaUtil;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpRestaurarConfiguracaoPrincipal]    Script Date: 05/01/2022 12:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[stpRestaurarConfiguracaoPrincipal](@Reconfigurar bit)
AS

BEGIN

	SET NOCOUNT ON;

	IF (@Reconfigurar = 1)
	BEGIN
		DELETE FROM ConfiguracaoPrincipal;
	END;

	IF NOT EXISTS (SELECT ConfiguracaoID FROM ConfiguracaoPrincipal)
	BEGIN
		INSERT INTO ConfiguracaoPrincipal
		(ConfiguracaoID, panelEsquerdoWidth, Contas_ExibeAtivas, Planejamento_ExibeAtivas)
		VALUES
		(1, 315, 0, 0);
	END;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpResumoInvestimentoLiquido]    Script Date: 05/01/2022 12:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
 Fornece o saldo líquido de um investimento em uma determinada data.
 */

/************************************************************
 EXEC stpResumoInvestimentoLiquido 1019, '2016-12-01';
 ************************************************************/

CREATE PROCEDURE [dbo].[stpResumoInvestimentoLiquido]
    @InvestimentoID INT, 
    @Data DATE,
    @TipoInformacao INT = 0
AS
BEGIN

    SET NOCOUNT ON;  
    
    --IF OBJECT_ID('TempDB.dbo.@Tabela') IS NOT NULL
    --    DROP TABLE @Tabela;

    DECLARE @Tabela TABLE (
        InvestimentoID  INT,
        Data            DATE, 
        UltimaCotacao   DATE,
        QtCotas         NUMERIC(18, 10),
        SdCotas         NUMERIC(18, 10),
        CotacaoCompra   NUMERIC(18, 10),
        CotacaoVenda    NUMERIC(18, 10),
        ValorCusto      NUMERIC(18,  2), -- 4
        ValorBruto      NUMERIC(18,  2), -- 4
        LucroBruto      NUMERIC(18,  2), -- 4		
        PercIOF         NUMERIC(18,  4),
        ValorIOF        NUMERIC(18,  2), -- 4
        PercIR          NUMERIC(18,  4),
        ValorIR         NUMERIC(18,  2), -- 4
        UltimoComeCota  DATE,
        CotacaoComeCota NUMERIC(18, 10),
        PercIOFComeCota NUMERIC(18,  4) DEFAULT 0,
        ValorComeCota   NUMERIC(18,  2), 
        Dias            INT,
        ImpostoDevido   NUMERIC(18,  2),
        SaldoLiquido    NUMERIC(18,  2)
    );

    DECLARE @CotacaoData    NUMERIC(18, 10),
            @UltimaCotacao  DATE;

    SELECT @CotacaoData = VrCotacao, @UltimaCotacao = Ultm.Data
    FROM InvestimentoCotacao Ultm
    WHERE Ultm.Data = (SELECT MAX(Cota.Data) FROM InvestimentoCotacao Cota WHERE Cota.InvestimentoID = @InvestimentoID AND Cota.Data <= @Data)
    AND   Ultm.InvestimentoID = @InvestimentoID;

    -- Insere todos os movimentos de compra de cotas
    INSERT INTO @Tabela
    (InvestimentoID, Data, UltimaCotacao, UltimoComeCota, QtCotas, SdCotas, CotacaoVenda)
    SELECT Inve.InvestimentoID, Mvto.Data, @UltimaCotacao, dbo.fncUltimoComeCota(Inve.InvestimentoID, Mvto.Data, @Data) UltimoComeCota, SUM(Inve.QtCotas), SUM(Inve.QtCotas), @CotacaoData
    FROM MovimentoConta Mvto
         INNER JOIN MovimentoInvestimento Inve ON Inve.MovimentoContaID = Mvto.MovimentoContaID AND Inve.QtCotas > 0
    WHERE Inve.InvestimentoID = @InvestimentoID AND Mvto.Data <= @Data
    GROUP BY Inve.InvestimentoID, Mvto.Data
    ORDER BY Mvto.Data ASC;

    DECLARE @VendaData DATE, @VendaCotas NUMERIC(18, 10);
    DECLARE @auxData DATE, @auxSaldo NUMERIC(18, 10);

    DECLARE Venda CURSOR
    FOR SELECT Mvto.Data, SUM(ABS(Inve.QtCotas))
        FROM MovimentoConta Mvto
             INNER JOIN MovimentoInvestimento Inve ON Inve.MovimentoContaID = Mvto.MovimentoContaID AND Inve.QtCotas < 0
        WHERE Inve.InvestimentoID = @InvestimentoID AND Mvto.Data <= @Data
        GROUP BY Mvto.Data
        ORDER BY Mvto.Data ASC;

    OPEN Venda;

    FETCH NEXT FROM Venda
    INTO @VendaData, @VendaCotas;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        WHILE (@VendaCotas > 0)
        BEGIN
            -- Procura a data mais antiga para baixar a venda 
            -- (as cotas mais antigas são vendidas primeiro)
            SELECT @auxData = MIN(Data) FROM @Tabela WHERE SdCotas > 0;
            SELECT @auxSaldo = SdCotas FROM @Tabela WHERE Data = @auxData;

            IF (@auxSaldo >= @VendaCotas)
            BEGIN
                UPDATE @Tabela
                SET SdCotas = SdCotas - @VendaCotas
                WHERE Data = @auxData;

                SET @VendaCotas = 0;
            END
            ELSE
            BEGIN
                UPDATE @Tabela
                SET SdCotas = 0
                WHERE Data = @auxData;

                SET @VendaCotas = @VendaCotas - @auxSaldo;
            END;
                       
        END;

        FETCH NEXT FROM Venda
        INTO @VendaData, @VendaCotas;

    END;

    CLOSE Venda;
    DEALLOCATE Venda;

    UPDATE @Tabela
    SET CotacaoCompra = Ultm.VrCotacao,
        ValorCusto = SdCotas * Ultm.VrCotacao,
        ValorBruto = SdCotas * CotacaoVenda,
        LucroBruto = Round(SdCotas * CotacaoVenda, 2) - round(SdCotas * Ultm.VrCotacao, 2),
        Dias = DATEDIFF(DAY, Tabl.Data, @UltimaCotacao),
        CotacaoComeCota = DBO.fncCotacaoComeCota(Tabl.InvestimentoID, UltimoComeCota)
    FROM @Tabela Tabl
    INNER JOIN InvestimentoCotacao Ultm 
    ON  Ultm.Data = (SELECT MAX(Cota.Data) FROM InvestimentoCotacao Cota WHERE Cota.InvestimentoID = @InvestimentoID AND Cota.Data <= Tabl.Data)
    AND Ultm.InvestimentoID = @InvestimentoID
    WHERE Tabl.SdCotas > 0;

    -- Desconta o IOF
    UPDATE @Tabela
    SET PercIOF = Faix.Porcentagem,
        ValorIOF = CASE WHEN Tabl.LucroBruto > 0 THEN Round(Tabl.LucroBruto * Faix.Porcentagem / 100, 2, 1)
                        ELSE 0
                   END
    FROM @Tabela Tabl
    INNER JOIN InvestimentoDespesa Desp ON Desp.InvestimentoID = Tabl.InvestimentoID AND Desp.IOF = 1
    INNER JOIN Imposto Impt ON Impt.ImpostoID = Desp.ImpostoID AND Impt.Ativo = 1
    INNER JOIN ImpostoFaixa Faix ON Faix.ImpostoID = Impt.ImpostoID AND Tabl.Dias BETWEEN Faix.DiasDe AND Faix.DiasAte
    WHERE Tabl.SdCotas > 0;

    -- Desconta o IF
    UPDATE @Tabela
    SET PercIR = Faix.Porcentagem,
        ValorIR = CASE WHEN Tabl.LucroBruto > 0 THEN Round(((Tabl.LucroBruto - COALESCE(Tabl.ValorIOF, 0)) * Faix.Porcentagem) / 100, 2, 1)
                       ELSE 0
                  END
    FROM @Tabela Tabl
    INNER JOIN InvestimentoDespesa Desp ON Desp.InvestimentoID = Tabl.InvestimentoID AND Desp.IR = 1
    INNER JOIN Imposto Impt ON Impt.ImpostoID = Desp.ImpostoID AND Impt.Ativo = 1
    INNER JOIN ImpostoFaixa Faix ON Faix.ImpostoID = Impt.ImpostoID AND Tabl.Dias BETWEEN Faix.DiasDe AND Faix.DiasAte
    WHERE Tabl.SdCotas > 0;
    
    -- Encontra a porcentagem de IOF no dia do Come Cotas
    UPDATE @Tabela
    SET PercIOFComeCota = Faix.Porcentagem
    FROM @Tabela Tabl
    INNER JOIN InvestimentoDespesa Desp ON Desp.InvestimentoID = Tabl.InvestimentoID AND Desp.IOF = 1
    INNER JOIN Imposto Impt ON Impt.ImpostoID = Desp.ImpostoID AND Impt.Ativo = 1
    INNER JOIN ImpostoFaixa Faix ON Faix.ImpostoID = Impt.ImpostoID AND DATEDIFF(DAY, Tabl.Data, Tabl.UltimocomeCota) BETWEEN Faix.DiasDe AND Faix.DiasAte
    WHERE Tabl.SdCotas > 0
    AND   Tabl.UltimoComeCota IS NOT NULL;


    -- Calcula o Come Cota
    UPDATE @Tabela
    SET ValorComeCota = (((SdCotas * CotacaoComeCota) - (SdCotas * CotacaoCompra)) -                                        ---- LucroBruto
                         ((SdCotas * CotacaoComeCota) - (SdCotas * CotacaoCompra)) * (PercIOFComeCota / 100)) *             ---- IOFNoComeCota
                        0.15;                                                                                               ---- Alíquota fixa do Come Cotas

    -- Desconta o come cota do IR devido
	UPDATE @Tabela
	SET ValorIR = COALESCE(ValorIR, 0) - COALESCE(ValorComeCota, 0);

    UPDATE @Tabela
    SET ImpostoDevido = COALESCE(ValorIOF, 0) + COALESCE(ValorIR, 0);

    UPDATE @Tabela
    SET SaldoLiquido = (SdCotas * CotacaoVenda) - ImpostoDevido;

    IF (@TipoInformacao = 0)
    BEGIN
        -- Toda informação disponível

        SELECT CAST(0 AS BIT) Total, InvestimentoID, Data DCompra, SdCotas, CotacaoCompra, ValorCusto, ValorBruto, UltimaCotacao DUltima, Dias, CotacaoVenda, 
               LucroBruto, PercIOF, ValorIOF, PercIR, ValorIR, UltimoComeCota, ValorComeCota, 
               ImpostoDevido, LucroBruto - ImpostoDevido AS LucroLiquido, SaldoLiquido, 
               (LucroBruto - ImpostoDevido) / ValorCusto * 100 AS PercLucroLiquido
        FROM @Tabela
        WHERE SdCotas > 0

        UNION ALL 

        SELECT CAST(1 AS BIT) Total, NULL, NULL, SUM(SdCotas) SdCotas, NULL, SUM(ValorCusto) ValorCusto, SUM(ValorBruto) ValorBruto, NULL, NULL, 
               NULL, SUM(LucroBruto) LucroBruto, NULL, SUM(ValorIOF) ValorIOF, NULL, SUM(ValorIR) ValorIR, NULL, SUM(ValorComeCota) ValorComeCota,
               SUM(ImpostoDevido) ImpostoDevido, SUM(LucroBruto - ImpostoDevido) AS LucroLiquido, SUM(SaldoLiquido) AS SaldoLiquido, 
               --SUM((LucroBruto - ImpostoDevido) / ValorCusto * 100) AS PercLucroLiquido
               (SUM(LucroBruto) - Sum(ImpostoDevido)) / SUM(ValorCusto) * 100 AS PercLucroLiquido
        FROM @Tabela
        WHERE SdCotas > 0

        ORDER BY Total ASC, Data ASC;

    END;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpSelecaoInvestimentosLiquidosAcumulados]    Script Date: 05/01/2022 12:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/***********************************************************************
 EXEC stpSelecaoInvestimentosLiquidosAcumulados 'M', '0;1;4;1014;1019';
 ***********************************************************************/

CREATE PROCEDURE [dbo].[stpSelecaoInvestimentosLiquidosAcumulados]
    @Periodo CHAR(1) = 'D',
    @Investimentos VARCHAR(MAX) = '',
    @DtInicio DATE = NULL,
	@SomentePeriodo BIT = 0
AS
BEGIN

    SET NOCOUNT ON;

    -- Variáveis auxiliares
    DECLARE @InvestimentoID  INT,
	        @Contador        INT,
			@IncluirPoupanca INT = -1,
            @Comando         NVARCHAR(MAX);

    -- Declara uma tabela para os investimentos selecionados
	DECLARE @Selecionados TABLE (
		InvestimentoID INT
    );

    -- Se a relação de investimento foi passada, garante que a lista termine por ponto e vírgula
    -- Procura a data mínima igual para toda a lista de investimentos
    IF (@Investimentos IS NOT NULL) 
    BEGIN

        -- Garante que a lista de investimentos termina por ponto e vírgula
        IF RIGHT(@Investimentos,1) <> ';'
            SET @Investimentos = @Investimentos + ';';

        DECLARE @CodigosInv VARCHAR(30);

        SET @CodigosInv = @Investimentos;

        DECLARE @DtMinima DATE, 
                @DtAux    DATE;

        -- Data utilizada na tabela de configuração
        SELECT @DtMinima = DtInicioUtilizacao
        FROM MoneyPro 
        WHERE MoneyProID = (SELECT MAX(MoneyProID) FROM MoneyPro);

		-- A data mínima será a maior entre a data de início da utilização e a mais nova aplicação
        
        SET @Contador = 0;
         
        WHILE (@CodigosInv > '')
        BEGIN

			SET @InvestimentoID = CAST(LEFT(@CodigosInv, CHARINDEX(';', @CodigosInv) - 1) AS INT);
			
			IF (@InvestimentoID = 0)
				SET @IncluirPoupanca = 0; 

			-- Coloca o código do investimento em @Selecionados
			INSERT INTO @Selecionados
			(InvestimentoID)
			VALUES
			(@InvestimentoID);


            SELECT @DtAux = MIN(Data)
            FROM InvestimentoCotacao Invt
            WHERE Invt.InvestimentoID = @InvestimentoID

            IF (@DtAux > @DtMinima)
            BEGIN
                SET @DtMinima = @DtAux;
            END;

            -- Descarta o primeiro código da lista.
            SET @CodigosInv = RIGHT(@CodigosInv, LEN(@CodigosInv) - CHARINDEX(';', @CodigosInv));

            SET @Contador = @Contador + 1;

        END;

    END;

    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;

	CREATE TABLE #Tabela (
        Registro        INT,
		Data            DATE,
		ContaID         INT,
		Valor           NUMERIC(19,2),
        InvestimentoID  INT
	);


	DECLARE @Datas TABLE (
		Data     DATE
    );

    INSERT INTO @Datas
	EXEC stpDataParaPesquisa @Periodo, @DtInicio;

	-- Insere os movimentos de investimento.
	INSERT INTO #Tabela
	(Registro, Data, ContaID, Valor, InvestimentoID)
	SELECT ROW_NUMBER() OVER(ORDER BY Data.Data ASC) AS Registro,
           Data.Data, Cnta.ContaID, 
	       dbo.fncLucroContaInvestimentoData(Cnta.ContaID, Data.Data) - dbo.fncContaInvestimentoDataImpostoPago(Cnta.ContaID, Data.Data) AS Valor,
           MvIv.InvestimentoID AS Investimento
    FROM Conta Cnta	    
         INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
		 INNER JOIN @Datas Data ON 1 = 1
		 INNER JOIN MovimentoConta MvCt ON MvCt.ContaID = Cnta.ContaID AND Mvct.Data <= Data.Data
         INNER JOIN MovimentoInvestimento MvIv ON MvIv.MovimentoContaID = MvCt.MovimentoContaID AND MvIv.VrLiquido <> 0
		 INNER JOIN @Selecionados Selc ON Selc.InvestimentoID = MvIv.InvestimentoID
    WHERE Tipo.Investimento = 1	
	GROUP BY Data.Data, Cnta.ContaID, MvIv.InvestimentoID
	ORDER BY Data.Data ASC;

    -- Atualiza os valores pelo cálculo dos investimentos descontando os impostos
    DECLARE @regMinimo INT, @regMaximo INT;
    DECLARE @Data DATE, @ValorSTP NUMERIC(18,2);

    SELECT @regMinimo = MIN(Registro) FROM #Tabela;
    SELECT @regMaximo = MAX(Registro) FROM #Tabela;

    DECLARE @Valor TABLE (
        Valor    NUMERIC(18,2)
    );

    WHILE (@regMinimo <= @regMaximo)
    BEGIN

        SELECT @InvestimentoID = InvestimentoID,
               @Data = Data
        FROM #Tabela
        WHERE Registro = @regMinimo;

        INSERT INTO @Valor
        EXEC stpDetalhesInvestimento @InvestimentoID, @Data, 1, 0;

        SELECT @ValorSTP = Valor FROM @Valor;

        UPDATE #Tabela
        SET Valor = @ValorSTP
        WHERE Registro = @regMinimo;

        DELETE FROM @Valor;

        SELECT @regMinimo = @regMinimo + 1;
    END;

	-- Insere os movimentos de poupança
	INSERT INTO #Tabela
	(Registro, Data, ContaID, Valor, InvestimentoID)
	SELECT 0 AS Registro, Data.Data, Mvto.ContaID, SUM(Mvto.Valor) AS Valor, Mvto.ContaID * -1 AS Investimento
	FROM @Datas Data
    INNER JOIN MovimentoConta Mvto ON Mvto.Data <= Data.Data
    INNER JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
    INNER JOIN TipoConta TCta ON TCta.TipoContaID = Cnta.TipoContaID
	WHERE Mvto.Sistema <> 1                      -- Não é operação do sistema (abertura de conta)
    AND Mvto.DoMovimentoContaID IS NULL          -- Não é fruto de transferência
    AND Mvto.Valor > 0                           -- Valor maior que zero
    AND TCta.Poupanca = 1                        -- Tipo de conta é poupança  
	AND @IncluirPoupanca = 0                     -- Se houver o parâmetro ZERO na lista de investimentos inclui as cadernetas de poupança
    GROUP BY Mvto.ContaID, Data.Data;

	IF (@SomentePeriodo = 1)
	BEGIN

		DECLARE @auxInvestimentoID INT,
		        @auxData           DATE,
				@auxValor          NUMERIC(19,2);

		DECLARE Redutor CURSOR
		FOR SELECT InvestimentoID, Min(Data) Data
	        FROM #Tabela
            GROUP BY InvestimentoID;

        OPEN Redutor;

        FETCH NEXT FROM Redutor
        INTO @auxInvestimentoID, @auxData;

		WHILE @@FETCH_STATUS = 0
		BEGIN

			SELECT @auxValor = COALESCE(Valor, 0)
			FROM #Tabela
			WHERE InvestimentoID = @auxInvestimentoID
			AND   Data = @auxData;

			UPDATE #Tabela
			SET Valor = Valor - @auxValor
			WHERE InvestimentoID = @auxInvestimentoID
			AND   Data >= @auxData;

	        FETCH NEXT FROM Redutor
            INTO @auxInvestimentoID, @auxData;

		END;

		CLOSE Redutor;
		DEALLOCATE Redutor;

	END;
 
    DECLARE @ColOrigem VARCHAR(MAX) = '';
    DECLARE @ColDestino VARCHAR(MAX) = '';

    DECLARE @ContaID INT;
    DECLARE @Apelido VARCHAR(40);
    DECLARE @Ordem INT;

    IF (@Periodo = 'M')
    BEGIN
        UPDATE #Tabela
        SET Data = dbo.fncMeioDoMes(Data);
    END;

    INSERT INTO #Tabela
	(Registro, Data, ContaID, Valor, InvestimentoID)
    SELECT 0 AS Registro, Data, 0 AS ContaID, SUM(Valor) AS Valor, 0 AS InvestimentoID
    FROM #Tabela
    WHERE Valor IS NOT NULL
    GROUP BY Data;

    DECLARE SAIDA CURSOR
    FOR SELECT DISTINCT #Tabela.InvestimentoID, COALESCE(Inv.Apelido, Cta.Apelido, 'Total') AS Apelido
        FROM #Tabela
		LEFT JOIN Investimento Inv ON Inv.InvestimentoID = #Tabela.InvestimentoID
		LEFT JOIN Conta Cta ON Cta.ContaID = #Tabela.ContaID
		WHERE Valor <> 0
        ORDER BY Apelido ASC;

    OPEN SAIDA;

    FETCH NEXT FROM SAIDA 
    INTO @InvestimentoID, @Apelido;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        SET @ColOrigem = @ColOrigem + '[' + CAST(@InvestimentoID AS VARCHAR(6)) + '] AS ''' + @Apelido + '''';
        SET @ColDestino = @ColDestino + '[' + CAST(@InvestimentoID AS VARCHAR(6)) + ']';

        FETCH NEXT FROM SAIDA 
        INTO @InvestimentoID, @Apelido;

        IF @@FETCH_STATUS = 0
        BEGIN
            SET @ColOrigem = @ColOrigem + ', ';
            SET @ColDestino = @ColDestino + ', ';
        END;

    END;

    CLOSE SAIDA;
    DEALLOCATE SAIDA;

    DECLARE @Pivot VARCHAR(MAX);

    SET @Pivot = 'SELECT Data, ' + @ColOrigem + ' FROM (SELECT Data, InvestimentoID, Valor FROM #Tabela WHERE Valor <> 0) ORIGEM PIVOT (' +
                 'SUM(Valor) FOR InvestimentoID IN (' + @ColDestino + ')) FINAL ORDER BY Data ASC;';

    EXEC (@Pivot);

    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpSelecaoInvestimentosSaldo]    Script Date: 05/01/2022 12:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/***********************************************************************
 EXEC stpSelecaoInvestimentosSaldo 'M', '0;1;4;1014;1019';
 ***********************************************************************/

CREATE PROCEDURE [dbo].[stpSelecaoInvestimentosSaldo]
    @Periodo CHAR(1) = 'M',
    @Investimentos VARCHAR(MAX) = '',
    @DtInicio DATE = NULL
AS
BEGIN

    SET NOCOUNT ON;

    -- Variáveis auxiliares
    DECLARE @InvestimentoID  INT,
	        @Contador        INT,
			@IncluirPoupanca INT = -1,
            @Comando         NVARCHAR(MAX);

    -- Declara uma tabela para os investimentos selecionados
	DECLARE @Selecionados TABLE (
		InvestimentoID INT
    );

    -- Se a relação de investimento foi passada, garante que a lista termine por ponto e vírgula
    -- Procura a data mínima igual para toda a lista de investimentos
    IF (@Investimentos IS NOT NULL) 
    BEGIN

        -- Garante que a lista de investimentos termina por ponto e vírgula
        IF RIGHT(@Investimentos,1) <> ';'
            SET @Investimentos = @Investimentos + ';';

        DECLARE @CodigosInv VARCHAR(30);

        SET @CodigosInv = @Investimentos;

        DECLARE @DtMinima DATE, 
                @DtAux    DATE;

        -- Data utilizada na tabela de configuração
        SELECT @DtMinima = DtInicioUtilizacao
        FROM MoneyPro 
        WHERE MoneyProID = (SELECT MAX(MoneyProID) FROM MoneyPro);

		-- A data mínima será a maior entre a data de início da utilização e a mais nova aplicação
        
        SET @Contador = 0;
         
        WHILE (@CodigosInv > '')
        BEGIN

			SET @InvestimentoID = CAST(LEFT(@CodigosInv, CHARINDEX(';', @CodigosInv) - 1) AS INT);
			
			IF (@InvestimentoID = 0)
				SET @IncluirPoupanca = 0; 

			-- Coloca o código do investimento em @Selecionados
			INSERT INTO @Selecionados
			(InvestimentoID)
			VALUES
			(@InvestimentoID);


            SELECT @DtAux = MIN(Data)
            FROM InvestimentoCotacao Invt
            WHERE Invt.InvestimentoID = @InvestimentoID

            IF (@DtAux > @DtMinima)
            BEGIN
                SET @DtMinima = @DtAux;
            END;

            -- Descarta o primeiro código da lista.
            SET @CodigosInv = RIGHT(@CodigosInv, LEN(@CodigosInv) - CHARINDEX(';', @CodigosInv));

            SET @Contador = @Contador + 1;

        END;

    END;

    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;

	CREATE TABLE #Tabela (
        Registro        INT,
		Data            DATE,
		ContaID         INT,
		Valor           NUMERIC(19,2),
        InvestimentoID  INT,
		Percentual      NUMERIC(19,4)
	);

	DECLARE @Datas TABLE (
		Data     DATE
    );

    INSERT INTO @Datas
	EXEC stpDataParaPesquisa @Periodo, @DtInicio;

	-- Insere os movimentos de investimento.
	INSERT INTO #Tabela
	(Registro, Data, ContaID, Valor, InvestimentoID)
	SELECT ROW_NUMBER() OVER(ORDER BY Data.Data ASC) AS Registro,
           Data.Data, Cnta.ContaID, 
           dbo.fncSaldoInvestimentoLiquido(MvIv.InvestimentoID, Data.Data, 1) AS Valor,
           --dbo.fncSaldoInvestimentoData(MvIv.InvestimentoID, Data.Data) AS Valor, 
           MvIv.InvestimentoID AS Investimento
    FROM Conta Cnta	    
         INNER JOIN TipoConta Tipo ON Tipo.TipoContaID = Cnta.TipoContaID
		 INNER JOIN @Datas Data ON 1 = 1
		 INNER JOIN MovimentoConta MvCt ON MvCt.ContaID = Cnta.ContaID AND Mvct.Data <= Data.Data
         INNER JOIN MovimentoInvestimento MvIv ON MvIv.MovimentoContaID = MvCt.MovimentoContaID AND MvIv.VrLiquido <> 0
		 INNER JOIN @Selecionados Selc ON Selc.InvestimentoID = MvIv.InvestimentoID
    WHERE Tipo.Investimento = 1	
	GROUP BY Data.Data, Cnta.ContaID, MvIv.InvestimentoID
	ORDER BY Data.Data ASC;

    -- Atualiza os valores pelo cálculo dos investimentos descontando os impostos
    DECLARE @regMinimo INT, @regMaximo INT;
    DECLARE @Data DATE, @ValorSTP NUMERIC(18,2);

    SELECT @regMinimo = MIN(Registro) FROM #Tabela;
    SELECT @regMaximo = MAX(Registro) FROM #Tabela;

    DECLARE @Valor TABLE (
        Valor    NUMERIC(18,2)
    );

	-- Insere os movimentos de poupança
	INSERT INTO #Tabela
	(Registro, Data, ContaID, Valor, InvestimentoID)
	SELECT 0 AS Registro, Data.Data, Mvto.ContaID, SUM(Mvto.Valor) AS Valor, Mvto.ContaID * -1 AS Investimento
	FROM @Datas Data
    INNER JOIN MovimentoConta Mvto ON Mvto.Data <= Data.Data
    INNER JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
    INNER JOIN TipoConta TCta ON TCta.TipoContaID = Cnta.TipoContaID
	WHERE TCta.Poupanca = 1                      -- Tipo de conta é poupança  
	AND @IncluirPoupanca = 0                     -- Se houver o parâmetro ZERO na lista de investimentos inclui as cadernetas de poupança
    GROUP BY Mvto.ContaID, Data.Data;


    INSERT INTO #Tabela
	(Registro, Data, ContaID, Valor, InvestimentoID)
    SELECT 0 AS Registro, Data, 0 AS ContaID, SUM(Valor) AS Valor, 0 AS InvestimentoID
    FROM #Tabela
    WHERE Valor IS NOT NULL
    GROUP BY Data;
 
    DECLARE @ColOrigem VARCHAR(MAX) = '';
    DECLARE @ColDestino VARCHAR(MAX) = '';

    DECLARE @ContaID INT;
    DECLARE @Apelido VARCHAR(40);
    DECLARE @Ordem INT;

    --IF (@Periodo = 'M')
    --BEGIN
    --    UPDATE #Tabela
    --    SET Data = dbo.fncMeioDoMes(Data);
    --END;

    DECLARE SAIDA CURSOR
    FOR SELECT DISTINCT #Tabela.InvestimentoID, COALESCE(Inv.Apelido, Cta.Apelido, 'Total') AS Apelido
        FROM #Tabela
		LEFT JOIN Investimento Inv ON Inv.InvestimentoID = #Tabela.InvestimentoID
		LEFT JOIN Conta Cta ON Cta.ContaID = #Tabela.ContaID
		WHERE Valor <> 0
        ORDER BY Apelido ASC;

    OPEN SAIDA;

    FETCH NEXT FROM SAIDA 
    INTO @InvestimentoID, @Apelido;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        SET @ColOrigem = @ColOrigem + '[' + CAST(@InvestimentoID AS VARCHAR(6)) + '] AS ''' + @Apelido + '''';
        SET @ColDestino = @ColDestino + '[' + CAST(@InvestimentoID AS VARCHAR(6)) + ']';

        FETCH NEXT FROM SAIDA 
        INTO @InvestimentoID, @Apelido;

        IF @@FETCH_STATUS = 0
        BEGIN
            SET @ColOrigem = @ColOrigem + ', ';
            SET @ColDestino = @ColDestino + ', ';
        END;

    END;

    CLOSE SAIDA;
    DEALLOCATE SAIDA;

    DECLARE @Pivot VARCHAR(MAX);

    SET @Pivot = 'SELECT Data, ' + @ColOrigem + ' FROM (SELECT Data, InvestimentoID, Valor FROM #Tabela WHERE Valor <> 0) ORIGEM PIVOT (' +
                 'SUM(Valor) FOR InvestimentoID IN (' + @ColDestino + ')) FINAL ORDER BY Data ASC;';

    EXEC (@Pivot);

    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpTruncarLog]    Script Date: 05/01/2022 12:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpTruncarLog]

AS

BEGIN

    -- Obs.: Só é possível truncar o log se o banco estiver no modo Simple
    ALTER DATABASE MoneyPro SET RECOVERY SIMPLE WITH NO_WAIT;

    -- Limpa o arquivo de log.  
    DBCC SHRINKFILE (MoneyPro_log, 1); -- Atenção: Colocar o nome do arquivo de log e tamanho que se quer reduzir 

    -- Volta o Banco para o modo FULL se for o caso
    ALTER DATABASE MoneyPro SET RECOVERY FULL WITH NO_WAIT;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpUltimoDiaUtil]    Script Date: 05/01/2022 12:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpUltimoDiaUtil](@Data DATE)
AS
BEGIN

    DECLARE @Encontrou BIT = 0;

    WHILE @Encontrou = 0
    BEGIN

       SELECT @Encontrou = dbo.fncDiaUtil(@Data);

       IF @Encontrou = 0
            SELECT @Data = DATEADD(DAY, -1, @Data);

    END;

    SELECT @Data AS DiaUtil;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpV2InvestimentoLiquido]    Script Date: 05/01/2022 12:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
 Fornece o saldo líquido de um investimento em uma determinada data.
 */

/************************************************************
 EXEC STPV2INVESTIMENTOLIQUIDO 1014, '2016-11-14';
 ************************************************************/

CREATE PROCEDURE [dbo].[stpV2InvestimentoLiquido]
    @InvestimentoID INT, 
    @Data DATE,
    @TipoInformacao INT = 0
AS
BEGIN

    SET NOCOUNT ON;  
    
    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;

    CREATE TABLE #Tabela (
        InvestimentoID  INT,
        Data            DATE, 
        UltimoComeCota  DATE,
        QtCotas         NUMERIC(18, 10),
        SdCotas         NUMERIC(18, 10),
        CotacaoCompra   NUMERIC(18, 10),
        CotacaoVenda    NUMERIC(18, 10),
        CotacaoComeCota NUMERIC(18, 10),
        ValorCusto      NUMERIC(18,  4),  -- 2
        ValorBruto      NUMERIC(18,  4),  -- 2
        LucroBruto      NUMERIC(18,  4),  -- 2
        PercIOF         NUMERIC(18,  4),
        ValorIOF        NUMERIC(18,  2),  -- 2
        PercIR          NUMERIC(18,  4),
        ValorIR         NUMERIC(18,  2),  -- 2
        ValorComeCota   NUMERIC(18,  2),  -- 2
        Dias            INT,
        ImpostoDevido   NUMERIC(18,  2)   -- 2
    );

    DECLARE @CotacaoData NUMERIC(18, 10);

    SELECT @CotacaoData = VrCotacao
    FROM InvestimentoCotacao Ultm
    WHERE Ultm.Data = (SELECT MAX(Cota.Data) FROM InvestimentoCotacao Cota WHERE Cota.InvestimentoID = @InvestimentoID AND Cota.Data <= @Data)
    AND   Ultm.InvestimentoID = @InvestimentoID;

    -- Insere todos os movimentos de compra de cotas
    INSERT INTO #Tabela
    (InvestimentoID, Data, UltimoComeCota, QtCotas, SdCotas, CotacaoVenda)
    SELECT Inve.InvestimentoID, Mvto.Data, dbo.fncUltimoComeCota(Inve.InvestimentoID, Mvto.Data, @Data) UltimoComeCota, SUM(Inve.QtCotas), SUM(Inve.QtCotas), @CotacaoData
    FROM MovimentoConta Mvto
         INNER JOIN MovimentoInvestimento Inve ON Inve.MovimentoContaID = Mvto.MovimentoContaID AND Inve.QtCotas > 0
    WHERE Inve.InvestimentoID = @InvestimentoID AND Mvto.Data <= @Data
    GROUP BY Inve.InvestimentoID, Mvto.Data
    ORDER BY Mvto.Data ASC;

    DECLARE @VendaData DATE, @VendaCotas NUMERIC(18, 10);
    DECLARE @auxData DATE, @auxSaldo NUMERIC(18, 10);

    DECLARE Venda CURSOR
    FOR SELECT Mvto.Data, SUM(ABS(Inve.QtCotas))
        FROM MovimentoConta Mvto
             INNER JOIN MovimentoInvestimento Inve ON Inve.MovimentoContaID = Mvto.MovimentoContaID AND Inve.QtCotas < 0
        WHERE Inve.InvestimentoID = @InvestimentoID AND Mvto.Data <= @Data
        GROUP BY Mvto.Data
        ORDER BY Mvto.Data ASC;

    OPEN Venda;

    FETCH NEXT FROM Venda
    INTO @VendaData, @VendaCotas;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        WHILE (@VendaCotas > 0)
        BEGIN
            -- Procura a data mais antiga para baixar a venda 
            -- (as cotas mais antigas são vendidas primeiro)
            SELECT @auxData = MIN(Data) FROM #Tabela WHERE SdCotas > 0;
            SELECT @auxSaldo = SdCotas FROM #Tabela WHERE Data = @auxData;

            IF (@auxSaldo >= @VendaCotas)
            BEGIN
                UPDATE #Tabela
                SET SdCotas = SdCotas - @VendaCotas
                WHERE Data = @auxData;

                SET @VendaCotas = 0;
            END
            ELSE
            BEGIN
                UPDATE #Tabela
                SET SdCotas = 0
                WHERE Data = @auxData;

                SET @VendaCotas = @VendaCotas - @auxSaldo;
            END;
            
            
        END;

        FETCH NEXT FROM Venda
        INTO @VendaData, @VendaCotas;

    END;

    CLOSE Venda;
    DEALLOCATE Venda;

    UPDATE #Tabela
    SET CotacaoCompra = Ultm.VrCotacao,
        ValorCusto = SdCotas * Ultm.VrCotacao,
        ValorBruto = SdCotas * CotacaoVenda,
        LucroBruto = (SdCotas * CotacaoVenda) - (SdCotas * Ultm.VrCotacao),
        Dias = DATEDIFF(DAY, Tabl.Data, @Data),
        CotacaoComeCota = DBO.fncCotacaoComeCota(Tabl.InvestimentoID, UltimoComeCota)
    FROM #Tabela Tabl
    INNER JOIN InvestimentoCotacao Ultm 
    ON  Ultm.Data = (SELECT MAX(Cota.Data) FROM InvestimentoCotacao Cota WHERE Cota.InvestimentoID = @InvestimentoID AND Cota.Data <= Tabl.Data)
    AND Ultm.InvestimentoID = @InvestimentoID
    WHERE Tabl.SdCotas > 0;

    -- Desconta o IOF
    UPDATE #Tabela
    SET PercIOF = Faix.Porcentagem,
        ValorIOF = CEILING(Tabl.LucroBruto * Faix.Porcentagem) / 100   ---- Arredonda pra cima
    FROM #Tabela Tabl
    INNER JOIN InvestimentoDespesa Desp ON Desp.InvestimentoID = Tabl.InvestimentoID AND Desp.IOF = 1
    INNER JOIN Imposto Impt ON Impt.ImpostoID = Desp.ImpostoID AND Impt.Ativo = 1
    INNER JOIN ImpostoFaixa Faix ON Faix.ImpostoID = Impt.ImpostoID AND Tabl.Dias BETWEEN Faix.DiasDe AND Faix.DiasAte
    WHERE Tabl.SdCotas > 0;

    -- Desconta o IF
    UPDATE #Tabela
    SET PercIR = Faix.Porcentagem,
        ValorIR = CEILING((Tabl.LucroBruto - COALESCE(Tabl.ValorIOF, 0)) * Faix.Porcentagem) / 100  ---- Arredonda pra cima
    FROM #Tabela Tabl
    INNER JOIN InvestimentoDespesa Desp ON Desp.InvestimentoID = Tabl.InvestimentoID AND Desp.IR = 1
    INNER JOIN Imposto Impt ON Impt.ImpostoID = Desp.ImpostoID AND Impt.Ativo = 1
    INNER JOIN ImpostoFaixa Faix ON Faix.ImpostoID = Impt.ImpostoID AND Tabl.Dias BETWEEN Faix.DiasDe AND Faix.DiasAte
    WHERE Tabl.SdCotas > 0;
    
    -- Calcula o Come Cota
    UPDATE #Tabela
    SET ValorComeCota = FLOOR(((SdCotas * CotacaoComeCota) - (SdCotas * CotacaoCompra)) * 0.15 * 100) / 100;

    UPDATE #Tabela
    SET ImpostoDevido = COALESCE(ValorIOF, 0) + COALESCE(ValorIR, 0) - COALESCE(ValorComeCota, 0);


    IF (@TipoInformacao = 0)
    BEGIN
        -- Toda informação disponível
        SELECT Data, Dias, QtCotas, SdCotas, CotacaoCompra, CotacaoVenda, ValorCusto, ValorBruto, 
               LucroBruto, PercIOF, ValorIOF, PercIR, ValorIR,
               UltimoComeCota, CotacaoComeCota, ValorComeCota, ImpostoDevido
        FROM #Tabela
        WHERE SdCotas > 0
        ORDER BY Data ASC;

    END
    ELSE IF (@TipoInformacao = 1)
    BEGIN
        -- Saldo líquido da aplicação
        SELECT SUM(ValorBruto) - SUM(ImpostoDevido) AS SaldoLiquido
        FROM #Tabela

    END;


    IF OBJECT_ID('TempDB.dbo.#Tabela') IS NOT NULL
        DROP TABLE #Tabela;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpVariacaoDezDiasInvestimentos]    Script Date: 05/01/2022 12:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/******************************************************
 Procedure stpOrcamentoDiario
 Elcio Reis - 27/08/2019
 Cria uma "planilha" com a variação diária dos 
 investimentos no mês
 EXEC stpVariacaoDezDiasInvestimentos 2;
 ******************************************************/

CREATE PROCEDURE [dbo].[stpVariacaoDezDiasInvestimentos] (@UsuarioID INT, @DataReferencia DATE = NULL)
AS
    DECLARE @Indice TINYINT = 10;
    DECLARE @ListaDatas VARCHAR(110) = '';
BEGIN
   
    IF (@DataReferencia IS NULL)
    BEGIN
        SELECT @DataReferencia = dbo.fncUltimaAtualizacaoInvestimentos();
    END;

    -- Cria uma tabela com todos os dias do mês em referência
    DECLARE @Dias TABLE (Indice SMALLINT, Dia DATE);

    WHILE (@Indice > 0)
    BEGIN

        -- Dia 1 = Domingo
        -- Dia 7 = Sábado
        --IF (DATEPART(DW, @DataReferencia) BETWEEN 2 AND 6)
        IF (dbo.fncDiaUtil(@DataReferencia) = 1)
        BEGIN
            INSERT INTO @Dias
            (Indice, Dia)
            VALUES
            (@Indice, @DataReferencia);

            SET @Indice = @Indice - 1;

            SET @ListaDatas = CONVERT(VARCHAR(10), @DataReferencia, 112) + ';' + @ListaDatas;
        END;

        SET @DataReferencia = DATEADD(DAY, -1, @DataReferencia);
    END; -- WHILE

    SET @ListaDatas = SUBSTRING(@ListaDatas, 1, 89);

    -- Cria tabela virtual para receber o conteúdo do select principal
    DECLARE @Tempor TABLE (
        Ordem            SMALLINT,
        TipoLinha        SMALLINT,
        InvestimentoID   INT,
        ContaID          INT,
        Tipo             VARCHAR(50),
        Apelido          VARCHAR(50),
        RiscoID          INT,
        Risco            VARCHAR(20),
        Dia01            DECIMAL(10,2),
        Perc0102         DECIMAL(10,6),
        Dia02            DECIMAL(10,2),
        Perc0203         DECIMAL(10,6),
        Dia03            DECIMAL(10,2),
        Perc0304         DECIMAL(10,6),
        Dia04            DECIMAL(10,2),
        Perc0405         DECIMAL(10,6),
        Dia05            DECIMAL(10,2),
        Perc0506         DECIMAL(10,6),
        Dia06            DECIMAL(10,2),
        Perc0607         DECIMAL(10,6),
        Dia07            DECIMAL(10,2),
        Perc0708         DECIMAL(10,6),
        Dia08            DECIMAL(10,2),
        Perc0809         DECIMAL(10,6),
        Dia09            DECIMAL(10,2),
        Perc0910         DECIMAL(10,6),
        Dia10            DECIMAL(10,2),  
        ListaDatasISO    VARCHAR(90)
    );

    -- O campo TipoLinha recebe o seguinte conteúdo:
    -- 0 - Linha com o saldo do dia anterior
    -- 1 - Total dos grupos entrada e saída
    -- 2 - Detalhes dos grupos entrada e saída
    -- 3 - Saldo final do dia

    DECLARE @EspacoSimpl VARCHAR(10) = '      ';
    DECLARE @EspacoDuplo VARCHAR(20) = @EspacoSimpl + @EspacoSimpl;

    WITH Fase01 AS (SELECT 0 Ordem,
                           Dias.Indice Dia, Ivst.InvestimentoID, Cnta.ContaID, Cnta.Apelido Conta,
                           Ivst.Apelido, Tipo.Apelido AS Tipo, Tipo.Fundo, Tipo.Acao,
                           dbo.fncSaldoInvestimentoLiquido(Ivst.InvestimentoID, Cota.Data, 1) Valor,
                           Rsco.RiscoID, Rsco.Apelido Risco
                    FROM @Dias Dias
                         JOIN Investimento Ivst ON 1 = 1
                         JOIN TipoInvestimento Tipo ON Tipo.TipoInvestimentoID = Ivst.TipoInvestimentoID
                         JOIN Risco Rsco ON Rsco.RiscoID = Ivst.RiscoID
                         JOIN MovimentoInvestimento Mvto ON Mvto.InvestimentoID = Ivst.InvestimentoID
                         JOIN MovimentoConta MCta ON MCta.MovimentoContaID = Mvto.MovimentoContaID
                                                 AND CAST(MCta.Data AS DATE) <= Dias.Dia
                         JOIN Conta Cnta ON Cnta.ContaID = MCta.ContaID
                         JOIN InvestimentoCotacao Cota ON Cota.InvestimentoID = Ivst.InvestimentoID
                                                      AND Cota.Data = (SELECT MAX(Data) 
                                                                       FROM InvestimentoCotacao 
                                                                       WHERE InvestimentoID = Ivst.InvestimentoID 
                                                                       AND   Data <= Dias.Dia)
                    GROUP BY Dias.Indice, Ivst.InvestimentoID, Cnta.ContaID, Cnta.Apelido, Ivst.Apelido, Tipo.Apelido, Tipo.Fundo, Tipo.Acao,
                             Cota.Data, Cota.VrCotacao, Rsco.RiscoID, Rsco.Apelido
                    HAVING SUM(COALESCE(Mvto.QtCotas, 0)) <> 0
                    
                    UNION ALL

                    SELECT 2 Ordem, 
                           Dias.Indice Dia, 0 AS InvestimentoID, Cnta.ContaID, Cnta.Apelido Conta, 
                           Cnta.Apelido, 'Poupança' AS Tipo, CAST(0 AS BIT) Fundo, CAST(0 AS BIT) Acao,
                           SUM(Valor) Valor, Rsco.RiscoID, Rsco.Apelido Risco
                    FROM @Dias Dias
                         JOIN Conta Cnta ON 1 = 1
                         JOIN Risco Rsco ON Rsco.RiscoID = 1
                         JOIN TipoConta TCnt ON TCnt.TipoContaID = Cnta.TipoContaID 
                                            AND TCnt.Poupanca = 1
                         JOIN MovimentoConta Mvto ON Mvto.ContaID = Cnta.ContaID 
                                                 AND CAST(Mvto.Data AS DATE) <= Dias.Dia
                    GROUP BY Dias.Indice, Cnta.ContaID, Cnta.Apelido, Rsco.RiscoID, Rsco.Apelido),
         Fase02 AS (SELECT 2 TipoLinha, F01.Ordem, F01.Dia, F01.InvestimentoID, F01.ContaID, @EspacoSimpl + F01.Apelido Apelido, F01.Tipo, F01.Valor,
                           F01.RiscoID, F01.Risco
                    FROM Fase01 F01
                    
                    UNION ALL

                    SELECT 1 TipoLinha, F01.Ordem, F01.Dia, 0 IvestimentoID, 0 ContaID, 'Total ' + F01.Tipo Apelido, F01.Tipo, SUM(F01.Valor) Valor,
                           NULL RiscoID, NULL Risco
                    FROM Fase01 F01
                    GROUP BY F01.Ordem, F01.Dia, F01.Tipo

                    UNION ALL

                    SELECT 3 TipoLinha, 1 Ordem, F01.Dia, 0 IvestimentoID, 0 ContaID, 'Total Fundos' Apelido, NULL Tipo, SUM(F01.Valor) Valor,
                           NULL RiscoID, NULL Risco
                    FROM Fase01 F01
                    WHERE F01.InvestimentoID <> 0
                    GROUP BY F01.Ordem, F01.Dia
                    
                    UNION ALL

                    SELECT 3 TipoLinha, 3 Ordem, F01.Dia, 0 IvestimentoID, 0 ContaID, 'Total Geral' Apelido, NULL Tipo, SUM(F01.Valor) Valor,
                           NULL RiscoID, NULL Risco
                    FROM Fase01 F01
                    GROUP BY F01.Dia)
    INSERT INTO @Tempor
    (Ordem, TipoLinha, InvestimentoID, ContaID, Tipo, Apelido,
     Dia01, Dia02, Dia03, Dia04, Dia05, Dia06, Dia07, Dia08, Dia09, Dia10, 
     RiscoID, Risco, ListaDatasISO)
    SELECT Ordem, TipoLinha, InvestimentoID, ContaID, Tipo, Apelido,
            [1] 'Dia01',  [2] 'Dia02',  [3] 'Dia03',  [4] 'Dia04',  [5] 'Dia05',  [6] 'Dia06',  [7] 'Dia07',  [8] 'Dia08',  [9] 'Dia09', [10] 'Dia10', 
           RiscoID, Risco, @ListaDatas
    FROM (SELECT Ordem, TipoLinha, Dia, InvestimentoID, ContaID, Apelido, Tipo, RiscoID, Risco, Valor FROM Fase02) Origem
    PIVOT (SUM(Valor) FOR Dia IN (  [1], [2], [3], [4], [5], [6], [7], [8], [9],[10])) Final;

    UPDATE @Tempor
    SET Perc0102 = CASE WHEN COALESCE(Dia01, 0) <> 0 AND COALESCE(Dia02, 0) <> 0 THEN
                             (Dia02 - Dia01) / Dia01
                        WHEN COALESCE(Dia01, 0) = 0 AND COALESCE(Dia02, 0) <> 0 THEN 9999.9999
                        WHEN COALESCE(Dia01, 0) <> 0 AND COALESCE(Dia02, 0) = 0 THEN -9999.9999
                        ELSE 0
                   END,
        Perc0203 = CASE WHEN COALESCE(Dia02, 0) <> 0 AND COALESCE(Dia03, 0) <> 0 THEN
                             (Dia03 - Dia02) / Dia02
                        WHEN COALESCE(Dia02, 0) = 0 AND COALESCE(Dia03, 0) <> 0 THEN 9999.9999
                        WHEN COALESCE(Dia02, 0) <> 0 AND COALESCE(Dia03, 0) = 0 THEN -9999.9999
                        ELSE 0
                   END,
        Perc0304 = CASE WHEN COALESCE(Dia03, 0) <> 0 AND COALESCE(Dia04, 0) <> 0 THEN
                             (Dia04 - Dia03) / Dia03
                        WHEN COALESCE(Dia03, 0) = 0 AND COALESCE(Dia04, 0) <> 0 THEN 9999.9999
                        WHEN COALESCE(Dia03, 0) <> 0 AND COALESCE(Dia04, 0) = 0 THEN -9999.9999
                        ELSE 0
                   END,
        Perc0405 = CASE WHEN COALESCE(Dia04, 0) <> 0 AND COALESCE(Dia05, 0) <> 0 THEN
                             (Dia05 - Dia04) / Dia04
                        WHEN COALESCE(Dia04, 0) = 0 AND COALESCE(Dia05, 0) <> 0 THEN 9999.9999
                        WHEN COALESCE(Dia04, 0) <> 0 AND COALESCE(Dia05, 0) = 0 THEN -9999.9999
                        ELSE 0
                   END,
        Perc0506 = CASE WHEN COALESCE(Dia05, 0) <> 0 AND COALESCE(Dia06, 0) <> 0 THEN
                             (Dia06 - Dia05) / Dia05
                        WHEN COALESCE(Dia05, 0) = 0 AND COALESCE(Dia06, 0) <> 0 THEN 9999.9999
                        WHEN COALESCE(Dia05, 0) <> 0 AND COALESCE(Dia06, 0) = 0 THEN -9999.9999
                        ELSE 0
                   END,
        Perc0607 = CASE WHEN COALESCE(Dia06, 0) <> 0 AND COALESCE(Dia07, 0) <> 0 THEN
                             (Dia07 - Dia06) / Dia06
                        WHEN COALESCE(Dia06, 0) = 0 AND COALESCE(Dia07, 0) <> 0 THEN 9999.9999
                        WHEN COALESCE(Dia06, 0) <> 0 AND COALESCE(Dia07, 0) = 0 THEN -9999.9999
                        ELSE 0
                   END,
        Perc0708 = CASE WHEN COALESCE(Dia07, 0) <> 0 AND COALESCE(Dia08, 0) <> 0 THEN
                             (Dia08 - Dia07) / Dia07
                        WHEN COALESCE(Dia07, 0) = 0 AND COALESCE(Dia08, 0) <> 0 THEN 9999.9999
                        WHEN COALESCE(Dia07, 0) <> 0 AND COALESCE(Dia08, 0) = 0 THEN -9999.9999
                        ELSE 0
                   END,
        Perc0809 = CASE WHEN COALESCE(Dia08, 0) <> 0 AND COALESCE(Dia09, 0) <> 0 THEN
                             (Dia09 - Dia08) / Dia08
                        WHEN COALESCE(Dia08, 0) = 0 AND COALESCE(Dia09, 0) <> 0 THEN 9999.9999
                        WHEN COALESCE(Dia08, 0) <> 0 AND COALESCE(Dia09, 0) = 0 THEN -9999.9999
                        ELSE 0
                   END,
        Perc0910 = CASE WHEN COALESCE(Dia09, 0) <> 0 AND COALESCE(Dia10, 0) <> 0 THEN
                             (Dia10 - Dia09) / Dia09
                        WHEN COALESCE(Dia09, 0) = 0 AND COALESCE(Dia10, 0) <> 0 THEN 9999.9999
                        WHEN COALESCE(Dia09, 0) <> 0 AND COALESCE(Dia10, 0) = 0 THEN -9999.9999
                        ELSE 0
                   END;

    SELECT Ordem, TipoLInha, InvestimentoID, ContaID, Tipo, Apelido, ListaDatasISO,
           Dia01, Perc0102, 
           Dia02, Perc0203,
           Dia03, Perc0304,
           Dia04, Perc0405,
           Dia05, Perc0506,
           Dia06, Perc0607,
           Dia07, Perc0708,
           Dia08, Perc0809,
           Dia09, Perc0910,
           Dia10,
           RiscoID, Risco
    FROM @Tempor
    ORDER BY Ordem ASC, Tipo ASC, TipoLinha ASC, Apelido ASC;

          
END;
GO
/****** Object:  StoredProcedure [dbo].[stpVariacaoDiariaInvestimentos]    Script Date: 05/01/2022 12:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/******************************************************
 Procedure stpOrcamentoDiario
 
 Elcio Reis - 27/08/2019
 Cria uma "planilha" com a variação diária dos 
 investimentos no mês

 Elcio Reis - 18/09/2019
 Inclusão de contas de câmbio

 Elcio Reis - 03/10/2019
 Alteração na rotina de valoração das moedas de câmbio
 
 EXEC stpVariacaoDiariaInvestimentos 2, '2019-10-03';
 ******************************************************/

CREATE PROCEDURE [dbo].[stpVariacaoDiariaInvestimentos] (@UsuarioID INT, @DataReferencia DATE = NULL)
AS
BEGIN
   
    SET NOCOUNT ON;

    IF (@DataReferencia IS NULL)
    BEGIN
        SET @DataReferencia = GETDATE();
    END;

    DECLARE @MoedaPadraoID INT;
    DECLARE @Simbolo VARCHAR(10);

    SELECT @MoedaPadraoID = MoedaID,
           @Simbolo = TRIM(Simbolo)
    FROM Moeda 
    WHERE Padrao = 1;

    -- Calcula o primeiro dia do mês
    DECLARE @PrimeiroDia DATE = DATEADD(DAY, 1, EOMONTH(@DataReferencia, -1));
    -- Calcula o último dia do mês
    DECLARE @UltimoDia DATE = EOMONTH(@DataReferencia);

    -- Cria uma tabela com todos os dias do mês em referência
    DECLARE @Dias TABLE (Indice SMALLINT, Dia DATE, DiaSeguinte DATE);

    -- Acrescenta todos os dias do mês na tabela @Dias e o último dia do mês anterior
    DECLARE @Dia DATE = DATEADD(DAY, -1, @PrimeiroDia);
    DECLARE @Indice SMALLINT = 0;

    WHILE (@Dia <= @UltimoDia)
    BEGIN
        INSERT INTO @Dias
        (Indice, Dia, DiaSeguinte)
        VALUES
        (@Indice, @Dia, DATEADD(DAY, 1, @Dia));

        SET @Indice = @Indice + 1;
        SET @Dia = DATEADD(DAY, 1, @Dia);
    END; -- WHILE


    -- Cria tabela virtual para receber o conteúdo do select principal
    DECLARE @Tempor TABLE (
        Ordem            SMALLINT,
        TipoLinha        SMALLINT,
        InvestimentoID   INT,
        ContaID          INT,
        Tipo             VARCHAR(50),
        Apelido          VARCHAR(50),
        RiscoID          INT,
        Risco            VARCHAR(20),
        Dia00            DECIMAL(10,2),
        Var0001          SMALLINT,
        Dia01            DECIMAL(10,2),
        Var0102          SMALLINT,
        Dia02            DECIMAL(10,2),
        Var0203          SMALLINT,
        Dia03            DECIMAL(10,2),
        Var0304          SMALLINT,
        Dia04            DECIMAL(10,2),
        Var0405          SMALLINT,
        Dia05            DECIMAL(10,2),
        Var0506          SMALLINT,
        Dia06            DECIMAL(10,2),
        Var0607          SMALLINT,
        Dia07            DECIMAL(10,2),
        Var0708          SMALLINT,
        Dia08            DECIMAL(10,2),
        Var0809          SMALLINT,
        Dia09            DECIMAL(10,2),
        Var0910          SMALLINT,
        Dia10            DECIMAL(10,2),
        Var1011          SMALLINT,
        Dia11            DECIMAL(10,2),
        Var1112          SMALLINT,
        Dia12            DECIMAL(10,2),
        Var1213          SMALLINT,
        Dia13            DECIMAL(10,2),
        Var1314          SMALLINT,
        Dia14            DECIMAL(10,2),
        Var1415          SMALLINT,
        Dia15            DECIMAL(10,2),
        Var1516          SMALLINT,
        Dia16            DECIMAL(10,2),
        Var1617          SMALLINT,
        Dia17            DECIMAL(10,2),
        Var1718          SMALLINT,
        Dia18            DECIMAL(10,2),
        Var1819          SMALLINT,
        Dia19            DECIMAL(10,2),
        Var1920          SMALLINT,
        Dia20            DECIMAL(10,2),
        Var2021          SMALLINT,
        Dia21            DECIMAL(10,2),
        Var2122          SMALLINT,
        Dia22            DECIMAL(10,2),
        Var2223          SMALLINT,
        Dia23            DECIMAL(10,2),
        Var2324          SMALLINT,
        Dia24            DECIMAL(10,2),
        Var2425          SMALLINT,
        Dia25            DECIMAL(10,2),
        Var2526          SMALLINT,
        Dia26            DECIMAL(10,2),
        Var2627          SMALLINT,
        Dia27            DECIMAL(10,2),
        Var2728          SMALLINT,
        Dia28            DECIMAL(10,2),
        Var2829          SMALLINT,
        Dia29            DECIMAL(10,2),
        Var2930          SMALLINT,
        Dia30            DECIMAL(10,2),
        Var3031          SMALLINT,
        Dia31            DECIMAL(10,2),
        Per0031          DECIMAL(14,6),
        DataReferencia   DATE
    );

    -- O campo TipoLinha recebe o seguinte conteúdo:
    -- 0 - Linha com o saldo do dia anterior
    -- 1 - Total dos grupos entrada e saída
    -- 2 - Detalhes dos grupos entrada e saída
    -- 3 - Saldo final do dia

    DECLARE @EspacoSimpl VARCHAR(10) = '      ';
    DECLARE @EspacoDuplo VARCHAR(20) = @EspacoSimpl + @EspacoSimpl;

---    SELECT * FROM @Dias

    WITH Fase01 AS (SELECT 0 Ordem,
                           Dias.Indice Dia, Ivst.InvestimentoID, Cnta.ContaID, ---Cnta.Apelido Conta,
                           Ivst.Apelido, Tipo.Apelido AS Tipo, Tipo.Fundo, Tipo.Acao,
                           dbo.fncSaldoInvestimentoLiquido(Ivst.InvestimentoID, Cota.Data, 1) Valor,
                           Rsco.RiscoID, Rsco.Apelido Risco
                    FROM @Dias Dias
                         JOIN Investimento Ivst ON 1 = 1
                         JOIN TipoInvestimento Tipo ON Tipo.TipoInvestimentoID = Ivst.TipoInvestimentoID
                         JOIN Risco Rsco ON Rsco.RiscoID = Ivst.RiscoID
                         JOIN MovimentoInvestimento Mvto ON Mvto.InvestimentoID = Ivst.InvestimentoID
                         JOIN MovimentoConta MCta ON MCta.MovimentoContaID = Mvto.MovimentoContaID
                                                 AND CAST(MCta.Data AS DATE) <= Dias.Dia
                         JOIN Conta Cnta ON Cnta.ContaID = MCta.ContaID
                         JOIN InvestimentoCotacao Cota ON Cota.InvestimentoID = Ivst.InvestimentoID
                                                      AND Cota.Data = (SELECT MAX(Data) 
                                                                       FROM InvestimentoCotacao 
                                                                       WHERE InvestimentoID = Ivst.InvestimentoID 
                                                                       AND   Data <= Dias.Dia)
                    GROUP BY Dias.Indice, Ivst.InvestimentoID, Cnta.ContaID, Cnta.Apelido, Ivst.Apelido, Tipo.Apelido, Tipo.Fundo, Tipo.Acao,
                             Cota.Data, Cota.VrCotacao, Rsco.RiscoID, Rsco.Apelido
                    HAVING SUM(COALESCE(Mvto.QtCotas, 0)) <> 0
                    
                    UNION ALL

                    SELECT 2 Ordem, 
                           Dias.Indice Dia, 0 AS InvestimentoID, Cnta.ContaID, ---Cnta.Apelido Conta, 
                           Cnta.Apelido, 'Poupança' AS Tipo, CAST(0 AS BIT) Fundo, CAST(0 AS BIT) Acao,
                           SUM(Valor) Valor, Rsco.RiscoID, Rsco.Apelido Risco
                    FROM @Dias Dias
                         JOIN Conta Cnta ON 1 = 1
                         JOIN Risco Rsco ON Rsco.RiscoID = 1
                         JOIN TipoConta TCnt ON TCnt.TipoContaID = Cnta.TipoContaID 
                                            AND TCnt.Poupanca = 1
                         JOIN MovimentoConta Mvto ON Mvto.ContaID = Cnta.ContaID 
                                                 AND CAST(Mvto.Data AS DATE) <= Dias.Dia
                    GROUP BY Dias.Indice, Cnta.ContaID, Cnta.Apelido, Rsco.RiscoID, Rsco.Apelido

---- Inclusão de contas de câmbio                    

                    UNION ALL

                    SELECT 3 Ordem, 
                           Dias.Indice Dia, 0 AS InvestimentoID, Cnta.ContaID, ---Cnta.Apelido Conta, 
                           TRIM(Cnta.Apelido) + ' (em ' + @Simbolo + ')' , 'Câmbio' AS Tipo, CAST(0 AS BIT) Fundo, CAST(0 AS BIT) Acao,
                           dbo.fncSaldoContaEmMoedaPadrao(Cnta.ContaID, Dias.Dia) Valor,
                           Rsco.RiscoID, Rsco.Apelido Risco
                    FROM @Dias Dias
                         JOIN Conta Cnta ON 1 = 1
                         JOIN Risco Rsco ON Rsco.RiscoID = 5
                         JOIN TipoConta TCnt ON TCnt.TipoContaID = Cnta.TipoContaID 
                                            AND TCnt.Cambio = 1
                    WHERE Cnta.Ativo = 1),
         Fase02 AS (SELECT 2 TipoLinha, F01.Ordem, F01.Dia, F01.InvestimentoID, F01.ContaID, @EspacoSimpl + F01.Apelido Apelido, F01.Tipo, F01.Valor,
                           F01.RiscoID, F01.Risco
                    FROM Fase01 F01
                    
                    UNION ALL

                    SELECT 1 TipoLinha, F01.Ordem, F01.Dia, 0 IvestimentoID, 0 ContaID, 'Total ' + F01.Tipo Apelido, F01.Tipo, SUM(F01.Valor) Valor,
                           NULL RiscoID, NULL Risco
                    FROM Fase01 F01
                    GROUP BY F01.Ordem, F01.Dia, F01.Tipo

                    UNION ALL

                    SELECT 3 TipoLinha, 1 Ordem, F01.Dia, 0 IvestimentoID, 0 ContaID, 'Total Fundos' Apelido, NULL Tipo, SUM(F01.Valor) Valor,
                           NULL RiscoID, NULL Risco
                    FROM Fase01 F01
                    WHERE F01.InvestimentoID <> 0
                    GROUP BY F01.Ordem, F01.Dia

                    UNION ALL

                    SELECT 3 TipoLinha, 4 Ordem, F01.Dia, 0 IvestimentoID, 0 ContaID, 'Total Geral' Apelido, NULL Tipo, SUM(F01.Valor) Valor,
                           NULL RiscoID, NULL Risco
                    FROM Fase01 F01
                    GROUP BY F01.Dia)
    INSERT INTO @Tempor
    (Ordem, TipoLinha, InvestimentoID, ContaID, Tipo, Apelido, DataReferencia,
     Dia00,
     Dia01, Dia02, Dia03, Dia04, Dia05, Dia06, Dia07, Dia08, Dia09, Dia10, 
     Dia11, Dia12, Dia13, Dia14, Dia15, Dia16, Dia17, Dia18, Dia19, Dia20, 
     Dia21, Dia22, Dia23, Dia24, Dia25, Dia26, Dia27, Dia28, Dia29, Dia30, Dia31,
     RiscoID, Risco)
    SELECT Ordem, TipoLinha, InvestimentoID, ContaID, Tipo, Apelido, @UltimoDia DataReferencia,
            [0] 'Dia00', 
            [1] 'Dia01',  [2] 'Dia02',  [3] 'Dia03',  [4] 'Dia04',  [5] 'Dia05',  [6] 'Dia06',  [7] 'Dia07',  [8] 'Dia08',  [9] 'Dia09', [10] 'Dia10', 
           [11] 'Dia11', [12] 'Dia12', [13] 'Dia13', [14] 'Dia14', [15] 'Dia15', [16] 'Dia16', [17] 'Dia17', [18] 'Dia18', [19] 'Dia19', [20] 'Dia20',
           [21] 'Dia21', [22] 'Dia22', [23] 'Dia23', [24] 'Dia24', [25] 'Dia25', [26] 'Dia26', [27] 'Dia27', [28] 'Dia28', [29] 'Dia29', [30] 'Dia30', [31] 'Dia31',
           
           RiscoID, Risco
    FROM (SELECT Ordem, TipoLinha, Dia, InvestimentoID, ContaID, Apelido, Tipo, RiscoID, Risco, Valor FROM Fase02) Origem
    PIVOT (SUM(Valor) FOR Dia IN (  [0],
                                    [1], [2], [3], [4], [5], [6], [7], [8], [9],[10],
                                   [11],[12],[13],[14],[15],[16],[17],[18],[19],[20],
                                   [21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31])) Final;

    UPDATE @Tempor
    SET Var0001 = CASE WHEN COALESCE(Dia00, 0) <> 0 AND COALESCE(Dia01, 0) <> 0 THEN
                            CASE WHEN Dia00 < Dia01 THEN 1
                                 WHEN Dia00 = Dia01 THEN 0
                                 WHEN Dia00 > Dia01 THEN -1
                            END
                       WHEN COALESCE(Dia00, 0) = 0 AND COALESCE(Dia01, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia00, 0) <> 0 AND COALESCE(Dia01, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var0102 = CASE WHEN COALESCE(Dia01, 0) <> 0 AND COALESCE(Dia02, 0) <> 0 THEN
                            CASE WHEN Dia01 < Dia02 THEN 1
                                 WHEN Dia01 = Dia02 THEN 0
                                 WHEN Dia01 > Dia02 THEN -1
                            END
                       WHEN COALESCE(Dia01, 0) = 0 AND COALESCE(Dia02, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia01, 0) <> 0 AND COALESCE(Dia02, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var0203 = CASE WHEN COALESCE(Dia02, 0) <> 0 AND COALESCE(Dia03, 0) <> 0 THEN
                            CASE WHEN Dia02 < Dia03 THEN 1
                                 WHEN Dia02 = Dia03 THEN 0
                                 WHEN Dia02 > Dia03 THEN -1
                            END
                       WHEN COALESCE(Dia02, 0) = 0 AND COALESCE(Dia03, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia02, 0) <> 0 AND COALESCE(Dia03, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var0304 = CASE WHEN COALESCE(Dia03, 0) <> 0 AND COALESCE(Dia04, 0) <> 0 THEN
                            CASE WHEN Dia03 < Dia04 THEN 1
                                 WHEN Dia03 = Dia04 THEN 0
                                 WHEN Dia03 > Dia04 THEN -1
                            END
                       WHEN COALESCE(Dia03, 0) = 0 AND COALESCE(Dia04, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia03, 0) <> 0 AND COALESCE(Dia04, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var0405 = CASE WHEN COALESCE(Dia04, 0) <> 0 AND COALESCE(Dia05, 0) <> 0 THEN
                            CASE WHEN Dia04 < Dia05 THEN 1
                                 WHEN Dia04 = Dia05 THEN 0
                                 WHEN Dia04 > Dia05 THEN -1
                            END
                       WHEN COALESCE(Dia04, 0) = 0 AND COALESCE(Dia05, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia04, 0) <> 0 AND COALESCE(Dia05, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var0506 = CASE WHEN COALESCE(Dia05, 0) <> 0 AND COALESCE(Dia06, 0) <> 0 THEN
                            CASE WHEN Dia05 < Dia06 THEN 1
                                 WHEN Dia05 = Dia06 THEN 0
                                 WHEN Dia05 > Dia06 THEN -1
                            END
                       WHEN COALESCE(Dia05, 0) = 0 AND COALESCE(Dia06, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia05, 0) <> 0 AND COALESCE(Dia06, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var0607 = CASE WHEN COALESCE(Dia06, 0) <> 0 AND COALESCE(Dia07, 0) <> 0 THEN
                            CASE WHEN Dia06 < Dia07 THEN 1
                                 WHEN Dia06 = Dia07 THEN 0
                                 WHEN Dia06 > Dia07 THEN -1
                            END
                       WHEN COALESCE(Dia06, 0) = 0 AND COALESCE(Dia07, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia06, 0) <> 0 AND COALESCE(Dia07, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var0708 = CASE WHEN COALESCE(Dia07, 0) <> 0 AND COALESCE(Dia08, 0) <> 0 THEN
                            CASE WHEN Dia07 < Dia08 THEN 1
                                 WHEN Dia07 = Dia08 THEN 0
                                 WHEN Dia07 > Dia08 THEN -1
                            END
                       WHEN COALESCE(Dia07, 0) = 0 AND COALESCE(Dia08, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia07, 0) <> 0 AND COALESCE(Dia08, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var0809 = CASE WHEN COALESCE(Dia08, 0) <> 0 AND COALESCE(Dia09, 0) <> 0 THEN
                            CASE WHEN Dia08 < Dia09 THEN 1
                                 WHEN Dia08 = Dia09 THEN 0
                                 WHEN Dia08 > Dia09 THEN -1
                            END
                       WHEN COALESCE(Dia08, 0) = 0 AND COALESCE(Dia09, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia08, 0) <> 0 AND COALESCE(Dia09, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var0910 = CASE WHEN COALESCE(Dia09, 0) <> 0 AND COALESCE(Dia10, 0) <> 0 THEN
                            CASE WHEN Dia09 < Dia10 THEN 1
                                 WHEN Dia09 = Dia10 THEN 0
                                 WHEN Dia09 > Dia10 THEN -1
                            END
                       WHEN COALESCE(Dia09, 0) = 0 AND COALESCE(Dia10, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia09, 0) <> 0 AND COALESCE(Dia10, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var1011 = CASE WHEN COALESCE(Dia10, 0) <> 0 AND COALESCE(Dia11, 0) <> 0 THEN
                            CASE WHEN Dia10 < Dia11 THEN 1
                                 WHEN Dia10 = Dia11 THEN 0
                                 WHEN Dia10 > Dia11 THEN -1
                            END
                       WHEN COALESCE(Dia10, 0) = 0 AND COALESCE(Dia11, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia10, 0) <> 0 AND COALESCE(Dia11, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var1112 = CASE WHEN COALESCE(Dia11, 0) <> 0 AND COALESCE(Dia12, 0) <> 0 THEN
                            CASE WHEN Dia11 < Dia12 THEN 1
                                 WHEN Dia11 = Dia12 THEN 0
                                 WHEN Dia11 > Dia12 THEN -1
                            END
                       WHEN COALESCE(Dia11, 0) = 0 AND COALESCE(Dia12, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia11, 0) <> 0 AND COALESCE(Dia12, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var1213 = CASE WHEN COALESCE(Dia12, 0) <> 0 AND COALESCE(Dia13, 0) <> 0 THEN
                            CASE WHEN Dia12 < Dia13 THEN 1
                                 WHEN Dia12 = Dia13 THEN 0
                                 WHEN Dia12 > Dia13 THEN -1
                            END
                       WHEN COALESCE(Dia12, 0) = 0 AND COALESCE(Dia13, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia12, 0) <> 0 AND COALESCE(Dia13, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var1314 = CASE WHEN COALESCE(Dia13, 0) <> 0 AND COALESCE(Dia14, 0) <> 0 THEN
                            CASE WHEN Dia13 < Dia14 THEN 1
                                 WHEN Dia13 = Dia14 THEN 0
                                 WHEN Dia13 > Dia14 THEN -1
                            END
                       WHEN COALESCE(Dia13, 0) = 0 AND COALESCE(Dia14, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia13, 0) <> 0 AND COALESCE(Dia14, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var1415 = CASE WHEN COALESCE(Dia14, 0) <> 0 AND COALESCE(Dia15, 0) <> 0 THEN
                            CASE WHEN Dia14 < Dia15 THEN 1
                                 WHEN Dia14 = Dia15 THEN 0
                                 WHEN Dia14 > Dia15 THEN -1
                            END
                       WHEN COALESCE(Dia14, 0) = 0 AND COALESCE(Dia15, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia14, 0) <> 0 AND COALESCE(Dia15, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var1516 = CASE WHEN COALESCE(Dia15, 0) <> 0 AND COALESCE(Dia16, 0) <> 0 THEN
                            CASE WHEN Dia15 < Dia16 THEN 1
                                 WHEN Dia15 = Dia16 THEN 0
                                 WHEN Dia15 > Dia16 THEN -1
                            END
                       WHEN COALESCE(Dia15, 0) = 0 AND COALESCE(Dia16, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia15, 0) <> 0 AND COALESCE(Dia16, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var1617 = CASE WHEN COALESCE(Dia16, 0) <> 0 AND COALESCE(Dia17, 0) <> 0 THEN
                            CASE WHEN Dia16 < Dia17 THEN 1
                                 WHEN Dia16 = Dia17 THEN 0
                                 WHEN Dia16 > Dia17 THEN -1
                            END
                       WHEN COALESCE(Dia16, 0) = 0 AND COALESCE(Dia17, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia16, 0) <> 0 AND COALESCE(Dia17, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var1718 = CASE WHEN COALESCE(Dia17, 0) <> 0 AND COALESCE(Dia18, 0) <> 0 THEN
                            CASE WHEN Dia17 < Dia18 THEN 1
                                 WHEN Dia17 = Dia18 THEN 0
                                 WHEN Dia17 > Dia18 THEN -1
                            END
                       WHEN COALESCE(Dia17, 0) = 0 AND COALESCE(Dia18, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia17, 0) <> 0 AND COALESCE(Dia18, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var1819 = CASE WHEN COALESCE(Dia18, 0) <> 0 AND COALESCE(Dia19, 0) <> 0 THEN
                            CASE WHEN Dia18 < Dia19 THEN 1
                                 WHEN Dia18 = Dia19 THEN 0
                                 WHEN Dia18 > Dia19 THEN -1
                            END
                       WHEN COALESCE(Dia18, 0) = 0 AND COALESCE(Dia19, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia18, 0) <> 0 AND COALESCE(Dia19, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var1920 = CASE WHEN COALESCE(Dia19, 0) <> 0 AND COALESCE(Dia20, 0) <> 0 THEN
                            CASE WHEN Dia19 < Dia20 THEN 1
                                 WHEN Dia19 = Dia20 THEN 0
                                 WHEN Dia19 > Dia20 THEN -1
                            END
                       WHEN COALESCE(Dia19, 0) = 0 AND COALESCE(Dia20, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia19, 0) <> 0 AND COALESCE(Dia20, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var2021 = CASE WHEN COALESCE(Dia20, 0) <> 0 AND COALESCE(Dia21, 0) <> 0 THEN
                            CASE WHEN Dia20 < Dia21 THEN 1
                                 WHEN Dia20 = Dia21 THEN 0
                                 WHEN Dia20 > Dia21 THEN -1
                            END
                       WHEN COALESCE(Dia20, 0) = 0 AND COALESCE(Dia21, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia20, 0) <> 0 AND COALESCE(Dia21, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var2122 = CASE WHEN COALESCE(Dia21, 0) <> 0 AND COALESCE(Dia22, 0) <> 0 THEN
                            CASE WHEN Dia21 < Dia22 THEN 1
                                 WHEN Dia21 = Dia22 THEN 0
                                 WHEN Dia21 > Dia22 THEN -1
                            END
                       WHEN COALESCE(Dia21, 0) = 0 AND COALESCE(Dia22, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia21, 0) <> 0 AND COALESCE(Dia22, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var2223 = CASE WHEN COALESCE(Dia22, 0) <> 0 AND COALESCE(Dia23, 0) <> 0 THEN
                            CASE WHEN Dia22 < Dia23 THEN 1
                                 WHEN Dia22 = Dia23 THEN 0
                                 WHEN Dia22 > Dia23 THEN -1
                            END
                       WHEN COALESCE(Dia22, 0) = 0 AND COALESCE(Dia23, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia22, 0) <> 0 AND COALESCE(Dia23, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var2324 = CASE WHEN COALESCE(Dia23, 0) <> 0 AND COALESCE(Dia24, 0) <> 0 THEN
                            CASE WHEN Dia23 < Dia24 THEN 1
                                 WHEN Dia23 = Dia24 THEN 0
                                 WHEN Dia23 > Dia24 THEN -1
                            END
                       WHEN COALESCE(Dia23, 0) = 0 AND COALESCE(Dia24, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia23, 0) <> 0 AND COALESCE(Dia24, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var2425 = CASE WHEN COALESCE(Dia24, 0) <> 0 AND COALESCE(Dia25, 0) <> 0 THEN
                            CASE WHEN Dia24 < Dia25 THEN 1
                                 WHEN Dia24 = Dia25 THEN 0
                                 WHEN Dia24 > Dia25 THEN -1
                            END
                       WHEN COALESCE(Dia24, 0) = 0 AND COALESCE(Dia25, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia24, 0) <> 0 AND COALESCE(Dia25, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var2526 = CASE WHEN COALESCE(Dia25, 0) <> 0 AND COALESCE(Dia26, 0) <> 0 THEN
                            CASE WHEN Dia25 < Dia26 THEN 1
                                 WHEN Dia25 = Dia26 THEN 0
                                 WHEN Dia25 > Dia26 THEN -1
                            END
                       WHEN COALESCE(Dia25, 0) = 0 AND COALESCE(Dia26, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia25, 0) <> 0 AND COALESCE(Dia26, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var2627 = CASE WHEN COALESCE(Dia26, 0) <> 0 AND COALESCE(Dia27, 0) <> 0 THEN
                            CASE WHEN Dia26 < Dia27 THEN 1
                                 WHEN Dia26 = Dia27 THEN 0
                                 WHEN Dia26 > Dia27 THEN -1
                            END
                       WHEN COALESCE(Dia26, 0) = 0 AND COALESCE(Dia27, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia26, 0) <> 0 AND COALESCE(Dia27, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var2728 = CASE WHEN COALESCE(Dia27, 0) <> 0 AND COALESCE(Dia28, 0) <> 0 THEN
                            CASE WHEN Dia27 < Dia28 THEN 1
                                 WHEN Dia27 = Dia28 THEN 0
                                 WHEN Dia27 > Dia28 THEN -1
                            END
                       WHEN COALESCE(Dia27, 0) = 0 AND COALESCE(Dia28, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia27, 0) <> 0 AND COALESCE(Dia28, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var2829 = CASE WHEN COALESCE(Dia28, 0) <> 0 AND COALESCE(Dia29, 0) <> 0 THEN
                            CASE WHEN Dia28 < Dia29 THEN 1
                                 WHEN Dia28 = Dia29 THEN 0
                                 WHEN Dia28 > Dia29 THEN -1
                            END
                       WHEN COALESCE(Dia28, 0) = 0 AND COALESCE(Dia29, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia28, 0) <> 0 AND COALESCE(Dia29, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var2930 = CASE WHEN COALESCE(Dia29, 0) <> 0 AND COALESCE(Dia30, 0) <> 0 THEN
                            CASE WHEN Dia29 < Dia30 THEN 1
                                 WHEN Dia29 = Dia30 THEN 0
                                 WHEN Dia29 > Dia30 THEN -1
                            END
                       WHEN COALESCE(Dia29, 0) = 0 AND COALESCE(Dia30, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia29, 0) <> 0 AND COALESCE(Dia30, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var3031 = CASE WHEN COALESCE(Dia30, 0) <> 0 AND COALESCE(Dia31, 0) <> 0 THEN
                            CASE WHEN Dia30 < Dia31 THEN 1
                                 WHEN Dia30 = Dia31 THEN 0
                                 WHEN Dia30 > Dia31 THEN -1
                            END
                       WHEN COALESCE(Dia30, 0) = 0 AND COALESCE(Dia31, 0) <> 0 THEN 9
                       WHEN COALESCE(Dia30, 0) <> 0 AND COALESCE(Dia31, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Per0031 = CASE WHEN COALESCE(Dia00, 0) <> 0 AND COALESCE(Dia31, Dia30, Dia29, Dia28, 0) <> 0 THEN
                            (COALESCE(Dia31, Dia30, Dia29, Dia28) - Dia00) / Dia00
                       WHEN COALESCE(Dia00, 0) = 0 AND COALESCE(Dia31, Dia30, Dia29, Dia28, 0) <> 0 THEN 9999.9999
                       WHEN COALESCE(Dia00, 0) <> 0 AND COALESCE(Dia31, Dia30, Dia29, Dia28, 0) = 0 THEN -9999.9999
                       ELSE 0
                  END;

    SELECT Ordem, TipoLInha, InvestimentoID, ContaID, Tipo, Apelido, DataReferencia,
           Dia00, Var0001,
           Dia01, Var0102, 
           Dia02, Var0203,
           Dia03, Var0304,
           Dia04, Var0405,
           Dia05, Var0506,
           Dia06, Var0607,
           Dia07, Var0708,
           Dia08, Var0809,
           Dia09, Var0910,
           Dia10, Var1011,
           Dia11, Var1112,
           Dia12, Var1213,
           Dia13, Var1314,
           Dia14, Var1415,
           Dia15, Var1516,
           Dia16, Var1617,
           Dia17, Var1718,
           Dia18, Var1819,
           Dia19, Var1920,
           Dia20, Var2021,
           Dia21, Var2122,
           Dia22, Var2223,
           Dia23, Var2324,
           Dia24, Var2425,
           Dia25, Var2526,
           Dia26, Var2627,
           Dia27, Var2728,
           Dia28, Var2829,
           Dia29, Var2930,
           Dia30, Var3031,
           Dia31, Per0031,
           RiscoID, Risco
    FROM @Tempor
    ORDER BY Ordem ASC, Tipo ASC, TipoLinha ASC, Apelido ASC;

          
END;
GO
/****** Object:  StoredProcedure [dbo].[stpVariacaoMensalInvestimentos]    Script Date: 05/01/2022 12:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/********************************************************
 Procedure stpVariacaoMensalInvestimentos

 Elcio Reis - 27/08/2019
 Cria uma "planilha" com os valor dos investimentos dos 
 útimos 18 meses.

 Elcio Reis - 18/09/2019
 Inclusão de contas de câmbio
 
 Elcio Reis - 03/10/2019
 Alteração na rotina de valoração das moedas de câmbio

 Os valores apresentados são referentes à última cotação
 do mês.
 Se a data de referência não for informada, utilizará a
 data corrente.

 Exemplo de execução
 EXEC stpVariacaoMensalInvestimentos 2, '2019-10-03'
 ********************************************************/

CREATE PROCEDURE [dbo].[stpVariacaoMensalInvestimentos] (@UsuarioID INT, @DataReferencia DATE = NULL)
AS
    DECLARE @InicioMes DATE;
    DECLARE @FimMes DATE;
BEGIN

    IF (@DataReferencia IS NULL)
    BEGIN
        SET @DataReferencia = GETDATE();
    END;

    SET @DataReferencia = EOMONTH(@DataReferencia);

    DECLARE @MoedaPadraoID INT;
    DECLARE @Simbolo VARCHAR(10);

    SELECT @MoedaPadraoID = MoedaID,
           @Simbolo = TRIM(Simbolo)
    FROM Moeda 
    WHERE Padrao = 1;

    DECLARE @Meses TABLE (Indice SMALLINT, Mes SMALLINT, Inicio DATE, Fim DATE, DiaSeguinte DATE);
    DECLARE @Indice SMALLINT = 13;

    SET @FimMes = DATEADD(DAY, 1, @DataReferencia);

    WHILE (@Indice > 0)
    BEGIN

        SET @FimMes = EOMONTH(@FimMes, -1);
        SET @InicioMes = DATEADD(DAY, 1, EOMONTH(@FimMes, -1));

        INSERT INTO @Meses 
        (Indice, Mes, Inicio, Fim, DiaSeguinte)
        VALUES 
        (@Indice, @Indice, @InicioMes, @FimMes, DATEADD(DAY, 1, @FimMes));

        SET @Indice = @Indice - 1;
    END;

    -- Cria tabela virtual para receber o conteúdo do select principal
    DECLARE @Tempor TABLE (
        Ordem              SMALLINT,
        TipoLinha          SMALLINT,
        InvestimentoID     INT,
        ContaID            INT,
        Tipo               VARCHAR(50),
        Apelido            VARCHAR(50),
        RiscoID            INT,
        Risco              VARCHAR(20),
        Mes01              DECIMAL(10, 2),
        Var0102            SMALLINT,
        Mes02              DECIMAL(10, 2),
        Var0203            SMALLINT,
        Mes03              DECIMAL(10, 2),
        Var0304            SMALLINT,
        Mes04              DECIMAL(10, 2),
        Var0405            SMALLINT,
        Mes05              DECIMAL(10, 2),
        Var0506            SMALLINT,
        Mes06              DECIMAL(10, 2),
        Var0607            SMALLINT,
        Mes07              DECIMAL(10, 2),
        Var0708            SMALLINT,
        Mes08              DECIMAL(10, 2),
        Var0809            SMALLINT,
        Mes09              DECIMAL(10, 2),
        Var0910            SMALLINT,
        Mes10              DECIMAL(10, 2),
        Var1011            SMALLINT,
        Mes11              DECIMAL(10, 2),
        Var1112            SMALLINT,
        Mes12              DECIMAL(10, 2),
        Var1213            SMALLINT,
        Perc1213           DECIMAL(14, 6),
        Mes13              DECIMAL(10, 2),
        DataReferencia     DATE
    );

    DECLARE @EspacoSimpl VARCHAR(10) = '      ';

    WITH Fase01 AS (SELECT 0 Ordem,
                           NMes.Mes, Ivst.InvestimentoID, Cnta.ContaID, ---Cnta.Apelido Conta,
                           Ivst.Apelido, Tipo.Apelido AS Tipo, Tipo.Fundo, Tipo.Acao,
                           ---SUM(COALESCE(Mvto.QtCotas, 0)) AS QtCotas, 
                           ---Cota.VrCotacao, Cota.Data,
                           dbo.fncSaldoInvestimentoLiquido(Ivst.InvestimentoID, Cota.Data, 1) AS Valor,
                           Rsco.RiscoID, Rsco.Apelido Risco
                    FROM @Meses NMes
                         JOIN Investimento Ivst ON 1 = 1
                         JOIN TipoInvestimento Tipo ON Tipo.TipoInvestimentoID = Ivst.TipoInvestimentoID
                         JOIN Risco Rsco ON Rsco.RiscoID = Ivst.RiscoID
                         JOIN MovimentoInvestimento Mvto ON Mvto.InvestimentoID = Ivst.InvestimentoID
                         JOIN MovimentoConta MCta ON MCta.MovimentoContaID = Mvto.MovimentoContaID
                                                 AND CAST(MCta.Data AS DATE) <= NMes.Fim
                         JOIN Conta Cnta ON Cnta.ContaID = MCta.ContaID
                         JOIN InvestimentoCotacao Cota ON Cota.InvestimentoID = Ivst.InvestimentoID
                                                      AND Cota.Data = (SELECT MAX(Data) 
                                                                       FROM InvestimentoCotacao 
                                                                       WHERE InvestimentoID = Ivst.InvestimentoID 
                                                                       AND   Data <= NMes.Fim)
                    GROUP BY NMes.Mes, Ivst.InvestimentoID, Cnta.ContaID, Cnta.Apelido, Ivst.Apelido, Tipo.Apelido, Tipo.Fundo, Tipo.Acao,
                             Cota.Data, /* Cota.VrCotacao, */ Rsco.RiscoID, Rsco.Apelido
                    HAVING SUM(COALESCE(Mvto.QtCotas, 0)) <> 0

                    UNION ALL

                    SELECT 2 Ordem, 
                           NMes.Mes, 0 AS InvestimentoID, Cnta.ContaID, ---Cnta.Apelido Conta, 
                           Cnta.Apelido, 'Poupança' AS Tipo, CAST(0 AS BIT) Fundo, CAST(0 AS BIT) Acao,
                           ---NULL as QtCotas, 
                           ---NULL AS VrCotacao, CAST(MAX(Mvto.Data) AS DATE) AS Data,
                           SUM(Valor) AS Valor, Rsco.RiscoID, Rsco.Apelido Risco
                    FROM @Meses NMes
                         JOIN Conta Cnta ON 1 = 1
                         JOIN Risco Rsco ON Rsco.RiscoID = 1
                         JOIN TipoConta TCnt ON TCnt.TipoContaID = Cnta.TipoContaID 
                                            AND TCnt.Poupanca = 1
                         JOIN MovimentoConta Mvto ON Mvto.ContaID = Cnta.ContaID 
                                                 AND CAST(Mvto.Data AS DATE) <= NMes.Fim
                    GROUP BY NMes.Mes, Cnta.ContaID, Cnta.Apelido, Rsco.RiscoID, Rsco.Apelido
                    
                    ---- Inclusão de contas de câmbio                    

                    UNION ALL

                    SELECT 3 Ordem, 
                           NMes.Mes, 0 AS InvestimentoID, Cnta.ContaID, ---Cnta.Apelido Conta, 
                           TRIM(Cnta.Apelido) + ' (em ' + @Simbolo + ')' Apelido, 'Câmbio' AS Tipo, CAST(0 AS BIT) Fundo, CAST(0 AS BIT) Acao,
                           dbo.fncSaldoContaEmMoedaPadrao(Cnta.ContaID, NMes.Fim) Valor,
                           --SUM(Mvto.Valor * CtcM.Cotacao) Valor, 
                           Rsco.RiscoID, Rsco.Apelido Risco
                    FROM @Meses NMes
                         JOIN Conta Cnta ON 1 = 1
                         JOIN Risco Rsco ON Rsco.RiscoID = 5
                         JOIN TipoConta TCnt ON TCnt.TipoContaID = Cnta.TipoContaID 
                                            AND TCnt.Cambio = 1
                         --JOIN MovimentoConta Mvto WITH (INDEX(IX_MovimentoConta_ContaID_Data))
                         --                           ON Mvto.ContaID = Cnta.ContaID 
                         --                          AND Mvto.Data < NMes.DiaSeguinte
                         --JOIN CotacaoMoeda CtcM WITH (INDEX(IX_CotacaoMoeda_UltimaCotacao_DeMoedaID_ParaMoedaID_Data))
                         --                         ON CtcM.UltimaCotacao = 1
                         --                        AND CtcM.DeMoedaID = Cnta.MoedaID
                         --                        AND CtcM.ParaMoedaID = @MoedaPadraoID
                         --                        AND CtcM.Data = (SELECT MAX(Moeda.Data)
                         --                                         FROM CotacaoMoeda Moeda WITH (INDEX(IX_CotacaoMoeda_UltimaCotacao_DeMoedaID_ParaMoedaID_Data))
                         --                                         WHERE Moeda.UltimaCotacao = 1
                         --                                         AND   Moeda.DeMoedaID = Cnta.MoedaID
                         --                                         AND   Moeda.ParaMoedaID = @MoedaPadraoID
                         --                                         AND   Moeda.Data < NMes.DiaSeguinte)
                    WHERE Cnta.Ativo = 1),
                    --GROUP BY NMes.Mes, Cnta.ContaID, Cnta.Apelido, Rsco.RiscoID, Rsco.Apelido),
         Fase02 AS (SELECT 2 TipoLinha, F01.Ordem, F01.Mes, F01.InvestimentoID, F01.ContaID, @EspacoSimpl + F01.Apelido Apelido, F01.Tipo, F01.Valor,
                           F01.RiscoID, F01.Risco
                    FROM Fase01 F01
                    
                    UNION ALL

                    SELECT 1 TipoLinha, F01.Ordem, F01.Mes, 0 IvestimentoID, 0 ContaID, 'Total ' + F01.Tipo Apelido, F01.Tipo, SUM(F01.Valor) Valor,
                           NULL RiscoID, NULL Risco
                    FROM Fase01 F01
                    GROUP BY F01.Ordem, F01.Mes, F01.Tipo

                    UNION ALL

                    SELECT 3 TipoLinha, 1 Ordem, F01.Mes, 0 IvestimentoID, 0 ContaID, 'Total Fundos' Apelido, NULL Tipo, SUM(F01.Valor) Valor,
                           NULL RiscoID, NULL Risco
                    FROM Fase01 F01
                    WHERE F01.InvestimentoID <> 0
                    GROUP BY F01.Ordem, F01.Mes

                    UNION ALL

                    SELECT 3 TipoLinha, 4 Ordem, F01.Mes, 0 IvestimentoID, 0 ContaID, 'Total Geral' Apelido, NULL Tipo, SUM(F01.Valor) Valor,
                           NULL RiscoID, NULL Risco
                    FROM Fase01 F01
                    GROUP BY F01.Mes)
    INSERT INTO @Tempor
    (Ordem, TipoLinha, InvestimentoID, ContaID, Tipo, Apelido, DataReferencia,
     Mes01, Mes02, Mes03, Mes04, Mes05, Mes06, 
     Mes07, Mes08, Mes09, Mes10, Mes11, Mes12, Mes13,
     RiscoID, Risco)
    SELECT Ordem, TipoLinha, InvestimentoID, ContaID, Tipo, Apelido, @DataReferencia,
            [1] 'Mes01',  [2] 'Mes02',  [3] 'Mes03',  [4] 'Mes04',  [5] 'Mes05',  [6] 'Mes06',  
            [7] 'Mes07',  [8] 'Mes08',  [9] 'Mes09', [10] 'Mes10', [11] 'Mes11', [12] 'Mes12', [13] 'Mes13',
           RiscoID, Risco
    FROM (SELECT Ordem, TipoLinha, Mes, InvestimentoID, ContaID, Apelido, Tipo, RiscoID, Risco, Valor FROM Fase02) Origem
    PIVOT (SUM(Valor) FOR Mes IN (  [1], [2], [3], [4], [5], [6], 
                                    [7], [8], [9],[10],[11],[12],[13])) Final;


    --ORDER BY Ordem ASC, Tipo ASC, TipoLinha ASC, Apelido ASC;

    UPDATE @Tempor
    SET Mes01 = COALESCE(Mes01, 0),
        Mes02 = COALESCE(Mes02, 0),
        Mes03 = COALESCE(Mes03, 0),
        Mes04 = COALESCE(Mes04, 0),
        Mes05 = COALESCE(Mes05, 0),
        Mes06 = COALESCE(Mes06, 0),
        Mes07 = COALESCE(Mes07, 0),
        Mes08 = COALESCE(Mes08, 0),
        Mes09 = COALESCE(Mes09, 0),
        Mes10 = COALESCE(Mes10, 0),
        Mes11 = COALESCE(Mes11, 0),
        Mes12 = COALESCE(Mes12, 0),
        Mes13 = COALESCE(Mes13, 0)
    WHERE TipoLinha IN (1, 3);

    UPDATE @Tempor
    SET Var0102 = CASE WHEN COALESCE(Mes01, 0) <> 0 AND COALESCE(Mes02, 0) <> 0 THEN
                            CASE WHEN Mes01 < Mes02 THEN 1
                                 WHEN Mes01 = Mes02 THEN 0
                                 WHEN Mes01 > Mes02 THEN -1
                            END
                       WHEN COALESCE(Mes01, 0) = 0 AND COALESCE(Mes02, 0) <> 0 THEN 9
                       WHEN COALESCE(Mes01, 0) <> 0 AND COALESCE(Mes02, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var0203 = CASE WHEN COALESCE(Mes02, 0) <> 0 AND COALESCE(Mes03, 0) <> 0 THEN
                            CASE WHEN Mes02 < Mes03 THEN 1
                                 WHEN Mes02 = Mes03 THEN 0
                                 WHEN Mes02 > Mes03 THEN -1
                            END
                       WHEN COALESCE(Mes02, 0) = 0 AND COALESCE(Mes03, 0) <> 0 THEN 9
                       WHEN COALESCE(Mes02, 0) <> 0 AND COALESCE(Mes03, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var0304 = CASE WHEN COALESCE(Mes03, 0) <> 0 AND COALESCE(Mes04, 0) <> 0 THEN
                            CASE WHEN Mes03 < Mes04 THEN 1
                                 WHEN Mes03 = Mes04 THEN 0
                                 WHEN Mes03 > Mes04 THEN -1
                            END
                       WHEN COALESCE(Mes03, 0) = 0 AND COALESCE(Mes04, 0) <> 0 THEN 9
                       WHEN COALESCE(Mes03, 0) <> 0 AND COALESCE(Mes04, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var0405 = CASE WHEN COALESCE(Mes04, 0) <> 0 AND COALESCE(Mes05, 0) <> 0 THEN
                            CASE WHEN Mes04 < Mes05 THEN 1
                                 WHEN Mes04 = Mes05 THEN 0
                                 WHEN Mes04 > Mes05 THEN -1
                            END
                       WHEN COALESCE(Mes04, 0) = 0 AND COALESCE(Mes05, 0) <> 0 THEN 9
                       WHEN COALESCE(Mes04, 0) <> 0 AND COALESCE(Mes05, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var0506 = CASE WHEN COALESCE(Mes05, 0) <> 0 AND COALESCE(Mes06, 0) <> 0 THEN
                            CASE WHEN Mes05 < Mes06 THEN 1
                                 WHEN Mes05 = Mes06 THEN 0
                                 WHEN Mes05 > Mes06 THEN -1
                            END
                       WHEN COALESCE(Mes05, 0) = 0 AND COALESCE(Mes06, 0) <> 0 THEN 9
                       WHEN COALESCE(Mes05, 0) <> 0 AND COALESCE(Mes06, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var0607 = CASE WHEN COALESCE(Mes06, 0) <> 0 AND COALESCE(Mes07, 0) <> 0 THEN
                            CASE WHEN Mes06 < Mes07 THEN 1
                                 WHEN Mes06 = Mes07 THEN 0
                                 WHEN Mes06 > Mes07 THEN -1
                            END
                       WHEN COALESCE(Mes06, 0) = 0 AND COALESCE(Mes07, 0) <> 0 THEN 9
                       WHEN COALESCE(Mes06, 0) <> 0 AND COALESCE(Mes07, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var0708 = CASE WHEN COALESCE(Mes07, 0) <> 0 AND COALESCE(Mes08, 0) <> 0 THEN
                            CASE WHEN Mes07 < Mes08 THEN 1
                                 WHEN Mes07 = Mes08 THEN 0
                                 WHEN Mes07 > Mes08 THEN -1
                            END
                       WHEN COALESCE(Mes07, 0) = 0 AND COALESCE(Mes08, 0) <> 0 THEN 9
                       WHEN COALESCE(Mes07, 0) <> 0 AND COALESCE(Mes08, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var0809 = CASE WHEN COALESCE(Mes08, 0) <> 0 AND COALESCE(Mes09, 0) <> 0 THEN
                            CASE WHEN Mes08 < Mes09 THEN 1
                                 WHEN Mes08 = Mes09 THEN 0
                                 WHEN Mes08 > Mes09 THEN -1
                            END
                       WHEN COALESCE(Mes08, 0) = 0 AND COALESCE(Mes09, 0) <> 0 THEN 9
                       WHEN COALESCE(Mes08, 0) <> 0 AND COALESCE(Mes09, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var0910 = CASE WHEN COALESCE(Mes09, 0) <> 0 AND COALESCE(Mes10, 0) <> 0 THEN
                            CASE WHEN Mes09 < Mes10 THEN 1
                                 WHEN Mes09 = Mes10 THEN 0
                                 WHEN Mes09 > Mes10 THEN -1
                            END
                       WHEN COALESCE(Mes09, 0) = 0 AND COALESCE(Mes10, 0) <> 0 THEN 9
                       WHEN COALESCE(Mes09, 0) <> 0 AND COALESCE(Mes10, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var1011 = CASE WHEN COALESCE(Mes10, 0) <> 0 AND COALESCE(Mes11, 0) <> 0 THEN
                            CASE WHEN Mes10 < Mes11 THEN 1
                                 WHEN Mes10 = Mes11 THEN 0
                                 WHEN Mes10 > Mes11 THEN -1
                            END
                       WHEN COALESCE(Mes10, 0) = 0 AND COALESCE(Mes11, 0) <> 0 THEN 9
                       WHEN COALESCE(Mes10, 0) <> 0 AND COALESCE(Mes11, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var1112 = CASE WHEN COALESCE(Mes11, 0) <> 0 AND COALESCE(Mes12, 0) <> 0 THEN
                            CASE WHEN Mes11 < Mes12 THEN 1
                                 WHEN Mes11 = Mes12 THEN 0
                                 WHEN Mes11 > Mes12 THEN -1
                            END
                       WHEN COALESCE(Mes11, 0) = 0 AND COALESCE(Mes12, 0) <> 0 THEN 9
                       WHEN COALESCE(Mes11, 0) <> 0 AND COALESCE(Mes12, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Var1213 = CASE WHEN COALESCE(Mes12, 0) <> 0 AND COALESCE(Mes13, 0) <> 0 THEN
                            CASE WHEN Mes12 < Mes13 THEN 1
                                 WHEN Mes12 = Mes13 THEN 0
                                 WHEN Mes12 > Mes13 THEN -1
                            END
                       WHEN COALESCE(Mes12, 0) = 0 AND COALESCE(Mes13, 0) <> 0 THEN 9
                       WHEN COALESCE(Mes12, 0) <> 0 AND COALESCE(Mes13, 0) = 0 THEN -9
                       ELSE 0
                  END,
        Perc1213= CASE WHEN COALESCE(Mes12, 0) <> 0 AND COALESCE(Mes13, 0) <> 0 THEN
                             (Mes13 - Mes12) / Mes12
                        WHEN COALESCE(Mes12, 0) = 0 AND COALESCE(Mes13, 0) <> 0 THEN 9999.9999
                        WHEN COALESCE(Mes12, 0) <> 0 AND COALESCE(Mes13, 0) = 0 THEN -9999.9999
                        ELSE NULL
                   END;

    SELECT Ordem, Tipo,
           TipoLinha, InvestimentoID, ContaID, Apelido,
           Mes01, Var0102,
           Mes02, Var0203,
           Mes03, Var0304,
           Mes04, Var0405,
           Mes05, Var0506,
           Mes06, Var0607,
           Mes07, Var0708,
           Mes08, Var0809,
           Mes09, Var0910,
           Mes10, Var1011,
           Mes11, Var1112,
           Mes12, Var1213,
           Mes13, Perc1213,
           RiscoID, Risco, DataReferencia
    FROM @Tempor
    ORDER BY Ordem ASC, Tipo ASC, TipoLinha ASC, Apelido ASC;

END;
GO
/****** Object:  StoredProcedure [dbo].[stpVariacaoUltimosDiasInvestimentos]    Script Date: 05/01/2022 12:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/******************************************************
 Procedure stpVariacaoUltimosDiasInvestimentos
 Elcio Reis - 27/08/2019
 Cria uma "planilha" com a variação diária dos 
 últimos 05 dias úteis

 Elcio Reis - 19/09/2019
 Inclusão de contas de câmbio

 Elcio Reis - 03/10/2019
 Alteração na rotina de valoração das moedas de câmbio

 EXEC stpVariacaoUltimosDiasInvestimentos 2;
 ******************************************************/

CREATE PROCEDURE [dbo].[stpVariacaoUltimosDiasInvestimentos] (@UsuarioID INT, @DataReferencia DATE = NULL)
AS
    DECLARE @Indice TINYINT = 5;
    DECLARE @ListaDatas VARCHAR(63) = '';
BEGIN

    SET NOCOUNT ON;
   
    IF (@DataReferencia IS NULL)
    BEGIN
        SELECT @DataReferencia = dbo.fncUltimaAtualizacaoInvestimentos();
    END;
    
    DECLARE @MoedaPadraoID INT;
    DECLARE @Simbolo VARCHAR(10);

    SELECT @MoedaPadraoID = MoedaID,
           @Simbolo = TRIM(Simbolo)
    FROM Moeda 
    WHERE Padrao = 1;

    -- Cria uma tabela com todos os dias do mês em referência
    DECLARE @Dias TABLE (Indice SMALLINT, Dia DATE, DiaSeguinte DATE);

    WHILE (@Indice > 0)
    BEGIN

        -- Dia 1 = Domingo
        -- Dia 7 = Sábado
        IF (dbo.fncDiaUtil(@DataReferencia) = 1)
        BEGIN
            INSERT INTO @Dias
            (Indice, Dia, DiaSeguinte)
            VALUES
            (@Indice, @DataReferencia, DATEADD(DAY, 1, @DataReferencia));

            SET @Indice = @Indice - 1;

            SET @ListaDatas = CONVERT(VARCHAR(10), @DataReferencia, 112) + ';' + @ListaDatas;
        END;

        SET @DataReferencia = DATEADD(DAY, -1, @DataReferencia);
    END; -- WHILE

    -- Remove o último caracter
    SET @ListaDatas = SUBSTRING(@ListaDatas, 1, LEN(@ListaDatas)-1);

    -- Cria tabela virtual para receber o conteúdo do select principal
    DECLARE @Tempor TABLE (
        Ordem            SMALLINT,
        TipoLinha        SMALLINT,
        InvestimentoID   INT,
        ContaID          INT,
        Tipo             VARCHAR(50),
        Apelido          VARCHAR(50),
        RiscoID          INT,
        Risco            VARCHAR(20),
        Dia01            DECIMAL(10,2),
        VarR0102         DECIMAL(10,2),
        Perc0102         DECIMAL(14,6),
        Dia02            DECIMAL(10,2),
        VarR0203         DECIMAL(10,2),
        Perc0203         DECIMAL(14,6),
        Dia03            DECIMAL(10,2),
        VarR0304         DECIMAL(10,2),
        Perc0304         DECIMAL(14,6),
        Dia04            DECIMAL(10,2),
        VarR0405         DECIMAL(10,2),
        Perc0405         DECIMAL(14,6),
        Dia05            DECIMAL(10,2),
        ListaDatasISO    VARCHAR(45)
    );

    -- O campo TipoLinha recebe o seguinte conteúdo:
    -- 0 - Linha com o saldo do dia anterior
    -- 1 - Total dos grupos entrada e saída
    -- 2 - Detalhes dos grupos entrada e saída
    -- 3 - Saldo final do dia

    DECLARE @EspacoSimpl VARCHAR(10) = '      ';
    DECLARE @EspacoDuplo VARCHAR(20) = @EspacoSimpl + @EspacoSimpl;

    WITH Fase01 AS (SELECT 0 Ordem,
                           Dias.Indice Dia, Ivst.InvestimentoID, Cnta.ContaID,
                           Ivst.Apelido, Tipo.Apelido AS Tipo, Tipo.Fundo, Tipo.Acao,
                           dbo.fncSaldoInvestimentoLiquido(Ivst.InvestimentoID, Cota.Data, 1) Valor,
                           Rsco.RiscoID, Rsco.Apelido Risco
                    FROM @Dias Dias
                         JOIN Investimento Ivst ON 1 = 1
                         JOIN TipoInvestimento Tipo ON Tipo.TipoInvestimentoID = Ivst.TipoInvestimentoID
                         JOIN Risco Rsco ON Rsco.RiscoID = Ivst.RiscoID
                         JOIN MovimentoInvestimento Mvto ON Mvto.InvestimentoID = Ivst.InvestimentoID
                         JOIN MovimentoConta MCta ON MCta.MovimentoContaID = Mvto.MovimentoContaID
                                                 AND CAST(MCta.Data AS DATE) <= Dias.Dia
                         JOIN Conta Cnta ON Cnta.ContaID = MCta.ContaID
                         JOIN InvestimentoCotacao Cota ON Cota.InvestimentoID = Ivst.InvestimentoID
                                                      AND Cota.Data = (SELECT MAX(Data) 
                                                                       FROM InvestimentoCotacao 
                                                                       WHERE InvestimentoID = Ivst.InvestimentoID 
                                                                       AND   Data <= Dias.Dia)
                    GROUP BY Dias.Indice, Ivst.InvestimentoID, Cnta.ContaID, Cnta.Apelido, Ivst.Apelido, Tipo.Apelido, Tipo.Fundo, Tipo.Acao,
                             Cota.Data, Cota.VrCotacao, Rsco.RiscoID, Rsco.Apelido
                    HAVING SUM(COALESCE(Mvto.QtCotas, 0)) <> 0
                    
                    UNION ALL

                    SELECT 2 Ordem, 
                           Dias.Indice Dia, 0 AS InvestimentoID, Cnta.ContaID,
                           Cnta.Apelido, 'Poupança' AS Tipo, CAST(0 AS BIT) Fundo, CAST(0 AS BIT) Acao,
                           SUM(Valor) Valor, Rsco.RiscoID, Rsco.Apelido Risco
                    FROM @Dias Dias
                         JOIN Conta Cnta ON 1 = 1
                         JOIN Risco Rsco ON Rsco.RiscoID = 1
                         JOIN TipoConta TCnt ON TCnt.TipoContaID = Cnta.TipoContaID 
                                            AND TCnt.Poupanca = 1
                         JOIN MovimentoConta Mvto ON Mvto.ContaID = Cnta.ContaID 
                                                 AND CAST(Mvto.Data AS DATE) <= Dias.Dia
                    GROUP BY Dias.Indice, Cnta.ContaID, Cnta.Apelido, Rsco.RiscoID, Rsco.Apelido

---- Inclusão de contas de câmbio                    

                    UNION ALL
                   
                    SELECT 3 Ordem, 
                           Dias.Indice Dia, 0 AS InvestimentoID, Cnta.ContaID,
                           TRIM(Cnta.Apelido) + ' (em ' + @Simbolo + ')' Apelido, 'Câmbio' AS Tipo, CAST(0 AS BIT) Fundo, CAST(0 AS BIT) Acao,
                           dbo.fncSaldoContaEmMoedaPadrao(Cnta.ContaID, Dias.Dia) Valor,
                           Rsco.RiscoID, Rsco.Apelido Risco
                    FROM @Dias Dias
                         JOIN Conta Cnta ON Cnta.Ativo = 1
                         JOIN Risco Rsco ON Rsco.RiscoID = 5
                         JOIN TipoConta TCnt ON TCnt.TipoContaID = Cnta.TipoContaID 
                                            AND TCnt.Cambio = 1
                    WHERE Cnta.Ativo = 1),
         Fase02 AS (SELECT 2 TipoLinha, F01.Ordem, F01.Dia, F01.InvestimentoID, F01.ContaID, @EspacoSimpl + F01.Apelido Apelido, F01.Tipo, F01.Valor,
                           F01.RiscoID, F01.Risco
                    FROM Fase01 F01
                    
                    UNION ALL

                    SELECT 1 TipoLinha, F01.Ordem, F01.Dia, 0 IvestimentoID, 0 ContaID, 'Total ' + F01.Tipo Apelido, F01.Tipo, SUM(F01.Valor) Valor,
                           NULL RiscoID, NULL Risco
                    FROM Fase01 F01
                    GROUP BY F01.Ordem, F01.Dia, F01.Tipo

                    UNION ALL

                    SELECT 3 TipoLinha, 1 Ordem, F01.Dia, 0 IvestimentoID, 0 ContaID, 'Total Fundos' Apelido, NULL Tipo, SUM(F01.Valor) Valor,
                           NULL RiscoID, NULL Risco
                    FROM Fase01 F01
                    WHERE F01.InvestimentoID <> 0
                    GROUP BY F01.Ordem, F01.Dia
                    
                    UNION ALL

                    SELECT 3 TipoLinha, 4 Ordem, F01.Dia, 0 IvestimentoID, 0 ContaID, 'Total Geral' Apelido, NULL Tipo, SUM(F01.Valor) Valor,
                           NULL RiscoID, NULL Risco
                    FROM Fase01 F01
                    GROUP BY F01.Dia)
    INSERT INTO @Tempor
    (Ordem, TipoLinha, InvestimentoID, ContaID, Tipo, Apelido,
     Dia01, Dia02, Dia03, Dia04, Dia05, --Dia06, Dia07, Dia08, Dia09, Dia10, 
     RiscoID, Risco, ListaDatasISO)
    SELECT Ordem, TipoLinha, InvestimentoID, ContaID, Tipo, Apelido,
            [1] 'Dia01',  [2] 'Dia02',  [3] 'Dia03',  [4] 'Dia04',  [5] 'Dia05',
           RiscoID, Risco, @ListaDatas
    FROM (SELECT Ordem, TipoLinha, Dia, InvestimentoID, ContaID, Apelido, Tipo, RiscoID, Risco, Valor FROM Fase02) Origem
    PIVOT (SUM(Valor) FOR Dia IN (  [1], [2], [3], [4], [5])) Final;

    UPDATE @Tempor
    SET VarR0102 = CASE WHEN Dia01 IS NULL AND Dia02 IS NULL THEN NULL
                        ELSE COALESCE(Dia02, 0) - COALESCE(Dia01, 0)
                   END,
        Perc0102 = CASE WHEN Dia01 IS NULL AND Dia02 IS NULL THEN NULL
                        WHEN COALESCE(Dia01, 0) <> 0 AND COALESCE(Dia02, 0) <> 0 THEN
                             (Dia02 - Dia01) / Dia01
                        WHEN COALESCE(Dia01, 0) = 0 AND COALESCE(Dia02, 0) <> 0 THEN 9999.9999
                        WHEN COALESCE(Dia01, 0) <> 0 AND COALESCE(Dia02, 0) = 0 THEN -9999.9999
                        ELSE 0
                   END,
        VarR0203 = CASE WHEN Dia02 IS NULL AND Dia03 IS NULL THEN NULL
                        ELSE COALESCE(Dia03, 0) - COALESCE(Dia02, 0)
                   END,
        Perc0203 = CASE WHEN Dia02 IS NULL AND Dia03 IS NULL THEN NULL
                        WHEN COALESCE(Dia02, 0) <> 0 AND COALESCE(Dia03, 0) <> 0 THEN
                             (Dia03 - Dia02) / Dia02
                        WHEN COALESCE(Dia02, 0) = 0 AND COALESCE(Dia03, 0) <> 0 THEN 9999.9999
                        WHEN COALESCE(Dia02, 0) <> 0 AND COALESCE(Dia03, 0) = 0 THEN -9999.9999
                        ELSE 0
                   END,
        VarR0304 = CASE WHEN Dia03 IS NULL AND Dia04 IS NULL THEN NULL
                        ELSE COALESCE(Dia04, 0) - COALESCE(Dia03, 0)
                   END,
        Perc0304 = CASE WHEN Dia03 IS NULL AND Dia04 IS NULL THEN NULL
                        WHEN COALESCE(Dia03, 0) <> 0 AND COALESCE(Dia04, 0) <> 0 THEN
                             (Dia04 - Dia03) / Dia03
                        WHEN COALESCE(Dia03, 0) = 0 AND COALESCE(Dia04, 0) <> 0 THEN 9999.9999
                        WHEN COALESCE(Dia03, 0) <> 0 AND COALESCE(Dia04, 0) = 0 THEN -9999.9999
                        ELSE 0
                   END,
        VarR0405 = CASE WHEN Dia04 IS NULL AND Dia05 IS NULL THEN NULL
                        ELSE COALESCE(Dia05, 0) - COALESCE(Dia04, 0)
                   END,
        Perc0405 = CASE WHEN Dia04 IS NULL AND Dia05 IS NULL THEN NULL
                        WHEN COALESCE(Dia04, 0) <> 0 AND COALESCE(Dia05, 0) <> 0 THEN
                             (Dia05 - Dia04) / Dia04
                        WHEN COALESCE(Dia04, 0) = 0 AND COALESCE(Dia05, 0) <> 0 THEN 9999.9999
                        WHEN COALESCE(Dia04, 0) <> 0 AND COALESCE(Dia05, 0) = 0 THEN -9999.9999
                        ELSE 0
                   END;

    SELECT Ordem, TipoLInha, InvestimentoID, ContaID, Tipo, Apelido, ListaDatasISO,
           Dia01, VarR0102, Perc0102, 
           Dia02, VarR0203, Perc0203,
           Dia03, VarR0304, Perc0304,
           Dia04, VarR0405, Perc0405,
           Dia05, 
           RiscoID, Risco
    FROM @Tempor
    ORDER BY Ordem ASC, Tipo ASC, TipoLinha ASC, Apelido ASC;

          
END;
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID da Categoria' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categoria', @level2type=N'COLUMN',@level2name=N'CategoriaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuário que criou a categoria' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categoria', @level2type=N'COLUMN',@level2name=N'UsuarioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Apelido da categoria.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categoria', @level2type=N'COLUMN',@level2name=N'Apelido'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descrição da categoria.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categoria', @level2type=N'COLUMN',@level2name=N'Descricao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Chave estrangeira autoreferenciada.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categoria', @level2type=N'COLUMN',@level2name=N'CategoriaPaiID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Informa a qual grupo de categorias a categoria pertence.
É opcional' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categoria', @level2type=N'COLUMN',@level2name=N'GrupoCategoriaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Informa se é crédito ou débito ou branco caso seja transferência.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categoria', @level2type=N'COLUMN',@level2name=N'CrdDeb'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifica a ordem de exibição das categorias pai. 
(categoria cujo campo CategoriaPaiID é nulo).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categoria', @level2type=N'COLUMN',@level2name=N'OrdemVisual'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Define se a categoria é uma conta fixa.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categoria', @level2type=N'COLUMN',@level2name=N'Fixo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Informa se a categoria é ativa ou não.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categoria', @level2type=N'COLUMN',@level2name=N'Ativo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Se a categoria está ligada a uma conta.
Categorias ligadas a contas são usadas para transferência.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categoria', @level2type=N'COLUMN',@level2name=N'ContaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Informa se o registro foi criado pelo sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categoria', @level2type=N'COLUMN',@level2name=N'Sistema'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Categoria dos lançamentos em conta.
Exemplo:
-Alimentação
-Alimentação:Refeição
-Alimentação:Restaurante
-Automóvel
-Automóvel:Combustível' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categoria'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID da Conta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Conta', @level2type=N'COLUMN',@level2name=N'ContaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID do usuário que incluiu a conta.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Conta', @level2type=N'COLUMN',@level2name=N'UsuarioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Instituição onde a conta é mantida.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Conta', @level2type=N'COLUMN',@level2name=N'InstituicaoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de conta.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Conta', @level2type=N'COLUMN',@level2name=N'TipoContaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Moeda utilizada nessa conta.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Conta', @level2type=N'COLUMN',@level2name=N'MoedaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Apelido da conta.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Conta', @level2type=N'COLUMN',@level2name=N'Apelido'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descrição da conta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Conta', @level2type=N'COLUMN',@level2name=N'Descricao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data de abertura.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Conta', @level2type=N'COLUMN',@level2name=N'DataAbertura'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Saldo na abertura da conta.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Conta', @level2type=N'COLUMN',@level2name=N'SaldoInicial'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Limite da conta.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Conta', @level2type=N'COLUMN',@level2name=N'Limite'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Informa se a conta é ativa ou não.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Conta', @level2type=N'COLUMN',@level2name=N'Ativo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contas do sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Conta'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID do Grupo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GrupoCategoria', @level2type=N'COLUMN',@level2name=N'GrupoCategoriaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuário que criou o grupo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GrupoCategoria', @level2type=N'COLUMN',@level2name=N'UsuarioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Apelido do grupo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GrupoCategoria', @level2type=N'COLUMN',@level2name=N'Apelido'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descrição do grupo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GrupoCategoria', @level2type=N'COLUMN',@level2name=N'Descricao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Informa se o grupo está ou não ativo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GrupoCategoria', @level2type=N'COLUMN',@level2name=N'Ativo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Grupo de categorias.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GrupoCategoria'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID do Grupo de Conta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GrupoConta', @level2type=N'COLUMN',@level2name=N'GrupoContaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuário que criou o grupo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GrupoConta', @level2type=N'COLUMN',@level2name=N'UsuarioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descrição do grupo de contas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GrupoConta', @level2type=N'COLUMN',@level2name=N'Descricao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ordem de apresentação em tela.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GrupoConta', @level2type=N'COLUMN',@level2name=N'Ordem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Define se ativo ou não.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GrupoConta', @level2type=N'COLUMN',@level2name=N'Ativo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Grupo para agrupamento do tipo de contas:
-Disponível
-Crédito
-Reserva' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GrupoConta'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID da instituição' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Instituicao', @level2type=N'COLUMN',@level2name=N'InstituicaoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuário que incluiu a instituição.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Instituicao', @level2type=N'COLUMN',@level2name=N'UsuarioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifica o tipo de instituição financeira.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Instituicao', @level2type=N'COLUMN',@level2name=N'TipoInstituicaoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Apelido da Instituição' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Instituicao', @level2type=N'COLUMN',@level2name=N'Apelido'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descrição da instituição' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Instituicao', @level2type=N'COLUMN',@level2name=N'Descricao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número do banco, conforme FEBRABAN
(preencher apenas se for banco)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Instituicao', @level2type=N'COLUMN',@level2name=N'Banco'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Informa se o banco está ou não ativo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Instituicao', @level2type=N'COLUMN',@level2name=N'Ativo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Instituições financeiras' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Instituicao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID do lançamento.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lancamento', @level2type=N'COLUMN',@level2name=N'LancamentoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuário que incluiu o lançamento.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lancamento', @level2type=N'COLUMN',@level2name=N'UsuarioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Apelido do lançamento.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lancamento', @level2type=N'COLUMN',@level2name=N'Apelido'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descrição do lançamento.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lancamento', @level2type=N'COLUMN',@level2name=N'Descricao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Define se é ou não um lançamento ativo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lancamento', @level2type=N'COLUMN',@level2name=N'Ativo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Informa se é um lançamento criado pelo sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lancamento', @level2type=N'COLUMN',@level2name=N'Sistema'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Pessoas ou empresas com quem fazemos negócios.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lancamento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id da Moeda' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Moeda', @level2type=N'COLUMN',@level2name=N'MoedaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Apelido da Moeda' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Moeda', @level2type=N'COLUMN',@level2name=N'Apelido'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Símbolo da moeda' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Moeda', @level2type=N'COLUMN',@level2name=N'Simbolo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica a moeda padrão do sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Moeda', @level2type=N'COLUMN',@level2name=N'Padrao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID do movimento ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovimentoConta', @level2type=N'COLUMN',@level2name=N'MovimentoContaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuário que lançou o movimento.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovimentoConta', @level2type=N'COLUMN',@level2name=N'UsuarioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Conta a que o movimento pertence.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovimentoConta', @level2type=N'COLUMN',@level2name=N'ContaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data do lançamento.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovimentoConta', @level2type=N'COLUMN',@level2name=N'Data'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descrição numérica, como número do cheque ou do boleto.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovimentoConta', @level2type=N'COLUMN',@level2name=N'Numero'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Lançamento ou parceiro do movimento.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovimentoConta', @level2type=N'COLUMN',@level2name=N'LancamentoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descrição do lançamento.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovimentoConta', @level2type=N'COLUMN',@level2name=N'Descricao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Categoria do lançamento.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovimentoConta', @level2type=N'COLUMN',@level2name=N'CategoriaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Informa uma possível segunda categoria para o lançamento.
Por exemplo: despesas com trabalho.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovimentoConta', @level2type=N'COLUMN',@level2name=N'GrupoCategoriaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Define se é crédito ou débito.
(diferente do utilizado na categoria)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovimentoConta', @level2type=N'COLUMN',@level2name=N'CrdDeb'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Crédito do lançamento, se CrdDeb = ''C''' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovimentoConta', @level2type=N'COLUMN',@level2name=N'Credito'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Débito do lançamento, se CrdDeb = ''D''' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovimentoConta', @level2type=N'COLUMN',@level2name=N'Debito'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor acumulado com a somatória de todos os créditos menos todos os débitos.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovimentoConta', @level2type=N'COLUMN',@level2name=N'Balanco'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Branco - Não conciliado
C - Conciliado
R - Reconciliado' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovimentoConta', @level2type=N'COLUMN',@level2name=N'Conciliacao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica a ordem de processamento de todos os lançamentos.
Cada conta tem sua pilha iniciando do ZERO, que é o lançamento de abertura.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovimentoConta', @level2type=N'COLUMN',@level2name=N'PilhaMovimentoContaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Se o movimento for uma transferência, haverá uma contrapartida na outra conta.
Se débito na conta A, crédito na conta B.
Se crédito na conta A, débito na conta B.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovimentoConta', @level2type=N'COLUMN',@level2name=N'DoMovimentoContaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Informa se o lançamento foi criado pelo sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovimentoConta', @level2type=N'COLUMN',@level2name=N'Sistema'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Movimentação de conta.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MovimentoConta'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID do Tipo de Conta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoConta', @level2type=N'COLUMN',@level2name=N'TipoContaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Grupo de Contas.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoConta', @level2type=N'COLUMN',@level2name=N'GrupoContaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuário que criou o tipo de conta.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoConta', @level2type=N'COLUMN',@level2name=N'UsuarioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Apelido do Tipo de Conta.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoConta', @level2type=N'COLUMN',@level2name=N'Apelido'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descrição do tipo de conta.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoConta', @level2type=N'COLUMN',@level2name=N'Descricao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de Conta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoConta'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID do Tipo Instituição' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoInstituicao', @level2type=N'COLUMN',@level2name=N'TipoInstituicaoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuário que criou o tipo de instituição.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoInstituicao', @level2type=N'COLUMN',@level2name=N'UsuarioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Apelido do Tipo de Instituição' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoInstituicao', @level2type=N'COLUMN',@level2name=N'Apelido'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descrição do tipo de instituição.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoInstituicao', @level2type=N'COLUMN',@level2name=N'Descricao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Define se o tipo de instituição é ativo ou inativo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoInstituicao', @level2type=N'COLUMN',@level2name=N'Ativo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID do tipo de investimento.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoInvestimento', @level2type=N'COLUMN',@level2name=N'TipoInvestimentoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuário que cadastrou o tipo de investimento.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoInvestimento', @level2type=N'COLUMN',@level2name=N'UsuarioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Apelido do tipo de investimento.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoInvestimento', @level2type=N'COLUMN',@level2name=N'Apelido'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descrição do tipo de investimento.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoInvestimento', @level2type=N'COLUMN',@level2name=N'Descricao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Define se o tipo de investimento é ativo ou não.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoInvestimento', @level2type=N'COLUMN',@level2name=N'Ativo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipos de investimentos.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoInvestimento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID do Usuário' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario', @level2type=N'COLUMN',@level2name=N'UsuarioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Apelido do usuário' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario', @level2type=N'COLUMN',@level2name=N'Apelido'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nome do usuário' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario', @level2type=N'COLUMN',@level2name=N'Nome'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Senha do usuário
(a senha é armazenada em MD5)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario', @level2type=N'COLUMN',@level2name=N'Senha'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Email do usuário' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Informa se o usuário é ativo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario', @level2type=N'COLUMN',@level2name=N'Ativo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Informa se o usuário é o administrador do sistema' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario', @level2type=N'COLUMN',@level2name=N'Sistema'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Relação de usuários do sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario'
GO
USE [master]
GO
ALTER DATABASE [MoneyPro] SET  READ_WRITE 
GO
