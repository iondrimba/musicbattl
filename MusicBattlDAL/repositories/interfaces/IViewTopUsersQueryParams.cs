namespace MusicBattlDAL.repositories.interfaces
{
    public interface IViewTopUsersQueryParams
    {
        string ProfileId { set; get; }

        string UsuarioId { set; get; }

        string TotalVotes { set; get; }

        string Name { set; get; }

        string Picture { set; get; }

        string Gender { set; get; }
    }
}