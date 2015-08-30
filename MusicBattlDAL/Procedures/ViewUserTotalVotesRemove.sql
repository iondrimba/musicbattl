
 CREATE PROCEDURE [dbo].[viewUserTotalVotesRemove]
  @viewUserTotalVotesId int 
 AS 
 BEGIN 
 delete from viewUserTotalVotes where viewUserTotalVotesId = @viewUserTotalVotesId 
 END 


