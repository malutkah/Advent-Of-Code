using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\input\input.txt";
            List<int> inputs = new List<int>();
            int increasedCount = 0;

            foreach (string line in File.ReadLines(inputPath))
            {
                inputs.Add(Convert.ToInt32(line));
            }

            Part2(increasedCount, inputs);
        }

        private static void Part2(int increasedCount, List<int> inputs)
        {
            int field = 0;
            int result1 = 0, result2 = 0;
            int x = 0, y = 0, z = 0;
            int sum = 0;

            for (int i = 0; i < inputs.Count; i++)
            {
                if (field == 0)
                {
                    x = inputs[i];
                    field++;
                }
                else if (field == 1)
                {
                    y = inputs[i];
                    field++;
                }
                else if (field == 2)
                {
                    z = inputs[i];
                    field = 0;
                }

                if (x != 0 && y != 0 && z != 0)
                {
                    if (sum == 0)
                    {
                        result1 = x + y + z;
                        sum++;
                    }
                    else
                    {
                        result2 = x + y + z;
                        sum = 0;
                    }

                    if (result1 != 0 && result2 != 0)
                    {

                        if (sum == 0)
                        {
                            if (result1 < result2)
                            {
                                Console.WriteLine($"{inputs[i]} (increased)");
                                increasedCount++;
                            }
                            else
                            {
                                Console.WriteLine($"{inputs[i]} (decreased)");
                            }
                        }
                        else
                        {
                            if (result2 < result1)
                            {
                                Console.WriteLine($"{inputs[i]} (increased)");
                                increasedCount++;
                            }
                            else
                            {
                                Console.WriteLine($"{inputs[i]} (decreased)");
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Increased: {increasedCount}");
            Console.ReadKey();
        }

        private static void Part1(int increasedCount, List<int> inputs)
        {
            int tmp = inputs[0];

            for (int i = 1; i < inputs.Count; i++)
            {
                if (tmp < inputs[i])
                {
                    increasedCount++;
                    Console.WriteLine($"{inputs[i]} (increased)");
                }
                else
                {
                    Console.WriteLine($"{inputs[i]} (decreased)");
                }

                tmp = inputs[i];
            }

            Console.WriteLine($"Increased: {increasedCount}");
            Console.ReadKey();
        }
    }
}
