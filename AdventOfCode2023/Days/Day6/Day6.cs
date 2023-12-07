namespace AdventOfCode2023.Days.Day6
{
    internal abstract class Day6
    {
        internal List<Race> Races;

        internal Day6(string filePath)
        {
            ReadDataFile(filePath);
        }

        internal string Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
            return result.ToString();
        }

        private void ReadDataFile(string filePath)
        {
            Races = new List<Race>();
            var rows = File.ReadLines(filePath).ToList();
            var times = rows[0].Split(':')[1].Split(' ').Where(m => !string.IsNullOrWhiteSpace(m)).ToList();
            var distances = rows[1].Split(':')[1].Split(' ').Where(m => !string.IsNullOrWhiteSpace(m)).ToList();

            for (int i = 0; i < times.Count(); i++)
            {
                Races.Add(new Race(long.Parse(times[i]), long.Parse(distances[i])));
            }
        }

        internal abstract long Calculate();

        internal virtual long GetAvailableWinCount(Race race)
        {
            var winCount = 0;
            for (long startingSpeed = 0; startingSpeed < race.Time; startingSpeed++)
            {
                var timeLeft = race.Time - startingSpeed;
                var distanceTraveled = startingSpeed * timeLeft;

                bool canBeatDistance = distanceTraveled > race.Distance;
                if (canBeatDistance)
                    winCount++;
            }
            return winCount;
        }
    }
}
