using AdventOfCode2025.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using Toolbox.Datas;

namespace AdventOfCode2025.Days
{
    internal class SolverDay11 : Solver
    {
        private Graph<string> _graph;
        public SolverDay11(string inputFile = "TestInput.txt", bool verbose = true)
        {
            _graph = new Graph<string>();
            _verbose = verbose;
            ReadInputFile(inputFile);
        }
        private void ReadInputFile(string inputFile)
        {
            FileReader fileReader = new FileReader(inputFile);

            while (!fileReader.EndOfStream)
            {
                string line = fileReader.Read();
                var startingNode = line.Split(':').Select(x => x.Trim()).ToList()[0];
                var endingNodes = line.Split(':').Select(x => x.Trim()).ToList()[1].Split(' ').Select(x => x.Trim()).ToList();
                foreach (var item in endingNodes)
                {
                    _graph.AddEdge(startingNode, item);
                }
            }
            _graph.InitStartingNode("you");
            _graph.AddFinalNode("out");
            if (_verbose)
                Console.WriteLine(_graph.ToString());
            fileReader.Close();
        }

        public override long GetSolution1Star()
        {
            return -1;
            List<HashSet<string>> paths = new List<HashSet<string>>();
             _graph.FindAllPath(ref  paths);
            if (_verbose)
                Console.WriteLine(_graph.BFSFromStart());
            return paths.Count;
        }
        public override long GetSolution2Star()
        {
            _graph.InitStartingNode("svr");
            List<HashSet<string>> paths = new List<HashSet<string>>();
            _graph.FindAllPath(ref paths);
            long solution = 0;
            foreach (var item in paths)
            {
                if (item.Contains("dac") && item.Contains("fft"))
                {
                    solution++;
                }
            }
            return solution;
        }
    }
}
