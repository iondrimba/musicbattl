
 CREATE PROCEDURE [dbo].[discographyRemove]
  @discographyId int 
 AS 
 BEGIN 
 delete from discography where discographyId = @discographyId 
 END 


