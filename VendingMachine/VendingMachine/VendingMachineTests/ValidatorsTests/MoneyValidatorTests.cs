using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Validators;

namespace VendingMachine.VendingMachineTests.ValidatorsTests
{
    [TestFixture]
    public class MoneyValidatorTests
    {
        private readonly MoneyValidator _moneyValidator = new MoneyValidator();

        [Test]
        public void IsValidCoinReturnsTrueForNickels()
        {
             var nickel = Coin.Nickel;

            var actual = _moneyValidator.IsValidCoin(nickel);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsValidCoinReturnsFalseForPennies()
        {
            var penny = Coin.Penny;

            var actual = _moneyValidator.IsValidCoin(penny);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsValidCoinReturnsTrueForDimes()
        {
            var dime = Coin.Dime;

            var actual = _moneyValidator.IsValidCoin(dime);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsValidCoinReturnsTrueForQuarters()
        {
            var quarter = Coin.Quarter;

            var actual = _moneyValidator.IsValidCoin(quarter);

            Assert.IsTrue(actual);
        }
    }
}
