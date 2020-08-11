using Snake_the_game.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Snake_the_game.Models
{
    public abstract class ImageDownloader
    {
        protected async Task<Bitmap> DownloadImageAsync(string url)
        {
            Bitmap imageBitmap = null;

            try
            {
                using (var webClient = new WebClient())
                {
                    var imageBytes = await webClient.DownloadDataTaskAsync(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        var ms = new MemoryStream(imageBytes);
                        imageBitmap = new Bitmap(ms);
                    }
                }
            }
            catch (WebException)
            { 
                
            }

            return imageBitmap;
        }
    }
}
