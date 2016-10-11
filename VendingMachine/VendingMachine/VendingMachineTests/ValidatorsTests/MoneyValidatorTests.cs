using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Validators;

namespace VendingMachine.VendingMachineTests.ValidatorsTests
{
    [TestFixture]
    public class MoneyValidatorTests
    {
        private MoneyValidator moneyValidator = new MoneyValidator();

        [Test]
        public void IsValidCoinReturnsTrueForNickels()
        {
             var nickel = Coin.Nickel;

            var actual = moneyValidator.IsValidCoin(nickel);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsValidCoinReturnsFalseForPennies()
        {
            var penny = Coin.Penny;

            var actual = moneyValidator.IsValidCoin(penny);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsValidCoinReturnsTrueForDimes()
        {
            var dime = Coin.Dime;

            var actual = moneyValidator.IsValidCoin(dime);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsValidCoinReturnsTrueForQuarters()
        {
            var quarter = Coin.Quarter;

            var actual = moneyValidator.IsValidCoin(quarter);

            Assert.IsTrue(actual);
        }
    }
}
