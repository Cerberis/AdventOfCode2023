namespace AdventOfCode2023.Days.Day1
{
    internal class Day1Part1 : Day1
    {
        internal Day1Part1(string filePath) : base(filePath)
        {
        }

        internal override int Calculate()
        {
            var sumOfRowDigits = 0;
            foreach (var item in InputData)
            {
                sumOfRowDigits += RowDigitResult(item);
            }

            return sumOfRowDigits;
        }
    }
}
