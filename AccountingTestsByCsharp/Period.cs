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

        public double OverlappingDays(Budget budget)
        {
            if (Start > budget.LastDay || End < budget.FirstDay)
            {
                return 0;
            }

            var effectiveStart = budget.FirstDay > Start
                ? budget.FirstDay
                : Start;

            var effectiveEnd = budget.LastDay < End
                ? budget.LastDay
                : End;

            return (effectiveEnd - effectiveStart).TotalDays + 1;
        }
    }
}