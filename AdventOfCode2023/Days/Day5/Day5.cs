
namespace AdventOfCode2023.Days.Day5
{
    internal abstract class Day5
    {
        internal List<long> Seeds;
        internal List<RangeUsageMapping> SeedsWithRanges;
        internal Dictionary<string, List<RangeMapping>> MappersDictionary;

        internal Dictionary<string, List<long>> MappersUsed;

        internal Day5(string filePath)
        {
            MappersDictionary = new Dictionary<string, List<RangeMapping>>();
            MappersUsed = new Dictionary<string, List<long>>();
            ReadDataFile(filePath);
        }

        internal string Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
            return result.ToString();
        }

        internal abstract void ParseSeedData(string row);
        private void ReadDataFile(string filePath)
        {
            var rows = File.ReadLines(filePath).Where(m => !string.IsNullOrEmpty(m)).ToList();

            ParseSeedData(rows[0]);
            string mappingName = string.Empty;
            var mappingData = new List<RangeMapping>();
            for (var rowIndex = 1; rowIndex < rows.Count; rowIndex++)
            {
                while (!rows[rowIndex].Contains(" map:"))
                {
                    var singleMappingInfo = rows[rowIndex].ToLongList(' ');
                    mappingData.Add(new RangeMapping(singleMappingInfo[0], singleMappingInfo[1], singleMappingInfo[2]));

                    if (rowIndex + 1 == rows.Count)
                        break;

                    rowIndex++;
                }

                if (mappingData.Any())
                    MappersDictionary.TryAdd(mappingName, mappingData);

                mappingName = rows[rowIndex].Replace(" map:", "");
                mappingData = new List<RangeMapping>();
            }
        }

        internal abstract long Calculate();

        internal long GetSeedLocation(long seed)
        {
            long initialDataToMap = seed;
            foreach (var mapper in MappersDictionary)
            {
                long mappedData = initialDataToMap;

                var foundDestinationMap = mapper.Value.FirstOrDefault(m =>
                    m.SourceRangeStart <= initialDataToMap && m.SourceRangeEnd >= initialDataToMap);


                if (foundDestinationMap != null)
                {
                    var difference = initialDataToMap - foundDestinationMap.SourceRangeStart;
                    mappedData = foundDestinationMap.DestinationRangeStart + difference;
                }

                initialDataToMap = mappedData;

                if (MappersUsed.ContainsKey(mapper.Key))
                {
                    if (MappersUsed[mapper.Key].Contains(initialDataToMap))
                        break;

                    MappersUsed[mapper.Key].Add(initialDataToMap);
                }
                else
                {
                    MappersUsed.Add(mapper.Key, new List<long> { initialDataToMap });
                }
            }

            return initialDataToMap;
        }
    }
}
