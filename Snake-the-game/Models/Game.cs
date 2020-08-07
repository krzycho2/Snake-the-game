using System;
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

        //public void Start() 
        //{
        //    StartClock();
        //}

        public void TimerTick()
        {
            Snake.Move();

            if(Snake.HeadPosition == Food.Position)
            {
                Snake.Eat();
                Food.CreateNewPosition();
            }
        }
    }
}
