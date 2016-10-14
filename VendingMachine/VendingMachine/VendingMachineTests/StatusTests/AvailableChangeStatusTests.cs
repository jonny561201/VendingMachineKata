using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.Repository;
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

            var actual = AvailableChangeStatus.MakeChange(_stock.Cost, insertedAmount);

            CollectionAssert.AreEquivalent(expectedResults, actual);
        }

        [Test]
        public void MakeChangeWillReturnChangeInHighestDenominatonsPossible()
        {
            _stock = VendingStock.Chips;
            var insertedAmount = 1.25m;
            var expectedResults = new List<Coin> {Coin.Quarter, Coin.Quarter, Coin.Quarter};

            var actual = AvailableChangeStatus.MakeChange(_stock.Cost, insertedAmount);

            CollectionAssert.AreEquivalent(expectedResults, actual);
        }

        [Test]
        public void AddChangeWillIncreaseTheInventoryOfChangeToReturn()
        {
            var coins = new List<Coin> {Coin.Quarter, Coin.Dime, Coin.Nickel, Coin.Quarter};
            var actual = _changeStatus.AddChange(coins);

            Assert.AreEqual(coins, actual);
        }

        [Test]
        public void AddChangeCalledTwiceWillAppendInventory()
        {
            var coins = new List<Coin> {Coin.Dime, Coin.Dime};
            var expectedCoins = new List<Coin> {Coin.Dime, Coin.Dime, Coin.Dime, Coin.Dime};

            _changeStatus.AddChange(coins);
            var actual = _changeStatus.AddChange(coins);

            Assert.AreEqual(expectedCoins, actual);
        }
    }
}
