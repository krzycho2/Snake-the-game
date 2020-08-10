using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_the_game.Models
{
    public class ImageDownloader
    {
        public Bitmap DownloadImage(string url)
        {
            System.Net.WebRequest request =
                  System.Net.WebRequest.Create(url);
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream =
                response.GetResponseStream();
            return new Bitmap(responseStream);
        }
    }
}
