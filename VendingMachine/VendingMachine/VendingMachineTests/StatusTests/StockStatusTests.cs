﻿using Moq;
using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Repository;
using VendingMachine.VendingMachine.Status;

namespace VendingMachine.VendingMachineTests.StatusTests
{
    [TestFixture]
    public class StockStatusTests
    {
        private StockStatus _stockStatus;
        private Mock<IVendingStockRepository> _stockRepo;

        [SetUp]
        public void SetUp()
        {
            _stockRepo = new Mock<IVendingStockRepository>();
            _stockStatus = new StockStatus(_stockRepo.Object);
        }

        [Test]
        public void VendingStockRepoAddInventoryShouldBeCalled()
        {
            var stock = VendingStock.Pop;
            _stockStatus.AddInventory(stock, 2);

            _stockRepo.Verify(x => x.AddInventory(stock, 2), Times.Once);
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
