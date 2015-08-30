
 CREATE PROCEDURE [dbo].[viewGenderTotalAdd
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[viewGenderTotal]( ) 
  VALUES () 
 SELECT SCOPE_IDENTITY() END 

