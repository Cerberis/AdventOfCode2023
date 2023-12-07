namespace AdventOfCode2023.Models
{
    internal class RangeUsageMapping
    {
        internal long RangeFrom;
        internal long RangeTo;

        public RangeUsageMapping(long rangeFrom, long rangeTo)
        {
            RangeTo = rangeTo;
            RangeFrom = rangeFrom;
        }
    }
}
