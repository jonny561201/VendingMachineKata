using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Validators;

namespace VendingMachine.VendingMachineTests.ValidatorsTests
{
    [TestFixture]
    public class ItemPurchaseValidatorTests
    {
        private readonly ItemPurchaseValidator _purchaseValidator = new ItemPurchaseValidator();
        private decimal _amount;

        [Test]
        public void CanPurchaseReturnsTrueWithCorrectChangeForPop()
        {
            _amount = 1.00m;

            var actual = _purchaseValidator.CanPurchase(VendingStock.Pop, _amount);

            Assert.IsTrue(actual);
        }
    }
}
