namespace AdventOfCode2023.Models
{
    internal class RangeMapping
    {
        internal readonly long DestinationRangeStart;
        internal readonly long DestinationRangeEnd;
        internal readonly long SourceRangeStart;
        internal readonly long SourceRangeEnd;

        public RangeMapping(long destinationRangeStart, long sourceRangeStart, long rangeLength)
        {
            DestinationRangeStart = destinationRangeStart;
            SourceRangeStart = sourceRangeStart;
            DestinationRangeEnd = destinationRangeStart + rangeLength - 1;
            SourceRangeEnd = sourceRangeStart + rangeLength - 1;
        }
    }
}
