using Moq;
using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Controllers;
using VendingMachine.VendingMachine.Validators;

namespace VendingMachine.VendingMachineTests.ControllersTests
{
    [TestFixture]
    public class SelectItemControllerTests
    {
        private SelectItemController _controller;
        private Mock<IStockPurchaseValidator> _itemValidator;

        [Test]
        public void SelectEvaluatesAvailabilityOfSelection()
        {
            _itemValidator = new Mock<IStockPurchaseValidator>();
            _controller = new SelectItemController(_itemValidator.Object);

            var stock = VendingStock.Candy;
            var tenderedAmount = 0.65m;
            _controller.Select(stock, tenderedAmount);

            _itemValidator.Verify(x => x.CanPurchase(stock, tenderedAmount));
        }
    }
}
