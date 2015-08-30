namespace MusicBattlDAL.repositories.interfaces
{
    public interface IViewUserTotalVotesQueryParams
    {
        string BattlId { set; get; }

        string SongId { set; get; }

        string ProfileId { set; get; }

        string Total { set; get; }

        string Name { set; get; }

        string UsuarioId { set; get; }

        string Picture { set; get; }

        string SongName { set; get; }

        string Gender { set; get; }
    }
}