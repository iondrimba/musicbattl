
 CREATE PROCEDURE [dbo].[viewActivityByHourRemove]
  @viewActivityByHourId int 
 AS 
 BEGIN 
 delete from viewActivityByHour where viewActivityByHourId = @viewActivityByHourId 
 END 


