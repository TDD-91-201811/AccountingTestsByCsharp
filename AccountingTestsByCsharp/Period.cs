using System;

namespace AccountingTestsByCsharp
{
    public class Period
    {
        public Period(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime End { get; private set; }
        public DateTime Start { get; private set; }

        public double OverlappingDays(Period another)
        {
            if (Start > another.End || End < another.Start)
            {
                return 0;
            }

            var effectiveStart = another.Start > Start
                ? another.Start
                : Start;

            var effectiveEnd = another.End < End
                ? another.End
                : End;

            return (effectiveEnd - effectiveStart).TotalDays + 1;
        }
    }
}