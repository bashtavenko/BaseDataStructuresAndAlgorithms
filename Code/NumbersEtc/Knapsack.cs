using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.NumbersEtc
{
    public class Knapsack
    {
        public int Run(int w, List<Item> items)
        {
            return Run(w, items, items.Count);
        }

        private int Run(int w, List<Item> items, int n)
        {
            if (n == 0 || w == 0)
                return 0;

            if (items[n - 1].Weight > w)
                return Run(w, items, n - 1);
            else
            {
                var included = items[n - 1].Value + Run(w - items[n - 1].Weight, items, n - 1);
                var notIncluded = Run(w, items, n - 1);
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
