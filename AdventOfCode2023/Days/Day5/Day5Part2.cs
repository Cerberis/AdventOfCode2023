using System.Diagnostics;

namespace AdventOfCode2023.Days.Day5
{
    internal class Day5Part2 : Day5
    {
        internal Day5Part2(string filePath) : base(filePath)
        {
        }

        internal override long Calculate()
        {
            var timer = new Stopwatch();
            timer.Start();
            var currentDataSet = SeedsWithRanges;
            foreach (var mapper in MappersDictionary)
            {
                Console.WriteLine($"Mapper: {mapper.Key}");
                var mappedData = MapData(mapper.Value, currentDataSet);
                var remadeDict = GetOnlyNewSeeds(mappedData);
                currentDataSet = remadeDict;
            }
            Console.WriteLine("Finished in: " + timer.Elapsed.Milliseconds + "ms");
            return currentDataSet.Min(m => m.RangeFrom);
        }

        private List<RangeUsageMapping> MapData(List<RangeMapping> mapperRanges, List<RangeUsageMapping> currentDataSet)
        {
            var newDataSet = new List<RangeUsageMapping>();
            while (currentDataSet.Any())
            {
                var currentData = currentDataSet.First();

                var dataLeftToMap = currentData;
                var mappedData = new List<RangeUsageMapping>();
                foreach (var mapperRange in mapperRanges)
                {
                    var mapperDifference = mapperRange.DestinationRangeStart - mapperRange.SourceRangeStart;

                    //Fully inside mappers range
                    if (mapperRange.SourceRangeStart <= dataLeftToMap.RangeFrom && mapperRange.SourceRangeEnd >= dataLeftToMap.RangeTo)
                    {
                        var start = dataLeftToMap.RangeFrom + mapperDifference;
                        var mappedCount = dataLeftToMap.RangeTo - dataLeftToMap.RangeFrom;
                        //if (mapperDifference < 0)
                        //    mappedCount++;
                        var finish = start + mappedCount;
                        mappedData.Add(new RangeUsageMapping(start, finish));
                        currentDataSet.RemoveAt(0);
                        currentData.RangeFrom = -1;
                        currentData.RangeTo = -1;
                        break;
                    }

                    //Ending is inside mapper range
                    if (mapperRange.SourceRangeStart <= dataLeftToMap.RangeTo && mapperRange.SourceRangeEnd > dataLeftToMap.RangeTo)
                    {
                        var mappedDataCount = dataLeftToMap.RangeTo - mapperRange.SourceRangeStart + 1;
                        var start = mapperRange.DestinationRangeStart;
                        var finish = start + mappedDataCount - 1;
                        mappedData.Add(new RangeUsageMapping(start, finish));
                        dataLeftToMap.RangeTo = mapperRange.SourceRangeStart - 1;
                        continue;
                    }

                    //Start is inside mappers range
                    if (mapperRange.SourceRangeEnd >= dataLeftToMap.RangeFrom && mapperRange.SourceRangeEnd < dataLeftToMap.RangeTo)
                    {
                        var mappedDataCount = mapperRange.SourceRangeEnd - dataLeftToMap.RangeFrom + 1;

                        var start = mapperRange.DestinationRangeEnd - mappedDataCount + 1;
                        var finish = mapperRange.DestinationRangeEnd;
                        mappedData.Add(new RangeUsageMapping(start, finish));

                        dataLeftToMap.RangeFrom = mapperRange.SourceRangeEnd + 1;
                        continue;
                    }

                    //Data is over mappers range
                    if (mapperRange.SourceRangeStart > dataLeftToMap.RangeFrom && mapperRange.SourceRangeEnd < dataLeftToMap.RangeTo)
                    {
                        var beforeDiff = mapperRange.SourceRangeStart - dataLeftToMap.RangeFrom;
                        var unmappedBeforeDataStart = dataLeftToMap.RangeFrom;
                        var unmappedBeforeDataEnd = dataLeftToMap.RangeFrom + beforeDiff;

                        var afterDiff = dataLeftToMap.RangeTo - mapperRange.SourceRangeEnd;
                        var unmappedAfterDataStart = dataLeftToMap.RangeFrom;
                        var unmappedAfterDataEnd = dataLeftToMap.RangeFrom + afterDiff;

                        var start = mapperRange.SourceRangeStart + mapperDifference;
                        var finish = mapperRange.SourceRangeEnd + mapperDifference;
                        mappedData.Add(new RangeUsageMapping(start, finish));
                        mappedData.Add(new RangeUsageMapping(unmappedAfterDataStart, unmappedBeforeDataEnd));
                        mappedData.Add(new RangeUsageMapping(unmappedBeforeDataStart, unmappedAfterDataEnd));
                    }
                }

                if (currentData.RangeFrom > -1 && currentData.RangeTo > -1)
                {
                    mappedData.Add(new RangeUsageMapping(currentData.RangeFrom, currentData.RangeTo));
                    currentDataSet.RemoveAt(0);
                }
                newDataSet.AddRange(mappedData);
            }

            return newDataSet;
        }

