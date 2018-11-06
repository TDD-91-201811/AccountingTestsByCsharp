using System;

namespace AccountingTestsByCsharp
{
    public class Budget
    {
        public int Amount { get; set; }

        public string YearMonth { get; set; }
        private int Days => LastDay.Day;

        private DateTime FirstDay => DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);

        private DateTime LastDay
        {
            get
            {
                var daysInMonth = DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
                return new DateTime(FirstDay.Year, FirstDay.Month, daysInMonth);
            }
        }

        public decimal OverlappingAmount(Period period)
        {
            return (decimal)(DailyAmount() * period.OverlappingDays(CreatePeriod()));
        }

        private Period CreatePeriod()
        {
            return new Period(FirstDay, LastDay);
        }

        private int DailyAmount()
        {
            return Amount / Days;
        }
    }
}