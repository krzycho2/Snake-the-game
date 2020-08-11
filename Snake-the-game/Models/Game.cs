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

        public void Tick()
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
    }
}
