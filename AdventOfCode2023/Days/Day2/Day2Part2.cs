namespace AdventOfCode2023.Days.Day2;

internal class Day2Part2 : Day2
{
    public Day2Part2(string filePath) : base(filePath)
    {
    }

    internal override int Calculate()
    {
        var sumOfValidGames = 0;
        foreach (CubeGame item in InputData)
        {
            var minBlueCubes = item.Rounds.Where(m => m.Blue != null).Max(m => m.Blue) ?? 1;
            var minGreenCubes = item.Rounds.Where(m => m.Green != null).Max(m => m.Green) ?? 1;
            var minRedCubes = item.Rounds.Where(m => m.Red != null).Max(m => m.Red) ?? 1;

            var sumOfCubes = minBlueCubes * minGreenCubes * minRedCubes;
            sumOfValidGames += sumOfCubes;
        }

        return sumOfValidGames;
    }
}