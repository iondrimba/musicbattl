
 CREATE PROCEDURE [dbo].[viewGenderTotalRemove]
  @viewGenderTotalId int 
 AS 
 BEGIN 
 delete from viewGenderTotal where viewGenderTotalId = @viewGenderTotalId 
 END 


