using System.Collections.Generic;
using System.Linq;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.models
{
    public class ViewUserAgesTotalBLL : IViewUserAgesTotalBLL
    {
        private IRepositoryBLL<IViewUserAges> _repository;
        private IDataBaseAccess _dataBaseAccess;

        public ViewUserAgesTotalBLL( IRepositoryBLL<IViewUserAges> repository )
        {
            _repository = repository;
            _dataBaseAccess = _repository.repositorieDAL.DataBaseAccess;
        }

        #region IViewUserAgesTotalBLL Members

        public IList<IPieChartItem> GetTotals()
        {
            IList<IPieChartItem> retorno = new List<IPieChartItem>();

            IDataQuery query = new DataQuery();

            IList<IViewUserAges> collection = _repository.Find(query);

            int[] usersAgeBetween15_25 = collection.Where(m => m.Age.GetValueOrDefault() >= 15 && m.Age.GetValueOrDefault() <= 25).Select(m => m.Age.GetValueOrDefault()).ToArray<int>();
            int[] usersAgeBetween26_40 = collection.Where(m => m.Age.GetValueOrDefault() >= 26 && m.Age.GetValueOrDefault() <= 40).Select(m => m.Age.GetValueOrDefault()).ToArray<int>();
            int[] usersAgeBetween41_60 = collection.Where(m => m.Age.GetValueOrDefault() >= 41 && m.Age.GetValueOrDefault() <= 60).Select(m => m.Age.GetValueOrDefault()).ToArray<int>();

            IPieChartItem total15_25 = new PieChartItem();
            total15_25.Value = usersAgeBetween15_25.Length;
            total15_25.Legend = "15 - 25";

            IPieChartItem total26_40 = new PieChartItem();
            total26_40.Value = usersAgeBetween26_40.Length;
            total26_40.Legend = "26 - 40";

            IPieChartItem total41_60 = new PieChartItem();
            total41_60.Value = usersAgeBetween41_60.Length;
            total41_60.Legend = "41 - 60";

            retorno.Add(total15_25);
            retorno.Add(total26_40);
            retorno.Add(total41_60);

            return retorno;
        }

        #endregion IViewUserAgesTotalBLL Members
    }
}