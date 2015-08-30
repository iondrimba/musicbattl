
 CREATE PROCEDURE [dbo].[usuarioAdd]
  @name nvarchar(150), 
 @birthdate datetime,
  @password nvarchar(8), 
 @created datetime,
  @udated datetime,
  @gender nvarchar(1),
  @customId int = null
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 INSERT	 
 INTO	[usuario](  [name], [birthdate], [password], [created], [udated], [gender],[customId]) 
  VALUES ( @name, @birthdate, @password, @created, @udated, @gender,@customId) 
 SELECT SCOPE_IDENTITY() END 

