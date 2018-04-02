using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    struct Part
    {
        public int X { get; set; }
        public int Y { get; set; }

        /*public override bool Equals(Part obj)
        {
            Part b = obj;
            if (b.X == this.X && b.Y == this.Y) return true;
            return false;
        }*/
    }
}
