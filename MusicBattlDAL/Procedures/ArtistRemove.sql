
 CREATE PROCEDURE [dbo].[artistRemove]
  @artistId int 
 AS 
 BEGIN 
 delete from artist where artistId = @artistId 
 END 


