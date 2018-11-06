using System;
using System.Linq;

namespace AccountingTestsByCsharp
{
    public class Accounting
    {
        private readonly IRepository<Budget> _budgetRepository;

        public Accounting(IRepository<Budget> budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public decimal TotalAmount(DateTime start, DateTime end)
        {
            var budgets = _budgetRepository.GetAll();

            if (budgets.Any())
            {
                var budget = budgets.First();
                var period = new Period(start, end);

                var dailyAmount = DailyAmount(budget);
                var overlappingDays = period.OverlappingDays(budget.CreatePeriod());
                return (decimal)(dailyAmount * overlappingDays);
            }

            return 0;
        }

        private static int DailyAmount(Budget budget)
        {
            return budget.Amount / budget.Days;
        }
    }
}