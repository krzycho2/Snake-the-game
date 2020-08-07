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
        private List<SnakePart> _snakeParts;
        private Position _foodPosition;

        
        //private string _text1 = "Dobry";
        //public string Text1 {
        //    get => _text1;
        //    set {
        //        _text1 = value;
        //        OnPropertyChanged("Text1");
        //    }
        //}

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

        public Position FoodPosition
        {
            get => _foodPosition;
            set
            {
                _foodPosition = value;
                OnPropertyChanged("FoodPosition");
            }
        }

        public int SnakeSquareSize
        {
            get => AppContext.SNAKE_SQUARE_SIZE;
        }

        public int GameAreaWidth
        {
            get => AppContext.GAME_AREA_WIDTH;
        }

        public int GameAreaLength
        {
            get => AppContext.GAME_AREA_LENGTH;
        }


        private Game Game { get; set; }

        public GameViewModel()
        {
            Game = new Game();
            StartClock();
            Console.WriteLine("Utworzenie GameViewModel.");
        }

        private void StartClock()
        {
            Console.WriteLine("Start zegarka.");
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += GameTick;
            timer.Start();
        }

        private void GameTick(object sender, EventArgs e)
        {
            Game.TimerTick();
            ReadFromModel();
        }

        private void ReadFromModel()
        {
            SnakeParts = Game.Snake.SnakeParts;

        }


        //public ICommand Click
        //{
        //    get => new RelayCommand(x => StartClock());
        //}



    }
}
