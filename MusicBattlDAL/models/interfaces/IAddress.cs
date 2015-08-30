namespace MusicBattlDAL.models.interfaces
{
    public interface IAddress
    {
        int AddressId { get; set; }

        int ProfileId { get; set; }

        string Country { get; set; }

        string City { get; set; }
    }
}