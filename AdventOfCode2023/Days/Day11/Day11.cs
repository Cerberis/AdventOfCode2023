using System.Drawing;

namespace AdventOfCode2023.Days.Day11
{
    internal abstract class Day11
    {
        internal int StarMultiplierValue;
        internal List<List<char>> Grid;
        internal Tuple<int, int> StartingPosition;

        internal Day11(string filePath)
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
            Grid = FileReaders.ReadDataFileAsCharMatrix(filePath);
        }

        internal string Calculate()
        {
            DublicateEmptyColumns();
            DublicateEmptyRows();
            DrawUniverse();
            List<Point> starLocations = GetStarLocations();
            var result = CalculateDistance(starLocations);
            return result.ToString();
        }

        void DublicateEmptyRows()
        {
            for (int i = 0; i < Grid.Count; i++)
            {
                if (Grid[i].All(m => m == '.' || m == 'x'))
                {
                    for (int columnIndex = 0; columnIndex < Grid[i].Count; columnIndex++)
                    {
                        Grid[i][columnIndex] = 'x';
                    };
                }
            }
        }

        void DublicateEmptyColumns()
        {
            for (int i = 0; i < Grid.First().Count; i++)
            {
                if (Grid.Select(m => m[i]).All(m => m == '.'))
                {
                    Grid.ForEach(m => m[i] = 'x');
                }
            }
        }

        void DrawUniverse()
        {
            Console.WriteLine("");
            foreach (var row in Grid)
            {
                Console.WriteLine("");
                foreach (var column in row)
                {
                    if (column == '.')
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    else
                        Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(column);
                }
            }
        }

        long CalculateDistance(List<Point> starLocations)
        {
            long result = 0;
            for (int pointIndex = 0; pointIndex < starLocations.Count; pointIndex++)
            {
                for (int nextPointIndex = pointIndex + 1; nextPointIndex < starLocations.Count; nextPointIndex++)
                {
                    var yDistance = GetYDistance(starLocations[pointIndex].Y, starLocations[nextPointIndex].Y);
                    var xDistance = GetXDistance(starLocations[pointIndex].X, starLocations[nextPointIndex].X);
                    long distanceBetweenStars = xDistance + yDistance;
                    //Console.WriteLine($"{starLocations[pointIndex].Y}x{starLocations[pointIndex].X} {starLocations[nextPointIndex].Y}x{starLocations[nextPointIndex].X} : {distanceBetweenStars}");
                    result += distanceBetweenStars;
                }
            }
            return result;
        }

        long GetYDistance(int y1, int y2)
        {
            var startingPoint = y1 > y2 ? y2 : y1;
            var endingPoint = y1 > y2 ? y1 : y2;
            long distance = 0;
            if (startingPoint == endingPoint)
                return distance;

            for (int i = startingPoint + 1; i < endingPoint; i++)
            {
                if (Grid[i][0] == 'x')
                    distance += StarMultiplierValue;
                else
                    distance++;
            }
            distance++;

            return distance;
        }

        long GetXDistance(int x1, int x2)
        {
            var startingPoint = x1 > x2 ? x2 : x1;
            var endingPoint = x1 > x2 ? x1 : x2;
            long distance = 0;
            if (startingPoint == endingPoint)
                return distance;

            for (int i = startingPoint + 1; i < endingPoint; i++)
            {
                if (Grid[0][i] == 'x')
                    distance += StarMultiplierValue;
                else
                    distance++;
            }
            distance++;

            return distance;
        }

        List<Point> GetStarLocations()
        {
            var result = new List<Point>();
            for (int rowIndex = 0; rowIndex < Grid.Count; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < Grid.First().Count(); columnIndex++)
                {
                    if (Grid[rowIndex][columnIndex] == '#')
                        result.Add(new Point(columnIndex, rowIndex));
                }
            }
            return result;
        }
    }
}
