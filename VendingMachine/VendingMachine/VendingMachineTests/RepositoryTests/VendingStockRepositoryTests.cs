using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Repository;
using VendingMachine.VendingMachine.Status;

namespace VendingMachine.VendingMachineTests.RepositoryTests
{
    [TestFixture]
    public class VendingStockRepositoryTests
    {
        [Test]
        public void GetInventoryWillReturnListOfCurrentStock()
        {
            var stockRepo = new VendingStockRepository();
            var expectedStock = new List<StockItem>{};

            var totalStock = stockRepo.GetInventory();

            CollectionAssert.AreEquivalent(expectedStock, totalStock);
        }

    }
}
