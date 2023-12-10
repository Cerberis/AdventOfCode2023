namespace AdventOfCode2023.Days.Day10
{
    internal class Day10Part1 : Day10
    {
        internal Day10Part1(string filePath) : base(filePath)
        {
        }

        internal override string Calculate()
        {
            var firstMove = GetFirstMove();

            var moveList = GetMoves(firstMove);
            var movesTaken = (moveList.Count / 2) + moveList.Count % 2;

            return movesTaken.ToString();
        }


    }
}
