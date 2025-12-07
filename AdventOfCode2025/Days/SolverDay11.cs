using AdventOfCode2025.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2025.Days
{
    internal class SolverDay11 : Solver
    {
        public SolverDay11(string inputFile = "TestInput.txt", bool verbose = true)
        {
            _verbose = verbose;
            ReadInputFile(inputFile);
        }
        private void ReadInputFile(string inputFile)
        {
            FileReader fileReader = new FileReader(inputFile);
            //_paperGrid = fileReader.ReadToEndAndSplitInto2DCharArray();
            fileReader.Close();
        }
    }
}
