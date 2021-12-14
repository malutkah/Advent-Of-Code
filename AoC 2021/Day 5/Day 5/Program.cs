using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Day_5
{
    class Program
    {
        private static List<string> inputs = new List<string>();
        private static List<string> testInputs = new List<string>();
        private const int left = 1;
        private const int right = 2;

        static void Main(string[] args)
        {
            FillList();
            Part1();

            Console.ReadKey();
        }

        private static void Part1()
        {
            int x1 = 0, y1 = 0;
            int x2 = 0, y2 = 0;

            List<Vector2> coordList1 = new List<Vector2>();
            List<Vector2> coordList2 = new List<Vector2>();

            foreach (string input in inputs)
            {
                string[] splitArrow = input.Split(new string[] { "->" }, StringSplitOptions.None);
                string[] splitCoordinates = splitArrow[0].Split(',');
                string[] splitCoordinates2 = splitArrow[1].Split(',');

                x1 = int.Parse(splitCoordinates[0]);
                y1 = int.Parse(splitCoordinates[1]);
                coordList1.Add(new Vector2(x1, y1));

                x2 = int.Parse(splitCoordinates2[0]);
                y2 = int.Parse(splitCoordinates2[1]);
                coordList2.Add(new Vector2(x2, y2));

                // Console.WriteLine($"{x1},{y1} -> {x2},{y2}");
            }

            var maxX1 = coordList1[0].X;
            var maxY1 = coordList1[0].Y;
            var maxX2 = coordList1[0].X;
            var maxY2 = coordList1[0].Y;
            float maxX = 0, maxY = 0;

            var minX1 = coordList1[0].X;
            var minY1 = coordList1[0].Y;
            var minX2 = coordList1[0].X;
            var minY2 = coordList1[0].Y;
            float minX = 0, minY = 0;

            for (int i = 0; i < coordList1.Count; i++)
            {
                maxX1 = Math.Max(coordList1[i].X, maxX1);
                maxY1 = Math.Max(coordList1[i].Y, maxY1);
                minX1 = Math.Min(coordList1[i].X, minX1);
                minY1 = Math.Min(coordList1[i].Y, minY1);
            }

            for (int i = 0; i < coordList2.Count; i++)
            {
                maxX2 = Math.Max(coordList2[i].X, maxX2);
                maxY2 = Math.Max(coordList2[i].Y, maxY2);
                minX2 = Math.Min(coordList1[i].X, minX2);
                minY2 = Math.Min(coordList1[i].Y, minY2);
            }

            maxX = maxX1 > maxX2 ? maxX1 : maxX2;
            maxY = maxY1 > maxY2 ? maxY1 : maxY2;
            minX = minX1 > minX2 ? minX1 : minX2;
            minY = minY1 > minY2 ? minY1 : minY2;

            var steps = 0f;
            var start = 0f;
            var end = 0f;

            var startX = 0f;
            var startY = 0f;
            var endX = 0f;
            var endY = 0f;
            var stepsX = 0f;
            var stepY = 0f;

            int[,] grid = new int[(int)maxX + 1, (int)maxY + 1]; // change grid to int[,]?            
            int _x = 0;
            int _y = 0;
            int _x2 = 0;
            int _y2 = 0;
            bool isHorizontal = false;
            bool isDiagonal = false;
            int overlapping = 0;
            int overlaps = 0;
            int direction = 0; // 1 - left | 2 - right | 0 - null

            for (int k = (int)minY; k < maxY + 1; k++)
            {
                for (int l = (int)minX; l < maxX + 1; l++)
                {
                    grid[k, l] = 0; // then fill with '0'?
                }
            }

            for (int i = 0; i < inputs.Count; i++)
            {
                if (coordList1[i].Y == coordList2[i].Y)
                {
                    isHorizontal = true;
                    isDiagonal = false;
                    if (coordList1[i].X < coordList2[i].X)
                    {
                        end = coordList2[i].X;
                        start = coordList1[i].X;
                    }
                    else
                    {
                        end = coordList1[i].X;
                        start = coordList2[i].X;
                    }

                    steps = end - start - 1;
                }
                else if (coordList1[i].X == coordList2[i].X)
                {
                    isHorizontal = false;
                    isDiagonal = false;
                    if (coordList1[i].Y < coordList2[i].Y)
                    {
                        end = coordList2[i].Y;
                        start = coordList1[i].Y;
                    }
                    else
                    {
                        end = coordList1[i].Y;
                        start = coordList2[i].Y;
                    }

                    steps = end - start - 1;
                }
                else
                {
                    isDiagonal = true;
                    isHorizontal = false;

                    // top to bottom
                    //5,5 -> 8,2
                    // 5 < 2
                    if (coordList1[i].Y < coordList2[i].Y)
                    {
                        startX = coordList1[i].X;
                        startY = coordList1[i].Y;
                        endX = coordList2[i].X;
                        endY = coordList2[i].Y;
                    }
                    else
                    {
                        startX = coordList2[i].X;
                        startY = coordList2[i].Y;
                        endX = coordList1[i].X;
                        endY = coordList1[i].Y;
                    }
                    Console.WriteLine($"{startX},{startY} -> {endX},{endY}");

                    start = startX;

                    if (startX > endX)
                    {
                        // move left <=
                        // calc steps
                        direction = left;
                        steps = startX - endX;
                    }
                    else
                    {
                        // move right => 
                        direction = right;
                        steps = endX - startX;
                    }
                }

                // set beginning and end point

                _x = (int)coordList1[i].X;
                _y = (int)coordList1[i].Y;
                _x2 = (int)coordList2[i].X;
                _y2 = (int)coordList2[i].Y;

                if (grid[_x, _y] >= 1)
                {
                    grid[_x, _y] += 1;
                }
                else
                {
                    grid[_x, _y] = 1;
                }

                if (grid[_x2, _y2] >= 1)
                {
                    grid[_x2, _y2] += 1;
                }
                else
                {
                    grid[_x2, _y2] = 1;
                }

                var stepBoost = (int)start;

                for (int s = stepBoost; s < steps + stepBoost; s++)
                {
                    // draw line
                    if (isHorizontal) // move horizontal
                    {
                        if (grid[s + 1, _y] >= 1)
                        {
                            grid[s + 1, _y] += 1;
                        }
                        else
                        {
                            grid[s + 1, _y] = 1;
                        }
                    }
                    else if (!isHorizontal && !isDiagonal) // move vertical
                    {
                        if (grid[_x, s + 1] >= 1)
                        {
                            grid[_x, s + 1] += 1;
                        }
                        else
                        {
                            grid[_x, s + 1] = 1;
                        }
                    }
                    else if (isDiagonal)
                    {
                        int tmpX = 0, tmpY = 0;
                        if (direction == left)
                        {
                            // x-1, y+1
                            if (_x > _x2)
                            {
                                _x--;
                                _y++;
                                tmpX = _x;
                                tmpY = _y;
                            }
                            else
                            {
                                _x2--;
                                _y2++;
                                tmpX = _x2;
                                tmpY = _y2;
                            }
                        }
                        else if (direction == right)
                        {
                            // x + 1, y + 1
                            if (_x > _x2)
                            {
                                _x2++;
                                _y2++;
                                tmpX = _x2;
                                tmpY = _y2;
                            }
                            else
                            {
                                _x++;
                                _y++;
                                tmpX = _x;
                                tmpY = _y;
                            }
                        }

                        if (tmpX == endX && tmpY == endY)
                        {
                            continue;
                        }

                        if (grid[tmpX, tmpY] >= 1 && tmpX != endX && tmpY != endY)
                        {
                            grid[tmpX, tmpY] += 1;
                        }
                        else
                        {
                            grid[tmpX, tmpY] = 1;
                        }
                    }
                }

            }

            for (int y = 0; y < maxY + 1; y++)
            {
                for (int x = 0; x < maxX + 1; x++)
                {
                    if (grid[x, y] > 1)
                    {
                        overlapping++;
                    }
                   // Console.Write($" {grid[x, y]} ");
                }
                //Console.WriteLine();
                //Console.WriteLine();
            }

            Console.WriteLine($"overlapping lines: {overlapping}");
        }

        private static void FillList()
        {
            string inputPath = @"../../input.txt";
            string testinputPath = @"../../testinput.txt";

            foreach (string line in File.ReadLines(inputPath))
            {
                inputs.Add(line);
            }

            foreach (string line in File.ReadLines(testinputPath))
            {
                testInputs.Add(line);
            }
        }
    }
}
