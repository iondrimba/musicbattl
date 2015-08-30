
 CREATE PROCEDURE [dbo].[songRemove]
  @songId int 
 AS 
 BEGIN 
 delete from song where songId = @songId 
 END 


