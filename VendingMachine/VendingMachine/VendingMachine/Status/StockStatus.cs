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
        private readonly IVendingStockRepository _vendingStockRepository;
        private readonly List<StockItem> _stock = new List<StockItem> {new StockItem(VendingStock.Candy, 0), new StockItem(VendingStock.Chips, 0), new StockItem(VendingStock.Pop, 0)};

        public StockStatus(IVendingStockRepository vendingStockRepository)
        {
            _vendingStockRepository = vendingStockRepository;
        }

        public int AddInventory(VendingStock stock, int addedInventory)
        {
            var stockItem = _stock.Single(x => x.Item == stock);
            _vendingStockRepository.AddInventory(stockItem.Item, addedInventory);

            return stockItem.AvailableStock;
        }

        public int PurchaseItem(VendingStock stock)
        {
            var stockItem = _stock.Single(x => x.Item == stock);
            PurchaseInventory(stockItem);

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

        private static void PurchaseInventory(StockItem item)
        {
            item.AvailableStock -= 1;
        }

        private static void AddInventory(StockItem item, int additionalInventory)
        {
            item.AvailableStock += additionalInventory;
        }
    }
}
