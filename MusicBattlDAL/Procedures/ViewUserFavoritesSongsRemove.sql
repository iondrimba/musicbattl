
 CREATE PROCEDURE [dbo].[viewUserFavoritesSongsRemove]
  @viewUserFavoritesSongsId int 
 AS 
 BEGIN 
 delete from viewUserFavoritesSongs where viewUserFavoritesSongsId = @viewUserFavoritesSongsId 
 END 


