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

        public int Position_x
        {
            get => X;
        }

        public int Position_y
        {
            get => Y;
        }

        public Position NextPositionBasedOnDirection(SnakeDirection direction)
        {
            int x = 0, y = 0;
            int maxX = AppContext.GAME_AREA_WIDTH;
            int maxY = AppContext.GAME_AREA_HEIGHT;
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

            if (x < 0)
                x = maxX + x;
            else if (x >= maxX)
                x = x - maxX;

            if (y < 0)
                y = maxY + y;
            else if (y >= maxY)
                y = y - maxY;

            return new Position { X = x, Y = y };
        }
        
    }
}
