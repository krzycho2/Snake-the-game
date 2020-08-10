using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Snake_the_game.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IPageViewModel _currentPageViewModel;

        private string _backgroundImagePath = @"C:\Users\Krzysztof Krupiński\source\repos\Snake-the-game\Snake-the-game\image.bmp";

        private ICommand _upPress;
        private ICommand _downPress;
        private ICommand _leftPress;
        private ICommand _rightPress;

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

        public string BackgroundImagePath 
        {
            get => _backgroundImagePath;
            set
            {
                _backgroundImagePath = value;
                Console.WriteLine("Zmiana obrazka");
                OnPropertyChanged("BackgroundImagePath");
            }
        }

        public ICommand UpPress 
        { 
            get => _upPress ?? (_upPress = new RelayCommand(x => Mediator.Notify("UpPress", ""))); 
        }

        public ICommand DownPress
        {
            get => _downPress ?? (_downPress = new RelayCommand(x => Mediator.Notify("DownPress", "")));
        }

        public ICommand LeftPress
        {
            get => _leftPress ?? (_leftPress = new RelayCommand(x => Mediator.Notify("LeftPress", "")));
        }

        public ICommand RightPress
        {
            get => _rightPress ?? (_rightPress = new RelayCommand(x => Mediator.Notify("RightPress", "")));
        }
    }
}
