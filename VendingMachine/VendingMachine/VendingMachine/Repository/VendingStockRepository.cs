using System.Collections;
using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.VendingMachine.Repository
{
    public class VendingStockRepository
    {
        private readonly List<StockItem> _stock = new List<StockItem> { new StockItem(VendingStock.Candy, 0), new StockItem(VendingStock.Chips, 0), new StockItem(VendingStock.Pop, 0) };

        public IEnumerable<StockItem> GetInventory()
        {
            return _stock;
        }

        public IEnumerable<StockItem> AddInventory(VendingStock pop, int addedInventory)
        {
            throw new System.NotImplementedException();
        }
    }
}
