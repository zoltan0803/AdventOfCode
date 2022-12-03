﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Models;

namespace AdventOfCode.Solvers
{
    public class Day03 : IDay
    {
        public static List<char> priorityItems = new List<char>();
        public static object PartOne(string input)
        {
            return GetCompartments(input).SelectMany(x => x.ElementAt(0).Intersect(x.ElementAt(1)))
                                         .ToList()
                                         .Sum(x => GetPriority(x));
        }

        public static object PartTwo(string input) => GetBadges(input).Sum(x => GetPriority(x[0]));

        public static List<List<char[]>> GetCompartments(string input)
        {
            return input.Split('\n')
                        .ToList()
                        .Select(x => (new List<char[]> { 
                            x.Substring(0, x.Length / 2).ToCharArray(),
                            x.Substring(x.Length / 2).ToCharArray() 
                        })).ToList();
        }

        public static List<List<char>> GetBadges(string input)
        {
            var s = input.Split('\n').ToList();
            return Enumerable.Range(1, (s.Count) / 3).ToList()
                             .Select(x => (x) * 3 - 3).ToList()
                             .Select(x => s.ElementAt(x)
                                           .Intersect(s.ElementAt(x + 1)
                                           .Intersect(s.ElementAt(x + 2))).ToList()).ToList();
        }

        public static int GetPriority(char c) => Char.IsLower(c) ? c - 96 : c - 64 + 26;
    }
}

