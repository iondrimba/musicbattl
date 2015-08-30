
 CREATE PROCEDURE [dbo].[viewAlbumArtistSongTotalVotesByArtistAdd]
  @artistId int,
  @total int,
  @albumName nvarchar(100), 
 @artistName nvarchar(250), 
 @albumCover nvarchar(50), 
 @picture nvarchar(350)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[viewAlbumArtistSongTotalVotesByArtist](  [artistId], [total], [albumName], [artistName], [albumCover], [picture]) 
  VALUES ( @artistId, @total, @albumName, @artistName, @albumCover, @picture) 
 SELECT SCOPE_IDENTITY() END 

