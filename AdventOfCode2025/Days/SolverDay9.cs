using AdventOfCode2025.Utilities;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AdventOfCode2025.Days
{
    internal class SolverDay9 : Solver
    {
        private List<Vector2> _coords;
        private Dictionary<(Vector2, Vector2), long> _areas;

        private char[][] _floor;

        private long _iMin = 0;
        private long _jMin =0;
        private long _iMax = 0;
        private long _jMax = 0;
        public SolverDay9(string inputFile = "TestInput.txt", bool verbose = true)
        {
            _coords = new List<Vector2>();
            _areas = new Dictionary<(Vector2, Vector2), long>();

            _verbose = verbose;
            _floor = new char[1][];
            ReadInputFile(inputFile);
        }
        private void ReadInputFile(string inputFile)
        {
            FileReader fileReader = new FileReader(inputFile);
            while (!fileReader.EndOfStream)
            {
                var coord = fileReader.Read().Split(',').Select(x => x.Trim()).ToList();
                Vector2 point = new Vector2(long.Parse(coord[0]), long.Parse(coord[1]));
                _coords.Add(point);
            }

            fileReader.Close();
        }

        private void GetAreasAndPrepareFloor()
        {
            _iMin = (long)_coords[0].X;
            _jMin = (long)_coords[0].Y;
            _iMax = (long)_coords[0].X;
            _jMax = (long)_coords[0].Y;
            for (int i = 0; i < _coords.Count; i++)
            {
                for (int j = i + 1; j < _coords.Count; j++)
                {
                    long dist = Math.Abs(((long)_coords[i].Y - (long)_coords[j].Y) + 1) * Math.Abs(((long)_coords[i].X - (long)_coords[j].X) + 1);
                    _areas.Add((_coords[i], _coords[j]), dist);
                }
                if (_coords[i].X < _iMin)
                    _iMin = (long)_coords[i].X;
                if (_coords[i].Y < _jMin)
                    _jMin = (long)_coords[i].Y;

                if (_coords[i].X > _iMax)
                    _iMax = (long)_coords[i].X;
                if (_coords[i].Y > _jMax)
                    _jMax = (long)_coords[i].Y;

            }
        }
        private char ToggleChar(char current) => current == '.' ? 'O' : '.';

        private void PrintGrid()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < _floor.Length; i++)
            {
                for (int j = 0; j < _floor[i].Length; j++)
                {
                    stringBuilder.Append(_floor[i][j]);
                }
                stringBuilder.Append('\n');
            }
            Console.Write(stringBuilder.ToString());
            Console.WriteLine();
        }
        public override long GetSolution1Star()
        {
            GetAreasAndPrepareFloor();
           // PrintGrid();
            return _areas.OrderByDescending(x => x.Value).First().Value;
        }

        public override long GetSolution2Star()
        {
            
            List<long> candidateList = [];

            for(int i = 2; i + 2 < _coords.Count;i++)
            {
                if (_areas.ContainsKey((_coords[i-2], _coords[i])))
                {
                    candidateList.Add(_areas[(_coords[i - 2], _coords[i])]);
                }
                else if (_areas.ContainsKey((_coords[i - 2], _coords[i])))
                {
                    candidateList.Add(_areas[(_coords[i - 2], _coords[i])]);
                }
            }
            if (_areas.ContainsKey((_coords[0], _coords[_coords.Count-2])))
            {
                candidateList.Add(_areas[(_coords[0], _coords[_coords.Count - 2])]);
            }
            else if (_areas.ContainsKey((_coords[_coords.Count - 2], _coords[0])))
            {
                candidateList.Add(_areas[(_coords[_coords.Count - 2], _coords[0])]);
            }

            if (_areas.ContainsKey((_coords[1], _coords[_coords.Count - 1])))
            {
                candidateList.Add(_areas[(_coords[1], _coords[_coords.Count - 1])]);
            }
            else if (_areas.ContainsKey((_coords[_coords.Count - 1], _coords[1])))
            {
                candidateList.Add(_areas[(_coords[_coords.Count - 1], _coords[1])]);
            }

            return candidateList.OrderByDescending(x => Math.Abs(x)).First();
        }
    }
}
