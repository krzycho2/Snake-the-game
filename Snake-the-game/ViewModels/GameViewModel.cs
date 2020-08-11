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
    public class GameViewModel : BaseViewModel, IPageViewModel
    {
        private ObservableCollection<SnakePart> _snakeParts;
        private Position _foodPosition = new Position { X = 100, Y = 100 };
        private string _scoreString;

        public ObservableCollection<SnakePart> SnakeParts
        {
            get => _snakeParts;
            set
            {
                _snakeParts = value;
                OnPropertyChanged("SnakeParts");
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

        public int Score
        {
            get => Game.Score;
        }

        public string ScoreString 
        {
            get => _scoreString;
            set
            {
                _scoreString = value;
                OnPropertyChanged("ScoreString");
            }
        }

        public string ImagePath { get => Game.ImagePath; }

        public double GameSpeed { get; set; } = 2.0; // sqaures per second

        private Game Game { get; set; }

        private DispatcherTimer Timer { get; set; }

        public void StartGame()
        {
            Game = new Game();
            StartClock();
        }

        private void StartClock()
        {
            Console.WriteLine("Start zegarka.");
            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(1.0/GameSpeed);
            Timer.Tick += GameTick;
            Timer.Start();
        }

        private  void GameTick(object sender, EventArgs e)
        {
            Game.Tick();
            ReadFromModel();
        }

        private void ReadFromModel()
        {
            SnakeParts = new ObservableCollection<SnakePart>(Game.Snake.SnakeParts);
            FoodPosition = Game.Food.Position;
            ScoreString = "Wynik: " + Game.Score.ToString();
        }

        public void StopGame()
        {
            Timer.Stop();
        }

        public void OnKeyPressed(Key key) 
        {
            switch (key)
            {
                case Key.Up:
                    Game.Snake.Direction = SnakeDirection.Up;
                    break;

                case Key.Down:
                    Game.Snake.Direction = SnakeDirection.Down;
                    break;

                case Key.Left:
                    Game.Snake.Direction = SnakeDirection.Left;
                    break;

                case Key.Right:
                    Game.Snake.Direction = SnakeDirection.Right;
                    break;
            }
            
        }
    }
}
