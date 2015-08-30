namespace MusicBattlDAL.models.interfaces
{
    public interface IViewTopUsers
    {
        int ProfileId { get; set; }

        int UsuarioId { get; set; }

        int? TotalVotes { get; set; }

        string Name { get; set; }

        string Picture { get; set; }

        string Gender { get; set; }
    }
}