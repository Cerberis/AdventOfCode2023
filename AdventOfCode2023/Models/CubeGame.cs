namespace AdventOfCode2023.Models;

internal class CubeGame
{
    internal readonly int Id;
    internal readonly List<CubeRound> Rounds;

    internal CubeGame(int id, List<CubeRound> rounds)
    {
        Id = id;
        Rounds = rounds;
    }
}