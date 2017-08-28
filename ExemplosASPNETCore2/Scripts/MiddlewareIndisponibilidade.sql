CREATE TABLE [dbo].[Indisponibilidade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InicioIndisponibilidade] [datetime] NOT NULL,
	[TerminoIndisponibilidade] [datetime] NULL,
	[Mensagem] [varchar](MAX) NOT NULL,
 CONSTRAINT [PK_Indisponibilidade] PRIMARY KEY ([Id])
)
GO