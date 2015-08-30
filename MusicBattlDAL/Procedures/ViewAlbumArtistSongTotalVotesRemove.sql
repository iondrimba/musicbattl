
 CREATE PROCEDURE [dbo].[viewAlbumArtistSongTotalVotesRemove]
  @viewAlbumArtistSongTotalVotesId int 
 AS 
 BEGIN 
 delete from viewAlbumArtistSongTotalVotes where viewAlbumArtistSongTotalVotesId = @viewAlbumArtistSongTotalVotesId 
 END 


