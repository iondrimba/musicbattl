
 CREATE PROCEDURE [dbo].[viewTopSongsUpdate]
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
 UPDATE	viewTopSongs 
 SET  artistId =@artistId , songId =@songId , songName =@songName , artistName =@artistName , albumName =@albumName , albumCover =@albumCover , totalVotes =@totalVotes 
 where viewTopSongsId = @viewTopSongsId 
 END 

