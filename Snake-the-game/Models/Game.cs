using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Snake_the_game.Models
{
    class Game
    {
        public Snake Snake { get; set; }

        public Food Food { get; set; }

        public int Score { get; set; } = 0;

        public bool GameOver { get; private set; } = false;

        public string ImagePath { get; set; }

        public Bitmap Image { get; set; }



        public Game()
        {
            Snake = CreateSnake();
            Food = CreateFood();
        }

        private Snake CreateSnake()
        {
            return new Snake(AppContext.INIT_SNAKE_POSITION, SnakeDirection.Left);
        }

        private Food CreateFood()
        {
            return new Food(AppContext.INIT_FOOD_POSITION);
        }

        public async Task Tick()
        {
            if (!GameOver)
            {
                if (Snake.EatingItself())
                {
                    EndGame();
                    return;
                }

                if (IsHeadOnFood())
                {
                    Scored();

                    //await DownloadSnakeImg();
                }

                Snake.Move();
            }
        }

        private void Scored()
        {
            Mediator.Notify("Scored", "");

            Snake.Eat();
            Food.CreateNewPosition();
            Score++;
        }

        private void EndGame()
        {
            GameOver = true;
            Mediator.Notify("EndGame", "");
        }

        private bool IsHeadOnFood()
        {
            return Snake.HeadPosition.X == Food.Position.X && Snake.HeadPosition.Y == Food.Position.Y;
        }

        //private async Task DownloadSnakeImg()
        //{
        //    var imgLocations = new List<string>
        //    {
        //        @"https://cdn.pixabay.com/photo/2014/10/25/07/52/king-snake-502263_1280.jpg",
        //        @"https://cdn.pixabay.com/photo/2019/02/06/17/09/snake-3979601__480.jpg",
        //        @"https://cdn.pixabay.com/photo/2013/10/15/10/04/snake-195917__480.jpg",
        //        @"https://cdn.pixabay.com/photo/2016/10/21/19/34/snake-1758994__480.jpg",
        //        @"https://cdn.pixabay.com/photo/2016/03/28/10/07/snake-1285354__480.jpg"
        //    };

        //    var rnd = new Random();
        //    int rndNum = rnd.Next(imgLocations.Count - 1);
        //    Console.WriteLine("Wybrany obrazek: " + rndNum.ToString());

        //    var imgLocation = imgLocations[rndNum];

        //    var downloader = new ImageDownloader();

        //    var imageBitmap = await downloader.DownloadImageAsync(imgLocation);

        //    var imagePath = @"C:\Users\Krzysztof Krupiński\source\repos\Snake-the-game\Snake-the-game\" + rndNum.ToString() + ".bmp";
        //    try
        //    {
        //        imageBitmap.Save(imagePath);
        //    }
        //    catch (System.Runtime.InteropServices.ExternalException)
        //    {
        //        Console.WriteLine("Problem z zapisem zdjęcia");
        //    }
            

        //    ImagePath = imagePath;

        //    Mediator.Notify("ImagePathSet", "");
        //    Console.WriteLine("Obrazek zapisany: " + imagePath);

        //}

    }
}
