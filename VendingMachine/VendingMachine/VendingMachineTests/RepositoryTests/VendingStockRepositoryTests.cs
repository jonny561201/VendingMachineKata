using System.Collections.Generic;
using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Repository;

namespace VendingMachine.VendingMachineTests.RepositoryTests
{
    [TestFixture]
    public class VendingStockRepositoryTests
    {
        private VendingStockRepository _stockRepo;

        [SetUp]
        public void SetUp()
        {
            _stockRepo = new VendingStockRepository();
        }

        [Test]
        public void GetInventoryWillReturnListOfCurrentStock()
        {
            var expectedStock = new List<StockItem> { new StockItem(VendingStock.Candy, 0), new StockItem(VendingStock.Chips, 0), new StockItem(VendingStock.Pop, 0) };

            var totalStock = _stockRepo.GetInventory();

            CollectionAssert.AreEquivalent(expectedStock, totalStock);
        }

        [Test]
        public void AddInventoryWillUpdateListOfCurrentStock()
        {
            var expectedStock = new List<StockItem> { new StockItem(VendingStock.Candy, 0), new StockItem(VendingStock.Chips, 0), new StockItem(VendingStock.Pop, 10) };

            var actual = _stockRepo.AddInventory(VendingStock.Pop, 10);

            CollectionAssert.AreEquivalent(expectedStock, actual);
        }
    }
}
