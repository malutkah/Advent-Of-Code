using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2
{
    class Program
    {
        private static List<string> FillList(List<string> input, string path = "real")
        {
            string inputPath = path == "real" ? @"input.txt" : @"testinput.txt";

            foreach (string line in File.ReadLines(inputPath))
            {
                input.Add(line);
            }

            return input;
        }

        static void Main(string[] args)
        {
            List<string> inputs = new List<string>();

            Solve(FillList(inputs, "realy"));

            Console.ReadKey();
        }

        private static void Solve(List<string> input)
        {
            string[,] treeMap = new string[input.Count, input[0].Length];
        }
    }
}
