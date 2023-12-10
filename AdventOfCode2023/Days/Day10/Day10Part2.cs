namespace AdventOfCode2023.Days.Day10
{
    internal class Day10Part2 : Day10
    {
        internal Day10Part2(string filePath) : base(filePath)
        {
        }

        internal override string Calculate()
        {
            var firstMove = GetFirstMove();
            var moveList = GetMoves(firstMove);
            int objectsInsideCount = GetObjectsInsidePipeCount(moveList);

            return objectsInsideCount.ToString();
        }

        private int GetObjectsInsidePipeCount(List<PipeAction> moveList)
        {
            var newGrid = Grid;
            var gridCount = Grid.Count;

            ReplaceFirstOutsideLayer(newGrid, moveList);
            WriteGrid(newGrid);

            ReplaceOutOfPipeAreas(moveList, gridCount, newGrid);
            WriteGrid(newGrid, moveList);

            ReplaceIllogicalPipes(moveList, gridCount, newGrid);
            WriteGrid(newGrid, moveList);

            var result = Grid.Sum(m => m.Count(n => n == ConnectingPipes.Ground));
            return result;
        }

        private void ReplaceOutOfPipeAreas(List<PipeAction> moveList, int gridCount, List<List<ConnectingPipes>> newGrid)
        {
            while (true)
            {
                var pipesUpdated = 0;
                for (int primaryIndex = 1; primaryIndex < gridCount; primaryIndex++)
                {
                    for (int secondaryIndex = 1; secondaryIndex < gridCount; secondaryIndex++)
                    {
                        var updatedTop = ReplaceTop(newGrid, primaryIndex, secondaryIndex, moveList);
                        var updatedRight = ReplaceRight(newGrid, secondaryIndex, gridCount - primaryIndex - 1,
                            moveList);
                        var updatedBottom = ReplaceBottom(newGrid, gridCount - primaryIndex - 1, secondaryIndex,
                            moveList);
                        var updatedLeft = ReplaceLeft(newGrid, secondaryIndex, primaryIndex, moveList);
                        pipesUpdated += updatedTop + updatedRight + updatedBottom + updatedLeft;
                    }
                }

                WriteGrid(newGrid);
                if (pipesUpdated == 0)
                    break;
            }
        }

        private void ReplaceIllogicalPipes(List<PipeAction> moveList, int gridCount, List<List<ConnectingPipes>> newGrid)
        {
            while (true)
            {
                var pipesUpdated = 0;
                for (int rowIndex = 1; rowIndex < gridCount; rowIndex++)
                {
                    for (int columnIndex = 1; columnIndex < gridCount; columnIndex++)
                    {
                        var updated = ReplaceIllogicalPipes(newGrid, rowIndex, columnIndex, moveList);
                        pipesUpdated += updated;
                    }
                }

                WriteGrid(newGrid);
                if (pipesUpdated == 0)
                    break;
            }
        }

        private void WriteGrid(List<List<ConnectingPipes>> newGrid, List<PipeAction> moveList)
        {
            Console.WriteLine("");
            for (var rowIndex = 0; rowIndex < newGrid.Count; rowIndex++)
            {
                var row = newGrid[rowIndex];
                Console.WriteLine("");
                for (var columnIndex = 0; columnIndex < row.Count; columnIndex++)
                {
                    var column = row[columnIndex];
                    if (column == ConnectingPipes.StartingPosition)
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    else
                        Console.BackgroundColor = moveList.Any(m => m.RowIndex == rowIndex && m.ColumnIndex == columnIndex) ? ConsoleColor.Red : ConsoleColor.Black;
                    Console.Write($" {MapPipeToSymbol(column)}");
                }
            }
        }


        void WriteGrid(List<List<ConnectingPipes>> grid)
        {
            Console.WriteLine("");
            foreach (var row in grid)
            {
                Console.WriteLine("");
                foreach (var column in row)
                {
                    Console.Write($" {MapPipeToSymbol(column)}");
                }
            }
        }

        private void ReplaceFirstOutsideLayer(List<List<ConnectingPipes>> newGrid, List<PipeAction> moveList)
        {
            var arrayCount = newGrid.First().Count;

            for (int dataIndex = 0; dataIndex < arrayCount; dataIndex++)
            {
                //Top row
                if (!moveList.Any(m => m.RowIndex == 0 && m.ColumnIndex == dataIndex))
                    newGrid[0][dataIndex] = ConnectingPipes.OutOfPipeArea;

                //Bottom row
                if (!moveList.Any(m => m.RowIndex == arrayCount - 1 && m.ColumnIndex == dataIndex))
                    newGrid[arrayCount - 1][dataIndex] = ConnectingPipes.OutOfPipeArea;

                //Left column
                if (!moveList.Any(m => m.ColumnIndex == 0 && m.RowIndex == dataIndex))
                    newGrid[dataIndex][0] = ConnectingPipes.OutOfPipeArea;

                //Right column
                if (!moveList.Any(m => m.ColumnIndex == arrayCount - 1 && m.RowIndex == dataIndex))
                    newGrid[dataIndex][arrayCount - 1] = ConnectingPipes.OutOfPipeArea;
            }
        }

        private int ReplaceLeft(List<List<ConnectingPipes>> newGrid, int rowIndex, int columnIndex, List<PipeAction> pipeActions)
        {
            if (newGrid[rowIndex][columnIndex] == ConnectingPipes.OutOfPipeArea)
                return 0;

            if (newGrid[rowIndex][columnIndex - 1] != ConnectingPipes.OutOfPipeArea)
                return 0;

            if (pipeActions.Any(m => m.RowIndex == rowIndex && m.ColumnIndex == columnIndex))
                return 0;

            newGrid[rowIndex][columnIndex] = ConnectingPipes.OutOfPipeArea;
            return 1;
        }

        private int ReplaceBottom(List<List<ConnectingPipes>> newGrid, int rowIndex, int columnIndex,
            List<PipeAction> pipeActions)
        {
            if (newGrid[rowIndex][columnIndex] == ConnectingPipes.OutOfPipeArea)
                return 0;

            if (newGrid[rowIndex + 1][columnIndex] != ConnectingPipes.OutOfPipeArea)
                return 0;

            if (pipeActions.Any(m => m.RowIndex == rowIndex && m.ColumnIndex == columnIndex))
                return 0;

            newGrid[rowIndex][columnIndex] = ConnectingPipes.OutOfPipeArea;
            return 1;
        }

        private int ReplaceRight(List<List<ConnectingPipes>> newGrid, int rowIndex, int columnIndex,
            List<PipeAction> pipeActions)
        {
            if (newGrid[rowIndex][columnIndex] == ConnectingPipes.OutOfPipeArea)
                return 0;

            if (newGrid[rowIndex][columnIndex + 1] != ConnectingPipes.OutOfPipeArea)
                return 0;

            if (pipeActions.Any(m => m.RowIndex == rowIndex && m.ColumnIndex == columnIndex))
                return 0;

            newGrid[rowIndex][columnIndex] = ConnectingPipes.OutOfPipeArea;
            return 1;
        }

        private int ReplaceTop(List<List<ConnectingPipes>> newGrid, int rowIndex, int columnIndex, List<PipeAction> pipeActions)
        {
            if (newGrid[rowIndex][columnIndex] == ConnectingPipes.OutOfPipeArea)
                return 0;

            if (newGrid[rowIndex - 1][columnIndex] != ConnectingPipes.OutOfPipeArea)
                return 0;

            if (pipeActions.Any(m => m.RowIndex == rowIndex && m.ColumnIndex == columnIndex))
                return 0;

            newGrid[rowIndex][columnIndex] = ConnectingPipes.OutOfPipeArea;
            return 1;
        }

        private int ReplaceIllogicalPipes(List<List<ConnectingPipes>> newGrid, int rowIndex, int columnIndex, List<PipeAction> pipeActions)
        {
            var pipe = newGrid[rowIndex][columnIndex];
            if (pipe is ConnectingPipes.OutOfPipeArea
                or ConnectingPipes.StartingPosition
                or ConnectingPipes.Ground)
                return 0;

            if (pipeActions.Any(m => m.RowIndex == rowIndex && m.ColumnIndex == columnIndex))
                return 0;

            switch (pipe)
            {
                case ConnectingPipes.EastWest:
                    if (_invalidLeftActions.Contains(newGrid[rowIndex][columnIndex - 1]) ||
                        _invalidRightActions.Contains(newGrid[rowIndex][columnIndex + 1]))
                    {
                        newGrid[rowIndex][columnIndex] = ConnectingPipes.Ground;
                        return 1;
                    }

                    break;
                case ConnectingPipes.NorthEast:
                    if (_invalidTopActions.Contains(newGrid[rowIndex - 1][columnIndex]) ||
                        _invalidRightActions.Contains(newGrid[rowIndex][columnIndex + 1]))
                    {
                        newGrid[rowIndex][columnIndex] = ConnectingPipes.Ground;
                        return 1;
                    }

                    break;
                case ConnectingPipes.NorthSouth:
                    if (_invalidTopActions.Contains(newGrid[rowIndex - 1][columnIndex]) ||
                        _invalidBottomActions.Contains(newGrid[rowIndex + 1][columnIndex]))
                    {
                        newGrid[rowIndex][columnIndex] = ConnectingPipes.Ground;
                        return 1;
                    }

                    break;
                case ConnectingPipes.NorthWest:
                    if (_invalidTopActions.Contains(newGrid[rowIndex - 1][columnIndex]) ||
                        _invalidLeftActions.Contains(newGrid[rowIndex][columnIndex - 1]))
                    {
                        newGrid[rowIndex][columnIndex] = ConnectingPipes.Ground;
                        return 1;
                    }

                    break;
                case ConnectingPipes.SouthEast:
                    if (_invalidBottomActions.Contains(newGrid[rowIndex + 1][columnIndex]) ||
                        _invalidRightActions.Contains(newGrid[rowIndex][columnIndex + 1]))
                    {
                        newGrid[rowIndex][columnIndex] = ConnectingPipes.Ground;
                        return 1;
                    }

                    break;
                case ConnectingPipes.SouthWest:
                    if (_invalidBottomActions.Contains(newGrid[rowIndex + 1][columnIndex]) ||
                        _invalidLeftActions.Contains(newGrid[rowIndex][columnIndex - 1]))
                    {
                        newGrid[rowIndex][columnIndex] = ConnectingPipes.Ground;
                        return 1;
                    }

                    break;
            }

            return 0;
        }

        private readonly List<ConnectingPipes> _invalidTopActions = new()
        {
            ConnectingPipes.EastWest,
            ConnectingPipes.NorthEast,
            ConnectingPipes.NorthWest,
            ConnectingPipes.Ground,
            ConnectingPipes.OutOfPipeArea
        };

        private readonly List<ConnectingPipes> _invalidBottomActions = new()
        {
            ConnectingPipes.EastWest,
            ConnectingPipes.SouthEast,
            ConnectingPipes.SouthWest,
            ConnectingPipes.Ground,
            ConnectingPipes.OutOfPipeArea
        };

        private readonly List<ConnectingPipes> _invalidLeftActions = new()
        {
            ConnectingPipes.NorthSouth,
            ConnectingPipes.NorthWest,
            ConnectingPipes.SouthWest,
            ConnectingPipes.Ground,
            ConnectingPipes.OutOfPipeArea
        };

        private readonly List<ConnectingPipes> _invalidRightActions = new()
        {
            ConnectingPipes.NorthSouth,
            ConnectingPipes.NorthEast,
            ConnectingPipes.SouthEast,
            ConnectingPipes.Ground,
            ConnectingPipes.OutOfPipeArea
        };
    }
}

//60 - X
//637 - too high

