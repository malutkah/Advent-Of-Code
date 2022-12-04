using System;
using System.Collections.Generic;
using System.IO;

namespace Day2
{
    class Program
    {
        private static List<string> FillList(List<string> input, bool isTest = true)
        {
            string inputPath = isTest ? @"test.txt" : @"input.txt";

            foreach (string line in File.ReadLines(inputPath))
            {
                input.Add(line);
            }

            return input;
        }

        static void Main(string[] args)
        {
            List<string> inputs = new List<string>();

            Solve(FillList(inputs, false));

            Console.ReadKey();
        }

        private static void Solve(List<string> list)
        {
            int rockScore = 1;
            int paperScore = 2;
            int scissScore = 3;
            int scoreTotal = 0;
            int won = 6;
            int lost = 0;
            int draw = 3;

            for (int i = 0; i < list.Count; i++)
            {
                string[] round = list[i].Split(" ");
                int enemy = round[0] == "A" ? rockScore : round[0] == "B" ? paperScore : scissScore;
                // for part 1: int score = round[1] == "X" ? rockScore : round[1] == "Y" ? paperScore : scissScore;
                string state = round[1] == "X" ? "lose" : round[1] == "Y" ? "draw" : "win";

                int score = state switch
                {
                    "lose" => enemy == rockScore ? scissScore : enemy == paperScore ? rockScore : paperScore,
                    
                    "draw" => enemy,
                    
                    "win" => enemy == rockScore ? paperScore : enemy == scissScore ? rockScore : scissScore,
                };

                score += score switch
                {
                    // rock
                    1 => enemy == rockScore ? draw : enemy == paperScore ? lost : won,
                    // paper
                    2 => enemy == rockScore ? won : enemy == paperScore ? draw : lost,
                    // scissors
                    3 => enemy == rockScore ? lost : enemy == paperScore ? won : draw,
                };

                Console.WriteLine($"my score in round {i+1}: {score}");

                scoreTotal += score;
            }

            Console.WriteLine($"my total score is: {scoreTotal}");
        }
    }
}
