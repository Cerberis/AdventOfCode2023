namespace AdventOfCode2023.Days.Day4
{
    internal abstract class Day4
    {
        internal List<ScratchCard> ScratchCards;

        internal Day4(string filePath)
        {
            ReadScratchCards(filePath);
        }

        internal string Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
            return result.ToString();
        }

        internal abstract int Calculate();

        private void ReadScratchCards(string filePath)
        {

            ScratchCards = new List<ScratchCard>
            {
                new(0, new List<int>(), new List<int>())
            };
            foreach(var row in File.ReadLines(filePath) ) 
            {
               var splitRow = row.Split(':', '|');
               var cardId =int.Parse(splitRow[0].Replace("Card ", ""));
               List<int> winningNumbers = splitRow[1].ToIntList(' ');
               List<int> playingNumbers = splitRow[2].ToIntList(' ');
               ScratchCards.Add(new ScratchCard(cardId, winningNumbers, playingNumbers));
            }
        }
    }
}
