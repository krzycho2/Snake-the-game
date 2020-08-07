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
        int speed;

        public Position HeadPosition 
        {
            get => SnakeParts[0].Position;
        }

        public SnakeDirection Direction { get; set; }

        public List<SnakePart> SnakeParts { get; private set; }

        public Snake(Position initSnakePosition)
        {
            SnakeParts = new List<SnakePart>();
            SnakeParts.Add(
                new SnakePart()
                {
                    Position = initSnakePosition,
                    IsHead = true
                }
            );

            AddSomeParts();

        }

        private void AddSomeParts()
        {
            AddPart();
            AddPart();
            AddPart();
        }

        public void Move()
        {

        }

        public void Eat()
        {
            AddPart();
        }

        private void AddPart() // At the beginning, after the head
        {
            var newPosition = SnakeParts[0].Position.NextPositionBasedOnDirection(Direction);
            SnakeParts.Add(new SnakePart { Position = newPosition, IsHead = true });
            SnakeParts[1].IsHead = false;
        }
    }
}
