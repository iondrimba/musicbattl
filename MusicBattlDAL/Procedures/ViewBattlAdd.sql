
 CREATE PROCEDURE [dbo].[viewBattlAdd]
  @battlId int,
  @firstSongId int,
  @startTime datetime,
  @endTime datetime,
  @battlDate datetime,
  @firstAlbumCover nvarchar(50), 
 @firstSongName nvarchar(150), 
 @firstAlbumName nvarchar(100), 
 @secondSongId int,
  @secondSongName nvarchar(150), 
 @secondAlbumCover nvarchar(50), 
 @secondAlbumName nvarchar(100)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[viewBattl](  [battlId], [firstSongId], [startTime], [endTime], [battlDate], [firstAlbumCover], [firstSongName], [firstAlbumName], [secondSongId], [secondSongName], [secondAlbumCover], [secondAlbumName]) 
  VALUES ( @battlId, @firstSongId, @startTime, @endTime, @battlDate, @firstAlbumCover, @firstSongName, @firstAlbumName, @secondSongId, @secondSongName, @secondAlbumCover, @secondAlbumName) 
 SELECT SCOPE_IDENTITY() END 

