namespace AdventOfCode2023.Days.Day3
{
    internal class Day3Part1 : Day3
    {
        internal Day3Part1(string filePath) : base(filePath)
        {
        }

        internal override int Calculate()
        {
            var result = 0;
            foreach (var unfinishedMachinePart in UnfinishedMachineParts)
            {
                if (IsCloseToSymbol(unfinishedMachinePart))
                    result += (int)unfinishedMachinePart.Number!;
            }
            return result;
        }

        private bool IsCloseToSymbol(PartNumber unfinishedMachinePart)
        {
            bool isSymbolBelow = IsSymbolBelow(unfinishedMachinePart);
            bool isSymbolAbove = IsSymbolAbove(unfinishedMachinePart);
            bool isSymbolOnLeft = IsSymbolOnLeft(unfinishedMachinePart);
            bool isSymbolOnRight = IsSymbolOnRight(unfinishedMachinePart);
            return isSymbolOnRight || isSymbolAbove || isSymbolBelow || isSymbolOnLeft;

        }

        private bool IsSymbolOnRight(PartNumber unfinishedMachinePart)
        {
            return SymbolParts.Any(m =>
                    m.RowFrom == unfinishedMachinePart.RowFrom && m.ColumnFrom == unfinishedMachinePart.ColumnTo + 1);
        }

        private bool IsSymbolOnLeft(PartNumber unfinishedMachinePart)
        {
            return SymbolParts.Any(m =>
                m.RowFrom == unfinishedMachinePart.RowFrom && m.ColumnFrom == unfinishedMachinePart.ColumnFrom - 1);
        }

        private bool IsSymbolAbove(PartNumber unfinishedMachinePart)
        {
            return SymbolParts.Any(m =>
                m.RowFrom == unfinishedMachinePart.RowFrom - 1 && m.ColumnFrom >= unfinishedMachinePart.ColumnFrom - 1 && m.ColumnFrom <= unfinishedMachinePart.ColumnTo + 1);
        }

        private bool IsSymbolBelow(PartNumber unfinishedMachinePart)
        {
            return SymbolParts.Any(m =>
                m.RowFrom == unfinishedMachinePart.RowFrom + 1 && m.ColumnFrom >= unfinishedMachinePart.ColumnFrom - 1 && m.ColumnFrom <= unfinishedMachinePart.ColumnTo + 1);
        }
    }
}
