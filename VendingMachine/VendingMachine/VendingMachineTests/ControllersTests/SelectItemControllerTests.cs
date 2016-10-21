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
        private Mock<IAvailableChangeStatus> _changeStatus; 
        private Mock<IStockPurchaseValidator> _itemValidator;
        private readonly VendingStock _stock = VendingStock.Candy;
        private const decimal TenderedAmount = 0.65m;

        [SetUp]
        public void SetUp()
        {
            _stockStatus = new Mock<IStockStatus>();
            _changeStatus = new Mock<IAvailableChangeStatus>();
            _itemValidator = new Mock<IStockPurchaseValidator>();
            _controller = new SelectItemController(_itemValidator.Object, _stockStatus.Object, _changeStatus.Object);
        }
        [Test]
        public void SelectItemForPurchaseWillNotCallPurchaseItemWhenNoItemAvailable()
        {
            _stockStatus.Setup(x => x.HasAvailableItem(_stock)).Returns(false);
            _itemValidator.Setup(x => x.CanPurchase(_stock, TenderedAmount)).Returns(true);

            _controller.SelectItemForPurchase(_stock, TenderedAmount);

            _stockStatus.Verify(x => x.HasAvailableItem(_stock), Times.Once);
            _stockStatus.Verify(x => x.PurchaseItem(_stock), Times.Never);
        }

        [Test]
        public void SelectItemForPurchaseWillNotCallPurchaseItemWhenDontHaveAvailableFunds()
        {
            _stockStatus.Setup(x => x.HasAvailableItem(_stock)).Returns(true);
            _itemValidator.Setup(x => x.CanPurchase(_stock, TenderedAmount)).Returns(false);

            _controller.SelectItemForPurchase(_stock, TenderedAmount);

            _itemValidator.Verify(x => x.CanPurchase(_stock, TenderedAmount), Times.Once);
            _stockStatus.Verify(x => x.PurchaseItem(_stock), Times.Never);
        }

        [Test]
        public void SelectItemForPurchaseWillCallPurchaseITemWhenFundAndItemAvailable()
        {
            var tenderedAmount = 0.75m;
            var stock = VendingStock.Chips;
            _stockStatus.Setup(x => x.HasAvailableItem(stock)).Returns(true);
            _itemValidator.Setup(x => x.CanPurchase(stock, tenderedAmount)).Returns(true);

            _controller.SelectItemForPurchase(stock, tenderedAmount);

            _changeStatus.Verify(x => x.MakeChange(stock.Cost, tenderedAmount), Times.Once);
            _changeStatus.Verify(x => x.DepositChange(stock.Cost), Times.Once);
            _itemValidator.Verify(x => x.CanPurchase(stock, tenderedAmount), Times.Once);
            _stockStatus.Verify(x => x.HasAvailableItem(stock), Times.Once);
            _stockStatus.Verify(x => x.PurchaseItem(stock), Times.Once);
        }

        [Test]
        public void SelectItemForPurchaseWillReturnThankYouWhenItemPurchased()
        {
            var tenderedAmount = 0.75m;
            var stock = VendingStock.Chips;
            _stockStatus.Setup(x => x.HasAvailableItem(stock)).Returns(true);
            _itemValidator.Setup(x => x.CanPurchase(stock, tenderedAmount)).Returns(true);

            var actual = _controller.SelectItemForPurchase(stock, tenderedAmount);

            Assert.AreEqual("THANK YOU", actual);
        }

        [Test]
        public void SelectItemForPurchaseWillReturnSoldOutWhenItemOutOfStock()
        {
            var tenderedAmount = 0.75m;
            var stock = VendingStock.Chips;
            _stockStatus.Setup(x => x.HasAvailableItem(stock)).Returns(false);
            _itemValidator.Setup(x => x.CanPurchase(stock, tenderedAmount)).Returns(true);

            var actual = _controller.SelectItemForPurchase(stock, tenderedAmount);

            Assert.AreEqual("SOLD OUT", actual);
        }

        [Test]
        public void SelectItemForPurchaseWillReturnPriceOfItemWhenNotEnoughFundsProvided()
        {
            var tenderedAmount = 0.75m;
            var stock = VendingStock.Pop;
            _stockStatus.Setup(x => x.HasAvailableItem(stock)).Returns(true);
            _itemValidator.Setup(x => x.CanPurchase(stock, tenderedAmount)).Returns(false);

            var actual = _controller.SelectItemForPurchase(stock, tenderedAmount);

            Assert.AreEqual("PRICE $1.00", actual);
        }
    }
}
