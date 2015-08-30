
 CREATE PROCEDURE [dbo].[socialUpdate]
  @socialId int,
  @userId int,
  @socialTypeId int
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	social 
 SET  userId =@userId , socialTypeId =@socialTypeId 
 where socialId = @socialId 
 END 

