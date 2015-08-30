
 CREATE PROCEDURE [dbo].[viewBattlResultsUpdate]
  @battlId int,
  @firstSongId int,
  @secondSongId int,
  @artistNameSecond nvarchar(250), 
 @artistNameFirst nvarchar(250), 
 @totalSecond int,
  @totalFirst int,
  @profileId int
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	viewBattlResults 
 SET  battlId =@battlId , firstSongId =@firstSongId , secondSongId =@secondSongId , artistNameSecond =@artistNameSecond , artistNameFirst =@artistNameFirst , totalSecond =@totalSecond , totalFirst =@totalFirst , profileId =@profileId 
 where viewBattlResultsId = @viewBattlResultsId 
 END 

