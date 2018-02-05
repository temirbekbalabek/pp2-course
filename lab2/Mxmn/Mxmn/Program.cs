using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Mxmn
{
    class Program
    {
        static void f()
        {
            FileStream file = new FileStream(@"C:\Users\Dauren\source\repositorypp2Dauren\lab2\Mxmn\formxmn.txt", FileMode.Open,FileAccess.Read);
            StreamReader fl = new StreamReader(file);

            string s = fl.ReadToEnd();
            string[] arrs = s.Split(' ','\n');
            int Mx = int.Parse(arrs[0]);
            int mn = int.Parse(arrs[0]);
            for(int i = 0; i < arrs.Length; ++i)
            {
                int x = int.Parse(arrs[i]);
                if (Mx < x)
                {
                    Mx = x;
                }
                if (mn > x)
                {
                    mn = x;
                }
               
            }
                
            Console.WriteLine("Max nubmer in file is "+ Mx);
            Console.WriteLine("Min nubmer in file is " + mn);

            fl.Close();
            file.Close();
                

        }

        static void Main(string[] args)
        {
            f();

            
        }
    }
}
