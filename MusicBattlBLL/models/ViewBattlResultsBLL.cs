using System.Collections.Generic;
using System.Linq;
using MusicBattlBLL.interfaces;
using MusicBattlDAL;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.models
{
    public class ViewBattlResultsBLL : IViewBattlResultBLL
    {
        #region Properties

        private IRepositoryBLL<IViewBattlResults> _battlRepository;
        private IDataBaseAccess _dataBaseAccess;

        #endregion Properties

        #region Constructor

        public ViewBattlResultsBLL( IRepositoryBLL<IViewBattlResults> battlRepository )
        {
            _battlRepository = battlRepository;
            _dataBaseAccess = _battlRepository.repositorieDAL.DataBaseAccess;
        }

        #endregion Constructor

        #region IList<IViewBattlResults> GetBattlsWonByProfileId( int profileId , int count = 0 )

        public IList<IViewBattlResults> GetBattlsWonByProfileId( int profileId , int count = 0 )
        {
            IDataQuery query = new DataQuery();
            query.Where = string.Format(" ViewBattlResults.profileId={0}" , profileId);
            query.OrderBy = " battlId DESC ";

            IList<IViewBattlResults> retorno = new List<IViewBattlResults>();

            retorno = _battlRepository.Find(query);

            var groupedResultByBattl = (from n in retorno
                                        group n by n.BattlId into g
                                        orderby g.Key
                                        let batll = g.FirstOrDefault()
                                        select new ViewBattlResults
                                        {
                                            BattlId = g.Key ,
                                            ProfileId = batll.ProfileId ,
                                            FirstSongId = batll.FirstSongId ,
                                            SecondSongId = batll.SecondSongId ,
                                            ArtistNameFirst = batll.ArtistNameFirst ,
                                            ArtistNameSecond = batll.ArtistNameSecond ,
                                            TotalFirst = g.Sum(m => m.TotalFirst).Value ,
                                            TotalSecond = g.Sum(m => m.TotalSecond).Value
                                        }).ToList<IViewBattlResults>();

            IList<IViewBattlResults> result = groupedResultByBattl.OrderByDescending(o => o.BattlId).ToList();

            return result;
        }

        #endregion IList<IViewBattlResults> GetBattlsWonByProfileId( int profileId , int count = 0 )

        #region IList<IViewBattlResults> GetBattlsLostByProfileId( int profileId , int count = 0 )

        public IList<IViewBattlResults> GetBattlsLostByProfileId( int profileId , int count = 0 )
        {
            IDataQuery query = new DataQuery();
            query.Where = string.Format(" ViewBattlResults.profileId={0}" , profileId);
            query.OrderBy = " battlId DESC ";

            IList<IViewBattlResults> retorno = new List<IViewBattlResults>();

            retorno = _battlRepository.Find(query);

            var groupedResultByBattl = (from n in retorno
                                        group n by n.BattlId into g
                                        orderby g.Key
                                        let batll = g.FirstOrDefault()
                                        select new ViewBattlResults
                                        {
                                            BattlId = g.Key ,
                                            ProfileId = batll.ProfileId ,
                                            FirstSongId = batll.FirstSongId ,
                                            SecondSongId = batll.SecondSongId ,
                                            ArtistNameFirst = batll.ArtistNameFirst ,
                                            ArtistNameSecond = batll.ArtistNameSecond ,
                                            TotalFirst = g.Sum(m => m.TotalFirst).Value ,
                                            TotalSecond = g.Sum(m => m.TotalSecond).Value
                                        }).ToList<IViewBattlResults>();

            IList<IViewBattlResults> result = groupedResultByBattl.OrderByDescending(o => o.BattlId).ToList();

            return result;
        }

        #endregion IList<IViewBattlResults> GetBattlsLostByProfileId( int profileId , int count = 0 )
    }
}