using AdventOfCode2025.Days.Day1;
using AdventOfCode2025.Utilities;


namespace AdventOfCode2025.Days
{
    internal class SolverDay1 : Solver
    {
        private List<string> _values = new List<string>();
        public SolverDay1(bool verbose = false)
        {
            _verbose = verbose;
            ReadInputFile();
        }
        public override void ReadInputFile()
        {
           FileReader fileReader = new FileReader("TestInput.txt");
            //FileReader fileReader = new FileReader("InputDay1.txt");
            _values = fileReader.ReadAndSplitInto2DList();
            fileReader.Close();
        }

        public override long GetSolution1Star()
        {
            long solution = 0;
            Dial dial = new Dial(50, true);
            foreach (string line in _values)
            {
                if (line[0] == 'R')
                {
                    dial.Turn(Dial.Direction.Right, int.Parse(line[1..]));
                }
                else
                {
                    dial.Turn(Dial.Direction.Left, int.Parse(line[1..]));
                }
                if (dial.Value == 0)
                    solution++;
            }
            return solution;
        }
        public override long GetSolution2Star()
        {
            long solution = 0;
            Dial dial = new Dial(50, true);
            foreach (string line in _values)
            {
                if (line[0] == 'R')
                {
                    solution += dial.Turn(Dial.Direction.Right, int.Parse(line[1..]));
                }
                else
                {
                    solution += dial.Turn(Dial.Direction.Left, int.Parse(line[1..]));
                }
            }
            return solution;
        }
    }

}
