namespace AdventOfCode2023.Days.Day9
{
    internal class Day9Part2 : Day9
    {
        internal Day9Part2(string filePath) : base(filePath)
        {
        }

        internal override int Calculate()
        {
            var newHistory = GetNewHistoryData();
            newHistory = AddPredictedEntries(newHistory);
            int result = CalculateScore(newHistory);
            return result;
        }

        internal override int CalculateScore(List<List<List<int>>> newHistory)
        {
            var result = 0;
            foreach (var history in newHistory)
            {
                result += history[0].First();
            }

            return result;
        }

        internal override List<List<List<int>>> AddPredictedEntries(List<List<List<int>>> newHistory)
        {
            foreach (var history in newHistory)
            {
                int lastPredictedEntry = 0;
                for (int index = history.Count; 0 < index; index--)
                {
                    var entryOnRight = history[index - 1].First();
                    var calculatedPredictionEntry = entryOnRight - lastPredictedEntry;
                    history[index - 1].Insert(0, calculatedPredictionEntry);
                    lastPredictedEntry = calculatedPredictionEntry;
                }
            }

            foreach (var his in newHistory)
            {
                foreach (var hisEntry in his)
                {
                    Console.WriteLine(string.Join(" ", hisEntry));
                }
                Console.WriteLine(string.Empty);
            }
            return newHistory;
        }
    }
}