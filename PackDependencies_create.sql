USE [Anvil.Test]
GO

/****** Object:  Table [dbo].[PackVersions]    Script Date: 2021. 09. 24. 19:54:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PackDependencies]') AND type in (N'U'))
DROP TABLE [dbo].[PackDependencies]
GO

/****** Object:  Table [dbo].[PackDependencies]    Script Date: 2021. 09. 24. 19:54:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PackDependencies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PackId] [varchar](64) NULL,
	[PackVersionId] [int] NULL,
	[ModId] [varchar](64) NULL,
	[ModVersionId] [int] NULL,
 CONSTRAINT [PK_PackDependencies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PackDependencies]  WITH CHECK ADD  CONSTRAINT [FK_PackDependencies_PackId] FOREIGN KEY([PackId])
REFERENCES [dbo].[Packs] ([Id])
GO

ALTER TABLE [dbo].[PackDependencies]  WITH CHECK ADD  CONSTRAINT [FK_PackDependencies_VersionId] FOREIGN KEY([PackVersionId])
REFERENCES [dbo].[PackVersions] ([Id])
GO

ALTER TABLE [dbo].[PackDependencies]  WITH CHECK ADD  CONSTRAINT [FK_PackDependencies_ModId] FOREIGN KEY([ModId])
REFERENCES [dbo].[Mods] ([Id])
GO

ALTER TABLE [dbo].[PackDependencies]  WITH CHECK ADD  CONSTRAINT [FK_PackDependencies_ModVersionId] FOREIGN KEY([ModVersionId])
REFERENCES [dbo].[ModVersions] ([Id])
GO