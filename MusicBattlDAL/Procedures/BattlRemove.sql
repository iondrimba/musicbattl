
 CREATE PROCEDURE [dbo].[battlRemove]
  @battlId int 
 AS 
 BEGIN 
 delete from battl where battlId = @battlId 
 END 


