
 CREATE PROCEDURE [dbo].[socialAdd]
  @userId int,
  @socialTypeId int
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[social](  [userId], [socialTypeId]) 
  VALUES ( @userId, @socialTypeId) 
 SELECT SCOPE_IDENTITY() END 

