
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = Console.ReadLine();
            string[] words = sentence.Split(' ');
            int numOfPoly = 0;
            foreach (string word in words)
            {
                if (isPolyndrome(word))
                {
                    numOfPoly++;
                }
            }
            Console.WriteLine(words.Length);
            Console.WriteLine(numOfPoly);

        }
        private static bool isPolyndrome(string word)
        {
            bool isPoly = true;
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - i - 1])
                {
                    isPoly = false;
                }
            }
            return isPoly;
        }
    }
}