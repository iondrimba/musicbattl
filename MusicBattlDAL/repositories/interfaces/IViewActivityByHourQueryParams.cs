namespace MusicBattlDAL.repositories.interfaces
{
    public interface IViewActivityByHourQueryParams
    {
        string Hour { set; get; }

        string TotalByHour { set; get; }
    }
}