using AdventOfCode2023.Days.Day1;
using AdventOfCode2023.Days.Day10;
using AdventOfCode2023.Days.Day11;
using AdventOfCode2023.Days.Day12;
using AdventOfCode2023.Days.Day13;
using AdventOfCode2023.Days.Day2;
using AdventOfCode2023.Days.Day3;
using AdventOfCode2023.Days.Day4;
using AdventOfCode2023.Days.Day5;
using AdventOfCode2023.Days.Day6;
using AdventOfCode2023.Days.Day7;
using AdventOfCode2023.Days.Day8;
using AdventOfCode2023.Days.Day9;
using System.ComponentModel;
using System.Reflection;

namespace AdventOfCode2023
{
    public static class RunModeHandler
    {
        public static void Execute(string consoleValue)
        {
            var runMode = GetRunMode(consoleValue);
            switch (runMode)
            {
                case RunMode.Day1Part1:
                    {
                        Day1Part1Handler();
                        break;
                    }
                case RunMode.Day1Part2:
                    {
                        Day1Part2Handler();
                        break;
                    }
                case RunMode.Day2Part1:
                    {
                        Day2Part1Handler();
                        break;
                    }
                case RunMode.Day2Part2:
                    {
                        Day2Part2Handler();
                        break;
                    }
                case RunMode.Day3Part1:
                    {
                        Day3Part1Handler();
                        break;
                    }
                case RunMode.Day3Part2:
                    {
                        Day3Part2Handler();
                        break;
                    }
                case RunMode.Day4Part1:
                    {
                        Day4Part1Handler();
                        break;
                    }
                case RunMode.Day4Part2:
                    {
                        Day4Part2Handler();
                        break;
                    }
                case RunMode.Day5Part1:
                    {
                        Day5Part1Handler();
                        break;
                    }
                case RunMode.Day5Part2:
                    {
                        Day5Part2Handler();
                        break;
                    }
                case RunMode.Day6Part1:
                    {
                        Day6Part1Handler();
                        break;
                    }
                case RunMode.Day6Part2:
                    {
                        Day6Part2Handler();
                        break;
                    }
                case RunMode.Day7Part1:
                    {
                        Day7Part1Handler();
                        break;
                    }
                case RunMode.Day7Part2:
                    {
                        Day7Part2Handler();
                        break;
                    }
                case RunMode.Day8Part1:
                    {
                        Day8Part1Handler();
                        break;
                    }
                case RunMode.Day8Part2:
                    {
                        Day8Part2Handler();
                        break;
                    }
                case RunMode.Day9Part1:
                    {
                        Day9Part1Handler();
                        break;
                    }
                case RunMode.Day9Part2:
                    {
                        Day9Part2Handler();
                        break;
                    }
                case RunMode.Day10Part1:
                    {
                        Day10Part1Handler();
                        break;
                    }
                case RunMode.Day10Part2:
                    {
                        Day10Part2Handler();
                        break;
                    }
                case RunMode.Day11Part1:
                    {
                        Day11Part1Handler();
                        break;
                    }
                case RunMode.Day11Part2:
                    {
                        Day11Part2Handler();
                        break;
                    }
                case RunMode.Day12Part1:
                    {
                        Day12Part1Handler();
                        break;
                    }
                case RunMode.Day12Part2:
                    {
                        Day12Part2Handler();
                        break;
                    }
                case RunMode.Day13Part1:
                    {
                        Day13Part1Handler();
                        break;
                    }
                case RunMode.Day13Part2:
                    {
                        Day13Part2Handler();
                        break;
                    }
            }
        }

        static void Day1Part1Handler()
        {
            const string dataFilePath = @"Days\Day1\Data.txt";
            var path = GetPath(dataFilePath);
            var handler = new Day1Part1(path);
            handler.Execute();
        }

        static void Day1Part2Handler()
        {
            const string dataFilePath = @"Days\Day1\Data.txt";
            var path = GetPath(dataFilePath);
            var handler = new Day1Part2(path);
            handler.Execute();
        }

        static void Day2Part1Handler()
        {
            string path = GetPath(@"Days\Day2\Data.txt");
            var handler = new Day2Part1(path);
            handler.Execute();
        }

        static void Day2Part2Handler()
        {
            string path = GetPath(@"Days\Day2\Data.txt");
            var handler = new Day2Part2(path);
            handler.Execute();
        }

