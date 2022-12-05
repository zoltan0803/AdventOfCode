namespace AdventOfCode.Utils
{
    public class ProgramUtils
    {
        public static void PrintSolution(bool test, string day, object partOne, long partOneTime, object partTwo, long partTwoTime)
        {
            Console.BackgroundColor = test ? ConsoleColor.DarkRed : ConsoleColor.DarkGreen;

            Console.WriteLine($"{(test ? "TEST " : "")}Solution of Day{day}:");
            Console.WriteLine();
            Console.WriteLine($"Part One: {partOne}");
            Console.WriteLine($"Took:  {partOneTime} ms");
            Console.WriteLine();
            Console.WriteLine($"Part Two: {partTwo}");
            Console.WriteLine($"Took {partTwoTime} ms");
        }

        public static string GetDayNumber(int day)
        {
            if (day == 0)
                day = DateTime.Now.Day;
            return day < 10 ? $"0{day}" : day.ToString();
        }
    }
}
