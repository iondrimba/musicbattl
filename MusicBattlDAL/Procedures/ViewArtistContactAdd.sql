
 CREATE PROCEDURE [dbo].[viewArtistContactAdd]
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
 INSERT	 
 INTO	[viewArtistContact](  [name], [description], [picture], [artistId], [idArtistContact], [bandcamp], [soundcloud], [website], [tumblr], [facebook], [twitter], [email]) 
  VALUES ( @name, @description, @picture, @artistId, @idArtistContact, @bandcamp, @soundcloud, @website, @tumblr, @facebook, @twitter, @email) 
 SELECT SCOPE_IDENTITY() END 

