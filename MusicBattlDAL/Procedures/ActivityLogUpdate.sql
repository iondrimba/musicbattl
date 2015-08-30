
 CREATE PROCEDURE [dbo].[activityLogUpdate]
  @activityLogId int,
  @userId int,
  @actionId int,
  @date datetime
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	activityLog 
 SET  userId =@userId , actionId =@actionId , date =@date 
 where activityLogId = @activityLogId 
 END 

