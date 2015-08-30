
 CREATE PROCEDURE [dbo].[viewArtistContactUpdate]
  @name nvarchar(250), 
 @description nvarchar(MAX), 
 @picture nvarchar(350), 
 @artistId int,
  @idArtistContact int,
  @bandcamp nvarchar(250), 
 @soundcloud nvarchar(250), 
 @website nvarchar(250), 
 @tumblr nvarchar(250), 
 @facebook nvarchar(250), 
 @twitter nvarchar(250), 
 @email nvarchar(250)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	viewArtistContact 
 SET  name =@name , description =@description , picture =@picture , artistId =@artistId , idArtistContact =@idArtistContact , bandcamp =@bandcamp , soundcloud =@soundcloud , website =@website , tumblr =@tumblr , facebook =@facebook , twitter =@twitter , email =@email 
 where viewArtistContactId = @viewArtistContactId 
 END 

