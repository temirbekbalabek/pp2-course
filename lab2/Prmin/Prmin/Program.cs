using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxMin
{
    class Program
    {
        static void f()
        {
            FileStream file = new FileStream(@"C:\Users\Dauren\source\repositorypp2Dauren\lab2\Prmin\input.txt", FileMode.Open, FileAccess.Read);
            StreamReader push = new StreamReader(file);

            string s = push.ReadToEnd();
            string pr = "";
            string ppr = "";
            string[] arr = s.Split(' ');
            List<int> nums = new List<int>();
            int mn = -1;


            for (int i = 0; i < arr.Length; ++i)
            {
                int x = int.Parse(arr[i]);

                if (IsPrime(x))
                {
                    /* pr = (pr + " " + x);
                     if (x < mn)
                     {
                         mn = x;

                     } */
                    nums.Add(x);
                }

            }
            mn = nums[0];
            for(int j = 0; j < nums.Count; j++)
            {
                if(mn > nums[j])
                {
                    mn = nums[j];
                }
            }

                ppr = "Most little prime number in file is " + ppr + mn;
            File.WriteAllText(@"C:\Users\Dauren\source\repositorypp2Dauren\lab2\Prmin\output.txt", ppr);


            push.Close();
            file.Close();

            FileStream w = new FileStream(@"C:\Users\Dauren\source\repositorypp2Dauren\lab2\Prmin\output.txt", FileMode.Open, FileAccess.Write);
            StreamWriter wr = new StreamWriter(w);

            wr.WriteLine(pr);
            wr.WriteLine(ppr);

            wr.Close();
            w.Close();

        }


        static bool IsPrime(int n)
        {
            if (n == 1 || n == 0)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(n); ++i)
            {
                if (n % i == 0)
                {
                    return false;
                }

            }
            return true;
        }
        static void Main(string[] args)
        {

            f();
        }
    }
}
