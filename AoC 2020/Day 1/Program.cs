using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_1
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
            List<int> inputNumbers = new List<int>();

            input.ForEach(s => inputNumbers.Add(int.Parse(s)));

            int num1 = 0, num2 = 0, num3 = 0, final = 0;

            for (int i = 0; i < inputNumbers.Count; i++)
            {
                for (int j = 0; j < inputNumbers.Count; j++)
                {
                    for (int n = 0; n < inputNumbers.Count; n++)
                    {
                        if (inputNumbers[i] + inputNumbers[j] + inputNumbers[n] == 2020)
                        {
                            num1 = inputNumbers[i];
                            num2 = inputNumbers[j];
                            num3 = inputNumbers[n];

                            Console.WriteLine($"{num1} + {num2} + {num3} = {num1 + num2 + num3}");
                            Console.WriteLine($"{num1} * {num2} * {num3} = {num1 * num2 * num3}");
                            break;
                        }
                    }
                }
            }
        }
    }
}
