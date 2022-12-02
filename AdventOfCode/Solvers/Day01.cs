using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Models;

namespace AdventOfCode.Solvers
{
    public class Day01 : IDay
    {
        static List<int[]>? Elfes;
        public static object PartOne(string input)
        {
            Elfes ??= GetElfes(input);
            return Elfes.First().Sum();
        }

        public static object PartTwo(string input)
        {
            Elfes ??= GetElfes(input);
            return Elfes.Take(3).Select(e => e.Sum()).Sum();
        }

        static List<int[]> GetElfes(string input)
        {
            return input.Split("\r\n\r\n")
                        .ToList()
                        .Select(elf => elf.Split("\r\n")
                            .Select(cal => int.Parse(cal))
                            .ToArray())
                        .OrderByDescending(elf => elf.Sum())
                        .ToList();
        }
    }
}
