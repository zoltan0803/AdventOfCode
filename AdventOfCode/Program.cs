using System.Diagnostics;
using System.Reflection;
using AdventOfCode.Utils;

RunSolutionOfTheDay(false);

static void RunSolutionOfTheDay(bool test, int day = 0)
{
    var dayOfMonth = ProgramUtils.GetDayNumber(day);
    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @$"inputs/day{(test ? dayOfMonth +  "_test" : dayOfMonth )}.txt");
    var input = File.ReadAllText(path);
    try
    {
        var t = typeof(Program).Assembly.GetType($"AdventOfCode.Solvers.Day{dayOfMonth}");
        var sw = Stopwatch.StartNew();
        object? partOne = t.GetMethod("PartOne", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[] {input});
        sw.Stop();
        var sw2 = Stopwatch.StartNew();
        object? partTwo = t.GetMethod("PartTwo", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[] { input });
        sw2.Stop();
        ProgramUtils.PrintSolution(test, dayOfMonth, partOne, sw.ElapsedMilliseconds, partTwo, sw2.ElapsedMilliseconds);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error: No solution for Day{dayOfMonth} yet. {e}");
    }
}
