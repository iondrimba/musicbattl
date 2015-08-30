
 CREATE PROCEDURE [dbo].[albumAdd]
  @artistId int,
  @year datetime,
  @albumCover nvarchar(50), 
 @name nvarchar(100), 
 @description nvarchar(MAX)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[album](  [artistId], [year], [albumCover], [name], [description]) 
  VALUES ( @artistId, @year, @albumCover, @name, @description) 
 SELECT SCOPE_IDENTITY() END 

