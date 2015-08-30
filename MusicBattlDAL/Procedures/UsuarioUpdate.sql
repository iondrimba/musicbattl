
 CREATE PROCEDURE [dbo].[usuarioUpdate]
  @usuarioId int,
  @name nvarchar(150), 
 @birthdate datetime,
  @password nvarchar(8), 
 @created datetime,
  @udated datetime,
  @gender nvarchar(1)
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 UPDATE	usuario 
 SET  name =@name , birthdate =@birthdate , password =@password , created =@created , udated =@udated , gender =@gender 
 where usuarioId = @usuarioId 
 END 

