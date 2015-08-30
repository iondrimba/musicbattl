
 CREATE PROCEDURE [dbo].[ViewUserAgesAdd]
  @age int
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[ViewUserAges](  [age]) 
  VALUES ( @age) 
 SELECT SCOPE_IDENTITY() END 

