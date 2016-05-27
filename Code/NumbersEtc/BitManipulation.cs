using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.NumbersEtc
{
    class BitManipulation
    {
        private int _number;

        public BitManipulation (int number)
        {
            _number = number;
        }

        public void Set (int n)
        {
            _number = _number | 1 << n;
        }

        public void Reset (int n)
        {
            _number = _number & ~(1 << n); // Can't shift 0 to right position 
        }

        public bool IsSet(int n)
        {
            // It can be any number or 0 
            return (_number & (1 << n)) > 0;
        }

        public int CountOnesCrudeWay ()
        {
            var count = 0;
            for (int i = 0; i < int.MaxValue; i++)
            {   
                if (IsSet(i))
                count++;
            }
            return count;
        }

        public int CountOnes(int x)
        {
            var count = 0;
            while (x > 0)
            {
                x = TurnOffRightMostBit(x);
                count++;
            }
            return count;
        }

        // (7)      0111
        // (6)      0110
        // x & (x-1) 0110    
        private static int TurnOffRightMostBit(int x)
        {
            return x & (x - 1);
        }

        // Bits are different 0-0=0 / 0-1=1 / 1-0=1/1-1=0
        // 1. XOR to itself is 0
        // 2. XOR to 0 is itself
        public int NumberXor(int x, int y)
        {
            return x ^ y;
        }

        public static int Toggle(int x, int n)
        {
            return x ^ (1 << n);
        }

        public static int TurnOnAllBitsToTheLeftOfN(int n)
        {
            // (4) 100
            // (3) 011
            return (1 << n) - 1;
        }
    }
}