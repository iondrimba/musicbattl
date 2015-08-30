
 CREATE PROCEDURE [dbo].[tagRemove]
  @tagId int 
 AS 
 BEGIN 
 delete from tag where tagId = @tagId 
 END 


