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
        private IPageViewModel _currentPageViewModel;

        public IPageViewModel CurrentPageViewModel
        {
            get => _currentPageViewModel;
            private set
            {
                _currentPageViewModel = value;
                OnPropertyChanged("CurrentPageViewModel");
            }
        }

        public MainWindowViewModel(IPageViewModel firstPage)
        {
            CurrentPageViewModel = firstPage;
        }

        public void ChangeViewModel(IPageViewModel viewModel)
        {
            CurrentPageViewModel = viewModel;
        }

        //private GameViewModel _gameViewModel = new GameViewModel();

        //public GameViewModel GameViewModel
        //{
        //    get => _gameViewModel;

        //    set
        //    {
        //        _gameViewModel = value;
        //        OnPropertyChanged("gameViewModel");
        //        Console.WriteLine("Ustawienie gameViewModel");
        //    }

        //}
    }
}
