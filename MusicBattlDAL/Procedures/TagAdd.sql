
 CREATE PROCEDURE [dbo].[tagAdd]
  @ownerTableId int,
  @ownerId int,
  @name nvarchar(250)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[tag](  [ownerTableId], [ownerId], [name]) 
  VALUES ( @ownerTableId, @ownerId, @name) 
 SELECT SCOPE_IDENTITY() END 

