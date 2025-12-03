using AdventOfCode2025.Utilities;
using System.Text;

namespace AdventOfCode2025.Days
{
    internal class SolverDay3 : Solver
    {
        List<string> _banks = new List<string>();
        public SolverDay3(bool verbose = false)
        {
            _verbose = verbose;
            ReadInputFile();
        }
        public override void ReadInputFile()
        {
            //FileReader fileReader = new FileReader("TestInput.txt");
            FileReader fileReader = new FileReader("InputDay3.txt"); _verbose = false;
            _banks = fileReader.ReadAndSplitInto2DList();
            fileReader.Close();
        }

        private long GetJoltageFromBank(string bank)
        {
            long joltage = 0;
            int pos = 0;
            char currentGreater = '0';
            char secondCurrentGreater = '0';
            //Get the first Number of joltage
            for (int i = bank.Length-2; i>=0; i--)
            {
                if (bank[i] > currentGreater)
                {
                    currentGreater = bank[i];
                    pos = i;
                }
            }
            pos = bank.IndexOf(currentGreater);

            //We get the second
            for (int j = pos +1; j < bank.Length;j++)
            {
                if (bank[j] > secondCurrentGreater)
                {
                    secondCurrentGreater = bank[j];
                }
            }
            joltage = long.Parse(string.Concat(currentGreater ,secondCurrentGreater));

            if (_verbose)
            {
                Console.WriteLine($"In [{bank}], the largest possible joltage if : {joltage}.");
            }
            return joltage;
        }
        private long GetJoltage12FromBank(string bank, int numberOfDigit = 12)
        {
            int pos = -1;
            int currentDigitNumber = numberOfDigit;
            
            StringBuilder joltageString = new StringBuilder();

            for (int n = numberOfDigit; n > 0; n--)
            {
                char currentGreater = '0';
                for (int i = pos + 1; i < (bank.Length - n + 1); i++)
                {
                    if (bank[i] > currentGreater)
                    {
                        currentGreater = bank[i];
                        pos = i;
                    }
                }
                joltageString.Append(currentGreater);
            }

            if (_verbose)
            {
                Console.WriteLine($"In [{bank}], the largest possible joltage if : {joltageString.ToString()}.");
            }
            return long.Parse(joltageString.ToString());
        }


        public override long GetSolution1Star()
        {
            long solution = 0;
            foreach (string bank in _banks)
            {
                solution += GetJoltageFromBank(bank);
            }
            return solution;
        }
        public override long GetSolution2Star()
        {
            long solution = 0;
            foreach (string bank in _banks)
            {
                solution += GetJoltage12FromBank(bank);
            }
            return solution;
        }

    }
}
