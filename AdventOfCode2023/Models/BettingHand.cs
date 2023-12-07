namespace AdventOfCode2023.Models
{
    internal class BettingHand
    {
        public readonly int Id;
        public readonly string Hand;
        public readonly long BettingAmount;
        public int HandScore { get; set; } = 0;
        public long HandInNumbers { get; set; } = 0;

        public BettingHand(int id, string hand, long bettingAmount)
        {
            Id = id;
            Hand = hand;
            BettingAmount = bettingAmount;
        }
    }
}
