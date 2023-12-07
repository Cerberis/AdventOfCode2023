namespace AdventOfCode2023.Extensions
{
    internal static class StringExtensions
    {
        internal static List<int> ToIntList(this string value, char separationSymbol)
        {
            return value.Split(separationSymbol).Where(m => !string.IsNullOrEmpty(m)).Select(int.Parse).ToList();
        }

        internal static List<long> ToLongList(this string value, char separationSymbol)
        {
            return value.Split(separationSymbol).Where(m => !string.IsNullOrEmpty(m)).Select(long.Parse).ToList();
        }
    }
}
