using AdventOfCode.Models;
using AdventOfCode.Utils;

namespace AdventOfCode.Solvers
{
    internal class Day02 : IDay
    {
        public static object PartOne(string input) => GetResults(input).Sum();

        public static object PartTwo(string input) => GetResultsWithoutStrategy(input).Sum();

        static List<int> GetResults(string input)
        {
            return input.GetLines()
                        .Select(elf => elf.Split(" ")
                            .Select(cal => char.Parse(cal)).ToArray())
                        .Select(c => RPS(c[1], c[0]) + c[1] - 87)
                        .ToList();
        }

        private static List<int> GetResultsWithoutStrategy(string input)
        {
            return input.GetLines()
                        .Select(elf => elf.Split(" ")
                            .Select(cal => char.Parse(cal)).ToArray())
                        .Select(c =>
                        {
                            var s = GetStrategy(c[1], c[0]) + 23;
                            return RPS(s, c[0]) + s - 87;
                        }).ToList();

        }
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
