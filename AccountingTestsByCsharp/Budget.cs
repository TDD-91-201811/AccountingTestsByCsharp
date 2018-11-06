using System;

namespace AccountingTestsByCsharp
{
    public class Budget
    {
        public int Amount { get; set; }

        public DateTime FirstDay
        {
            get
            {
                var firstDay = DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);
                return firstDay;
            }
        }

        public string YearMonth { get; set; }
    }
}