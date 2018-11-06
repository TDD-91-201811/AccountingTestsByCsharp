using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AccountingTestsByCsharp
{
    [TestClass]
    public class AccountingTests
    {
        private Accounting _accounting = new Accounting();

        [TestMethod]
        public void no_budgets()
        {
            TotalAmountShouldBe(0, new DateTime(2010, 4, 1), new DateTime(2010, 4, 1));
        }

        private void TotalAmountShouldBe(decimal expected, DateTime start, DateTime end)
        {
            Assert.AreEqual(expected, _accounting.TotalAmount(start, end));
        }
    }
}