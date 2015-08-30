
 CREATE PROCEDURE [dbo].[songAdd]
  @albumId int,
  @name nvarchar(150), 
 @duration nchar,
  @trackNumber int
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[song](  [albumId], [name], [duration], [trackNumber]) 
  VALUES ( @albumId, @name, @duration, @trackNumber) 
 SELECT SCOPE_IDENTITY() END 

