USE [Anvil.Test]
GO

/****** Object:  Table [dbo].[ModVersions]    Script Date: 2021. 09. 24. 21:38:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ModVersions]') AND type in (N'U'))
DROP TABLE [dbo].[ModVersions]
GO