        static void Day3Part1Handler()
        {
            string path = GetPath(@"Days\Day3\Data.txt");
            var handler = new Day3Part1(path);
            handler.Execute();
        }

        static void Day3Part2Handler()
        {
            string path = GetPath(@"Days\Day3\Data.txt");
            var handler = new Day3Part2(path);
            handler.Execute();
        }

        static void Day4Part1Handler()
        {
            string path = GetPath(@"Days\Day4\Data.txt");
            var handler = new Day4Part1(path);
            handler.Execute();
        }

        static void Day4Part2Handler()
        {
            string path = GetPath(@"Days\Day4\Data.txt");
            var handler = new Day4Part2(path);
            handler.Execute();
        }

        static void Day5Part1Handler()
        {
            string path = GetPath(@"Days\Day5\Data.txt");
            var handler = new Day5Part1(path);
            handler.Execute();
        }

        static void Day5Part2Handler()
        {
            string path = GetPath(@"Days\Day5\Data.txt");
            var handler = new Day5Part2(path);
            handler.Execute();
        }

        static void Day6Part1Handler()
        {
            string path = GetPath(@"Days\Day6\Data.txt");
            var handler = new Day6Part1(path);
            handler.Execute();
        }

        static void Day6Part2Handler()
        {
            string path = GetPath(@"Days\Day6\Data.txt");
            var handler = new Day6Part2(path);
            handler.Execute();
        }

        static void Day7Part1Handler()
        {
            string path = GetPath(@"Days\Day7\Data.txt");
            var handler = new Day7Part1(path);
            handler.Execute();
        }

        static void Day7Part2Handler()
        {
            string path = GetPath(@"Days\Day7\Data.txt");
            var handler = new Day7Part2(path);
            handler.Execute();
        }

        static void Day8Part1Handler()
        {
            string path = GetPath(@"Days\Day8\Data.txt");
            var handler = new Day8Part1(path);
            handler.Execute();
        }

        static void Day8Part2Handler()
        {
            string path = GetPath(@"Days\Day8\Data.txt");
            var handler = new Day8Part2(path);
            handler.Execute();
        }

        static void Day9Part1Handler()
        {
            string path = GetPath(@"Days\Day9\Data.txt");
            var handler = new Day9Part1(path);
            handler.Execute();
        }

        static void Day9Part2Handler()
        {
            string path = GetPath(@"Days\Day9\Data.txt");
            var handler = new Day9Part2(path);
            handler.Execute();
        }

        static void Day10Part1Handler()
        {
            string path = GetPath(@"Days\Day10\Data.txt");
            var handler = new Day10Part1(path);
            handler.Execute();
        }

        static void Day10Part2Handler()
        {
            string path = GetPath(@"Days\Day10\Data.txt");
            var handler = new Day10Part2(path);
            handler.Execute();
        }

        static void Day11Part1Handler()
        {
            string path = GetPath(@"Days\Day11\Data.txt");
            var handler = new Day11Part1(path);
            handler.Execute();
        }

        static void Day11Part2Handler()
        {
            string path = GetPath(@"Days\Day11\Data.txt");
            var handler = new Day11Part2(path);
            handler.Execute();
        }

        static void Day12Part1Handler()
        {
            string path = GetPath(@"Days\Day12\Data.txt");
            var handler = new Day12Part1(path);
            handler.Execute();
        }

        static void Day12Part2Handler()
        {
            string path = GetPath(@"Days\Day12\Data.txt");
            var handler = new Day12Part2(path);
            handler.Execute();
        }

        static void Day13Part1Handler()
        {
            string path = GetPath(@"Days\Day13\Data.txt");
            var handler = new Day13Part1(path);
            handler.Execute();
        }

        static void Day13Part2Handler()
        {
            string path = GetPath(@"Days\Day13\Data.txt");
            var handler = new Day13Part2(path);
            handler.Execute();
        }

        static RunMode GetRunMode(string consoleValue)
        {
            var canBeParsed = Enum.TryParse(consoleValue, true, out RunMode parsedRunMode);

            if (canBeParsed)
                return parsedRunMode;

            throw new InvalidEnumArgumentException($"Provided day and part  ({consoleValue})  doesn't exist");
        }

        static string GetPath(string path)
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, path);
        }
    }
}