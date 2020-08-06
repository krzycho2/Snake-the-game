using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Snake_the_game.Models
{
    class Snake
    {
        public int nParts { get; private set; }
        SnakeDirection snakeDirection { get; set; }
        Point Direction { get; set; }
        List<SnakePart> SnakeParts { get; set; }
        int speed;

        public Snake()
        {
            nParts = 1;
            SnakeParts = new List<SnakePart>();
            SnakeParts.Add(
                new SnakePart()
                {
                    Position = new Position { X = 10, Y = 10 },
                    IsHead = true
                }
            );

        }

        public void Eat()
        {
            nParts++;
            AddPart();
        }

        private void AddPart()
        {
            
        }
    }
}
