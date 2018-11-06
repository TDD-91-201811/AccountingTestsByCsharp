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

        public DateTime End { get; }
        public DateTime Start { get; }

        public double OverlappingDays(Period another)
        {
            if (IsInvalid() || HasNoOverlapping(another))
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

        private bool HasNoOverlapping(Period another)
        {
            return Start > another.End || End < another.Start;
        }

        private bool IsInvalid()
        {
            return Start > End;
        }
    }
}