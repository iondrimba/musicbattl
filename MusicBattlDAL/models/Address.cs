using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class Address : IAddress
    {
        #region Properties

        private int _addressId;

        public int AddressId
        {
            get { return _addressId; }
            set { _addressId = value; }
        }

        private int _profileId;

        public int ProfileId
        {
            get { return _profileId; }
            set { _profileId = value; }
        }

        private string _country;

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        #endregion Properties

        #region Constructor

        public Address()
        {
        }

        #endregion Constructor
    }
}