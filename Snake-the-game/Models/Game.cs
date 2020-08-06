using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_the_game.Models
{
    class Game
    {
        Snake snake { get; set; }

        Food food { get; set; }

        public Game()
        {
            snake = CreateSnake();
            food = CreateFood();
        }

        private Snake CreateSnake()
        {
            throw new NotImplementedException();
        }

        private Food CreateFood()
        {
            throw new NotImplementedException();
        }
    }
}
