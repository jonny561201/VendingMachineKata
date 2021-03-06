﻿using System.Collections.Generic;
using Moq;
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
            var stockItems = new List<StockItem> {new StockItem(VendingStock.Pop, 2)};
            _stockRepo.Setup(x => x.AddInventory(stock, 2)).Returns(stockItems);

            _stockStatus.AddInventory(stock, 2);

            _stockRepo.Verify(x => x.AddInventory(stock, 2), Times.Once);
        }

        [Test]
        public void VendingStockRepoReduceStockShouldBeCalled()
        {
            var stock = VendingStock.Pop;
            var stockItems = new List<StockItem> { new StockItem(VendingStock.Pop, 1) };
            _stockRepo.Setup(x => x.ReduceStock(stock, 1)).Returns(stockItems);

            _stockStatus.PurchaseItem(stock);

            _stockRepo.Verify(x => x.ReduceStock(stock, 1), Times.Once);
        }

        [Test]
        public void VendingStockRepoHasAvailableFundsShouldBeCalled()
        {
            var stock = VendingStock.Pop;
            var stockItems = new List<StockItem> { new StockItem(VendingStock.Pop, 1) };
            _stockRepo.Setup(x => x.GetInventory()).Returns(stockItems);

            _stockStatus.HasFundsAvailable(stock, 1.00m);

            _stockRepo.Verify(x => x.GetInventory(), Times.Once);
        }

        [Test]
        public void VendingStockRepoGetInventoryShouldBeCalled()
        {
            var stockItems = new List<StockItem> { new StockItem(VendingStock.Pop, 1) };
            _stockRepo.Setup(x => x.GetInventory()).Returns(stockItems);

            _stockStatus.HasAvailableItem(VendingStock.Pop);

            _stockRepo.Verify(x => x.GetInventory(), Times.Once);
        }

        [Test]
        public void HasAvailableItemReturnsTrueWhenStockIsGreaterThanOne()
        {
            var stockItems = new List<StockItem> { new StockItem(VendingStock.Pop, 2) };
            _stockRepo.Setup(x => x.GetInventory()).Returns(stockItems);

            var actual = _stockStatus.HasAvailableItem(VendingStock.Pop);

            Assert.IsTrue(actual);
        }

        [Test]
        public void HasAvailableItemReturnsTrueWhenStockIsOne()
        {
            var stockItems = new List<StockItem> {new StockItem(VendingStock.Chips, 2)};
            _stockRepo.Setup(x => x.GetInventory()).Returns(stockItems);
            var actual = _stockStatus.HasAvailableItem(VendingStock.Chips);

            Assert.IsTrue(actual);
        }

        [Test]
        public void HasAvaialbleItemReturnsFalseWhenStockIsZero()
        {
            var stockItems = new List<StockItem> { new StockItem(VendingStock.Pop, 0) };
            _stockRepo.Setup(x => x.GetInventory()).Returns(stockItems);
            var actual = _stockStatus.HasAvailableItem(VendingStock.Pop);

            Assert.IsFalse(actual);
        }

        [Test]
        public void HasFundsAvailableReturnsTrueWhenFundsAreGreaterThanRequired()
        {
            var funds = 1.25m;
            var stockItems = new List<StockItem> { new StockItem(VendingStock.Candy, 0) };
            _stockRepo.Setup(x => x.GetInventory()).Returns(stockItems);
            var actual = _stockStatus.HasFundsAvailable(VendingStock.Candy, funds);

            Assert.IsTrue(actual);
        }

        [Test]
        public void HasFundsAvailableReturnsTrueWhenFundsAreEqual()
        {
            var funds = 0.50m;
            var stockItems = new List<StockItem> { new StockItem(VendingStock.Chips, 0) };
            _stockRepo.Setup(x => x.GetInventory()).Returns(stockItems);

            var actual = _stockStatus.HasFundsAvailable(VendingStock.Chips, funds);

            Assert.IsTrue(actual);
        }
    }
}
