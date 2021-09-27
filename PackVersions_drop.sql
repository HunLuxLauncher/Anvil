USE [Anvil.Test]
GO

/****** Object:  Table [dbo].[PackVersions]    Script Date: 2021. 09. 24. 19:54:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PackVersions]') AND type in (N'U'))
DROP TABLE [dbo].[PackVersions]
GO


