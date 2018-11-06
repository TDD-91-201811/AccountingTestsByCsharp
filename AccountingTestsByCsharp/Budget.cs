using System;

namespace AccountingTestsByCsharp
{
    public class Budget
    {
        public int Amount { get; set; }

        public DateTime FirstDay => DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);

        public string YearMonth { get; set; }
    }
}