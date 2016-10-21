namespace VendingMachine.Models
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

        public override bool Equals(object obj)
        {
            var item = obj as StockItem;
            return item != null && (Item == item.Item && AvailableStock == item.AvailableStock);
        }
    }
}