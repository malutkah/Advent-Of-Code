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
        private static List<string> FillList(List<string> input, string path = "real")
        {
            string inputPath = path == "real" ? @"../../input.txt" : @"../../testinput.txt";

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

        private static void Solve(List<string> input)
        {
            int validPasswordAmound = 0;

            for (int i = 0; i < input.Count; i++)
            {
                bool isPasswordValid = false;

                string[] splitted = input[i].Split(' ');

                // get numbers (e.g. 12-3)
                string[] letterAppear = splitted[0].Split('-');

                int letterFirstPosition = int.Parse(letterAppear[0]);
                int letterLastPosition = int.Parse(letterAppear[1]);

                // get the letter that must be in the password
                char letterMustHave = splitted[1][0];

                string password = splitted[2];

                // check if password is correct

                if ((password[letterFirstPosition - 1] == letterMustHave && password[letterLastPosition - 1] != letterMustHave) || (password[letterFirstPosition - 1] != letterMustHave && password[letterLastPosition - 1] == letterMustHave))
                {
                    isPasswordValid = true;
                }

                validPasswordAmound = isPasswordValid ? validPasswordAmound += 1 : validPasswordAmound;

                Console.WriteLine($"{letterFirstPosition}-{letterLastPosition} {letterMustHave}: {password} => {isPasswordValid}");
            }

            Console.WriteLine($"Amount of valid Passwords: {validPasswordAmound}");
        }
    }
}
