using NUnit.Framework;
using VendingMachine.Models;

namespace VendingMachine.VendingMachineTests.ModelsTests
{

    [TestFixture]
    public class StockItemTests
    {
        [Test]
        public void EqualsReturnTrueWhenPropertiesMatch()
        {
            var stock1 = new StockItem(VendingStock.Candy, 1);
            var stock2 = new StockItem(VendingStock.Candy, 1);

            Assert.AreEqual(stock1, stock2);
        }

        [Test]
        public void EqualsReturnsFalseWhenPropertiesDontMatch()
        {
            var stock1 = new StockItem(VendingStock.Candy, 1);
            var stock2 = new StockItem(VendingStock.Chips, 0);

            Assert.AreNotEqual(stock1, stock2);
        }

        [Test]
        public void EqualsReturnsFalseWhenOnePropertyDoesntMatch()
        {
            var stock1 = new StockItem(VendingStock.Pop, 3);
            var stock2 = new StockItem(VendingStock.Chips, 3);

            Assert.AreNotEqual(stock1, stock2);
        }
    }
}

