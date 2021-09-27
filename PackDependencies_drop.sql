USE [Anvil.Test]
GO

/****** Object:  Table [dbo].[PackDependencies]    Script Date: 2021. 09. 24. 19:54:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PackDependencies]') AND type in (N'U'))
DROP TABLE [dbo].[PackDependencies]
GO


