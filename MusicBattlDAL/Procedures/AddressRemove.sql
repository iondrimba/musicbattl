
 CREATE PROCEDURE [dbo].[addressRemove]
  @addressId int 
 AS 
 BEGIN 
 delete from address where addressId = @addressId 
 END 


