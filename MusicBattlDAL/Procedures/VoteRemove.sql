
 CREATE PROCEDURE [dbo].[voteRemove]
  @voteId int 
 AS 
 BEGIN 
 delete from vote where voteId = @voteId 
 END 


