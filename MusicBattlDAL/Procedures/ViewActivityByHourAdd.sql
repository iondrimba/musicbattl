
 CREATE PROCEDURE [dbo].[viewActivityByHourAdd]
  @hour varchar,
  @totalByHour int
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[viewActivityByHour](  [hour], [totalByHour]) 
  VALUES ( @hour, @totalByHour) 
 SELECT SCOPE_IDENTITY() END 

