using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8
{
    class Program
    {
        private static List<string> inputs = new List<string>();
        private static List<string> testinputs = new List<string>();
        private static List<string> digitsString = new List<string>();

        #region digits
        private const int digit_0 = 6;
        private const int digit_1 = 2;
        private const int digit_2 = 5;
        private const int digit_3 = 5;
        private const int digit_4 = 4;
        private const int digit_5 = 5;
        private const int digit_6 = 6;
        private const int digit_7 = 3;
        private const int digit_8 = 7;
        private const int digit_9 = 6;

        private const string Sdigit_0 = "cagedb";
        private const string Sdigit_1 = "ab";
        private const string Sdigit_2 = "gcdfa";
        private const string Sdigit_3 = "fbcad";
        private const string Sdigit_4 = "eafb";
        private const string Sdigit_5 = "cdfbe";
        private const string Sdigit_6 = "cdfgeb";
        private const string Sdigit_7 = "dab";
        private const string Sdigit_8 = "acedgfb";
        private const string Sdigit_9 = "cefabd";
        #endregion

        private static void FillList()
        {
            string inputPath = @"C:\Users\Alan\Nextcloud2\AoC\Day 8\Day 8\input.txt";
            string testinputPath = @"C:\Users\Alan\Nextcloud2\AoC\Day 8\Day 8\testinput.txt";

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

            //Solve();
            PrintSegment();

            Console.ReadKey();
        }

        private static void Solve()
        {
            // easy digits:
            // 1, 4, 7, 8

            List<string[]> outputValues = new List<string[]>();
            List<string> easyDigits = new List<string>();
            string[] splitBeforeLine = new string[58];
            string[] splitAfterLine = new string[58];
            int easyDigitCounter = 0;

            // get strings after '|'
            foreach (string input in inputs)
            {
                string[] splitLine = input.Split('|');
                splitBeforeLine = splitLine[0].Split(' ').Where(k => k != "").ToArray();
                splitAfterLine = splitLine[1].Split(' ').Where(k => k != "").ToArray();

                outputValues.Add(splitAfterLine);
            }

            for (int s = 0; s < outputValues.Count; s++)
            {
                for (int i = 0; i < outputValues[s].Length; i++)
                {
                    switch (outputValues[s][i].Length)
                    {
                        case digit_1:
                            easyDigits.Add(outputValues[s][i]);
                            break;
                        case digit_4:
                            easyDigits.Add(outputValues[s][i]);
                            break;
                        case digit_7:
                            easyDigits.Add(outputValues[s][i]);
                            break;
                        case digit_8:
                            easyDigits.Add(outputValues[s][i]);
                            break;
                        default:
                            break;
                    }
                }
            }

            Console.WriteLine($"instances of easy digits {easyDigits.Count}");
        }

        private static void SetDigits(List<string> _segments)
        {
            string digits = "";
            
            // 0

        }

        private static void PrintSegment(string segment = "")
        {
            List<string> segments = new List<string>();

            segment = "gcbe";

            // 1,2,3,4 & 6,7,8,9
            segments.Add($" dddd ");//0
            segments.Add($"e");//1
            segments.Add($"    a");//2
            segments.Add($"e");//3
            segments.Add($"    a");//4
            segments.Add($" ffff ");//5
            segments.Add($"g");//6
            segments.Add($"    b");//7
            segments.Add($"g");//8
            segments.Add($"    b");//9
            segments.Add($" cccc");//10

            if (segment.Length == digit_0 || segment.Length == digit_6 || segment.Length == digit_9)
            {

            }

            if (segment.Length == digit_1)
            {
                // draw 1
                Console.WriteLine($" {segments[2]}");
                Console.WriteLine($" {segments[4]}");
                Console.WriteLine();
                Console.WriteLine($" {segments[7]}");
                Console.WriteLine($" {segments[9]}");
            }

            if (segment.Length == digit_7)
            {
                // draw 7
                Console.WriteLine($"{segments[0]}");
                Console.WriteLine($" {segments[2]}");
                Console.WriteLine($" {segments[4]}");
                Console.WriteLine();
                Console.WriteLine($" {segments[7]}");
                Console.WriteLine($" {segments[9]}");
            }

            if (segment.Length == digit_4)
            {
                // draw 4
                Console.WriteLine($"{segments[1]}{segments[2]}");
                Console.WriteLine($"{segments[3]}{segments[4]}");
                Console.WriteLine($"{segments[5]}");
                Console.WriteLine($" {segments[7]}");
                Console.WriteLine($" {segments[9]}");
            }

            if (segment.Length == digit_8)
            {
                // draw 8
                Console.WriteLine($"{segments[0]}");
                Console.WriteLine($"{segments[1]}{segments[2]}");
                Console.WriteLine($"{segments[3]}{segments[4]}");
                Console.WriteLine($"{segments[5]}");
                Console.WriteLine($"{segments[6]}{segments[7]}");
                Console.WriteLine($"{segments[8]}{segments[9]}");
                Console.WriteLine($"{segments[10]}");
            }
        }
    }
}
