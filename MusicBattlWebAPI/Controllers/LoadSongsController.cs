using MusicBattlBLL.models;
using MusicBattlWebAPI.Helpers;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace MusicBattlWebAPI.Controllers
{
    public class LoadSongsController : Controller
    {
        public LoadSongsController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FromBandcamp(string url)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(url);
            StreamReader reader = new StreamReader(stream);
            String content = reader.ReadToEnd();

            var data = new
            {
                html = content
            };

            return Json(data);
        }

        public ActionResult GetArtistDetails(string url)
        {
            WebClient myWebClient = new WebClient();
            byte[] myDataBuffer = myWebClient.DownloadData(url);

            // Display the downloaded data.
            string download = Encoding.ASCII.GetString(myDataBuffer);

            var data = new
            {
                html = download
            };

            return Json(data);
        }

        [HttpPost]
        public ActionResult Save(LoadSongsViewModel model)
        {
            //ALBUM
            string pasta = "/img/album";
            string pastaSmall = string.Format("{0}/small", pasta);
            string pastaMini = string.Format("{0}/mini", pasta);
            string pastaMedia = string.Format("{0}/medium", pasta);
            string pastaTemp = string.Format("{0}/temp", pasta);

            string postedFileName = Path.GetFileName(model.Album.AlbumCover);
            string extensao = Path.GetExtension(postedFileName);
            string nome = model.Album.Name.Trim().Replace(" ", string.Empty).ToLower();
            string arquivoNome = string.Format("{0}{1}", nome, extensao);

            string filePathSmall = Path.Combine(Server.MapPath(pastaSmall), Path.GetFileName(arquivoNome));
            string filePathMini = Path.Combine(Server.MapPath(pastaMini), Path.GetFileName(arquivoNome));
            string filePathMedia = Path.Combine(Server.MapPath(pastaMedia), Path.GetFileName(arquivoNome));
            string filePathFull = Path.Combine(Server.MapPath(pasta), Path.GetFileName(arquivoNome));
            string filePathTemp = Path.Combine(Server.MapPath(pastaTemp), Path.GetFileName(arquivoNome));

            System.IO.Directory.CreateDirectory(Server.MapPath(pastaTemp));

            WebClient client = new WebClient();
            client.DownloadFile(model.Album.AlbumCover, filePathTemp);
            model.Album.AlbumCover = arquivoNome;
            ImageUtils.ResizeAndSave(filePathTemp, filePathSmall, 78, 78, Color.Black);
            ImageUtils.ResizeAndSave(filePathTemp, filePathMini, 62, 62, Color.Black);
            ImageUtils.ResizeAndSave(filePathTemp, filePathMedia, 150, 150, Color.Black);
            ImageUtils.ResizeAndSave(filePathTemp, filePathFull, 220, 220, Color.Black);
            System.IO.Directory.Delete(Server.MapPath(pastaTemp), true);

            //ARTISTA
            nome = model.Artist.Name.Trim().Replace(" ", string.Empty).ToLower();
            arquivoNome = string.Format("{0}{1}", nome, extensao);

            string pastaArtista = "/img/artist";
            string pastaArtistaMini = string.Format("{0}/mini", pastaArtista);
            string pastaArtistaFull = string.Format("{0}/", pastaArtista);
            string pastaArtistaTemp = string.Format("{0}/temp", pastaArtista);
            string filePathTempArtista = Path.Combine(Server.MapPath(pastaArtistaTemp), Path.GetFileName(arquivoNome));
            System.IO.Directory.CreateDirectory(Server.MapPath(pastaArtistaTemp));

            if (model.Artist.Picture != null)
            {
                WebClient clientArtista = new WebClient();
                clientArtista.DownloadFile(model.Artist.Picture, filePathTempArtista);
                string filePathArtistaMini = Path.Combine(Server.MapPath(pastaArtistaMini), Path.GetFileName(arquivoNome));
                string filePathArtistaFull = Path.Combine(Server.MapPath(pastaArtistaFull), Path.GetFileName(arquivoNome));
                ImageUtils.ResizeAndSave(filePathTempArtista, filePathArtistaMini, 78, 78, Color.Black);
                ImageUtils.ResizeAndSave(filePathTempArtista, filePathArtistaFull, 220, 220, Color.Black);
                System.IO.Directory.Delete(Server.MapPath(pastaArtistaTemp), true);
                model.Artist.Picture = arquivoNome;
            }

            model.Save();

            return Json(model);
        }
    }
}