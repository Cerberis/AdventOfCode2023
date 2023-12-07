
Console.WriteLine("Please enter day, followed by the part number");
var runModeValue = Console.ReadLine() ?? string.Empty;
RunModeHandler.Execute(runModeValue);