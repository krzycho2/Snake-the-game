﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Snake_the_game.Models
{
    class Game
    {
        public Snake Snake { get; set; }

        public Food Food { get; set; }


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
            return new Food();
        }

        public void TimerTick()
        {
            Snake.Move();
            //Food.CreateNewPosition(); // Działa

            // losowa zmiana kierunku żeby zobaczyć, czy poprawnie chodzi
            var rnd = new Random();
            

            if (Snake.HeadPosition == Food.Position)
            {
                Snake.Eat();
                Food.CreateNewPosition();
            }

            Snake.Direction = (SnakeDirection)rnd.Next(3);
            Console.WriteLine("Nowy kierunek: " + Snake.Direction);
        }
    }
}
