using System.Reflection;
using AdventOfCode;

RunSolutionOfTheDay(false);


void RunSolutionOfTheDay(bool test, int day = 0)
{
    var dayOfMonth = Utils.GetDayNumber(day);
    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @$"inputs\day{(test ? dayOfMonth +  "_test" : dayOfMonth )}.txt");
    var input = File.ReadAllText(path);
    try
    {
        var t = typeof(Program).Assembly.GetType($"AdventOfCode.Solvers.Day{dayOfMonth}");
        object? partOne = t.GetMethod("PartOne", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[] {input});
        object? partTwo = t.GetMethod("PartTwo", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[] { input });
        Utils.PrintSolution(test, dayOfMonth, partOne, partTwo);
    }
    catch (Exception)
    {
        Console.WriteLine($"Error: No solution for Day{dayOfMonth} yet.");
    }
    

}
