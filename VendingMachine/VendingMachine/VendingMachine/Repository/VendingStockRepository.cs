using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<StockItem> AddInventory(VendingStock item, int addedInventory)
        {
            var stockItem = _stock.Single(x => x.Item == item);
            stockItem.AvailableStock += addedInventory;

            return _stock;
        }
    }
}
