
 CREATE PROCEDURE [dbo].[albumUpdate]
  @albumId int,
  @artistId int,
  @year datetime,
  @albumCover nvarchar(50), 
 @name nvarchar(100), 
 @description nvarchar(MAX)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	album 
 SET  artistId =@artistId , year =@year , albumCover =@albumCover , name =@name , description =@description 
 where albumId = @albumId 
 END 

