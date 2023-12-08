using BigInteger = Extreme.Mathematics.BigInteger;

namespace AdventOfCode2023.Days.Day8
{
    internal class Day8Part2 : Day8
    {
        internal Day8Part2(string filePath) : base(filePath)
        {
        }

        private char GetActiveInstruction(ref string currentInstructions)
        {
            var tempInstruction = currentInstructions[0];
            currentInstructions = currentInstructions.Remove(0, 1);

            if (currentInstructions.Length == 0)
                currentInstructions = Instructions;

            return tempInstruction;
        }

        internal override string Calculate()
        {
            var activeNodes = Direction.Where(m => m.Key.EndsWith("A")).Select(m => m.Key).ToList();
            var allNodes = new Dictionary<int, List<NodesWithZ>>();
            for (var index = 0; index < activeNodes.Count; index++)
            {
                var currentInstructions = Instructions;
                long turnsTaken = 0;
                var activeNode = activeNodes[index];
                var nodesWithZ = new List<NodesWithZ>();
                while (true)
                {
                    turnsTaken++;
                    var activeInstruction = GetActiveInstruction(ref currentInstructions);

                    activeNode = activeInstruction == 'L' ? Direction[activeNode].Item1 : Direction[activeNode].Item2;
                    if (!activeNode.EndsWith("Z"))
                        continue;

                    if (nodesWithZ.Any(m => m.InstructionsLeft == currentInstructions && m.Node == activeNode))
                    {
                        allNodes.Add(index, nodesWithZ);
                        break;
                    }

                    nodesWithZ.Add(new NodesWithZ
                    {
                        InstructionsLeft = currentInstructions,
                        Iteration = turnsTaken,
                        Node = activeNode
                    });
                }
            }

            var result = FindFirstTimeAllCanMeet(allNodes);

            return result.ToString();
        }

        private BigInteger FindFirstTimeAllCanMeet(Dictionary<int, List<NodesWithZ>> distinctNodes)
        {
            BigInteger result = 1;
            foreach (var distinctNode in distinctNodes)
            {
                var iteration = distinctNode.Value.First().Iteration;
                result = BigInteger.LeastCommonMultiple(result, iteration);
            }

            return result;
        }
    }
}