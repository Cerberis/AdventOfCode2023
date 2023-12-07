namespace AdventOfCode2023.Days.Day8
{
    internal abstract class Day8
    {
   

        internal Day8(string filePath)
        {
            ReadDataFile(filePath);
        }

        internal string Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
            return result.ToString();
        }
        


        //        Five of a kind, where all five cards have the same label: AAAAA
        //Four of a kind, where four cards have the same label and one card has a different label: AA8AA
        //Full house, where three cards have the same label, and the remaining two cards share a different label: 23332
        //Three of a kind, where three cards have the same label, and the remaining two cards are each different from any other card in the hand: TTT98
        //Two pair, where two cards share one label, two other cards share a second label, and the remaining card has a third label: 23432
        //One pair, where two cards share one label, and the other three cards have a different label from the pair and each other: A23A4
        //High card, where all cards' labels are distinct: 23456
        //Hands are primarily ordered based on type; for example, every full house is stronger than any three of a kind.

        //If two hands have the same type, a second ordering rule takes effect.Start by comparing the first card in each hand. If these cards are different, the hand with the stronger first card is considered stronger. If the first card in each hand have the same label, however, then move on to considering the second card in each hand. If they differ, the hand with the higher second card wins; otherwise, continue with the third card in each hand, then the fourth, then the fifth.

        //So, 33332 and 2AAAA are both four of a kind hands, but 33332 is stronger because its first card is stronger.Similarly, 77888 and 77788 are both a full house, but 77888 is stronger because its third card is stronger (and both hands have the same first and second card).


        private void ReadDataFile(string filePath)
        {
            //Hands = new List<BettingHand>();
            //var rows = File.ReadLines(filePath).ToList();
            //for (int i = 0; i < rows.Count; i++)
            //{
            //    var row = rows[i].Split(' ');
            //    var hand = new BettingHand(i + 1, row[0], long.Parse(row[1]));
            //    string handAsNumbers = GetHandAsNumbers(hand.Hand);
            //    hand.HandInNumbers = handAsNumbers;
            //    Hands.Add(hand);
            //}
        }
        

        internal abstract long Calculate();

       
    }
}
