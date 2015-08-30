
 CREATE PROCEDURE [dbo].[addressAdd]
  @profileId int,
  @country nvarchar(150), 
 @city nvarchar(150)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[address](  [profileId], [country], [city]) 
  VALUES ( @profileId, @country, @city) 
 SELECT SCOPE_IDENTITY() END 

