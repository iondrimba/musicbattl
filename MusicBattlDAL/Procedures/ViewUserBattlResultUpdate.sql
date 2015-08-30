
 CREATE PROCEDURE [dbo].[viewUserBattlResultUpdate]
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
 UPDATE	viewUserBattlResult 
 SET  battlId =@battlId , firstSongId =@firstSongId , secondSongId =@secondSongId , artistNameFirst =@artistNameFirst , artistNameSecond =@artistNameSecond , totalFirst =@totalFirst , totalSecond =@totalSecond , profileIdFirst =@profileIdFirst , totalFirstSong =@totalFirstSong , nameFirst =@nameFirst , profileIdSecond =@profileIdSecond , totalSecondSong =@totalSecondSong , nameSecond =@nameSecond , artistIdFirst =@artistIdFirst , artistIdSecond =@artistIdSecond , firstAlbumCover =@firstAlbumCover , secondAlbumCover =@secondAlbumCover 
 where viewUserBattlResultId = @viewUserBattlResultId 
 END 

