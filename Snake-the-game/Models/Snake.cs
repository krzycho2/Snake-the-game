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
        private SnakeDirection _direction;

        public Position HeadPosition 
        {
            get => SnakeParts[0].Position;
        }

        public SnakeDirection Direction 
        {
            get => _direction;
            set
            {
                if(OpposedDirection(Direction, value))
                {
                    Console.WriteLine("Nie można zmienić kierunku na przeciwny.");
                }

                else
                {
                    Console.WriteLine("Zmiana kierunku na: " + value);
                    _direction = value;
                }
            }
        }

        public List<SnakePart> SnakeParts { get; private set; }



        public Snake(Position initSnakePosition, SnakeDirection initSnakeDirection)
        {
            Direction = initSnakeDirection;
            SnakeParts = new List<SnakePart>();
            SnakeParts.Add(
                new SnakePart()
                {
                    Position = initSnakePosition,
                    IsHead = true
                }
            );
        }

        public void Move()
        {
            var nextPosition = SnakeParts[0].Position.NextPositionBasedOnDirection(Direction);
            SnakeParts.Insert(0, new SnakePart { Position = nextPosition, IsHead = true });
            SnakeParts[1].IsHead = false;

            SnakeParts.RemoveAt(SnakeParts.Count - 1);
        }

        public void Eat()
        {
            AddPart();
        }

        private void AddPart() // At the beginning, after the head
        {
            var newPosition = SnakeParts[0].Position.NextPositionBasedOnDirection(Direction);
            SnakeParts.Insert(0, new SnakePart { Position = newPosition, IsHead = true });
            SnakeParts[1].IsHead = false;

            Console.WriteLine("Dodano element. Aktualna długość: " + SnakeParts.Count);
        }

        public bool EatingItself()
        {
            int x = HeadPosition.X;
            int y = HeadPosition.Y;

            foreach (var part in SnakeParts.GetRange(1, SnakeParts.Count - 1))
            {
                if (part.Position.X == x && part.Position.Y == y)
                    return true;
            }

            return false;
        }

        private bool OpposedDirection(SnakeDirection direction1, SnakeDirection direction2)
        {
            return Math.Abs((int)direction1 - (int)direction2) == 2;
        }
    }
}
