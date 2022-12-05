using AdventOfCode.Utils;

namespace AdventOfCode.Solvers
{
    internal class Day04
    {
        public static object PartOne(string input)
        => GetSections(input).Count(p =>
        {
            var a = p.ElementAt(0).Except(p.ElementAt(1)).Any();
            var b = p.ElementAt(1).Except(p.ElementAt(0)).Any();
            return !a || !b;
        });

        public static object PartTwo(string input) 
        => GetSections(input).Count(p => p.ElementAt(0).Intersect(p.ElementAt(1)).Any());

        public static List<List<List<int>>> GetSections(string input)
        {
            return input.GetLines().Select(l => l.Split(',')
                                   .ToList()
                                   .Select(y => {
                                       var e = y.Split('-');
                                       return Enumerable.Range(int.Parse(e[0]), int.Parse(e[1]) - int.Parse(e[0]) + 1).ToList();
                                   }).ToList()).ToList();
        }
    }
}
