USE [Anvil.Test]
GO

INSERT INTO [dbo].[Packs]
           ([Id]
           ,[Name]
           ,[Creator]
           ,[Contributors]
           ,[IconAssetUrl]
           ,[IconAssetHash]
           ,[LogoAssetUrl]
           ,[LogoAssetHash]
           ,[BackgroundAssetUrl]
           ,[BackgroundAssetHash]
		   ,[VisibleOnPublicList])
     VALUES
           ('test-pack',
		   'Test pack',
		   'Czompi',
		   null,
		   '{{default}}',
		   null,
		   '{{default}}',
		   null,
		   '{{default}}',
		   null,
		   1)
GO


