
 CREATE PROCEDURE [dbo].[battlAdd]
  @firstSongId int,
  @secondSongId int,
  @startTime datetime,
  @endTime datetime,
  @battlDate datetime
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[battl](  [firstSongId], [secondSongId], [startTime], [endTime], [battlDate]) 
  VALUES ( @firstSongId, @secondSongId, @startTime, @endTime, @battlDate) 
 SELECT SCOPE_IDENTITY() END 

