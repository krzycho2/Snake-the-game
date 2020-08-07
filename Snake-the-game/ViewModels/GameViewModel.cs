using Snake_the_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows;
using System.Threading;

namespace Snake_the_game.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        private string _text1 = "Dobry";
        public string Text1 {
            get => _text1;
            set {
                _text1 = value;
                OnPropertyChanged("Text1");
            }
        }

        private Position _position = new Position { X = 120, Y = 200 };
        public Position Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPropertyChanged("Position");
            }
        }

        public Position Position1
        {
            get => new Position { X = 300, Y = 100 };
        }

        public Position Position2
        {
            get => new Position { X = 320, Y = 120 };
        }

        public Position Position3
        {
            get => new Position { X = 340, Y = 140 };
        }

        private List<SnakePart> _snakeParts;
        public List<SnakePart> SnakeParts
        {
            get {
                return _snakeParts;
                //var parts = new List<SnakePart>();
                //parts.Add(new SnakePart { Position = new Position { X = 0, Y = 100 }, IsHead = true });
                //parts.Add(new SnakePart { Position = new Position { X = 20, Y = 120 }, IsHead = false });
                //parts.Add(new SnakePart { Position = new Position { X = 40, Y = 140 }, IsHead = false });
                //return parts;
            }

            set
            {
                _snakeParts = value;
                OnPropertyChanged("SnakeParts");
                Console.WriteLine("Ustawienie SnakeParts");
            }
            
        }

        public GameViewModel()
        {
            Console.WriteLine("Utworzenie GameViewModel");
            StartClock();

            var parts = new List<SnakePart>();
            parts.Add(new SnakePart { Position = new Position { X = 300, Y = 300 }, IsHead = true });
            parts.Add(new SnakePart { Position = new Position { X = 320, Y = 300 }, IsHead = false });
            parts.Add(new SnakePart { Position = new Position { X = 340, Y = 300 }, IsHead = false });

            SnakeParts = parts;
        }



        public ICommand Click
        {
            get => new RelayCommand(x => StartClock());
        }

        public void StartClock()
        {
            Console.WriteLine("Wywyołanie StartClock");
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            int py = SnakeParts[0].Position.Y;
            int px0 = (SnakeParts[0].Position.X + 20) % 400;
            int px1 = (SnakeParts[1].Position.X + 20) % 400;
            int px2 = (SnakeParts[2].Position.X + 20) % 400;
            var parts = new List<SnakePart>();
            parts.Add(new SnakePart { Position = new Position { X = px0, Y = py }, IsHead = true });
            parts.Add(new SnakePart { Position = new Position { X = px1, Y = py }, IsHead = false });
            parts.Add(new SnakePart { Position = new Position { X = px2, Y = py }, IsHead = false });

            SnakeParts = parts;
        }
    }
}
