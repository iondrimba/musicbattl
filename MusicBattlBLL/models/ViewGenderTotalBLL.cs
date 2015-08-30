using System.Collections.Generic;
using System.Linq;
using MusicBattlBLL.interfaces;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.models
{
    public class ViewGenderTotalBLL : IViewGenderTotalBLL
    {
        private IRepositoryBLL<IViewGenderTotal> _repository;
        private IDataBaseAccess _dataBaseAccess;

        public ViewGenderTotalBLL( IRepositoryBLL<IViewGenderTotal> repository )
        {
            _repository = repository;
            _dataBaseAccess = _repository.repositorieDAL.DataBaseAccess;
        }

        #region IViewGenderTotalBLL Members

        public IList<IPieChartItem> GetTotals()
        {
            IList<IPieChartItem> retorno = new List<IPieChartItem>();

            IDataQuery query = new DataQuery();            

            IViewGenderTotal viewGenderTotal = _repository.Find(query).FirstOrDefault();

            IPieChartItem totalFemale = new PieChartItem();
            totalFemale.Value = ((decimal)(viewGenderTotal.Total * viewGenderTotal.TotalFemale) / 100);
            totalFemale.Legend = "Female";

            IPieChartItem totalMale = new PieChartItem();
            totalMale.Value = ((decimal)(viewGenderTotal.Total * viewGenderTotal.TotalMale) / 100);
            totalMale.Legend = "Male";

            retorno.Add(totalMale);
            retorno.Add(totalFemale);

            return retorno;
        }

        #endregion IViewGenderTotalBLL Members
    }
}