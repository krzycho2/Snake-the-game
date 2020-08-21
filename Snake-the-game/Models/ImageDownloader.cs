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
        protected Bitmap Image { get; set; }

        protected async Task DownloadImageAsync(string url)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    var imageBytes = await webClient.DownloadDataTaskAsync(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        var ms = new MemoryStream(imageBytes);
                        Image = new Bitmap(ms);
                    }
                }
            }
            catch (WebException)
            {
                Console.WriteLine("Wykryty błąd z siecią, nie pobrano obrazka.");
            }
        }
    }
}
