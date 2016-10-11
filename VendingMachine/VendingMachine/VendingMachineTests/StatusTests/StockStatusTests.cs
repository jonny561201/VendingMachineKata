using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Status;

namespace VendingMachine.VendingMachineTests.StatusTests
{
    [TestFixture]
    public class StockStatusTests
    {
        private StockStatus _stockStatus = new StockStatus();

        [Test]
        public void AddInventoryIncreasesTotalStockByTwo()
        {
            var actual = StockStatus.AddInventory(VendingStock.Candy, 2);

            Assert.AreEqual(2, actual);
        }
    }

}
