
 CREATE PROCEDURE [dbo].[viewTopSongsAdd]
  @artistId int,
  @songId int,
  @songName nvarchar(150), 
 @artistName nvarchar(250), 
 @albumName nvarchar(100), 
 @albumCover nvarchar(50), 
 @totalVotes int
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[viewTopSongs](  [artistId], [songId], [songName], [artistName], [albumName], [albumCover], [totalVotes]) 
  VALUES ( @artistId, @songId, @songName, @artistName, @albumName, @albumCover, @totalVotes) 
 SELECT SCOPE_IDENTITY() END 

