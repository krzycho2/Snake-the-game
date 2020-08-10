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

        public void Tick()
        {
            if (!GameOver)
            {
                if (Snake.EatingItself())
                {
                    EndGame();
                    return;
                }

                //Console.WriteLine($"Food: {Food.Position.X} {Food.Position.Y}, Snake: {Snake.HeadPosition.X} {Snake.HeadPosition.Y}");
                if (HeadOnFood())
                {
                    Console.WriteLine("Warunek na zjedzenie spełniony");
                    Snake.Eat();
                    Food.CreateNewPosition();
                    Score++;
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

        private bool HeadOnFood()
        {
            return Snake.HeadPosition.X == Food.Position.X && Snake.HeadPosition.Y == Food.Position.Y;
        }



    }
}
