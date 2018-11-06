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
                var period = new Period(start, end);
                return (decimal)period.Days();
            }

            return 0;
        }
    }
}