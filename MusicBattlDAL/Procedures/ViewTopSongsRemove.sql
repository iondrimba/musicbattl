
 CREATE PROCEDURE [dbo].[viewTopSongsRemove]
  @viewTopSongsId int 
 AS 
 BEGIN 
 delete from viewTopSongs where viewTopSongsId = @viewTopSongsId 
 END 


