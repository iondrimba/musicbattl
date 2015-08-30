
 CREATE PROCEDURE [dbo].[actionUpdate]
  @actionId int,
  @name nvarchar(250)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	action 
 SET  name =@name 
 where actionId = @actionId 
 END 

