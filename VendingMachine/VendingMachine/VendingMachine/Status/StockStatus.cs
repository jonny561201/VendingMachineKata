using System;
using System.Diagnostics.PerformanceData;
using VendingMachine.Models;

namespace VendingMachine.VendingMachine.Status
{
    public class StockStatus
    {
        private static int _candyStock;
        private static int _popStock;
        private static int _chipsStock;

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
            if (stock == VendingStock.Chips)
            {
                _chipsStock += addedInventory;
                return _chipsStock;
            }
            return 0;
        }
    }
}
