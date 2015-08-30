
 CREATE PROCEDURE [dbo].[addressUpdate]
  @addressId int,
  @profileId int,
  @country nvarchar(150), 
 @city nvarchar(150)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	address 
 SET  profileId =@profileId , country =@country , city =@city 
 where addressId = @addressId 
 END 

