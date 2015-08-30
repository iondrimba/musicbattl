namespace MusicBattlDAL.repositories.interfaces
{
    public interface IProfileQueryParams
    {
        string ProfileId { set; get; }

        string UserId { set; get; }

        string Picture { set; get; }

        string Upadted { set; get; }

        string Removed { set; get; }
    }
}