
 CREATE PROCEDURE [dbo].[viewAlbumArtistSongTotalVotesAdd]
  @songId int,
  @total int,
  @songName nvarchar(150), 
 @albumName nvarchar(100), 
 @artistName nvarchar(250), 
 @artistId int,
  @albumCover nvarchar(50)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[viewAlbumArtistSongTotalVotes](  [songId], [total], [songName], [albumName], [artistName], [artistId], [albumCover]) 
  VALUES ( @songId, @total, @songName, @albumName, @artistName, @artistId, @albumCover) 
 SELECT SCOPE_IDENTITY() END 

