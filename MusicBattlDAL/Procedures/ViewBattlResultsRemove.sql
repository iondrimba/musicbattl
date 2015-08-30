
 CREATE PROCEDURE [dbo].[viewBattlResultsRemove]
  @viewBattlResultsId int 
 AS 
 BEGIN 
 delete from viewBattlResults where viewBattlResultsId = @viewBattlResultsId 
 END 


