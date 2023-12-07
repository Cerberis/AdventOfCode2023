namespace AdventOfCode2023.Models
{
    internal class PartNumber
    {
        public int? Number;
        public int RowFrom;
        public int RowTo;
        public int ColumnFrom;
        public int ColumnTo;
        public PartNumber(int? number, int rowFrom, int rowTo, int columnFrom, int columnTo)
        {
            Number = number;
            RowFrom = rowFrom;
            RowTo = rowTo;
            ColumnFrom = columnFrom;
            ColumnTo = columnTo;
        }
    }
}
