using AdventOfCode.Models;
using AdventOfCode.Utils;

namespace AdventOfCode.Solvers
{
    internal class Day02 : IDay
    {
        public static object PartOne(string input) => GetGuides(input).Select(c => RPS(c[1], c[0]) + c[1] - 87).Sum();

        public static object PartTwo(string input) 
            => GetGuides(input).Select(c => 
            {
                var s = GetStrategy(c[1], c[0]) + 23;
                return RPS(s, c[0]) + s - 87;
            }).Sum();


        private static IEnumerable<char[]> GetGuides(string input) 
            => input.GetLines().Select(e => e.Split(" ")
                               .Select(c => char.Parse(c))
                               .ToArray());

        private static int RPS(int i, int j)
        {
            i -= 87; j -= 64;
            if (i == j) return 3;
            if (i == 3) return j == 1 ? 0 : 6;
            if (j == 3) return i == 1 ? 6 : 0;
            return i < j ? 0 : 6;
        }

        private static char GetStrategy(char i, char j)
        {
            return i switch
            {
                'X' => (char)(j == 'A' ? j + 2 : j - 1),
                'Y' => j,
                _ => (char)(j == 'C' ? j - 2 : j + 1)
            };

        }
    }
}
