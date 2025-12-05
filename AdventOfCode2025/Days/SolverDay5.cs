using AdventOfCode2025.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using Range = Toolbox.Datas.Range;

namespace AdventOfCode2025.Days
{
    internal class SolverDay5 : Solver
    {
        private List<Range> _freshIds = new List<Range>();
        private List<long> _ingredientsList = new List<long>();
        public SolverDay5(string inputFile = "TestInput.txt", bool verbose = true)
        {
            _verbose = verbose;
            ReadInputFile(inputFile);
        }
        private void ReadInputFile(string inputFile)
        {
            FileReader fileReader = new FileReader(inputFile);
            string line = fileReader.Read();
           
            while (line != string.Empty)
            {
                var ids = line.Split('-');
                Range ingredientRange = new Range(long.Parse(ids[0]), long.Parse(ids[1]));
                _freshIds.Add(ingredientRange);
                line = fileReader.Read();
            }

            while (!fileReader.EndOfStream)
            {
                line = fileReader.Read();
                _ingredientsList.Add(long.Parse(line));
            }

            fileReader.Close();
        }

        private bool IsInOneRange(long id)
        {
            foreach (Range range in _freshIds)
            {
                if (range.IsInRange(id, true, true))
                    return true;
            }
            return false;
        }
        public override long GetSolution1Star()
        {
            List<long> freshIngredients = new List<long>();
            foreach (long ingredientId in _ingredientsList)
            {
                if (IsInOneRange(ingredientId))
                {
                    freshIngredients.Add(ingredientId);
                    if (_verbose)
                        Console.WriteLine($"Ingredient ID {ingredientId} is FRESH");
                }
                else
                {
                    if (_verbose)
                        Console.WriteLine($"Ingredient ID {ingredientId} is SPOILED");
                }
            }

            return freshIngredients.Count;
        }

        private (Range range, int index) GetContinuousRange (int startingIndex)
        {
            long startintRange = _freshIds[startingIndex].MinValue;
            long endingRange = _freshIds[startingIndex].MaxValue;
            int i = startingIndex + 1;
            while (i < _freshIds.Count && endingRange + 1 >= _freshIds[i].MinValue)
            {
                if (endingRange < _freshIds[i].MaxValue)
                    endingRange = _freshIds[i].MaxValue;
                i++;
            }

            Range newRange = new Range(startintRange, endingRange);
            return (newRange, i);
        }
        public override long GetSolution2Star()
        {
            _freshIds.Sort((x,y) => x.MinValue.CompareTo(y.MinValue));
            List<Range> newFreshIds = new List<Range>();
            int i = 0;
            while (i < _freshIds.Count)
            {
                var newRange = GetContinuousRange(i);
                newFreshIds.Add(newRange.range);
                if
                    (i == newRange.index) i++;
                else
                    i = newRange.index; 
            }

            long solution = newFreshIds.Sum(x => (x.MaxValue +1) - x.MinValue);
            return solution;
            
        }
    }
}
