
 CREATE PROCEDURE [dbo].[ViewUserAgesRemove]
  @ViewUserAgesId int 
 AS 
 BEGIN 
 delete from ViewUserAges where ViewUserAgesId = @ViewUserAgesId 
 END 


