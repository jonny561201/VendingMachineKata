using VendingMachine.Models;

namespace VendingMachine.VendingMachine.Status
{
    public class StockItem
    {
        public StockItem(VendingStock item, int availableStock)
        {
            Item = item;
            AvailableStock = availableStock;
        }

        public VendingStock Item { get; }
        public int AvailableStock { get; set; }
    }
}