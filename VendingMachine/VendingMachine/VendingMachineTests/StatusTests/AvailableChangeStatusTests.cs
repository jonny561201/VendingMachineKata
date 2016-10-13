using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Status;

namespace VendingMachine.VendingMachineTests.StatusTests
{
    [TestFixture]
    public class AvailableChangeStatusTests
    {
        private AvailableChangeStatus _changeStatus = new AvailableChangeStatus();
        private VendingStock _stock;

        [Test]
        public void DepositChangeWillIncreaseTotalAvailableChangeByStockCost()
        {
            _stock = VendingStock.Pop;

            var actual = _changeStatus.DepositChange(_stock.Cost);

            Assert.AreEqual(_stock.Cost, actual);
        }

        [Test]
        public void MakeChangeWillReturnModulusOfInsertedValue()
        {
            _stock = VendingStock.Candy;
            var insertedAmount = 1.00m;
            var actual = _changeStatus.MakeChange(_stock.Cost, insertedAmount);

            Assert.AreEqual(0.35m, actual);
        }
    }
}
