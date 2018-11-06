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
                return (decimal)Days(start, end);
            }

            return 0;
        }

        private static double Days(DateTime start, DateTime end)
        {
            return (end - start).TotalDays + 1;
        }
    }
}