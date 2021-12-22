using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
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
            List<string> testInputs = new List<string>();
            FillList(inputs);
            FillList(testInputs, "test");

            Solve(testInputs);

            Console.ReadKey();
        }

        private static void Solve(List<string> inputs)
        {
            string[] openingChunks = new string[] { "(", "[", "{", "<" };
            string[] closingChunks = new string[] { ")", "]", "}", ">" };

            Dictionary<string, int> illegalChar = new Dictionary<string, int>
            {
                {")", 3 }
                ,{"]", 57 }
                ,{"}", 1197 }
                ,{">", 25137 }
            };

            // find currupted line
            // currupted line: chunk closes with the wrong character

            // get the opening chunk and then look if that opening chunk has a closing chunk     -

            char startChunk = '.';
            char endChunk = '.';

            for (int i = 0; i < inputs.Count; i++)
            {
                for (int c = 0; c < inputs[i].Length; c++)
                {
                    startChunk = inputs[i][c];
                    endChunk = inputs[i][inputs[i].Length];

                    //check if the start chunk matches the endchunk

                    if (startChunk == '(' && endChunk == ')')
                    {
                        // legal
                    }
                    else if (startChunk == '(' && endChunk != ')')
                    {
                        break;                        
                    }
                }

                foreach (var chunk in inputs[i])
                {
                }
            }
        }
    }
}
