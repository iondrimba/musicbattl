
 CREATE PROCEDURE [dbo].[viewPastBattlsAdd]
  @battlId int,
  @firstSongId int,
  @firstAlbumId int,
  @firstArtistId int,
  @firstSongName nvarchar(150), 
 @firstAlbumName nvarchar(100), 
 @firstArtistName nvarchar(250), 
 @secondSongId int,
  @secondAlbumId int,
  @secondArtistId int,
  @secondSongName nvarchar(150), 
 @secondAlbumName nvarchar(100), 
 @secondArtistName nvarchar(250), 
 @firstAlbumCover nvarchar(50), 
 @secondAlbumCover nvarchar(50)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[viewPastBattls](  [battlId], [firstSongId], [firstAlbumId], [firstArtistId], [firstSongName], [firstAlbumName], [firstArtistName], [secondSongId], [secondAlbumId], [secondArtistId], [secondSongName], [secondAlbumName], [secondArtistName], [firstAlbumCover], [secondAlbumCover]) 
  VALUES ( @battlId, @firstSongId, @firstAlbumId, @firstArtistId, @firstSongName, @firstAlbumName, @firstArtistName, @secondSongId, @secondAlbumId, @secondArtistId, @secondSongName, @secondAlbumName, @secondArtistName, @firstAlbumCover, @secondAlbumCover) 
 SELECT SCOPE_IDENTITY() END 

