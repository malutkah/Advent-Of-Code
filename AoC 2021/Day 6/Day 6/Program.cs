using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6
{
    class Program
    {
        private static List<string> inputs = new List<string>();
        private static List<string> testInputs = new List<string>();

        private static void FillList()
        {
            string inputPath = @"C:\Users\Alan\Nextcloud2\AoC\Day 6\Day 6\input.txt";
            string testinputPath = @"C:\Users\Alan\Nextcloud2\AoC\Day 6\Day 6\testinput.txt";

            foreach (string line in File.ReadLines(inputPath))
            {
                inputs.Add(line);
            }

            foreach (string line in File.ReadLines(testinputPath))
            {
                testInputs.Add(line);
            }
        }

        static void Main(string[] args)
        {
            FillList();

            Part1();

            Console.ReadKey();
        }

        private static void Part1()
        {
            List<long> nums = new List<long>();
            nums = inputs[0].Split(',').Select(long.Parse).ToList();
            int newCount = 0;
            int countSave = 0;

            Console.WriteLine($"Initial State: {inputs[0]}");

            for (int i = 0; i < 256; i++)
            {
                newCount = nums.Count;

                for (int n = 0; n < newCount; n++)
                {
                    nums[n]--;

                    if (nums[n] < 0)
                    {                        
                        nums[n] = 6;
                        nums.Add(8);
                        // 253.086.074
                        // 2.146.435.071
                        // save current count and clear list und mach weiter
                    }
                }

                //Console.WriteLine($"After {i+1} day(s): {string.Join(",", nums)}");
            }

            Console.WriteLine($"There are a total of {nums.Count} fish!");

        }

    }
}
