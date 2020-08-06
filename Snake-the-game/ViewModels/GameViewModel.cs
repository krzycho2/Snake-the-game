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

        private int _location = 220;
        public int Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }

        private List<SnakePart> _snakeParts;
        public List<SnakePart> SnakeParts
        {
            get => _snakeParts;

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
            parts.Add(new SnakePart { Position = new Position(300, 300), IsHead = true });
            parts.Add(new SnakePart { Position = new Position(320, 300), IsHead = false });
            parts.Add(new SnakePart { Position = new Position(340, 300), IsHead = false });

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
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //Text1 = "Aktualny czas: " + DateTime.Now.ToString();
            Location = (Location + 20) % 400;

        }
    }
}
