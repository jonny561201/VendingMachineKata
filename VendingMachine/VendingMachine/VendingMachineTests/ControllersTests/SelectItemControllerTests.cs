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
        private readonly VendingStock _stock = VendingStock.Candy;
        private const decimal TenderedAmount = 0.65m;

        [SetUp]
        public void SetUp()
        {
            _itemValidator = new Mock<IStockPurchaseValidator>();
            _stockStatus = new Mock<IStockStatus>();
            _controller = new SelectItemController(_itemValidator.Object, _stockStatus.Object);
        }

        [Test]
        public void SelectEvaluatesAvailabilityOfSelection()
        {
            _controller.Select(_stock, TenderedAmount);

            _stockStatus.Verify(x => x.HasAvailableItem(_stock), Times.Once);
            _itemValidator.Verify(x => x.CanPurchase(_stock, TenderedAmount), Times.Once);
            _stockStatus.Verify(x => x.PurchaseItem(_stock), Times.Once);
        }

        [Test]
        public void SelectWillNotCallPurchaseItemWhenNoItemAvailable()
        {
            _stockStatus.Setup(x => x.HasAvailableItem(_stock)).Returns(false);

            _controller.Select(_stock, TenderedAmount);

            _stockStatus.Verify(x => x.PurchaseItem(_stock), Times.Never);
        }
    }
}
