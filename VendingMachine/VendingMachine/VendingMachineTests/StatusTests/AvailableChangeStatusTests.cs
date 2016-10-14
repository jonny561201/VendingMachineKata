using System.Collections.Generic;
using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Status;

namespace VendingMachine.VendingMachineTests.StatusTests
{
    [TestFixture]
    public class AvailableChangeStatusTests
    {
        private readonly AvailableChangeStatus _changeStatus = new AvailableChangeStatus();
        private VendingStock _stock;

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
    }
}
