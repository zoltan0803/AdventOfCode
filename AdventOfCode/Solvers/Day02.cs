using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Models;

namespace AdventOfCode.Solvers
{
    internal class Day02 : IDay
    {
        public static object PartOne(string input)
        {
            return GetResults(input).Sum();
        }

        public static object PartTwo(string input)
        {
            return GetResultsWithoutStrategy(input).Sum();
        }

        static List<int> GetResults(string input)
        {
            return input.Split("\r\n")
                        .ToList()
                        .Select(elf => elf.Split(" ")
                            .Select(cal => char.Parse(cal)).ToArray())
                        .Select(c => RPS(c[1], c[0]) + c[1] - 87)
                        .ToList();
        }

        static List<int> GetResultsWithoutStrategy(string input)
        {
            return input.Split("\r\n")
                        .ToList()
                        .Select(elf => elf.Split(" ")
                            .Select(cal => char.Parse(cal)).ToArray())
                        .Select(c =>
                        {
                            var s = GetStrategy(c[1], c[0]) + 23;
                            return RPS(s, c[0]) + s - 87;
                        })
                        .ToList();

        }
        public static int RPS(int i, int j)
        {
            i -= 87; j -= 64;

            if (i == 3) return j == 1 ? 0 : i == j ? 3 : 6;
            if (j == 3) return i == 1 ? 6 : i == j ? 3 : 0;
            return i < j ? 0 : i == j ? 3 : 6;
        }

        public static char GetStrategy(char i, char j)
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
