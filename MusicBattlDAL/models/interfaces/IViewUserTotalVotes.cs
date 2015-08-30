namespace MusicBattlDAL.models.interfaces
{
    public interface IViewUserTotalVotes
    {
        int? BattlId { get; set; }

        int SongId { get; set; }

        int ProfileId { get; set; }

        int? Total { get; set; }

        string Name { get; set; }

        int UsuarioId { get; set; }

        string Picture { get; set; }

        string SongName { get; set; }

        string Gender { get; set; }
    }
}