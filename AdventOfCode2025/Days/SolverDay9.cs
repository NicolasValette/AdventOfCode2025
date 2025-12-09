using AdventOfCode2025.Utilities;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AdventOfCode2025.Days
{
    internal class SolverDay9 : Solver
    {
        List<Vector2> _coords;
        Dictionary<(Vector2, Vector2), long> _areas;
        public SolverDay9(string inputFile = "TestInput.txt", bool verbose = true)
        {
            _coords = new List<Vector2>();
            _areas = new Dictionary<(Vector2, Vector2), long>();

            _verbose = verbose;
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

        private void GetAreas()
        {
            for (int i = 0; i < _coords.Count; i++)
            {
                for (int j = i + 1; j < _coords.Count; j++)
                {
                    long dist = (((long)_coords[i].Y - (long)_coords[j].Y) + 1) * (((long)_coords[i].X - (long)_coords[j].X) + 1);
                    _areas.Add((_coords[i], _coords[j]), dist);
                }
            }
        }
        public override long GetSolution1Star()
        {
            GetAreas();
            return _areas.OrderByDescending(x => x.Value).First().Value;
        }
    }
}
