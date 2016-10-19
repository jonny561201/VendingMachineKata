using NUnit.Framework;
using VendingMachine.Models;

namespace VendingMachine.VendingMachineTests.ModelsTests
{

    [TestFixture]
    public class StockItemTests
    {
        [Test]
        public void EqualsWillReturnTrueWhenPropertiesMatch()
        {
            var stock1 = new StockItem(VendingStock.Candy, 1);
            var stock2 = new StockItem(VendingStock.Candy, 1);

            Assert.AreEqual(stock1, stock2);
        }

    }
}
