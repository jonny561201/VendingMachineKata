using System.Collections.Generic;
using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.Repository;

namespace VendingMachine.VendingMachineTests.RepositoryTests
{
    [TestFixture]
    public class AvailableReturnFundsRepositoryTests
    {
        private AvailableReturnFundsRepository _fundsRepo;

        [Test]
        public void AddAvailableFundsWillIncreaseInventory()
        {
            _fundsRepo = new AvailableReturnFundsRepository();
            var coins = new List<Coin> { Coin.Nickel };

            var actual = _fundsRepo.AddAvailableFunds(coins);

            Assert.AreEqual(coins, actual);
        }
    }
}
