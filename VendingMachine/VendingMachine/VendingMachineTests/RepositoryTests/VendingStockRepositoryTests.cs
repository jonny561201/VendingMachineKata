using System.Collections.Generic;
using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Repository;

namespace VendingMachine.VendingMachineTests.RepositoryTests
{
    [TestFixture]
    public class VendingStockRepositoryTests
    {
        [Test]
        public void GetInventoryWillReturnListOfCurrentStock()
        {
            var stockRepo = new VendingStockRepository();
            var expectedStock = new List<StockItem> { new StockItem(VendingStock.Candy, 0), new StockItem(VendingStock.Chips, 0), new StockItem(VendingStock.Pop, 0) };

            var totalStock = stockRepo.GetInventory();

            CollectionAssert.AreEquivalent(expectedStock, totalStock);
        }

    }
}
