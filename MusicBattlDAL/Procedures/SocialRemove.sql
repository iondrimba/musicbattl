
 CREATE PROCEDURE [dbo].[socialRemove]
  @socialId int 
 AS 
 BEGIN 
 delete from social where socialId = @socialId 
 END 


