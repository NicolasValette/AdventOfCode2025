using AdventOfCode2025.Utilities;
using System.Text;

namespace AdventOfCode2025.Days
{
    internal class SolverDay7 : Solver
    {
        private char[][] _tachyons;
        private char[][] _tachyons2;
        public SolverDay7(string inputFile = "TestInput.txt", bool verbose = true)
        {
            _tachyons = new char[1][];
            _tachyons2 = new char[1][];
            _verbose = verbose;
            ReadInputFile(inputFile);
        }
        private void ReadInputFile(string inputFile)
        {
            _tachyons = new char[1][];
            FileReader fileReader = new FileReader(inputFile);
            _tachyons = fileReader.ReadToEndAndSplitInto2DCharArray();
            fileReader.Close();
            FileReader fileReader2 = new FileReader(inputFile);
            _tachyons2 = fileReader2.ReadToEndAndSplitInto2DCharArray();
            fileReader2.Close();
        }

        private void PrintGrid()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < _tachyons.Length; i++)
            {
                for (int j = 0; j < _tachyons[i].Length; j++)
                {
                    stringBuilder.Append(_tachyons[i][j]);
                }
                stringBuilder.Append('\n');
            }
            Console.Write(stringBuilder.ToString());
            Console.WriteLine();
        }

        public override long GetSolution1Star()
        {
            (int i, int j) position = (0,0) ;
            int solution = 0;
            for (int j = 0; j < _tachyons[0].Length; j++)
            {
                if (_tachyons[0][j] == 'S')
                {
                    position = (0, j);
                    break;
                }
            }
            _tachyons[position.i + 1][position.j] = '|';
            position.i++;
            for (int i = position.i; i +1< _tachyons.Length; i++)
            {
                for (int j=0;j< _tachyons[i].Length;j++)
                {
                    if (_tachyons[i][j] == '|')
                    {
                        if (_tachyons[i + 1][j] == '.')
                            _tachyons[i + 1][j] = '|';
                        else if (_tachyons[i + 1][j] == '^')
                        {
                            solution++;
                            _tachyons[i + 1][j - 1] = '|';
                            _tachyons[i + 1][j + 1] = '|';
                        }
                    }
                }
            }
            if (_verbose)
                PrintGrid();
            return solution;
        }
        public override long GetSolution2Star()
        {
            long[] count = new long[_tachyons2[0].Length];
            (int i, int j) position = (0, 0);
            int solution = 0;
            for (int j = 0; j < _tachyons2[0].Length; j++)
            {
                if (_tachyons2[0][j] == 'S')
                {
                    count[j] = 1;
                    position = (0, j);
                    break;
                }
            }
            //_tachyons2[position.i + 1][position.j] = '|';
            position.i++;

            foreach (var line in _tachyons2)
            {
                long[] oldCount = new long[count.Length];
                Array.Copy(count, oldCount, count.Length);
                count = new long[line.Length];

                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'S')
                    {
                        count[j] = 1;
                    }
                    else if (oldCount[j] != 0)
                    {
                        if (line[j] == '.')
                        {
                            //line[j] = '|';
                            count[j] += oldCount[j];
                        }
                        else if (line[j] == '^')
                        {
                            //line[j - 1] = '|';
                            //line[j + 1] = '|';
                            count[j-1] += oldCount[j];
                            count[j+1] += oldCount[j];
                        }
                    }
                }
            }
            Console.WriteLine(string.Join("-", count));
            return count.Sum();
        }
    }
}
