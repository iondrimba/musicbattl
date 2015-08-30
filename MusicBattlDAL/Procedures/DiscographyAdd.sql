
 CREATE PROCEDURE [dbo].[discographyAdd]
  @artistId int
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[discography](  [artistId]) 
  VALUES ( @artistId) 
 SELECT SCOPE_IDENTITY() END 

