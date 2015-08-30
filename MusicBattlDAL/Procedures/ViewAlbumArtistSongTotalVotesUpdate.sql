
 CREATE PROCEDURE [dbo].[viewAlbumArtistSongTotalVotesUpdate]
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
 UPDATE	viewAlbumArtistSongTotalVotes 
 SET  songId =@songId , total =@total , songName =@songName , albumName =@albumName , artistName =@artistName , artistId =@artistId , albumCover =@albumCover 
 where viewAlbumArtistSongTotalVotesId = @viewAlbumArtistSongTotalVotesId 
 END 

