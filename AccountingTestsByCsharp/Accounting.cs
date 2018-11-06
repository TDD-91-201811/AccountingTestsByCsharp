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
            if (_budgetRepository.GetAll().Any())
            {
                var budget = _budgetRepository.GetAll().First();
                var period = new Period(start, end);

                return (decimal)OverlappingDays(period, budget);
            }

            return 0;
        }

        private static double OverlappingDays(Period period, Budget budget)
        {
            if (period.End < budget.FirstDay)
            {
                return 0;
            }

            return period.Days();
        }
    }
}