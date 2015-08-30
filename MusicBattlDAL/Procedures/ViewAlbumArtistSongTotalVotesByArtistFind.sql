
 CREATE PROCEDURE [dbo].[viewAlbumArtistSongTotalVotesByArtistFind]
  @fromParam nvarchar(MAX) = ' viewAlbumArtistSongTotalVotesByArtist ', 
 @whereParam nvarchar(MAX) = NULL, 
 @orderByParam nvarchar(MAX) = 'name' 
 AS 
 BEGIN 
 SET NOCOUNT ON;	 
 DECLARE @query nvarchar(MAX)	 
 DECLARE @from nvarchar(MAX)	 
 SET @from = @fromParam	 
 DECLARE @where nvarchar(MAX)	 
 SET @where = @whereParam	 
 DECLARE @orderBy nvarchar(MAX)	 
 SET @orderBy = @orderByParam	 
 IF @orderByParam IS NOT NULL	 
 set @orderBy = 'viewAlbumArtistSongTotalVotesByArtistId DESC'	 
 set @query = ' SELECT DISTINCT * FROM ' + @from + ' order by '+ @orderBy		 
 IF @whereParam IS NOT NULL	 
 set @query = 'SELECT DISTINCT * FROM ' + @from +' where '+ @where + ' order by '+ @orderBy	 
 EXEC(@query)	 
 END	 


