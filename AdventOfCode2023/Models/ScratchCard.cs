namespace AdventOfCode2023.Models
{
    internal class ScratchCard
    {
        internal readonly int Id;
        internal readonly List<int> WinningNumbers;
        internal readonly List<int> PlayingNumbers;

        public ScratchCard(int id, List<int> winningNumbers, List<int> playingNumbers)
        {
            Id = id;
            WinningNumbers = winningNumbers;
            PlayingNumbers = playingNumbers;
        }
    }
}
