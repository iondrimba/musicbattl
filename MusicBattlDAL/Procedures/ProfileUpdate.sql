
 CREATE PROCEDURE [dbo].[profileUpdate]
  @profileId int,
  @userId int,
  @picture nvarchar(50), 
 @upadted datetime,
  @removed bit
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	profile 
 SET  userId =@userId , picture =@picture , upadted =@upadted , removed =@removed 
 where profileId = @profileId 
 END 

