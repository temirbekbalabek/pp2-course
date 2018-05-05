using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fallingCircle
{
    class Drop
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color color { get; set; }

        public Drop(int X, int Y, Color color)
        {
            this.X = X;
            this.Y = Y;
            this.color = color;
        }
    }
}
