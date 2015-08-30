using System;

namespace MusicBattlDAL.models.interfaces
{
    public interface IBattl
    {
        int BattlId { get; set; }

        int FirstSongId { get; set; }

        int SecondSongId { get; set; }

        DateTime StartTime { get; set; }

        DateTime EndTime { get; set; }

        DateTime BattlDate { get; set; }

        bool Active { get; set; }
    }
}