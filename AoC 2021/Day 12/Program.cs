using System;
using System.Collections.Generic;
using System.IO;

namespace Day_12
{
    class Program
    {

        private static void FillList(List<string> input, string path = "real")
        {
            string inputPath = path == "real" ? @"input.txt" : @"testinput.txt";

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
        }

        private static void Solve(List<string> inputs)
        {
            // rules:
            // start in a cave named "start" and the destination is the cave named "end"
            // an entry like "b-d" means that the cave "b" is connected to the cave "d"
            // the goal is to find the number of distinct paths that start at "start" and end at "end"
            // there are two types of caves:
            // big caves (written in uppercase, like "A")
            // small caves (written in lowercase, like "b")
            // visit small caves at most once and visit big caves any number of times

            // a map looks like this:
            /*  
                start-A
                start-b
                A-c
                A-b
                b-d
                A-end
                b-end
            */

            // the map is represented as a graph, where each node is a cave and each edge is a connection between two caves
            // the graph is represented as a dictionary, where the key is the cave name and the value is a list of caves that are connected to it

            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

            // fill the graph with the testinput
            foreach (string line in inputs)
            {
                string[] parts = line.Split('-');
                string cave1 = parts[0];
                string cave2 = parts[1];

                if (!graph.ContainsKey(cave1))
                {
                    graph.Add(cave1, new List<string>());
                }

                graph[cave1].Add(cave2);
            }
        }
    }
}
