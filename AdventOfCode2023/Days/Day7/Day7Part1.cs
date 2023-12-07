namespace AdventOfCode2023.Days.Day7
{
    internal class Day7Part1 : Day7
    {
        internal Day7Part1(string filePath) : base(filePath)
        {
        }

        internal override long Calculate()
        {
            long totalScore = 0;
            var orderedHands = Hands.OrderByDescending(m => m.HandScore).ThenByDescending(m => m.HandInNumbers).ToList();
            int currentScore = Hands.Count;

            foreach (var orderedHand in orderedHands)
            {
                var handScore = orderedHand.BettingAmount * currentScore;
                totalScore += handScore;
                currentScore--;
            }
            return totalScore;
        }

        internal override long GetHandAsNumbers(string hand)
        {
            var newHand = string.Empty;
            foreach (var card in hand)
            {
                if (card == 'T')
                    newHand += "10";
                else if (card == 'J')
                    newHand += "11";
                else if (card == 'Q')
                    newHand += "12";
                else if (card == 'K')
                    newHand += "13";
                else if (card == 'A')
                    newHand += "14";
                else
                    newHand += "0" + card;
            }

            return long.Parse(newHand);
        }

        internal override bool HasPairs(string hand, int pairsNeeded)
        {
            var data = hand.GroupBy(m => m)
                .Select(group => new
                {
                    Card = group.Key,
                    Count = group.Count()
                }).ToArray();

            return data.Count(m => m.Count == 2) == pairsNeeded;
        }

        internal override bool HasGroupOf(string hand, int groupOfNeeded)
        {
            var data = hand.GroupBy(m => m)
                .Select(group => new
                {
                    Card = group.Key,
                    Count = group.Count()
                }).ToArray();
            return data.Any(m => m.Count == groupOfNeeded);
        }
    }
}
