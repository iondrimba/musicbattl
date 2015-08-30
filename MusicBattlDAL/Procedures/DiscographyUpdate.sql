
 CREATE PROCEDURE [dbo].[discographyUpdate]
  @discographyId int,
  @artistId int
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	discography 
 SET  artistId =@artistId 
 where discographyId = @discographyId 
 END 

