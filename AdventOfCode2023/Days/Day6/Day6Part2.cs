namespace AdventOfCode2023.Days.Day6
{
    internal class Day6Part2 : Day6
    {
        internal Day6Part2(string filePath) : base(filePath)
        {
        }

        internal override long Calculate()
        {
            var singleRaceTime = string.Join(',', Races.Select(m => m.Time)).Replace(",", "");
            var singleRaceDistance = string.Join(',', Races.Select(m => m.Distance)).Replace(",", "");
            var singleRace = new Race(long.Parse(singleRaceTime), long.Parse(singleRaceDistance));
            var winCount = GetAvailableWinCount(singleRace);

            return winCount;
        }
    }
}