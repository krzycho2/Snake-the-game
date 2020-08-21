using Snake_the_game.Models;
using Snake_the_game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Snake_the_game
{
    class WindowManager
    {
        public MainWindowViewModel WindowVM { get; private set; }
        public HelloViewModel HelloVM { get; private set; } = new HelloViewModel();
        public GameViewModel GameVM { get; private set; } = new GameViewModel();
        public SummaryViewModel SummaryVM { get; private set; } = new SummaryViewModel();

        public MainWindow Window { get; set; }

        public WindowManager()
        {
            WindowVM = new MainWindowViewModel(HelloVM);
            Window = new MainWindow()
            {
                DataContext = WindowVM
            };
            Window.Show();
            
            SubscribeToNotifications();
        }

        private void SubscribeToNotifications()
        {
            Mediator.Subscribe("Restart", OnRestart);
            Mediator.Subscribe("StartGame", OnStartGame);
            Mediator.Subscribe("EndGame", OnEndGame);
            Mediator.Subscribe("EndProgram", OnEndProgram);
            Mediator.Subscribe("Scored", OnScored);
            Mediator.Subscribe("UpPress", OnUpPress);
            Mediator.Subscribe("DownPress", OnDownPress);
            Mediator.Subscribe("LeftPress", OnLeftPress);
            Mediator.Subscribe("RightPress", OnRightPress);
        }

        // Notifications handlers

        private void OnRestart(object obj)
        {
            Window.DataContext = null;
            Window.DataContext = WindowVM;
            WindowVM.ChangeViewModel(HelloVM);
            WindowVM.OnRestart();
            GameVM = new GameViewModel();
        }

        private void OnStartGame(object obj)
        {
            GameVM.StartGame();
            WindowVM.ChangeViewModel(GameVM);
        }


        private void OnScored(object obj)
        {
            WindowVM.OnScored();
        }

        private void OnEndGame(object obj)
        {
            GameVM.StopGame();
            SummaryVM.Score = GameVM.Score;
            WindowVM.ChangeViewModel(SummaryVM); 
        }

        private void OnEndProgram(object obj)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void OnUpPress(object obj) 
        {
            GameVM.OnKeyPressed(Key.Up);
        }

        private void OnDownPress(object obj) 
        {
            GameVM.OnKeyPressed(Key.Down);
        }

        private void OnLeftPress(object obj) 
        {
            GameVM.OnKeyPressed(Key.Left);
        }

        private void OnRightPress(object obj) 
        {
            GameVM.OnKeyPressed(Key.Right);
        }


    }
}
