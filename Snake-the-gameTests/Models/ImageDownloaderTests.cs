using NUnit.Framework;
using Snake_the_game.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_the_game.Models.Tests
{
    [TestFixture()]
    public class ImageDownloaderTests
    {
        [Test()]
        public async Task DownloadImageAsyncTestAsync()
        {
            var downloader = new ImageDownloader();
            var url = @"https://cdn.pixabay.com/photo/2019/02/06/17/09/snake-3979601__480.jpg";

            var bitmap = await downloader.DownloadImageAsync(url);
            bitmap.Save(@"C:\Users\Krzysztof Krupiński\source\repos\Snake-the-game\image1.bmp");

        }
    }
}