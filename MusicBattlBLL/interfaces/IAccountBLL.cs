using MusicBattlBLL.models;
using MusicBattlDAL.models.interfaces;

namespace MusicBattlBLL.interfaces
{
    public interface IAccountBLL
    {
        IUsuario SignIn( string password , string email );

        IUsuario SignIn( string socialCustomId );

        IProfile CreateAccount( AccountUser usuario );

        IUsuario UpdateAccount( IUsuario usuario );

        IUsuario Get( int usuarioId );

        IProfile GetProfile( int usuarioId );

        IUsuario ChangePassword( int usuarioId , string currentPassword , string newPassword , string confirmPassword );

        bool DeleteAccount( int usuarioId );

        bool SignOut( int id );

        IProfile ProfileExists( AccountUser usuario );

        AccountUser GetAccount( int userId );

        IProfile UpdateProfile( IProfile profile );
    }
}