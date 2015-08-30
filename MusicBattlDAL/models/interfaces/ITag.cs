namespace MusicBattlDAL.models.interfaces
{
    public interface ITag
    {
        int TagId { get; set; }

        int OwnerTableId { get; set; }

        int OwnerId { get; set; }

        string Name { get; set; }
    }
}