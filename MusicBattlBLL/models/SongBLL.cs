using Microsoft.Practices.EnterpriseLibrary.Data;
using MusicBattlBLL.interfaces;
using MusicBattlDAL;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.models
{
    public class SongBLL : ISongBLL
    {
        private IRepositoryBLL<ISong> _songRepository;
        private Database _dataBaseAccess;

        public SongBLL( IRepositoryBLL<ISong> songRepository )
        {
            _songRepository = songRepository;
            _dataBaseAccess = ((SongRepository)_songRepository.repositorieDAL).DataBase;
        }

        #region ISongBLL Members

        public ISong GetRandomSong( int songId )
        {
            IDataQuery query = new DataQuery();
            query.Where = string.Format("songId <> {0}" , songId);
            query.OrderBy = " NEWID() ";
            ISong song = _songRepository.GetTop(1 , query)[0];

            return song;
        }

        #endregion ISongBLL Members
    }
}