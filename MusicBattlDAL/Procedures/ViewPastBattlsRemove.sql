
 CREATE PROCEDURE [dbo].[viewPastBattlsRemove]
  @viewPastBattlsId int 
 AS 
 BEGIN 
 delete from viewPastBattls where viewPastBattlsId = @viewPastBattlsId 
 END 


