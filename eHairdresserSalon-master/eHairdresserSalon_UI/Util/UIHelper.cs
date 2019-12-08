﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace eHairdresserSalon_UI.Util
{
    public class UIHelper
    {
        #region Klijenti

        public static string GenerateSalt()
        {
            byte[] arr = new byte[16];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetBytes(arr);
            return Convert.ToBase64String(arr);
        }

        public static string GenerateHash(string lozinka, string salt)
        {
            byte[] byteLozinka = Encoding.Unicode.GetBytes(lozinka);
            byte[] byteSalt = Convert.FromBase64String(salt);
            byte[] forHashing = new byte[byteLozinka.Length + byteSalt.Length];
            //strcpy strcat
            System.Buffer.BlockCopy(byteLozinka, 0, forHashing, 0, byteLozinka.Length);
            System.Buffer.BlockCopy(byteSalt, 0, forHashing, byteLozinka.Length, byteSalt.Length); //4. parametar, ne pocinjemo na nultoj poziciji forHashinga nego gdje smo stali kod lozinke

            HashAlgorithm alg = HashAlgorithm.Create("SHA1"); //zelimo da koristimo SHA1 algoritam
            return Convert.ToBase64String(alg.ComputeHash(forHashing));
        }

        #endregion

        #region Slike

        public static Image CropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea,
            bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }

        public static Image ResizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

        #endregion
    }
}
