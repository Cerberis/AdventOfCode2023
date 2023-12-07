namespace AdventOfCode2023.Days.Day4
{
    internal class Day4Part1 : Day4
    {
        internal Day4Part1(string filePath) : base(filePath)
        {
        }

        internal override int Calculate()
        {
            var result = 0;
            foreach (var scratchCard in ScratchCards)
            {
                int score = CalculateCardScore(scratchCard);
                result += score;
            }
            return result;
        }

        private int CalculateCardScore(ScratchCard scratchCard)
        {
            var score = 0;
            foreach (var playingNumber in scratchCard.PlayingNumbers)
            {
                if (!scratchCard.WinningNumbers.Contains(playingNumber))
                    continue;

                if (score == 0)
                {
                    score = 1;
                    continue;
                }
                score *= 2;
            }

            return score;
        }
    }
}
