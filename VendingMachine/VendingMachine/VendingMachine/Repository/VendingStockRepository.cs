using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Models;

namespace VendingMachine.VendingMachine.Repository
{
    public interface IVendingStockRepository
    {
        IEnumerable<StockItem> GetInventory();
        IEnumerable<StockItem> AddInventory(VendingStock item, int addedInventory);
        IEnumerable<StockItem> ReduceStock(VendingStock item, int reduceAmount);
    }

    public class VendingStockRepository : IVendingStockRepository
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

        public IEnumerable<StockItem> ReduceStock(VendingStock item, int reduceAmount)
        {
            var stockItem = _stock.Single(x => x.Item == item);
            stockItem.AvailableStock -= reduceAmount;

            return _stock;
        }
    }
}
