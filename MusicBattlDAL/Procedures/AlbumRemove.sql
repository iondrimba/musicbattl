
 CREATE PROCEDURE [dbo].[albumRemove]
  @albumId int 
 AS 
 BEGIN 
 delete from album where albumId = @albumId 
 END 


