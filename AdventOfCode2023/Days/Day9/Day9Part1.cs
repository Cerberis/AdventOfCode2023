namespace AdventOfCode2023.Days.Day9
{
    internal class Day9Part1 : Day9
    {
        internal Day9Part1(string filePath) : base(filePath)
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
                result += history[0].Last();
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
                    var entryOnLeft = history[index - 1].Last();
                    var calculatedPredictionEntry = lastPredictedEntry + entryOnLeft;
                    history[index - 1].Add(calculatedPredictionEntry);
                    lastPredictedEntry = calculatedPredictionEntry;
                }
            }

            return newHistory;
        }
    }
}
