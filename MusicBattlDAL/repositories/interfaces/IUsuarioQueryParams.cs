namespace MusicBattlDAL.repositories.interfaces
{
    public interface IUsuarioQueryParams
    {
        string UsuarioId { set; get; }

        string Name { set; get; }

        string Birthdate { set; get; }

        string Password { set; get; }

        string Created { set; get; }

        string Udated { set; get; }

        string Gender { set; get; }

        string Email { set; get; }
    }
}