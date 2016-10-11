using System;
using System.Diagnostics.PerformanceData;
using VendingMachine.Models;

namespace VendingMachine.VendingMachine.Status
{
    public class StockStatus
    {
        private static int _candyStock = 0;
        private static int _popStock = 0;

        public static int AddInventory(VendingStock stock, int addedInventory)
        {
            if (stock == VendingStock.Candy)
            {
                _candyStock += addedInventory;
                return _candyStock;
            }
            if (stock == VendingStock.Pop)
            {
                _popStock += addedInventory;
                return _popStock;
            }
            return 0;
        }
    }
}
