
 CREATE PROCEDURE [dbo].[ViewUserAgesUpdate]
  @age int
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	ViewUserAges 
 SET  age =@age 
 where ViewUserAgesId = @ViewUserAgesId 
 END 

