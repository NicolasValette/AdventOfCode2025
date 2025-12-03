using AdventOfCode2025.Days;
using AdventOfCode2025.Utilities;
using System.Diagnostics;

namespace AdventOfCode2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solver day = new SolverDay3(true);
            Stopwatch sw = new Stopwatch();
            
            #region Solution 1 étoile
            Console.WriteLine("####################");
            Console.WriteLine("Resolution 1 étoiles");
            sw.Start();
            long solution = day.GetSolution1Star();
            sw.Stop();
            
            Console.WriteLine("solution : " + solution);
            Console.WriteLine("RunTime :" + sw.Elapsed);
            Console.WriteLine("####################");
            Console.WriteLine("");
            #endregion

            sw.Reset();

            #region Solution 2 étoiles
            Console.WriteLine("####################");
            Console.WriteLine("Resolution 2 étoiles");
            sw.Start();
            long solution2 = day.GetSolution2Star();
            sw.Stop();
           
            Console.WriteLine("solution : " + solution2);
            Console.WriteLine("RunTime :" + sw.Elapsed);
            Console.WriteLine("####################");
            Console.WriteLine("");
            #endregion
        }
    }
}