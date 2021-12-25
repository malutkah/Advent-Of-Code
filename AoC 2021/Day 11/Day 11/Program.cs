using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11
{
    class Program
    {
        private static List<string> inputs = new List<string>();
        private static List<string> testinputs = new List<string>();

        private static void FillList()
        {
            string inputPath = @"..\..\input.txt";
            string testinputPath = @"..\..\testinput.txt";

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
            Part1();
            Part2();
            Console.ReadKey();
        }

        private static void Part1()
        {
            int flashes = 0;
            int[,] field = new int[10, 10];

            for (int i = 0; i < testinputs.Count; i++)
            {
                for (int c = 0; c < testinputs[i].Length; c++)
                {
                    field[i, c] = (int)char.GetNumericValue(testinputs[i][c]);
                }
            }

            for (int x = 0; x < field.Length; x++)
            {
                for (int y = 0; y < field.Length; y++)
                {
                    var currentField = field[x, y];
                    bool foundNine = false;

                    // (1) increase energy level by 1
                    currentField += 1;

                    // (2) check if energy level is greater than 9
                    if (currentField > 9)
                    {
                        foundNine = true;

                        // (3) if so increase all adjacent values by 1
                        // left, right, up, down, up left, up right, down left, down right

                        // left = field[x -1, y]   | topLeft = field[x-1, y-1]  | downLeft = field[x-1, y+1]
                        // right = field [x +1, y] | topRight = field[x+1, y-1] | downRight = field[x+1, y+1]
                        // up = field[x, y-1
                        // down = field[x, y+1]
                        while (foundNine)
                        {
                            // (4) increase flash count by 1
                            flashes += 1;

                            // (5) and then set the value which exceeded 9 to 0
                            // repeat until there are no more flashes
                            // (6) and move on to the next field and repeat
                        }
                    }
                }
            }
        }



        private static void Part2()
        {

        }
    }
}
