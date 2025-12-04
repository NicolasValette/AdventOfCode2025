using AdventOfCode2025.Utilities;
using System.Text;

namespace AdventOfCode2025.Days
{
    internal class SolverDay4 : Solver
    {
        private char[][] _paperGrid;
       
        public SolverDay4(string inputFile = "TestInput.txt", bool verbose = true)
        {
            _paperGrid = new char[1][];
            _verbose = verbose;
            ReadInputFile(inputFile);
        }
        private void ReadInputFile(string inputFile)
        {
            FileReader fileReader = new FileReader(inputFile); 
            _paperGrid = fileReader.ReadToEndAndSplitInto2DCharArray();
            fileReader.Close();
        }

        private void PrintGrid()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < _paperGrid.Length; i++)
            {
                for (int j = 0; j < _paperGrid[i].Length; j++)
                {
                    stringBuilder.Append(_paperGrid[i][j]);
                }
                stringBuilder.Append('\n');
            }
            Console.Write(stringBuilder.ToString());
            Console.WriteLine();
        }
        private int GetNumberOfAdjacentRolls(int i, int j)
        {
            int neighbour = 0;

            //NW
            if ((i-1 >= 0 && j-1 >= 0) && (_paperGrid[i - 1][j-1]!= '.'))
            {
                neighbour++;
            }
            //N
            if ((i - 1 >= 0) && (_paperGrid[i - 1][j] != '.'))
            {
                neighbour++;
            }
            //NE
            if ((i - 1 >= 0 && j + 1 < _paperGrid[i-1].Length) && (_paperGrid[i - 1][j + 1] != '.'))
            {
                neighbour++;
            }
            //W
            if ((j - 1 >= 0) && (_paperGrid[i][j - 1] != '.'))
            {
                neighbour++;
            }
            //E
            if ((j + 1 < _paperGrid[i].Length) && (_paperGrid[i][j + 1] != '.'))
            {
                neighbour++;
            }
            //SW
            if ((i + 1 < _paperGrid.Length && j - 1 >= 0) && (_paperGrid[i + 1][j - 1] != '.'))
            {
                neighbour++;
            }
            //S
            if ((i + 1 < _paperGrid.Length) && (_paperGrid[i + 1][j] != '.'))
            {
                neighbour++;
            }
            //SE
            if ((i + 1 < _paperGrid.Length && j + 1 < _paperGrid[i].Length) && (_paperGrid[i + 1][j + 1] != '.'))
            {
                neighbour++;
            }
            return neighbour;
        }

        public override long GetSolution1Star()
        {
            long solution = 0;
            if (_verbose)
                PrintGrid();
            for (int i = 0; i<_paperGrid.Length;i++)
            {
                for (int j = 0; j < _paperGrid[i].Length;j++)
                {
                    if (_paperGrid[i][j] != '.' && GetNumberOfAdjacentRolls(i,j) < 4)
                    {
                        solution++;
                    }
                }
            }
            if (_verbose)
                PrintGrid();
            return solution;
        }

        private void RemovePaperRolls()
        {
            for (int i = 0; i < _paperGrid.Length; i++)
            {
                for (int j = 0; j < _paperGrid[i].Length; j++)
                {
                    if (_paperGrid[i][j] == 'X')
                    {
                        _paperGrid[i][j] = '.';
                    }
                }
            }
        }
        public override long GetSolution2Star()
        {
            long solution = 0;
            if (_verbose)
                PrintGrid();
            long numberOfRemovedRolls = -1;
            while (numberOfRemovedRolls != 0)
            {
                numberOfRemovedRolls = 0;
                for (int i = 0; i < _paperGrid.Length; i++)
                {
                    for (int j = 0; j < _paperGrid[i].Length; j++)
                    {
                        if (_paperGrid[i][j] != '.' && GetNumberOfAdjacentRolls(i, j) < 4)
                        {
                            numberOfRemovedRolls++;
                            _paperGrid[i][j] = 'X';
                        }
                    }
                }
                if (numberOfRemovedRolls != 0)
                {
                    solution += numberOfRemovedRolls;
                    RemovePaperRolls();
                }
                else
                    break;
            }
            if (_verbose)
                PrintGrid();
            return solution;
        }
    }
}
