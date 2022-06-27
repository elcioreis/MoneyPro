-- Insere o usuário Admin, com senha 1234 no banco de dados.

INSERT INTO [dbo].[Usuario]
           ([Apelido],[Nome],[Senha],[Email],[Ativo],[Sistema])
     VALUES
           ('Admin', 'Administrador do Sistema', '8D71456BB10974A84B054B3FB5A24447', NULL, 1, 1)
GO
