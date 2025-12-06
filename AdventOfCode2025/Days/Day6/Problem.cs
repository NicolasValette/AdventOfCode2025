using AdventOfCode2025.Days.Day6;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode2025.Days.Day6
{
    public enum Operation
    {
        Addition,
        Soustraction,
        Multiplication,
        Division
    }
    internal class Problem
    {

        private List<long> _numbers;
        private Operation _operation;
        

        public Problem()
        {
            _numbers = new List<long>();
        }
        public void SetOperation(Operation operation)
        {
            _operation = operation;
        }
        public void SetOperation(char op)
        {
            if (op == '+')
            {
                _operation = Operation.Addition;
            }
            else if (op == '-')
            {
                _operation = Operation.Soustraction;
            }
            else if (op == '*')
            {
                _operation = Operation.Multiplication;
            }
            else if (op == '/')
            {
                _operation = Operation.Division;
            }
        }
        public void AddNumber(long number)
        {
            _numbers.Add(number);
        }
        public long Solve()
        {

            long solution;
            //Set Neutral element;
            if (_operation == Operation.Addition)
            {
                solution = 0;
            }
            else if (_operation == Operation.Soustraction)
            {
                solution = 0;
            }
            else if (_operation != Operation.Multiplication)
            {
                solution = 1;
            }
            else // Division
            {
                solution = 1;
            }

            foreach (long number in _numbers)
            {
                if (_operation == Operation.Addition)
                {
                    solution += number;
                }
                else if (_operation == Operation.Division)
                {
                    if (number == 0) return -1;
                    solution /= number;
                }
                else if (_operation == Operation.Soustraction)
                {
                    solution -= number;
                }
                else if (_operation == Operation.Multiplication)
                {
                    solution *= number;
                }
            }
            return solution;
        }

        public override string ToString()
        {
            char op = '+';
            if (_operation == Operation.Addition)
            {
                op = '+';
            }
            if (_operation == Operation.Soustraction)
            {
                op = '-';
            }
            if (_operation == Operation.Multiplication)
            {
                op = '*';
            }
            if (_operation == Operation.Division)
            {
                op = '/';
            }
            return string.Join(op, _numbers);
        }
    }
}
