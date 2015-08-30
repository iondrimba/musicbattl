
 CREATE PROCEDURE [dbo].[viewBattlUpdate]
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
 UPDATE	viewBattl 
 SET  battlId =@battlId , firstSongId =@firstSongId , startTime =@startTime , endTime =@endTime , battlDate =@battlDate , firstAlbumCover =@firstAlbumCover , firstSongName =@firstSongName , firstAlbumName =@firstAlbumName , secondSongId =@secondSongId , secondSongName =@secondSongName , secondAlbumCover =@secondAlbumCover , secondAlbumName =@secondAlbumName 
 where viewBattlId = @viewBattlId 
 END 

