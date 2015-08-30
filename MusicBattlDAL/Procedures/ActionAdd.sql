
 CREATE PROCEDURE [dbo].[actionAdd]
  @name nvarchar(250)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[action](  [name]) 
  VALUES ( @name) 
 SELECT SCOPE_IDENTITY() END 

