using MusicBattlBLL.interfaces;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.models
{
    public class ViewArtistContactBLL : IViewArtistContactBLL
    {
        private IRepositoryBLL<IViewArtistContact> _repository;
        private IDataBaseAccess _dataBaseAccess;

        public ViewArtistContactBLL( IRepositoryBLL<IViewArtistContact> repository )
        {
            _repository = repository;
            _dataBaseAccess = _repository.repositorieDAL.DataBaseAccess;
        }

        public IViewArtistContact ArtistContactGet( int id )
        {
            IDataQuery query = new DataQuery();
            query.Where = string.Format("artistId={0}" , id);

            IViewArtistContact retorno = _repository.Find(query)[0];

            return retorno;
        }
    }
}