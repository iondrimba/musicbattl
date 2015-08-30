using System;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class ActivityLog : IActivityLog
    {
        #region Properties

        private int _activityLogId;

        public int ActivityLogId
        {
            get { return _activityLogId; }
            set { _activityLogId = value; }
        }

        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private int _actionId;

        public int ActionId
        {
            get { return _actionId; }
            set { _actionId = value; }
        }

        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        #endregion Properties

        #region Constructor

        public ActivityLog()
        {
        }

        #endregion Constructor
    }
}