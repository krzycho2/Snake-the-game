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

        public Food(Position initPosition)
        {
            Position = initPosition;
        }

        public void CreateNewPosition() 
        {
            int maxX = AppContext.GAME_AREA_WIDTH;
            int maxY = AppContext.GAME_AREA_HEIGHT;
            int square = AppContext.SNAKE_SQUARE_SIZE;

            var possibleX = new List<int>();
            int current = 0;
            while(current <= maxX)
            {
                possibleX.Add(current);
                current += square;
            }

            var possibleY = new List<int>();
            current = 0;
            while (current <= maxX)
            {
                possibleY.Add(current);
                current += square;
            }

            var rnd = new Random();

            int newXindex = rnd.Next(possibleX.Count);
            int newYindex = rnd.Next(possibleY.Count);

            int newX = possibleX[newXindex];
            int newY = possibleX[newYindex];

            Position = new Position { X = newX, Y = newY };
        }
    }
}
