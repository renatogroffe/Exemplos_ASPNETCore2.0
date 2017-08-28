CREATE TABLE dbo.Cotacoes(
	Sigla char(3) NOT NULL,
	Nome_Moeda varchar(30) NOT NULL,
	Ultima_Cotacao datetime NOT NULL,
	Valor_Comercial numeric (18,4) NOT NULL,
	Valor_Turismo numeric (18,4) NULL,
	CONSTRAINT PK_Cotacoes PRIMARY KEY (Sigla)
)
GO


INSERT INTO dbo.Cotacoes
           (Sigla
           ,Nome_Moeda
           ,Ultima_Cotacao
           ,Valor_Comercial
		   ,Valor_Turismo)
     VALUES
           ('USD'
           ,'Dólar norte-americano'
           ,'25.08.2017 16:59'
           ,3.1544
		   ,3.2800)

INSERT INTO dbo.Cotacoes
           (Sigla
           ,Nome_Moeda
           ,Ultima_Cotacao
           ,Valor_Comercial)
     VALUES
           ('EUR'
           ,'Euro'
           ,'25.08.2017 16:59'
           ,3.7703)

INSERT INTO dbo.Cotacoes
           (Sigla
           ,Nome_Moeda
           ,Ultima_Cotacao
           ,Valor_Comercial)
     VALUES
           ('LIB'
           ,'Libra esterlina'
           ,'25.08.2017 16:59'
           ,4.0741)