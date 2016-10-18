using System.Collections.Generic;
using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Repository;

namespace VendingMachine.VendingMachineTests.RepositoryTests
{
    [TestFixture]
    public class AvailableReturnFundsRepositoryTests
    {
        private AvailableReturnFundsRepository _fundsRepo;

        [SetUp]
        public void SetUp()
        {
            _fundsRepo = new AvailableReturnFundsRepository();
        }

        [Test]
        public void AddAvailableFundsWillIncreaseInventory()
        {
            var coins = new List<Coin> { Coin.Nickel };

            var actual = _fundsRepo.AddAvailableFunds(coins);

            Assert.AreEqual(coins, actual);
        }

        [Test]
        public void AddAvailableFundsCalledTwiceWillAppendInventory()
        {
            var coins = new List<Coin> { Coin.Dime, Coin.Dime };
            var expectedCoins = new List<Coin> { Coin.Dime, Coin.Dime, Coin.Dime, Coin.Dime };

            _fundsRepo.AddAvailableFunds(coins);
            var actual = _fundsRepo.AddAvailableFunds(coins);

            Assert.AreEqual(expectedCoins, actual);
        }

        [Test]
        public void AddAvailableFundsWillReturnNewListWhenNull()
        {
            var actual = _fundsRepo.AddAvailableFunds(null);

            CollectionAssert.AreEquivalent(new List<Coin>(), actual);
        }

        //Add null to list with items already included
    }
}
