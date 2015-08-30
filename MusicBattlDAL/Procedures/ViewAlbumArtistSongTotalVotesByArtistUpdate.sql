
 CREATE PROCEDURE [dbo].[viewAlbumArtistSongTotalVotesByArtistUpdate]
  @artistId int,
  @total int,
  @albumName nvarchar(100), 
 @artistName nvarchar(250), 
 @albumCover nvarchar(50), 
 @picture nvarchar(350)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	viewAlbumArtistSongTotalVotesByArtist 
 SET  artistId =@artistId , total =@total , albumName =@albumName , artistName =@artistName , albumCover =@albumCover , picture =@picture 
 where viewAlbumArtistSongTotalVotesByArtistId = @viewAlbumArtistSongTotalVotesByArtistId 
 END 

