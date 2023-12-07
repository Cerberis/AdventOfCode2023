namespace AdventOfCode2023.Helpers;

public static class FileReaders
{
    public static List<string> ReadDataFileAsStringList(string filePath)
    {
        return File.ReadLines(filePath).ToList();
    }
}