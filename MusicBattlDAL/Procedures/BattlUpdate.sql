
 CREATE PROCEDURE [dbo].[battlUpdate]
  @battlId int,
  @firstSongId int,
  @secondSongId int,
  @startTime datetime,
  @endTime datetime,
  @battlDate datetime
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	battl 
 SET  firstSongId =@firstSongId , secondSongId =@secondSongId , startTime =@startTime , endTime =@endTime , battlDate =@battlDate 
 where battlId = @battlId 
 END 

