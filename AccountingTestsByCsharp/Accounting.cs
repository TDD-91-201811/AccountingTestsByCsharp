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
                return (decimal)Days(new Period(start, end));
            }

            return 0;
        }

        private static double Days(Period period)
        {
            return (period.End - period.Start).TotalDays + 1;
        }
    }
}