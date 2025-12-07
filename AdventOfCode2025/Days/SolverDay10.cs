using AdventOfCode2025.Utilities;

namespace AdventOfCode2025.Days
{
    internal class SolverDay10 : Solver
    {
        public SolverDay10(string inputFile = "TestInput.txt", bool verbose = true)
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
