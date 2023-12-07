namespace AdventOfCode2023.Days.Day4
{
    internal class Day4Part2 : Day4
    {
        private Dictionary<int, int> ScratchCardsUsed;
        internal Day4Part2(string filePath) : base(filePath)
        {
            ScratchCardsUsed = new Dictionary<int, int>();
        }

        internal override int Calculate()
        {
            int result = 0;
            for (int cardId = ScratchCards.Count - 1; 0 < cardId; cardId--)
            {
                var timesMatched = GetTimesMatched(cardId);
                int cardsGenerated = CalculateHowMuchCardsGenerate(cardId, timesMatched);
                result += cardsGenerated;
            }
            result += ScratchCards.Count - 1;
            return result;
        }

        private int CalculateHowMuchCardsGenerate(int cardId, int timesMatched)
        {
            int cardsUsed = 0;
            ;
            for (var startingCardId = cardId + timesMatched; cardId < startingCardId; startingCardId--)
            {
                cardsUsed += ScratchCardsUsed[startingCardId];
            }

            ScratchCardsUsed.TryAdd(cardId, cardsUsed + 1);
            return cardsUsed;
        }

        private int GetTimesMatched(int cardId)
        {
            var timesMatched = 0;
            var scratchCard = ScratchCards[cardId];
            foreach (var playingNumber in scratchCard.PlayingNumbers)
            {
                if (scratchCard.WinningNumbers.Contains(playingNumber))
                    timesMatched++;
            }

            return timesMatched;
        }
    }
}

