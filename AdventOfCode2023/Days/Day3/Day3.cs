namespace AdventOfCode2023.Days.Day3
{
    internal abstract class Day3
    {
        internal List<PartNumber> UnfinishedMachineParts;
        internal List<PartNumber> SymbolParts;
        internal List<PartNumber> Gears;
        internal readonly char IgnoreSymbol = '.';
        internal readonly char GearSymbol = '*';

        internal Day3(string filePath)
        {
            ReadPartNumbers(filePath);
        }

        internal string Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
            return result.ToString();
        }

        internal abstract int Calculate();

        private void ReadPartNumbers(string filePath)
        {

            UnfinishedMachineParts = new List<PartNumber>();
            SymbolParts = new List<PartNumber>();
            Gears = new List<PartNumber>();
            var fileRows = File.ReadLines(filePath).ToList();
            int columnCount = fileRows.First().Length;
            for (int rowIndex = 0; rowIndex < fileRows.Count; rowIndex++)
            {
                var currentDigit = string.Empty;
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    if (char.IsDigit(fileRows[rowIndex][columnIndex]))
                    {
                        currentDigit += fileRows[rowIndex][columnIndex];
                        continue;
                    }

                    if (!string.IsNullOrEmpty(currentDigit))
                    {
                        UnfinishedMachineParts.Add(new PartNumber(int.Parse(currentDigit), rowIndex, rowIndex, columnIndex - currentDigit.Length, columnIndex - 1));
                        currentDigit = string.Empty;
                    }

                    if (fileRows[rowIndex][columnIndex] == IgnoreSymbol)
                        continue;

                    if (fileRows[rowIndex][columnIndex] == GearSymbol)
                        Gears.Add(new PartNumber(null, rowIndex, rowIndex, columnIndex, columnIndex));

                    SymbolParts.Add(new PartNumber(null, rowIndex, rowIndex, columnIndex, columnIndex));
                }

                if (!string.IsNullOrEmpty(currentDigit))
                    UnfinishedMachineParts.Add(new PartNumber(int.Parse(currentDigit), rowIndex, rowIndex, columnCount - currentDigit.Length, columnCount - 1));
            }
        }
    }
}
