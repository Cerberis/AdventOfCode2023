using System.Collections.Generic;
using System.ComponentModel;

namespace AdventOfCode2023.Days.Day10
{
    internal abstract class Day10
    {
        internal List<List<ConnectingPipes>> Grid;
        internal Tuple<int, int> StartingPosition;

        internal Day10(string filePath)
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
                for (var colIndex = 0; colIndex < rows[rowIndex].Length; colIndex++)
                {
                    var col = rows[rowIndex][colIndex];
                    var mappedPipe = MapSymbolToValue(col);
                    if (mappedPipe == ConnectingPipes.StartingPosition)
                        StartingPosition = new Tuple<int, int>(rowIndex, colIndex);
                    pipeRow.Add(mappedPipe);
                }

                Grid.Add(pipeRow);
            }
        }

        internal abstract string Calculate();

        static ConnectingPipes MapSymbolToValue(char symbol)
        {
            return symbol switch
            {
                '.' => ConnectingPipes.Ground,
                'S' => ConnectingPipes.StartingPosition,
                '-' => ConnectingPipes.EastWest,
                'L' => ConnectingPipes.NorthEast,
                '|' => ConnectingPipes.NorthSouth,
                'J' => ConnectingPipes.NorthWest,
                'F' => ConnectingPipes.SouthEast,
                '7' => ConnectingPipes.SouthWest,
                _ => throw new InvalidEnumArgumentException("Symbol not in pipe list")
            };
        }

        internal static char MapPipeToSymbol(ConnectingPipes pipe)
        {
            return pipe switch
            {
                ConnectingPipes.Ground => '.',
                ConnectingPipes.StartingPosition => 'S',
                ConnectingPipes.EastWest => '-',
                ConnectingPipes.NorthEast => 'L',
                ConnectingPipes.NorthSouth => '|',
                ConnectingPipes.NorthWest => 'J',
                ConnectingPipes.SouthEast => 'F',
                ConnectingPipes.SouthWest => '7',
                ConnectingPipes.OutOfPipeArea => 'O',
                ConnectingPipes.Test => 'X',
                _ => throw new InvalidEnumArgumentException("Symbol not in pipe list")
            };
        }

        internal List<PipeAction> GetMoves(Tuple<int, int> firstMove)
        {

            //Makes first move to have last position values
            var lastPosition = StartingPosition;
            var currentPosition = firstMove;
            var currentMove = Grid[firstMove.Item1][firstMove.Item2];

            var moveList = new List<PipeAction>
            {
                new (ConnectingPipes.StartingPosition, StartingPosition.Item1, StartingPosition.Item2),
                new(currentMove, firstMove.Item1, firstMove.Item2)
            };

            while (true)
            {
                var nextMove = GetNextMove(lastPosition, currentPosition);
                currentMove = Grid[nextMove.Item1][nextMove.Item2];

                if (currentMove == ConnectingPipes.StartingPosition)
                    break;

                moveList.Add(new(currentMove, nextMove.Item1, nextMove.Item2));
                lastPosition = currentPosition;
                currentPosition = nextMove;
            }
            return moveList;
        }

        //internal List<ConnectingPipes> GetMoves(Tuple<int, int> firstMove)
        //{

        //    //Makes first move to have last position values
        //    var lastPosition = StartingPosition;
        //    var currentPosition = firstMove;
        //    var currentMove = Grid[firstMove.Item1][firstMove.Item2];

        //    var moveList = new List<ConnectingPipes> { currentMove };

        //    while (true)
        //    {
        //        var nextMove = GetNextMove(lastPosition, currentPosition);
        //        currentMove = Grid[nextMove.Item1][nextMove.Item2];

        //        if (currentMove == ConnectingPipes.StartingPosition)
        //            break;

        //        moveList.Add(currentMove);
        //        lastPosition = currentPosition;
        //        currentPosition = nextMove;
        //    }
        //    return moveList;
        //}

        internal Tuple<int, int> GetFirstMove()
        {
            var lastColumnIndex = Grid.First().Count - 1;
            var lastRowIndex = Grid.Count - 1;
            //Top left Corner
            if (StartingPosition.Item1 == 0 && StartingPosition.Item2 == 0)
                return Tuple.Create(0, 1);

            //Top right corner
            if (StartingPosition.Item1 == 0 && StartingPosition.Item2 == lastColumnIndex)
                return Tuple.Create(1, lastColumnIndex);

            //Bottom right corner
            if (StartingPosition.Item1 == lastRowIndex && StartingPosition.Item2 == lastColumnIndex)
                return Tuple.Create(lastRowIndex, lastColumnIndex - 1);

            //Bottom left corner
            if (StartingPosition.Item1 == lastRowIndex && StartingPosition.Item2 == 0)
                return Tuple.Create(lastRowIndex - 1, 0);

            //Top row
            if (StartingPosition.Item1 == 0)
            {
                if (Grid[0][StartingPosition.Item2 + 1] is ConnectingPipes.EastWest
                    or ConnectingPipes.SouthWest)
                    return Tuple.Create(0, StartingPosition.Item2 + 1);

                if (Grid[1][StartingPosition.Item2] is ConnectingPipes.NorthSouth
                    or ConnectingPipes.NorthEast
                    or ConnectingPipes.NorthWest)
                    return Tuple.Create(1, StartingPosition.Item2);
            }

            //Right column
            if (StartingPosition.Item2 == lastColumnIndex)
            {
                if (Grid[StartingPosition.Item1 + 1][lastColumnIndex] is ConnectingPipes.NorthSouth
                    or ConnectingPipes.NorthWest)
                    return Tuple.Create(lastRowIndex + 1, lastColumnIndex);

                if (Grid[StartingPosition.Item1][lastColumnIndex - 1] is ConnectingPipes.EastWest
                    or ConnectingPipes.NorthEast
                    or ConnectingPipes.SouthEast)
                    return Tuple.Create(StartingPosition.Item1, lastColumnIndex - 1);
            }

            //Bottom row
            if (StartingPosition.Item1 == lastRowIndex)
            {
                if (Grid[lastRowIndex][StartingPosition.Item2 - 1] is ConnectingPipes.EastWest
                    or ConnectingPipes.NorthEast)
                    return Tuple.Create(lastRowIndex, StartingPosition.Item2 - 1);

                if (Grid[lastRowIndex - 1][StartingPosition.Item2] is ConnectingPipes.NorthSouth
                    or ConnectingPipes.SouthEast
                    or ConnectingPipes.SouthWest)
                    return Tuple.Create(lastRowIndex - 1, StartingPosition.Item2);
            }

            //Left column
            if (StartingPosition.Item2 == 0)
            {
                if (Grid[StartingPosition.Item1 - 1][0] is ConnectingPipes.NorthSouth
                    or ConnectingPipes.SouthEast)
                    return Tuple.Create(StartingPosition.Item1 - 1, 0);

                if (Grid[StartingPosition.Item1][1] is ConnectingPipes.EastWest
                    or ConnectingPipes.NorthWest
                    or ConnectingPipes.SouthWest)
                    return Tuple.Create(StartingPosition.Item1, 1);
            }

            //Middle -> right
            if (Grid[StartingPosition.Item1][StartingPosition.Item2 + 1] is ConnectingPipes.NorthWest
                or ConnectingPipes.SouthWest)
                return Tuple.Create(StartingPosition.Item1, StartingPosition.Item2 + 1);

            if (Grid[StartingPosition.Item1][StartingPosition.Item2 + 1] is ConnectingPipes.EastWest &&
                StartingPosition.Item2 + 1 != lastColumnIndex)
                return Tuple.Create(StartingPosition.Item1, StartingPosition.Item2 + 1);

            //Middle -> bottom
            if (Grid[StartingPosition.Item1 + 1][StartingPosition.Item2] is ConnectingPipes.NorthEast
                or ConnectingPipes.NorthWest)
                return Tuple.Create(StartingPosition.Item1 + 1, StartingPosition.Item2);

            if (Grid[StartingPosition.Item1 + 1][StartingPosition.Item2] is ConnectingPipes.NorthSouth &&
                StartingPosition.Item2 + 1 != lastRowIndex)
                return Tuple.Create(StartingPosition.Item1 + 1, StartingPosition.Item2);

            //Middle -> left
            if (Grid[StartingPosition.Item1][StartingPosition.Item2 - 1] is ConnectingPipes.NorthEast
                or ConnectingPipes.SouthEast)
                return Tuple.Create(StartingPosition.Item1, StartingPosition.Item2 - 1);

            if (Grid[StartingPosition.Item1][StartingPosition.Item2 - 1] is ConnectingPipes.EastWest &&
                StartingPosition.Item2 - 1 != 0)
                return Tuple.Create(StartingPosition.Item1, StartingPosition.Item2 - 1);

            //Middle -> top
            if (Grid[StartingPosition.Item1 - 1][StartingPosition.Item2] is ConnectingPipes.SouthEast
                or ConnectingPipes.SouthWest)
                return Tuple.Create(StartingPosition.Item1 - 1, StartingPosition.Item2);

            if (Grid[StartingPosition.Item1 - 1][StartingPosition.Item2] is ConnectingPipes.NorthSouth &&
                StartingPosition.Item1 - 1 != 0)
                return Tuple.Create(StartingPosition.Item1 - 1, StartingPosition.Item2);

            throw new Exception(
                $"Something went wrong with pipe at location {StartingPosition.Item1} {StartingPosition.Item2}");
        }

        internal Tuple<int, int> GetNextMove(Tuple<int, int> previousPosition, Tuple<int, int> currentPosition)
        {
            var lastColumnIndex = Grid.First().Count - 1;
            var lastRowIndex = Grid.Count - 1;

            //Top left Corner
            if (currentPosition.Item1 == 0 && currentPosition.Item2 == 0)
                return previousPosition.Item1 == 1 ? Tuple.Create(0, 1) : Tuple.Create(1, 0);

            //Top right corner
            if (currentPosition.Item1 == 0 && currentPosition.Item2 == lastColumnIndex)
                return previousPosition.Item1 == 0 ? Tuple.Create(1, lastColumnIndex) : Tuple.Create(0, lastColumnIndex - 1);

            //Bottom right corner
            if (currentPosition.Item1 == lastRowIndex && currentPosition.Item2 == lastColumnIndex)
                return previousPosition.Item1 == lastRowIndex ? Tuple.Create(lastRowIndex - 1, lastColumnIndex) : Tuple.Create(lastRowIndex, lastColumnIndex - 1);

            //Bottom left corner
            if (currentPosition.Item1 == lastRowIndex && currentPosition.Item2 == 0)
                return previousPosition.Item1 == lastRowIndex ? Tuple.Create(lastRowIndex - 1, 0) : Tuple.Create(lastRowIndex, 1);

            var currentPipe = Grid[currentPosition.Item1][currentPosition.Item2];

            //Top row
            if (currentPosition.Item1 == 0)
            {
                //From right
                if (previousPosition.Item2 == currentPosition.Item2 + 1)
                {
                    switch (currentPipe)
                    {
                        //To left
                        case ConnectingPipes.EastWest:
                            return Tuple.Create(currentPosition.Item1, currentPosition.Item2 - 1);
                        //To Bottom
                        case ConnectingPipes.SouthEast:
                            return Tuple.Create(currentPosition.Item1 + 1, currentPosition.Item2);
                    }
                }

                //From left
                if (previousPosition.Item2 == currentPosition.Item2 - 1)
                {
                    switch (currentPipe)
                    {
                        //To right
                        case ConnectingPipes.EastWest:
                            return Tuple.Create(currentPosition.Item1, currentPosition.Item2 + 1);
                        //To Bottom
                        case ConnectingPipes.SouthWest:
                            return Tuple.Create(currentPosition.Item1 + 1, currentPosition.Item2);
                    }
                }

                //From bottom
                if (previousPosition.Item1 == currentPosition.Item1 + 1)
                {
                    switch (currentPipe)
                    {
                        //To left
                        case ConnectingPipes.SouthWest:
                            return Tuple.Create(currentPosition.Item1, currentPosition.Item2 - 1);
                        //To right
                        case ConnectingPipes.SouthEast:
                            return Tuple.Create(currentPosition.Item1, currentPosition.Item2 + 1);
                    }
                }
            }

            //Right column
            if (currentPosition.Item2 == lastColumnIndex)
            {
                //From top
                if (previousPosition.Item1 == currentPosition.Item1 - 1)
                {
                    switch (currentPipe)
                    {
                        //To left
                        case ConnectingPipes.NorthWest:
                            return Tuple.Create(currentPosition.Item1, currentPosition.Item2 - 1);
                        //To Bottom
                        case ConnectingPipes.NorthSouth:
                            return Tuple.Create(currentPosition.Item1 + 1, currentPosition.Item2);
                    }
                }

                //From left
                if (previousPosition.Item2 == currentPosition.Item2 - 1)
                {
                    switch (currentPipe)
                    {
                        //To top
                        case ConnectingPipes.NorthWest:
                            return Tuple.Create(currentPosition.Item1 - 1, currentPosition.Item2);
                        //To Bottom
                        case ConnectingPipes.SouthWest:
                            return Tuple.Create(currentPosition.Item1 + 1, currentPosition.Item2);
                    }
                }

                //From bottom
                if (previousPosition.Item1 == currentPosition.Item1 + 1)
                {
                    switch (currentPipe)
                    {
                        //To left
                        case ConnectingPipes.SouthWest:
                            return Tuple.Create(currentPosition.Item1, currentPosition.Item2 - 1);
                        //To top
                        case ConnectingPipes.NorthSouth:
                            return Tuple.Create(currentPosition.Item1 - 1, currentPosition.Item2);
                    }
                }
            }

            //Bottom row
            if (currentPosition.Item1 == lastRowIndex)
            {
                //From right
                if (previousPosition.Item2 == currentPosition.Item2 + 1)
                {
                    switch (currentPipe)
                    {
                        //To left
                        case ConnectingPipes.EastWest:
                            return Tuple.Create(currentPosition.Item1, currentPosition.Item2 - 1);
                        //To top
                        case ConnectingPipes.NorthEast:
                            return Tuple.Create(currentPosition.Item1 - 1, currentPosition.Item2);
                    }
                }

                //From left
                if (previousPosition.Item2 == currentPosition.Item2 - 1)
                {
                    switch (currentPipe)
                    {
                        //To right
                        case ConnectingPipes.EastWest:
                            return Tuple.Create(currentPosition.Item1, currentPosition.Item2 + 1);
                        //To top
                        case ConnectingPipes.NorthWest:
                            return Tuple.Create(currentPosition.Item1 - 1, currentPosition.Item2);
                    }
                }

                //From top
                if (previousPosition.Item1 == currentPosition.Item1 - 1)
                {
                    switch (currentPipe)
                    {
                        //To left
                        case ConnectingPipes.NorthWest:
                            return Tuple.Create(currentPosition.Item1, currentPosition.Item2 - 1);
                        //To right
                        case ConnectingPipes.NorthEast:
                            return Tuple.Create(currentPosition.Item1, currentPosition.Item2 + 1);
                    }
                }
            }

            //Left column
            if (currentPosition.Item2 == 0)
            {
                //From top
                if (previousPosition.Item1 == currentPosition.Item1 - 1)
                {
                    switch (currentPipe)
                    {
                        //To right
                        case ConnectingPipes.NorthEast:
                            return Tuple.Create(currentPosition.Item1, currentPosition.Item2 + 1);
                        //To bottom
                        case ConnectingPipes.NorthSouth:
                            return Tuple.Create(currentPosition.Item1 + 1, currentPosition.Item2);
                    }
                }

                //From right
                if (previousPosition.Item2 == currentPosition.Item2 - 1)
                {
                    switch (currentPipe)
                    {
                        //To top
                        case ConnectingPipes.NorthEast:
                            return Tuple.Create(currentPosition.Item1 - 1, currentPosition.Item2);
                        //To bottom
                        case ConnectingPipes.SouthEast:
                            return Tuple.Create(currentPosition.Item1 + 1, currentPosition.Item2);
                    }
                }

                //From bottom
                if (previousPosition.Item1 == currentPosition.Item1 + 1)
                {
                    switch (currentPipe)
                    {
                        //To right
                        case ConnectingPipes.SouthEast:
                            return Tuple.Create(currentPosition.Item1, currentPosition.Item2 - 1);
                        //To top
                        case ConnectingPipes.NorthSouth:
                            return Tuple.Create(currentPosition.Item1 - 1, currentPosition.Item2);
                    }
                }
            }

            if (currentPipe == ConnectingPipes.EastWest)
                return previousPosition.Item2 == currentPosition.Item2 - 1 ?
                    Tuple.Create(currentPosition.Item1, currentPosition.Item2 + 1)
                    : Tuple.Create(currentPosition.Item1, currentPosition.Item2 - 1);

            if (currentPipe == ConnectingPipes.NorthEast)
                return previousPosition.Item1 == currentPosition.Item1 - 1 ?
                    Tuple.Create(currentPosition.Item1, currentPosition.Item2 + 1)
                    : Tuple.Create(currentPosition.Item1 - 1, currentPosition.Item2);

            if (currentPipe == ConnectingPipes.NorthSouth)
                return previousPosition.Item1 == currentPosition.Item1 - 1 ?
                    Tuple.Create(currentPosition.Item1 + 1, currentPosition.Item2)
                    : Tuple.Create(currentPosition.Item1 - 1, currentPosition.Item2);

            if (currentPipe == ConnectingPipes.NorthWest)
                return previousPosition.Item1 == currentPosition.Item1 - 1 ?
                    Tuple.Create(currentPosition.Item1, currentPosition.Item2 - 1)
                    : Tuple.Create(currentPosition.Item1 - 1, currentPosition.Item2);

            if (currentPipe == ConnectingPipes.SouthEast)
                return previousPosition.Item1 == currentPosition.Item1 + 1 ?
                    Tuple.Create(currentPosition.Item1, currentPosition.Item2 + 1)
                    : Tuple.Create(currentPosition.Item1 + 1, currentPosition.Item2);

            if (currentPipe == ConnectingPipes.SouthWest)
                return previousPosition.Item1 == currentPosition.Item1 + 1 ?
                    Tuple.Create(currentPosition.Item1, currentPosition.Item2 - 1)
                    : Tuple.Create(currentPosition.Item1 + 1, currentPosition.Item2);

            throw new Exception(
                $"Something went wrong with pipe at location {currentPosition.Item1} {currentPosition.Item2}");
        }
    }
}
