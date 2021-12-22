using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    class Program
    {
        private static List<string> inputs = new List<string>();
        private static List<string> testinputs = new List<string>();
        private static Dictionary<Vector2, int> heigths = new Dictionary<Vector2, int>();

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
            Solve();
            Console.ReadKey();
        }

        private static void Solve()
        {
            List<int> lowValues = new List<int>();
            int rows = testinputs.Count - 1;
            int columns = testinputs[0].Length - 1;
            CreateHeightMap();

            for (int row = 0; row <= rows; row++)
            {
                for (int col = 0; col <= columns; col++)
                {
                    if (row == 0)
                    {
                        if (row == 0 && col == 0)
                        {
                            // top left
                            // check right && bottom
                            if (isRightLower(row, col) && isBottomLower(row, col))
                            {
                                lowValues.Add(heigths[new Vector2(row, col)]);
                            }
                        }
                        else
                        {
                            // top edge
                            // check left, right, bottom
                            if (col != columns)
                            {
                                if (isLeftLower(row, col) && isRightLower(row, col) && isBottomLower(row, col))
                                {
                                    lowValues.Add(heigths[new Vector2(row, col)]);
                                }
                            }
                        }
                    }

                    if (col == 0)
                    {
                        if (row == rows && col == 0)
                        {
                            // bottom left
                            // check up && right

                            if (isUpLower(row, col) && isRightLower(row, col))
                            {
                                lowValues.Add(heigths[new Vector2(row, col)]);
                            }
                        }
                        else
                        {
                            // left edge
                            // check up, right, bottom

                            if (row != 0)
                            {
                                if (isUpLower(row, col) && isRightLower(row, col) && isBottomLower(row, col))
                                {
                                    lowValues.Add(heigths[new Vector2(row, col)]);
                                }
                            }
                        }
                    }

                    if (col == columns)
                    {
                        if (row == 0 && col == columns)
                        {
                            // top right
                            // check left && bottom

                            if (isLeftLower(row, col) && isBottomLower(row, col))
                            {
                                lowValues.Add(heigths[new Vector2(row, col)]);
                            }
                        }
                        else
                        {
                            // right edge
                            // check up, left, bottom

                            if (isUpLower(row, col) && isLeftLower(row, col) && isBottomLower(row, col))
                            {
                                lowValues.Add(heigths[new Vector2(row, col)]);
                            }
                        }
                    }

                    if (row == rows)
                    {
                        if (row == rows && col == columns)
                        {
                            // bottom right
                            // check up && left

                            if (isUpLower(row, col) && isLeftLower(row, col))
                            {
                                lowValues.Add(heigths[new Vector2(row, col)]);
                            }
                        }
                        else
                        {
                            // bottom edge
                            // check up, left, right
                            if (isUpLower(row, col) && isLeftLower(row, col) && isRightLower(row, col))
                            {
                                lowValues.Add(heigths[new Vector2(row, col)]);
                            }
                        }
                    }

                    if (row != 0 && row != rows && col != 0 && col != columns)
                    {
                        if (isRightLower(row, col) && isLeftLower(row, col) && isUpLower(row, col) && isBottomLower(row, col))
                        {
                            lowValues.Add(heigths[new Vector2(row, col)]);
                        }
                    }

                }
            }

            var sum = 0;
            for (int i = 0; i < lowValues.Count; i++)
            {
                sum += lowValues[i];
            }

            Console.WriteLine($"{sum + lowValues.Count}");
        }


        private static bool isRightLower(int row, int col)
        {
            return heigths[new Vector2(row, col)] < heigths[new Vector2(row, col + 1)] ? true : false;
        }

        private static bool isLeftLower(int row, int col)
        {
            return heigths[new Vector2(row, col)] < heigths[new Vector2(row, col - 1)] ? true : false;
        }

        private static bool isUpLower(int row, int col)
        {
            return heigths[new Vector2(row, col)] < heigths[new Vector2(row - 1, col)] ? true : false;
        }

        private static bool isBottomLower(int row, int col)
        {
            return heigths[new Vector2(row, col)] < heigths[new Vector2(row + 1, col)] ? true : false;
        }

        private static void CreateHeightMap()
        {
            for (int row = 0; row < testinputs.Count; row++)
            {
                for (int col = 0; col < testinputs[0].Length; col++)
                {
                    var value = Convert.ToInt32(testinputs[row][col].ToString());
                    heigths.Add(new Vector2(row, col), value);
                }
            }
        }
    }
}
