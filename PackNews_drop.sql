USE [Anvil.Test]
GO

/****** Object:  Table [dbo].[PackNews]    Script Date: 2021. 09. 25. 14:25:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PackNews]') AND type in (N'U'))
DROP TABLE [dbo].[PackNews]
GO


