using System;
using System.Collections.Generic;
using System.Text;

namespace Code.NumbersEtc
{
    // Scores 2, 3, 7 
    // 12 = 6 * 2
    // 12 = 3 * 2 + 2 * 3
    // 12 = 1 * 2 + 1 * 3 + 1 * 1 * 7
    // 12 = 4 * 3 
    //public void Get 
    public class Scores
    {
        // Score: finalScore
        // Points: array of points that comprises that results, can be 1, 2, 3 or 2,3,7 or whatever
        // Idea is to keep subtracting points from the score until it is > 0
        public static List<string> GenerateScoreCombinations(int score, int[] points)
        {
            var uniqueResults = new Dictionary<string, object>();
            var temp = new int[300]; // temp results have dups
            GenerateScoreCombinations(score, points, temp, 0, uniqueResults);

            var results = new List<string>();
            foreach (var result in uniqueResults)
            {
                results.Add(result.Key);
            }
            return results;
        }

        // temp and tempIndex: we need to buffer results somewhere
        // results: final results
        private static void GenerateScoreCombinations(int score, int[] points, int[] temp, int tempIndex, Dictionary<string, object> results)
        {
            if (score == 0)
            {
                var sb = new StringBuilder();
                for (int j = 0; j < tempIndex; j++)
                {
                    sb.Append(temp[j]);
                }

                // Get rid of dups
                var tempArray = sb.ToString().ToCharArray();
                Array.Sort(tempArray);
                var sortedString = new String(tempArray);
                if (!results.ContainsKey(sortedString))
                {
                    results.Add(sortedString, null);
                }
            }
            else if (score > 0)
            {
                foreach (var point in points)
                {
                    temp[tempIndex] = point;
                    GenerateScoreCombinations(score - point, points, temp, tempIndex + 1, results); // score - point +++
                }
            }
        }

        public static int ScoreCombinationCountDp(int score, int[] points)
        {
            int[,] matrix = new int[points.Length,score + 1];
            for (int i = 0; i < points.Length; i++)
            {
                matrix[i, 0] = 1; // One way to reach zero
                for (int j = 1; j <= score; j++)
                {
                    int withoutThisPlay = i - 1 >= 0 ? matrix[i - 1, j] : 0;
                    int withThisPlay = j >= points[i] ? matrix[i, j - points[i]] : 0;
                    matrix[i, j] = withoutThisPlay + withThisPlay;
                }
            }

            return matrix[points.Length - 1, score];
        }

        public static int ScoreCombinationCountSimpleDp(int score, int[] points)
        {
            int[] combinations = new int[score + 1];
            combinations[0] = 1;
            foreach (var point in points)
            {
                for (var j = point; j <= score; j++)
                {
                    combinations[j] += combinations[j - point];
                }
            }

            return combinations[score];
        }
    }
}
