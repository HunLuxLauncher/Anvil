USE [Anvil.Test]
GO

/****** Object:  Table [dbo].[ModVersions]    Script Date: 2021. 09. 24. 21:38:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ModVersions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModId] [varchar](64) NULL,
	[Name] [varchar](64) NULL,
	[GameVersion] [varchar](16) NULL,
	[ReleaseTime] [datetime] NULL,
	[Type] [varchar](40) NULL,
	[Hash] [varchar](40) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ModVersions]  WITH CHECK ADD  CONSTRAINT [FK_ModVersions_ModId] FOREIGN KEY([ModId])
REFERENCES [dbo].[Mods] ([Id])
GO
