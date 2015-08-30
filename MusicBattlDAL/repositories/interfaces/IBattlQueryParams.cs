namespace MusicBattlDAL.repositories.interfaces
{
    public interface IBattlQueryParams
    {
        string BattlId { set; get; }

        string FirstSongId { set; get; }

        string SecondSongId { set; get; }

        string StartTime { set; get; }

        string EndTime { set; get; }

        string BattlDate { set; get; }
    }
}