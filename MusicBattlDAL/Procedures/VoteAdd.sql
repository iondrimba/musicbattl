
 CREATE PROCEDURE [dbo].[voteAdd]
  @battlId int,
  @songId int,
  @profileId int,
  @votes int
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[vote](  [battlId], [songId], [profileId], [votes]) 
  VALUES ( @battlId, @songId, @profileId, @votes) 
 SELECT SCOPE_IDENTITY() END 

