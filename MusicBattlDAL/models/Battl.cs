using System;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlDAL
{
    public class Battl : IBattl
    {
        #region Properties

        private int _battlId;

        public int BattlId
        {
            get { return _battlId; }
            set { _battlId = value; }
        }

        private int _firstSongId;

        public int FirstSongId
        {
            get { return _firstSongId; }
            set { _firstSongId = value; }
        }

        private int _secondSongId;

        public int SecondSongId
        {
            get { return _secondSongId; }
            set { _secondSongId = value; }
        }

        private DateTime _startTime;

        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        private DateTime _endTime;

        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        private DateTime _battlDate;

        public DateTime BattlDate
        {
            get { return _battlDate; }
            set { _battlDate = value; }
        }

        private bool _active;

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        #endregion Properties

        #region Constructor

        public Battl()
        {
        }

        #endregion Constructor
    }
}