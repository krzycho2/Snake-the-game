using Snake_the_game.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Snake_the_game.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region fields
        private IPageViewModel _currentPageViewModel;

        private string _backgroundImagePath = @"C:\Users\Krzysztof Krupiński\source\repos\Snake-the-game\Snake-the-game\image.bmp";
        private BitmapImage _bitmapImageSource;

        private ICommand _upPress;
        private ICommand _downPress;
        private ICommand _leftPress;
        private ICommand _rightPress;
        #endregion

        #region public properties
        public IPageViewModel CurrentPageViewModel
        {
            get => _currentPageViewModel;
            private set
            {
                _currentPageViewModel = value;
                OnPropertyChanged("CurrentPageViewModel");
            }
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

        public BitmapImage BitmapImageSource 
        {
            get => _bitmapImageSource;
            set 
            {
                _bitmapImageSource = value;
                Console.WriteLine("Zmiana obrazka");
                OnPropertyChanged("BitmapImageSource");
            } 
        }

        public string InitBackImagePath { get => "/Resources/init-image.png"; }

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

        private SnakeImageDownloader ImageDownloader { get; set; } = new SnakeImageDownloader();

        #endregion


        public  MainWindowViewModel(IPageViewModel firstPage)
        {
            CurrentPageViewModel = firstPage;
            SetDefaultBackImg();
        }

        private void SetDefaultBackImg()
        {
            // Zdjęcie początkowe
            var imgPath = @"C:\Users\Krzysztof Krupiński\source\repos\Snake-the-game\Snake-the-game\2.bmp";
            
            var bitmap = new Bitmap(InitBackImagePath);
            var imageSource = SnakeImageDownloader.GetImageSource(bitmap);
            BitmapImageSource = imageSource;
        }

        public void ChangeViewModel(IPageViewModel viewModel)
        {
            CurrentPageViewModel = viewModel;
        }

        public async Task OnScored()
        {
            await SetNewBackImg();
        }

        private async Task SetNewBackImg()
        {
            await ImageDownloader.DownloadSnakeImg();
            BitmapImageSource = ImageDownloader.GetImageSource();
        }

    }
}
