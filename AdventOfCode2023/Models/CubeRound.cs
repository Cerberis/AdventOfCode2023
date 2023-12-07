namespace AdventOfCode2023.Models;

internal class CubeRound
{
    internal readonly int Id;
    internal readonly int? Blue;
    internal readonly int? Red;
    internal readonly int? Green;

    internal CubeRound(int id, int? blue, int? red, int? green)
    {
        Id = id;
        Blue = blue;
        Red = red;
        Green = green;
    }
}