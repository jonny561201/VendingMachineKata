using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Validators;

namespace VendingMachine.VendingMachineTests.ValidatorsTests
{
    [TestFixture]
    public class ItemPurchaseValidatorTests
    {
        private decimal _amount;

        [Test]
        public void CanPurchaseReturnsTrueWithCorrectChangeForPop()
        {
            _amount = 1.00m;

            var actual = ItemPurchaseValidator.CanPurchase(VendingStock.Pop, _amount);

            Assert.IsTrue(actual);
        }

        [Test]
        public void CanPurchaseReturnsTrueWithExcessChangeForChips()
        {
            _amount = 0.55m;

            var actual = ItemPurchaseValidator.CanPurchase(VendingStock.Chips, _amount);

            Assert.IsTrue(actual);
        }

        [Test]
        public void CanPurchaseReturnsTrueWithExcessChangeForCandy()
        {
            _amount = 0.75m;

            var actual = ItemPurchaseValidator.CanPurchase(VendingStock.Candy, _amount);

            Assert.IsTrue(actual);
        }

        [Test]
        public void CanPurchaseReturnsFalseWhenNotEnoughChangeProvided()
        {
            _amount = 0.25m;

            var actual = ItemPurchaseValidator.CanPurchase(VendingStock.Pop, _amount);

            Assert.IsFalse(actual);
        }
    }
}
