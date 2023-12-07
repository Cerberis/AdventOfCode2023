namespace AdventOfCode2023.Days.Day1
{
    internal abstract class Day1
    {
        internal readonly List<string> InputData;
        internal Day1(string filePath)
        {
            InputData = FileReaders.ReadDataFileAsStringList(filePath);
        }

        internal void Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
        }

        internal abstract int Calculate();

        internal char GetLastDigit(string item)
        {
            return item.Last(char.IsDigit);
        }

        internal char GetFirstDigit(string item)
        {
            return item.First(char.IsDigit);
        }

        internal int RowDigitResult(string item)
        {
            string digits = string.Empty;
            digits += GetFirstDigit(item);
            digits += GetLastDigit(item);
            var digit = int.Parse(digits);
            return digit;
        }
    }
}
