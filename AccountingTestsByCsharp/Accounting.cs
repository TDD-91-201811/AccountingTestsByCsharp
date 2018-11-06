using System;

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

            var period = new Period(start, end);
            decimal totalAmount = 0;
            foreach (var budget in budgets)
            {
                totalAmount += budget.OverlappingAmount(period);
            }

            return totalAmount;
        }
    }
}