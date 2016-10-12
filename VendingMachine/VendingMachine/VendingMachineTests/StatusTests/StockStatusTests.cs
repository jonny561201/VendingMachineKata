using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Status;

namespace VendingMachine.VendingMachineTests.StatusTests
{
    [TestFixture]
    public class StockStatusTests
    {
        private StockStatus _stockStatus;

        [SetUp]
        public void SetUp()
        {
            _stockStatus = new StockStatus();
        }

        [Test]
        public void AddInventoryIncreasesTotalCandyStock()
        {
            var actual = _stockStatus.AddInventory(VendingStock.Candy, 2);

            Assert.AreEqual(2, actual);
        }

        [Test]
        public void AddInventoryIncreasesTotalPopStock()
        {
            var actual = _stockStatus.AddInventory(VendingStock.Pop, 5);

            Assert.AreEqual(5, actual);
        }

        [Test]
        public void AddInventoryIncreasesTotalChipsStock()
        {
            var actual = _stockStatus.AddInventory(VendingStock.Chips, 9);

            Assert.AreEqual(9, actual);
        }

        [Test]
        public void PurchaseItemWillRemoveOneItemFromInventory()
        {
            _stockStatus.AddInventory(VendingStock.Candy, 3);

            var actual = _stockStatus.PurchaseItem(VendingStock.Candy);

            Assert.AreEqual(2, actual);
        }

        [Test]
        public void HasAvailableItemReturnsTrueWhenStockIsGreaterThanOne()
        {
            _stockStatus.AddInventory(VendingStock.Pop, 2);
            var actual = _stockStatus.HasAvailableItem(VendingStock.Pop);

            Assert.IsTrue(actual);
        }

        [Test]
        public void HasAvailableItemReturnsTrueWhenStockIsOne()
        {
            _stockStatus.AddInventory(VendingStock.Chips, 1);
            var actual = _stockStatus.HasAvailableItem(VendingStock.Chips);

            Assert.IsTrue(actual);
        }

        [Test]
        public void HasAvaialbleItemReturnsFalseWhenStockIsZero()
        {
            var actual = _stockStatus.HasAvailableItem(VendingStock.Pop);

            Assert.IsFalse(actual);
        }

        [Test]
        public void HasFundsAvailableReturnsTrueWhenFundsAreGreaterThanRequired()
        {
            var funds = 1.25m;
            var actual = _stockStatus.HasFundsAvailable(VendingStock.Candy, funds);

            Assert.IsTrue(actual);
        }

        [Test]
        public void HasFundsAvailableReturnsTrueWhenFundsAreEqual()
        {
            var funds = 0.50m;
            var actual = _stockStatus.HasFundsAvailable(VendingStock.Chips, funds);

            Assert.IsTrue(actual);
        }
    }
}
