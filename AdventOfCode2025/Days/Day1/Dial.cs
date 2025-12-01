using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2025.Days.Day1
{
    internal class Dial
    {
        public enum Direction
        {
            Left,
            Right
        }

        private int _value;
        private bool _verbose;
        public int Value { get => _value; }
        public Dial(int startingValue, bool verbose = false)
        {
            _value = startingValue;
            _verbose = verbose;

            if (_verbose)
            {
                Console.WriteLine($"Dial start at {_value}");
            }
        }

        public int Turn(Direction dir, int value)
        {
            bool isStartAt0 = false;
            if (Value == 0)
                isStartAt0 = true;
            int reste = value / 100;
            value = value % 100;
            _value = (_value + (value * (dir == Direction.Right ? 1 : -1)));

            if (_value >= 100)
            {
                reste++; //we point 0 at leaast once
                _value = _value % 100;
            }
            else if (_value < 0)
            {
                if (!isStartAt0)
                    reste++; //we point 0 at leaast once
                _value = 100 - (_value*-1);
            }
            else if (_value == 0)
            {
                reste++;
            }

            if (_verbose)
            {
                Console.WriteLine($"The dial is rotated {dir} for {value}. New Value : {_value}. Pointing at 0 : {reste}");
            }
            return reste;
        }

        
    }
}
