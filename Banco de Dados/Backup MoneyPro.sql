USE master;

DECLARE @DESTINO VARCHAR(MAX);
DECLARE @DIA DATETIME = DATEADD(DAY, -10, GETDATE());

EXEC msdb.dbo.sp_delete_backuphistory @DIA;

-- Backup MoneyPro

-- Gera nome de arquivo no formato C:\Backup\MoneyPro_240609-0547.bak
SET @DESTINO = 'C:\Backup\MoneyPro_' + CONVERT(VARCHAR(6), GETDATE(), 12) + '-' + REPLACE(CONVERT(VARCHAR(5), GETDATE(), 8), ':', '') + '.bak'; 
BACKUP DATABASE [MoneyPro] TO  DISK = @DESTINO WITH NOFORMAT, INIT,  NAME = N'MoneyPro-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10;

