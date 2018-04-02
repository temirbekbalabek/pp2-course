using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SnakeGame
{
    class Records
    {
        private static string file = "Records.txt";
        private static List<RecordsEntry> entries = new List<RecordsEntry>();
        private static void GetRecords()
        {
            entries.Clear();
            if (File.Exists(file))
            {
                StreamReader read = new StreamReader(file);
                using (read)
                {
                    string line = read.ReadLine();
                    while (line != null)
                    {
                        string[] res = line.Split();
                        RecordsEntry entry = new RecordsEntry();
                        entry.Name = res[0];
                        entry.Score = int.Parse(res[1]);
                        entries.Add(entry);
                        line = read.ReadLine();
                    }
                }
            }
        }
        public static bool CheckForRecordResult(int result)
        {
            GetRecords();
            if (result == 0)
            {
                return false;
            }
            if (entries.Count < 10)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < entries.Count; i++)
                {
                    if (result > entries[i].Score)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public static void EnterRecords(RecordsEntry entry)
        {
            entries.Add(entry);
            if (entries.Count > 10)
            {
                int min = int.MaxValue;
                int pos = 0;
                for (int i = 0; i < entries.Count; i++)
                {
                    if (entries[i].Score < min)
                    {
                        min = entries[i].Score;
                        pos = i;
                    }
                }
                entries.RemoveAt(pos);
            }
            SaveRecords();
        }
        private static void SaveRecords()
        {
            StreamWriter write = new StreamWriter(file, false);
            using (write)
            {
                for (int i = 0; i < entries.Count; i++)
                {
                    write.WriteLine("{0} {1}", entries[i].Name, entries[i].Score);
                }
            }
        }
        public static void Show()
        {
            GetRecords();
            var list = from entry in entries
                       orderby entry.Score descending
                       select entry;
            int counter = 1;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(36, 5);
            Console.Write("Records:");
            foreach (var item in list)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(30, 6 + counter);
                if (counter % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                if (counter % 3 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine("{0} - {1}   -   {2}", counter, item.Name, item.Score);
                Console.ForegroundColor = ConsoleColor.White;
                //counter++;
            }
            Console.ReadKey();
            Console.Clear();
            Menu.Draw();
        }
    }
}
