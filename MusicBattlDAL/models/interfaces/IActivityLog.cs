using System;

namespace MusicBattlDAL.models.interfaces
{
    public interface IActivityLog
    {
        int ActivityLogId { get; set; }

        int UserId { get; set; }

        int ActionId { get; set; }

        DateTime Date { get; set; }
    }
}