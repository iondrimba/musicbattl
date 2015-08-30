namespace MusicBattlDAL.models.interfaces
{
    public interface IViewActivityByHour
    {
        int Hour { get; set; }

        int? TotalByHour { get; set; }
    }
}