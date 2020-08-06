using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Snake_the_game.Models
{
    public class SnakePart
    {
        public Position Position { get; set; }

        public int Position_x {
            get => Position.X;
        }

        public int Position_y
        {
            get => Position.Y;
        }
        public bool IsHead { get; set; }
    }
}
