using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2025.Days.Day12
{
    internal class Region
    {
        private int Width { get; init; }
        private int Height { get; init; }
        public int Area => Width * Height;
        public int Present0 { get; init; }
        public int Present1 { get; init; }
        public int Present2 { get; init; }
        public int Present3 { get; init; }
        public int Present4 { get; init; }
        public int Present5 { get; init; }

        public Region(int w, int h, int p0, int p1, int p2, int p3, int p4, int p5)
        {
            Width = w;
            Height = h;
            Present0 = p0;
            Present1 = p1;
            Present2 = p2;
            Present3 = p3;
            Present4 = p4;
            Present5 = p5;
        }
    }
}
