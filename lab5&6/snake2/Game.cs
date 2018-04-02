using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
   public class Game
    {
        static bool inGame = true;
        static DateTime start = DateTime.Now;
        static Food food = new Food();
        static int score = 0;
        public static int boardW = 80;
        public static int boardH = 24;
        public static void StartNewGame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            inGame = true;
            score = 0;
            Snake.Make();
            MakePlayground();
            food.Appear();
            Play();
        }
        /*public void Start()
        {
            ThreadStart ts = new ThreadStart(StartNewGame);
            Thread t = new Thread(ts);
            t.Start();
        }*/


        public static void Play()
        {
            
            while (inGame)
            {
                CheckForSelfColision();
                CheckForInput();
                
                Move();
                IsFoodEaten();
                Thread.Sleep(150);
            }
        }

        public static void CheckForSelfColision()
        {
            if (Snake.CheckForSelfColission())
            {
                GameOver();
            }
        }

        public static void IsFoodEaten()
        {
            if (Snake.CheckColission(food.X, food.Y))
            {
                if (food.View == 0)
                {
                    Snake.ClearSnake();
                    Snake.Make();
                }
                else
                {
                    score += 10; 
                    Snake.Grow();
                    Console.SetCursorPosition(57, 19);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Score: {0}", score);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                food = new Food();
                food.Appear();

            }
        }

        public static void MakePlayground()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            for (int x = 2; x < 77; x++)
            {
                Console.SetCursorPosition(x, 1);
                if (x == 2)
                {
                    Console.WriteLine("╔");
                }
                else if (x == 76)
                {
                    Console.WriteLine("╗");
                }
                else
                {
                Console.WriteLine("═");
                }


            }
            for (int x = 2; x < 77; x++)
            {
                Console.SetCursorPosition(x, 17);
                if (x == 2)
                {
                    Console.WriteLine("╚");
                }
                else if (x == 76)
                {
                    Console.WriteLine("╝");
                }
                else
                {
                    Console.WriteLine("═");
                }


            }
            for (int i = 2; i < 17; i++)
            {
                Console.SetCursorPosition(2, i);
                Console.WriteLine("║");
                Console.SetCursorPosition(76, i);
                Console.WriteLine("║");
            }
            for (int x = 2; x < 23; x++)
            {
                Console.SetCursorPosition(x, 20);
                if (x == 2)
                {
                    Console.WriteLine("╚");
                }
                else if (x == 22)
                {
                    Console.WriteLine("╝");
                }
                else
                {
                    Console.WriteLine("═");
                }
            }
            for (int i = 18; i < 20; i++)
            {
                Console.SetCursorPosition(2, i);
                Console.WriteLine("║");
                Console.SetCursorPosition(22, i);
                Console.WriteLine("║");
            }
            Console.SetCursorPosition(7, 19);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("SNAKE GAME");
            Console.ForegroundColor = ConsoleColor.Magenta;
            for (int x = 2; x < 23; x++)
            {
                Console.SetCursorPosition(x, 18);
                if (x == 2)
                {
                    Console.WriteLine("╔");
                }
                else if (x == 22)
                {
                    Console.WriteLine("╗");
                }
                else
                {
                    Console.WriteLine("═");
                }


            }
            for (int x = 55; x < 77; x++)
            {
                Console.SetCursorPosition(x, 18);
                if (x == 55)
                {
                    Console.WriteLine("╔");
                }
                else if (x == 76)
                {
                    Console.WriteLine("╗");
                }
                else
                {
                    Console.WriteLine("═");
                }


            }
            for (int i = 19; i < 21; i++)
            {
                Console.SetCursorPosition(55, i);
                Console.WriteLine("║");
                Console.SetCursorPosition(76, i);
                Console.WriteLine("║");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(25, 19);
            Console.WriteLine("Press ESC to go to menu");
            Console.SetCursorPosition(25, 20);
            Console.WriteLine("Press SPACE if u wanna pause");
            Console.SetCursorPosition(57, 20);
            Console.WriteLine("Status: Playing");
            Console.ForegroundColor = ConsoleColor.Magenta;
            for (int x = 55; x < 77; x++)
            {
                Console.SetCursorPosition(x, 21);
                if (x == 55)
                {
                    Console.WriteLine("╚");
                }
                else if (x == 76)
                {
                    Console.WriteLine("╝");
                }
                else
                {
                    Console.WriteLine("═");
                }


            }
            Console.SetCursorPosition(57, 19);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Score:{0}", score);
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        public static void Move()
        {
            bool on = Snake.Move();
            if (!on) 
            {
                GameOver();
            }
        }

        public static void GameOver()
        {
            inGame = false;
            Console.SetCursorPosition(35, 13);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Snake.ClearSnake();
            Console.Clear();
            //CheckResultRecords();
            //Menu.Draw();
        }

        public static void CheckResultRecords()
        {
            if (Records.CheckForRecordResult(score))
            {
                Console.Clear();
                Console.SetCursorPosition(18, 9);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You've got a great result! Congratulations!!!");
                Console.SetCursorPosition(18, 13);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Please, enter your name without spaces: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.CursorVisible = true;
                string name = Console.ReadLine();
                Console.CursorVisible = false;
                RecordsEntry entry = new RecordsEntry();
                if (name.Contains(' '))
                {
                    string[] res = name.Trim().Split();
                    name = res[0];
                }
                entry.Name = name;
                entry.Score = score;
                Records.EnterRecords(entry);
            }
        }

        public static void CheckForInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (Snake.direction != Direction.right)
                    {
                        Snake.direction = Direction.left;
                    }

                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (Snake.direction != Direction.left)
                    {
                        Snake.direction = Direction.right;
                    }

                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (Snake.direction != Direction.down)
                    {
                        Snake.direction = Direction.up;
                    }

                }
                if (key.Key == ConsoleKey.DownArrow && Snake.direction != Direction.up)
                {
                    Snake.direction = Direction.down;
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    inGame = false;
                }
            }
        }
    }
}
