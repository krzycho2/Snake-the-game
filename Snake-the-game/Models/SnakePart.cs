using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Snake_the_game.Models
{
    public class SnakePart
    {
        public Position Position { get; set; }

        public UIElement UIElement
        {
            get
            {
                var rect = new Rectangle()
                {
                    Width = 20,
                    Height = 20,
                    Fill = Brushes.Black
                };
                return rect;
            }
        }
        public bool IsHead { get; set; }
    }
}
