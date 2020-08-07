using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_the_game.Models
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position NextPositionBasedOnDirection(SnakeDirection direction)
        {
            int x = 0, y = 0;
            switch (direction)
            {
                case SnakeDirection.Up:
                    x = X;
                    y = Y - 20;
                    break;
                

                case SnakeDirection.Left:
                        x = X - 20;
                        y = Y;
                        break;

                case SnakeDirection.Down:
                    x = X;
                    y = Y + 20;
                    break;

                case SnakeDirection.Right:
                    x = X + 20;
                    y = Y;
                    break;
            }

            return new Position { X = x, Y = y };
        }
        
    }
}
