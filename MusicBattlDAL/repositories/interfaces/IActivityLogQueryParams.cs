namespace MusicBattlDAL.repositories.interfaces
{
    public interface IActivityLogQueryParams
    {
        string ActivityLogId { set; get; }

        string UserId { set; get; }

        string ActionId { set; get; }

        string Date { set; get; }
    }
}