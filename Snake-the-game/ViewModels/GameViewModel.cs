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
using System.Collections.ObjectModel;

namespace Snake_the_game.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        private ObservableCollection<SnakePart> _snakeParts;
        private Position _foodPosition = new Position { X = 100, Y = 100 };

        public ObservableCollection<SnakePart> SnakeParts
        {
            get => _snakeParts;

            set
            {
                _snakeParts = value;
                OnPropertyChanged("SnakeParts");
                Console.WriteLine("Aktualny wąż:");
                Console.WriteLine($"Głowa: {Game.Snake.HeadPosition.X} {Game.Snake.HeadPosition.Y}.");
                //foreach (var part in SnakeParts)
                //{
                //    Console.WriteLine(part.Position.X + " " + part.Position.Y);
                //}
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

        public int SnakeSquareSize { get => AppContext.SNAKE_SQUARE_SIZE; }

        public int GameAreaWidth { get => AppContext.GAME_AREA_WIDTH; }

        public int GameAreHeight { get => AppContext.GAME_AREA_HEIGHT; }

        public Position InitFoodPosition { get => AppContext.INIT_FOOD_POSITION; }

        public ICommand UpPress
        {
            get => new RelayCommand(x => Game.Snake.Direction = SnakeDirection.Up);
        }

        public ICommand DownPress
        {
            get => new RelayCommand(x => Game.Snake.Direction = SnakeDirection.Down);
        }

        public ICommand LeftPress
        {
            get => new RelayCommand(x => Game.Snake.Direction = SnakeDirection.Left);
        }

        public ICommand RightPress
        {
            get => new RelayCommand(x => Game.Snake.Direction = SnakeDirection.Right);
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
            SnakeParts = new ObservableCollection<SnakePart>(Game.Snake.SnakeParts);
            FoodPosition = Game.Food.Position;
        }
    }
}
