using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Menu
    {
        public static string[] items = { "New Game", "Load Game", "Records", "Settings", "Exit" };
        public static int selectedItemIndex = 0;

        static void NewGame()
        {

            //StatusBar.ShowInfo("New Game");
        }
        static void Recordz()
        {

            //StatusBar.ShowInfo("Records");
        }

        static void Exit()
        {
           // StatusBar.ShowInfo("Exit");
        }

        public static void Draw()
        {

            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;

            /*for (int i = 0; i < Game.boardH - 2; ++i)
            {
                for (int j = 0; j < Game.boardW; ++j)
                {
                    Console.Write(' ');
                }
                Console.WriteLine();
            }*/


            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < items.Length; ++i)
            {
                Console.SetCursorPosition(33, 5 + i);
                if (i == selectedItemIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine(String.Format("{0}. {1}", i, items[i]));
            }
        }

        public static void Process(ConsoleKeyInfo pressedButton)
        {
            switch (pressedButton.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedItemIndex--;
                    if (selectedItemIndex < 0)
                    {
                        selectedItemIndex = items.Length - 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    selectedItemIndex++;
                    if (selectedItemIndex >= items.Length)
                    {
                        selectedItemIndex = 0;
                    }
                    break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    Menu.Draw();
                    break;
                case ConsoleKey.Enter:

                    switch (selectedItemIndex)
                    {
                        case 0:
                            NewGame();
                            Game.StartNewGame();
                            break;
                        case 1:
                            break;
                        case 2:
                            Console.Clear();
                            Records.Show();
                            break;
                        case 3:

                            break;
                        case 4:
                            Exit();
                            Environment.Exit(1);
                            break;
                    }

                    break;
            }

            Draw();
        }
    }
}
