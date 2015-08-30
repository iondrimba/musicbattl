
 CREATE PROCEDURE [dbo].[artistAdd]
  @name nvarchar(250), 
 @description nvarchar(MAX)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[artist](  [name], [description]) 
  VALUES ( @name, @description) 
 SELECT SCOPE_IDENTITY() END 

