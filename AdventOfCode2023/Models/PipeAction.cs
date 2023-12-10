namespace AdventOfCode2023.Models
{
    internal class PipeAction
    {
        internal readonly ConnectingPipes Pipe;
        internal readonly int RowIndex;
        internal readonly int ColumnIndex;

        public PipeAction(ConnectingPipes pipe, int rowIndex, int columnIndex)
        {
            Pipe = pipe;
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }
    }
}
