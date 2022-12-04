using System;
using System.Collections.Generic;
using System.IO;

namespace Day3
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

            Solve(FillList(inputs));

            Console.ReadKey();
        }

        private static void print(string msg)
        {
            Console.WriteLine(msg);
        }

        private static void Solve(List<string> list)
        {

            for (int i = 0; i < list.Count; i++)
            {
                string rucksack = list[i];
                string compart1 = rucksack.Substring(0, rucksack.Length / 2);
                string compart2 = rucksack.Substring(rucksack.Length / 2, compart1.Length);


                print($"rucksack {i + 1} compartnemnt 1: {compart1}");
                print($"rucksack {i + 1} compartnemnt 2: {compart2}");
                print("----------------------------");
            }
        }

    }
}
