using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace MusicBattlDAL
{
    public partial class ViewAlbumArtistSongTotalVotesRepository
    {
        #region IList<IViewTopAlbums> ExecuteProcedure<IViewTopAlbumsQueryParams>( string procedureName , IViewTopAlbumsQueryParams query , int top = 0 )

        public IList<IViewAlbumArtistSongTotalVotes> ExecuteProcedure<IViewTopAlbumsQueryParams>(string procedureName, IViewTopAlbumsQueryParams query, int top = 0)
        {
            _collection = new List<IViewAlbumArtistSongTotalVotes>();

            using (DbCommand dbCmd = _dataBase.GetStoredProcCommand(procedureName))
            {
                if (top > 0)
                {
                    _dataBase.AddInParameter(dbCmd, "@topParam", DbType.Int32, top);
                }

                _dataBase.AddInParameter(dbCmd, "@whereParam", DbType.String, ((IDataQuery)query).Where);

                using (IDataReader reader = _dataBase.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        IViewAlbumArtistSongTotalVotes viewAlbumArtistSongTotalVotes = new ViewAlbumArtistSongTotalVotes();

                        viewAlbumArtistSongTotalVotes.ArtistId = Convert.ToInt32(reader["artistId"].ToString());
                        viewAlbumArtistSongTotalVotes.Total = Convert.ToInt32(reader["totalVotes"].ToString());
                        viewAlbumArtistSongTotalVotes.AlbumName = reader["albumName"].ToString();
                        viewAlbumArtistSongTotalVotes.ArtistName = reader["artistName"].ToString();
                        viewAlbumArtistSongTotalVotes.AlbumCover = reader["albumCover"].ToString();
                        viewAlbumArtistSongTotalVotes.Picture = reader["picture"].ToString();

                        _collection.Add(viewAlbumArtistSongTotalVotes);
                    }
                }
            }

            return _collection;
        }

        #endregion IList<IViewTopAlbums> ExecuteProcedure<IViewTopAlbumsQueryParams>( string procedureName , IViewTopAlbumsQueryParams query , int top = 0 )
    }
}