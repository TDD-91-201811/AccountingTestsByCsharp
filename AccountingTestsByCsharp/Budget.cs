using System;

namespace AccountingTestsByCsharp
{
    public class Budget
    {
        public int Amount { get; set; }

        public int Days => LastDay.Day;

        public DateTime FirstDay => DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);

        public DateTime LastDay
        {
            get
            {
                var daysInMonth = DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
                return new DateTime(FirstDay.Year, FirstDay.Month, daysInMonth);
            }
        }

        public string YearMonth { get; set; }

        public Period CreatePeriod()
        {
            return new Period(FirstDay, LastDay);
        }

        public int DailyAmount()
        {
            return Amount / Days;
        }

        public double OverlappingAmount(Period period)
        {
            return DailyAmount() * period.OverlappingDays(CreatePeriod());
        }
    }
}