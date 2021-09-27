USE [Anvil.Test]
GO

INSERT INTO [dbo].[Packs]
           ([Id]
           ,[Name]
           ,[Creator]
           ,[Description]
           ,[Contributors]
           ,[IconAssetUrl]
           ,[IconAssetHash]
           ,[LogoAssetUrl]
           ,[LogoAssetHash]
           ,[BackgroundAssetUrl]
           ,[BackgroundAssetHash]
           ,[VisibleOnPublicList])
     VALUES
           ('test-pack'
		   ,'Test pack'
		   ,'Czompi'
		   ,'Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptate amet adipisci a sint architecto quisquam vero quis earum ex in voluptas et odio, voluptatum eius totam molestiae? Dignissimos, suscipit consequuntur?\nLorem ipsum dolor sit amet consectetur adipisicing elit. Vel assumenda qui nam optio ipsa? Libero atque numquam incidunt perferendis cum molestias ullam odio vero aspernatur id? Fuga libero impedit quis.\nLorem, ipsum dolor sit amet consectetur adipisicing elit. Ut vero hic est, dolor eum vitae quas earum voluptatibus sit error aliquid sint quam unde ex excepturi quasi atque. Natus, nesciunt!\nLorem ipsum dolor sit amet consectetur adipisicing elit. Sapiente ab reprehenderit dolore ipsum maxime iure, unde iusto voluptatem officiis natus fugit sed? Perferendis consequuntur dicta vero? Excepturi nulla quisquam fugiat.'
		   ,null
		   ,'{{DEFAULT}}'
		   ,null
		   ,'{{DEFAULT}}'
		   ,null
		   ,'{{DEFAULT}}'
		   ,null
		   ,1
		   )
GO


