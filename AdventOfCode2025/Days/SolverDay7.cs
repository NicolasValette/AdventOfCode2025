using AdventOfCode2025.Utilities;

namespace AdventOfCode2025.Days
{
    internal class SolverDay7 : Solver
    {
        private char[][] _tachyons;
        public SolverDay7(string inputFile = "TestInput.txt", bool verbose = true)
        {
            _tachyons = new char[1][];
            _verbose = verbose;
            ReadInputFile(inputFile);
        }
        private void ReadInputFile(string inputFile)
        {
            FileReader fileReader = new FileReader(inputFile);
            _tachyons = fileReader.ReadToEndAndSplitInto2DCharArray();
            fileReader.Close();
        }

        public override long GetSolution1Star()
        {
            return base.GetSolution1Star();
        }
    }
}
