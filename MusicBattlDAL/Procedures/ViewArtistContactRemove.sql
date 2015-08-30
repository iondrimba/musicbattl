
 CREATE PROCEDURE [dbo].[viewArtistContactRemove]
  @viewArtistContactId int 
 AS 
 BEGIN 
 delete from viewArtistContact where viewArtistContactId = @viewArtistContactId 
 END 


