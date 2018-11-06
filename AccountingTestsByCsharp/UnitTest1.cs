using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AccountingTestsByCsharp
{
    [TestClass]
    public class AccountingTests
    {
        [TestMethod]
        public void no_budgets()
        {
            var accounting = new Accounting();
            var totalAmount = accounting.TotalAmount(new DateTime(2010, 4, 1), new DateTime(2010, 4, 1));
            Assert.AreEqual(0, totalAmount);
        }
    }
}