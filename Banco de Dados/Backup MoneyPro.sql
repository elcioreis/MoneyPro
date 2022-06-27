USE master;

DECLARE @DESTINO VARCHAR(MAX);
DECLARE @DIA DATETIME = DATEADD(DAY, -10, GETDATE());

EXEC msdb.dbo.sp_delete_backuphistory @DIA;

--- Backup MoneyPro
SET @DESTINO = 'C:\Users\Elcio\Dropbox\Backup\MoneyPro_' + CONVERT(VARCHAR(10), GETDATE(), 12) + '.bak'; 
BACKUP DATABASE [MoneyPro] TO  DISK = @DESTINO WITH NOFORMAT, INIT,  NAME = N'MoneyPro-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10;

--- Backuo MoneyPro_Devel
--- SET @DESTINO = 'C:\Users\Elcio\Dropbox\Backup\MoneyPro_Devel_' + CONVERT(VARCHAR(10), GETDATE(), 12) + '.bak'; 
--- BACKUP DATABASE [MoneyPro_Devel] TO  DISK = @DESTINO WITH NOFORMAT, INIT,  NAME = N'MoneyPro_Devel-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10;
