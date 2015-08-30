namespace MusicBattlDAL.models.interfaces
{
    public interface IVote
    {
        int VoteId { get; set; }

        int? BattlId { get; set; }

        int SongId { get; set; }

        int ProfileId { get; set; }

        int Votes { get; set; }
    }
}