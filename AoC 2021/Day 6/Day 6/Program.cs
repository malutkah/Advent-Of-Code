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
            //FillList();

            Part1();

            Console.ReadKey();
        }

        private static void Part1()
        {
            string[] _inputs = File.ReadAllText(Path.Combine(@"C:\Users\Alan\Nextcloud2\Advent-Of-Code\AoC 2021\Day 6\Day 6", "input.txt")).Split(',');

            int[] input = (Array.ConvertAll(_inputs, s => Int32.Parse(s)));

            long[] fishGens = new long[9];

            foreach (var f in input)
            {
                fishGens[f]++;
            }

            for (int i = 0; i < 256; i++)
            {
                long newOnes = fishGens[0];

                for (int j = 1; j < fishGens.Length; j++)
                {
                    fishGens[j - 1] = fishGens[j];
                }

                fishGens[8] = newOnes;
                fishGens[6] += newOnes;
            }

            Console.WriteLine($"{fishGens.Sum()}");
        }

    }
}
