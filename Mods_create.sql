USE [Anvil.Test]
GO

/****** Object:  Table [dbo].[Mods]    Script Date: 2021. 09. 24. 21:38:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Mods](
	[Id] [varchar](64) NOT NULL,
	[Name] [varchar](64) NULL,
	[Description] [varchar](1024) NULL,
	[Author] [varchar](64) NULL,
	[UpdateUrl] [varchar](512) NULL,
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Mods]  WITH CHECK ADD  CONSTRAINT [FK_Mods_ModId] PRIMARY KEY ([Id])
GO
