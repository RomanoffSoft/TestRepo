using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Technology.VoIP
{
    public static class PhotoPicker
    {

        //public static Bitmap PickPhoto(IEntityContainer Caller)
        //{
        //    try
        //    {
        //        int PersonNumber = Caller.GetAttribute<int>("Номер анкеты");
        //        string path = GetPhotosPath();
        //        if (String.IsNullOrEmpty(path))
        //            return null;
        //        string fileName = PersonNumber.ToString() + ".jpg";
        //        string fullFileName = path + "\\" + fileName;
        //        FileStream stream = new FileStream(fullFileName, FileMode.Open);
        //        Bitmap result = ResizeImage(Image.FromStream(stream), 67, 82);
        //        stream.Close();
        //        stream.Dispose();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        public static Bitmap Convert2Photo(Image Image)
        {
            return ResizeImage(Image, 67, 82);
        }

        private static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
