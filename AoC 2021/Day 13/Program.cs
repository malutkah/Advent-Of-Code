using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_13
{
    class Program
    {
        private static bool isTest = true;

        private static List<string> FillList(bool test = false)
        {
            List<string> input = new List<string>();
            string inputPath = !test ? @"../../input.txt" : @"../../testinput.txt";

            foreach (string line in File.ReadLines(inputPath))
            {
                input.Add(line);
            }

            return input;
        }


        static void Main(string[] args)
        {
            Solve(FillList(isTest));

            Console.ReadKey();
        }

        private static void Solve(List<string> inputs)
        {
            // to get only the coordinates
            int substractCount = isTest ? 3 : 13;
            int x = 0, y = 0;
            List<Vector2> coordList = new List<Vector2>();

            // to get the fold instructions
            int foldAlongX = 0, foldAlongY = 0;
            string foldAlong = string.Empty;
            List<string> foldAlongStringList = new List<string>();
            List<int> foldAlongXList = new List<int>();
            List<int> foldAlongYList = new List<int>();


            // get fold along coordinates
            for (int i = inputs.Count - substractCount + 1; i < inputs.Count; i++)
            {
                foldAlongStringList.Add(inputs[i]);
            }

            for (int i = 0; i < foldAlongStringList.Count; i++)
            {
                foldAlong = "";
                for (int k = 0; k < foldAlongStringList[i].Length; k++)
                {
                    if (Char.IsDigit(foldAlongStringList[i][k]))
                    {
                        foldAlong += foldAlongStringList[i][k];
                    }
                }

                if (foldAlongStringList[i].Contains("y"))
                {
                    var theNumber = Regex.Match(foldAlongStringList[i], @"\d+").Value;
                    foldAlongYList.Add(int.Parse(foldAlong));
                }
                else
                {
                    foldAlongXList.Add(int.Parse(foldAlong));
                }
            }

            // get coordinates
            for (int i = 0; i < inputs.Count - substractCount; i++)
            {
                string[] splitCoordinates = inputs[i].Split(new string[] { "," }, StringSplitOptions.None);

                x = int.Parse(splitCoordinates[0]);
                y = int.Parse(splitCoordinates[1]);
                coordList.Add(new Vector2(x, y));
            }

            float Xmax = 0f;
            float Ymax = 0f;

            // get the highest x and y values
            for (int i = 0; i < coordList.Count; i++)
            {
                Xmax = Math.Max(coordList[i].X, Xmax);
                Ymax = Math.Max(coordList[i].Y, Ymax);
            }

            string[,] grid = new string[(int)Xmax + 1, (int)Ymax + 1];

            for (int k = 0; k < (int)Ymax + 1; k++)
            {
                for (int j = 0; j < (int)Xmax + 1; j++)
                {
                    grid[j, k] = ".";
                }
            }

            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid.Length; col++)
                {
                    for (int i = 0; i < coordList.Count; i++)
                    {
                        if (row == coordList[i].Y && col == coordList[i].X)
                        {
                            grid[col, row] = "#";
                        }
                    }

                }
            }

            // fold the grid
            for (int i = 0; i < foldAlongStringList.Count; i++)
            {
                if (foldAlongStringList[i].Contains("y"))
                {
                    foldAlongY = int.Parse(Regex.Match(foldAlongStringList[i], @"\d+").Value);
                }
                else
                {
                    foldAlongX = int.Parse(Regex.Match(foldAlongStringList[i], @"\d+").Value);
                }
            }

            for (int k = 0; k < (int)Ymax + 1; k++)
            {
                for (int j = 0; j < (int)Xmax + 1; j++)
                {
                    Console.Write($"{grid[j, k]}");
                }
                Console.WriteLine();
            }

        }
    }
}
