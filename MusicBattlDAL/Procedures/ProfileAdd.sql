
 CREATE PROCEDURE [dbo].[profileAdd]
  @userId int,
  @picture nvarchar(50), 
 @upadted datetime,
  @removed bit
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[profile](  [userId], [picture], [upadted], [removed]) 
  VALUES ( @userId, @picture, @upadted, @removed) 
 SELECT SCOPE_IDENTITY() END 

