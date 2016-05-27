using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.Strings
{
    public class PowerSet
    {
        // a b c 
        // 4 2 1
        // 0 0 0 
        // 0 0 1    c
        // 0 1 0    b
        // 0 1 1    b c  
        //http://stackoverflow.com/questions/19890781/creating-a-power-set-of-a-sequence   
        public static List<string> Generate(string input)
        {
            var n = input.Length;
            var result = new List<string>();
            
            for (int i = 0; i < (1 << n); i++)
            {
                // Check which bits should be set
                var s = new StringBuilder();
                for (int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        s.Append(input[j]);
                    }
                }
                result.Add(s.ToString());
            }
            
            return result;
        }
        
        public static List<string> GenerateRecursive(string input)
        {
            if (!input.Any())
            {
                return new List<string>();
            }
            else
            {
                List<string> result = GenerateRecursive(input.Substring(1));
                var s = new StringBuilder();
                foreach (var ss in result)
                {
                    s.Append(input[0]);
                }
                result.Add(s.ToString());
                return result;
            }
        }

        public static IList<IList<T>> PowerSet2<T>(IList<T> list)
        {
            if (list.Count == 0)
                return new List<IList<T>>(new[] { new List<T>() });
            else
            {
                IList<IList<T>> ps = PowerSet2(list.Skip(1).ToArray());
                foreach (List<T> ss in ps.ToArray())
                    ps.Add(new List<T>(ss) { list.First() });
                return ps;
            }
        }

    }
}
