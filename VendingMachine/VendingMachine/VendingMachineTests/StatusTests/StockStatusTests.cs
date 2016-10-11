using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Status;

namespace VendingMachine.VendingMachineTests.StatusTests
{
    [TestFixture]
    public class StockStatusTests
    {
        [Test]
        public void AddInventoryIncreasesTotalCandyStock()
        {
            var actual = StockStatus.AddInventory(VendingStock.Candy, 2);

            Assert.AreEqual(2, actual);
        }

        [Test]
        public void AddInventoryIncreasesTotalPopStock()
        {
            var actual = StockStatus.AddInventory(VendingStock.Pop, 5);

            Assert.AreEqual(5, actual);
        }
    }

}
