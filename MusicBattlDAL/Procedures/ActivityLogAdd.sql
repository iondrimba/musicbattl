
 CREATE PROCEDURE [dbo].[activityLogAdd]
  @userId int,
  @actionId int,
  @date datetime
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[activityLog](  [userId], [actionId], [date]) 
  VALUES ( @userId, @actionId, @date) 
 SELECT SCOPE_IDENTITY() END 

