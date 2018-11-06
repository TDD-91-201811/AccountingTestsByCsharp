using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace AccountingTestsByCsharp
{
    [TestClass]
    public class AccountingTests
    {
        private Accounting _accounting;
        private IRepository<Budget> _stubBudgetRepository = Substitute.For<IRepository<Budget>>();

        [TestMethod]
        public void no_budgets()
        {
            _stubBudgetRepository.GetAll().Returns(new List<Budget>());
            TotalAmountShouldBe(0, new DateTime(2010, 4, 1), new DateTime(2010, 4, 1));
        }

        [TestMethod]
        public void period_inside_budget_month()
        {
            _stubBudgetRepository.GetAll().Returns(new List<Budget>
            {
                new Budget {YearMonth = "201004", Amount = 30},
            });

            TotalAmountShouldBe(1, new DateTime(2010, 4, 1), new DateTime(2010, 4, 1));
        }

        [TestInitialize]
        public void TestInit()
        {
            _accounting = new Accounting(_stubBudgetRepository);
        }

        private void TotalAmountShouldBe(decimal expected, DateTime start, DateTime end)
        {
            Assert.AreEqual(expected, _accounting.TotalAmount(start, end));
        }
    }
}