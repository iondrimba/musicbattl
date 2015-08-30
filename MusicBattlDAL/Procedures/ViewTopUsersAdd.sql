
 CREATE PROCEDURE [dbo].[viewTopUsersAdd]
  @profileId int,
  @usuarioId int,
  @totalVotes int,
  @name nvarchar(150), 
 @picture nvarchar(50), 
 @gender nvarchar(1)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[viewTopUsers](  [profileId], [usuarioId], [totalVotes], [name], [picture], [gender]) 
  VALUES ( @profileId, @usuarioId, @totalVotes, @name, @picture, @gender) 
 SELECT SCOPE_IDENTITY() END 

