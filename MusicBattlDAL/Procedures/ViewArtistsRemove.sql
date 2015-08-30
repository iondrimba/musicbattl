
 CREATE PROCEDURE [dbo].[viewArtistsRemove]
  @viewArtistsId int 
 AS 
 BEGIN 
 delete from viewArtists where viewArtistsId = @viewArtistsId 
 END 


