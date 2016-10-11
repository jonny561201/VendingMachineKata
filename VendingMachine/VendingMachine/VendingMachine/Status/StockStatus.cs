using System;
using System.Diagnostics.PerformanceData;
using VendingMachine.Models;

namespace VendingMachine.VendingMachine.Status
{
    public class StockStatus
    {
        public static int CandyStock = 0;

        public static int AddInventory(VendingStock stock, int addedInventory)
        {
            if (stock == VendingStock.Candy)
            {
                CandyStock += addedInventory;
                return CandyStock;
            }
            return 0;
        }
    }
}
