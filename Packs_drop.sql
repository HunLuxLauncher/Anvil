USE [Anvil.Test]
GO

/****** Object:  Table [dbo].[Packs]    Script Date: 2021. 09. 24. 19:53:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Packs]') AND type in (N'U'))
DROP TABLE [dbo].[Packs]
GO


