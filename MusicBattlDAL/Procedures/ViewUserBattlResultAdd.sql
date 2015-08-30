
 CREATE PROCEDURE [dbo].[viewUserBattlResultAdd]
  @battlId int,
  @firstSongId int,
  @secondSongId int,
  @artistNameFirst nvarchar(250), 
 @artistNameSecond nvarchar(250), 
 @totalFirst int,
  @totalSecond int,
  @profileIdFirst int,
  @totalFirstSong int,
  @nameFirst nvarchar(150), 
 @profileIdSecond int,
  @totalSecondSong int,
  @nameSecond nvarchar(150), 
 @artistIdFirst int,
  @artistIdSecond int,
  @firstAlbumCover nvarchar(50), 
 @secondAlbumCover nvarchar(50)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[viewUserBattlResult](  [battlId], [firstSongId], [secondSongId], [artistNameFirst], [artistNameSecond], [totalFirst], [totalSecond], [profileIdFirst], [totalFirstSong], [nameFirst], [profileIdSecond], [totalSecondSong], [nameSecond], [artistIdFirst], [artistIdSecond], [firstAlbumCover], [secondAlbumCover]) 
  VALUES ( @battlId, @firstSongId, @secondSongId, @artistNameFirst, @artistNameSecond, @totalFirst, @totalSecond, @profileIdFirst, @totalFirstSong, @nameFirst, @profileIdSecond, @totalSecondSong, @nameSecond, @artistIdFirst, @artistIdSecond, @firstAlbumCover, @secondAlbumCover) 
 SELECT SCOPE_IDENTITY() END 

