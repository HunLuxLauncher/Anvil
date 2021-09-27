USE [Anvil.Test]
GO

--ALTER TABLE [dbo].[PackVersions] DROP CONSTRAINT [CK_PackVersion_Type-Enum]
--GO

--ALTER TABLE [dbo].[PackVersions] DROP CONSTRAINT [FK_PackVersions_PackId]
--GO

--ALTER TABLE [dbo].[PackVersions] DROP CONSTRAINT [DF__PackVersio__Type__1DB06A4F]
--GO

--ALTER TABLE [dbo].[PackVersions] DROP CONSTRAINT [DF__PackVersi__Relea__1CBC4616]
--GO

--ALTER TABLE [dbo].[PackVersions] DROP CONSTRAINT [DF__PackVersi__Updat__1BC821DD]
--GO

/****** Object:  Table [dbo].[PackVersions]    Script Date: 2021. 09. 24. 19:54:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PackVersions]') AND type in (N'U'))
DROP TABLE [dbo].[PackVersions]
GO

/****** Object:  Table [dbo].[PackVersions]    Script Date: 2021. 09. 24. 19:54:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PackVersions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PackId] [varchar](64) NULL,
	[Name] [varchar](32) NULL,
	[UpdateTime] [datetime] NULL,
	[ReleaseTime] [datetime] NULL,
	[Type] [varchar](50) NOT NULL,
	[Hash] [varchar](40) NULL,
 CONSTRAINT [PK_PackVersionId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UK_UniquePackWithVersion] UNIQUE NONCLUSTERED 
(
	[PackId] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PackVersions] ADD  DEFAULT (getdate()) FOR [UpdateTime]
GO

ALTER TABLE [dbo].[PackVersions] ADD  DEFAULT (getdate()) FOR [ReleaseTime]
GO

ALTER TABLE [dbo].[PackVersions] ADD  DEFAULT ('Stable') FOR [Type]
GO

ALTER TABLE [dbo].[PackVersions]  WITH CHECK ADD  CONSTRAINT [FK_PackVersions_PackId] FOREIGN KEY([PackId])
REFERENCES [dbo].[Packs] ([Id])
GO

ALTER TABLE [dbo].[PackVersions] CHECK CONSTRAINT [FK_PackVersions_PackId]
GO

ALTER TABLE [dbo].[PackVersions]  WITH CHECK ADD  CONSTRAINT [CK_PackVersion_Type-Enum] CHECK  (([Type]='Dev' OR [Type]='Beta' OR [Type]='Preview' OR [Type]='Stable'))
GO

ALTER TABLE [dbo].[PackVersions] CHECK CONSTRAINT [CK_PackVersion_Type-Enum]
GO


