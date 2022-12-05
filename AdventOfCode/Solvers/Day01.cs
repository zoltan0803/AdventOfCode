using AdventOfCode.Models;
using AdventOfCode.Utils;

namespace AdventOfCode.Solvers
{
    public class Day01 : IDay
    {
        public static object PartOne(string input) => GetElfes(input).First().Sum();

        public static object PartTwo(string input) => GetElfes(input).Take(3).Select(elf => elf.Sum()).Sum();

        static List<int[]> GetElfes(string input)
        {
            return input.Split("\r\n\r\n")
                        .ToList()
                        .Select(elf => elf.GetLines()
                            .Select(cal => int.Parse(cal))
                            .ToArray())
                        .OrderByDescending(elf => elf.Sum())
                        .ToList();
        }
    }
}
