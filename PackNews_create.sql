USE [Anvil.Test]
GO

/****** Object:  Table [dbo].[PackNews]    Script Date: 2021. 09. 25. 14:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PackNews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PackId] [varchar](64) NULL,
	[VersionId] [int] NULL,
	[Title] [varchar](256) NULL,
	[Description] [text] NULL,
	[Author] [varchar](64) NULL,
	[Avatar] [varchar](512) NULL,
	[PostTime] [datetime] NULL,
	[Url] [varchar](512) NULL,
	[OnlyIn] [varchar](40) NULL,
 CONSTRAINT [PK_PackNews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


