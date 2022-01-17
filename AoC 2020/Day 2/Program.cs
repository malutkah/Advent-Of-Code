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
        private static void FillList(List<string> input, string path = "real")
        {
            string inputPath = path == "real" ? @"../../input.txt" : @"../../testinput.txt";

            foreach (string line in File.ReadLines(inputPath))
            {
                input.Add(line);
            }
        }

        static void Main(string[] args)
        {
            List<string> inputs = new List<string>();
            List<string> testInputs = new List<string>();
            FillList(inputs);
            FillList(testInputs, "test");

            Solve(inputs);

            Console.ReadKey();
        }

        private static void Solve(List<string> input)
        {
        }
    }
}
