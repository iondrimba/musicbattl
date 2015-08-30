using System;

namespace MusicBattlDAL.models.interfaces
{
    public interface IUsuario
    {
        int UsuarioId { get; set; }

        string CustomId { get; set; }

        string Name { get; set; }

        DateTime? Birthdate { get; set; }

        string Password { get; set; }

        DateTime Created { get; set; }

        DateTime? Udated { get; set; }

        string Gender { get; set; }

        string Email { get; set; }

        string City { get; set; }

        string Country { get; set; }
    }
}