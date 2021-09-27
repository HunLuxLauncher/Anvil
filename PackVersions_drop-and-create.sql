USE [Anvil.Test]
GO

--ALTER TABLE [dbo].[PackVersions] DROP CONSTRAINT [FK_PackVersions_PackId]
--GO

--ALTER TABLE [dbo].[PackVersions] DROP CONSTRAINT [UK_UniquePackWithVersion]
--GO

--ALTER TABLE [dbo].[PackVersions] DROP CONSTRAINT [CK_PackVersion_Type-Enum]
--GO

--ALTER TABLE [dbo].[PackVersions] DROP CONSTRAINT [CK_PackVersion_Type-Default]
--GO

--ALTER TABLE [dbo].[PackVersions] DROP CONSTRAINT [CK_PackVersion_ReleaseTime-Default]
--GO

--ALTER TABLE [dbo].[PackVersions] DROP CONSTRAINT [CK_PackVersion_UpdateTime-Default]
--GO

/****** Object:  Table [dbo].[PackVersions]    Script Date: 2021. 09. 24. 16:15:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PackVersions]') AND type in (N'U'))
DROP TABLE [dbo].[PackVersions]
GO

/****** Object:  Table [dbo].[PackVersions]    Script Date: 2021. 09. 24. 16:15:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PackVersions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PackId] [varchar](64) NULL,
	[Name] [varchar](16) NULL,
	[UpdateTime] [datetime] NULL DEFAULT CURRENT_TIMESTAMP,
	[ReleaseTime] [datetime] NULL DEFAULT CURRENT_TIMESTAMP,
	[Type] [varchar](50) NOT NULL DEFAULT 'Stable',
	[Hash] [varchar](40) NULL,
 CONSTRAINT [PK_PackVersionId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--- Add foreign key for [PackId], that references [Packs].[Id]
ALTER TABLE [dbo].[PackVersions]  WITH CHECK ADD  CONSTRAINT [FK_PackVersions_PackId] PRIMARY KEY([Id])
GO

--- Add foreign key for [PackId], that references [Packs].[Id]
ALTER TABLE [dbo].[PackVersions]  WITH CHECK ADD  CONSTRAINT [FK_PackVersions_PackId] FOREIGN KEY([PackId]) REFERENCES [dbo].[Packs] ([Id])
GO

ALTER TABLE [dbo].[PackVersions] CHECK CONSTRAINT [FK_PackVersions_PackId]
GO

--- Add check for version name to be unique
ALTER TABLE [dbo].[PackVersions] WITH CHECK ADD CONSTRAINT [UK_UniquePackWithVersion] UNIQUE ([PackId], [Name])
GO

--- Add check for [Type]
ALTER TABLE [dbo].[PackVersions]  WITH CHECK ADD  CONSTRAINT [CK_PackVersion_Type-Enum] CHECK  (([Type]='Dev' OR [Type]='Beta' OR [Type]='Preview' OR [Type]='Stable'))
GO

ALTER TABLE [dbo].[PackVersions] CHECK CONSTRAINT [CK_PackVersion_Type-Enum]
GO

-- Add default date to [Type]
ALTER TABLE [dbo].[PackVersions] WITH CHECK ADD CONSTRAINT [CK_PackVersion_Type-Default] DEFAULT ('Stable') FOR [Type]
GO

ALTER TABLE [dbo].[PackVersions] CHECK CONSTRAINT [CK_PackVersion_Type-Default]
GO

-- Add default date to [ReleaseTime]
ALTER TABLE [dbo].[PackVersions] WITH CHECK ADD CONSTRAINT [CK_PackVersion_ReleaseTime-Default]  DEFAULT (getdate()) FOR [ReleaseTime]
GO

ALTER TABLE [dbo].[PackVersions] CHECK CONSTRAINT [CK_PackVersion_ReleaseTime-Default]
GO

-- Add default date to [ReleaseTime]
ALTER TABLE [dbo].[PackVersions] WITH CHECK ADD CONSTRAINT [CK_PackVersion_UpdateTime-Default]  DEFAULT (getdate()) FOR [UpdateTime]
GO

ALTER TABLE [dbo].[PackVersions] CHECK CONSTRAINT [CK_PackVersion_UpdateTime-Default]
GO


