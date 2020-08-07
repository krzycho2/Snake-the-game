using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_the_game.Models
{
    class Food
    {
        public Position Position { get; set; }

        public void CreateNewPosition() 
        {
            int maxX = AppContext.GAME_AREA_WIDTH;
            int maxY = AppContext.GAME_AREA_HEIGHT;

            var rnd = new Random();

            int newX = rnd.Next(maxX);
            int newY = rnd.Next(maxY);

            Position = new Position { X = newX, Y = newY };
        }
    }
}
