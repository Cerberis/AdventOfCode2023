using System.ComponentModel;

namespace AdventOfCode2023.Days.Day2;

internal abstract class Day2
{
    internal readonly List<CubeGame> InputData;
    internal Day2(string filePath)
    {
        InputData = ReadDataFileAsCubeGames(filePath);
    }

    internal void Execute()
    {
        var result = Calculate();

        Console.WriteLine($"Result: {result}");
    }

    internal abstract int Calculate();
    public static List<CubeGame> ReadDataFileAsCubeGames(string filePath)
    {
        var result = new List<CubeGame>();
        foreach (var line in File.ReadLines(filePath))
        {
            var splitString = line.Split(':', ';');
            var gameId = int.Parse(splitString[0].Remove(0, 5));

            var rounds = ParseRounds(splitString);

            result.Add(new CubeGame(gameId, rounds));
        }
        return result;
    }

    static List<CubeRound> ParseRounds(string[] roundString)
    {
        var result = new List<CubeRound>();
        for (int roundIndex = 1; roundIndex < roundString.Length; roundIndex++)
        {
            var cubeSetResult = new Dictionary<CubeColour, int?>()
            {
                { CubeColour.Blue, null },
                { CubeColour.Red, null },
                { CubeColour.Green, null }
            };

            var cubeSubsets = roundString[roundIndex].Split(',');
            foreach (var cubeSubset in cubeSubsets)
            {
                var cubeDraws = cubeSubset.Trim().Split(' ');
                CubeColour cubeColour = GetCubeColour(cubeDraws[1]);
                var cubeValue = int.Parse(cubeDraws.First());
                if (cubeSetResult[cubeColour] == null)
                    cubeSetResult[cubeColour] = cubeValue;
                else
                    cubeSetResult[cubeColour] += cubeValue;
            }

            var round = new CubeRound(roundIndex, cubeSetResult[CubeColour.Blue], cubeSetResult[CubeColour.Red],
                cubeSetResult[CubeColour.Green]);
            result.Add(round);
        }

        return result;
    }

    static CubeColour GetCubeColour(string colour)
    {
        switch (colour.ToLower())
        {
            case "red":
                return CubeColour.Red;
            case "green":
                return CubeColour.Green;
            case "blue":
                return CubeColour.Blue;
        }

        throw new InvalidEnumArgumentException($"Invalid colour: {colour}");
    }
}