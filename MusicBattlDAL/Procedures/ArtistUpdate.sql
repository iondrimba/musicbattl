
 CREATE PROCEDURE [dbo].[artistUpdate]
  @artistId int,
  @name nvarchar(250), 
 @description nvarchar(MAX)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	artist 
 SET  name =@name , description =@description 
 where artistId = @artistId 
 END 

