namespace MusicBattlDAL.repositories.interfaces
{
    public interface IAddressQueryParams
    {
        string AddressId { set; get; }

        string ProfileId { set; get; }

        string Country { set; get; }

        string City { set; get; }
    }
}