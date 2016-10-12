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

        [Test]
        public void AddInventoryIncreasesTotalChipsStock()
        {
            var actual = StockStatus.AddInventory(VendingStock.Chips, 9);

            Assert.AreEqual(9, actual);
        }

        [Test]
        public void PurchaseItemWillRemoveOneItemFromInventory()
        {
            StockStatus.AddInventory(VendingStock.Candy, 3);

            var actual = StockStatus.PurchaseItem(VendingStock.Candy);

            Assert.AreEqual(2, actual);
        }

        [Test]
        public void HasAvailableItemReturnsTrueWhenStockIsGreaterThanOne()
        {
            StockStatus.AddInventory(VendingStock.Pop, 2);
            var actual = StockStatus.HasAvailableItem(VendingStock.Pop);

            Assert.IsTrue(actual);
        }

        [Test]
        public void HasAvailableItemReturnsTrueWhenStockIsOne()
        {
            StockStatus.AddInventory(VendingStock.Chips, 1);
            var actual = StockStatus.HasAvailableItem(VendingStock.Chips);

            Assert.IsTrue(actual);
        }

        [Test]
        public void HasAvaialbleItemReturnsFalseWhenStockIsZero()
        {
            var actual = StockStatus.HasAvailableItem(VendingStock.Pop);

            Assert.IsFalse(actual);
        }
    }
}
