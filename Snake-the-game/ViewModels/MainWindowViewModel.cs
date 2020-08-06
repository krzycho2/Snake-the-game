using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Snake_the_game.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private GameViewModel _gameViewModel;

        public GameViewModel gameViewModel
        {
            get => _gameViewModel;

            set
            {
                _gameViewModel = value;
                OnPropertyChanged("gameViewModel");
                Console.WriteLine("Ustawienie gameViewModel");
            }

        }
        
        public MainWindowViewModel()
        {
            gameViewModel = new GameViewModel();
        }

        public ICommand Click
        {
            get => new RelayCommand(x => gameViewModel.StartClock());
        }
    }
}
