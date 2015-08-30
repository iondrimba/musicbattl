using System.Collections.Generic;
using System.Linq;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.models
{
    public class ViewActivityByHourBLL : IViewActivityByHourBLL
    {
        private IRepositoryBLL<IViewActivityByHour> _repository;
        private IDataBaseAccess _dataBaseAccess;

        public ViewActivityByHourBLL( IRepositoryBLL<IViewActivityByHour> repository )
        {
            _repository = repository;
            _dataBaseAccess = _repository.repositorieDAL.DataBaseAccess;
        }

        #region IViewActivityByHourBLL Members

        public IList<IPieChartItem> GetTotals()
        {
            IList<IPieChartItem> retorno = new List<IPieChartItem>();

            IDataQuery query = new DataQuery();

            IList<IViewActivityByHour> collection = _repository.Find(query);

            IList<IViewActivityByHour> dayList = collection.Where(m => m.Hour <= 17 && m.Hour >= 6).Select(m => m).ToList<IViewActivityByHour>();
            IList<IViewActivityByHour> nightList = collection.Where(m => m.Hour >= 18 && m.Hour <= 23 || m.Hour >= 0 && m.Hour <= 5).Select(m => m).ToList<IViewActivityByHour>();

            IPieChartItem totalNight = new PieChartItem();
            totalNight.Value = nightList.Sum(m => m.TotalByHour).GetValueOrDefault();
            totalNight.Legend = "Night";

            IPieChartItem totalDay = new PieChartItem();
            totalDay.Value = dayList.Sum(m => m.TotalByHour).GetValueOrDefault();
            totalDay.Legend = "Day";

            retorno.Add(totalNight);
            retorno.Add(totalDay);

            return retorno;
        }

        #endregion IViewActivityByHourBLL Members
    }
}