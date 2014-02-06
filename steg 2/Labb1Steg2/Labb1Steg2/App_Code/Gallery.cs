using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Labb1Steg2.App_Code
{
    public class Gallery
    {
        //Fält
        private static readonly Regex ApprovedExtenstions;

        //Egenskap
        public static string PhysicalApplicationPath { get; set; }

        //Konstruktor
        static Gallery()
        {
            ApprovedExtenstions = new Regex(@"^.*\.(gif|GIF|jpg|JPG|png|PNG)$");
        }

        //Metoder
        public List<string> GetImageNames()
        {
            List<string> imgFileNames = new List<string>();
            string imgPath = PhysicalApplicationPath;

            var di = new DirectoryInfo(imgPath);

            var files = di.GetFiles();

            foreach (FileInfo item in files)
            {
                imgFileNames.Add(item.Name);
            }

            return imgFileNames;
        }

        public static bool ImageExist(string name)
        {
            if (File.Exists(PhysicalApplicationPath + name))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool IsValidImage(Image image)
        {
            if (image.RawFormat.Guid == ImageFormat.Gif.Guid || image.RawFormat.Guid ==
                ImageFormat.Jpeg.Guid || image.RawFormat.Guid == ImageFormat.Png.Guid)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public string SaveImage(Stream stream, string fileName)
        {
            var image = System.Drawing.Image.FromStream(stream);
            string imgPath = PhysicalApplicationPath + fileName;
            string fileExt = Path.GetExtension(imgPath);
            string name = Path.GetFileNameWithoutExtension(imgPath);
            int i = 2;

            //lägg till en siffra om filnamnet redan finns
            if (ImageExist(fileName))
            {
                fileName = string.Format("{0}{1}{2}", name, i++, fileExt);
            }

            //spara bilden m thumb
            if (IsValidImage(image))
            {
                image.Save(Path.GetFullPath(PhysicalApplicationPath + fileName));
                var thumb = image.GetThumbnailImage(60, 45, null, System.IntPtr.Zero);
                thumb.Save(Path.GetFullPath(PhysicalApplicationPath + @"\thumbs\" + fileName));

            }


            else
            {
                throw new ArgumentException("Bilden har fel format");
            }

            return fileName;
        }
    }
}