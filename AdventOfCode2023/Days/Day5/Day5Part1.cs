namespace AdventOfCode2023.Days.Day5
{
    internal class Day5Part1 : Day5
    {
        internal Day5Part1(string filePath) : base(filePath)
        {
        }

        internal override long Calculate()
        {
            var locationsFound = new List<long>();
            foreach (var seed in Seeds)
            {
                var seedLocations = GetSeedLocation(seed);
                locationsFound.Add(seedLocations);
            }
            return locationsFound.Min();
        }

        internal override void ParseSeedData(string row)
        {
            Seeds = row.Replace("seeds: ", "").ToLongList(' ');
        }
    }
}
