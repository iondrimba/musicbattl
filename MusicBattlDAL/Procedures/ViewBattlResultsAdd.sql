
 CREATE PROCEDURE [dbo].[viewBattlResultsAdd]
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
 INSERT	 
 INTO	[viewBattlResults](  [battlId], [firstSongId], [secondSongId], [artistNameSecond], [artistNameFirst], [totalSecond], [totalFirst], [profileId]) 
  VALUES ( @battlId, @firstSongId, @secondSongId, @artistNameSecond, @artistNameFirst, @totalSecond, @totalFirst, @profileId) 
 SELECT SCOPE_IDENTITY() END 

