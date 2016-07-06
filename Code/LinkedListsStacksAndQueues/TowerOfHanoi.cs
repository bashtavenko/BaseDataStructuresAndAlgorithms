using System.Collections.Generic;
using System.Diagnostics;

namespace Code.LinkedListsStacksAndQueues
{
    public class TowerOfHanoi
    {
        private static int _numOfPegs = 3;

        public static void Compute(int numRings)
        {
            var pegs = new LinkedList<int>[_numOfPegs];
            for (int i = 0; i < _numOfPegs; i++)
            {
                pegs[i] = new LinkedList<int>();
            }

            for (int i = numRings; i >= 1; i--)
            {
                pegs[0].AddFirst(i);
            }

            ComputeSteps(numRings, pegs, 0, 2, 1);
        }

        // I'll be damned... 
        private static void ComputeSteps(int numRingsToMove, LinkedList<int>[] pegs, int fromPeg, int toPeg, int usePeg)
        {
            if (numRingsToMove > 0)
            {
                ComputeSteps(numRingsToMove - 1, pegs, fromPeg: fromPeg, toPeg: usePeg, usePeg: toPeg);
                pegs[toPeg].AddFirst(pegs[fromPeg].First.Value);
                pegs[fromPeg].RemoveFirst();
                Trace.WriteLine($"Move from peg {fromPeg} to peg {toPeg}");
                ComputeSteps(numRingsToMove - 1, pegs, fromPeg: usePeg, toPeg: toPeg, usePeg: fromPeg);
            }
        }
    }
}
