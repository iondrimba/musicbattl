
 CREATE PROCEDURE [dbo].[actionRemove]
  @actionId int 
 AS 
 BEGIN 
 delete from action where actionId = @actionId 
 END 


