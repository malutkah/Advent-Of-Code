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
        private static List<string> inputs = new List<string>();
        private static int horizontal, depth, aim;

        static void Main(string[] args)
        {
            horizontal = 0;
            depth = 0;
            aim = 0;

            FillList();

            Part2();

            Console.ReadKey();
        }

        private static void FillList()
        {
            string inputPath = @"..\..\input\input.txt";

            foreach (string line in File.ReadLines(inputPath))
            {
                inputs.Add(line);
            }
        }

        private static int GetLength(string command)
        {
            return Convert.ToInt32(new String(command.Where(Char.IsDigit).ToArray()));
        }

        private static void Part1()
        {
            int final = 0;

            for (int i = 0; i < inputs.Count; i++)
            {
                if (inputs[i].Contains("forward"))
                {
                    horizontal += GetLength(inputs[i]);
                }

                if (inputs[i].Contains("up"))
                {
                    depth -= GetLength(inputs[i]);
                }

                if (inputs[i].Contains("down"))
                {
                    depth += GetLength(inputs[i]);
                }

            }

            final = horizontal * depth;

            Console.WriteLine($"result: {final}"); // result: 1990000
        }

        private static void Part2()
        {
            int final = 0;

            for (int i = 0; i < inputs.Count; i++)
            {
                if (inputs[i].Contains("forward"))
                {
                    horizontal += GetLength(inputs[i]);
                    depth += GetLength(inputs[i]) * aim;
                }

                if (inputs[i].Contains("up"))
                {
                    aim -= GetLength(inputs[i]);
                }

                if (inputs[i].Contains("down"))
                {
                    aim += GetLength(inputs[i]);
                }

            }

            final = horizontal * depth;

            Console.WriteLine($"result: {final}"); 
        }
    }
}
