
 CREATE PROCEDURE [dbo].[usuarioRemove]
  @usuarioId int 
 AS 
 BEGIN 
 delete from usuario where usuarioId = @usuarioId 
 END 


