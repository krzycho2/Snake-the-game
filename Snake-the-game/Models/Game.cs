using System;
using System.Collections.Generic;
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

        public async Task TickAsync()
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
                    Console.WriteLine("Warunek na zjedzenie spełniony");
                    Snake.Eat();
                    Food.CreateNewPosition();
                    Score++;

                    await DownloadSnakeImg();
                }

                Snake.Move();
            }
        }

        private void EndGame()
        {
            GameOver = true;
            MessageBox.Show("Koniec gry. Wynik: " + Score);
            Mediator.Notify("EndGame", "");
        }

        private bool IsHeadOnFood()
        {
            return Snake.HeadPosition.X == Food.Position.X && Snake.HeadPosition.Y == Food.Position.Y;
        }

        private async Task DownloadSnakeImg()
        {
            var imgLocations = new List<string>
            {
                @"https://cdn.pixabay.com/photo/2014/10/25/07/52/king-snake-502263_1280.jpg",
                @"https://cdn.pixabay.com/photo/2019/02/06/17/09/snake-3979601__480.jpg",
                @"https://cdn.pixabay.com/photo/2013/10/15/10/04/snake-195917__480.jpg",
                @"https://cdn.pixabay.com/photo/2016/10/21/19/34/snake-1758994__480.jpg",
                @"https://cdn.pixabay.com/photo/2016/03/28/10/07/snake-1285354__480.jpg"
            };

            var rnd = new Random();
            var imgLocation = imgLocations[rnd.Next(imgLocations.Count-1)];

            var downloader = new ImageDownloader();
            var imageBitmap = await downloader.DownloadImage(imgLocation);
        }

    }
}
