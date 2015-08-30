
 CREATE PROCEDURE [dbo].[viewTopUsersUpdate]
  @profileId int,
  @usuarioId int,
  @totalVotes int,
  @name nvarchar(150), 
 @picture nvarchar(50), 
 @gender nvarchar(1)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	viewTopUsers 
 SET  profileId =@profileId , usuarioId =@usuarioId , totalVotes =@totalVotes , name =@name , picture =@picture , gender =@gender 
 where viewTopUsersId = @viewTopUsersId 
 END 

