
 CREATE PROCEDURE [dbo].[tagUpdate]
  @tagId int,
  @ownerTableId int,
  @ownerId int,
  @name nvarchar(250)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	tag 
 SET  ownerTableId =@ownerTableId , ownerId =@ownerId , name =@name 
 where tagId = @tagId 
 END 

