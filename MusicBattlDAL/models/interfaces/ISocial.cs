namespace MusicBattlDAL.models.interfaces
{
    public interface ISocial
    {
        int SocialId { get; set; }

        int? UserId { get; set; }

        int? SocialTypeId { get; set; }
    }
}