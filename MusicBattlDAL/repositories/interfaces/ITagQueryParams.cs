namespace MusicBattlDAL.repositories.interfaces
{
    public interface ITagQueryParams
    {
        string TagId { set; get; }

        string OwnerTableId { set; get; }

        string OwnerId { set; get; }

        string Name { set; get; }
    }
}