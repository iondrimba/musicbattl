
 CREATE PROCEDURE [dbo].[voteUpdate]
  @voteId int,
  @battlId int,
  @songId int,
  @profileId int,
  @votes int
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	vote 
 SET  battlId =@battlId , songId =@songId , profileId =@profileId , votes =@votes 
 where voteId = @voteId 
 END 

