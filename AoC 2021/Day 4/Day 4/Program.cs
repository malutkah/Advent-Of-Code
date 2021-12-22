using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day_4
{
    class Program
    {
        private static List<string> inputs = new List<string>();
        private static int marked = -1;
        private static int start = 2;
        private static char[] charSeparators = new char[] { ' ' };
        private static int boardCount = 1;

        static void Main(string[] args)
        {
            FillLists();
            Part2();

            Console.ReadKey();
        }

        private static void FillLists()
        {
            string inputPath = @"..\..\input\input.txt";

            foreach (string line in File.ReadLines(inputPath))
            {
                inputs.Add(line);
            }
        }


        private static void Part1()
        {
            // get number
            int[] draw = Array.ConvertAll(inputs[0].Split(','), draws => int.Parse(draws));

            List<int[,]> allBoards = new List<int[,]>();
            List<int[,]> wonBoards = new List<int[,]>();
            bool won = false;
            int lastDrawnNumber = 0, finalScore = 0, round = 0;

            CreateBoards(allBoards);
            CreateBoards(wonBoards);

            int[] markedNumberInBoard = new int[allBoards.Count];
            int[] boardsWon = new int[allBoards.Count];
            int wonBoard = -1;
            int wins = 0;
            int unmarkedSum = 0;

            // find equal numbers in board and mark them
            for (int i = 0; i < draw.Length; i++)
            {
                if (wins == allBoards.Count)
                {
                    lastDrawnNumber = draw[i - 1];
                    break;
                }

                for (int b = 0; b < allBoards.Count; b++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            if (allBoards[b][x, y] == draw[i])
                            {
                                allBoards[b][x, y] = marked;
                                markedNumberInBoard[b]++; // count marked numbers in board
                            }
                        }
                    }

                    if (!markedNumberInBoard.Contains(wonBoard))
                    {
                        // board has at least 5 marked numbers
                        if (markedNumberInBoard[b] >= 5)
                        {
                            // now check if the marked numbers are in the same row or column

                            for (int c = 0; c < 5; c++)
                            {
                                // check row
                                if (allBoards[b][c, 0] == -1 && allBoards[b][c, 1] == -1 && allBoards[b][c, 2] == -1 && allBoards[b][c, 3] == -1 && allBoards[b][c, 4] == -1)
                                {
                                    wonBoard = b;
                                    //allBoards.RemoveAt(wonBoard);
                                    wins++;
                                }

                                // check column
                                if (allBoards[b][0, c] == -1 && allBoards[b][1, c] == -1 && allBoards[b][2, c] == -1 && allBoards[b][3, c] == -1 && allBoards[b][4, c] == -1)
                                {
                                    wonBoard = b;
                                    //allBoards.RemoveAt(wonBoard);
                                    wins++;
                                }
                            }

                        }
                    }
                }
            }

            // calculate the score
            // sum of all unmarked numbers
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (allBoards[wonBoard][x, y] != marked)
                    {
                        unmarkedSum += allBoards[wonBoard][x, y];
                    }
                }
            }
            // then multiply that sum by the number that was just called
            finalScore = unmarkedSum * lastDrawnNumber;

            Console.WriteLine($"Board {wonBoard} has won! - Final Score: {finalScore}");
        }

        private static void Part2()
        {
            int[] draw = Array.ConvertAll(inputs[0].Split(','), draws => int.Parse(draws));

            List<Board> boards = new List<Board>();
            int lines = 0;
            Board board = new Board();
            Board wonBoard = new Board();

            // create boards
            for (int i = 2; i < inputs.Count; i++)
            {
                if (inputs[i].Length != 0)
                {
                    string[] line = inputs[i].Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < line.Length; j++)
                    {
                        board.values[lines, j % 5] = Int32.Parse(line[j]);
                    }

                    lines++;

                    if (lines == 5)
                    {
                        boards.Add(board);
                        board = new Board();
                        lines = 0;
                    }
                }
            }

            int lastDraw = -1;
            int lastBoard = -1;
            for (int i = 0; i < draw.Length; i++)
            {
                if (boards.Where(b => b.hasWon == false).Count() == 0)
                {
                    lastDraw = draw[i - 1];
                    break;
                }

                for (int b = 0; b < boards.Count; b++)
                {
                    if (!boards[b].hasWon)
                    {
                        for (int x = 0; x < 5; x++)
                        {
                            for (int y = 0; y < 5; y++)
                            {
                                if (boards[b].values[x, y] == draw[i])
                                {
                                    boards[b].AddMarker(x, y);
                                }
                            }
                        }
                        if (boards[b].markedNums >= 5)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if ((boards[b].markers[0, j] == -1 && boards[b].markers[1, j] == -1 && boards[b].markers[2, j] == -1 && boards[b].markers[3, j] == -1 && boards[b].markers[4, j] == -1))
                                {
                                    boards[b].hasWon = true;
                                    lastBoard = b;
                                }
                                if (boards[b].markers[j, 0] == -1 && boards[b].markers[j, 1] == -1 && boards[b].markers[j, 2] == -1 && boards[b].markers[j, 3] == -1 && boards[b].markers[j, 4] == -1)
                                {
                                    boards[b].hasWon = true;
                                    lastBoard = b;
                                }
                            }
                        }
                    }

                }
            }

            int unmarkedSum = 0;

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (boards[lastBoard].markers[x, y] != marked)
                    {
                        unmarkedSum += boards[lastBoard].values[x, y];
                    }
                }
            }
            Console.WriteLine($"Final Score:{unmarkedSum * lastDraw}");
        }

        private static void CreateBoards(List<int[,]> allBoards)
        {
            int[,] currentBoard = new int[5, 5];
            int lines = 0;

            for (int i = 2; i < inputs.Count; i++)
            {
                if (inputs[i].Length != 0)
                {
                    // get every number from each line without spaces
                    string[] line = inputs[i].Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < line.Length; j++)
                    {
                        // add each number to current Board
                        currentBoard[lines, j % 5] = Convert.ToInt32(line[j]);
                    }

                    lines++;

                    if (lines == 5)
                    {
                        allBoards.Add(currentBoard);
                        currentBoard = new int[5, 5]; // reset current board
                        lines = 0; // restart
                    }
                }
            }
        }
    }

    internal class Board
    {
        public int[,] values { get; set; } = new int[5, 5];
        public int[,] markers { get; set; } = new int[5, 5];
        public int markedNums = 0;
        public bool hasWon { get; set; }

        public void AddMarker(int x, int y)
        {
            markers[x, y] = -1;
            markedNums++;
        }
    }
}
