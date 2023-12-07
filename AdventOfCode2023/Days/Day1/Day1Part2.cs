namespace AdventOfCode2023.Days.Day1
{
    internal class Day1Part2 : Day1
    {
       private readonly Dictionary<string, string> NumbersToReplace = new()
        {
            { "one", "1" },
            { "two", "2" },
            { "three", "3"},
            { "four", "4"},
            { "five", "5"},
            { "six", "6"},
            { "seven", "7"},
            {"eight", "8"},
            {"nine", "9"},
            {"zero", "0"}
        };

        internal Day1Part2(string filePath) : base(filePath)
        {
        }
        
        internal override int Calculate()
        {
            var sumOfRowDigits = 0;
            foreach (var item in InputData)
            {
                var remadeItem = TransformStringDigits(item);
                sumOfRowDigits += RowDigitResult(remadeItem);
            }

            return sumOfRowDigits;
        }

        string TransformStringDigits(string item)
        {
            var remadeString = item.ToLower();


            for (int charIndex = 0; charIndex < remadeString.Length; charIndex++)
            {
                if (char.IsDigit(remadeString[charIndex]))
                    continue;

                foreach(var numberToReplace in NumbersToReplace)
                {
                    var digitLength = numberToReplace.Key.Length;
                    if (remadeString.Length < charIndex + digitLength)
                        continue;

                    if (remadeString.Substring(charIndex, digitLength) == numberToReplace.Key)
                    {
                        remadeString =remadeString.Insert(charIndex, numberToReplace.Value);
                        charIndex++;
                        break;
                    }
                }

            }
            return remadeString;
        }
    }
}
