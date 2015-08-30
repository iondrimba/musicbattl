namespace MusicBattlDAL.repositories.interfaces
{
    public interface ISocialQueryParams
    {
        string SocialId { set; get; }

        string UserId { set; get; }

        string SocialTypeId { set; get; }
    }
}