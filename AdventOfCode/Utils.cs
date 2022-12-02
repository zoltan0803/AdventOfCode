using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Utils
    {
        public static void PrintSolution(bool test, string day, object partOne, object partTwo)
        {
            Console.BackgroundColor = test ? ConsoleColor.DarkRed : ConsoleColor.DarkGreen;
            
            Console.WriteLine($"{(test ? "TEST " : "" )}Solution of Day{day}:");
            Console.WriteLine("******************");
            Console.WriteLine($"Part One: {partOne}");
            Console.WriteLine("******************");
            Console.WriteLine($"Part Two: {partTwo}");
            Console.WriteLine("******************");
        }

        public static string GetDayNumber(int day)
        {
            if (day == 0)
                day = DateTime.Now.Day;
            return day < 10 ? $"0{day}" : day.ToString();
        }
    }
}
