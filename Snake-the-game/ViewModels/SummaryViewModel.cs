using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Snake_the_game.ViewModels
{
    class SummaryViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _endProgram;
        private ICommand _restart;

        public ICommand EndProgram
        {
            get
            {
                return _endProgram ?? (_endProgram =
                    new RelayCommand(x => Mediator.Notify("EndProgram", "")));
            }
        }

        public ICommand Restart
        {
            get
            {
                return _restart ?? (_restart =
                    new RelayCommand(x => Mediator.Notify("Restart", "")));
            }
        }

        public int Score { get; set; }
    }
}
