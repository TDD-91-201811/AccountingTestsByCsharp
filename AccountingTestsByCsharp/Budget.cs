using System;

namespace AccountingTestsByCsharp
{
    public class Budget
    {
        public int Amount { get; set; }

        public int Days
        {
            get { return 30; }
        }

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
    }
}