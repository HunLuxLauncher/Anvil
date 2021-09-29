USE [Anvil.Test]
GO

/****** Object:  Table [dbo].[ModVersions]    Script Date: 2021. 09. 28. 22:11:46 ******/
SET ANSI_NULLS ON
GO

/****** Object:  Table [dbo].[PackNews]    Script Date: 2021. 09. 25. 14:25:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ModVersions]') AND type in (N'U'))
DROP TABLE [dbo].[PackNews]
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
	[Hash] [varchar](40) NULL,
 CONSTRAINT [PK_ModVersions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ModVersions]  WITH CHECK ADD  CONSTRAINT [FK_ModVersions_ModId] FOREIGN KEY([ModId])
REFERENCES [dbo].[Mods] ([Id])
GO

ALTER TABLE [dbo].[ModVersions] CHECK CONSTRAINT [FK_ModVersions_ModId]
GO


