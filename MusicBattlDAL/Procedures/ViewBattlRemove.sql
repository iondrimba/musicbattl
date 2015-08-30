
 CREATE PROCEDURE [dbo].[viewBattlRemove]
  @viewBattlId int 
 AS 
 BEGIN 
 delete from viewBattl where viewBattlId = @viewBattlId 
 END 


