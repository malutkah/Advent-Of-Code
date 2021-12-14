using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
    class Program
    {
        private static List<string> inputs = new List<string>();
        private static List<string> testinputs = new List<string>();

        private static void FillList()
        {
            string inputPath = @"C:\Users\Alan\Nextcloud2\AoC\Day 7\Day 7\input.txt";
            string testinputPath = @"C:\Users\Alan\Nextcloud2\AoC\Day 7\Day 7\testinput.txt";

            foreach (string line in File.ReadLines(inputPath))
            {
                inputs.Add(line);
            }

            foreach (string line in File.ReadLines(testinputPath))
            {
                testinputs.Add(line);
            }
        }

        static void Main(string[] args)
        {
            FillList();

            Solve();

            Console.ReadKey();
        }

        private static void Solve()
        {
            // part 2
            List<int> horizontalPositions = new List<int>();
            List<int> fuels = new List<int>();
            List<int> allFuelCosts = new List<int>();
            horizontalPositions = inputs[0].Split(',').Select(int.Parse).ToList();

            int fuelCosts = 0;
            int totalFuelCost = 0;
            int steps = 0;
            var max = horizontalPositions.Max();

            for (int j = 0; j < max; j++)
            {
                for (int c = 0; c < horizontalPositions.Count; c++)
                {
                    steps = horizontalPositions[c] > j ? horizontalPositions[c] - j : j - horizontalPositions[c];

                    for (int s = 1; s <= steps; s++)
                    {
                        fuelCosts += s;
                    }

                    fuels.Add(fuelCosts);
                    fuelCosts = 0;
                    steps = 0;
                }

                for (int i = 0; i < fuels.Count; i++)
                {
                    totalFuelCost += fuels[i];
                }

                allFuelCosts.Add(totalFuelCost);
                totalFuelCost = 0;
                fuels.Clear();
            }

            var min = allFuelCosts.Min();

            Console.WriteLine();
            Console.WriteLine($"Total costs of fuel: {min}");
        }
    }
}
