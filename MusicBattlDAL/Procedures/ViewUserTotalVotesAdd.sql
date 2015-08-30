
 CREATE PROCEDURE [dbo].[viewUserTotalVotesAdd]
  @usuarioId int,
  @profileId int,
  @name nvarchar(150), 
 @picture nvarchar(50), 
 @gender nvarchar(1), 
 @total int,
  @songId int,
  @battlId int,
  @songName nvarchar(150)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[viewUserTotalVotes](  [usuarioId], [profileId], [name], [picture], [gender], [total], [songId], [battlId], [songName]) 
  VALUES ( @usuarioId, @profileId, @name, @picture, @gender, @total, @songId, @battlId, @songName) 
 SELECT SCOPE_IDENTITY() END 

