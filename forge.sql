USE [Anvil.Test]
GO

INSERT INTO [dbo].[Mods]([Id],[Name],[Description],[Author],[UpdateUrl]) VALUES
('forge', 'Minecraft Forge', '', '', 'https://addons-ecs.forgesvc.net/api/v2/minecraft/modloader');
GO
INSERT INTO [dbo].[ModVersions]([ModId],[Name],[GameVersion],[ReleaseTime],[Type],[Hash]) VALUES
('forge', '1.16.5-35.2.5', '1.16.5', '2021-09-19 23:50:14', 'Stable', '528abeff9d09605015e09d3a26605de3758ed47d');
GO

INSERT INTO [dbo].[PackDependencies]([PackId],[PackVersionId],[ModId],[ModVersionId]) VALUES
('test-pack', 3,'forge',102)
;     
GO