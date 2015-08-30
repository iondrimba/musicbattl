
 CREATE PROCEDURE [dbo].[songUpdate]
  @songId int,
  @albumId int,
  @name nvarchar(150), 
 @duration nchar,
  @trackNumber int
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	song 
 SET  albumId =@albumId , name =@name , duration =@duration , trackNumber =@trackNumber 
 where songId = @songId 
 END 

