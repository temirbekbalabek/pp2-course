using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace complex
{
    [Serializable]
    class Program
    {
        static void Main(string[] args)
        {
            F1();
        }
        /*private static void F2()
        {

            FileStream fs = new FileStream("complex.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            Complex s = xs.Deserialize(fs) as Complex;
            11
            Console.WriteLine(s.GetInfo());

            fs.Close();
        }*/

        private static void F1()
        {
            Console.WriteLine("Введите числитель и знаменатель числа а: ");
            string line1 = Console.ReadLine();
            string[] linefor1 = line1.Split(' ');

            int a = int.Parse(linefor1[0]);
            int b = int.Parse(linefor1[1]);
            Console.WriteLine("Введите знак: ");
            string sign = Console.ReadLine();
            char znak = sign[0];
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
            if (znak == '+') {
                string summa = "Cумма = " + result;
                Console.WriteLine(summa);
                FileStream fs = new FileStream("complex.xml", FileMode.Truncate, FileAccess.ReadWrite);
                XmlSerializer xs = new XmlSerializer(typeof(string));

                xs.Serialize(fs, summa);


                fs.Close();
            }
            if (znak == '-') {
                string raznost = "Разность = " + result1;
                Console.WriteLine(raznost);
                FileStream fs = new FileStream("complex.xml", FileMode.Truncate, FileAccess.ReadWrite);
                XmlSerializer xs = new XmlSerializer(typeof(string));

                xs.Serialize(fs, raznost);


                fs.Close();
            }
            if (znak == '*') {
                string multi = "Умножение = " + resultm;
                Console.WriteLine(multi);
                FileStream fs = new FileStream("complex.xml", FileMode.Truncate, FileAccess.ReadWrite);
                XmlSerializer xs = new XmlSerializer(typeof(string));

                xs.Serialize(fs, multi);


                fs.Close();
            }
            if (znak == '/') {
                string delenie = "Деление = " + resultdiv;
                Console.WriteLine(delenie);
                FileStream fs = new FileStream("complex.xml", FileMode.Truncate, FileAccess.ReadWrite);
                XmlSerializer xs = new XmlSerializer(typeof(string));

                xs.Serialize(fs, delenie);


                fs.Close();
            }







            Console.ReadKey();

           
        }
    }
}
