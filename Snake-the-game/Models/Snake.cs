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

            AddSomeParts();

        }

        private void AddSomeParts()
        {
            AddPart();
            AddPart();
            AddPart();
            AddPart();
            AddPart();
            AddPart();
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
            Console.WriteLine($"Nowa pozycja: {newPosition.X}, {newPosition.Y}");
            SnakeParts.Insert(0, new SnakePart { Position = newPosition, IsHead = true });
            SnakeParts[1].IsHead = false;

            Console.WriteLine("Dodano element. Aktualna długość: " + SnakeParts.Count);
            Console.WriteLine("Aktualny wąż:");
            foreach(var part in SnakeParts)
            {
                Console.WriteLine(part.Position.X + " " + part.Position.Y);
            }
        }
    }
}
