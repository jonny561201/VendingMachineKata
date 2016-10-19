using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Repository;

namespace VendingMachine.VendingMachine.Status
{
    public interface IStockStatus
    {
        int AddInventory(VendingStock stock, int addedInventory);
        int PurchaseItem(VendingStock stock);
        bool HasAvailableItem(VendingStock stock);
    }

    public class StockStatus : IStockStatus
    {
        private const int ReduceStock = 1;
        private readonly IVendingStockRepository _vendingStockRepository;
        private readonly List<StockItem> _stock = new List<StockItem> {new StockItem(VendingStock.Candy, 0), new StockItem(VendingStock.Chips, 0), new StockItem(VendingStock.Pop, 0)};

        public StockStatus(IVendingStockRepository vendingStockRepository)
        {
            _vendingStockRepository = vendingStockRepository;
        }

        public int AddInventory(VendingStock stock, int addedInventory)
        {
            var stockItems = _vendingStockRepository.AddInventory(stock, addedInventory);
            var stockItem = stockItems.Single(x => x.Item == stock);

            return stockItem.AvailableStock;
        }

        public int PurchaseItem(VendingStock stock)
        {
            var stockItems = _vendingStockRepository.ReduceStock(stock, ReduceStock);
            var stockItem = stockItems.Single(x => x.Item == stock);

            return stockItem.AvailableStock;
        }

        public bool HasAvailableItem(VendingStock item)
        {
            var stock = _vendingStockRepository.GetInventory();
            return stock.Single(x => x.Item == item).AvailableStock >= 1;
        }

        public bool HasFundsAvailable(VendingStock item, decimal funds)
        {
            return _stock.Single(x => x.Item == item).Item.Cost <= funds;
        }
    }
}
