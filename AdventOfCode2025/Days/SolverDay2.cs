using AdventOfCode2025.Utilities;
using System.Text;
using System.Text.RegularExpressions;
using Toolbox.Datas;
using Range = Toolbox.Datas.Range;
namespace AdventOfCode2025.Days
{
    internal class SolverDay2 : Solver
    {
        private List<Range> _ids = new List<Range>();
        private List<string> _values = new List<string>();
        public SolverDay2(bool verbose = false)
        {
            _verbose = verbose;
            ReadInputFile();
        }
        public override void ReadInputFile()
        {
            //FileReader fileReader = new FileReader("TestInput.txt");
            FileReader fileReader = new FileReader("InputDay2.txt");
            _values = fileReader.ReadToEndAndSplit(',');
            fileReader.Close();
        }

        private List<long> GetInvalidIds(string regexPattern)
        {
            List<long> invalidIds = new List<long>();

            foreach (Range rangeID in _ids)
            {
                StringBuilder strb = new StringBuilder();
                if (_verbose)
                    strb.Append($"[{rangeID.MinValue}-{rangeID.MaxValue}] : ");
                for (long i = rangeID.MinValue; i <= rangeID.MaxValue; i++)
                {
                    Match match = Regex.Match(i.ToString(), regexPattern);
                    if (match.Success)
                    {
                        invalidIds.Add(long.Parse(match.Value));
                        if (_verbose)
                            strb.Append($" {match.Value} ");
                    }
                }
                if (_verbose)
                {
                    Console.WriteLine(strb.ToString());
                }
                strb.Clear();
            }
            return invalidIds;
        }
        public override long GetSolution1Star()
        {
            string pattern = "^(\\d+)\\1$";
            foreach (var line in _values)
            {
                var range = line.Split('-');
                _ids.Add(new Range(long.Parse(range[0]), long.Parse(range[1])));
            }

            List<long> badIds = GetInvalidIds(pattern);
            return badIds.Sum(x => x);
        }
        public override long GetSolution2Star()
        {
            string pattern = "^(\\d+)\\1+$";
            

            List<long> badIds = GetInvalidIds(pattern);
            return badIds.Sum(x => x);
        }
    }
}
