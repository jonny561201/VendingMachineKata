using NUnit.Framework;
using VendingMachine.VendingMachine.Validators;

namespace VendingMachine.VendingMachineTests.ValidatorsTests
{
    [TestFixture]
    public class MoneyValidatorTests
    {
        private MoneyValidator moneyValidator = new MoneyValidator();

        [Test]
        public void ValidateCanAcceptNickels()
        {
            const string nickel = "Nickel";

            var actual = moneyValidator.IsValidCoin(nickel);

            Assert.IsTrue(actual);
        }
    }
}
