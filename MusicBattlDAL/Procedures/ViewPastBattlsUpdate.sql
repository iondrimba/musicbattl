
 CREATE PROCEDURE [dbo].[viewPastBattlsUpdate]
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
 UPDATE	viewPastBattls 
 SET  battlId =@battlId , firstSongId =@firstSongId , firstAlbumId =@firstAlbumId , firstArtistId =@firstArtistId , firstSongName =@firstSongName , firstAlbumName =@firstAlbumName , firstArtistName =@firstArtistName , secondSongId =@secondSongId , secondAlbumId =@secondAlbumId , secondArtistId =@secondArtistId , secondSongName =@secondSongName , secondAlbumName =@secondAlbumName , secondArtistName =@secondArtistName , firstAlbumCover =@firstAlbumCover , secondAlbumCover =@secondAlbumCover 
 where viewPastBattlsId = @viewPastBattlsId 
 END 

