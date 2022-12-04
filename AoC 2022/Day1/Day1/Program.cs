using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        private static List<string> FillList(List<string> input, bool isTest = true)
        {
            string inputPath = isTest ? @"test.txt" : @"input.txt";

            foreach (string line in File.ReadLines(inputPath))
            {
                input.Add(line);
            }

            return input;
        }

        static void Main(string[] args)
        {
            List<string> inputs = new List<string>();

            Solve(FillList(inputs, true));

            Console.ReadKey();
        }

        private static void Solve(List<string> list)
        {
            int calories = 0;
            List<int> cals = new List<int>();

            for (int c = 0; c < list.Count; c++)
            {
                if (list[c] != "")
                    calories += int.Parse(list[c]);

                if (list[c] == "" || c == list.Count -1)
                {
                    cals.Add(calories);
                    calories = 0;
                }

            }

            var secondHighest =
                                cals
                                .Distinct()
                                .OrderByDescending(i => i)
                                .Skip(1)
                                .First();
            var thirdHighest =
                                cals
                                .Distinct()
                                .OrderByDescending(i => i)
                                .Skip(2)
                                .First();

            Console.WriteLine($"max calories = {cals.Max()}");
            Console.WriteLine($"2nd max calories = {secondHighest}");
            Console.WriteLine($"3rd max calories = {thirdHighest}");
            Console.WriteLine($"total top 3 calories = {cals.Max() + secondHighest + thirdHighest}");
        }

    }
}
