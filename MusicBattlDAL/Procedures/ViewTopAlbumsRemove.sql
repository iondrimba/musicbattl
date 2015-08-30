
 CREATE PROCEDURE [dbo].[viewTopAlbumsRemove]
  @viewTopAlbumsId int 
 AS 
 BEGIN 
 delete from viewTopAlbums where viewTopAlbumsId = @viewTopAlbumsId 
 END 


