using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            Path(path);
        }

        private static void Path(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            List<FileInfo> dir = new List<FileInfo>();
            dir.AddRange(dirInfo.GetFiles());

            foreach(FileInfo file in dir)
            {
                using(FileStream fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                {
                    StreamReader sr = new StreamReader(fs);
                    string t = sr.ReadLine();

                    string[] nums = t.Split(' ');

                    foreach(string num in nums)
                    {
                        if (isPrime(int.Parse(num)))
                        {
                            Console.WriteLine(file.Name);
                            break;
                        }
                    }
                }
            }
        }

        private static bool isPrime(int x)
        {
            bool isPrime = true;
            for(int i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0)
                {
                    isPrime = false;
                }
            }
            return isPrime;
        }
    }
}
