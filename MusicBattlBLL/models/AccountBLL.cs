using Microsoft.Practices.EnterpriseLibrary.Data;
using MusicBattlBLL.interfaces;
using MusicBattlDAL;
using MusicBattlDAL.concrete;
using MusicBattlDAL.interfaces;
using MusicBattlDAL.models.interfaces;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace MusicBattlBLL.models
{
    public class AccountBLL : IAccountBLL
    {
        private IRepositoryBLL<IUsuario> _repository;
        private IRepositoryBLL<IProfile> _repositoryProfile;
        private IRepository<IActivityLog> _repositoryActivityLog;
        private Database _dataBase;        

        public AccountBLL(IRepositoryBLL<IUsuario> repository,
        IRepositoryBLL<IProfile> repositoryProfile,
         IRepository<IActivityLog> repositoryActivityLog)
        {
            this._repository = repository;
            this._repositoryProfile = repositoryProfile;
            this._repositoryActivityLog = repositoryActivityLog;
            _dataBase = ((UsuarioRepository)repository.repositorieDAL).DataBase ;
        }

        #region IAccount Members

        #region IUsuario SignIn( string password , string email )

        public IUsuario SignIn(string password, string email)
        {
            IDataQuery query = new DataQuery();
            string emailcrypted = Security.Encrypt(Security.ClearSQLInjection(email));
            string passw = PasswordHash.CreateHash(Security.ClearSQLInjection(password));

            query.Where = string.Format("email='{0}'", emailcrypted);

            IList<IUsuario> result = _repository.Find(query);
            IUsuario retorno = new Usuario();

            if (result.Count > 0)
            {
                retorno = result[0];

                if (PasswordHash.ValidatePassword(password, retorno.Password))
                {
                    IActivityLog activityLog1 = new ActivityLog();
                    activityLog1.ActionId = 929;
                    activityLog1.Date = DateTime.Now;
                    activityLog1.UserId = retorno.UsuarioId;
                    this._repositoryActivityLog.Add(activityLog1);
                }
                else
                {
                    retorno.UsuarioId = 0;
                }
            }
            return retorno;
        }

        #endregion IUsuario SignIn( string password , string email )

        #region IUsuario SignIn( Int64 socialCustomId )

        public IUsuario SignIn(string socialCustomId)
        {
            IDataQuery query = new DataQuery();
            query.Where = string.Format("customId='{0}'", Security.ClearSQLInjection(socialCustomId));

            IList<IUsuario> result = _repository.Find(query);
            IUsuario retorno = new Usuario();

            if (result.Count > 0)
            {
                retorno = result[0];

                IActivityLog activityLog1 = new ActivityLog();
                activityLog1.ActionId = 929;
                activityLog1.Date = DateTime.Now;
                activityLog1.UserId = retorno.UsuarioId;
                this._repositoryActivityLog.Add(activityLog1);
            }

            retorno.CustomId = socialCustomId;

            return retorno;
        }

        #endregion IUsuario SignIn( Int64 socialCustomId )

        #region IProfile CreateAccount( IUsuario usuario )

        public IProfile CreateAccount(AccountUser usuario)
        {
            IProfile result = new Profile();

            using (TransactionScope scope = new TransactionScope())
            {
                usuario.Created = DateTime.Now;
                usuario.City = Security.ClearSQLInjection(usuario.City);
                usuario.Country = Security.ClearSQLInjection(usuario.Country);
                usuario.CustomId = Security.ClearSQLInjection(usuario.CustomId);
                usuario.Email = Security.ClearSQLInjection(usuario.Email);
                usuario.Name = Security.ClearSQLInjection(usuario.Name);
                usuario.Password = Security.ClearSQLInjection(usuario.Password);
                usuario.Picture = Security.ClearSQLInjection(usuario.Picture);
                usuario.Gender = Security.ClearSQLInjection(usuario.Gender);

                string emailcrypted = Security.Encrypt(usuario.Email);
                string passw = PasswordHash.CreateHash(usuario.Password);
                
                usuario.Email = emailcrypted;
                usuario.Password = passw;

                IUsuario iusuario = _repository.Add(usuario);

                ProfileRepository profile = new ProfileRepository(_dataBase);
                IProfile newProfile = new Profile();
                newProfile.UserId = iusuario.UsuarioId;
                newProfile.Upadted = DateTime.Now;
                newProfile.Picture = Security.ClearSQLInjection(usuario.Picture);
                result = profile.Add(newProfile);

                scope.Complete();
            }

            return result;
        }

        #endregion IProfile CreateAccount( IUsuario usuario )

        #region IUsuario UpdateAccount( IUsuario usuario )

        public IUsuario UpdateAccount(IUsuario usuario)
        {
            IUsuario result = _repository.GetById(usuario.UsuarioId);
            result.Name = Security.ClearSQLInjection(usuario.Name);
            result.City = Security.ClearSQLInjection(usuario.City);
            result.Country = Security.ClearSQLInjection(usuario.Country);
            result.Birthdate = usuario.Birthdate;

            result = _repository.Update(result);

            IActivityLog activityLog1 = new ActivityLog();
            activityLog1.ActionId = 1009;
            activityLog1.Date = DateTime.Now;
            activityLog1.UserId = usuario.UsuarioId;
            this._repositoryActivityLog.Add(activityLog1);

            return result;
        }

        #endregion IUsuario UpdateAccount( IUsuario usuario )

        #region IUsuario Get( int usuarioId )

        public IUsuario Get(int usuarioId)
        {
            IDataQuery query = new DataQuery();
            query.Where = string.Format("usuarioId={0}", usuarioId);

            IList<IUsuario> result = _repository.Find(query);
            IUsuario usuario = new Usuario();

            if (result.Count > 0)
            {
                usuario = result[0];
            }

            return usuario;
        }

        #endregion IUsuario Get( int usuarioId )

        public IProfile ProfileExists(AccountUser usuario)
        {
            IDataQuery query = new DataQuery();
            query.Where = string.Format("customId='{0}'", Security.ClearSQLInjection(usuario.CustomId));

            IList<IUsuario> result = _repository.Find(query);
            IProfile profile = new Profile();

            if (result.Count > 0)
            {
                query.Where = string.Format("userId={0} and removed=0", result[0].UsuarioId);
                profile = _repositoryProfile.Find(query)[0];
            }

            return profile;
        }

        #region IProfile GetProfile( int usuarioId )

        public IProfile GetProfile(int usuarioId)
        {
            IDataQuery query = new DataQuery();
            query.Where = string.Format("userId={0} and removed=0", usuarioId);

            IList<IProfile> result = _repositoryProfile.Find(query);
            IProfile profile = new Profile();

            if (result.Count > 0)
            {
                profile = result[0];
            }

            return profile;
        }

        #endregion IProfile GetProfile( int usuarioId )

        #region IUsuario ChangePassword( string currentPassword , string newPassword , string confirmPassword )

        public IUsuario ChangePassword(int usuarioId, string currentPassword, string newPassword, string confirmPassword)
        {
            IDataQuery query = new DataQuery();
            query.Where = string.Format("usuarioId={0}", usuarioId);

            IList<IUsuario> result = _repository.Find(query);

            IUsuario usuario = result[0];
            string passw = PasswordHash.CreateHash(Security.ClearSQLInjection(newPassword));
            usuario.Password = passw;

            usuario = _repository.Update(usuario);

            return usuario;
        }

        #endregion IUsuario ChangePassword( string currentPassword , string newPassword , string confirmPassword )

        #region bool SignOut(int id)

        public bool SignOut(int id)
        {
            IActivityLog activityLog1 = new ActivityLog();
            activityLog1.ActionId = 1008;
            activityLog1.Date = DateTime.Now;
            activityLog1.UserId = id;
            this._repositoryActivityLog.Add(activityLog1);

            return true;
        }

        #endregion bool SignOut(int id)

        #region bool DeleteAccount( int usuarioId )

        public bool DeleteAccount(int usuarioId)
        {
            bool result = false;
            
            using (TransactionScope scope = new TransactionScope())
            {
                IDataQuery query = new DataQuery();
                query.Where = string.Format("userId={0}", usuarioId);
                IList<IProfile> collection = _repositoryProfile.Find(query);
                if (collection.Count > 0)
                {
                    VoteRepository voteRepository = new VoteRepository(_dataBase);
                    query.Where = string.Format("profileId={0}", collection[0].ProfileId);
                    IList<IVote> votes = voteRepository.Find(query);

                    foreach (IVote vote in votes)
                    {
                        voteRepository.Remove(vote.VoteId);
                    }

                    _repositoryProfile.Remove(collection[0].ProfileId);

                    result = _repository.Remove(usuarioId);
                }
            }

            return result;
        }

        #endregion bool DeleteAccount( int usuarioId )

        #endregion IAccount Members

        #region IAccountBLL Members

        public AccountUser GetAccount(int userId)
        {
            AccountUser retorno = new AccountUser();

            IDataQuery query = new DataQuery();
            query.Where = string.Format("usuarioId={0}", userId);
            IList<IUsuario> result = _repository.Find(query);
            IProfile profile = new Profile();
            IUsuario usuario = new Usuario();

            if (result.Count > 0)
            {
                usuario = result[0];
                query.Where = string.Format("userId={0} and removed=0", result[0].UsuarioId);
                profile = _repositoryProfile.Find(query)[0];

                retorno.Birthdate = usuario.Birthdate;
                retorno.Created = usuario.Created;
                retorno.CustomId = usuario.CustomId;
                retorno.Email = usuario.Email;
                retorno.Gender = usuario.Gender;
                retorno.Name = usuario.Name;
                retorno.UsuarioId = usuario.UsuarioId;
                retorno.City = usuario.City;
                retorno.Country = usuario.Country;

                retorno.Picture = profile.Picture;
                retorno.ProfileId = profile.ProfileId;
                retorno.UserId = profile.UserId;
            }

            return retorno;
        }

        #endregion IAccountBLL Members

        #region IProfile UpdateProfile( IProfile profile )

        public IProfile UpdateProfile(IProfile profile)
        {
            IProfile result = _repositoryProfile.Update(profile);

            return result;
        }

        #endregion IProfile UpdateProfile( IProfile profile )
    }
}