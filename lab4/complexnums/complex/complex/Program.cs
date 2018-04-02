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
        static void Load()
        {
            FileStream fs = new FileStream("complex.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            Complex s = xs.Deserialize(fs) as Complex;
            Console.WriteLine(s.ToString());
            fs.Close();
        }
        static void Save(Complex name)
        {
            FileStream fs = new FileStream("complex.xml", FileMode.Truncate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));

            xs.Serialize(fs, name);


            fs.Close();
        }
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
                Complex summa = result;
                Console.WriteLine(summa);
                Save(summa);
                Load();

            }
            if (znak == '-') {
                Complex raznost = result1;
                Console.WriteLine(raznost);
                Save(raznost);

                Load();
            }
            if (znak == '*') {
                Complex multi = resultm;
                Console.WriteLine(multi);
                Save(multi);

                Load();
            }
            if (znak == '/') {
                Complex delenie = resultdiv;
                Console.WriteLine(delenie);
                Save(delenie);

                Load();
            }







            Console.ReadKey();

           
        }
    }
}
