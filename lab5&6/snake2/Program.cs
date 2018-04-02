using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Game.boardW, Game.boardH);
            Console.SetBufferSize(Game.boardW, Game.boardW);
            
            Console.CursorVisible = false;
            Menu.Draw();
            //Game game = new Game();
            //game.Start();

            while (true)
            {
                ConsoleKeyInfo pressedButton = Console.ReadKey();
                Menu.Process(pressedButton);
            }
        }
    }
}
