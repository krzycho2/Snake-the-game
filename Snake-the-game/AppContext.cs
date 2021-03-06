﻿using Snake_the_game.Models;
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
        public static Position INIT_SNAKE_POSITION = new Position { X = 100, Y = 100 };
        public static Position INIT_FOOD_POSITION = new Position { X = 0, Y = 0 };
        public static int GAME_AREA_HEIGHT = 400;
        public static int GAME_AREA_WIDTH = 400;
    }
}
