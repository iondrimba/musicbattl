
 CREATE PROCEDURE [dbo].[viewUserBattlResultRemove]
  @viewUserBattlResultId int 
 AS 
 BEGIN 
 delete from viewUserBattlResult where viewUserBattlResultId = @viewUserBattlResultId 
 END 


