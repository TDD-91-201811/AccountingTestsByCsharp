using System;
using System.Linq;

namespace AccountingTestsByCsharp
{
    public class Accounting
    {
        private readonly IRepository<Budget> _stubBudgetRepository;

        public Accounting(IRepository<Budget> stubBudgetRepository)
        {
            _stubBudgetRepository = stubBudgetRepository;
        }

        public decimal TotalAmount(DateTime start, DateTime end)
        {
            if (_stubBudgetRepository.GetAll().Any())
            {
                return (decimal)(end - start).TotalDays + 1;
            }

            return 0;
        }
    }
}