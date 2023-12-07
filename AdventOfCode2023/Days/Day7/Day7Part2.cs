namespace AdventOfCode2023.Days.Day7
{
    internal class Day7Part2 : Day7
    {
        internal Day7Part2(string filePath) : base(filePath)
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
                    newHand += "01";
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

        internal override void GetCardScore(BettingHand bettingHand)
        {
            if (!bettingHand.Hand.Contains("J"))
            {
                base.GetCardScore(bettingHand);
            }
            else
            {
                GetHighestCardHand(bettingHand);
            }
        }

        private void GetHighestCardHand(BettingHand bettingHand)
        {
            var jokerCount = bettingHand.Hand.Count(m => m == 'J');

            if (jokerCount >= 4 || HasGroupOf(bettingHand.Hand, 5 - jokerCount))
            {
                bettingHand.HandScore = 99;
                return;
            }

            if (jokerCount == 3 || HasGroupOf(bettingHand.Hand, 4 - jokerCount))
            {
                bettingHand.HandScore = 98;
                return;
            }

            if (jokerCount == 1 && HasPairs(bettingHand.Hand, 2))
            {
                bettingHand.HandScore = 97;
                return;
            }

            if (jokerCount == 2 || (jokerCount == 1 && HasPairs(bettingHand.Hand, 1)))
            {
                bettingHand.HandScore = 96;
                return;
            }

            if (jokerCount == 1)
            {
                bettingHand.HandScore = 94;
                return;
            }

            var a = 1;
        }

        internal override bool HasPairs(string hand, int pairsNeeded)
        {
            var data = hand.Where(m => m != 'J').GroupBy(m => m)
                .Select(group => new
                {
                    Card = group.Key,
                    Count = group.Count()
                }).ToArray();

            return data.Count(m => m.Count == 2) == pairsNeeded;
        }

        internal override bool HasGroupOf(string hand, int groupOfNeeded)
        {
            var data = hand.Where(m => m != 'J').GroupBy(m => m)
                .Select(group => new
                {
                    Card = group.Key,
                    Count = group.Count()
                }).ToArray();
            return data.Any(m => m.Count == groupOfNeeded);
        }
    }
}