
 CREATE PROCEDURE [dbo].[viewTopAlbumsUpdate]
  @artistId int,
  @totalVotes int,
  @albumName nvarchar(100), 
 @artistName nvarchar(250), 
 @albumCover nvarchar(50), 
 @battlDate datetime
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	viewTopAlbums 
 SET  artistId =@artistId , totalVotes =@totalVotes , albumName =@albumName , artistName =@artistName , albumCover =@albumCover , battlDate =@battlDate 
 where viewTopAlbumsId = @viewTopAlbumsId 
 END 

