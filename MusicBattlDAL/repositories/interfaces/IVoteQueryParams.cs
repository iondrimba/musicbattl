namespace MusicBattlDAL.repositories.interfaces
{
    public interface IVoteQueryParams
    {
        string VoteId { set; get; }

        string BattlId { set; get; }

        string SongId { set; get; }

        string ProfileId { set; get; }

        string Votes { set; get; }
    }
}