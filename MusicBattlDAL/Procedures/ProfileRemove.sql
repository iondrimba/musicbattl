
 CREATE PROCEDURE [dbo].[profileRemove]
  @profileId int 
 AS 
 BEGIN 
 delete from profile where profileId = @profileId 
 END 


