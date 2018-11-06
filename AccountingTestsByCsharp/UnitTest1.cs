using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Linq;

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
            GivenBudgets();
            TotalAmountShouldBe(0, new DateTime(2010, 4, 1), new DateTime(2010, 4, 1));
        }

        [TestMethod]
        public void period_inside_budget_month()
        {
            GivenBudgets(new Budget { YearMonth = "201004", Amount = 30 });
            TotalAmountShouldBe(1, new DateTime(2010, 4, 1), new DateTime(2010, 4, 1));
        }

        [TestMethod]
        public void period_no_overlapping_after_budget_lastDay()
        {
            GivenBudgets(new Budget { YearMonth = "201004", Amount = 30 });
            TotalAmountShouldBe(0, new DateTime(2010, 5, 1), new DateTime(2010, 5, 1));
        }

        [TestMethod]
        public void period_no_overlapping_before_budget_firstDay()
        {
            GivenBudgets(new Budget { YearMonth = "201004", Amount = 30 });
            TotalAmountShouldBe(0, new DateTime(2010, 3, 31), new DateTime(2010, 3, 31));
        }

        [TestInitialize]
        public void TestInit()
        {
            _accounting = new Accounting(_stubBudgetRepository);
        }

        private void GivenBudgets(params Budget[] budgets)
        {
            _stubBudgetRepository.GetAll().Returns(budgets.ToList());
        }

        private void TotalAmountShouldBe(decimal expected, DateTime start, DateTime end)
        {
            Assert.AreEqual(expected, _accounting.TotalAmount(start, end));
        }
    }
}