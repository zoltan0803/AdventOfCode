using AdventOfCode.Models;
using AdventOfCode.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Solvers
{
    internal class Day05 : IDay
    {
        public static object PartOne(string input)
        {
            var t = GetTowers(input);
            var m = GetMoves(input);
            m.ForEach(m => UseCrateMover9000(t, m));
            return new string(t.Select(x => x.Last()).ToArray());
        }

        public static object PartTwo(string input)
        {
            var t = GetTowers(input);
            GetMoves(input).ForEach(m => UseCrateMover9001(t, m));
            return new string(t.Select(x => x.Last()).ToArray());
        }

        public static List<List<char>> GetTowers(string input)
        {
            var s = input.GetLines();
            var maxHeight = s.FindIndex(x => int.TryParse(x[1].ToString(), out int r));
            var numberOfTowers = int.Parse(s[maxHeight].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList().Last());
            var towers = new char[numberOfTowers, maxHeight];
            for(int i = 0; i < maxHeight; i++)
            {
                for (int j = 0; j < numberOfTowers; j++)
                {
                    var val = s[i][j == 0 ? 1 : j * 4 + 1];
                    if (!char.IsLetter(val)) continue;
                    towers[j, maxHeight - i - 1] = val;
                }
            }
            return towers.Cast<char>()
                         .Select((x, i) => new { x, index = i / towers.GetLength(1) })
                         .GroupBy(x => x.index)
                         .Select(x => x.Select(s => s.x).Where(y => char.IsLetter(y)).ToList())
                         .ToList();
        }

        public static List<int[]> GetMoves(string input)
        {
            return input.GetLines()
                        .Select(x => Regex.Match(x, @"move\s(\d+)\sfrom\s(\d+)\sto\s(\d+)").Groups
                                          .Cast<Group>()
                                          .Skip(1)
                                          .ToList()
                                          .Select(y => int.Parse(y.Value))
                                          .ToArray())
                        .Where(x => x.Length > 0)
                        .ToList();

        }

        public static List<List<char>> UseCrateMover9000(List<List<char>> towers, int[] p)
        {
            int cnt = p[0]; int from = p[1]; int to = p[2];
            Enumerable.Range(0, cnt)
                      .ToList()
                      .ForEach(x => { 
                          towers.ElementAt(to - 1).Add(towers.ElementAt(from - 1).Last());
                          var t = towers.ElementAt(from - 1);
                          t.RemoveAt(t.Count - 1); 
                      });
            return towers;
        }

        public static List<List<char>> UseCrateMover9001(List<List<char>> towers, int[] p)
        {
            int cnt = p[0]; int from = p[1]; int to = p[2];
            towers.ElementAt(from - 1).Reverse();
            var crates = towers.ElementAt(from - 1).Take(cnt).Reverse().ToList();
            towers.ElementAt(to - 1).AddRange(crates);
            crates.ForEach(x => towers.ElementAt(from - 1).Remove(x));
            towers.ElementAt(from - 1).Reverse();
            return towers;
        }
    }
}
