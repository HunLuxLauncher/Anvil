USE [Anvil.Test]
GO

/****** Object:  Table [dbo].[Packs]    Script Date: 2021. 09. 24. 16:00:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Packs]') AND type in (N'U'))
DROP TABLE [dbo].[Packs]
GO

/****** Object:  Table [dbo].[Packs]    Script Date: 2021. 09. 24. 16:00:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Packs](
	[Id] [varchar](64) NOT NULL,
	[Name] [varchar](256) NOT NULL,
	[Creator] [varchar](24) NOT NULL,
	[Contributors] [varchar](1024) NULL,
	[IconAssetUrl] [varchar](1024) NULL,
	[IconAssetHash] [varchar](40) NULL,
	[LogoAssetUrl] [varchar](1024) NULL,
	[LogoAssetHash] [varchar](40) NULL,
	[BackgroundAssetUrl] [varchar](1024) NULL,
	[BackgroundAssetHash] [varchar](40) NULL,
	[VisibleOnPublicList] [bit] NULL,
 CONSTRAINT [PK_PackId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


