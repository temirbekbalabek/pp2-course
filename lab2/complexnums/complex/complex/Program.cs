using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace complex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите числитель и знаменатель числа а: ");
            string line1 = Console.ReadLine();
            string[] linefor1 = line1.Split(' ');

            int a = int.Parse(linefor1[0]);
            int b = int.Parse(linefor1[1]);
            Console.WriteLine("Введите числитель и знаменатель числа b: ");
            string line2 = Console.ReadLine();
            string[] linefor2 = line2.Split(' ');

            int c = int.Parse(linefor2[0]);
            int d = int.Parse(linefor2[1]);

            Complex c1 = new Complex(a, b);
            Complex c2 = new Complex(c, d);

            Complex result = c1 + c2;
            Complex result1 = c1 - c2;
            Complex resultdiv = c1 / c2;
            Complex resultm = c1 * c2;
            Console.WriteLine("Cумма = " + result);
            Console.WriteLine("Разность = " + result1);
            Console.WriteLine("Деление=  " + resultdiv);
            Console.WriteLine("Умножение= " + resultm);

            Console.ReadKey();
        }
    }
}
