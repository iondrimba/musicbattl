
 CREATE PROCEDURE [dbo].[activityLogRemove]
  @activityLogId int 
 AS 
 BEGIN 
 delete from activityLog where activityLogId = @activityLogId 
 END 


