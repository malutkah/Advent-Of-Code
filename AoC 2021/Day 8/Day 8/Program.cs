using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8
{
    class Program
    {
        private static List<string> inputs = new List<string>();
        private static List<string> testinputs = new List<string>();
        private static List<string> digitsString = new List<string>();
        private static Dictionary<string, int> codes = new Dictionary<string, int>();

        #region digits
        private static int digit_0 = 0;
        private static int digit_1 = 0;
        private static int digit_2 = 0;
        private static int digit_3 = 0;
        private static int digit_4 = 0;
        private static int digit_5 = 0;
        private static int digit_6 = 0;
        private static int digit_7 = 0;
        private static int digit_8 = 0;
        private static int digit_9 = 0;
        #endregion

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
            List<int> outputValues = new List<int>();
            List<string> decodes = new List<string>();
            StringBuilder codeBuilder = new StringBuilder();
            string[] decoder = new string[58];
            string[] outputs = new string[58];
            var final = 0;

            // get strings after '|'
            foreach (string input in inputs)
            {
                string[] splitLine = input.Split('|');
                decoder = splitLine[0].Split(' ').Where(k => k != "").ToArray();
                outputs = splitLine[1].Split(' ').Where(k => k != "").ToArray();

                var one = decoder.Single(n => n.Length == 2);
                var four = decoder.Single(n => n.Length == 4);
                var seven = decoder.Single(n => n.Length == 3);
                var eight = decoder.Single(n => n.Length == 7);

                #region nine, six and zero

                var nine = decoder.Single(n => n.Length == 6 && n.Except(seven).Except(four).Count() == 1);

                var six = decoder.Single(s => s.Length == 6 && s != nine && one.Except(s).Count() == 1);

                var zero = decoder.Single(z => z.Length == 6 && z != six && z != nine);

                #endregion

                // die restlichen segment codes
                var alpha = eight.Except(nine).Single();

                var beta = eight.Except(six).Single();

                var gamma = one.Except(new[] { beta }).Single();

                #region two, three and five

                var two = decoder.Single(t => t.Length == 5 && t.Contains(beta) && !t.Contains(gamma));

                var five = decoder.Single(f => f.Length == 5 && f != two && !f.Contains(beta) && !f.Contains(alpha));

                var three = decoder.Single(f => f.Length == 5 && f != two && f != five);

                #endregion

                var numbers = new[] { zero, one, two, three, four, five, six, seven, eight, nine, };

                codes.Add(zero, 0);
                codes.Add(one, 1);
                codes.Add(two, 2);
                codes.Add(three, 3);
                codes.Add(four, 4);
                codes.Add(five, 5);
                codes.Add(six, 6);
                codes.Add(seven, 7);
                codes.Add(eight, 8);
                codes.Add(nine, 9);

                // for each letter in outputs
                // check if numbers contain the same letter, despite the order

                int yes = 0;
                for (int i = 0; i < outputs.Length; i++)
                {
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        if (numbers[j].Length == outputs[i].Length)
                        {
                            yes = 0;
                            for (int n = 0; n < numbers[j].Length; n++)
                            {
                                if (yes == numbers[j].Length)
                                {
                                    break;
                                }

                                for (int k = 0; k < outputs[i].Length; k++)
                                {
                                    if (numbers[j][n] == outputs[i][k])
                                    {
                                        yes++;
                                        break;
                                    }
                                }

                            }

                            if (yes == numbers[j].Length)
                            {
                                var num = codes.First(x => x.Key == numbers[j]).Value;

                                codeBuilder.Append(num.ToString());

                                yes = 0;
                                break;
                            }

                        }
                    }

                }

                outputValues.Add(Convert.ToInt32(codeBuilder.ToString()));
                codeBuilder.Clear();
                codes.Clear();
            }

            for (int i = 0; i < outputValues.Count; i++)
            {
                final += outputValues[i];
            }

            Console.WriteLine($"Final score: {final}");

        }

    }
}
