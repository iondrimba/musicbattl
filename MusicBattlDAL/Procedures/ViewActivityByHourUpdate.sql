
 CREATE PROCEDURE [dbo].[viewActivityByHourUpdate]
  @hour varchar,
  @totalByHour int
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	viewActivityByHour 
 SET  hour =@hour , totalByHour =@totalByHour 
 where viewActivityByHourId = @viewActivityByHourId 
 END 

