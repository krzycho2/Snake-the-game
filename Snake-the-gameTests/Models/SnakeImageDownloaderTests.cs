using NUnit.Framework;
using Snake_the_game.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_the_game.Models.Tests
{
    [TestFixture()]
    public class SnakeImageDownloaderTests
    {
        [Test()]
        public async Task DownloadSnakeImgTest()
        {
            var downloader = new SnakeImageDownloader();
            for(int i = 0; i < 10; i++)
            {
                await downloader.DownloadSnakeImg();
                Process proc = Process.GetCurrentProcess();

                Console.WriteLine($"Pamięć po pobraniu i: {i} - {proc.PrivateMemorySize64}");
            }
        }
    }
}