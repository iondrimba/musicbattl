namespace MusicBattlDAL.interfaces
{
    public interface IDataQuery
    {
        string Column { set; get; }

        string From { set; get; }

        string Where { set; get; }

        string OrderBy { set; get; }

        int Page { set; get; }

        int RowCount { set; get; }
    }
}