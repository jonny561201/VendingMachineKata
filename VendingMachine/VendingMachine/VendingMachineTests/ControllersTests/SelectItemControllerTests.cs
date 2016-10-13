using Moq;
using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Controllers;
using VendingMachine.VendingMachine.Status;
using VendingMachine.VendingMachine.Validators;

namespace VendingMachine.VendingMachineTests.ControllersTests
{
    [TestFixture]
    public class SelectItemControllerTests
    {
        private SelectItemController _controller;
        private Mock<IStockStatus> _stockStatus; 
        private Mock<IStockPurchaseValidator> _itemValidator;

        [Test]
        public void SelectEvaluatesAvailabilityOfSelection()
        {
            _itemValidator = new Mock<IStockPurchaseValidator>();
            _stockStatus = new Mock<IStockStatus>();
            _controller = new SelectItemController(_itemValidator.Object, _stockStatus.Object);

            var stock = VendingStock.Candy;
            var tenderedAmount = 0.65m;
            _controller.Select(stock, tenderedAmount);

            _stockStatus.Verify(x => x.HasAvailableItem(stock), Times.Once);
            _itemValidator.Verify(x => x.CanPurchase(stock, tenderedAmount), Times.Once);
        }
    }
}
