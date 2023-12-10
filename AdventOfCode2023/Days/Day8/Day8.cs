namespace AdventOfCode2023.Days.Day8
{
    internal abstract class Day8
    {
        internal string Instructions = string.Empty;
        internal Dictionary<string, Tuple<string, string>> Direction;
        internal const string EndingNode = "ZZZ";

        internal Day8(string filePath)
        {
            ReadDataFile(filePath);
        }

        internal string Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
            return result;
        }

        private void ReadDataFile(string filePath)
        {
            Direction = new Dictionary<string, Tuple<string, string>>();
            var rows = File.ReadLines(filePath).ToList();
            Instructions = rows[0];

            for (int i = 2; i < rows.Count; i++)
            {
                var withoutSymbols = rows[i].Replace(" = (", ",").Replace(" ", "").Replace(")", "");
                var row = withoutSymbols.Split(',');

                Direction.Add(row[0], new Tuple<string, string>(row[1], row[2]));
            }
        }

        internal abstract string Calculate();
    }
}
