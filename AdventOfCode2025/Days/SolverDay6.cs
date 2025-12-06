using AdventOfCode2025.Days.Day6;
using AdventOfCode2025.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2025.Days
{
    internal class SolverDay6 : Solver
    {
        List<Problem> _problems;
        List<Problem> _problems2;
        public SolverDay6(string inputFile = "TestInput.txt", bool verbose = true)
        {
            _verbose = verbose;
            _problems = new List<Problem>();
            _problems2 = new List<Problem>();
            ReadInputFile(inputFile);
        }
        private void ReadInputFile(string inputFile)
        {
            bool isInit = false;
            FileReader fileReader = new FileReader(inputFile);
            List<string> lines = fileReader.ReadAndSplitInto2DList();
            foreach (string line in lines)
            {
                var splittedLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
               
                for (int i = 0; i < splittedLine.Length; i++)
                {
                    if (!isInit)
                        _problems.Add(new Problem());

                    if (long.TryParse(splittedLine[i], out long number))
                    {
                        _problems[i].AddNumber(number);
                    }
                    else
                    {
                        if (splittedLine[i] =="+")
                        {
                            _problems[i].SetOperation(Operation.Addition);
                        }
                        else if (splittedLine[i] == "-")
                        {
                            _problems[i].SetOperation(Operation.Soustraction);
                        }
                        else if (splittedLine[i] == "*")
                        {
                            _problems[i].SetOperation(Operation.Multiplication);
                        }
                        else if (splittedLine[i] == "/")
                        {
                            _problems[i].SetOperation(Operation.Division);
                        }
                    }
                }
                isInit = true;
            }
            fileReader.Close();

            //Star 2
            FileReader fileReader2 = new FileReader(inputFile);
            char[][] array = fileReader2.ReadToEndAndSplitInto2DCharArray(FileReaderOptions.WithEmptySpace);


            List<char> s = array[array.Length - 1].ToList();
            s.RemoveAll(x=> x==' ');
            
            for (int i = 0; i < s.Count; i++)
            {
                Problem pb = new Problem();
                pb.SetOperation(s[i]);
                _problems2.Add(pb);
            }
            int startingColInd = 0;
            int endColInd = startingColInd + 1;
            int problemId = 0;
            while (startingColInd < array[array.Length - 1].Length)
            {
                while (endColInd < array[array.Length - 1].Length && array[array.Length - 1][endColInd] == ' ')
                {
                    endColInd++;
                }


                
                for (int i = startingColInd; i < endColInd; i++)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    for (int j = 0; j < array.Length - 1; j++)
                    {
                        stringBuilder.Append(array[j][i]);
                    }
                    if (!string.IsNullOrWhiteSpace(stringBuilder.ToString()))
                        _problems2[problemId].AddNumber(long.Parse(stringBuilder.ToString()));
                }
                startingColInd = endColInd;
                endColInd = startingColInd + 1;
                problemId++;
            }
            fileReader2.Close();
        }

        public override long GetSolution1Star()
        {
            long solution = 0;
            foreach (Problem prob in _problems)
            {
                long problemSolution = prob.Solve();
                if (_verbose)
                    Console.WriteLine($"{prob.ToString()} = {problemSolution}");
                solution += problemSolution;
            }
            return solution;
        }
        public override long GetSolution2Star()
        {
            long solution = 0;
            foreach (Problem prob in _problems2)
            {
                long problemSolution = prob.Solve();
                if (_verbose)
                    Console.WriteLine($"{prob.ToString()} = {problemSolution}");
                solution += problemSolution;
            }
            return solution;
        }
    }
}
