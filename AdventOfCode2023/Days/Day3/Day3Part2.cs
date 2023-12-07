namespace AdventOfCode2023.Days.Day3
{
    internal class Day3Part2 : Day3
    {
        internal Day3Part2(string filePath) : base(filePath)
        {
        }

        internal override int Calculate()
        {
            var result = 0;
            foreach (var gear in Gears)
            {
                List<int> closeNumbers = GetCloseNumbers(gear);
                if (closeNumbers.Count == 2)
                    result += closeNumbers.Aggregate((a, x) => a * x);
            }

            return result;
        }

        private List<int> GetCloseNumbers(PartNumber gear)
        {
            var allCloseNumbers = new List<int>();
            List<int> closeBelowNumbers = CloseBelowNumbers(gear);
            List<int> closeAboveNumbers = CloseAboveNumbers(gear);
            List<int> closeLeftNumbers = CloseLeftNumbers(gear);
            List<int> closeRightNumbers = CloseRightNumbers(gear);

            allCloseNumbers.AddRange(closeBelowNumbers);
            allCloseNumbers.AddRange(closeAboveNumbers);
            allCloseNumbers.AddRange(closeRightNumbers);
            allCloseNumbers.AddRange(closeLeftNumbers);
            return allCloseNumbers;
        }

        private List<int> CloseAboveNumbers(PartNumber gear)
        {
            return UnfinishedMachineParts.Where(m =>
                m.RowFrom == gear.RowFrom - 1 && gear.ColumnFrom >= m.ColumnFrom - 1 && gear.ColumnTo <= m.ColumnTo + 1).Select(m => (int)m.Number!).ToList();
        }

        private List<int> CloseBelowNumbers(PartNumber gear)
        {
            return UnfinishedMachineParts.Where(m =>
                m.RowFrom == gear.RowFrom + 1 && gear.ColumnFrom >= m.ColumnFrom - 1 && gear.ColumnTo <= m.ColumnTo + 1).Select(m => (int)m.Number!).ToList();
        }

        private List<int> CloseRightNumbers(PartNumber gear)
        {
            return UnfinishedMachineParts.Where(m => m.RowFrom == gear.RowFrom && m.ColumnFrom - 1 == gear.ColumnFrom).Select(m => (int)m.Number!).ToList();
        }

        private List<int> CloseLeftNumbers(PartNumber gear)
        {
            return UnfinishedMachineParts.Where(m => m.RowFrom == gear.RowFrom && m.ColumnTo + 1 == gear.ColumnFrom).Select(m => (int)m.Number!).ToList();
        }
    }
}
