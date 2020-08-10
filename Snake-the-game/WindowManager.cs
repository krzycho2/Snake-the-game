using Snake_the_game.Models;
using Snake_the_game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_the_game
{
    class WindowManager
    {
        public MainWindowViewModel WindowVM { get; private set; }
        public HelloViewModel HelloVM { get; private set; } = new HelloViewModel();
        public GameViewModel GameVM { get; private set; } = new GameViewModel();
        public SummaryViewModel SummaryVM { get; private set; } = new SummaryViewModel();

        public WindowManager()
        {
            WindowVM = new MainWindowViewModel(HelloVM);
            MainWindow window = new MainWindow()
            {
                DataContext = WindowVM
            };
            window.Show();

            SubscribeToNotifications();
        }

        private void SubscribeToNotifications()
        {
            Mediator.Subscribe("Restart", OnRestart);
            Mediator.Subscribe("StartGame", OnStartGame);
            Mediator.Subscribe("EndGame", OnEndGame);
            Mediator.Subscribe("EndProgram", OnEndProgram);
        }

        // Notifications handlers

        private void OnRestart(object obj)
        {
            WindowVM.ChangeViewModel(HelloVM);
        }

        private void OnStartGame(object obj)
        {
            GameVM.StartGame();
            WindowVM.ChangeViewModel(GameVM);
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

        

    }
}