        internal override void ParseSeedData(string row)
        {
            var parsedSeeds = row.Replace("seeds: ", "").ToLongList(' ');

            SeedsWithRanges = new List<RangeUsageMapping>();
            for (int i = 0; i < parsedSeeds.Count; i++)
            {
                var seedRangeStart = parsedSeeds[i];
                var seedRangeFinish = seedRangeStart + parsedSeeds[i + 1] - 1;

                SeedsWithRanges = GetOnlyNewSeeds(SeedsWithRanges, seedRangeStart, seedRangeFinish);
                i++;
            }
        }

        private List<RangeUsageMapping> GetOnlyNewSeeds(List<RangeUsageMapping> dataDictionary, long seedRangeStart, long seedRangeFinish)
        {
            var redudantSeeds = dataDictionary.Where(m => seedRangeStart <= m.RangeFrom && seedRangeFinish >= m.RangeTo).ToList();
            foreach (var redudantSeed in redudantSeeds)
            {
                dataDictionary.Remove(redudantSeed);
            }

            var seedsWithDublicateEnds = dataDictionary.Where(m => (seedRangeFinish >= m.RangeFrom && seedRangeFinish <= m.RangeTo)
                                                                   && seedRangeStart <= m.RangeFrom).ToList();
            foreach (var seedWithDublicateEnds in seedsWithDublicateEnds)
            {
                dataDictionary.Remove(seedWithDublicateEnds);
                dataDictionary.Add(new RangeUsageMapping(seedRangeStart, seedWithDublicateEnds.RangeTo));
            }

            var seedsWithDublicateStarts = dataDictionary.Where(m => (seedRangeStart >= m.RangeFrom && seedRangeStart <= m.RangeTo)
                                                                     && seedRangeFinish >= m.RangeTo).ToList();
            foreach (var seedWithDublicateStarts in seedsWithDublicateStarts)
            {
                dataDictionary.Remove(seedWithDublicateStarts);
                dataDictionary.Add(new RangeUsageMapping(seedWithDublicateStarts.RangeFrom, seedRangeFinish));
            }

            if (!seedsWithDublicateEnds.Any() && !seedsWithDublicateStarts.Any())
                dataDictionary.Add(new RangeUsageMapping(seedRangeStart, seedRangeFinish));

            return dataDictionary;
        }

        private List<RangeUsageMapping> GetOnlyNewSeeds(List<RangeUsageMapping> dataDictionary)
        {
            var remadeDataSet = new List<RangeUsageMapping>();

            foreach (var dataDic in dataDictionary)
            {
                var seedRangeStart = dataDic.RangeFrom;
                var seedRangeFinish = dataDic.RangeTo;

                if (remadeDataSet.Any(m => seedRangeStart >= m.RangeFrom && seedRangeFinish <= m.RangeTo))
                    continue;

                var redudantSeeds = remadeDataSet.Where(m => seedRangeStart <= m.RangeFrom && seedRangeFinish >= m.RangeTo).ToList();
                foreach (var redudantSeed in redudantSeeds)
                {
                    remadeDataSet.Remove(redudantSeed);
                }

                var seedsWithDublicateEnds = remadeDataSet.Where(m => (seedRangeFinish >= m.RangeFrom && seedRangeFinish <= m.RangeTo)
                                                                      && seedRangeStart <= m.RangeFrom).ToList();
                foreach (var seedWithDublicateEnds in seedsWithDublicateEnds)
                {
                    remadeDataSet.Remove(seedWithDublicateEnds);
                    remadeDataSet.Add(new RangeUsageMapping(seedRangeStart, seedWithDublicateEnds.RangeTo));
                }

                var seedsWithDublicateStarts = remadeDataSet.Where(m => (seedRangeStart >= m.RangeFrom && seedRangeStart <= m.RangeTo)
                                                                        && seedRangeFinish >= m.RangeTo).ToList();
                foreach (var seedWithDublicateStarts in seedsWithDublicateStarts)
                {
                    remadeDataSet.Remove(seedWithDublicateStarts);
                    remadeDataSet.Add(new RangeUsageMapping(seedWithDublicateStarts.RangeFrom, seedRangeFinish));
                }

                if (!seedsWithDublicateEnds.Any() && !seedsWithDublicateStarts.Any())
                    remadeDataSet.Add(new RangeUsageMapping(seedRangeStart, seedRangeFinish));
            }

            return remadeDataSet;
        }
    }
}