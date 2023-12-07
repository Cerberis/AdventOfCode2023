namespace AdventOfCode2023.Days.Day2;

internal class Day2Part1 : Day2
{
    public Day2Part1(string filePath) : base(filePath)
    {
    }

    private Dictionary<CubeColour, int> AvailableCubes = new()
    {
        { CubeColour.Green, 13 },
        { CubeColour.Red, 12 },
        { CubeColour.Blue, 14 }
    };
    
    internal override int Calculate()
    {
        var sumOfValidGames = 0;
        foreach (CubeGame item in InputData)
        {
            if (item.Rounds.Max(m => m.Blue) > AvailableCubes[CubeColour.Blue])
                continue;

            if (item.Rounds.Max(m => m.Green) > AvailableCubes[CubeColour.Green])
                continue;

            if (item.Rounds.Max(m => m.Red) > AvailableCubes[CubeColour.Red])
                continue;

            sumOfValidGames += item.Id;
        }

        return sumOfValidGames;
    }
}