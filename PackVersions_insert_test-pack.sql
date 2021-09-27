USE [Anvil.Test]
GO

INSERT INTO [dbo].[PackVersions] ([PackId], [Name], [UpdateTime], [ReleaseTime],[Type]) VALUES
('test-pack', '1.0.1-Pre2', '2021-09-24 16:24', '2021-09-24 16:24:55', 'Preview'),
('test-pack', '1.0.1-Pre1', '2021-09-24 16:24', '2021-09-08 19:40:10', 'Preview'),
('test-pack', '1.0.0', '2021-09-24 16:24', '2021-09-05 18:24:49', 'Stable'),
('test-pack', '1.0.0-Pre3', '2021-09-24 16:24', '2021-08-12 20:50:30', 'Preview'),
('test-pack', '1.0.0-Pre2', '2021-09-24 16:24', '2021-04-23 12:20:24', 'Preview'),
('test-pack', '1.0.0-Pre1', '2021-09-24 16:24', '2021-04-10 14:19:07', 'Preview')
GO


