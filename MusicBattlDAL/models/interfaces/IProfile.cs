using System;

namespace MusicBattlDAL.models.interfaces
{
    public interface IProfile
    {
        int ProfileId { get; set; }

        int UserId { get; set; }

        string Picture { get; set; }

        DateTime Upadted { get; set; }

        bool Removed { get; set; }
    }
}