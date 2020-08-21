using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Snake_the_game.Models
{
    public class SnakeImageDownloader : ImageDownloader, IDisposable
    {
        //private Bitmap Image { get; set; }

        private List<string> ImgLocations { get; set; }

        //private MemoryStream Memory { get; set; } = new MemoryStream();

        public SnakeImageDownloader()
        {
            ImgLocations = new List<string>
            {
                @"https://cdn.pixabay.com/photo/2014/10/25/07/52/king-snake-502263_1280.jpg",
                @"https://cdn.pixabay.com/photo/2019/02/06/17/09/snake-3979601__480.jpg",
                @"https://cdn.pixabay.com/photo/2013/10/15/10/04/snake-195917__480.jpg",
                @"https://cdn.pixabay.com/photo/2016/10/21/19/34/snake-1758994__480.jpg",
                @"https://cdn.pixabay.com/photo/2016/03/28/10/07/snake-1285354__480.jpg",
                @"https://cdn.pixabay.com/photo/2015/02/28/15/25/snake-653639__480.jpg",
                @"https://cdn.pixabay.com/photo/2013/07/13/13/42/animal-161424__480.png",
                @"https://cdn.pixabay.com/photo/2015/05/17/20/39/snake-771541__480.jpg",
                @"https://cdn.pixabay.com/photo/2014/08/15/21/40/snake-419043__480.jpg"
            };
        }

        public async Task DownloadSnakeImg()
        {
            var imgLocation = RandomLocation();
            await DownloadImageAsync(imgLocation);
        }

        private string RandomLocation()
        {
            var rnd = new Random();
            int rndNum = rnd.Next(ImgLocations.Count - 1);
            Console.WriteLine("Wybrany obrazek: " + rndNum.ToString());

            return ImgLocations[rndNum];
        }

        public BitmapImage GetImageSource()
        {
            if (Image == null)
                return null;
            else
                return ConvertBitmapToBitmapImage();
        }

        private BitmapImage ConvertBitmapToBitmapImage()
        {
            using (MemoryStream memory = new MemoryStream())
            {
                Image.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                bitmapimage.Freeze();

                return bitmapimage;
            }
        }

        public void Dispose()
        {
            Image.Dispose();
            GC.Collect();
        }

    }


}
