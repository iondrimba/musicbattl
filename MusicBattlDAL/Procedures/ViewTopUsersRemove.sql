
 CREATE PROCEDURE [dbo].[viewTopUsersRemove]
  @viewTopUsersId int 
 AS 
 BEGIN 
 delete from viewTopUsers where viewTopUsersId = @viewTopUsersId 
 END 


