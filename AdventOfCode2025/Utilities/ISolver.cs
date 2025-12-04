using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2025.Utilities
{
    interface ISolver
    {
       // void ReadInputFile(bool isSample = false);
        long GetSolution1Star();
        long GetSolution2Star();
    }
}
