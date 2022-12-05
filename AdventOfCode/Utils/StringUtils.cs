namespace AdventOfCode.Utils
{
    public static class StringUtils
    {
        public static List<string> GetLines(this string input, bool removeEmptyLines = true)
        {
            var o = removeEmptyLines ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None;
            return (input.Contains('\r') ?
                        input.Split("\r\n", o) :
                        input.Split(new char[] { '\r', '\n' }, o))
                    .ToList();

        }
    }
}
