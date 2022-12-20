using AdventOfCode.Models;

namespace AdventOfCode.Solvers
{
    internal class Day06 : IDay
    {
        public static object PartOne(string input) => GetFirstNDistinctMatchIndex(input, 4);

        public static object PartTwo(string input) => GetFirstNDistinctMatchIndex(input, 14);
        
        public static int GetFirstNDistinctMatchIndex(string input, int k) 
            => k + Enumerable.Range(0, input.Length).ToList().FindIndex(x => input.Take(new Range(x, x + k)).Distinct().Count() == k);
        
    }
}


