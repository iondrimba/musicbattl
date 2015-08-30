
 CREATE PROCEDURE [dbo].[viewTopAlbumsAdd]
  @artistId int,
  @totalVotes int,
  @albumName nvarchar(100), 
 @artistName nvarchar(250), 
 @albumCover nvarchar(50), 
 @battlDate datetime
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[viewTopAlbums](  [artistId], [totalVotes], [albumName], [artistName], [albumCover], [battlDate]) 
  VALUES ( @artistId, @totalVotes, @albumName, @artistName, @albumCover, @battlDate) 
 SELECT SCOPE_IDENTITY() END 

