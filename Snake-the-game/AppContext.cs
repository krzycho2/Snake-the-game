using Snake_the_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_the_game
{
    static class AppContext
    {
        public static int SNAKE_SQUARE_SIZE = 20;
        public static Position INIT_SNAKE_POSITION = new Position { X = 150, Y = 150 };
        public static int GAME_AREA_LENGTH = 400;
        public static int GAME_AREA_WIDTH = 400;
    }
}
