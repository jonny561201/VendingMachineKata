﻿using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Repository;
using VendingMachine.VendingMachine.Status;

namespace VendingMachine.VendingMachineTests.StatusTests
{
    [TestFixture]
    public class AvailableChangeStatusTests
    {
        private VendingStock _stock;
        private AvailableChangeStatus _changeStatus;
        private Mock<IAvailableReturnFundsRepo> _returnRepo;

        [SetUp]
        public void SetUp()
        {
            _returnRepo = new Mock<IAvailableReturnFundsRepo>();
            _changeStatus = new AvailableChangeStatus(_returnRepo.Object);
        }

        [Test]
        public void DepositChangeWillIncreaseTotalAvailableChangeByStockCost()
        {
            _stock = VendingStock.Pop;

            var actual = _changeStatus.DepositChange(_stock.Cost);

            Assert.AreEqual(_stock.Cost, actual);
        }

        [Test]
        public void MakeChangeWillReturnModulusOfInsertedValueInCorrectDenominations()
        {
            _stock = VendingStock.Candy;
            var insertedAmount = 1.00m;
            var expectedResults = new List<Coin> {Coin.Quarter, Coin.Dime };

            var actual = _changeStatus.MakeChange(_stock.Cost, insertedAmount);

            CollectionAssert.AreEquivalent(expectedResults, actual);
        }

        [Test]
        public void MakeChangeWillReturnChangeInHighestDenominatonsPossible()
        {
            _stock = VendingStock.Chips;
            var insertedAmount = 1.25m;
            var expectedResults = new List<Coin> {Coin.Quarter, Coin.Quarter, Coin.Quarter};

            var actual = _changeStatus.MakeChange(_stock.Cost, insertedAmount);

            CollectionAssert.AreEquivalent(expectedResults, actual);
        }

        [Test]
        public void IncreaseCoinReturnInventoryWillIncreaseTheInventoryOfChangeToReturn()
        {
            var coins = new List<Coin> {Coin.Quarter, Coin.Dime, Coin.Nickel, Coin.Quarter};
            _returnRepo.Setup(x => x.AddAvailableFunds(coins)).Returns(coins);

            var actual = _changeStatus.IncreaseCoinReturnInventory(coins);

            _returnRepo.Verify(x => x.AddAvailableFunds(coins), Times.Once);
        }
    }
}
