using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3
{
    class Program
    {
        private static List<string> inputs = new List<string>();
        private static List<string> inputsSave = new List<string>();

        static void Main(string[] args)
        {
            FillList();

            Part2();
            Part2_2();

            Console.ReadKey();
        }

        private static void Part2()
        {
            List<string> binaryOfOnes = new List<string>();
            List<string> binaryOfZeros = new List<string>();

            for (int n = 0; n < 12; n++)
            {
                for (int i = 0; i < inputs.Count; i++)
                {
                    string currentBit = inputs[i].Substring(n, 1);

                    if (currentBit == "1")
                    {
                        binaryOfOnes.Add(inputs[i]);
                    }
                    else
                    {
                        binaryOfZeros.Add(inputs[i]);
                    }
                }

                // ------- oxygen generator value ---------
                // if binayerOfOnes.Count == binaryOfZeros.Count
                inputs.Clear();

                if (binaryOfOnes.Count == binaryOfZeros.Count)
                {
                    inputs.AddRange(binaryOfOnes);
                }
                else
                {
                    if (binaryOfOnes.Count > binaryOfZeros.Count)
                    {
                        inputs.AddRange(binaryOfOnes);
                    }
                    else
                    {
                        inputs.AddRange(binaryOfZeros);
                    }
                }

                binaryOfOnes.Clear();
                binaryOfZeros.Clear();
                //-----------------------------------------
            }

            Console.WriteLine($"inputs count: {inputs.Count}");
            Console.WriteLine($"oxygen generator rating {inputs[0]} ({Convert.ToInt32(inputs[0], 2)})");
        }

        private static void Part2_2()
        {
            List<string> binaryOfOnes = new List<string>();
            List<string> binaryOfZeros = new List<string>();

            for (int n = 0; n < 12; n++)
            {
                for (int i = 0; i < inputsSave.Count; i++)
                {
                    string currentBit = inputsSave[i].Substring(n, 1);

                    if (currentBit == "1")
                    {
                        binaryOfOnes.Add(inputsSave[i]);
                    }
                    else
                    {
                        binaryOfZeros.Add(inputsSave[i]);
                    }
                }

                // ------- oxygen generator value ---------

                inputsSave.Clear();

                if (binaryOfOnes.Count == binaryOfZeros.Count)
                {
                    inputsSave.AddRange(binaryOfZeros);
                }
                else
                {
                    if (binaryOfOnes.Count > binaryOfZeros.Count)
                    {
                        inputsSave.AddRange(binaryOfZeros);
                    }
                    else
                    {
                        inputsSave.AddRange(binaryOfOnes);
                    }
                }

                binaryOfOnes.Clear();
                binaryOfZeros.Clear();

                if (inputsSave.Count == 1)
                    break;
                //-----------------------------------------
            }

            Console.WriteLine($"inputs count: {inputsSave.Count}");
            Console.WriteLine($"CO2 scrubber rating {inputsSave[0]} ({Convert.ToInt32(inputsSave[0], 2)})");
        }

        private static void Part1()
        {
            string gammaRate = "", epsilonRate = "";
            string currentBit = "";
            int oneCounter = 0, zeroCounter = 0;

            for (int n = 0; n < 12; n++)
            {
                for (int i = 0; i < inputs.Count; i++)
                {
                    currentBit = inputs[i].Substring(n, 1);

                    if (currentBit == "0")
                    {
                        zeroCounter++;
                    }
                    else
                    {
                        oneCounter++;
                    }
                }

                gammaRate = oneCounter > zeroCounter ? gammaRate.Insert(n, "1") : gammaRate.Insert(n, "0");
                epsilonRate = oneCounter > zeroCounter ? epsilonRate.Insert(n, "0") : epsilonRate.Insert(n, "1");

                oneCounter = 0;
                zeroCounter = 0;
            }

            Console.WriteLine($"gamma rate:   {gammaRate}   | decimal: {Convert.ToInt32(gammaRate, 2)}");
            Console.WriteLine($"epsilon rate: {epsilonRate} | decimal: {Convert.ToInt32(epsilonRate, 2)}");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine($"Power consumption: {Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2)}");
        }

        private static void FillList()
        {
            string inputPath = @"..\..\input\input.txt";

            foreach (string line in File.ReadLines(inputPath))
            {
                inputs.Add(line);
                inputsSave.Add(line);
            }
        }
    }
}
