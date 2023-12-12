namespace AdventOfCode2023.Helpers;

public static class FileReaders
{
    public static List<string> ReadDataFileAsStringList(string filePath)
    {
        return File.ReadLines(filePath).ToList();
    }

    public static List<List<char>> ReadDataFileAsCharMatrix(string filePath)
    {
        var result = new List<List<char>>();
        foreach (var line in File.ReadAllLines(filePath))
        {
            result.Add(line.ToList());
        }
        return result;
    }
}