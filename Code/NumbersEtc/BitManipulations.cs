using System;

namespace Code.NumbersEtc
{
    public class BitManipulations
    {
        // Bits are different 0-0=0 / 0-1=1 / 1-0=1/1-1=0
        // 1. XOR to itself is 0
        // 2. XOR to 0 is itself
        public int NumberXor(int x, int y)
        {
            return x ^ y;
        }

        public static int Set (int x, int n)
        {
            return x | 1 << n;
        }

        public int Reset (int x, int n)
        {
            return x & ~(1 << n); // Can't shift 0 to right position 
        }

        public static bool Test(int x, int n)
        {
            // It can be any number or 0 
            return (x & (1 << n)) > 0;
        }

        public static int Toggle(int x, int n)
        {
            return x ^ (1 << n);
        }

        // x (6)       110
        //   (5)       101   
        // x & (x-1)   100      
        private static int TurnOffRightMostOne(int x)
        {
            return x & (x - 1);
        }

        // (4) 100
        // (3) 011
        public static int TurnOnAllBitsToTheLeftOfN(int n)
        {
            return (1 << n) - 1;
        }

        public static int CountOnesCrudeWay(int x)
        {
            var count = 0;
            for (int i = 0; i < sizeof(int) * 8; i++)
            {
                if ((x & (1 << i)) > 0) count++;
            }
            return count;
        }

        public static int CountOnesBinaryShift(int x)
        {
            var count = 0;
            while (x > 0)
            {
                count += x & 1;
                x = x >> 1; // or x >>= 1
            }
            return count;
        }

        // Brian Kernigan algo
        // This is a lot better than others because it iterates over ones only.
        public static int CountOnes(int x)
        {
            var count = 0;
            while (x > 0)
            {
                // Turn off rightmost bit (NOT least significaant bit). Can drop by 1, 2 or whatever
                x = x & (x - 1);  
                count++;
            }
            return count;
        }

        public static bool[] GetBitsOfNumber(int x)
        {
            // Find number of bits in the number
            int numberOfBits = 0;
            for (int y = x; y > 0; y >>= 1)
            {
                numberOfBits++;
            }

            // Now we can allocate array with that size
            var result = new bool[numberOfBits];
            
            for (int i = 0; i < numberOfBits; i++)
            {
                result[i] = (x & 1) > 0;
                x >>= 1;
            }
            return result;
        }
    }
}