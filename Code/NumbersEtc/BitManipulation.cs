using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.NumbersEtc
{
    class BitManipulation
    {
        private ulong _number;

        public BitManipulation (ulong number)
        {
            _number = number;
        }

        public void Set (int n)
        {
            if (n < 0 || n > sizeof(ulong))
                return;
            _number = _number | (ulong) 1 << n;
        }

        public void Reset (int n)
        {
            if (n < 0 || n > sizeof(ulong))
                return;
            _number = _number & ~((ulong) 1 << n);
        }

        public bool Test(int n)
        {
            return (_number & ((ulong) 1 << n)) == 1;
        }

        public int Count ()
        {
            var count = 0;
            for (ulong i = 0; i <= ulong.MaxValue; i++)
            {   
                if (Test((int) i))
                count++;
            }
            return count;
        }
    }
}