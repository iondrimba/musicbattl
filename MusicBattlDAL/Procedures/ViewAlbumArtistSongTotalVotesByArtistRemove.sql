
 CREATE PROCEDURE [dbo].[viewAlbumArtistSongTotalVotesByArtistRemove]
  @viewAlbumArtistSongTotalVotesByArtistId int 
 AS 
 BEGIN 
 delete from viewAlbumArtistSongTotalVotesByArtist where viewAlbumArtistSongTotalVotesByArtistId = @viewAlbumArtistSongTotalVotesByArtistId 
 END 


