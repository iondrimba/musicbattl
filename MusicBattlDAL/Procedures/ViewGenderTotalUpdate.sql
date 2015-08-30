
 CREATE PROCEDURE [dbo].[viewGenderTotalUpdate
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	viewGenderTotal 
 SET
 where viewGenderTotalId = @viewGenderTotalId 
 END 

