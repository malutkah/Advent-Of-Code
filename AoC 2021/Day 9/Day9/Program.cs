using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace Day9
{
    public enum Direction { RIGHT, LEFT, BOTTOM, UP }

    class Program
    {
        private static Dictionary<Vector2, int> heigths = new Dictionary<Vector2, int>();

        private static List<string> FillList(List<string> input, string path = "real")
        {
            string inputPath = path == "real" ? @"..\..\input.txt" : @"..\..\testinput.txt";

            foreach (string line in File.ReadLines(inputPath))
            {
                input.Add(line);
            }

            return input;
        }


        static void Main(string[] args)
        {
            List<string> inputs = new List<string>();

            Solve(FillList(inputs, "real"));

            Console.ReadKey();
        }

        private static void Solve2(List<string> input)
        {
            List<int> lowValues = new List<int>();
            int rows = input.Count - 1;
            int columns = input[0].Length - 1;
            int current = -1;
            CreateHeightMap(input);

            for (int row = 0; row <= rows; row++)
            {
                for (int col = 0; col <= columns; col++)
                {
                    
                }
            }

        }

        private static void Solve(List<string> input)
        {
            List<int> lowValues = new List<int>();
            int rows = input.Count - 1;
            int columns = input[0].Length - 1;
            CreateHeightMap(input);

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
                            if (IsItLower(Direction.RIGHT, row, col) && IsItLower(Direction.BOTTOM, row, col))
                            {
                                lowValues.Add(ValueOf(row, col));
                            }
                        }
                        else
                        {
                            // top edge
                            // check left, right, bottom
                            if (col != columns)
                            {
                                if (IsItLower(Direction.LEFT, row, col) && IsItLower(Direction.RIGHT, row, col) && IsItLower(Direction.BOTTOM, row, col))
                                {
                                    lowValues.Add(ValueOf(row, col));
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

                            if (IsItLower(Direction.UP, row, col) && IsItLower(Direction.RIGHT, row, col))
                            {
                                lowValues.Add(ValueOf(row, col));
                            }
                        }
                        else
                        {
                            // left edge
                            // check up, right, bottom

                            if (row != 0)
                            {
                                if (IsItLower(Direction.UP, row, col) && IsItLower(Direction.RIGHT, row, col) && IsItLower(Direction.BOTTOM, row, col))
                                {
                                    lowValues.Add(ValueOf(row, col));
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

                            if (IsItLower(Direction.LEFT, row, col) && IsItLower(Direction.BOTTOM, row, col))
                            {
                                lowValues.Add(ValueOf(row, col));
                            }
                        }
                        else
                        {
                            // right edge
                            // check up, left, bottom

                            if (IsItLower(Direction.UP, row, col) && IsItLower(Direction.LEFT, row, col) && IsItLower(Direction.BOTTOM, row, col))
                            {
                                lowValues.Add(ValueOf(row, col));
                            }
                        }
                    }

                    if (row == rows)
                    {
                        if (row == rows && col == columns)
                        {
                            // bottom right
                            // check up && left

                            if (IsItLower(Direction.UP, row, col) && IsItLower(Direction.LEFT, row, col))
                            {
                                lowValues.Add(ValueOf(row, col));
                            }
                        }
                        else
                        {
                            // bottom edge
                            // check up, left, right
                            if (IsItLower(Direction.UP, row, col) && IsItLower(Direction.LEFT, row, col) && IsItLower(Direction.RIGHT, row, col))
                            {
                                lowValues.Add(ValueOf(row, col));
                            }
                        }
                    }

                    if (row != 0 && row != rows && col != 0 && col != columns)
                    {
                        if (IsItLower(Direction.RIGHT, row, col) && IsItLower(Direction.LEFT, row, col) && IsItLower(Direction.UP, row, col) && IsItLower(Direction.BOTTOM, row, col))
                        {
                            lowValues.Add(ValueOf(row, col));
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

        private static int GetValue(Direction direction, int row, int col)
        {
            int value = 0;

            switch (direction)
            {
                case Direction.RIGHT:
                    value = ValueOf(row, col + 1);
                    break;
                case Direction.LEFT:
                    value = ValueOf(row, col - 1);
                    break;
                case Direction.BOTTOM:
                    value = ValueOf(row + 1, col);
                    break;
                case Direction.UP:
                    value = ValueOf(row - 1, col);
                    break;
                default:
                    break;
            }

            return value;
        }

        private static bool IsItLower(Direction direction, int row, int col)
        {
            switch (direction)
            {
                case Direction.RIGHT:
                    return ValueOf(row, col) < ValueOf(row, col + 1);
                    break;
                case Direction.LEFT:
                    return ValueOf(row, col) < ValueOf(row, col - 1);
                    break;
                case Direction.BOTTOM:
                    return ValueOf(row, col) < ValueOf(row + 1, col);
                    break;
                case Direction.UP:
                    return ValueOf(row, col) < ValueOf(row - 1, col);
                    break;
                default:
                    return false;
                    break;
            }
        }

        private static void CreateHeightMap(List<string> input)
        {
            for (int row = 0; row < input.Count; row++)
            {
                for (int col = 0; col < input[0].Length; col++)
                {
                    var value = Convert.ToInt32(input[row][col].ToString());
                    heigths.Add(new Vector2(row, col), value);
                }
            }
        }

        private static int ValueOf(int row, int col)
        {
            return heigths[new Vector2(row, col)];
        }
    }
}