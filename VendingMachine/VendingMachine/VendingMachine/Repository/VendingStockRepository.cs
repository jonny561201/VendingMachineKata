using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Status;

namespace VendingMachine.VendingMachine.Repository
{
    public class VendingStockRepository
    {
        private readonly List<StockItem> _stock = new List<StockItem> {  };

        public IEnumerable<StockItem> GetInventory()
        {
            return _stock;
        }
    }
}
