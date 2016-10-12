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
            UpdateInventory(stockItem, addedInventory);

            return stockItem.AvailableStock;
        }

        private static void UpdateInventory(StockItem item, int additionalInventory)
        {
            item.AvailableStock += additionalInventory;
        }
    }
}
