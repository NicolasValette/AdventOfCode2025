using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2025.Days.Day12
{
    internal class Block
    {
        private string _shape;
        public int NbBlock { get; init; }

        public Block(string shape, int area)
        {
            _shape = shape;
            NbBlock = area;
        }
    }
}
