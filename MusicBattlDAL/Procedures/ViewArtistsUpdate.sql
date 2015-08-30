
 CREATE PROCEDURE [dbo].[viewArtistsUpdate]
  @artistId int,
  @name nvarchar(250), 
 @description nvarchar(MAX), 
 @picture nvarchar(350)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	viewArtists 
 SET  artistId =@artistId , name =@name , description =@description , picture =@picture 
 where viewArtistsId = @viewArtistsId 
 END 

