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

                return (decimal)OverlappingAmount(budget, period);
            }

            return 0;
        }

        private static double OverlappingAmount(Budget budget, Period period)
        {
            return budget.DailyAmount() * period.OverlappingDays(budget.CreatePeriod());
        }
    }
}