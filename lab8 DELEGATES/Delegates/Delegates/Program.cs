using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        delegate void myDelegate(int x, int b);
        static void Main(string[] args)
        {
            myDelegate sumOfNumbers;
            Sum sum = new Sum();
            string s = Console.ReadLine();
            string[] nums = s.Split(' ');
            int x = int.Parse(nums[0]);
            int y = int.Parse(nums[1]);

            while (true)
            {
                Thread.Sleep(1000);
                sumOfNumbers = sum.SumOfNumbers;
                sumOfNumbers.Invoke(x, y);
                break;
            }


        }

    }
}
