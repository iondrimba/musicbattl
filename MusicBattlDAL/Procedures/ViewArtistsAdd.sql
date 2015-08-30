
 CREATE PROCEDURE [dbo].[viewArtistsAdd]
  @artistId int,
  @name nvarchar(250), 
 @description nvarchar(MAX), 
 @picture nvarchar(350)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[viewArtists](  [artistId], [name], [description], [picture]) 
  VALUES ( @artistId, @name, @description, @picture) 
 SELECT SCOPE_IDENTITY() END 

