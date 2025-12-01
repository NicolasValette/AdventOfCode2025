using AdventOfCode2025.Days;
using AdventOfCode2025.Utilities;

namespace AdventOfCode2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solver day = new SolverDay1(true);

            #region Solution 1 étoile
            Console.WriteLine("####################");
            Console.WriteLine("Resolution 1 étoiles");
            long solution = day.GetSolution1Star();
            Console.WriteLine("solution : " + solution);
            Console.WriteLine("####################");
            Console.WriteLine("");
            #endregion

            #region Solution 2 étoiles
            Console.WriteLine("####################");
            Console.WriteLine("Resolution 2 étoiles");
            long solution2 = day.GetSolution2Star();
            Console.WriteLine("solution : " + solution2);
            Console.WriteLine("####################");
            Console.WriteLine("");
            #endregion
        }
    }
}