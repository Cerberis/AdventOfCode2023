namespace AdventOfCode2023.Days.Day6
{
    internal class Day6Part1 : Day6
    {
        internal Day6Part1(string filePath) : base(filePath)
        {
        }

        internal override long Calculate()
        {
            long totalWinCount = 1;
            foreach (var race in Races)
            {
                var winCount = GetAvailableWinCount(race);

                if (winCount > 0 && totalWinCount == 0)
                    totalWinCount = 1;
                totalWinCount *= winCount;
            }
            return totalWinCount;
        }
    }
}
