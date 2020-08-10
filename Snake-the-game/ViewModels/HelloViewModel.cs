using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Snake_the_game.ViewModels
{
    public class HelloViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _startGame;

        public ICommand StartGame
        {
            get 
            {
                return _startGame ?? (_startGame =
                    new RelayCommand(x => Mediator.Notify("StartGame","")));
            }
        }
    }
}
