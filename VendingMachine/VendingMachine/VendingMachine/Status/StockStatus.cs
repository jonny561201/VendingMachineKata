using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using VendingMachine.Models;

namespace VendingMachine.VendingMachine.Status
{
    public class StockStatus
    {

        private static readonly List<StockItem> Stock = new List<StockItem> {new StockItem(VendingStock.Candy, 0), new StockItem(VendingStock.Chips, 0), new StockItem(VendingStock.Pop, 0)}; 

        public static int AddInventory(VendingStock stock, int addedInventory)
        {
            var stockItem = Stock.Single(x => x.Item == stock);
            AddInventory(stockItem, addedInventory);

            return stockItem.AvailableStock;
        }

        public static int PurchaseItem(VendingStock stock)
        {
            var stockItem = Stock.Single(x => x.Item == stock);
            PurcahseInventory(stockItem);

            return stockItem.AvailableStock;
        }

        public static bool HasAvailableItem(VendingStock item)
        {
            return Stock.Single(x => x.Item == item).AvailableStock > 1;
        }

        public static bool HasFundsAvailable(VendingStock item, decimal funds)
        {
            return Stock.Single(x => x.Item == item).Item.Cost < funds;
        }

        private static void PurcahseInventory(StockItem item)
        {
            item.AvailableStock -= 1;
        }

        private static void AddInventory(StockItem item, int additionalInventory)
        {
            item.AvailableStock += additionalInventory;
        }
    }
}
