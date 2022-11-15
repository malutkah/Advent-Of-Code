using System;
using System.Collections.Generic;
using System.IO;

namespace Day_25
{
    class Program
    {
        private static List<string> FillList(List<string> input, string path = "real")
        {
            string inputPath = path == "real" ? @"..\..\..\input.txt" : @"..\..\..\testinput.txt";

            foreach (string line in File.ReadLines(inputPath))
            {
                input.Add(line);
            }

            return input;
        }

        static void Main(string[] args)
        {
            List<string> inputs = new List<string>();

            Solve(FillList(inputs, "reald"));

            Console.ReadKey();
        }

        private static void Solve(List<string> list)
        {
            string east = ">";
            string south = "v";
            string freeSpace = ".";
            int steps = 0;

            foreach (var item in list)
            {
                Console.WriteLine();
                Console.WriteLine(item);
            }
        }
    }
}
