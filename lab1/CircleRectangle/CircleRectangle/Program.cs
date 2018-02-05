using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace Task3prime
{
    class Rectangle
    {
        int width;
        int height;
        int RArea;
        int RPerimeter;
        double RDiagonal;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;

        }

        public void findAreaR()
        {
            RArea = width * height;
        }

        public void findPerimetr()
        {
            RPerimeter = 2 * (width + height);
        }

        public void findDiagonal()
        {
            RDiagonal = Math.Sqrt(width * width + height * height);
        }


        public void Printinfo()
        {
            Console.WriteLine($"The Area of the rectangle is " + RArea);
            Console.WriteLine($"The Perimeter of the rectangle is " + RPerimeter);
            Console.WriteLine($"The diagonal of the rectangle is " + RDiagonal);
        }

    }

    class Circle
    {
        int radius;
        double CArea;
        double CLength;
        double CDiametr;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void findArea()
        {
            CArea = Math.PI * radius * radius;
        }

        public void findLength()
        {
            CLength = Math.PI * 2 * radius;
        }

        public void findDiametr()
        {
            CDiametr = 2 * radius;
        }

        public void Print1Info()
        {
            Console.WriteLine($"The Area of the circle is " + CArea);
            Console.WriteLine($"The Length of the circle is " + CLength);
            Console.WriteLine($"The Diameter of the circle is " + CDiametr);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, write width of the Rectangle: ");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Please, write height of the Rectangle: ");
            int b = int.Parse(Console.ReadLine());

            Rectangle s = new Rectangle(a, b);
            s.Printinfo();

            int r = int.Parse(Console.ReadLine());
            Circle c = new Circle(r);
            c.Print1Info();

            Console.ReadKey();

        }
    }
}