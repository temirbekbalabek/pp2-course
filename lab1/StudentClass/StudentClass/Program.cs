using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsStudent
{

    class Student
    {
        public string name;
        public string sname;
        public int age;
        public double gpa;
        public int numretakes;

        public Student()
        {
            name = "Dauren";
            sname = "Yerbolov";
            age = 17;
            gpa = 3.67;
            numretakes = 1;

        }
        public Student(string name, int age, double gpa)
        {
            this.name = name;
            this.age = age;
            this.gpa = gpa;

        }
        public Student(string name)
        {
            this.name = name;
        }


        public override string ToString()
        {
            if (numretakes > 0)
            {

                return this.name + " " + sname + " " + age + " " + gpa + " " + numretakes;
            }
            else
            {
                return this.name + " " + sname + " " + age + " " + gpa;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student a = new Student();

            Student s = new Student("asd", 4, 1);
            Student s2 = new Student("asd");

            Console.WriteLine(s2);

            Console.ReadKey();

        }
    }
}