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
        public void AddInventoryWillUpdateListOfCurrentStockForPop()
        {
            var expectedStock = new List<StockItem> { new StockItem(VendingStock.Candy, 0), new StockItem(VendingStock.Chips, 0), new StockItem(VendingStock.Pop, 10) };

            var actual = _stockRepo.AddInventory(VendingStock.Pop, 10);

            CollectionAssert.AreEquivalent(expectedStock, actual);
        }

        [Test]
        public void AddInventoryWillUpdateListOfCurrentStockForChips()
        {
            var expectedStock = new List<StockItem> { new StockItem(VendingStock.Candy, 0), new StockItem(VendingStock.Chips, 5), new StockItem(VendingStock.Pop, 0) };

            var actual = _stockRepo.AddInventory(VendingStock.Chips, 5);

            CollectionAssert.AreEquivalent(expectedStock, actual);
        }

        [Test]
        public void AddInventoryWillUpdateListOfCurrentStockForCandy()
        {
            var expectedStock = new List<StockItem> { new StockItem(VendingStock.Candy, 7), new StockItem(VendingStock.Chips, 0), new StockItem(VendingStock.Pop, 0) };

            var actual = _stockRepo.AddInventory(VendingStock.Candy, 7);

            CollectionAssert.AreEquivalent(expectedStock, actual);
        }

        [Test]
        public void ReduceStockWillReduceListOfCurrentStockByOne()
        {
            var expectedStock = new List<StockItem> { new StockItem(VendingStock.Candy, 6), new StockItem(VendingStock.Chips, 0), new StockItem(VendingStock.Pop, 0) };

            _stockRepo.AddInventory(VendingStock.Candy, 7);
            var actual = _stockRepo.ReduceStock(VendingStock.Candy, 1);

            CollectionAssert.AreEquivalent(expectedStock, actual);
        }
    }
}
