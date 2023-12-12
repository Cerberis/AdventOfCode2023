namespace AdventOfCode2023.Days.Day12
{
    internal abstract class Day12
    {
        internal List<List<ConnectingPipes>> Grid;
        internal Tuple<int, int> StartingPosition;

        internal Day12(string filePath)
        {
            ReadDataFile(filePath);
        }

        internal string Execute()
        {
            var result = Calculate();

            Console.WriteLine("");
            Console.WriteLine($"Result: {result}");
            return result;
        }

        private void ReadDataFile(string filePath)
        {
            Grid = new List<List<ConnectingPipes>>();
            var rows = File.ReadAllLines(filePath).ToList();
            for (int rowIndex = 0; rowIndex < rows.Count; rowIndex++)
            {
                var pipeRow = new List<ConnectingPipes>();
             

                Grid.Add(pipeRow);
            }
        }

        internal abstract string Calculate();


    }
}
