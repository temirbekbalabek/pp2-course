using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Food
    {
        public char View { get; private set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Food()
        {
            Random generator = new Random();
            this.View = '■';
            this.X = generator.Next(4, 75);
            this.Y = generator.Next(4, 15);
        }
        public void Appear()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(this.View);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Disappear()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(" ");
        }
       
    }
}
