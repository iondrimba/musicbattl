using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MusicBattlBLL.interfaces;
using MusicBattlBLL.models;
using MusicBattlDAL;
using MusicBattlDAL.models.interfaces;
using MusicBattlWebAPI.Helpers;

namespace MusicBattlWebAPI.Controllers
{
    public class AccountController : System.Web.Http.ApiController
    {
        private IAccountBLL model;

        public AccountController( IAccountBLL model )
        {
            this.model = model;
        }

        [HttpPost]
        public object Create( AccountUser accountUser )
        {
            IProfile profile = new Profile();
            AccountUser retorno = new AccountUser();

            if( !String.IsNullOrEmpty(accountUser.CustomId) )
            {
                profile = this.model.ProfileExists(accountUser);
            }

            if( profile.UserId == 0 )
            {
                profile = this.model.CreateAccount(accountUser);
            }

            retorno = this.model.GetAccount(profile.UserId);

            var simpleResult = CleanUser(retorno);

            return simpleResult;
        }

        private object CleanUser( AccountUser pAccountUser)
        {
               var retorno =  new {
                    Birthdate = pAccountUser.Birthdate,
                    City = pAccountUser.City,
                    Country = pAccountUser.Country,                    
                    CustomId = pAccountUser.CustomId,
                    Name = pAccountUser.Name,
                    Picture = pAccountUser.Picture,
                    ProfileId = pAccountUser.ProfileId,
                    UserId = pAccountUser.UserId
                };

                return retorno;
        }

        [HttpPost]
        public object UserUpdate( AccountUser accountUser )
        {
            IUsuario usuario = this.model.UpdateAccount((IUsuario)accountUser);
            AccountUser retorno = this.model.GetAccount(usuario.UsuarioId);

            var simpleResult = CleanUser(retorno);

            return simpleResult;
        }

        [HttpGet]
        public object UserDetails( int id )
        {
            AccountUser profile = new AccountUser();

            profile = this.model.GetAccount(id);

            var simpleResult = CleanUser(profile);

            return simpleResult;
        }

        [HttpPost]
        public object SignIn( AccountUser accountUser )
        {        
            IUsuario usuario = this.model.SignIn(accountUser.Password, accountUser.Email);
            AccountUser retorno = this.model.GetAccount(usuario.UsuarioId);

            if( retorno.UsuarioId == 0 )
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No user found!" , accountUser.Email)) ,
                    ReasonPhrase = "User not Found"
                };
                throw new HttpResponseException(resp);
            }

            var simpleResult = CleanUser(retorno);

            return simpleResult;
        }

        [HttpPost]
        public object SignIn( string id )
        {
            IUsuario usuario = this.model.SignIn(id);
            AccountUser retorno = this.model.GetAccount(usuario.UsuarioId);

            if( retorno.UsuarioId == 0 && String.IsNullOrEmpty(usuario.CustomId) )
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("No user found") ,
                    ReasonPhrase = "Error"
                };
                throw new HttpResponseException(resp);
            }

            var simpleResult = CleanUser(retorno);

            return simpleResult;
        }

        [HttpPost]
        public object ChangePassword( PassWordChange passWordChange )
        {
            AccountUser retorno = new AccountUser();

            try
            {
                IUsuario usuario = this.model.ChangePassword(passWordChange.IdUsuario
                , passWordChange.CurrentPassword
                , passWordChange.NewPassword
                , passWordChange.ConfirmPassword);

                retorno = this.model.GetAccount(usuario.UsuarioId);
            }
            catch( Exception ex )
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message) ,
                    ReasonPhrase = "Error!"
                };
                throw new HttpResponseException(resp);
            }


            var simpleResult = CleanUser(retorno);

            return simpleResult;
        }

        [HttpPost]
        public object SaveProfileImage()
        {
            HttpContext httpContext = HttpContext.Current;

            if( httpContext.Request.Files.Count == 0 )
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NoContent)
                {
                    Content = new StringContent("No file was sent!") ,
                    ReasonPhrase = "Error"
                };
                throw new HttpResponseException(resp);
            }

            IProfile profile = this.model.GetProfile(Convert.ToInt32(httpContext.Request.Form[5].ToString()));

            try
            {
                string pastaSmall = "/Files/profile/small";
                string pastaMini = "/Files/profile/mini";
                string pastaFull = "/Files/profile";
                HttpPostedFile postedFile = httpContext.Request.Files[0];
                string postedFileName = Path.GetFileName(postedFile.FileName);
                string extensao = Path.GetExtension(postedFileName);                
                string nome = GetRandomFileName();
                string arquivoNome = string.Format("{0}{1}" , nome , extensao);
                string filePathSmall = Path.Combine(httpContext.Server.MapPath(pastaSmall) , Path.GetFileName(arquivoNome));
                string filePathMini = Path.Combine(httpContext.Server.MapPath(pastaMini) , Path.GetFileName(arquivoNome));
                string filePathFull = Path.Combine(httpContext.Server.MapPath(pastaFull) , Path.GetFileName(arquivoNome));

                ImageUtils.ResizeAndSave(postedFile,filePathSmall, 60,60, Color.Black);

                ImageUtils.ResizeAndSave(postedFile , filePathMini , 49, 49 , Color.Black);

                ImageUtils.ResizeAndSave(postedFile , filePathFull , 154 , 154, Color.Black);

                profile.Picture = arquivoNome;

                this.model.UpdateProfile(profile);
            }
            catch( Exception ex )
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message) ,
                    ReasonPhrase = "Error"
                };
                throw new HttpResponseException(resp);
            }
            AccountUser retorno = this.model.GetAccount(profile.UserId);

            var simpleResult = CleanUser(retorno);

            return simpleResult;
        }

        private string GetRandomFileName()
        {
            string fileName = string.Empty;

            string random = System.IO.Path.GetRandomFileName().Replace("." , string.Empty);
            System.Random randomInt = new System.Random((int)System.DateTime.Now.Ticks);
            int start = 1;
            int size = 10000000;
            int resultRandomInt = randomInt.Next(start , size);
            string date = DateTime.Now.ToString("yymmddhhmmssmmmm");
            fileName = string.Format("{0}{1}-{2}" , random , resultRandomInt , date);

            return fileName;
        }

        [HttpPost]
        public void SignOut( int id )
        {
            this.model.SignOut(id);
        }
    }
}