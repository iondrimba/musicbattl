
 CREATE PROCEDURE [dbo].[viewUserFavoritesSongsAdd]
  @songId int,
  @usuarioId int,
  @profileId int,
  @totalSong int,
  @albumId int,
  @artistId int,
  @albumCover nvarchar(50), 
 @albumName nvarchar(100), 
 @artistName nvarchar(250), 
 @name nvarchar(150)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[viewUserFavoritesSongs](  [songId], [usuarioId], [profileId], [totalSong], [albumId], [artistId], [albumCover], [albumName], [artistName], [name]) 
  VALUES ( @songId, @usuarioId, @profileId, @totalSong, @albumId, @artistId, @albumCover, @albumName, @artistName, @name) 
 SELECT SCOPE_IDENTITY() END 

