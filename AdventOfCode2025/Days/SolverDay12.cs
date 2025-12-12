using AdventOfCode2025.Days.Day12;
using AdventOfCode2025.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2025.Days
{
    internal class SolverDay12 : Solver
    {
        private List<Block> _blocks;
        private List<Region> _regions;
        public SolverDay12(string inputFile = "TestInput.txt", bool verbose = true)
        {
            _blocks = new List<Block>();
            _regions = new List<Region>();
            _verbose = verbose;
            ReadInputFile(inputFile);
        }
        private void ReadInputFile(string inputFile)
        {
            FileReader fileReader = new FileReader(inputFile);
            var block = fileReader.ReadToEnd().Split("\r\n\r\n", StringSplitOptions.TrimEntries).Select(x=>x.Trim()).ToList();
            fileReader.Close();

            for (int i = 0; i < 6; i++)
            {
                if (i < 6)
                {
                    int area = block[i].Where(x => x == '#').Count();
                    Block bk = new Block(block[i], area);
                    _blocks.Add(bk);
                }
            }
            List<string> regions = block[6].Split("\n", StringSplitOptions.TrimEntries).ToList();
            foreach(var item in regions)
            {
                var line = item.Split(':', StringSplitOptions.TrimEntries);
                int w = int.Parse(line[0].Split('x', StringSplitOptions.TrimEntries)[0]);
                int h = int.Parse(line[0].Split('x', StringSplitOptions.TrimEntries)[1]);
                int[] present = line[1].Split(' ', StringSplitOptions.TrimEntries).Select(int.Parse).ToArray();
                Region region = new(w, h, present[0], present[1], present[2], present[3], present[4], present[5]);
                _regions.Add(region);
            }
            Console.WriteLine("fin");
            
        }

        public override long GetSolution1Star()
        {
            long solution = 0;
            foreach(var region in _regions)
            {
                int area = region.Area;
                int minimumArea = region.Present0 * _blocks[0].NbBlock + region.Present1 * _blocks[1].NbBlock + region.Present2 * _blocks[2].NbBlock +
                    region.Present3 * _blocks[3].NbBlock + region.Present4 * _blocks[4].NbBlock + region.Present5 * _blocks[5].NbBlock;
                if (minimumArea < area)
                    solution++;
            }
            return solution;

        }
    }
}
