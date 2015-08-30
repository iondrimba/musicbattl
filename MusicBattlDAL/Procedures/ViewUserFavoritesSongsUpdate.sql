
 CREATE PROCEDURE [dbo].[viewUserFavoritesSongsUpdate]
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
 UPDATE	viewUserFavoritesSongs 
 SET  songId =@songId , usuarioId =@usuarioId , profileId =@profileId , totalSong =@totalSong , albumId =@albumId , artistId =@artistId , albumCover =@albumCover , albumName =@albumName , artistName =@artistName , name =@name 
 where viewUserFavoritesSongsId = @viewUserFavoritesSongsId 
 END 

