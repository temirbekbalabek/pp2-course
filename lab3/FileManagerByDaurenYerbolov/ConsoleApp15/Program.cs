using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{

    public class Program
    {
        static void DrawUpBorder()
        {
            string s = "═";
            string s1 = "";

            for (int i = 0; i < 100; i++)
            {
                if (i == 0)
                {
                    s1 = s1 + "╔";

                }
                else if (i == 33)
                {
                    s1 = s1 + "╦";
                }
                else if (i == 99)
                {
                    s1 = s1 + "╗";
                }
                else
                {
                    s1 = s1 + s;
                }

            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(s1);

        }
        static void DrawDownBorder()
        {
            string s = "═";
            string s1 = "";

            for (int i = 0; i < 100; i++)
            {
                if (i == 0)
                {
                    s1 = s1 + "╚";

                }
                else if (i == 33)
                {
                    s1 = s1 + "╩";
                }
                else if (i == 99)
                {
                    s1 = s1 + "╝";
                }
                else
                {
                    s1 = s1 + s;
                }


            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(s1);

        }
        /*static double GetDirectorySize(string folder)
        {
            double size = 0;
            try
            {
                DirectoryInfo di = new DirectoryInfo(folder);
                DirectoryInfo[] diA = di.GetDirectories();
                FileInfo[] fi = di.GetFiles();

                foreach (FileInfo f in fi)
                {
                    if (size > 10e7)
                    {
                        size = -1;
                        break;
                    }
                    size += f.Length;
                    
                }

                foreach (DirectoryInfo df in diA)
                {
                    if (size > 10e7)
                    {
                        size = -1;
                        break;
                    }
                    GetDirectorySize(df.FullName);
                    size += GetDirectorySize(df.FullName);
                    
                }
                        return Math.Round(size, 1);
                
            }
            catch (DirectoryNotFoundException)
            {
                return 0;
            }
            catch (UnauthorizedAccessException)
            {
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }*/
        static double GetFileSize(FileSystemInfo dr)
        {
            double res = 0;
            FileInfo info = new FileInfo(dr.FullName);
            res += info.Length;
            return Math.Round((double)(res), 1);


        }
        static void Draw(int index, List<FileSystemInfo> array, string path)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine(' ');
            Thread.Sleep(0);
            SetTextColor('R');
            Console.WriteLine("            NAME                      TYPE             LAST ACCESS                  SIZE");
            DrawUpBorder();
            int pos = index / 20;
            pos *= 20;
           
            for (int i = pos; i < pos + 20; ++i)
            {
                int k = 0;
                if (i >= array.Count)
                {
                    break;
                }
                bool xcc = false; // xcc - boolean dlya napisaniay tipa size i access time videlennogo fila or foldera
                string mass = array[i].Name;
                string t = null;
                string t1 = "║ ";
                string t2 = " ║";
                string t3 = "                                                                ";
                string ss = null;
                string sdir = null;

                string sfile = null;
                bool temp = false;
                bool type = true;
                if (index == i)
                {
                   
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    xcc = true;

                }

                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                if (array[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (array[i].GetType() == typeof(FileInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    type = false;
                }

                for (int j = 0; j < 30 - array[i].Name.Length; j++)
                {
                    t += ' ';
                }
                if (array[i].Name.Length >= 30)
                {
                    temp = true;
                    for (int m = 0; m < 27; m++)
                    {
                        ss += array[i].Name[m];
                    }
                    ss += "...";
                }

                if (temp)
                {
                    mass = null;
                }
                SetTextColor('W');
                Console.Write(t1);
                if (type)
                {
                    SetTextColor('W');
                    if (!xcc)
                    {
                        Console.Write(ss + mass + t + t2 + t3);
                    }
                    else
                    {
                        Console.Write(ss + mass + t + t2);
                        SetTextColor('D');
                        string access = null;
                        access = array[i].LastAccessTime.ToString();// + GetDirectorySize(array[i].FullName).ToString();
                          
                            if ((array[i].Attributes & FileAttributes.Hidden) == 0)
                            {
                            Console.Write("  Directory          {0}           ", array[i].LastAccessTime);//, GetDirectorySize(array[i].FullName));
                                for (int r = 0; r < t3.Length - 32 - access.Length; r++)
                                {
                                    sdir += " ";
                                }
                                Console.Write(sdir);
                            }
                            else if ((array[i].Attributes & FileAttributes.Hidden) != 0)
                            {
                            Console.Write("  Hidden             {0}           ", array[i].LastAccessTime);//, GetDirectorySize(array[i].FullName));
                                for (int r = 0; r < t3.Length - 32 - access.Length; r++)
                                {
                                    sdir += " ";
                                }
                                Console.Write(sdir);
                            }
          
                    }

                }
                else
                {

                    SetTextColor('R');
                    Console.Write(ss + mass + t);
                    SetTextColor('W');
                    Console.Write(t2);
                    if (!xcc)
                    {
                        Console.Write(t3);
                    }
                    else
                    {
                        string access = null;
                        access = array[i].LastAccessTime.ToString() + GetFileSize(array[i]).ToString();
                        SetTextColor('D');
                        Console.Write("  File            {0}           {1} bytes", array[i].LastAccessTime, GetFileSize(array[i]));
                        for (int r = 0; r < t3.Length - 35 - access.Length; r++)
                        {
                            sfile += " ";
                        }
                        Console.Write(sfile);
                    }



                }
                SetTextColor('W');
                Console.Write(t2);
                k++;
                Console.WriteLine(' ');
                
            }
            Console.BackgroundColor = ConsoleColor.Blue;
            DrawDownBorder();
            SetTextColor('R');
            Console.WriteLine(" Current location: " + path);
            Console.CursorVisible = false;
            Console.Write(" Elements: " + array.Count);

        }
        static void BackgroundColor()
        {

        }
        static void SetTextColor(char s)
        {
            if (s == 'W')
            {

                Console.ForegroundColor = ConsoleColor.White;
            }
            if (s == 'R')
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (s == 'D')

            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

        }
        static void Path(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(@path);
            List<FileSystemInfo> array = new List<FileSystemInfo>();
            array.AddRange(dir.GetDirectories());
            array.AddRange(dir.GetFiles());
            
            int index = 0;
            bool quit = false;
            while (!quit)
            {
                Draw(index, array, path);

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        index--;
                        if (index < 0)
                        {
                            index = array.Count - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        index = (index + 1) % array.Count;
                        break;
                    case ConsoleKey.Enter:
                        if (array[index].GetType() == typeof(DirectoryInfo))
                        {
                            try
                            {
                                Path(array[index].FullName);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Exception");
                            }
                        }
                        else if (array[index].GetType() == typeof(FileInfo))
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            FileStream fs = null;
                            StreamReader sr = null;
                            try
                            {
                                fs = new FileStream(array[index].FullName, FileMode.Open, FileAccess.Read);
                                sr = new StreamReader(fs);

                                Console.WriteLine(sr.ReadToEnd());
                                Console.ReadKey();
                                Console.CursorVisible = false;
                            }
                            catch (Exception ex)
                            {
                                Console.CursorVisible = false;
                                Console.WriteLine("Exception");
                            }
                            finally
                            {
                                if (sr != null)
                                {
                                    sr.Close();
                                }

                                if (fs != null)
                                {
                                    fs.Close();
                                }
                            }
                            break;

                        }
                        break;
                    case ConsoleKey.Backspace:
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Clear();
                        quit = true;
                        break;
                    case ConsoleKey.Escape:
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Clear();
                        Console.WriteLine("If you want to quit the program press the Escape, otherwise press Backspace");
                        ConsoleKeyInfo pressed = Console.ReadKey();

                        switch (pressed.Key)
                        {
                            case ConsoleKey.Escape:
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Clear();
                                Environment.Exit(0);
                                break;
                        }
                        break;
                    default:
                        break;


                }
            }



        }
        static void Main(string[] args)
        {
            Console.SetWindowSize(110, 35);
            Console.SetBufferSize(110, 300);
            Path(@"C:\");

        }
    }
}