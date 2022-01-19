using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2
{
    class Program
    {
        private static void FillList(List<string> input, string path = "real")
        {
            string inputPath = path == "real" ? @"../../input.txt" : @"../../testinput.txt";

            foreach (string line in File.ReadLines(inputPath))
            {
                input.Add(line);
            }
        }

        static void Main(string[] args)
        {
            List<string> inputs = new List<string>();
            List<string> testinputs = new List<string>();
            FillList(inputs);
            FillList(testinputs, "test");

            Solve(inputs);

            Console.ReadKey();
        }

        private static void Solve(List<string> input)
        {
            int validPasswordAmound = 0;

            for (int i = 0; i < input.Count; i++)
            {
                bool isPasswordValid = false;

                string[] splitted = input[i].Split(' ');

                // get numbers (e.g. 12-3)
                string[] letterAppear = splitted[0].Split('-');

                int letterAtLeast = int.Parse(letterAppear[0]);
                int letterAtMost = int.Parse(letterAppear[1]);

                // get the letter that must be in the password
                char letterMustHave = splitted[1][0];

                string password = splitted[2];

                // check if password is correct
                int howManyLettersInPassword = 0;

                foreach (var letter in password)
                {
                    if (letterMustHave == letter)
                    {
                        howManyLettersInPassword++;
                    }
                }

                isPasswordValid = (howManyLettersInPassword <= letterAtMost) && (howManyLettersInPassword >= letterAtLeast) ? true : false;

                validPasswordAmound = isPasswordValid ? validPasswordAmound += 1 : validPasswordAmound;

                Console.WriteLine($"{letterAtLeast}-{letterAtMost} {letterMustHave}: {password} => {isPasswordValid}");

                isPasswordValid = false;
            }

            Console.WriteLine($"Amount of valid Passwords: {validPasswordAmound}");
        }
    }
}
