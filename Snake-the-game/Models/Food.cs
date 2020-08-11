using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Snake_the_game.Models
{
    class Food
    {
        public Position Position { get; set; }

        private List<int> PossibleX { get; set; }

        private List<int> PossibleY { get; set; }

        private int MaxX { get => AppContext.GAME_AREA_WIDTH; } 

        private int MaxY { get => AppContext.GAME_AREA_HEIGHT; }
        
        public Food(Position initPosition)
        {
            CreatePossibleXY();
            Position = initPosition;
        }

        private void CreatePossibleXY()
        {
            
            int square = AppContext.SNAKE_SQUARE_SIZE;

            PossibleX = CreatePossibleCoordinate(MaxX, square);
            PossibleY = CreatePossibleCoordinate(MaxY, square);

        }

        private List<int> CreatePossibleCoordinate(int maxValue, int square)
        {
            var possibleVals = new List<int>();
            int current = 0;
            while (current < maxValue)
            {
                possibleVals.Add(current);
                current += square;
            }

            return possibleVals;
        }

        public void CreateNewPosition() 
        {
            int newXindex = RandomIndex(PossibleX.Count);
            int newYindex = RandomIndex(PossibleY.Count);

            int newX = PossibleX[newXindex];
            int newY = PossibleY[newYindex];

            Position = new Position { X = newX, Y = newY };
        }

        private int RandomIndex(int count)
        {
            var rnd = new Random();
            return rnd.Next(count);
        }
    }
}
