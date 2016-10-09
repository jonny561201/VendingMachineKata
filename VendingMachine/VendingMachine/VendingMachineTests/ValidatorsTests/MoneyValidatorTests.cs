using NUnit.Framework;
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
            const string nickel = "Nickel";

            var actual = moneyValidator.IsValidCoin(nickel);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsValidCoinReturnsFalseForPennies()
        {
            const string penny = "Penny";

            var actual = moneyValidator.IsValidCoin(penny);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsValidCoinReturnsTrueForDimes()
        {
            const string dime = "Dime";

            var actual = moneyValidator.IsValidCoin(dime);

            Assert.IsTrue(actual);
        }
    }
}
