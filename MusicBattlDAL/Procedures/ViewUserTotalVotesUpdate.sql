
 CREATE PROCEDURE [dbo].[viewUserTotalVotesUpdate]
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
 UPDATE	viewUserTotalVotes 
 SET  usuarioId =@usuarioId , profileId =@profileId , name =@name , picture =@picture , gender =@gender , total =@total , songId =@songId , battlId =@battlId , songName =@songName 
 where viewUserTotalVotesId = @viewUserTotalVotesId 
 END 

