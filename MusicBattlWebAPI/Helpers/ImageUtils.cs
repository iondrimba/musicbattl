using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web;

namespace MusicBattlWebAPI.Helpers
{
    public static class ImageUtils
    {
        public static void Save(HttpPostedFile file, string path)
        {
            FileStream stream = new FileStream(Path.GetFullPath(path), FileMode.OpenOrCreate);

            // Convert our uploaded file to an image
            Image OrigImage = Image.FromStream(file.InputStream);
            OrigImage.Save(stream, OrigImage.RawFormat);
            stream.Dispose();
            stream.Close();
        }

        public static void ResizeAndSave(HttpPostedFile file, string path, int width, int height, Color backGroundColor)
        {
            FileStream stream = new FileStream(Path.GetFullPath(path), FileMode.OpenOrCreate);
            Image OrigImage = Image.FromStream(file.InputStream);
            Bitmap temp = ResizeImage(OrigImage, width, height, backGroundColor);
            
            temp.Save(stream, OrigImage.RawFormat);
            OrigImage.Dispose();
            temp.Dispose();
            stream.Dispose();
            stream.Close();
        }

        public static void ResizeAndSave(string file, string path, int width, int height, Color backGroundColor)
        {
            Image OrigImage = Image.FromFile(file);
            Bitmap temp = ResizeImage(OrigImage, width, height, backGroundColor);

            temp.Save(path, OrigImage.RawFormat);
            OrigImage.Dispose();
            temp.Dispose();
        }

        public static Bitmap ResizeImage(Image image, int width, int height, Color backGroundColor)
        {
            // Create a new bitmap with the size of our
            // thumbnail
            Bitmap TempBitmap = new Bitmap(width, height);

            // Create a new image that contains quality
            // information
            Graphics resized = Graphics.FromImage(TempBitmap);
            resized.CompositingQuality = CompositingQuality.HighQuality;
            resized.SmoothingMode = SmoothingMode.HighQuality;
            resized.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Figure out the ratio
            double ratioX = (double)width / (double)image.Width;
            double ratioY = (double)height / (double)image.Height;
            // use whichever multiplier is smaller
            double ratio = ratioX < ratioY ? ratioX : ratioY;

            // now we can get the new height and width
            int newHeight = Convert.ToInt32(image.Height * ratio);
            int newWidth = Convert.ToInt32(image.Width * ratio);

            // Now calculate the X,Y position of the upper-left corner
            // (one of these will always be zero)
            int posX = Convert.ToInt32((width - (image.Width * ratio)) / 2);
            int posY = Convert.ToInt32((height - (image.Height * ratio)) / 2);

            resized.Clear(backGroundColor);
            resized.DrawImage(image, posX, posY, newWidth, newHeight);

            return TempBitmap;
        }
    }
}