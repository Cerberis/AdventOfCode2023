namespace AdventOfCode2023.Days.Day8
{
    internal class Day8Part1 : Day8
    {
        internal Day8Part1(string filePath) : base(filePath)
        {
        }

        internal override string Calculate()
        {
            long turnsTaken = 0;
            var currentNode = "AAA";
            var currentInstructions = Instructions;
            while (currentNode != EndingNode)
            {
                if (currentInstructions.Length == 0)
                    currentInstructions = Instructions;

                currentNode = currentInstructions[0] == 'L' ? Direction[currentNode].Item1 : Direction[currentNode].Item2;

                currentInstructions = currentInstructions.Remove(0, 1);
                turnsTaken++;
            }

            return turnsTaken.ToString();
        }
    }
}
