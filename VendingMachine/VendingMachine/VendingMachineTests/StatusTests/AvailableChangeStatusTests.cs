using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Status;

namespace VendingMachine.VendingMachineTests.StatusTests
{
    [TestFixture]
    public class AvailableChangeStatusTests
    {
        private AvailableChangeStatus _changeStatus;
        private VendingStock _stock;

        [Test]
        public void DepositChangeWillIncreaseTotalAvailableChangeByStockCost()
        {
            _changeStatus = new AvailableChangeStatus();
            _stock = VendingStock.Pop;

            var actual = _changeStatus.DepositChange(_stock);

            Assert.AreEqual(_stock.Cost, actual);
        }
    }
}
