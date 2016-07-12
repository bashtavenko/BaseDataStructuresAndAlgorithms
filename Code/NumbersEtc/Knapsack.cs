using System;
using System.Collections.Generic;

namespace Code.NumbersEtc
{
    public class Knapsack
    {
        public int Run(int weight, List<Item> items)
        {
            return Run(weight, items, items.Count);
        }

        // Returns value
        private int Run(int weight, List<Item> items, int n)
        {
            if (n == 0 || weight == 0)
                return 0;

            if (items[n - 1].Weight > weight)
                return Run(weight, items, n - 1);
            else
            {
                var included = items[n - 1].Value + Run(weight - items[n - 1].Weight, items, n - 1);
                var notIncluded = Run(weight, items, n - 1);
                return Math.Max(included, notIncluded);
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }
    }
}
