using AdventOfCode.Models;
using AdventOfCode.Utils;

namespace AdventOfCode.Solvers
{
    public class Day03 : IDay
    {
        public static object PartOne(string input) 
            => GetCompartments(input).SelectMany(x => x.ElementAt(0).Intersect(x.ElementAt(1)))
                                     .ToList()
                                     .Sum(GetPriority);

        public static object PartTwo(string input) => GetBadges(input).Sum(x => GetPriority(x[0]));

        public static List<List<char[]>> GetCompartments(string input)
        {
            return input.GetLines()
                        .Select(x => (new List<char[]> { 
                            x[..(x.Length / 2)].ToCharArray(),
                            x[(x.Length / 2)..].ToCharArray() 
                        })).ToList();
        }

        public static List<List<char>> GetBadges(string input)
        {
            var s = input.GetLines();
            return Enumerable.Range(1, (s.Count) / 3).ToList()
                             .Select(x => (x) * 3 - 3).ToList()
                             .Select(x => s[x].Intersect(s[x + 1].Intersect(s[x + 2])).ToList())
                             .ToList();
        }

        public static int GetPriority(char c) => char.IsLower(c) ? c - 96 : c - 64 + 26;
    }
}

