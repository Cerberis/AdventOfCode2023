namespace AdventOfCode2023.Days.Day9
{
    internal abstract class Day9
    {
        internal List<List<int>> InputData;

        internal Day9(string filePath)
        {
            ReadDataFile(filePath);
        }

        internal int Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
            return result;
        }

        private void ReadDataFile(string filePath)
        {
            InputData = new List<List<int>>();
            var rows = File.ReadLines(filePath).ToList();

            for (int i = 0; i < rows.Count; i++)
            {
                var rowData = rows[i].Split(" ").Select(int.Parse).ToList();
                InputData.Add(rowData);
            }
        }

        internal abstract int Calculate();

        internal abstract int CalculateScore(List<List<List<int>>> newHistory);
        
        internal abstract List<List<List<int>>> AddPredictedEntries(List<List<List<int>>> newHistory);

        internal List<List<List<int>>> GetNewHistoryData()
        {
            var result = new List<List<List<int>>>();
            foreach (var history in InputData)
            {
                var remadeHistoryEntry = new List<List<int>>();
                var currentHistoryEntry = history;
                while (true)
                {
                    remadeHistoryEntry.Add(currentHistoryEntry);
                    if (currentHistoryEntry.All(m => m == 0))
                        break;

                    var newHistoryEntry = new List<int>();
                    for (int i = 0; i < currentHistoryEntry.Count - 1; i++)
                    {
                        newHistoryEntry.Add(currentHistoryEntry[i + 1] - currentHistoryEntry[i]);
                    }
                    currentHistoryEntry = newHistoryEntry;
                }
                result.Add(remadeHistoryEntry);
            }

            return result;
        }
    }
}
