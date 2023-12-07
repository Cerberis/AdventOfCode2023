namespace AdventOfCode2023.Days.Day7
{
    internal abstract class Day7
    {
        internal List<BettingHand> Hands;

        internal Day7(string filePath)
        {
            ReadDataFile(filePath);
        }

        internal string Execute()
        {
            GetCardScores();
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
            return result.ToString();
        }

        private void ReadDataFile(string filePath)
        {
            Hands = new List<BettingHand>();
            var rows = File.ReadLines(filePath).ToList();
            for (int i = 0; i < rows.Count; i++)
            {
                var row = rows[i].Split(' ');
                var hand = new BettingHand(i + 1, row[0], long.Parse(row[1]));
                long handAsNumbers = GetHandAsNumbers(hand.Hand);
                hand.HandInNumbers = handAsNumbers;
                Hands.Add(hand);
            }
        }

        internal virtual void GetCardScores()
        {
            foreach (var bettingHand in Hands)
            {
                GetCardScore(bettingHand);
            }
        }

        internal virtual void GetCardScore(BettingHand bettingHand)
        {
            if (UniqueCards(bettingHand.Hand, 1))
            {
                bettingHand.HandScore = 99;
                return;
            }

            if (HasGroupOf(bettingHand.Hand, 4))
            {
                bettingHand.HandScore = 98;
                return;
            }

            if (HasFullHouse(bettingHand.Hand))
            {
                bettingHand.HandScore = 97;
                return;
            }

            if (HasGroupOf(bettingHand.Hand, 3))
            {
                bettingHand.HandScore = 96;
                return;
            }

            if (HasPairs(bettingHand.Hand, 2))
            {
                bettingHand.HandScore = 95;
                return;
            }

            if (HasPairs(bettingHand.Hand, 1))
            {
                bettingHand.HandScore = 94;
                return;
            }

            if (UniqueCards(bettingHand.Hand, 5))
            {
                bettingHand.HandScore = 93;
            }
        }

        internal abstract long GetHandAsNumbers(string hand);

        internal abstract long Calculate();

        internal virtual bool UniqueCards(string hand, int uniqueCardsNeeded)
        {
            return hand.Distinct().Count() == uniqueCardsNeeded;
        }

        internal virtual bool HasFullHouse(string hand)
        {
            var data = hand.GroupBy(m => m)
                .Select(group => new
                {
                    Card = group.Key,
                    Count = group.Count()
                }).ToArray();

            return data.Any(m => m.Count == 2) && data.Any(m => m.Count == 3);
        }

        internal abstract bool HasPairs(string hand, int pairsNeeded);
        internal abstract bool HasGroupOf(string hand, int groupOfNeeded);
    }
}
